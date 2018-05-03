namespace WeightApp
{
    partial class frmchangepass
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
            this.pchangepd = new System.Windows.Forms.Panel();
            this.txtnewpd1 = new System.Windows.Forms.TextBox();
            this.txtnewpd = new System.Windows.Forms.TextBox();
            this.btn_cpCancel = new System.Windows.Forms.Button();
            this.btn_cpok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pchangepd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pchangepd
            // 
            this.pchangepd.Controls.Add(this.txtnewpd1);
            this.pchangepd.Controls.Add(this.txtnewpd);
            this.pchangepd.Controls.Add(this.btn_cpCancel);
            this.pchangepd.Controls.Add(this.btn_cpok);
            this.pchangepd.Controls.Add(this.label3);
            this.pchangepd.Controls.Add(this.label4);
            this.pchangepd.Location = new System.Drawing.Point(41, 3);
            this.pchangepd.Name = "pchangepd";
            this.pchangepd.Size = new System.Drawing.Size(261, 146);
            this.pchangepd.TabIndex = 10;
            // 
            // txtnewpd1
            // 
            this.txtnewpd1.Location = new System.Drawing.Point(89, 49);
            this.txtnewpd1.Name = "txtnewpd1";
            this.txtnewpd1.PasswordChar = '*';
            this.txtnewpd1.Size = new System.Drawing.Size(100, 21);
            this.txtnewpd1.TabIndex = 5;
            // 
            // txtnewpd
            // 
            this.txtnewpd.Location = new System.Drawing.Point(90, 16);
            this.txtnewpd.Name = "txtnewpd";
            this.txtnewpd.PasswordChar = '*';
            this.txtnewpd.Size = new System.Drawing.Size(100, 21);
            this.txtnewpd.TabIndex = 4;
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
            // frmchangepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 152);
            this.Controls.Add(this.pchangepd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmchangepass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.pchangepd.ResumeLayout(false);
            this.pchangepd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pchangepd;
        private System.Windows.Forms.TextBox txtnewpd1;
        private System.Windows.Forms.TextBox txtnewpd;
        private System.Windows.Forms.Button btn_cpCancel;
        private System.Windows.Forms.Button btn_cpok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}