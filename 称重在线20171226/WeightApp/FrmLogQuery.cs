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
    public partial class FrmLogQuery : Form
    {
        public FrmLogQuery()
        {
            InitializeComponent();
        }

        private void chkOUser_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkOUser.Checked)
                    BindUser();
                else
                {
                    this.comUser.DataSource = null;
                    this.comUser.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void BindUser()
        {
            this.comUser.Enabled = true;
            string strSql="select distinct oper from WMS_Bms_Rec_WGD_ManageLog";
            DataSet ds=DbEntry.Context.ExecuteDataset(strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                this.comUser.DataSource = ds.Tables[0];
            else
                this.comUser.DataSource = null;
        }

        private void chkRQ_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRQ.Checked)
            {
                this.dateTimeBegin.Enabled = true;
                this.dateTimeEnd.Enabled = true;
                this.dateTimeBegin.Text = DateTime.Now.ToShortDateString();
                this.dateTimeEnd.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                this.dateTimeBegin.Enabled = false;
                this.dateTimeEnd.Enabled = false;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = "select top 3000 * from wms_bms_rec_wgd_managelog where 1=1 ";
                sqlStr = sqlStr + GetWhere()+" order by opetime desc";
                DataSet ds = DbEntry.Context.ExecuteDataset(sqlStr);
                this.dgvData.AutoGenerateColumns = false;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    this.dgvData.DataSource = ds.Tables[0];
                else
                    this.dgvData.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string GetWhere()
        {
            string sqlfilter = "";
            if (chkOUser.Checked)
            {
                if (!string.IsNullOrEmpty(this.comUser.Text))
                    sqlfilter = sqlfilter + " and oper='" + comUser.Text + "'";
            }
            if (chkRQ.Checked)
            {
                sqlfilter += " and (opetime between '" + Convert.ToDateTime(this.dateTimeBegin.Text).ToShortDateString() + "' and '" + Convert.ToDateTime(dateTimeEnd.Text).AddDays(1).ToShortDateString() + "')";
            }
            return sqlfilter;
        }
    }
}
