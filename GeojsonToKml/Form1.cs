using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        # region 转换方式的选择与更改
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
