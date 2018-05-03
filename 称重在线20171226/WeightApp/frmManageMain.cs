using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Lephone.Data;

namespace WeightApp
{
    public partial class frmManageMain : Form
    {
        public static bool isRunManMain;
        private string itype = "";
        public frmManageMain()
        {
            
            InitializeComponent();
        }
        private void searchuser()
        {
            DataSet ds = null;
            string sqlstr = "";
            sqlstr = "select username,usercname from WMS_Bms_Rec_WGD_Manage order by username";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            dgv.DataSource = ds.Tables[0];
            if (dgv.SelectedRows.Count == 0) return;
            inishow(dgv.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void inishow(string userno)
        {
            foreach (Control control in gbedt.Controls)
            {
                string controlname = control.Name;
                if (control is System.Windows.Forms.Label) continue;
                if (control is System.Windows.Forms.TextBox)control.Text = "";
                if (control is System.Windows.Forms.CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    cb.Checked = false;
                }
            }
            if (userno == "") return;
            DataSet ds = null;
            
            ds = DbEntry.Context.ExecuteDataset("select * from WMS_Bms_Rec_WGD_Manage where username='" + userno + "'");
            DataRow dr = ds.Tables[0].Rows[0];
            foreach (Control control in gbedt.Controls)
            {
                string controlname = control.Name;
                if (control is System.Windows.Forms.Label) continue;
                if (control is System.Windows.Forms.TextBox) continue;
                if (control is System.Windows.Forms.CheckBox)
                {
                    string filename = controlname.Substring(3);
                    CheckBox cb = (CheckBox)control;
                    cb.Checked = Convert.ToBoolean(dr[filename]);
                }
            }
            txtusername.Text = dr["usercname"].ToString();
            txtuserno.Text = dr["username"].ToString();
            txtpass.Text = dr["userpassword"].ToString();
            txtpass1.Text = dr["userpassword"].ToString();
        }
        private void frmManageMain_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            searchuser();
            if (!Public.ismanager)
            {
                paneln.Enabled = false;
            }
            else paneln.Enabled = true;
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            inishow(dgv.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void setedtstatus(string status)
        {
            itype = status;
            switch (status)
            {

                case "new":
                    dgv.Enabled = false;
                    gbedt.Enabled = true;
                    btn_add.Enabled = false;
                    btn_edt.Enabled = false;
                    btn_del.Enabled = false;
                    btn_save.Enabled = true;
                    btn_cancel.Enabled = true;
                    inishow("");
                    break;
                case "edt":
                    dgv.Enabled = false;
                    gbedt.Enabled = true;
                    btn_add.Enabled = false;
                    btn_edt.Enabled = false;
                    btn_del.Enabled = false;
                    btn_save.Enabled = true;
                    btn_cancel.Enabled = true;
                    break;
                case "qry":
                    dgv.Enabled = true;
                    gbedt.Enabled = false;
                    btn_add.Enabled = true;
                    btn_edt.Enabled = true;
                    btn_del.Enabled = true;
                    btn_save.Enabled = false;
                    btn_cancel.Enabled = false;
                    break;
                case "can":
                    dgv.Enabled = true;
                    gbedt.Enabled = false;
                    btn_add.Enabled = true;
                    btn_edt.Enabled = true;
                    btn_del.Enabled = true;
                    btn_save.Enabled = false;
                    btn_cancel.Enabled = false;
                    inishow(dgv.SelectedRows[0].Cells[0].Value.ToString());
                    break;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            setedtstatus("new");
        }

        private void btn_edt_Click(object sender, EventArgs e)
        {
            setedtstatus("edt");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            DataSet ds = null;
            if (txtuserno.Text == "")
            {
                MessageBox.Show("输入用户编码", "系统提示");
                txtuserno.Focus();
                return;
            }
            if (txtusername.Text == "")
            {
                MessageBox.Show("输入用户名", "系统提示");
                txtusername.Focus();
                return;
            }
            if (txtpass.Text!= txtpass1.Text)
            {
                MessageBox.Show("密码确认错误", "系统提示");
                txtpass.Focus();
                return;
            }
            string sqlstrtmp = "";
            if (itype == "new")
            {
                sqlstrtmp = "select count(1) as f from WMS_Bms_Rec_WGD_Manage where username='"+txtuserno.Text+"'";
                string filelist = "";
                string filevaluelist = "";
                foreach (Control control in gbedt.Controls)
                {
                    string controlname = control.Name;
                    if (control is System.Windows.Forms.Label) continue;
                    if (control is System.Windows.Forms.TextBox) continue;
                    if (control is System.Windows.Forms.CheckBox)
                    {
                        string filename = controlname.Substring(3);
                        filelist += filename + ",";
                        CheckBox cb = (CheckBox)control;
                        if (cb.Checked) filevaluelist = filevaluelist + "1,";
                        else filevaluelist += "0,";
                    }
                }
                sqlstr = "insert into WMS_Bms_Rec_WGD_Manage(username,usercname,userpassword,"+filelist.Substring(0,filelist.Length-1)+
                    ") values('"+txtuserno.Text+"','"+txtusername.Text+"','"+txtpass.Text+"',"+filevaluelist.Substring(0,filevaluelist.Length-1)+")";
                ds = DbEntry.Context.ExecuteDataset(sqlstrtmp);
                if (ds.Tables[0].Rows[0]["f"].ToString() != "0")
                {
                    MessageBox.Show("该用户已经存在！","系统提示");
                    return;
                }
                if (MessageBox.Show("是否保存？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                try
                {
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    MessageBox.Show("保存成功！","系统提示");
                    searchuser();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("保存失败："+ex.Message,"系统提示");
                    return;
                }
            }
            else 
            {
                sqlstrtmp = "select count(1) as f from WMS_Bms_Rec_WGD_Manage where username='"+txtuserno.Text+"' and username<>'"+dgv.SelectedRows[0].Cells[0].Value.ToString()+"'";
                string setvaluestr = "";
                foreach (Control control in gbedt.Controls)
                {
                    string controlname = control.Name;
                    if (control is System.Windows.Forms.Label) continue;
                    if (control is System.Windows.Forms.TextBox) continue;
                    if (control is System.Windows.Forms.CheckBox)
                    {
                        string filename = controlname.Substring(3);
                        CheckBox cb = (CheckBox)control;
                        if (cb.Checked)
                            setvaluestr += filename + "=1,";
                        else setvaluestr += filename + "=0,";
                    }
                }
                sqlstr = "update WMS_Bms_Rec_WGD_Manage set username='"+txtuserno.Text+"',usercname='"+txtusername.Text+"'," + setvaluestr + " userpassword='"+txtpass.Text+"' where username='" + dgv.SelectedRows[0].Cells[0].Value.ToString() + "'";
                
                ds = DbEntry.Context.ExecuteDataset(sqlstrtmp);
                if (ds.Tables[0].Rows[0]["f"].ToString() != "0")
                {
                    MessageBox.Show("该用户已经存在！", "系统提示");
                    return;
                }
                if (MessageBox.Show("是否保存？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                try
                {
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    MessageBox.Show("保存成功！", "系统提示");
                    searchuser();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败：" + ex.Message, "系统提示");
                    return;
                }
            }

            setedtstatus("qry");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            setedtstatus("can");
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择","系统提示");
                return;
            }
            if (MessageBox.Show("是否删除，删除后将不能恢复？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            string sqlstr = "delete from WMS_Bms_Rec_WGD_Manage where username='"+dgv.SelectedRows[0].Cells[0].Value.ToString()+"'";
            
            try
            {
                DbEntry.Context.ExecuteNonQuery(sqlstr);
                MessageBox.Show("删除成功！","系统提示");
                searchuser();
                setedtstatus("qry");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败："+ex.Message,"系统提示");
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            if (!Public.getWeightManageAuthority(Public.usermangno, "WeightSearch"))
            {
                MessageBox.Show("没有相关权限","系统提示");
                return;
            }
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmwgdmanage frm = new frmwgdmanage();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Public.getWeightManageAuthority(Public.usermangno, "PrintModle"))
            {
                MessageBox.Show("没有相关权限", "系统提示");
                return;
            }
            frmprintmodule frm = new frmprintmodule();
            frm.ShowDialog();
        }

        private void btnchangepsd_Click(object sender, EventArgs e)
        {
            frmchangepass frm = new frmchangepass();
            frm.ShowDialog();
        }

        private void frmManageMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Public.usermangno = "";
            isRunManMain = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmLogQuery frm = new FrmLogQuery();
            frm.ShowDialog();
        }
    }
}