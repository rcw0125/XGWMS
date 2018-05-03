namespace WeightApp
{
    partial class frmParam
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
            this.ckWeightUp = new System.Windows.Forms.CheckBox();
            this.ckSCXParamWeightDown = new System.Windows.Forms.CheckBox();
            this.nudZeroLow = new System.Windows.Forms.NumericUpDown();
            this.nudZeroHight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSCXParamUptime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ckAutoGetWeightFlag = new System.Windows.Forms.CheckBox();
            this.nudAutoGetWeightNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nudweightup = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudweightdown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudGPZLDOWN = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudGPZLUP = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudZeroLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZeroHight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSCXParamUptime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoGetWeightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudweightup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudweightdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPZLDOWN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPZLUP)).BeginInit();
            this.SuspendLayout();
            // 
            // ckWeightUp
            // 
            this.ckWeightUp.AutoSize = true;
            this.ckWeightUp.Location = new System.Drawing.Point(51, 34);
            this.ckWeightUp.Name = "ckWeightUp";
            this.ckWeightUp.Size = new System.Drawing.Size(120, 16);
            this.ckWeightUp.TabIndex = 0;
            this.ckWeightUp.Text = "升起到位控制打印";
            this.ckWeightUp.UseVisualStyleBackColor = true;
            this.ckWeightUp.CheckedChanged += new System.EventHandler(this.ckWeightUp_CheckedChanged);
            // 
            // ckSCXParamWeightDown
            // 
            this.ckSCXParamWeightDown.AutoSize = true;
            this.ckSCXParamWeightDown.Location = new System.Drawing.Point(76, 66);
            this.ckSCXParamWeightDown.Name = "ckSCXParamWeightDown";
            this.ckSCXParamWeightDown.Size = new System.Drawing.Size(96, 16);
            this.ckSCXParamWeightDown.TabIndex = 1;
            this.ckSCXParamWeightDown.Text = "零点判断范围";
            this.ckSCXParamWeightDown.UseVisualStyleBackColor = true;
            // 
            // nudZeroLow
            // 
            this.nudZeroLow.Location = new System.Drawing.Point(177, 61);
            this.nudZeroLow.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudZeroLow.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudZeroLow.Name = "nudZeroLow";
            this.nudZeroLow.Size = new System.Drawing.Size(52, 21);
            this.nudZeroLow.TabIndex = 2;
            // 
            // nudZeroHight
            // 
            this.nudZeroHight.Location = new System.Drawing.Point(235, 61);
            this.nudZeroHight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudZeroHight.Name = "nudZeroHight";
            this.nudZeroHight.Size = new System.Drawing.Size(52, 21);
            this.nudZeroHight.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "kg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "上升到位轮询时间";
            // 
            // nudSCXParamUptime
            // 
            this.nudSCXParamUptime.Location = new System.Drawing.Point(177, 192);
            this.nudSCXParamUptime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSCXParamUptime.Name = "nudSCXParamUptime";
            this.nudSCXParamUptime.Size = new System.Drawing.Size(110, 21);
            this.nudSCXParamUptime.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "ms";
            // 
            // ckAutoGetWeightFlag
            // 
            this.ckAutoGetWeightFlag.AutoSize = true;
            this.ckAutoGetWeightFlag.Location = new System.Drawing.Point(54, 222);
            this.ckAutoGetWeightFlag.Name = "ckAutoGetWeightFlag";
            this.ckAutoGetWeightFlag.Size = new System.Drawing.Size(120, 16);
            this.ckAutoGetWeightFlag.TabIndex = 13;
            this.ckAutoGetWeightFlag.Text = "上升到位取数时间";
            this.ckAutoGetWeightFlag.UseVisualStyleBackColor = true;
            // 
            // nudAutoGetWeightNum
            // 
            this.nudAutoGetWeightNum.Location = new System.Drawing.Point(176, 217);
            this.nudAutoGetWeightNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAutoGetWeightNum.Name = "nudAutoGetWeightNum";
            this.nudAutoGetWeightNum.Size = new System.Drawing.Size(111, 21);
            this.nudAutoGetWeightNum.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "ms";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nudweightup
            // 
            this.nudweightup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudweightup.Location = new System.Drawing.Point(177, 88);
            this.nudweightup.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudweightup.Name = "nudweightup";
            this.nudweightup.Size = new System.Drawing.Size(110, 21);
            this.nudweightup.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "重量上限";
            // 
            // nudweightdown
            // 
            this.nudweightdown.Location = new System.Drawing.Point(177, 114);
            this.nudweightdown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudweightdown.Name = "nudweightdown";
            this.nudweightdown.Size = new System.Drawing.Size(110, 21);
            this.nudweightdown.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "重量下限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "kg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "kg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "生产线：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(297, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "线材重量/钢坯重量";
            // 
            // nudGPZLDOWN
            // 
            this.nudGPZLDOWN.DecimalPlaces = 3;
            this.nudGPZLDOWN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudGPZLDOWN.Location = new System.Drawing.Point(177, 162);
            this.nudGPZLDOWN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGPZLDOWN.Name = "nudGPZLDOWN";
            this.nudGPZLDOWN.Size = new System.Drawing.Size(110, 21);
            this.nudGPZLDOWN.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(71, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "钢坯重量下限倍率";
            // 
            // nudGPZLUP
            // 
            this.nudGPZLUP.DecimalPlaces = 3;
            this.nudGPZLUP.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.nudGPZLUP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudGPZLUP.Location = new System.Drawing.Point(177, 136);
            this.nudGPZLUP.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGPZLUP.Name = "nudGPZLUP";
            this.nudGPZLUP.Size = new System.Drawing.Size(110, 21);
            this.nudGPZLUP.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(70, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "钢坯重量上限倍率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "线材重量/钢坯重量";
            // 
            // frmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 283);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudGPZLDOWN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudGPZLUP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudweightdown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudweightup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudAutoGetWeightNum);
            this.Controls.Add(this.ckAutoGetWeightFlag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudSCXParamUptime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudZeroHight);
            this.Controls.Add(this.nudZeroLow);
            this.Controls.Add(this.ckSCXParamWeightDown);
            this.Controls.Add(this.ckWeightUp);
            this.Name = "frmParam";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生产线参数维护";
            this.Load += new System.EventHandler(this.frmParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudZeroLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZeroHight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSCXParamUptime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoGetWeightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudweightup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudweightdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPZLDOWN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGPZLUP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckWeightUp;
        private System.Windows.Forms.CheckBox ckSCXParamWeightDown;
        private System.Windows.Forms.NumericUpDown nudZeroLow;
        private System.Windows.Forms.NumericUpDown nudZeroHight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSCXParamUptime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckAutoGetWeightFlag;
        private System.Windows.Forms.NumericUpDown nudAutoGetWeightNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudweightup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudweightdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudGPZLDOWN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudGPZLUP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
    }
}