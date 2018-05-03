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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void getcmblist(string filename, ComboBox cmb,string sqlf)
        {
            string sqlstr = "";
            DataSet ds = null;
            sqlstr = "select distinct top 1000  " + filename + " from WMS_Bms_Inv_info where 1=1 " + sqlf + " order by " + filename + " desc";
            try
            {
                cmb.Items.Clear();
                Cursor.Current = Cursors.WaitCursor;
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        cmb.Items.Add(dr[filename].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (System.Exception ex)
            {
            	
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void search()
        {
            string sqlstrf = "";
            if (!string.IsNullOrEmpty(cmbpchq.Text)) sqlstrf += " and pch >='" + cmbpchq.Text + "'";
            if (!string.IsNullOrEmpty(cmbpchz.Text)) sqlstrf += " and pch<='" + cmbpchz.Text + "'";
            if (!string.IsNullOrEmpty(cmbbb.Text)) sqlstrf += " and bb='" + cmbbb.Text + "'";
            if (!string.IsNullOrEmpty(cmbph.Text)) sqlstrf += " and ph like '%" + cmbph.Text + "%'";
            if (!string.IsNullOrEmpty(cmbwlh.Text)) sqlstrf += " and wlh like '%" + cmbwlh.Text + "%'";
            if (!string.IsNullOrEmpty(cmbtm.Text)) sqlstrf += " and barcode like '%" + cmbtm.Text + "%'";
            if (!string.IsNullOrEmpty(cmbsx.Text)) sqlstrf += " and sx like '%" + cmbsx.Text + "%'";
            if (!string.IsNullOrEmpty(cmbgg.Text)) sqlstrf += " and gg like '%" + cmbgg.Text + "%'";
            if (cbrq.Checked)
            {
                sqlstrf += " and weightrq>='" + dtpq.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00' and weightrq<='" + dtpz.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
            }
            string sqlstr = "SELECT RANK() OVER (ORDER BY barcode DESC) AS 序号,* from WMS_Bms_Inv_info  where 1=1 " + sqlstrf + "  order by barcode desc";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            dgv.DataSource = ds.Tables[0];
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            dtpq.Value = DateTime.Now;
            dtpz.Value = DateTime.Now;
        }

        private void cmbpchq_DropDown(object sender, EventArgs e)
        {
            getcmblist("pch", cmbpchq, " ");
        }

        private void cmbpchz_DropDown(object sender, EventArgs e)
        {
            getcmblist("pch", cmbpchz, " ");
        }

        private void cmbwlh_DropDown(object sender, EventArgs e)
        {
            getcmblist("wlh", cmbwlh,"");
        }

        private void cmbsx_DropDown(object sender, EventArgs e)
        {
            getcmblist("sx", cmbsx, "");
        }

        private void cmbph_DropDown(object sender, EventArgs e)
        {
            getcmblist("ph", cmbph, "");
        }

        private void cmbgg_DropDown(object sender, EventArgs e)
        {
            getcmblist("gg", cmbgg, "");
        }

        private void cmbbb_DropDown(object sender, EventArgs e)
        {
            getcmblist("bb", cmbbb, "");
        }

        private void cmbtm_DropDown(object sender, EventArgs e)
        {
            getcmblist("barcode", cmbtm, "");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择单卷信息", "系统提示");
                return;
            }

            //Boolean v = Common.getWeightManageAuthority(Common.userno, "QuDel");
            Boolean t = Public.getWeightManageAuthority(Public.usermangno, "QuDel");
            if (!t)
            {
                MessageBox.Show("没有删除卷信息的权限！", "系统提示");
                return;
            }
            DataSet ds = null;
            string sqlstr = "";

            string pch = dgv.SelectedRows[0].Cells[1].Value.ToString();
            string barcode = dgv.SelectedRows[0].Cells["Column6"].Value.ToString();
            //string mcbarcode = dgv.SelectedRows[0].Cells["Column13"].Value.ToString();
            sqlstr = "select count(1) as f from WMS_Com_Log where ComResult=1 and  DOCID=(select WGDH from WMS_Bms_Rec_WGD where pch='" + pch + "')";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds.Tables[0].Rows[0]["f"].ToString() != "0")
            {
                if (MessageBox.Show("已回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            sqlstr = "select wcbz from WMS_Bms_Rec_WGD where pch='" + pch + "'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["wcbz"].ToString() == "3")
                {
                    MessageBox.Show("完工单已经结束批次，不能删除，在批次管理中放开完工单后再进行此操作！", "系统提示");
                    return;
                }
            }
            else
            {
                MessageBox.Show("完工单不存在，请重新查询！", "系统提示");
                return;
            }


            string msg = "是否删除，删除后将不能恢复？";
            //sqlstr = "select barcode from Wms_Bms_Inv_MC where mcbarcode='" + mcbarcode + "'";
            //ds = DbEntry.Context.ExecuteDataset(sqlstr);
            //string cjbarcodelist = "";
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 1)
            //{
            //    foreach (DataRow dr in ds.Tables[0].Rows)
            //    {
            //        cjbarcodelist += dr["barcode"].ToString() + ",";
            //    }
            //    cjbarcodelist = cjbarcodelist.Substring(0, cjbarcodelist.Length - 1);
            //    msg = "系统将自动删除相同母材的产品条码，产品条码为【" + cjbarcodelist + "】，请对不需要删除的产品条码进行重新打印！是否继续？";
            //}

            if (MessageBox.Show(msg, "系统提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                DbEntry.UsingTransaction(delegate()
                    {
                        sqlstr = "delete from WMS_Bms_Inv_Info where barcode='" + barcode + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        sqlstr = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper)" +
                            " values('" + barcode +
                            "','" + dgv.SelectedRows[0].Cells["Column5"].Value.ToString() +
                            "','" + dgv.SelectedRows[0].Cells["Column8"].Value.ToString() + "','" +
                            "0" +
                            "','" + dgv.SelectedRows[0].Cells["Column5"].Value.ToString() +
                            "','" + dgv.SelectedRows[0].Cells["Column8"].Value.ToString() +
                            "','" + "0" +
                            "','单卷删除','" + Public.userno + "')";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        sqlstr = "delete from wms_bms_inv_Bzzl where barcode='" + barcode + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        MessageBox.Show("删除成功！");
                        ds = DbEntry.Context.ExecuteDataset("select count(1) as f from wms_bms_inv_info where pch='" + pch + "'");   
                        if (ds.Tables[0].Rows[0]["f"].ToString() == "0")
                        {
                            DbEntry.Context.ExecuteNonQuery("update WMS_Bms_Rec_WGD set wcbz=0 where pch='" + pch + "'");
                        }
                        search();
                    });






            }
            catch (System.Exception ex)
            {
                MessageBox.Show("删除失败:" + ex.Message, "系统提示");
            }
        }

        private void cmbpchq_TextChanged(object sender, EventArgs e)
        {
            cmbpchz.Text = cmbpchq.Text;
        }
    }
}