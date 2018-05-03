namespace WeightApp
{
    partial class FrmTJSearch
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
            this.comSPCH = new System.Windows.Forms.ComboBox();
            this.comPH = new System.Windows.Forms.ComboBox();
            this.comGG = new System.Windows.Forms.ComboBox();
            this.comBB = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.chkRQ = new System.Windows.Forms.CheckBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.comEPC = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkPCH
            // 
            this.chkPCH.AutoSize = true;
            this.chkPCH.Location = new System.Drawing.Point(23, 21);
            this.chkPCH.Name = "chkPCH";
            this.chkPCH.Size = new System.Drawing.Size(60, 16);
            this.chkPCH.TabIndex = 1;
            this.chkPCH.Text = "批次号";
            this.chkPCH.UseVisualStyleBackColor = true;
            this.chkPCH.CheckedChanged += new System.EventHandler(this.chkPCH_CheckedChanged);
            // 
            // chkPH
            // 
            this.chkPH.AutoSize = true;
            this.chkPH.Location = new System.Drawing.Point(23, 48);
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
            this.chkGG.Location = new System.Drawing.Point(23, 74);
            this.chkGG.Name = "chkGG";
            this.chkGG.Size = new System.Drawing.Size(48, 16);
            this.chkGG.TabIndex = 4;
            this.chkGG.Text = "规格";
            this.chkGG.UseVisualStyleBackColor = true;
            this.chkGG.CheckedChanged += new System.EventHandler(this.chkGG_CheckedChanged);
            // 
            // chkBB
            // 
            this.chkBB.AutoSize = true;
            this.chkBB.Location = new System.Drawing.Point(23, 128);
            this.chkBB.Name = "chkBB";
            this.chkBB.Size = new System.Drawing.Size(48, 16);
            this.chkBB.TabIndex = 5;
            this.chkBB.Text = "班级";
            this.chkBB.UseVisualStyleBackColor = true;
            this.chkBB.CheckedChanged += new System.EventHandler(this.chkBB_CheckedChanged);
            // 
            // comSPCH
            // 
            this.comSPCH.Enabled = false;
            this.comSPCH.FormattingEnabled = true;
            this.comSPCH.Location = new System.Drawing.Point(81, 20);
            this.comSPCH.Name = "comSPCH";
            this.comSPCH.Size = new System.Drawing.Size(125, 20);
            this.comSPCH.TabIndex = 6;
            this.comSPCH.TextChanged += new System.EventHandler(this.comSPCH_TextChanged);
            // 
            // comPH
            // 
            this.comPH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPH.Enabled = false;
            this.comPH.FormattingEnabled = true;
            this.comPH.Location = new System.Drawing.Point(81, 45);
            this.comPH.Name = "comPH";
            this.comPH.Size = new System.Drawing.Size(256, 20);
            this.comPH.TabIndex = 8;
            // 
            // comGG
            // 
            this.comGG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGG.Enabled = false;
            this.comGG.FormattingEnabled = true;
            this.comGG.Location = new System.Drawing.Point(81, 71);
            this.comGG.Name = "comGG";
            this.comGG.Size = new System.Drawing.Size(256, 20);
            this.comGG.TabIndex = 9;
            // 
            // comBB
            // 
            this.comBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBB.Enabled = false;
            this.comBB.FormattingEnabled = true;
            this.comBB.Items.AddRange(new object[] {
            "甲班",
            "乙班",
            "丙班",
            "丁班"});
            this.comBB.Location = new System.Drawing.Point(81, 125);
            this.comBB.Name = "comBB";
            this.comBB.Size = new System.Drawing.Size(256, 20);
            this.comBB.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(212, 165);
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
            this.chkRQ.Location = new System.Drawing.Point(23, 98);
            this.chkRQ.Name = "chkRQ";
            this.chkRQ.Size = new System.Drawing.Size(48, 16);
            this.chkRQ.TabIndex = 13;
            this.chkRQ.Text = "日期";
            this.chkRQ.UseVisualStyleBackColor = true;
            this.chkRQ.CheckedChanged += new System.EventHandler(this.chkRQ_CheckedChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Enabled = false;
            this.dateFrom.Location = new System.Drawing.Point(81, 95);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(125, 21);
            this.dateFrom.TabIndex = 14;
            // 
            // dateTo
            // 
            this.dateTo.Enabled = false;
            this.dateTo.Location = new System.Drawing.Point(212, 93);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(125, 21);
            this.dateTo.TabIndex = 15;
            // 
            // comEPC
            // 
            this.comEPC.Enabled = false;
            this.comEPC.FormattingEnabled = true;
            this.comEPC.Location = new System.Drawing.Point(212, 19);
            this.comEPC.Name = "comEPC";
            this.comEPC.Size = new System.Drawing.Size(125, 20);
            this.comEPC.TabIndex = 16;
            // 
            // FrmTJSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 216);
            this.Controls.Add(this.comEPC);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.chkRQ);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comBB);
            this.Controls.Add(this.comGG);
            this.Controls.Add(this.comPH);
            this.Controls.Add(this.comSPCH);
            this.Controls.Add(this.chkBB);
            this.Controls.Add(this.chkGG);
            this.Controls.Add(this.chkPH);
            this.Controls.Add(this.chkPCH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTJSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "统计查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPCH;
        private System.Windows.Forms.CheckBox chkPH;
        private System.Windows.Forms.CheckBox chkGG;
        private System.Windows.Forms.CheckBox chkBB;
        private System.Windows.Forms.ComboBox comSPCH;
        private System.Windows.Forms.ComboBox comPH;
        private System.Windows.Forms.ComboBox comGG;
        private System.Windows.Forms.ComboBox comBB;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.CheckBox chkRQ;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.ComboBox comEPC;
    }
}