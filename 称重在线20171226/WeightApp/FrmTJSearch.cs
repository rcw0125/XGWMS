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
    public partial class FrmTJSearch : Form
    {
        public string sqlfilter;

        public FrmTJSearch()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.sqlfilter = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkPCH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPCH.Checked)
            {
                string strSql = "select pch from WMS_Bms_Rec_WGD where scx='" + Public.userdd + "'";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comSPCH.Enabled = true;
                comSPCH.DataSource = null;
                comSPCH.ValueMember = "pch";
                comSPCH.DisplayMember = "pch";
                comSPCH.DataSource = ds.Tables[0];
                comSPCH.SelectedIndex = 0;

                comEPC.Enabled = true;
                comEPC.DataSource = null;
                comEPC.ValueMember = "pch";
                comEPC.DisplayMember = "pch";
                comEPC.DataSource = ds.Tables[0];
                comEPC.SelectedIndex = 0;
            }
            else
            {
                comSPCH.DataSource=null;
                comSPCH.Enabled = false;

                comEPC.DataSource = null;
                comEPC.Enabled = false;
            }
        }

        private void chkPH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPH.Checked)
            {
                string strSql = "select distinct ph from WMS_Bms_Inv_Info";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comPH.Enabled = true;
                comPH.DataSource = null;
                comPH.ValueMember = "ph";
                comPH.DisplayMember = "ph";
                comPH.DataSource = ds.Tables[0];
                comPH.SelectedIndex = 0;
            }
            else
            {
                comPH.DataSource = null;
                comPH.Enabled = false;
            }
        }

        private void chkGG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkGG.Checked)
            {
                this.comGG.Enabled = true;
                string strSql = "select distinct gg from WMS_Bms_Inv_Info";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comGG.DataSource = null;
                comGG.ValueMember = "gg";
                comGG.DisplayMember = "gg";
                comGG.DataSource = ds.Tables[0];
                comGG.SelectedIndex = 0;
            }
            else
            {
                comGG.DataSource = null;
                comGG.Enabled = false;
            }
        }

        private void chkBB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBB.Checked)
            {
                this.comBB.Enabled = true;
            }
            else
            {
                comBB.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkPCH.Checked)
            {
                if(!string.IsNullOrEmpty(this.comSPCH.Text))
                    sqlfilter = sqlfilter + " and pch>='" + this.comSPCH.Text.Trim() + "'";
                if (!string.IsNullOrEmpty(this.comEPC.Text))
                    sqlfilter = sqlfilter + " and pch<='" + this.comSPCH.Text.Trim() + "'";
            }
            if(chkPH.Checked)
                sqlfilter+=" and ph='"+this.comPH.Text+"'";
            if(chkGG.Checked)
                sqlfilter+=" and gg='"+this.comGG.Text+"'";
            if(chkBB.Checked)
                sqlfilter+=" and bb='"+this.comBB.Text+"'";
            if (chkRQ.Checked)
                sqlfilter += sqlfilter + " and ((ProduceData>='" + Convert.ToDateTime(this.dateFrom.Text).ToString("yyyy.MM.dd") +
              "') and (ProduceData<='" + Convert.ToDateTime(this.dateFrom.Text).ToString("yyyy.MM.dd") + "'))";
            sqlfilter=sqlfilter+" and pch in (select pch from WMS_Bms_Rec_WGD where scx='"+Public.userdd+"')";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkRQ_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRQ.Checked)
            {
                this.dateFrom.Enabled = true;
                this.dateTo.Enabled = true;
                this.dateFrom.Text = DateTime.Now.ToShortDateString();
                this.dateTo.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                this.dateFrom.Enabled = false;
                this.dateTo.Enabled = false;
            }
        }

        private void comSPCH_TextChanged(object sender, EventArgs e)
        {
            this.comEPC.Text = comSPCH.Text;
        }
    }
}
