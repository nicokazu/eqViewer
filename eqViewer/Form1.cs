using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eqViewer
{
    public partial class Form1 : Form
    {
        DateTime dt = new DateTime();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = kyoshinUrl();
            textBox1.Text = hinetInfo();
            pictureBox2.ImageLocation = eqUrl();
            textBox2.Text = sindo();
            eew();
            labelNowTime.Text = updateNowTime();
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        public string hinetInfo()
        {
            string info = "[Hi-Net] ";
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.GetEncoding("euc-jp");
            var doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.Load(wc.OpenRead("http://www.hinet.bosai.go.jp/?LANG=ja"), Encoding.GetEncoding("euc-jp"));
                var node = doc.DocumentNode.SelectNodes("//table[@class='top_rtmap']//td[@class='td3']");
                info += $"{node[1].InnerText.ToString()} {node[0].InnerText.ToString()}({node[2].InnerText.ToString()}, {node[3].InnerText.ToString()}) M{node[5].InnerText.ToString()} {node[4].InnerText.ToString()}";
            }
            catch (Exception e)
            {
                info += $"ERROR: {e.Message}";
            }

            return info;
        }

        public string kyoshinUrl()
        {
            string time;
            dt = DateTime.Now;
            if (dt.Second % 2 == 0)
            {
                time = dt.AddSeconds(-2).ToString("yyyyMMddHHmmss");
            }
            else
            {
                time = dt.AddSeconds(-3).ToString("yyyyMMddHHmmss");
            }
            return $"https://realtime-earthquake-monitor.appspot.com/jma_s/{time}";
        }

        public string eqUrl()
        {
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("https://quake.one/api/list.json?limit=1");
            var data = JsonConvert.DeserializeObject<Rootobject>(json);
            return $"http://files.quake.one/{data.objects[0].EventID}/image.png";
        }
        public string sindo()
        {
            string eq = "";
            int sindo;
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("https://quake.one/api/list.json?limit=1");
            var data = JsonConvert.DeserializeObject<Rootobject>(json);
            json = wc.DownloadString($"http://files.quake.one/{data.objects[0].EventID}/largeScalePoints.json");
            var info = JsonConvert.DeserializeObject<quakeInfo>(json);
            json = wc.DownloadString($"http://files.quake.one/{data.objects[0].EventID}/info.json");
            var detail = JsonConvert.DeserializeObject<quakeDetail>(json);
            eq += $"【震度{info.features[1].properties.@class}】";
            sindo = int.Parse(info.features[1].properties.@class);
            for (int i = 1; i < info.features.Length; i++)
            {
                if (int.Parse(info.features[i].properties.@class) != sindo)
                {
                    eq += $"\r\n【震度{info.features[i].properties.@class}】";
                    sindo = int.Parse(info.features[i].properties.@class);
                }
                eq += $"{info.features[i].properties.name}, ";
            }
            labelEQTime.Text = data.objects[0].OriginDateTime.ToString("yyyy年MM月dd日 HH時mm分ごろ");
            labelSingen.Text = data.objects[0].Hypocenter;
            labelMaxInt.Text = data.objects[0].MaxInt;
            labelMagnitude.Text = data.objects[0].Magnitude;
            detail.Hypocenter.Depth *= -1;
            if (detail.Hypocenter.Depth >= 1000) labelDepth.Text = (detail.Hypocenter.Depth / 1000).ToString("# Km");
            else labelDepth.Text = detail.Hypocenter.Depth.ToString("# m");
            labelComment.Text = detail.Comments;
            return eq;
        }

        public void eew()
        {
            string info = "";
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("https://api.iedred7584.com/eew/json/");
            var data = JsonConvert.DeserializeObject<eew>(json);
            if(data.ParseStatus == "Success")
            {
                labelEEWSokuho.Text = $"{data.Title.String.Substring(0, data.Title.String.Length - 1)}第{data.Serial}報";
                if (data.Type.Code == 9) labelEEWSokuho.Text += " 最終報";
                labelEEWSokuho.Text += "）";
                labelEEWTime.Text = $"{data.OriginTime.String} 発生";
                labelEEWHypocenter.Text = data.Hypocenter.Name;
                labelEEWInt.Text = data.MaxIntensity.String;
                labelEEWMagnitude.Text = data.Hypocenter.Magnitude.Float.ToString();
                labelEEWDepth.Text = $"{data.Hypocenter.Location.Depth.Int}Km";
                labelEEWSource.Text = data.Source.String;
            }
        }

        public string updateNowTime()
        {
            dt = DateTime.Now;
            return dt.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = kyoshinUrl();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = eqUrl();
            textBox2.Text = sindo();
            textBox1.Text = hinetInfo();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            eew();
            labelNowTime.Text = updateNowTime();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = kyoshinUrl();
            textBox1.Text = hinetInfo();
            pictureBox2.ImageLocation = eqUrl();
            textBox2.Text = sindo();
            eew();
            labelNowTime.Text = updateNowTime();
        }
    }


    public class Rootobject
    {
        public Object[] objects { get; set; }
        public string next_cursor { get; set; }
    }

    public class Object
    {
        public string Hypocenter { get; set; }
        public string MaxInt { get; set; }
        public DateTime ReportDateTime { get; set; }
        public DateTime OriginDateTime { get; set; }
        public string Magnitude { get; set; }
        public string EventID { get; set; }
    }


    public class quakeInfo
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Propert properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Propert
    {
        public string @class { get; set; }
        public string area { get; set; }
        public string name { get; set; }
        public string coord_jp { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }


    public class quakeDetail
    {
        public string EventID { get; set; }
        public DateTime ReportDateTime { get; set; }
        public DateTime OriginDateTime { get; set; }
        public string MaxInt { get; set; }
        public string Magnitude { get; set; }
        public Hypocenter Hypocenter { get; set; }
        public string Comments { get; set; }
    }

    public class Hypocenter
    {
        public string Name { get; set; }
        public float[] Coordinate { get; set; }
        public int Depth { get; set; }
        public string Japanese { get; set; }
    }


    public class eew
    {
        public string ParseStatus { get; set; }
        public Title Title { get; set; }
        public Source Source { get; set; }
        public Status Status { get; set; }
        public Announcedtime AnnouncedTime { get; set; }
        public Origintime OriginTime { get; set; }
        public string EventID { get; set; }
        public Type Type { get; set; }
        public int Serial { get; set; }
        public Hypocenter_eew Hypocenter { get; set; }
        public Maxintensity MaxIntensity { get; set; }
        public bool Warn { get; set; }
        public Option Option { get; set; }
        public string OriginalText { get; set; }
    }

    public class Title
    {
        public int Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class Source
    {
        public int Code { get; set; }
        public string String { get; set; }
    }

    public class Status
    {
        public string Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class Announcedtime
    {
        public string String { get; set; }
        public int UnixTime { get; set; }
        public string RFC1123 { get; set; }
    }

    public class Origintime
    {
        public string String { get; set; }
        public int UnixTime { get; set; }
        public string RFC1123 { get; set; }
    }

    public class Type
    {
        public int Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class Hypocenter_eew
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public bool isAssumption { get; set; }
        public Location Location { get; set; }
        public Magnitude Magnitude { get; set; }
        public Accuracy Accuracy { get; set; }
        public bool isSea { get; set; }
    }

    public class Location
    {
        public float Lat { get; set; }
        public float Long { get; set; }
        public Depth Depth { get; set; }
    }

    public class Depth
    {
        public int Int { get; set; }
        public string String { get; set; }
    }

    public class Magnitude
    {
        public float Float { get; set; }
        public string String { get; set; }
        public string LongString { get; set; }
    }

    public class Accuracy
    {
        public Epicenter Epicenter { get; set; }
        public Depth1 Depth { get; set; }
        public Magnitude1 Magnitude { get; set; }
        public int NumberOfMagnitudeCalculation { get; set; }
    }

    public class Epicenter
    {
        public int Code { get; set; }
        public string String { get; set; }
        public int Rank2 { get; set; }
        public string String2 { get; set; }
    }

    public class Depth1
    {
        public int Code { get; set; }
        public string String { get; set; }
    }

    public class Magnitude1
    {
        public int Code { get; set; }
        public string String { get; set; }
    }

    public class Maxintensity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string String { get; set; }
        public string LongString { get; set; }
    }

    public class Option
    {
        public Change Change { get; set; }
    }

    public class Change
    {
        public int Code { get; set; }
        public string String { get; set; }
        public Reason Reason { get; set; }
    }

    public class Reason
    {
        public int Code { get; set; }
        public string String { get; set; }
    }


}
