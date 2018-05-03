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
    public partial class FrmQSearch : Form
    {
        public string sqlfilter;
        public string sqlfilterhz;

        public FrmQSearch()
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
            this.comPCHF.Enabled = this.chkPCH.Checked;
            this.cmbPCHT.Enabled = this.chkPCH.Checked;
            if (this.chkPCH.Checked)
            {
                string strSql = "select DISTINCT top 1000 pch from WMS_Bms_Inv_Info order by pch desc";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comPCHF.DataSource = null;
                comPCHF.ValueMember = "pch";
                comPCHF.DisplayMember = "pch";
                comPCHF.DataSource = ds.Tables[0];
                comPCHF.SelectedIndex = 0;
                cmbPCHT.DataSource = null;
                cmbPCHT.ValueMember = "pch";
                cmbPCHT.DisplayMember = "pch";
                cmbPCHT.DataSource = ds.Tables[0];
                cmbPCHT.SelectedIndex = 0;
            }
            else
            {
                comPCHF.DataSource=null;
                comPCHF.Enabled = false;
                cmbPCHT.DataSource = null;
                cmbPCHT.Enabled = false;
            }
        }

        private void chkPH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPH.Checked)
            {
                string strSql = "select DISTINCT top 1000 ph from WMS_Bms_Inv_Info order by ph desc";
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
                string strSql = "select DISTINCT top 500 gg from WMS_Bms_Inv_Info order by gg desc";
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
                string strSql = "select DISTINCT top 100 bb from WMS_Bms_Inv_Info order by bb desc";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comBB.DataSource = null;
                comBB.ValueMember = "bb";
                comBB.DisplayMember = "bb";
                comBB.DataSource = ds.Tables[0];
                comBB.SelectedIndex = 0;
            }
            else
            {
                comBB.DataSource = null;
                comBB.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(chkPCH.Checked)
                sqlfilter=sqlfilter+" and (pch>='"+this.comPCHF.Text.Trim()+"') and (pch<='"+this.cmbPCHT.Text.Trim()+"')";
            if(chkPH.Checked)
                sqlfilter+=" and ph='"+this.comPH.Text+"'";
            if(chkSX.Checked)
                sqlfilter+=" and sx='"+this.comSX.Text+"'";
            if(chkWL.Checked)
                sqlfilter+=" and wlh='"+this.comWL.Text+"'";
            if(chkGG.Checked)
                sqlfilter+=" and gg='"+this.comGG.Text+"'";
            if(chkGH.Checked)
                sqlfilter+=" and gg="+this.comGH.Text;
            if(chkBB.Checked)
                sqlfilter+=" and bb='"+this.comBB.Text+"'";
            if(chkCK.Checked)
               sqlfilter+=" and ck='"+this.comCK.SelectedValue.ToString()+"'";
            if(chkDJ.Checked)
               sqlfilter+=" and Barcode='"+this.txtDJ.Text+"'";
            if(chkHW.Checked)
               sqlfilter+=" and hw='"+this.txtHW.Text+"'";
            if (chkRQ.Checked)
                sqlfilter += sqlfilter + " and ((ProduceData>='" + Convert.ToDateTime(this.dateFrom.Text).ToString("yyyy.MM.dd") +
              "') and (ProduceData<='" + Convert.ToDateTime(this.dateFrom.Text).ToString("yyyy.MM.dd") + "'))";
            sqlfilterhz = sqlfilter;
            sqlfilter=sqlfilter+" order by pch,bb";
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

        private void chkSX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSX.Checked)
            {
                this.comSX.Enabled = true;
            }
            else
            {
                comSX.Enabled = false;
            }
        }

        private void chkWL_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkWL.Checked)
            {
                this.comWL.Enabled = true;
                string strSql = "select DISTINCT top 500 wlh from WMS_Bms_Inv_Info order by wlh desc";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comWL.DataSource = null;
                comWL.ValueMember = "wlh";
                comWL.DisplayMember = "wlh";
                comWL.DataSource = ds.Tables[0];
                comWL.SelectedIndex = 0;
            }
            else
            {
                comWL.DataSource = null;
                comWL.Enabled = false;
            }
        }

        private void chkGH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkGH.Checked)
            {
                this.comGH.Enabled = true;
                string strSql = "select DISTINCT top 500 gh from WMS_Bms_Inv_Info order by gh desc";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comGH.DataSource = null;
                comGH.ValueMember = "gh";
                comGH.DisplayMember = "gh";
                comGH.DataSource = ds.Tables[0];
                comGH.SelectedIndex = 0;
            }
            else
            {
                comGH.DataSource = null;
                comGH.Enabled = false;
            }
        }

        private void chkCK_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCK.Checked)
            {
                this.comCK.Enabled = true;
                string strSql = "select * from WMS_Pub_Store";
                DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
                comCK.DataSource = null;
                comCK.ValueMember = "ckid";
                comCK.DisplayMember = "ckname";
                comCK.DataSource = ds.Tables[0];
                comCK.SelectedIndex = 0;
            }
            else
            {
                comCK.DataSource = null;
                comCK.Enabled = false;
            }
        }

        private void chkDJ_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDJ.Checked)
            {
                this.txtDJ.Enabled = true;
            }
            else
            {
                this.txtDJ.Text = "";
                txtDJ.Enabled = false;
            }
        }

        private void chkHW_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHW.Checked)
            {
                this.txtHW.Enabled = true;
            }
            else
            {
                this.txtHW.Text = "";
                txtHW.Enabled = false;
            }
        }
        private void comPCHF_TextChanged(object sender, EventArgs e)
        {
            this.cmbPCHT.Text = comPCHF.Text;
        }
    }
}
