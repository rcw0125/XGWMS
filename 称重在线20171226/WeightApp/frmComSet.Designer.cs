namespace WeightApp
{
    partial class frmComSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbHandShake = new System.Windows.Forms.ComboBox();
            this.cmbparity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.txtbaudRate = new System.Windows.Forms.TextBox();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nujh = new System.Windows.Forms.NumericUpDown();
            this.lampZero = new LFY.UI.Controls.Glass.GlassLamp();
            this.txtdatalen = new System.Windows.Forms.TextBox();
            this.txtpoint = new System.Windows.Forms.TextBox();
            this.txtTestvalue = new System.Windows.Forms.TextBox();
            this.s = new System.IO.Ports.SerialPort(this.components);
            this.txtdataChare = new System.Windows.Forms.TextBox();
            this.txtdataChars = new System.Windows.Forms.TextBox();
            this.txtdatae = new System.Windows.Forms.TextBox();
            this.txtdatas = new System.Windows.Forms.TextBox();
            this.cmbDtrEnable = new System.Windows.Forms.ComboBox();
            this.cmbRtsEnable = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ckHandShake = new System.Windows.Forms.CheckBox();
            this.ckRtsEnable = new System.Windows.Forms.CheckBox();
            this.ckDtrEnable = new System.Windows.Forms.CheckBox();
            this.ckdatalen = new System.Windows.Forms.CheckBox();
            this.ckdatas = new System.Windows.Forms.CheckBox();
            this.ckdatae = new System.Windows.Forms.CheckBox();
            this.ckpoint = new System.Windows.Forms.CheckBox();
            this.ckdataChars = new System.Windows.Forms.CheckBox();
            this.ckdataChare = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nudqsjg = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nujh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudqsjg)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbHandShake
            // 
            this.cmbHandShake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHandShake.FormattingEnabled = true;
            this.cmbHandShake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.cmbHandShake.Location = new System.Drawing.Point(144, 134);
            this.cmbHandShake.Name = "cmbHandShake";
            this.cmbHandShake.Size = new System.Drawing.Size(121, 20);
            this.cmbHandShake.TabIndex = 125;
            // 
            // cmbparity
            // 
            this.cmbparity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbparity.FormattingEnabled = true;
            this.cmbparity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cmbparity.Location = new System.Drawing.Point(144, 107);
            this.cmbparity.Name = "cmbparity";
            this.cmbparity.Size = new System.Drawing.Size(121, 20);
            this.cmbparity.TabIndex = 124;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.cmbStopBits.Location = new System.Drawing.Point(144, 79);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(121, 20);
            this.cmbStopBits.TabIndex = 123;
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(144, 54);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(121, 21);
            this.txtDataBits.TabIndex = 122;
            // 
            // txtbaudRate
            // 
            this.txtbaudRate.Location = new System.Drawing.Point(144, 31);
            this.txtbaudRate.Name = "txtbaudRate";
            this.txtbaudRate.Size = new System.Drawing.Size(121, 21);
            this.txtbaudRate.TabIndex = 121;
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cmbCom.Location = new System.Drawing.Point(144, 9);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(121, 20);
            this.cmbCom.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 113;
            this.label5.Text = "奇偶校验";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 111;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 110;
            this.label2.Text = "波特率";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(179, 447);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 115;
            this.btncancel.Text = "关闭";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(98, 447);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 114;
            this.btnok.Text = "确定";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 112;
            this.label4.Text = "停止位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 109;
            this.label1.Text = "COM";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(280, 9);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtError.Size = new System.Drawing.Size(356, 285);
            this.txtError.TabIndex = 144;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(278, 356);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 12);
            this.label15.TabIndex = 143;
            this.label15.Text = "重量静荷改变次数";
            // 
            // nujh
            // 
            this.nujh.Location = new System.Drawing.Point(280, 378);
            this.nujh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nujh.Name = "nujh";
            this.nujh.Size = new System.Drawing.Size(48, 21);
            this.nujh.TabIndex = 142;
            this.nujh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lampZero
            // 
            this.lampZero.BackColor = System.Drawing.Color.Transparent;
            this.lampZero.BorderColor = System.Drawing.Color.Black;
            this.lampZero.Depth = 3;
            this.lampZero.DisabledGradient.Bottom = System.Drawing.Color.Red;
            this.lampZero.DisabledGradient.Top = System.Drawing.Color.IndianRed;
            this.lampZero.Error = true;
            this.lampZero.ErrorEx = true;
            this.lampZero.Location = new System.Drawing.Point(363, 371);
            this.lampZero.Name = "lampZero";
            this.lampZero.Size = new System.Drawing.Size(29, 33);
            this.lampZero.Step = 4;
            this.lampZero.TabIndex = 0;
            this.lampZero.TabStop = false;
            this.lampZero.Text = "glassLamp1";
            this.lampZero.Tip = "";
            this.lampZero.UseVisualStyleBackColor = true;
            // 
            // txtdatalen
            // 
            this.txtdatalen.Location = new System.Drawing.Point(144, 223);
            this.txtdatalen.Name = "txtdatalen";
            this.txtdatalen.Size = new System.Drawing.Size(121, 21);
            this.txtdatalen.TabIndex = 140;
            // 
            // txtpoint
            // 
            this.txtpoint.Location = new System.Drawing.Point(144, 303);
            this.txtpoint.Name = "txtpoint";
            this.txtpoint.Size = new System.Drawing.Size(121, 21);
            this.txtpoint.TabIndex = 138;
            // 
            // txtTestvalue
            // 
            this.txtTestvalue.Location = new System.Drawing.Point(14, 418);
            this.txtTestvalue.Name = "txtTestvalue";
            this.txtTestvalue.Size = new System.Drawing.Size(251, 21);
            this.txtTestvalue.TabIndex = 136;
            // 
            // s
            // 
            this.s.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.s_DataReceived);
            // 
            // txtdataChare
            // 
            this.txtdataChare.Location = new System.Drawing.Point(145, 356);
            this.txtdataChare.MaxLength = 2;
            this.txtdataChare.Name = "txtdataChare";
            this.txtdataChare.Size = new System.Drawing.Size(121, 21);
            this.txtdataChare.TabIndex = 134;
            this.txtdataChare.TextChanged += new System.EventHandler(this.txtdataChare_TextChanged);
            // 
            // txtdataChars
            // 
            this.txtdataChars.Location = new System.Drawing.Point(145, 330);
            this.txtdataChars.MaxLength = 2;
            this.txtdataChars.Name = "txtdataChars";
            this.txtdataChars.Size = new System.Drawing.Size(121, 21);
            this.txtdataChars.TabIndex = 133;
            // 
            // txtdatae
            // 
            this.txtdatae.Location = new System.Drawing.Point(144, 277);
            this.txtdatae.Name = "txtdatae";
            this.txtdatae.Size = new System.Drawing.Size(121, 21);
            this.txtdatae.TabIndex = 132;
            // 
            // txtdatas
            // 
            this.txtdatas.Location = new System.Drawing.Point(144, 252);
            this.txtdatas.Name = "txtdatas";
            this.txtdatas.Size = new System.Drawing.Size(121, 21);
            this.txtdatas.TabIndex = 131;
            // 
            // cmbDtrEnable
            // 
            this.cmbDtrEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDtrEnable.FormattingEnabled = true;
            this.cmbDtrEnable.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbDtrEnable.Location = new System.Drawing.Point(144, 192);
            this.cmbDtrEnable.Name = "cmbDtrEnable";
            this.cmbDtrEnable.Size = new System.Drawing.Size(121, 20);
            this.cmbDtrEnable.TabIndex = 130;
            // 
            // cmbRtsEnable
            // 
            this.cmbRtsEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRtsEnable.FormattingEnabled = true;
            this.cmbRtsEnable.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbRtsEnable.Location = new System.Drawing.Point(144, 161);
            this.cmbRtsEnable.Name = "cmbRtsEnable";
            this.cmbRtsEnable.Size = new System.Drawing.Size(121, 20);
            this.cmbRtsEnable.TabIndex = 129;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(280, 451);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 145;
            this.checkBox1.Text = "通信测试";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ckHandShake
            // 
            this.ckHandShake.AutoSize = true;
            this.ckHandShake.Location = new System.Drawing.Point(14, 138);
            this.ckHandShake.Name = "ckHandShake";
            this.ckHandShake.Size = new System.Drawing.Size(78, 16);
            this.ckHandShake.TabIndex = 146;
            this.ckHandShake.Text = "HandShake";
            this.ckHandShake.UseVisualStyleBackColor = true;
            // 
            // ckRtsEnable
            // 
            this.ckRtsEnable.AutoSize = true;
            this.ckRtsEnable.Location = new System.Drawing.Point(14, 165);
            this.ckRtsEnable.Name = "ckRtsEnable";
            this.ckRtsEnable.Size = new System.Drawing.Size(78, 16);
            this.ckRtsEnable.TabIndex = 147;
            this.ckRtsEnable.Text = "RtsEnable";
            this.ckRtsEnable.UseVisualStyleBackColor = true;
            // 
            // ckDtrEnable
            // 
            this.ckDtrEnable.AutoSize = true;
            this.ckDtrEnable.Location = new System.Drawing.Point(14, 196);
            this.ckDtrEnable.Name = "ckDtrEnable";
            this.ckDtrEnable.Size = new System.Drawing.Size(78, 16);
            this.ckDtrEnable.TabIndex = 148;
            this.ckDtrEnable.Text = "DtrEnable";
            this.ckDtrEnable.UseVisualStyleBackColor = true;
            // 
            // ckdatalen
            // 
            this.ckdatalen.AutoSize = true;
            this.ckdatalen.Checked = true;
            this.ckdatalen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckdatalen.Location = new System.Drawing.Point(14, 228);
            this.ckdatalen.Name = "ckdatalen";
            this.ckdatalen.Size = new System.Drawing.Size(72, 16);
            this.ckdatalen.TabIndex = 149;
            this.ckdatalen.Text = "数据长度";
            this.ckdatalen.UseVisualStyleBackColor = true;
            // 
            // ckdatas
            // 
            this.ckdatas.AutoSize = true;
            this.ckdatas.Checked = true;
            this.ckdatas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckdatas.Location = new System.Drawing.Point(14, 257);
            this.ckdatas.Name = "ckdatas";
            this.ckdatas.Size = new System.Drawing.Size(84, 16);
            this.ckdatas.TabIndex = 150;
            this.ckdatas.Text = "数据起始位";
            this.ckdatas.UseVisualStyleBackColor = true;
            // 
            // ckdatae
            // 
            this.ckdatae.AutoSize = true;
            this.ckdatae.Checked = true;
            this.ckdatae.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckdatae.Location = new System.Drawing.Point(14, 282);
            this.ckdatae.Name = "ckdatae";
            this.ckdatae.Size = new System.Drawing.Size(84, 16);
            this.ckdatae.TabIndex = 151;
            this.ckdatae.Text = "数据结束位";
            this.ckdatae.UseVisualStyleBackColor = true;
            // 
            // ckpoint
            // 
            this.ckpoint.AutoSize = true;
            this.ckpoint.Location = new System.Drawing.Point(14, 308);
            this.ckpoint.Name = "ckpoint";
            this.ckpoint.Size = new System.Drawing.Size(60, 16);
            this.ckpoint.TabIndex = 152;
            this.ckpoint.Text = "小数位";
            this.ckpoint.UseVisualStyleBackColor = true;
            // 
            // ckdataChars
            // 
            this.ckdataChars.AutoSize = true;
            this.ckdataChars.Location = new System.Drawing.Point(14, 335);
            this.ckdataChars.Name = "ckdataChars";
            this.ckdataChars.Size = new System.Drawing.Size(84, 16);
            this.ckdataChars.TabIndex = 153;
            this.ckdataChars.Text = "起始标识符";
            this.ckdataChars.UseVisualStyleBackColor = true;
            // 
            // ckdataChare
            // 
            this.ckdataChare.AutoSize = true;
            this.ckdataChare.Location = new System.Drawing.Point(14, 361);
            this.ckdataChare.Name = "ckdataChare";
            this.ckdataChare.Size = new System.Drawing.Size(96, 16);
            this.ckdataChare.TabIndex = 154;
            this.ckdataChare.Text = "静荷稳定次数";
            this.ckdataChare.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(375, 451);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 155;
            this.checkBox2.Text = "重量测试";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 156;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudqsjg
            // 
            this.nudqsjg.Location = new System.Drawing.Point(144, 383);
            this.nudqsjg.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudqsjg.Name = "nudqsjg";
            this.nudqsjg.Size = new System.Drawing.Size(69, 21);
            this.nudqsjg.TabIndex = 157;
            this.nudqsjg.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 158;
            this.label6.Text = "取数间隔";
            // 
            // frmComSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 489);
            this.Controls.Add(this.lampZero);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudqsjg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.ckdataChare);
            this.Controls.Add(this.ckdataChars);
            this.Controls.Add(this.ckpoint);
            this.Controls.Add(this.ckdatae);
            this.Controls.Add(this.ckdatas);
            this.Controls.Add(this.ckdatalen);
            this.Controls.Add(this.ckDtrEnable);
            this.Controls.Add(this.ckRtsEnable);
            this.Controls.Add(this.ckHandShake);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmbHandShake);
            this.Controls.Add(this.cmbparity);
            this.Controls.Add(this.cmbStopBits);
            this.Controls.Add(this.txtDataBits);
            this.Controls.Add(this.txtbaudRate);
            this.Controls.Add(this.cmbCom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nujh);
            this.Controls.Add(this.txtdatalen);
            this.Controls.Add(this.txtpoint);
            this.Controls.Add(this.txtTestvalue);
            this.Controls.Add(this.txtdataChare);
            this.Controls.Add(this.txtdataChars);
            this.Controls.Add(this.txtdatae);
            this.Controls.Add(this.txtdatas);
            this.Controls.Add(this.cmbDtrEnable);
            this.Controls.Add(this.cmbRtsEnable);
            this.MaximizeBox = false;
            this.Name = "frmComSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComSet_FormClosing);
            this.Load += new System.EventHandler(this.frmComSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nujh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudqsjg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHandShake;
        private System.Windows.Forms.ComboBox cmbparity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.TextBox txtbaudRate;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nujh;
        private System.Windows.Forms.TextBox txtdatalen;
        private System.Windows.Forms.TextBox txtpoint;
        private System.Windows.Forms.TextBox txtTestvalue;
        private System.IO.Ports.SerialPort s;
        private System.Windows.Forms.TextBox txtdataChare;
        private System.Windows.Forms.TextBox txtdataChars;
        private System.Windows.Forms.TextBox txtdatae;
        private System.Windows.Forms.TextBox txtdatas;
        private System.Windows.Forms.ComboBox cmbDtrEnable;
        private System.Windows.Forms.ComboBox cmbRtsEnable;
        private System.Windows.Forms.CheckBox checkBox1;
        private LFY.UI.Controls.Glass.GlassLamp lampZero;
        private System.Windows.Forms.CheckBox ckHandShake;
        private System.Windows.Forms.CheckBox ckRtsEnable;
        private System.Windows.Forms.CheckBox ckDtrEnable;
        private System.Windows.Forms.CheckBox ckdatalen;
        private System.Windows.Forms.CheckBox ckdatas;
        private System.Windows.Forms.CheckBox ckdatae;
        private System.Windows.Forms.CheckBox ckpoint;
        private System.Windows.Forms.CheckBox ckdataChars;
        private System.Windows.Forms.CheckBox ckdataChare;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudqsjg;
        private System.Windows.Forms.Label label6;
    }
}