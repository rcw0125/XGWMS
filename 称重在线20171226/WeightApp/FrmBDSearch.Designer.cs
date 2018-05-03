namespace WeightApp
{
    partial class FrmBDSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTH = new System.Windows.Forms.RadioButton();
            this.rdoKN = new System.Windows.Forms.RadioButton();
            this.chkPCH = new System.Windows.Forms.CheckBox();
            this.chkGH = new System.Windows.Forms.CheckBox();
            this.chkPH = new System.Windows.Forms.CheckBox();
            this.chkGG = new System.Windows.Forms.CheckBox();
            this.chkSX = new System.Windows.Forms.CheckBox();
            this.comPCH = new System.Windows.Forms.ComboBox();
            this.comGH = new System.Windows.Forms.ComboBox();
            this.comPH = new System.Windows.Forms.ComboBox();
            this.comGG = new System.Windows.Forms.ComboBox();
            this.comSX = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoTH);
            this.groupBox1.Controls.Add(this.rdoKN);
            this.groupBox1.Location = new System.Drawing.Point(22, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型";
            // 
            // rdoTH
            // 
            this.rdoTH.AutoSize = true;
            this.rdoTH.Location = new System.Drawing.Point(104, 19);
            this.rdoTH.Name = "rdoTH";
            this.rdoTH.Size = new System.Drawing.Size(71, 16);
            this.rdoTH.TabIndex = 1;
            this.rdoTH.Text = "退货补打";
            this.rdoTH.UseVisualStyleBackColor = true;
            // 
            // rdoKN
            // 
            this.rdoKN.AutoSize = true;
            this.rdoKN.Checked = true;
            this.rdoKN.Location = new System.Drawing.Point(17, 19);
            this.rdoKN.Name = "rdoKN";
            this.rdoKN.Size = new System.Drawing.Size(71, 16);
            this.rdoKN.TabIndex = 0;
            this.rdoKN.TabStop = true;
            this.rdoKN.Text = "库内补打";
            this.rdoKN.UseVisualStyleBackColor = true;
            // 
            // chkPCH
            // 
            this.chkPCH.AutoSize = true;
            this.chkPCH.Location = new System.Drawing.Point(31, 74);
            this.chkPCH.Name = "chkPCH";
            this.chkPCH.Size = new System.Drawing.Size(60, 16);
            this.chkPCH.TabIndex = 1;
            this.chkPCH.Text = "批次号";
            this.chkPCH.UseVisualStyleBackColor = true;
            this.chkPCH.CheckedChanged += new System.EventHandler(this.chkPCH_CheckedChanged);
            // 
            // chkGH
            // 
            this.chkGH.AutoSize = true;
            this.chkGH.Location = new System.Drawing.Point(31, 100);
            this.chkGH.Name = "chkGH";
            this.chkGH.Size = new System.Drawing.Size(48, 16);
            this.chkGH.TabIndex = 2;
            this.chkGH.Text = "钩号";
            this.chkGH.UseVisualStyleBackColor = true;
            this.chkGH.CheckedChanged += new System.EventHandler(this.chkGH_CheckedChanged);
            // 
            // chkPH
            // 
            this.chkPH.AutoSize = true;
            this.chkPH.Location = new System.Drawing.Point(31, 128);
            this.chkPH.Name = "chkPH";
            this.chkPH.Size = new System.Drawing.Size(48, 16);
            this.chkPH.TabIndex = 3;
            this.chkPH.Text = "牌号";
            this.chkPH.UseVisualStyleBackColor = true;
            this.chkPH.CheckedChanged += new System.EventHandler(this.chkPH_CheckedChanged);
            // 
            // chkGG
            // 
            this.chkGG.AutoSize = true;
            this.chkGG.Location = new System.Drawing.Point(31, 154);
            this.chkGG.Name = "chkGG";
            this.chkGG.Size = new System.Drawing.Size(48, 16);
            this.chkGG.TabIndex = 4;
            this.chkGG.Text = "规格";
            this.chkGG.UseVisualStyleBackColor = true;
            this.chkGG.CheckedChanged += new System.EventHandler(this.chkGG_CheckedChanged);
            // 
            // chkSX
            // 
            this.chkSX.AutoSize = true;
            this.chkSX.Location = new System.Drawing.Point(31, 181);
            this.chkSX.Name = "chkSX";
            this.chkSX.Size = new System.Drawing.Size(48, 16);
            this.chkSX.TabIndex = 5;
            this.chkSX.Text = "属性";
            this.chkSX.UseVisualStyleBackColor = true;
            this.chkSX.CheckedChanged += new System.EventHandler(this.chkSX_CheckedChanged);
            // 
            // comPCH
            // 
            this.comPCH.Enabled = false;
            this.comPCH.FormattingEnabled = true;
            this.comPCH.Location = new System.Drawing.Point(97, 73);
            this.comPCH.Name = "comPCH";
            this.comPCH.Size = new System.Drawing.Size(121, 20);
            this.comPCH.TabIndex = 6;
            // 
            // comGH
            // 
            this.comGH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGH.Enabled = false;
            this.comGH.FormattingEnabled = true;
            this.comGH.Location = new System.Drawing.Point(97, 98);
            this.comGH.Name = "comGH";
            this.comGH.Size = new System.Drawing.Size(121, 20);
            this.comGH.TabIndex = 7;
            // 
            // comPH
            // 
            this.comPH.Enabled = false;
            this.comPH.FormattingEnabled = true;
            this.comPH.Location = new System.Drawing.Point(97, 125);
            this.comPH.Name = "comPH";
            this.comPH.Size = new System.Drawing.Size(121, 20);
            this.comPH.TabIndex = 8;
            // 
            // comGG
            // 
            this.comGG.Enabled = false;
            this.comGG.FormattingEnabled = true;
            this.comGG.Location = new System.Drawing.Point(97, 151);
            this.comGG.Name = "comGG";
            this.comGG.Size = new System.Drawing.Size(121, 20);
            this.comGG.TabIndex = 9;
            // 
            // comSX
            // 
            this.comSX.Enabled = false;
            this.comSX.FormattingEnabled = true;
            this.comSX.Location = new System.Drawing.Point(97, 178);
            this.comSX.Name = "comSX";
            this.comSX.Size = new System.Drawing.Size(121, 20);
            this.comSX.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(35, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(126, 214);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 12;
            this.btnCancle.Text = "关闭";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FrmBDSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 249);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comSX);
            this.Controls.Add(this.comGG);
            this.Controls.Add(this.comPH);
            this.Controls.Add(this.comGH);
            this.Controls.Add(this.comPCH);
            this.Controls.Add(this.chkSX);
            this.Controls.Add(this.chkGG);
            this.Controls.Add(this.chkPH);
            this.Controls.Add(this.chkGH);
            this.Controls.Add(this.chkPCH);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBDSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "补打查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTH;
        private System.Windows.Forms.RadioButton rdoKN;
        private System.Windows.Forms.CheckBox chkPCH;
        private System.Windows.Forms.CheckBox chkGH;
        private System.Windows.Forms.CheckBox chkPH;
        private System.Windows.Forms.CheckBox chkGG;
        private System.Windows.Forms.CheckBox chkSX;
        private System.Windows.Forms.ComboBox comPCH;
        private System.Windows.Forms.ComboBox comGH;
        private System.Windows.Forms.ComboBox comPH;
        private System.Windows.Forms.ComboBox comGG;
        private System.Windows.Forms.ComboBox comSX;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
    }
}