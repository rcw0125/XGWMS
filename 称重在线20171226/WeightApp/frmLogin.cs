using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;
using System.IO;
using System.Diagnostics;

namespace WeightApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Width = 281;
            this.Height = 196;
            plogin.Dock = DockStyle.Fill;
            pchangepd.Dock = DockStyle.Fill;
            plogin.BringToFront();
            CheckUpdate();
        }

        private void CheckUpdate()
        {

            string exeFile = System.AppDomain.CurrentDomain.BaseDirectory + "/AutoUpdate.exe";
            if (File.Exists(exeFile))
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = exeFile;
                info.Arguments = "";
                info.WindowStyle = ProcessWindowStyle.Normal;
                Process pro = Process.Start(info);
                if (pro.Start())
                {
                    pro.Close();

                }
            }

        }

        private void login()
        {
            DataSet ds = null;
            DataSet dstmp = null;
            
            string sqlstr = "";
            sqlstr = "select UserDept,UserID,UserPass,UserRole from WMS_Pub_Users where UserID='" + cmb_user.Text + "'";
            try
            {
                
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    string pass = dr["UserPass"].ToString();
                    string UserRole = dr["UserRole"].ToString();
                    string username = dr["UserID"].ToString();
                    string userdep = dr["userdept"].ToString();
                    if (pass != txtpasd.Text)
                    {
                        MessageBox.Show("密码错误！", "系统提示");
                        return;
                    }

                    if (userdep == "")
                    {
                        MessageBox.Show("没有指定生产线，不能登录", "系统提示");
                        return;
                    }
                    sqlstr = "select Bar_Print from WMS_Pub_Role where RoleName='" + UserRole + "'";
                    dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        if(dstmp.Tables[0].Rows[0]["Bar_Print"].ToString().ToUpper() != "TRUE")
                        {
                            MessageBox.Show("权限不够，不能使用！", "系统提示");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户权限没有初始化，不能使用本程序", "系统提示");
                        return;
                    }
                    Public.userno = username;
                    Public.userdd = userdep;
                    frmMain.isRunMain = true;
                    if (ckChPsd.Checked)
                    {
                        pchangepd.BringToFront();
                    }
                    else
                        this.Close();
                }
                else
                {
                    MessageBox.Show("用户不存在", "系统提示");
                    cmb_user.Focus();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void changepasslogin()
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
                    string sqlstr = "update WMS_Pub_Users set UserPass='" + txtnewpd.Text + "' where UserID='" + Public.userno + "'";
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

        private void btn_cpok_Click(object sender, EventArgs e)
        {
            changepasslogin();
        }

        private void btn_cpCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmb_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpasd.Focus();
            }
        }

        private void txtpasd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void txtnewpd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnewpd1.Focus();
            }
        }

        private void txtnewpd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                changepasslogin();
            }
        }
    }
}