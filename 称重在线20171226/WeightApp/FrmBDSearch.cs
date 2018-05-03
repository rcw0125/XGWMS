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
    public partial class FrmBDSearch : Form
    {
        public string SqlString;
        private string sqlfilter;
        public string TableName;

        public FrmBDSearch()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.sqlfilter = "";
            this.SqlString = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkPCH_CheckedChanged(object sender, EventArgs e)
        {
            this.comPCH.Enabled = this.chkPCH.Checked;
            if (this.chkPCH.Checked)
            {
                GetSearchItem("pch", comPCH);
            }
            else
            {
                comPCH.DataSource=null;
                comPCH.Enabled = false;
            }
        }

        private void GetSearchItem(string fildName, ComboBox com)
        {
            string sqlStr;
            try
            {
                Cursor.Current=Cursors.WaitCursor;
                if(this.rdoKN.Checked)
                    sqlStr="select distinct a."+fildName+" from WMS_Bms_Inv_Info a left join "+
                  "WMS_Bms_Rec_WGD b on a.pch=b.pch where b.scx='"+Public.userdd+"' order by a."+fildName;
                else
                    sqlStr= "select distinct a."+fildName+" from WMS_Bms_Inv_OutInfo a  left join "+
                 "WMS_Bms_Rec_WGD b on a.pch=b.pch where b.scx='"+Public.userdd+"' order by a."+fildName;
                DataSet ds=DbEntry.Context.ExecuteDataset(sqlStr);
                com.DataSource = null;
                com.ValueMember = fildName;
                com.DisplayMember = fildName;
                com.DataSource = ds.Tables[0];
                com.SelectedIndex = 0;
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current=Cursors.Default;
            }
        }

        private void chkGH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkGH.Checked)
            {
                this.comGH.Enabled = true;
                GetSearchItem("gh", comGH);
            }
            else
            {
                comGH.DataSource = null;
                comGH.Enabled = false;
            }
        }

        private void chkPH_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPH.Checked)
            {
                this.comPH.Enabled = true;
                GetSearchItem("ph", comPH);
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
                GetSearchItem("gg", comGG);
            }
            else
            {
                comGG.DataSource = null;
                comGG.Enabled = false;
            }
        }

        private void chkSX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSX.Checked)
            {
                this.comSX.Enabled = true;
                GetSearchItem("sx", comSX);
            }
            else
            {
                comSX.DataSource = null;
                comSX.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkPCH.Checked && !string.IsNullOrEmpty(this.comPCH.Text))
                sqlfilter=sqlfilter+" and a.pch='"+this.comPCH.Text+"'";
            if(chkGH.Checked)
                sqlfilter+=" and a.gh='"+this.comGH.Text+"'";
            if (chkPH.Checked && !string.IsNullOrEmpty(this.comPH.Text))
                sqlfilter+=" and a.ph='"+this.comPH.Text+"'";
            if (chkGG.Checked && !string.IsNullOrEmpty(this.comGG.Text))
                sqlfilter+=" and a.gg='"+this.comGG.Text+"'";
            if (chkSX.Checked && !string.IsNullOrEmpty(this.chkSX.Text))
                sqlfilter+=" and a.sx='"+this.comSX.Text+"'";
            //if (this.rdoKN.Checked)
            //{
            //    SqlString = "select a.*,b.SCX from WMS_Bms_Inv_Info a left join  " +
            //    " WMS_Bms_Rec_WGD b on a.pch=b.pch where b.SCX= '" + Public.userdd + "'" + sqlfilter;
            //    TableName = "WMS_Bms_Inv_Info";
            //}
            //else
            //{
            //    SqlString = "select a.*,b.SCX from WMS_Bms_Inv_OutInfo a left join " +
            //    "  WMS_Bms_Rec_WGD b on a.pch=b.pch where b.SCX= '" + Public.userdd + sqlfilter;
            //    TableName = "WMS_Bms_Inv_OutInfo";
            //}

            if (this.rdoKN.Checked)
            {
                SqlString = "select a.*,b.SCX,b.vfree0 as heatid,b.vfree4 as liaohao from WMS_Bms_Inv_Info a left join  " +
                " WMS_Bms_Rec_WGD b on a.pch=b.pch where b.SCX= '" + Public.userdd + "'" + sqlfilter;
                TableName = "WMS_Bms_Inv_Info";
            }
            else
            {
                SqlString = "select a.*,b.SCX,b.vfree0 as heatid,b.vfree4 as liaohao from WMS_Bms_Inv_OutInfo a left join " +
                "  WMS_Bms_Rec_WGD b on a.pch=b.pch where b.SCX= '" + Public.userdd + "'" + sqlfilter;
                TableName = "WMS_Bms_Inv_OutInfo";
            }



            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
