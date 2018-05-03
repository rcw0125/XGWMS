namespace WeightApp
{
    partial class updatebarcodeFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbbarcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbpcsx = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SpinEdit1 = new System.Windows.Forms.NumericUpDown();
            this.cmbsx = new System.Windows.Forms.ComboBox();
            this.SpinEdit2 = new System.Windows.Forms.NumericUpDown();
            this.comBHG = new System.Windows.Forms.ComboBox();
            this.PrintPCInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.maskedit1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "条码";
            // 
            // lbbarcode
            // 
            this.lbbarcode.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbbarcode.Location = new System.Drawing.Point(69, 11);
            this.lbbarcode.Name = "lbbarcode";
            this.lbbarcode.Size = new System.Drawing.Size(100, 23);
            this.lbbarcode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "批次属性";
            // 
            // lbpcsx
            // 
            this.lbpcsx.Location = new System.Drawing.Point(281, 11);
            this.lbpcsx.Name = "lbpcsx";
            this.lbpcsx.Size = new System.Drawing.Size(100, 23);
            this.lbpcsx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "钩号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "序号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "质量原因";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "属性";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "生产日期";
            // 
            // SpinEdit1
            // 
            this.SpinEdit1.Location = new System.Drawing.Point(76, 50);
            this.SpinEdit1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpinEdit1.Name = "SpinEdit1";
            this.SpinEdit1.Size = new System.Drawing.Size(103, 21);
            this.SpinEdit1.TabIndex = 11;
            this.SpinEdit1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbsx
            // 
            this.cmbsx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsx.FormattingEnabled = true;
            this.cmbsx.Location = new System.Drawing.Point(257, 52);
            this.cmbsx.Name = "cmbsx";
            this.cmbsx.Size = new System.Drawing.Size(121, 20);
            this.cmbsx.TabIndex = 12;
            this.cmbsx.SelectedIndexChanged += new System.EventHandler(this.cmbsx_SelectedIndexChanged);
            // 
            // SpinEdit2
            // 
            this.SpinEdit2.Location = new System.Drawing.Point(76, 88);
            this.SpinEdit2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpinEdit2.Name = "SpinEdit2";
            this.SpinEdit2.Size = new System.Drawing.Size(103, 21);
            this.SpinEdit2.TabIndex = 13;
            this.SpinEdit2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comBHG
            // 
            this.comBHG.FormattingEnabled = true;
            this.comBHG.Location = new System.Drawing.Point(76, 143);
            this.comBHG.Name = "comBHG";
            this.comBHG.Size = new System.Drawing.Size(105, 20);
            this.comBHG.TabIndex = 15;
            // 
            // PrintPCInfoCheckBox
            // 
            this.PrintPCInfoCheckBox.AutoSize = true;
            this.PrintPCInfoCheckBox.Location = new System.Drawing.Point(198, 128);
            this.PrintPCInfoCheckBox.Name = "PrintPCInfoCheckBox";
            this.PrintPCInfoCheckBox.Size = new System.Drawing.Size(96, 16);
            this.PrintPCInfoCheckBox.TabIndex = 16;
            this.PrintPCInfoCheckBox.Text = "打印特殊信息";
            this.PrintPCInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // maskedit1
            // 
            this.maskedit1.Location = new System.Drawing.Point(257, 88);
            this.maskedit1.Name = "maskedit1";
            this.maskedit1.Size = new System.Drawing.Size(124, 21);
            this.maskedit1.TabIndex = 17;
            // 
            // updatebarcodeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 216);
            this.Controls.Add(this.maskedit1);
            this.Controls.Add(this.PrintPCInfoCheckBox);
            this.Controls.Add(this.comBHG);
            this.Controls.Add(this.SpinEdit2);
            this.Controls.Add(this.cmbsx);
            this.Controls.Add(this.SpinEdit1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbpcsx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbbarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "updatebarcodeFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改";
            this.Load += new System.EventHandler(this.updatebarcodeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbbarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbpcsx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown SpinEdit1;
        private System.Windows.Forms.ComboBox cmbsx;
        private System.Windows.Forms.NumericUpDown SpinEdit2;
        private System.Windows.Forms.ComboBox comBHG;
        private System.Windows.Forms.CheckBox PrintPCInfoCheckBox;
        private System.Windows.Forms.TextBox maskedit1;
    }
}