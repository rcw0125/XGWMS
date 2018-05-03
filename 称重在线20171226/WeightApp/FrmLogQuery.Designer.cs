namespace WeightApp
{
    partial class FrmLogQuery
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
            this.panTop = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.chkRQ = new System.Windows.Forms.CheckBox();
            this.comUser = new System.Windows.Forms.ComboBox();
            this.chkOUser = new System.Windows.Forms.CheckBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnQuery);
            this.panTop.Controls.Add(this.dateTimeEnd);
            this.panTop.Controls.Add(this.dateTimeBegin);
            this.panTop.Controls.Add(this.chkRQ);
            this.panTop.Controls.Add(this.comUser);
            this.panTop.Controls.Add(this.chkOUser);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(788, 40);
            this.panTop.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(601, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Enabled = false;
            this.dateTimeEnd.Location = new System.Drawing.Point(469, 9);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(122, 21);
            this.dateTimeEnd.TabIndex = 4;
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.Enabled = false;
            this.dateTimeBegin.Location = new System.Drawing.Point(341, 10);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(122, 21);
            this.dateTimeBegin.TabIndex = 3;
            // 
            // chkRQ
            // 
            this.chkRQ.AutoSize = true;
            this.chkRQ.Location = new System.Drawing.Point(254, 13);
            this.chkRQ.Name = "chkRQ";
            this.chkRQ.Size = new System.Drawing.Size(72, 16);
            this.chkRQ.TabIndex = 2;
            this.chkRQ.Text = "操作日期";
            this.chkRQ.UseVisualStyleBackColor = true;
            this.chkRQ.CheckedChanged += new System.EventHandler(this.chkRQ_CheckedChanged);
            // 
            // comUser
            // 
            this.comUser.DisplayMember = "oper";
            this.comUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUser.Enabled = false;
            this.comUser.FormattingEnabled = true;
            this.comUser.Location = new System.Drawing.Point(91, 11);
            this.comUser.Name = "comUser";
            this.comUser.Size = new System.Drawing.Size(157, 20);
            this.comUser.TabIndex = 1;
            this.comUser.ValueMember = "oper";
            // 
            // chkOUser
            // 
            this.chkOUser.AutoSize = true;
            this.chkOUser.Location = new System.Drawing.Point(13, 13);
            this.chkOUser.Name = "chkOUser";
            this.chkOUser.Size = new System.Drawing.Size(72, 16);
            this.chkOUser.TabIndex = 0;
            this.chkOUser.Text = "操作人员";
            this.chkOUser.UseVisualStyleBackColor = true;
            this.chkOUser.CheckedChanged += new System.EventHandler(this.chkOUser_CheckedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 40);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(788, 314);
            this.dgvData.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "opetype";
            this.Column1.HeaderText = "操作类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "barcode";
            this.Column2.HeaderText = "条码(单据)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "sx";
            this.Column3.HeaderText = "属性";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "gh";
            this.Column4.HeaderText = "钩号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "zl";
            this.Column5.HeaderText = "重量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ysx";
            this.Column6.HeaderText = "原属性";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ygh";
            this.Column7.HeaderText = "原钩号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "yzl";
            this.Column8.HeaderText = "原重量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "oper";
            this.Column9.HeaderText = "操作人员";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "opetime";
            this.Column10.HeaderText = "操作时间";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // FrmLogQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 354);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panTop);
            this.Name = "FrmLogQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印日志查询";
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.CheckBox chkOUser;
        private System.Windows.Forms.CheckBox chkRQ;
        private System.Windows.Forms.ComboBox comUser;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeBegin;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}