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
        string cachedEEWSerial = null;
        bool startup = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getServerTime();
            comboBoxKyoshinType.SelectedIndex = 0;
            pictureBox1.ImageLocation = kyoshinUrl();
            textBox1.Text = hinetInfo();
            pictureBox2.ImageLocation = eqUrl();
            textBox2.Text = sindo();
            eew();
            labelNowTime.Text = updateNowTime();
            timer1.Start();
            timer2.Start();
        }

        public void getServerTime()
        {
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = wc.DownloadString("http://www.kmoni.bosai.go.jp/webservice/server/pros/latest.json");
            var data = JsonConvert.DeserializeObject<server>(json);
            dt = DateTime.Parse(data.latest_time);
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
            int cached_bg = 0;
            time = dt.AddSeconds(-2).ToString("yyyyMMddHHmmss");
            date = dt.AddSeconds(-2).ToString("yyyyMMdd");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Bitmap bmp = new Bitmap(assembly.GetManifestResourceStream("eqViewer.base_sindo.png"));
            //return $"https://realtime-earthquake-monitor.appspot.com/jma_s/{time}";
            if (comboBoxKyoshinType.SelectedIndex == 0 && cached_bg != 0)
            {
                bmp = new Bitmap(assembly.GetManifestResourceStream("eqViewer.base_sindo.png"));
                cached_bg = 0;
            }
            else if (comboBoxKyoshinType.SelectedIndex == 1 && cached_bg != 1)
            {
                bmp = new Bitmap(assembly.GetManifestResourceStream("eqViewer.base_pga.png"));
                cached_bg = 1;
            }
            else if((comboBoxKyoshinType.SelectedIndex == 2 || comboBoxKyoshinType.SelectedIndex == 4 || comboBoxKyoshinType.SelectedIndex == 5 || comboBoxKyoshinType.SelectedIndex == 6 || comboBoxKyoshinType.SelectedIndex == 7 || comboBoxKyoshinType.SelectedIndex == 8 || comboBoxKyoshinType.SelectedIndex == 9) && cached_bg != 2)
            {
                bmp = new Bitmap(assembly.GetManifestResourceStream("eqViewer.base_pgv.png"));
                cached_bg = 2;
            }
            else if(comboBoxKyoshinType.SelectedIndex == 3 && cached_bg != 3)
            {
                bmp = new Bitmap(assembly.GetManifestResourceStream("eqViewer.base_pgd.png"));
                cached_bg = 3;
            }
            pictureBox1.BackgroundImage = bmp;
            switch (comboBoxKyoshinType.SelectedIndex)
            {
                case 0:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/jma_s/{date}/{time}.jma_s.gif";
                case 1:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/acmap_s/{date}/{time}.acmap_s.gif";
                case 2:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/vcmap_s/{date}/{time}.vcmap_s.gif";
                case 3:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/dcmap_s/{date}/{time}.dcmap_s.gif";
                case 4:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp0125_s/{date}/{time}.rsp0125_s.gif";
                case 5:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp0250_s/{date}/{time}.rsp0250_s.gif";
                case 6:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp0500_s/{date}/{time}.rsp0500_s.gif";
                case 7:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp1000_s/{date}/{time}.rsp1000_s.gif";
                case 8:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp2000_s/{date}/{time}.rsp2000_s.gif";
                case 9:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/rsp4000_s/{date}/{time}.rsp4000_s.gif";
                default:
                    return $"http://www.kmoni.bosai.go.jp/data/map_img/RealTimeImg/jma_s/{date}/{time}.jma_s.gif";
            }
            
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
            string time = dt.ToString("yyyyMMddHHmmss");
            string json = "";
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            try
            {
                json = wc.DownloadString($"http://www.kmoni.bosai.go.jp/webservice/hypo/eew/{time}.json");
                var data = JsonConvert.DeserializeObject<eew>(json);
                if (data.result.status == "success" && data.result.message != "データがありません")
                {
                    if (startup == true)
                    {
                        startup = false;
                        cachedEEWSerial = data.report_num;
                    }
                    else
                    {
                        if (cachedEEWSerial != data.report_num)
                        {
                            cachedEEWSerial = data.report_num;
                            notifyIcon2.BalloonTipTitle = $"緊急地震速報({data.alertflg}第{data.report_num}報";
                            if (data.is_final == true) notifyIcon2.BalloonTipTitle += " 最終報";
                            notifyIcon2.BalloonTipTitle += ")";
                            notifyIcon2.BalloonTipText = $"{data.report_time} 発表\r\n震源:{data.region_name}\r\n震度{data.calcintensity} M{data.magunitude}";
                            notifyIcon2.BalloonTipIcon = ToolTipIcon.Info;
                            notifyIcon2.ShowBalloonTip(3000);
                        }
                    }
                    labelEEWSokuho.Text = $"緊急地震速報({data.alertflg}第{data.report_num}報";
                    if (data.is_final == true) labelEEWSokuho.Text += " 最終報";
                    labelEEWSokuho.Text += ")";
                    labelEEWTime.Text = $"{data.report_time} 発表";
                    labelEEWHypocenter.Text = data.region_name;
                    labelEEWInt.Text = data.calcintensity;
                    labelEEWMagnitude.Text = data.magunitude;
                    labelEEWDepth.Text = data.depth;
                }
            }
            catch (Exception)
            {
            }
        }

        public string updateNowTime()
        {
            return dt.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            getServerTime();
            pictureBox1.ImageLocation = kyoshinUrl();
            eew();
            labelNowTime.Text = updateNowTime();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            getServerTime();
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
        public Result result { get; set; }
        public string report_time { get; set; }
        public string region_code { get; set; }
        public string request_time { get; set; }
        public string region_name { get; set; }
        public string longitude { get; set; }
        public bool is_cancel { get; set; }
        public string depth { get; set; }
        public string calcintensity { get; set; }
        public bool is_final { get; set; }
        public bool is_training { get; set; }
        public string latitude { get; set; }
        public string origin_time { get; set; }
        public Security security { get; set; }
        public string magunitude { get; set; }
        public string report_num { get; set; }
        public string request_hypo_type { get; set; }
        public string report_id { get; set; }
        public string alertflg { get; set; }
    }

    public class Result
    {
        public string status { get; set; }
        public string message { get; set; }
        public bool is_auth { get; set; }
    }

    public class Security
    {
        public string realm { get; set; }
        public string hash { get; set; }
    }


    public class server
    {
        public Security_s security { get; set; }
        public string latest_time { get; set; }
        public string request_time { get; set; }
        public Result_s result { get; set; }
    }

    public class Security_s
    {
        public string realm { get; set; }
        public string hash { get; set; }
    }

    public class Result_s
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}
