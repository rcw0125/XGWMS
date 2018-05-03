namespace WeightApp
{
    partial class frmLogin
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
            this.plogin = new System.Windows.Forms.Panel();
            this.cmb_user = new System.Windows.Forms.TextBox();
            this.ckChPsd = new System.Windows.Forms.CheckBox();
            this.txtpasd = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pchangepd = new System.Windows.Forms.Panel();
            this.txtnewpd1 = new System.Windows.Forms.TextBox();
            this.txtnewpd = new System.Windows.Forms.TextBox();
            this.btn_cpCancel = new System.Windows.Forms.Button();
            this.btn_cpok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.plogin.SuspendLayout();
            this.pchangepd.SuspendLayout();
            this.SuspendLayout();
            // 
            // plogin
            // 
            this.plogin.Controls.Add(this.cmb_user);
            this.plogin.Controls.Add(this.ckChPsd);
            this.plogin.Controls.Add(this.txtpasd);
            this.plogin.Controls.Add(this.btn_exit);
            this.plogin.Controls.Add(this.btn_login);
            this.plogin.Controls.Add(this.label2);
            this.plogin.Controls.Add(this.label1);
            this.plogin.Location = new System.Drawing.Point(12, 186);
            this.plogin.Name = "plogin";
            this.plogin.Size = new System.Drawing.Size(261, 146);
            this.plogin.TabIndex = 8;
            // 
            // cmb_user
            // 
            this.cmb_user.Location = new System.Drawing.Point(91, 16);
            this.cmb_user.Name = "cmb_user";
            this.cmb_user.Size = new System.Drawing.Size(100, 21);
            this.cmb_user.TabIndex = 0;
            this.cmb_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_user_KeyDown);
            // 
            // ckChPsd
            // 
            this.ckChPsd.AutoSize = true;
            this.ckChPsd.Location = new System.Drawing.Point(91, 72);
            this.ckChPsd.Name = "ckChPsd";
            this.ckChPsd.Size = new System.Drawing.Size(72, 16);
            this.ckChPsd.TabIndex = 6;
            this.ckChPsd.Text = "修改密码";
            this.ckChPsd.UseVisualStyleBackColor = true;
            // 
            // txtpasd
            // 
            this.txtpasd.Location = new System.Drawing.Point(91, 49);
            this.txtpasd.Name = "txtpasd";
            this.txtpasd.PasswordChar = '*';
            this.txtpasd.Size = new System.Drawing.Size(100, 21);
            this.txtpasd.TabIndex = 1;
            this.txtpasd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpasd_KeyDown);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(120, 114);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(71, 24);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_login
            // 
            this.btn_login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_login.Location = new System.Drawing.Point(39, 115);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // pchangepd
            // 
            this.pchangepd.Controls.Add(this.txtnewpd1);
            this.pchangepd.Controls.Add(this.txtnewpd);
            this.pchangepd.Controls.Add(this.btn_cpCancel);
            this.pchangepd.Controls.Add(this.btn_cpok);
            this.pchangepd.Controls.Add(this.label3);
            this.pchangepd.Controls.Add(this.label4);
            this.pchangepd.Location = new System.Drawing.Point(12, 34);
            this.pchangepd.Name = "pchangepd";
            this.pchangepd.Size = new System.Drawing.Size(261, 146);
            this.pchangepd.TabIndex = 9;
            // 
            // txtnewpd1
            // 
            this.txtnewpd1.Location = new System.Drawing.Point(89, 49);
            this.txtnewpd1.Name = "txtnewpd1";
            this.txtnewpd1.PasswordChar = '*';
            this.txtnewpd1.Size = new System.Drawing.Size(100, 21);
            this.txtnewpd1.TabIndex = 5;
            this.txtnewpd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnewpd1_KeyDown);
            // 
            // txtnewpd
            // 
            this.txtnewpd.Location = new System.Drawing.Point(90, 16);
            this.txtnewpd.Name = "txtnewpd";
            this.txtnewpd.PasswordChar = '*';
            this.txtnewpd.Size = new System.Drawing.Size(100, 21);
            this.txtnewpd.TabIndex = 4;
            this.txtnewpd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnewpd_KeyDown);
            // 
            // btn_cpCancel
            // 
            this.btn_cpCancel.Location = new System.Drawing.Point(113, 94);
            this.btn_cpCancel.Name = "btn_cpCancel";
            this.btn_cpCancel.Size = new System.Drawing.Size(71, 24);
            this.btn_cpCancel.TabIndex = 7;
            this.btn_cpCancel.Text = "取消";
            this.btn_cpCancel.UseVisualStyleBackColor = true;
            this.btn_cpCancel.Click += new System.EventHandler(this.btn_cpCancel_Click);
            // 
            // btn_cpok
            // 
            this.btn_cpok.Location = new System.Drawing.Point(29, 94);
            this.btn_cpok.Name = "btn_cpok";
            this.btn_cpok.Size = new System.Drawing.Size(75, 23);
            this.btn_cpok.TabIndex = 6;
            this.btn_cpok.Text = "确认";
            this.btn_cpok.UseVisualStyleBackColor = true;
            this.btn_cpok.Click += new System.EventHandler(this.btn_cpok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码确认";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "新 密 码";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 360);
            this.Controls.Add(this.plogin);
            this.Controls.Add(this.pchangepd);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.plogin.ResumeLayout(false);
            this.plogin.PerformLayout();
            this.pchangepd.ResumeLayout(false);
            this.pchangepd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plogin;
        private System.Windows.Forms.TextBox cmb_user;
        private System.Windows.Forms.CheckBox ckChPsd;
        private System.Windows.Forms.TextBox txtpasd;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pchangepd;
        private System.Windows.Forms.TextBox txtnewpd1;
        private System.Windows.Forms.TextBox txtnewpd;
        private System.Windows.Forms.Button btn_cpCancel;
        private System.Windows.Forms.Button btn_cpok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}