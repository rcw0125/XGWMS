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
    public partial class frmchangepass : Form
    {
        public frmchangepass()
        {
            InitializeComponent();
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