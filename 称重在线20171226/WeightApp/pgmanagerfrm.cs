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
    public partial class pgmanagerfrm : Form
    {
        public pgmanagerfrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pgmanagerfrm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnDele_Click(object sender, EventArgs e)
        {
            if (this.dgvData.DataSource!=null && this.dgvData.SelectedRows != null && this.dgvData.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否删除该跑钩记录?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow row =this.dgvData.SelectedRows[0];
                        Public.WriteManLog("",0,"",Convert.ToInt32(row.Cells[1].Value),0,"",Convert.ToInt32(row.Cells[1].Value),"跑钩删除",Public.userno);
                        string strDele="delete from  WMS_Bms_Rec_WGD_PaoGou where gh="+row.Cells[1].Value.ToString()+" and pch='"+row.Cells[2].Value.ToString()+"'";
                        DbEntry.Context.ExecuteNonQuery(strDele);
                        BindGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        void BindGrid()
        {
            string sql = "select * from WMS_Bms_Rec_WGD_PaoGou where scx='" + Public.userdd + "'";
            DataSet ds = DbEntry.Context.ExecuteDataset(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                this.dgvData.DataSource = ds.Tables[0];
            else
                this.dgvData.DataSource = null;
        }
    }
}