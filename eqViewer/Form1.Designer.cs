namespace eqViewer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelDepth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEQTime = new System.Windows.Forms.Label();
            this.labelMagnitude = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaxInt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSingen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelEEWSource = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelEEWDepth = new System.Windows.Forms.Label();
            this.labelEEWMagnitude = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEEWInt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEEWHypocenter = new System.Windows.Forms.Label();
            this.labelEEWTime = new System.Windows.Forms.Label();
            this.labelEEWSokuho = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelNowTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 434);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "強震モニタ(NIED)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 452);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hi-Net 地震情報";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox1.Location = new System.Drawing.Point(6, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(351, 41);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(399, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 303);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "地震情報";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 270);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(8, 165);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(478, 157);
            this.textBox2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelComment);
            this.groupBox4.Controls.Add(this.labelDepth);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.labelEQTime);
            this.groupBox4.Controls.Add(this.labelMagnitude);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labelMaxInt);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.labelSingen);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(399, 321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 338);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "地震情報(詳細)";
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(6, 134);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(0, 12);
            this.labelComment.TabIndex = 11;
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(39, 106);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(0, 12);
            this.labelDepth.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "深さ:";
            // 
            // labelEQTime
            // 
            this.labelEQTime.AutoSize = true;
            this.labelEQTime.Location = new System.Drawing.Point(6, 18);
            this.labelEQTime.Name = "labelEQTime";
            this.labelEQTime.Size = new System.Drawing.Size(0, 12);
            this.labelEQTime.TabIndex = 8;
            // 
            // labelMagnitude
            // 
            this.labelMagnitude.AutoSize = true;
            this.labelMagnitude.Location = new System.Drawing.Point(82, 83);
            this.labelMagnitude.Name = "labelMagnitude";
            this.labelMagnitude.Size = new System.Drawing.Size(0, 12);
            this.labelMagnitude.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "マグニチュード:";
            // 
            // labelMaxInt
            // 
            this.labelMaxInt.AutoSize = true;
            this.labelMaxInt.Location = new System.Drawing.Point(67, 61);
            this.labelMaxInt.Name = "labelMaxInt";
            this.labelMaxInt.Size = new System.Drawing.Size(0, 12);
            this.labelMaxInt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "最大深度:";
            // 
            // labelSingen
            // 
            this.labelSingen.AutoSize = true;
            this.labelSingen.Location = new System.Drawing.Point(43, 39);
            this.labelSingen.Name = "labelSingen";
            this.labelSingen.Size = new System.Drawing.Size(0, 12);
            this.labelSingen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "震源:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelEEWSource);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.labelEEWDepth);
            this.groupBox5.Controls.Add(this.labelEEWMagnitude);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.labelEEWInt);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.labelEEWHypocenter);
            this.groupBox5.Controls.Add(this.labelEEWTime);
            this.groupBox5.Controls.Add(this.labelEEWSokuho);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(12, 528);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(363, 189);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "緊急地震速報";
            // 
            // labelEEWSource
            // 
            this.labelEEWSource.AutoSize = true;
            this.labelEEWSource.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEEWSource.Location = new System.Drawing.Point(240, 145);
            this.labelEEWSource.Name = "labelEEWSource";
            this.labelEEWSource.Size = new System.Drawing.Size(48, 22);
            this.labelEEWSource.TabIndex = 9;
            this.labelEEWSource.Text = "label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "発表：";
            // 
            // labelEEWDepth
            // 
            this.labelEEWDepth.AutoSize = true;
            this.labelEEWDepth.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEEWDepth.Location = new System.Drawing.Point(6, 145);
            this.labelEEWDepth.Name = "labelEEWDepth";
            this.labelEEWDepth.Size = new System.Drawing.Size(48, 22);
            this.labelEEWDepth.TabIndex = 7;
            this.labelEEWDepth.Text = "label";
            // 
            // labelEEWMagnitude
            // 
            this.labelEEWMagnitude.AutoSize = true;
            this.labelEEWMagnitude.Font = new System.Drawing.Font("M+ 2p", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEEWMagnitude.Location = new System.Drawing.Point(195, 97);
            this.labelEEWMagnitude.Name = "labelEEWMagnitude";
            this.labelEEWMagnitude.Size = new System.Drawing.Size(82, 38);
            this.labelEEWMagnitude.TabIndex = 6;
            this.labelEEWMagnitude.Text = "label";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(176, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "M";
            // 
            // labelEEWInt
            // 
            this.labelEEWInt.AutoSize = true;
            this.labelEEWInt.Font = new System.Drawing.Font("M+ 2p", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEEWInt.Location = new System.Drawing.Point(43, 97);
            this.labelEEWInt.Name = "labelEEWInt";
            this.labelEEWInt.Size = new System.Drawing.Size(82, 38);
            this.labelEEWInt.TabIndex = 4;
            this.labelEEWInt.Text = "label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "震度";
            // 
            // labelEEWHypocenter
            // 
            this.labelEEWHypocenter.AutoSize = true;
            this.labelEEWHypocenter.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEEWHypocenter.Location = new System.Drawing.Point(6, 76);
            this.labelEEWHypocenter.Name = "labelEEWHypocenter";
            this.labelEEWHypocenter.Size = new System.Drawing.Size(48, 22);
            this.labelEEWHypocenter.TabIndex = 2;
            this.labelEEWHypocenter.Text = "label";
            // 
            // labelEEWTime
            // 
            this.labelEEWTime.AutoSize = true;
            this.labelEEWTime.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEEWTime.Location = new System.Drawing.Point(6, 54);
            this.labelEEWTime.Name = "labelEEWTime";
            this.labelEEWTime.Size = new System.Drawing.Size(48, 22);
            this.labelEEWTime.TabIndex = 1;
            this.labelEEWTime.Text = "label";
            // 
            // labelEEWSokuho
            // 
            this.labelEEWSokuho.AutoSize = true;
            this.labelEEWSokuho.Font = new System.Drawing.Font("M+ 2p", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEEWSokuho.Location = new System.Drawing.Point(6, 25);
            this.labelEEWSokuho.Name = "labelEEWSokuho";
            this.labelEEWSokuho.Size = new System.Drawing.Size(48, 22);
            this.labelEEWSokuho.TabIndex = 0;
            this.labelEEWSokuho.Text = "label";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelNowTime);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(399, 665);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(284, 52);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "現在時刻";
            // 
            // labelNowTime
            // 
            this.labelNowTime.AutoSize = true;
            this.labelNowTime.Font = new System.Drawing.Font("M+ 2p black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelNowTime.Location = new System.Drawing.Point(12, 14);
            this.labelNowTime.Name = "labelNowTime";
            this.labelNowTime.Size = new System.Drawing.Size(260, 30);
            this.labelNowTime.TabIndex = 0;
            this.labelNowTime.Text = "2000/01/01 00:00:00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 673);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "手動更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(905, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EQViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelEQTime;
        private System.Windows.Forms.Label labelMagnitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaxInt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSingen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelEEWSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelEEWDepth;
        private System.Windows.Forms.Label labelEEWMagnitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEEWInt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEEWHypocenter;
        private System.Windows.Forms.Label labelEEWTime;
        private System.Windows.Forms.Label labelEEWSokuho;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelNowTime;
        private System.Windows.Forms.Button button1;
    }
}

