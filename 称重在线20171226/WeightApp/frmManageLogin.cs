using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;

namespace WeightApp
{
    public partial class frmManageLogin : Form
    {
        private bool isb;
        /// <summary>
        /// 补打标签
        /// </summary>
        public bool Isb
        {
            get { return isb; }
            set { isb = value; }
        }

        private bool printBAuthority;

        public bool PrintBAuthority
        {
            get { return printBAuthority; }
            set { printBAuthority = value; }
        }


        private bool isLogin;

        public bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value; }
        }

        public frmManageLogin()
        {
            InitializeComponent();
        }

        private void frmManageLogin_Load(object sender, EventArgs e)
        {
            this.Width = 281;
            this.Height = 196;
            plogin.Dock = DockStyle.Fill;
            pchangepd.Dock = DockStyle.Fill;
            plogin.BringToFront();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            DataSet dstmp = null;
            string sqlstr = "";
            sqlstr = "select * from WMS_Bms_Rec_WGD_Manage where username='" + cmb_user.Text + "'";
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    string pass = dr["userpassword"].ToString();
                    string username = dr["username"].ToString();
                    if (pass != txtpasd.Text)
                    {
                        frmManageMain.isRunManMain = false;
                        MessageBox.Show("密码错误！", "系统提示");
                        return;
                    }

                    Public.usermangno = username;
                    Public.ismanager = Convert.ToBoolean(dr["ismanager"]);
                    frmManageMain.isRunManMain = true;
                    frmParam.isRunManMain = true;
                    if (ckChPsd.Checked)
                    {
                        pchangepd.BringToFront();
                    }
                    else
                    {
                        printBAuthority = bool.Parse(dr["WeightBD"].ToString());
                        isLogin = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在", "系统提示");
                    cmb_user.Focus();
                    //return;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            frmManageMain.isRunManMain = false;
            frmParam.isRunManMain = false;
            Close();
        }

        private void btn_cpok_Click(object sender, EventArgs e)
        {
            string npd = txtnewpd.Text;
            string npd1 = txtnewpd1.Text;
            if (npd == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (npd != npd1)
            {
                MessageBox.Show("密码确认错误！");
                return;
            }
            if (MessageBox.Show("是否修改密码？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    string sqlstr = "update WMS_Bms_Rec_WGD_Manage set userpassword='" + txtnewpd.Text + "' where username='" + Public.usermangno + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    MessageBox.Show("修改成功！");
                    Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show("数据访问失败！" + err.Message);
                }
                finally
                {
                    //Cursor.Current = Cursors.Default;
                }

            }
        }

        private void btn_cpCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}