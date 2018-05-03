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
    public partial class FrmQuery : Form
    {
        public FrmQuery()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FrmQSearch bdSearch = new FrmQSearch();
        
            if (bdSearch.ShowDialog() == DialogResult.OK)
            {
                BindCGrid(bdSearch.sqlfilter,bdSearch.sqlfilterhz);
                BindOGrid(bdSearch.sqlfilter,bdSearch.sqlfilterhz);
            }
        }

        void BindCGrid(string strWhere,string strWhereHZ)
        {
            string strHZ = "select top 3000 count(1) as js,sum(zl) as zl from wms_bms_inv_info where 1=1 " + strWhereHZ;
            string strSele = "select top 3000 * from wms_bms_inv_info where 1=1 "+strWhere;
            DataSet dsQ=DbEntry.Context.ExecuteDataset(strSele);
            this.dgvCur.AutoGenerateColumns = false;
            if (dsQ != null && dsQ.Tables.Count > 0 && dsQ.Tables[0].Rows.Count > 0)
                this.dgvCur.DataSource = dsQ.Tables[0];
            else
                this.dgvCur.DataSource = null;

            DataSet dsH=DbEntry.Context.ExecuteDataset(strHZ);
            this.txtCZJS.Text=dsH.Tables[0].Rows[0]["js"].ToString();
            this.txtCZZL.Text=dsH.Tables[0].Rows[0]["zl"].ToString();
        }

        void BindOGrid(string strWhere,string strWhereHZ)
        {
            string strHZ = "select top 3000 count(1) as js,sum(zl) as zl from WMS_Bms_Inv_OutInfo where 1=1 " + strWhereHZ;
            string strSele = "select top 3000 * from WMS_Bms_Inv_OutInfo where 1=1 " + strWhere;

            DataSet dsQ = DbEntry.Context.ExecuteDataset(strSele);
            this.dgvOut.AutoGenerateColumns = false;
            if (dsQ != null && dsQ.Tables.Count > 0 && dsQ.Tables[0].Rows.Count > 0)
                this.dgvOut.DataSource = dsQ.Tables[0];
            else
                this.dgvOut.DataSource = null;

            DataSet dsH = DbEntry.Context.ExecuteDataset(strHZ);
            this.txtOJS.Text = dsH.Tables[0].Rows[0]["js"].ToString();
            this.txtOZL.Text = dsH.Tables[0].Rows[0]["zl"].ToString();
        }
    }
}
