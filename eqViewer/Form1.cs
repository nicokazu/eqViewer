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
        DateTime? cachedEQTime = null;
        int? cachedEEWSerial = null;
        bool startup = true;
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
            string time, date;
            dt = DateTime.Now;
            time = dt.AddSeconds(-2).ToString("yyyyMMddHHmmss");
            date = dt.AddSeconds(-2).ToString("yyyyMMdd");
            //return $"https://realtime-earthquake-monitor.appspot.com/jma_s/{time}";
            return $"http://www.kmoni.bosai.go.jp/new/data/map_img/RealTimeImg/jma_s/{date}/{time}.jma_s.gif";
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
            string[] Int = { "7", "6+", "6-", "5+", "5-", "4", "3", "2", "1" };
            string eq = "";
            int judge = 0;
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("https://quake.one/api/list.json?limit=1");
            var data = JsonConvert.DeserializeObject<Rootobject>(json);
            json = wc.DownloadString($"http://files.quake.one/{data.objects[0].EventID}/largeScalePoints.json");
            var info = JsonConvert.DeserializeObject<quakeInfo>(json);
            json = wc.DownloadString($"http://files.quake.one/{data.objects[0].EventID}/info.json");
            var detail = JsonConvert.DeserializeObject<quakeDetail>(json);
            for (int i = 0; i < Int.Length; i++)
            {
                judge = 0;
                for (int j = 1; j < info.features.Length; j++)
                {
                    if (info.features[j].properties.@class == Int[i])
                    {
                        judge++;
                        if (judge == 1)
                        {
                            eq += $"【震度{Int[i]}】";
                        }
                        eq += info.features[j].properties.name + ", ";
                    }
                }
                if(judge != 0)  eq += "\r\n";
            }
            if (cachedEQTime != data.objects[0].OriginDateTime)
            {
                cachedEQTime = data.objects[0].OriginDateTime;
                notifyIcon1.BalloonTipTitle = $"最大震度{data.objects[0].MaxInt}の地震情報を取得しました。";
                notifyIcon1.BalloonTipText = $"{data.objects[0].OriginDateTime.ToString("yyyy年MM月dd日 HH時mm分ごろ")}\r\n震源:{data.objects[0].Hypocenter} M{data.objects[0].Magnitude}\r\n{detail.Comments}";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(3000);
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
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("https://api.iedred7584.com/eew/json/");
            var data = JsonConvert.DeserializeObject<eew>(json);
            if(data.ParseStatus == "Success")
            {
                if (startup == true)
                {
                    startup = false;
                    cachedEEWSerial = data.Serial;
                }
                else
                {
                    if (cachedEEWSerial != data.Serial)
                    {
                        cachedEEWSerial = data.Serial;
                        notifyIcon2.BalloonTipTitle = $"{data.Title.String.Substring(0, data.Title.String.Length - 1)}第{data.Serial}報";
                        if (data.Type.Code == 9) notifyIcon2.BalloonTipTitle += " 最終報";
                        notifyIcon2.BalloonTipTitle += "）";
                        notifyIcon2.BalloonTipText = $"{data.OriginTime.String} 発表\r\n震源:{data.Hypocenter.Name} M{data.Hypocenter.Magnitude.Float.ToString("0.0")}\r\nソース: {data.Source.String}";
                        notifyIcon2.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon2.ShowBalloonTip(3000);
                    }
                }
                labelEEWSokuho.Text = $"{data.Title.String.Substring(0, data.Title.String.Length - 1)}第{data.Serial}報";
                if (data.Type.Code == 9) labelEEWSokuho.Text += " 最終報";
                labelEEWSokuho.Text += "）";
                labelEEWTime.Text = $"{data.OriginTime.String} 発生";
                labelEEWHypocenter.Text = data.Hypocenter.Name;
                labelEEWInt.Text = data.MaxIntensity.String;
                labelEEWMagnitude.Text = data.Hypocenter.Magnitude.Float.ToString("0.0");
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
            eew();
            labelNowTime.Text = updateNowTime();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = eqUrl();
            textBox2.Text = sindo();
            textBox1.Text = hinetInfo();
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
