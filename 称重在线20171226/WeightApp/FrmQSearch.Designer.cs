namespace WeightApp
{
    partial class FrmQSearch
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
            this.chkPCH = new System.Windows.Forms.CheckBox();
            this.chkPH = new System.Windows.Forms.CheckBox();
            this.chkGG = new System.Windows.Forms.CheckBox();
            this.chkBB = new System.Windows.Forms.CheckBox();
            this.comPCHF = new System.Windows.Forms.ComboBox();
            this.comPH = new System.Windows.Forms.ComboBox();
            this.comGG = new System.Windows.Forms.ComboBox();
            this.comBB = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.chkRQ = new System.Windows.Forms.CheckBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbPCHT = new System.Windows.Forms.ComboBox();
            this.chkSX = new System.Windows.Forms.CheckBox();
            this.comSX = new System.Windows.Forms.ComboBox();
            this.chkWL = new System.Windows.Forms.CheckBox();
            this.comWL = new System.Windows.Forms.ComboBox();
            this.chkGH = new System.Windows.Forms.CheckBox();
            this.comGH = new System.Windows.Forms.ComboBox();
            this.chkCK = new System.Windows.Forms.CheckBox();
            this.comCK = new System.Windows.Forms.ComboBox();
            this.chkDJ = new System.Windows.Forms.CheckBox();
            this.txtDJ = new System.Windows.Forms.TextBox();
            this.chkHW = new System.Windows.Forms.CheckBox();
            this.txtHW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkPCH
            // 
            this.chkPCH.AutoSize = true;
            this.chkPCH.Location = new System.Drawing.Point(9, 20);
            this.chkPCH.Name = "chkPCH";
            this.chkPCH.Size = new System.Drawing.Size(72, 16);
            this.chkPCH.TabIndex = 1;
            this.chkPCH.Text = "批次选择";
            this.chkPCH.UseVisualStyleBackColor = true;
            this.chkPCH.CheckedChanged += new System.EventHandler(this.chkPCH_CheckedChanged);
            // 
            // chkPH
            // 
            this.chkPH.AutoSize = true;
            this.chkPH.Location = new System.Drawing.Point(8, 48);
            this.chkPH.Name = "chkPH";
            this.chkPH.Size = new System.Drawing.Size(72, 16);
            this.chkPH.TabIndex = 3;
            this.chkPH.Text = "牌号选择";
            this.chkPH.UseVisualStyleBackColor = true;
            this.chkPH.CheckedChanged += new System.EventHandler(this.chkPH_CheckedChanged);
            // 
            // chkGG
            // 
            this.chkGG.AutoSize = true;
            this.chkGG.Location = new System.Drawing.Point(9, 128);
            this.chkGG.Name = "chkGG";
            this.chkGG.Size = new System.Drawing.Size(72, 16);
            this.chkGG.TabIndex = 4;
            this.chkGG.Text = "规格选择";
            this.chkGG.UseVisualStyleBackColor = true;
            this.chkGG.CheckedChanged += new System.EventHandler(this.chkGG_CheckedChanged);
            // 
            // chkBB
            // 
            this.chkBB.AutoSize = true;
            this.chkBB.Location = new System.Drawing.Point(8, 185);
            this.chkBB.Name = "chkBB";
            this.chkBB.Size = new System.Drawing.Size(72, 16);
            this.chkBB.TabIndex = 5;
            this.chkBB.Text = "班别选择";
            this.chkBB.UseVisualStyleBackColor = true;
            this.chkBB.CheckedChanged += new System.EventHandler(this.chkBB_CheckedChanged);
            // 
            // comPCHF
            // 
            this.comPCHF.Enabled = false;
            this.comPCHF.FormattingEnabled = true;
            this.comPCHF.Location = new System.Drawing.Point(81, 20);
            this.comPCHF.Name = "comPCHF";
            this.comPCHF.Size = new System.Drawing.Size(112, 20);
            this.comPCHF.TabIndex = 6;
            this.comPCHF.TextChanged += new System.EventHandler(this.comPCHF_TextChanged);
            // 
            // comPH
            // 
            this.comPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPH.Enabled = false;
            this.comPH.FormattingEnabled = true;
            this.comPH.Location = new System.Drawing.Point(81, 45);
            this.comPH.Name = "comPH";
            this.comPH.Size = new System.Drawing.Size(226, 20);
            this.comPH.TabIndex = 8;
            // 
            // comGG
            // 
            this.comGG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGG.Enabled = false;
            this.comGG.FormattingEnabled = true;
            this.comGG.Location = new System.Drawing.Point(81, 126);
            this.comGG.Name = "comGG";
            this.comGG.Size = new System.Drawing.Size(226, 20);
            this.comGG.TabIndex = 9;
            // 
            // comBB
            // 
            this.comBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBB.Enabled = false;
            this.comBB.FormattingEnabled = true;
            this.comBB.Location = new System.Drawing.Point(81, 182);
            this.comBB.Name = "comBB";
            this.comBB.Size = new System.Drawing.Size(226, 20);
            this.comBB.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(68, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(181, 324);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 12;
            this.btnCancle.Text = "关闭";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // chkRQ
            // 
            this.chkRQ.AutoSize = true;
            this.chkRQ.Location = new System.Drawing.Point(9, 289);
            this.chkRQ.Name = "chkRQ";
            this.chkRQ.Size = new System.Drawing.Size(72, 16);
            this.chkRQ.TabIndex = 13;
            this.chkRQ.Text = "时间选择";
            this.chkRQ.UseVisualStyleBackColor = true;
            this.chkRQ.CheckedChanged += new System.EventHandler(this.chkRQ_CheckedChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Enabled = false;
            this.dateFrom.Location = new System.Drawing.Point(81, 287);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(112, 21);
            this.dateFrom.TabIndex = 14;
            // 
            // dateTo
            // 
            this.dateTo.Enabled = false;
            this.dateTo.Location = new System.Drawing.Point(195, 287);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(112, 21);
            this.dateTo.TabIndex = 15;
            // 
            // cmbPCHT
            // 
            this.cmbPCHT.Enabled = false;
            this.cmbPCHT.FormattingEnabled = true;
            this.cmbPCHT.Location = new System.Drawing.Point(195, 20);
            this.cmbPCHT.Name = "cmbPCHT";
            this.cmbPCHT.Size = new System.Drawing.Size(112, 20);
            this.cmbPCHT.TabIndex = 16;
            // 
            // chkSX
            // 
            this.chkSX.AutoSize = true;
            this.chkSX.Location = new System.Drawing.Point(8, 74);
            this.chkSX.Name = "chkSX";
            this.chkSX.Size = new System.Drawing.Size(72, 16);
            this.chkSX.TabIndex = 17;
            this.chkSX.Text = "属性选择";
            this.chkSX.UseVisualStyleBackColor = true;
            this.chkSX.CheckedChanged += new System.EventHandler(this.chkSX_CheckedChanged);
            // 
            // comSX
            // 
            this.comSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSX.Enabled = false;
            this.comSX.FormattingEnabled = true;
            this.comSX.Items.AddRange(new object[] {
            "A",
            "AA",
            "AAA",
            "CK",
            "A1",
            "B1",
            "B2",
            "C1",
            "C2",
            "D",
            "DP",
            "E3",
            "E4"});
            this.comSX.Location = new System.Drawing.Point(81, 71);
            this.comSX.Name = "comSX";
            this.comSX.Size = new System.Drawing.Size(226, 20);
            this.comSX.TabIndex = 18;
            // 
            // chkWL
            // 
            this.chkWL.AutoSize = true;
            this.chkWL.Location = new System.Drawing.Point(8, 101);
            this.chkWL.Name = "chkWL";
            this.chkWL.Size = new System.Drawing.Size(72, 16);
            this.chkWL.TabIndex = 19;
            this.chkWL.Text = "物料选择";
            this.chkWL.UseVisualStyleBackColor = true;
            this.chkWL.CheckedChanged += new System.EventHandler(this.chkWL_CheckedChanged);
            // 
            // comWL
            // 
            this.comWL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comWL.Enabled = false;
            this.comWL.FormattingEnabled = true;
            this.comWL.Location = new System.Drawing.Point(81, 99);
            this.comWL.Name = "comWL";
            this.comWL.Size = new System.Drawing.Size(226, 20);
            this.comWL.TabIndex = 20;
            // 
            // chkGH
            // 
            this.chkGH.AutoSize = true;
            this.chkGH.Location = new System.Drawing.Point(9, 155);
            this.chkGH.Name = "chkGH";
            this.chkGH.Size = new System.Drawing.Size(72, 16);
            this.chkGH.TabIndex = 21;
            this.chkGH.Text = "钩号选择";
            this.chkGH.UseVisualStyleBackColor = true;
            this.chkGH.CheckedChanged += new System.EventHandler(this.chkGH_CheckedChanged);
            // 
            // comGH
            // 
            this.comGH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGH.Enabled = false;
            this.comGH.FormattingEnabled = true;
            this.comGH.Location = new System.Drawing.Point(81, 154);
            this.comGH.Name = "comGH";
            this.comGH.Size = new System.Drawing.Size(226, 20);
            this.comGH.TabIndex = 22;
            // 
            // chkCK
            // 
            this.chkCK.AutoSize = true;
            this.chkCK.Location = new System.Drawing.Point(7, 211);
            this.chkCK.Name = "chkCK";
            this.chkCK.Size = new System.Drawing.Size(72, 16);
            this.chkCK.TabIndex = 23;
            this.chkCK.Text = "仓库选择";
            this.chkCK.UseVisualStyleBackColor = true;
            this.chkCK.CheckedChanged += new System.EventHandler(this.chkCK_CheckedChanged);
            // 
            // comCK
            // 
            this.comCK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCK.Enabled = false;
            this.comCK.FormattingEnabled = true;
            this.comCK.Items.AddRange(new object[] {
            "甲班",
            "乙班",
            "丙班",
            "丁班"});
            this.comCK.Location = new System.Drawing.Point(80, 208);
            this.comCK.Name = "comCK";
            this.comCK.Size = new System.Drawing.Size(226, 20);
            this.comCK.TabIndex = 24;
            // 
            // chkDJ
            // 
            this.chkDJ.AutoSize = true;
            this.chkDJ.Location = new System.Drawing.Point(8, 237);
            this.chkDJ.Name = "chkDJ";
            this.chkDJ.Size = new System.Drawing.Size(60, 16);
            this.chkDJ.TabIndex = 25;
            this.chkDJ.Text = "单卷号";
            this.chkDJ.UseVisualStyleBackColor = true;
            this.chkDJ.CheckedChanged += new System.EventHandler(this.chkDJ_CheckedChanged);
            // 
            // txtDJ
            // 
            this.txtDJ.Enabled = false;
            this.txtDJ.Location = new System.Drawing.Point(79, 234);
            this.txtDJ.Name = "txtDJ";
            this.txtDJ.Size = new System.Drawing.Size(225, 21);
            this.txtDJ.TabIndex = 26;
            // 
            // chkHW
            // 
            this.chkHW.AutoSize = true;
            this.chkHW.Location = new System.Drawing.Point(8, 259);
            this.chkHW.Name = "chkHW";
            this.chkHW.Size = new System.Drawing.Size(48, 16);
            this.chkHW.TabIndex = 27;
            this.chkHW.Text = "货位";
            this.chkHW.UseVisualStyleBackColor = true;
            this.chkHW.CheckedChanged += new System.EventHandler(this.chkHW_CheckedChanged);
            // 
            // txtHW
            // 
            this.txtHW.Enabled = false;
            this.txtHW.Location = new System.Drawing.Point(79, 259);
            this.txtHW.Name = "txtHW";
            this.txtHW.Size = new System.Drawing.Size(225, 21);
            this.txtHW.TabIndex = 28;
            // 
            // FrmQSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 366);
            this.Controls.Add(this.txtHW);
            this.Controls.Add(this.chkHW);
            this.Controls.Add(this.txtDJ);
            this.Controls.Add(this.chkDJ);
            this.Controls.Add(this.comCK);
            this.Controls.Add(this.chkCK);
            this.Controls.Add(this.comGH);
            this.Controls.Add(this.chkGH);
            this.Controls.Add(this.comWL);
            this.Controls.Add(this.chkWL);
            this.Controls.Add(this.comSX);
            this.Controls.Add(this.chkSX);
            this.Controls.Add(this.cmbPCHT);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.chkRQ);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comBB);
            this.Controls.Add(this.comGG);
            this.Controls.Add(this.comPH);
            this.Controls.Add(this.comPCHF);
            this.Controls.Add(this.chkBB);
            this.Controls.Add(this.chkGG);
            this.Controls.Add(this.chkPH);
            this.Controls.Add(this.chkPCH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPCH;
        private System.Windows.Forms.CheckBox chkPH;
        private System.Windows.Forms.CheckBox chkGG;
        private System.Windows.Forms.CheckBox chkBB;
        private System.Windows.Forms.ComboBox comPCHF;
        private System.Windows.Forms.ComboBox comPH;
        private System.Windows.Forms.ComboBox comGG;
        private System.Windows.Forms.ComboBox comBB;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.CheckBox chkRQ;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.ComboBox cmbPCHT;
        private System.Windows.Forms.CheckBox chkSX;
        private System.Windows.Forms.ComboBox comSX;
        private System.Windows.Forms.CheckBox chkWL;
        private System.Windows.Forms.ComboBox comWL;
        private System.Windows.Forms.CheckBox chkGH;
        private System.Windows.Forms.ComboBox comGH;
        private System.Windows.Forms.CheckBox chkCK;
        private System.Windows.Forms.ComboBox comCK;
        private System.Windows.Forms.CheckBox chkDJ;
        private System.Windows.Forms.TextBox txtDJ;
        private System.Windows.Forms.CheckBox chkHW;
        private System.Windows.Forms.TextBox txtHW;
    }
}