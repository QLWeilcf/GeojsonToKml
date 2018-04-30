using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GeojsonToKml {
    public partial class jTokForm : Form {
        private int convType = 1;//1:j2k; 2:k2j; 3:j2c; 4:k2j; 5:k2c; 6:c2k
        private bool isLightWconvert = true;
        private string inputFile = "";
        private string outputFile = "D:/jsonToKmlProjectOutput.txt";
        public jTokForm () {
            InitializeComponent();
        }

        #region 按钮交互部分
        //转换按钮
        private void convertBtn_Click (object sender, EventArgs e) {

            //转换完成后在infolbl显示提示和文件保存位置
        }
        //选择输入文件
        private void inputfBtn_Click (object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JSON(*.geojson)|*.geojson;|KML(*.kml)|*.kml;|CSV(*.csv)|*.csv";
            openFile.Title = "选择待转文件";
            if (openFile.ShowDialog() == DialogResult.OK) {
                inputFile = openFile.FileName;
                inputTBox.Text = inputFile;
            }
        }
        // 选择输出文件
        private void outputBtn_Click (object sender, EventArgs e) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "JSON(*.geojson)|*.geojson;|KML(*.kml)|*.kml;|CSV(*.csv)|*.csv;|所有文件(*.*)|*.*";
            saveFile.Title = "选择保存文件及目录";
            if (saveFile.ShowDialog() == DialogResult.OK) {
                outputFile = saveFile.FileName;
                ouputTBox.Text = outputFile;
            }
        }

        #endregion

        #region 转换实现部分

        private void geojsonToKml () {
            if (inputFile == "") {
                inputFile = "E:/ComputerGraphicsProj/Geojson2kml/J2K_data/最简单的json.geojson";
            }
            StreamReader sr = new StreamReader(inputFile, Encoding.UTF8);
            JObject o = JObject.Parse(sr.ReadToEnd());

            JToken jfts = o["features"];
            //int aslwq3 = jfts.Count<JToken>();
            XmlDocument xmlVer = new XmlDocument();
            XmlDeclaration xd1 = xmlVer.CreateXmlDeclaration("1.0", "UTF-8", null);//这一句还是必须有的
            XmlElement rootElt = xmlVer.CreateElement("kml", "http://www.opengis.net/kml/2.2");
            //xmlID.DocumentElement
            XmlElement xname = xmlVer.CreateElement("name");

            XmlElement xdesc = xmlVer.CreateElement("description");
            XmlElement xopen = xmlVer.CreateElement("open");
            xopen.InnerText = "";
            xname.InnerText = "";
            xdesc.InnerText = "";
            XmlElement xdoc = xmlVer.CreateElement("Document");
            //XmlElement xfder = xmlVer.CreateElement("Folder");
            //XmlElement xpmk = xmlVer.CreateElement("Placemark");
            //xpmk.InnerText = "";
            xdoc.AppendChild(xname);
            xdoc.AppendChild(xopen);
            xdoc.AppendChild(xdesc);
            //XmlElement xw1=new XmlElement()
            //List<XmlElement> xepmllst = new List<XmlElement>();

            List<JToken> jlst = jfts.ToList<JToken>();
            int jlen = jlst.Count;

            for (int i = 0; i < jlen; i++) {
                // prop的处理
                string jt1 = (string)jlst[i]["geometry"]["type"];
                if (jt1 == "Point") {
                    XmlElement xcoord1 = xmlVer.CreateElement("coordinates");
                    Array al1 = jlst[i]["geometry"]["coordinates"].ToArray();
                    xcoord1.InnerText = coordPoint(al1);
                    XmlElement xpoi1 = xmlVer.CreateElement("Point");
                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    xpoi1.AppendChild(xcoord1);
                    xpmk1.AppendChild(xpoi1);
                    xdoc.AppendChild(xpmk1);//不加文件夹封装
                    //xepmllst.Add(xpmk1);
                }
                else if (jt1 == "MultiPoint") {
                    Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray();
                    List<string> jstlst = coordMultiPoint(arr1);
                    XmlElement xmugeo1 = xmlVer.CreateElement("MultiGeometry");
                    for (int kw = 0; kw < jstlst.Count; kw++) {
                        XmlElement xcoord1 = xmlVer.CreateElement("coordinates");
                        xcoord1.InnerText = jstlst[kw];
                        XmlElement xpoi1 = xmlVer.CreateElement("Point");
                        xpoi1.AppendChild(xcoord1);
                        xmugeo1.AppendChild(xpoi1);
                    }

                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    XmlElement xtd1 = xmlVer.CreateElement("ExtendedData");
                    xtd1.InnerText = "";
                    xpmk1.AppendChild(xtd1);
                    xpmk1.AppendChild(xmugeo1);
                    xdoc.AppendChild(xpmk1);
                }
                else if (jt1 == "LineString") {
                    Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray();
                    XmlElement xline = xmlVer.CreateElement("LineString");
                    XmlElement xcoord1 = xmlVer.CreateElement("coordinates");
                    xcoord1.InnerText = coordMLineTostr(arr1);

                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    XmlElement xtd1 = xmlVer.CreateElement("ExtendedData");
                    xtd1.InnerText = " ";
                    xpmk1.AppendChild(xtd1);
                    xline.AppendChild(xcoord1);
                    xpmk1.AppendChild(xline);
                    xdoc.AppendChild(xpmk1);
                }
                else if (jt1 == "MultiLineString") {
                    Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray(); //对应三维数组
                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    XmlElement xtd1 = xmlVer.CreateElement("ExtendedData");
                    xtd1.InnerText = "";
                    xpmk1.AppendChild(xtd1);
                    XmlElement mlgeo = xmlVer.CreateElement("MultiGeometry");
                    for (int j = 0; j < arr1.Length; j++) {

                        JArray arrT = (JArray)arr1.GetValue(j);//“二维”列表，每一个子元素是一个点
                        Array b2 = arrT.ToArray();
                        XmlElement xcdnt = xmlVer.CreateElement("coordinates");
                        xcdnt.InnerText = coordMLineTostr(b2);
                        XmlElement xmline = xmlVer.CreateElement("LineString");
                        xmline.AppendChild(xcdnt);
                        mlgeo.AppendChild(xmline);
                    }
                    xpmk1.AppendChild(mlgeo);
                    xdoc.AppendChild(xpmk1);
                }
                else if (jt1 == "Polygon") {
                    Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray();//三维数组

                    XmlElement xpoly = coordPolyToXEM(xmlVer, arr1);//
                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    XmlElement xtd1 = xmlVer.CreateElement("ExtendedData");
                    xtd1.InnerText = "";
                    xpmk1.AppendChild(xtd1);
                    xpmk1.AppendChild(xpoly);
                    xdoc.AppendChild(xpmk1);
                }
                else if (jt1 == "MultiPolygon") {
                    XmlElement xpmk1 = xmlVer.CreateElement("Placemark");
                    XmlElement xtd1 = xmlVer.CreateElement("ExtendedData");
                    xtd1.InnerText = "";
                    xpmk1.AppendChild(xtd1);
                    XmlElement xmulgeo = xmlVer.CreateElement("MultiGeometry");
                    Array arr1 = jlst[i]["geometry"]["coordinates"].ToArray();//四维数组
                    for (int mk = 0; mk < arr1.Length; mk++) {
                        JArray jarr = (JArray)arr1.GetValue(mk);
                        //List<JToken> b = arrT.ToList<JToken>(); //“二维”列表，每一个子元素是一个点
                        Array b2 = jarr.ToArray();
                        XmlElement xpolyw = coordPolyToXEM(xmlVer, b2);
                        xmulgeo.AppendChild(xpolyw);
                    }
                    xpmk1.AppendChild(xmulgeo);
                    xdoc.AppendChild(xpmk1);
                }
                else if (jt1 == "GeometryCollection") {


                }
                else {
                    Console.Write("there something err");
                }
            }


            rootElt.AppendChild(xdoc);
            xmlVer.AppendChild(xd1);
            xmlVer.AppendChild(rootElt);
            xmlVer.Save(outputFile);
            infoLabel.Text = "output at:" + outputFile;
            
        }



        #endregion

        #region 辅助解析函数
        /// <summary>
        /// 多边形压制为xml元素
        /// </summary>
        /// <param name="xdc"></param>
        /// <param name="arrw"></param>
        /// <returns></returns>
        public XmlElement coordPolyToXEM (XmlDocument xdc, Array arrw) {
            //输入为3维数组
            XmlElement xpoly = xdc.CreateElement("Polygon");

            int arrlen = arrw.Length;
            for (int i = 0; i < arrlen; i++) {
                XmlElement xbndary = xdc.CreateElement("innerBoundaryIs");
                if (i == 0) {
                    xbndary = xdc.CreateElement("outerBoundaryIs");
                }
                JArray arrT = (JArray)arrw.GetValue(i);
                List<JToken> b = arrT.ToList<JToken>(); //“二维”列表，每一个子元素是一个点
                Array b2 = b.ToArray();
                XmlElement xcdnt = xdc.CreateElement("coordinates");
                xcdnt.InnerText = coordMLineTostr(b2);
                XmlElement xliner = xdc.CreateElement("LinearRing");
                xliner.AppendChild(xcdnt);
                xbndary.AppendChild(xliner);
                xpoly.AppendChild(xbndary);
            }
            return xpoly;
        }

        /// <summary>
        /// 线要素处理；二维数组转字符串
        /// </summary>
        /// <param name="arrw">输入二维数组</param>
        /// <returns>点坐标序列字符串</returns>
        public string coordMLineTostr (Array arrw) {
            string outlst = "";
            int arrlen = arrw.Length;
            for (int i = 0; i < arrlen; i++) {
                JArray arr = (JArray)arrw.GetValue(i);
                int awlen = arr.Count;
                if (awlen == 2) {
                    outlst = outlst + (arr[0].ToString() + "," + arr[1].ToString()) + " ";
                }
                else if (awlen == 3) {
                    outlst = outlst + (arr[0].ToString() + "," + arr[1].ToString()
                        + "," + arr[2].ToString()) + " ";
                }
                else {
                    throw new ArgumentException("输入参数长度arrlen应该为2或3");
                }
            }
            return outlst;
        }


        //[12.2,134323] ==> "12.2,134323"
        public string coordPoint (Array arr) {
            string rw = "";
            int arrlen = arr.Length;
            if (arrlen == 2) {
                return arr.GetValue(0).ToString() + "," + arr.GetValue(1).ToString();
            }
            else if (arrlen == 3) {
                return arr.GetValue(0).ToString() + "," + arr.GetValue(1).ToString()
                    + "," + arr.GetValue(2).ToString();
            }
            else {
                throw new ArgumentException("输入参数长度arrlen应该为2或3");
            }
        }

        //[[105.380859375,31.57853542647338],[105.580859375,31.52853542647338]] 
        //==> ["12.2,134323","105.580,31.52"] List<string>
        public List<string> coordMultiPoint (Array arrw) {
            List<string> outlst = new List<string>();
            int arrlen = arrw.Length;
            for (int i = 0; i < arrlen; i++) {
                string rw = "";
                JArray arr = (JArray)arrw.GetValue(i);
                int awlen = arr.Count;
                if (awlen == 2) {
                    outlst.Add(arr[0].ToString() + "," + arr[1].ToString());
                }
                else if (awlen == 3) {
                    outlst.Add(arr[0].ToString() + "," + arr[1].ToString()
                        + "," + arr[2].ToString());
                }
                else {
                    throw new ArgumentException("输入参数长度arrlen应该为2或3");
                }
            }
            return outlst;
        }

        #endregion


        #region 转换方式的选择与更改
        private void j2kmlRBtn_CheckedChanged (object sender, EventArgs e) {
            if (j2kmlRBtn.Checked) {
                convType = 1;
            }
        }

        private void k2jsonRBtn_CheckedChanged (object sender, EventArgs e) {
            if (k2jsonRBtn.Checked) {
                convType = 2;
            }
        }

        private void j2csvRBtn_CheckedChanged (object sender, EventArgs e) {
            if (j2csvRBtn.Checked) {
                convType = 3;
            }
        }

        private void c2jsonRBtn_CheckedChanged (object sender, EventArgs e) {
            if (c2jsonRBtn.Checked) {
                convType = 4;
            }
        }

        private void k2csvRBtn_CheckedChanged (object sender, EventArgs e) {
            if (k2csvRBtn.Checked) {
                convType = 5;
            }
        }

        private void c2kmlRBtn_CheckedChanged (object sender, EventArgs e) {
            if (c2kmlRBtn.Checked) {
                convType = 6;
            }
        }

        private void lightcBox_CheckedChanged (object sender, EventArgs e) {
            if (lightcBox.Checked) {
                isLightWconvert = true;
            }
            else {
                isLightWconvert = false;
            }
        }
        #endregion

    }
}
