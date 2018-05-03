namespace WeightApp
{
    partial class frmManageMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnchangepsd = new System.Windows.Forms.Button();
            this.paneln = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_edt = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.gbedt = new System.Windows.Forms.GroupBox();
            this.cb_PrintModle = new System.Windows.Forms.CheckBox();
            this.cb_WeightBD = new System.Windows.Forms.CheckBox();
            this.cb_DelWgd = new System.Windows.Forms.CheckBox();
            this.cb_BHGYY = new System.Windows.Forms.CheckBox();
            this.cb_StandManage = new System.Windows.Forms.CheckBox();
            this.cb_reCheck = new System.Windows.Forms.CheckBox();
            this.cb_SearchWGD = new System.Windows.Forms.CheckBox();
            this.cb_IsManager = new System.Windows.Forms.CheckBox();
            this.cb_WeightSearch = new System.Windows.Forms.CheckBox();
            this.cb_QuDel = new System.Windows.Forms.CheckBox();
            this.txtpass1 = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtuserno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.paneln.SuspendLayout();
            this.gbedt.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "管理员列表";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 17);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(812, 146);
            this.dgv.TabIndex = 0;
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "username";
            this.Column1.HeaderText = "用户编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "userCname";
            this.Column2.HeaderText = "用户姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnchangepsd);
            this.panel1.Controls.Add(this.paneln);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 59);
            this.panel1.TabIndex = 1;
            // 
            // btnchangepsd
            // 
            this.btnchangepsd.Location = new System.Drawing.Point(391, 17);
            this.btnchangepsd.Name = "btnchangepsd";
            this.btnchangepsd.Size = new System.Drawing.Size(75, 23);
            this.btnchangepsd.TabIndex = 10;
            this.btnchangepsd.Tag = "修改密码";
            this.btnchangepsd.Text = "修改密码";
            this.btnchangepsd.UseVisualStyleBackColor = true;
            this.btnchangepsd.Click += new System.EventHandler(this.btnchangepsd_Click);
            // 
            // paneln
            // 
            this.paneln.Controls.Add(this.btn_cancel);
            this.paneln.Controls.Add(this.btn_del);
            this.paneln.Controls.Add(this.btn_save);
            this.paneln.Controls.Add(this.btn_edt);
            this.paneln.Controls.Add(this.btn_add);
            this.paneln.Dock = System.Windows.Forms.DockStyle.Left;
            this.paneln.Location = new System.Drawing.Point(0, 0);
            this.paneln.Name = "paneln";
            this.paneln.Size = new System.Drawing.Size(390, 59);
            this.paneln.TabIndex = 9;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Location = new System.Drawing.Point(307, 18);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "撤销";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(232, 18);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 8;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(157, 18);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_edt
            // 
            this.btn_edt.Location = new System.Drawing.Point(83, 18);
            this.btn_edt.Name = "btn_edt";
            this.btn_edt.Size = new System.Drawing.Size(75, 23);
            this.btn_edt.TabIndex = 6;
            this.btn_edt.Text = "修改";
            this.btn_edt.UseVisualStyleBackColor = true;
            this.btn_edt.Click += new System.EventHandler(this.btn_edt_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(9, 18);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "增加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(762, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 23);
            this.button10.TabIndex = 8;
            this.button10.Text = "关闭";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(703, 17);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(58, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "模板套";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(626, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "日志查询";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(549, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "卷信息查询";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(472, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "完工单查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // gbedt
            // 
            this.gbedt.Controls.Add(this.cb_PrintModle);
            this.gbedt.Controls.Add(this.cb_WeightBD);
            this.gbedt.Controls.Add(this.cb_DelWgd);
            this.gbedt.Controls.Add(this.cb_BHGYY);
            this.gbedt.Controls.Add(this.cb_StandManage);
            this.gbedt.Controls.Add(this.cb_reCheck);
            this.gbedt.Controls.Add(this.cb_SearchWGD);
            this.gbedt.Controls.Add(this.cb_IsManager);
            this.gbedt.Controls.Add(this.cb_WeightSearch);
            this.gbedt.Controls.Add(this.cb_QuDel);
            this.gbedt.Controls.Add(this.txtpass1);
            this.gbedt.Controls.Add(this.txtpass);
            this.gbedt.Controls.Add(this.txtusername);
            this.gbedt.Controls.Add(this.txtuserno);
            this.gbedt.Controls.Add(this.label4);
            this.gbedt.Controls.Add(this.label3);
            this.gbedt.Controls.Add(this.label2);
            this.gbedt.Controls.Add(this.label1);
            this.gbedt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbedt.Enabled = false;
            this.gbedt.Location = new System.Drawing.Point(0, 166);
            this.gbedt.Name = "gbedt";
            this.gbedt.Size = new System.Drawing.Size(818, 173);
            this.gbedt.TabIndex = 2;
            this.gbedt.TabStop = false;
            this.gbedt.Text = "管理员维护";
            // 
            // cb_PrintModle
            // 
            this.cb_PrintModle.AutoSize = true;
            this.cb_PrintModle.Location = new System.Drawing.Point(448, 124);
            this.cb_PrintModle.Name = "cb_PrintModle";
            this.cb_PrintModle.Size = new System.Drawing.Size(84, 16);
            this.cb_PrintModle.TabIndex = 17;
            this.cb_PrintModle.Text = "模板套维护";
            this.cb_PrintModle.UseVisualStyleBackColor = true;
            // 
            // cb_WeightBD
            // 
            this.cb_WeightBD.AutoSize = true;
            this.cb_WeightBD.Location = new System.Drawing.Point(332, 124);
            this.cb_WeightBD.Name = "cb_WeightBD";
            this.cb_WeightBD.Size = new System.Drawing.Size(72, 16);
            this.cb_WeightBD.TabIndex = 16;
            this.cb_WeightBD.Text = "补打标牌";
            this.cb_WeightBD.UseVisualStyleBackColor = true;
            // 
            // cb_DelWgd
            // 
            this.cb_DelWgd.AutoSize = true;
            this.cb_DelWgd.Location = new System.Drawing.Point(579, 58);
            this.cb_DelWgd.Name = "cb_DelWgd";
            this.cb_DelWgd.Size = new System.Drawing.Size(84, 16);
            this.cb_DelWgd.TabIndex = 15;
            this.cb_DelWgd.Text = "删除完工单";
            this.cb_DelWgd.UseVisualStyleBackColor = true;
            // 
            // cb_BHGYY
            // 
            this.cb_BHGYY.AutoSize = true;
            this.cb_BHGYY.Location = new System.Drawing.Point(448, 89);
            this.cb_BHGYY.Name = "cb_BHGYY";
            this.cb_BHGYY.Size = new System.Drawing.Size(96, 16);
            this.cb_BHGYY.TabIndex = 14;
            this.cb_BHGYY.Text = "质量原因维护";
            this.cb_BHGYY.UseVisualStyleBackColor = true;
            // 
            // cb_StandManage
            // 
            this.cb_StandManage.AutoSize = true;
            this.cb_StandManage.Location = new System.Drawing.Point(332, 89);
            this.cb_StandManage.Name = "cb_StandManage";
            this.cb_StandManage.Size = new System.Drawing.Size(96, 16);
            this.cb_StandManage.TabIndex = 13;
            this.cb_StandManage.Text = "执行标准维护";
            this.cb_StandManage.UseVisualStyleBackColor = true;
            // 
            // cb_reCheck
            // 
            this.cb_reCheck.AutoSize = true;
            this.cb_reCheck.Location = new System.Drawing.Point(448, 58);
            this.cb_reCheck.Name = "cb_reCheck";
            this.cb_reCheck.Size = new System.Drawing.Size(84, 16);
            this.cb_reCheck.TabIndex = 12;
            this.cb_reCheck.Text = "重检完工单";
            this.cb_reCheck.UseVisualStyleBackColor = true;
            // 
            // cb_SearchWGD
            // 
            this.cb_SearchWGD.AutoSize = true;
            this.cb_SearchWGD.Location = new System.Drawing.Point(332, 58);
            this.cb_SearchWGD.Name = "cb_SearchWGD";
            this.cb_SearchWGD.Size = new System.Drawing.Size(84, 16);
            this.cb_SearchWGD.TabIndex = 11;
            this.cb_SearchWGD.Text = "完工单重置";
            this.cb_SearchWGD.UseVisualStyleBackColor = true;
            // 
            // cb_IsManager
            // 
            this.cb_IsManager.AutoSize = true;
            this.cb_IsManager.Location = new System.Drawing.Point(579, 29);
            this.cb_IsManager.Name = "cb_IsManager";
            this.cb_IsManager.Size = new System.Drawing.Size(108, 16);
            this.cb_IsManager.TabIndex = 10;
            this.cb_IsManager.Text = "称重管理员管理";
            this.cb_IsManager.UseVisualStyleBackColor = true;
            // 
            // cb_WeightSearch
            // 
            this.cb_WeightSearch.AutoSize = true;
            this.cb_WeightSearch.Location = new System.Drawing.Point(448, 29);
            this.cb_WeightSearch.Name = "cb_WeightSearch";
            this.cb_WeightSearch.Size = new System.Drawing.Size(84, 16);
            this.cb_WeightSearch.TabIndex = 9;
            this.cb_WeightSearch.Text = "卷信息查询";
            this.cb_WeightSearch.UseVisualStyleBackColor = true;
            // 
            // cb_QuDel
            // 
            this.cb_QuDel.AutoSize = true;
            this.cb_QuDel.Location = new System.Drawing.Point(332, 29);
            this.cb_QuDel.Name = "cb_QuDel";
            this.cb_QuDel.Size = new System.Drawing.Size(96, 16);
            this.cb_QuDel.TabIndex = 8;
            this.cb_QuDel.Text = "单卷信息删除";
            this.cb_QuDel.UseVisualStyleBackColor = true;
            // 
            // txtpass1
            // 
            this.txtpass1.Location = new System.Drawing.Point(83, 122);
            this.txtpass1.Name = "txtpass1";
            this.txtpass1.PasswordChar = '*';
            this.txtpass1.Size = new System.Drawing.Size(126, 21);
            this.txtpass1.TabIndex = 7;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(83, 89);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(126, 21);
            this.txtpass.TabIndex = 6;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(83, 58);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(126, 21);
            this.txtusername.TabIndex = 5;
            // 
            // txtuserno
            // 
            this.txtuserno.Location = new System.Drawing.Point(83, 27);
            this.txtuserno.Name = "txtuserno";
            this.txtuserno.Size = new System.Drawing.Size(126, 21);
            this.txtuserno.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码确认";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密    码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户编码";
            // 
            // frmManageMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 398);
            this.Controls.Add(this.gbedt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmManageMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "称重管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManageMain_FormClosing);
            this.Load += new System.EventHandler(this.frmManageMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.paneln.ResumeLayout(false);
            this.gbedt.ResumeLayout(false);
            this.gbedt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbedt;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpass1;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtuserno;
        private System.Windows.Forms.CheckBox cb_IsManager;
        private System.Windows.Forms.CheckBox cb_WeightSearch;
        private System.Windows.Forms.CheckBox cb_QuDel;
        private System.Windows.Forms.CheckBox cb_PrintModle;
        private System.Windows.Forms.CheckBox cb_WeightBD;
        private System.Windows.Forms.CheckBox cb_DelWgd;
        private System.Windows.Forms.CheckBox cb_BHGYY;
        private System.Windows.Forms.CheckBox cb_StandManage;
        private System.Windows.Forms.CheckBox cb_reCheck;
        private System.Windows.Forms.CheckBox cb_SearchWGD;
        private System.Windows.Forms.Panel paneln;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_edt;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btnchangepsd;
    }
}