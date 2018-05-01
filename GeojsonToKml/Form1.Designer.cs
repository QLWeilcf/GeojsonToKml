namespace GeojsonToKml {
    partial class jTokForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jTokForm));
            this.convertBtn = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.inlabelt = new System.Windows.Forms.Label();
            this.inputTBox = new System.Windows.Forms.TextBox();
            this.inputfBtn = new System.Windows.Forms.Button();
            this.outputBtn = new System.Windows.Forms.Button();
            this.ouputTBox = new System.Windows.Forms.TextBox();
            this.outlabelt = new System.Windows.Forms.Label();
            this.lightcBox = new System.Windows.Forms.CheckBox();
            this.j2kmlRBtn = new System.Windows.Forms.RadioButton();
            this.k2jsonRBtn = new System.Windows.Forms.RadioButton();
            this.c2jsonRBtn = new System.Windows.Forms.RadioButton();
            this.j2csvRBtn = new System.Windows.Forms.RadioButton();
            this.c2kmlRBtn = new System.Windows.Forms.RadioButton();
            this.k2csvRBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // convertBtn
            // 
            this.convertBtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.convertBtn.Location = new System.Drawing.Point(504, 152);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(102, 36);
            this.convertBtn.TabIndex = 0;
            this.convertBtn.Text = "转换";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(1, 383);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(263, 12);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "选择待转换文件；选择转换方式；点击转换按钮.";
            // 
            // inlabelt
            // 
            this.inlabelt.AutoSize = true;
            this.inlabelt.Location = new System.Drawing.Point(12, 37);
            this.inlabelt.Name = "inlabelt";
            this.inlabelt.Size = new System.Drawing.Size(35, 12);
            this.inlabelt.TabIndex = 2;
            this.inlabelt.Text = "输入:";
            // 
            // inputTBox
            // 
            this.inputTBox.Location = new System.Drawing.Point(53, 33);
            this.inputTBox.Name = "inputTBox";
            this.inputTBox.Size = new System.Drawing.Size(483, 21);
            this.inputTBox.TabIndex = 3;
            this.inputTBox.TextChanged += new System.EventHandler(this.inputTBox_TextChanged);
            // 
            // inputfBtn
            // 
            this.inputfBtn.Location = new System.Drawing.Point(542, 33);
            this.inputfBtn.Name = "inputfBtn";
            this.inputfBtn.Size = new System.Drawing.Size(48, 21);
            this.inputfBtn.TabIndex = 4;
            this.inputfBtn.Text = "…";
            this.inputfBtn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.inputfBtn.UseVisualStyleBackColor = true;
            this.inputfBtn.Click += new System.EventHandler(this.inputfBtn_Click);
            // 
            // outputBtn
            // 
            this.outputBtn.Location = new System.Drawing.Point(542, 65);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(48, 21);
            this.outputBtn.TabIndex = 7;
            this.outputBtn.Text = "…";
            this.outputBtn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.outputBtn_Click);
            // 
            // ouputTBox
            // 
            this.ouputTBox.Location = new System.Drawing.Point(53, 65);
            this.ouputTBox.Name = "ouputTBox";
            this.ouputTBox.Size = new System.Drawing.Size(483, 21);
            this.ouputTBox.TabIndex = 6;
            this.ouputTBox.TextChanged += new System.EventHandler(this.ouputTBox_TextChanged);
            // 
            // outlabelt
            // 
            this.outlabelt.AutoSize = true;
            this.outlabelt.Location = new System.Drawing.Point(12, 70);
            this.outlabelt.Name = "outlabelt";
            this.outlabelt.Size = new System.Drawing.Size(35, 12);
            this.outlabelt.TabIndex = 5;
            this.outlabelt.Text = "输出:";
            // 
            // lightcBox
            // 
            this.lightcBox.AutoSize = true;
            this.lightcBox.Checked = true;
            this.lightcBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lightcBox.Location = new System.Drawing.Point(518, 220);
            this.lightcBox.Name = "lightcBox";
            this.lightcBox.Size = new System.Drawing.Size(72, 16);
            this.lightcBox.TabIndex = 8;
            this.lightcBox.Text = "轻量转换";
            this.lightcBox.UseVisualStyleBackColor = true;
            this.lightcBox.CheckedChanged += new System.EventHandler(this.lightcBox_CheckedChanged);
            // 
            // j2kmlRBtn
            // 
            this.j2kmlRBtn.AutoSize = true;
            this.j2kmlRBtn.Checked = true;
            this.j2kmlRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.j2kmlRBtn.Location = new System.Drawing.Point(83, 138);
            this.j2kmlRBtn.Name = "j2kmlRBtn";
            this.j2kmlRBtn.Size = new System.Drawing.Size(118, 24);
            this.j2kmlRBtn.TabIndex = 9;
            this.j2kmlRBtn.TabStop = true;
            this.j2kmlRBtn.Text = "JSON To KML";
            this.j2kmlRBtn.UseVisualStyleBackColor = true;
            this.j2kmlRBtn.CheckedChanged += new System.EventHandler(this.j2kmlRBtn_CheckedChanged);
            // 
            // k2jsonRBtn
            // 
            this.k2jsonRBtn.AutoSize = true;
            this.k2jsonRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.k2jsonRBtn.Location = new System.Drawing.Point(272, 138);
            this.k2jsonRBtn.Name = "k2jsonRBtn";
            this.k2jsonRBtn.Size = new System.Drawing.Size(118, 24);
            this.k2jsonRBtn.TabIndex = 10;
            this.k2jsonRBtn.Text = "KML To JSON";
            this.k2jsonRBtn.UseVisualStyleBackColor = true;
            this.k2jsonRBtn.CheckedChanged += new System.EventHandler(this.k2jsonRBtn_CheckedChanged);
            // 
            // c2jsonRBtn
            // 
            this.c2jsonRBtn.AutoSize = true;
            this.c2jsonRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c2jsonRBtn.Location = new System.Drawing.Point(272, 193);
            this.c2jsonRBtn.Name = "c2jsonRBtn";
            this.c2jsonRBtn.Size = new System.Drawing.Size(118, 24);
            this.c2jsonRBtn.TabIndex = 12;
            this.c2jsonRBtn.Text = "CSV  To JSON";
            this.c2jsonRBtn.UseVisualStyleBackColor = true;
            this.c2jsonRBtn.CheckedChanged += new System.EventHandler(this.c2jsonRBtn_CheckedChanged);
            // 
            // j2csvRBtn
            // 
            this.j2csvRBtn.AutoSize = true;
            this.j2csvRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.j2csvRBtn.Location = new System.Drawing.Point(83, 193);
            this.j2csvRBtn.Name = "j2csvRBtn";
            this.j2csvRBtn.Size = new System.Drawing.Size(114, 24);
            this.j2csvRBtn.TabIndex = 11;
            this.j2csvRBtn.Text = "JSON To CSV";
            this.j2csvRBtn.UseVisualStyleBackColor = true;
            this.j2csvRBtn.CheckedChanged += new System.EventHandler(this.j2csvRBtn_CheckedChanged);
            // 
            // c2kmlRBtn
            // 
            this.c2kmlRBtn.AutoSize = true;
            this.c2kmlRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c2kmlRBtn.Location = new System.Drawing.Point(272, 245);
            this.c2kmlRBtn.Name = "c2kmlRBtn";
            this.c2kmlRBtn.Size = new System.Drawing.Size(116, 24);
            this.c2kmlRBtn.TabIndex = 14;
            this.c2kmlRBtn.Text = "CSV  To  KML";
            this.c2kmlRBtn.UseVisualStyleBackColor = true;
            this.c2kmlRBtn.CheckedChanged += new System.EventHandler(this.c2kmlRBtn_CheckedChanged);
            // 
            // k2csvRBtn
            // 
            this.k2csvRBtn.AutoSize = true;
            this.k2csvRBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.k2csvRBtn.Location = new System.Drawing.Point(83, 245);
            this.k2csvRBtn.Name = "k2csvRBtn";
            this.k2csvRBtn.Size = new System.Drawing.Size(116, 24);
            this.k2csvRBtn.TabIndex = 13;
            this.k2csvRBtn.Text = "KML  To  CSV";
            this.k2csvRBtn.UseVisualStyleBackColor = true;
            this.k2csvRBtn.CheckedChanged += new System.EventHandler(this.k2csvRBtn_CheckedChanged);
            // 
            // jTokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 404);
            this.Controls.Add(this.c2kmlRBtn);
            this.Controls.Add(this.k2csvRBtn);
            this.Controls.Add(this.c2jsonRBtn);
            this.Controls.Add(this.j2csvRBtn);
            this.Controls.Add(this.k2jsonRBtn);
            this.Controls.Add(this.j2kmlRBtn);
            this.Controls.Add(this.lightcBox);
            this.Controls.Add(this.outputBtn);
            this.Controls.Add(this.ouputTBox);
            this.Controls.Add(this.outlabelt);
            this.Controls.Add(this.inputfBtn);
            this.Controls.Add(this.inputTBox);
            this.Controls.Add(this.inlabelt);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.convertBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "jTokForm";
            this.Text = "JCKconvert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label inlabelt;
        private System.Windows.Forms.TextBox inputTBox;
        private System.Windows.Forms.Button inputfBtn;
        private System.Windows.Forms.Button outputBtn;
        private System.Windows.Forms.TextBox ouputTBox;
        private System.Windows.Forms.Label outlabelt;
        private System.Windows.Forms.CheckBox lightcBox;
        private System.Windows.Forms.RadioButton j2kmlRBtn;
        private System.Windows.Forms.RadioButton k2jsonRBtn;
        private System.Windows.Forms.RadioButton c2jsonRBtn;
        private System.Windows.Forms.RadioButton j2csvRBtn;
        private System.Windows.Forms.RadioButton c2kmlRBtn;
        private System.Windows.Forms.RadioButton k2csvRBtn;
    }
}

