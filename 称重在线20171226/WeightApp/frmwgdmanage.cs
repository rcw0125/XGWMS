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
    public partial class frmwgdmanage : Form
    {
        public frmwgdmanage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void searchwgd()
        {
            string sqlstr = "";
            DataSet ds = null;
            string pch = txtpch.Text;
            sqlstr = "select top 3000 *,case wcbz "+
                     " when 0 then '正常'  "+
                     " when 1 then '称重中'  "+
                     " when 2 then '称重完成'  "+
                     " when 3 then '入库完成'  "+
                     " end wcbzname  from WMS_Bms_Rec_WGD "+
                     " where (pch like '%"+pch+"%') ";
            ds = DbEntry.Context.ExecuteDataset(sqlstr); 
            dgvwgd.DataSource=ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvwgd.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择完工单！","系统提示");
                return;
            }
            if (!Public.getWeightManageAuthority(Public.usermangno, "SearchWGD"))
            {
                MessageBox.Show("没有权限！","系统提示");
                return;
            }
            string wgdh = dgvwgd.SelectedRows[0].Cells[0].Value.ToString();
            string pch = dgvwgd.SelectedRows[0].Cells[1].Value.ToString();
            string sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='"+wgdh+"'";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);

            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("完工单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='" + pch + "'";

            ds = DbEntry.Context.ExecuteDataset(sqlstr);

            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("材料出库单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            if (int.Parse(dgvwgd.SelectedRows[0].Cells["colwcbz"].Value.ToString()) < 2)
            {
                MessageBox.Show("无需重置！","系统提示");
                return;
            }
            
            if (MessageBox.Show("是否重置完工单，批次号【" + pch + "】", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                DbEntry.UsingTransaction(delegate()
                        {
                            sqlstr = "update WMS_Bms_Rec_WGD set wcbz=1 , sendend=0 where pch='" + pch + "'";
                            DbEntry.Context.ExecuteNonQuery(sqlstr);

                            sqlstr = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper)" +
                                 " values('" + wgdh + "','0',' ',0,0,' ',0,'重置完工单','" + Public.usermangno + "')";
                            DbEntry.Context.ExecuteNonQuery(sqlstr);
                            MessageBox.Show("重置成功！");
                            searchwgd();
                        });
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败:" + ex.Message, "系统提示");
            }
        }

        private void frmwgdmanage_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            dgvwgd.AutoGenerateColumns = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvwgd.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择完工单！", "系统提示");
                return;
            }
            if (!Public.getWeightManageAuthority(Public.usermangno, "ReCheck"))
            {
                MessageBox.Show("没有权限！", "系统提示");
                return;
            }
            string wgdh = dgvwgd.SelectedRows[0].Cells[0].Value.ToString();
            string pch = dgvwgd.SelectedRows[0].Cells[1].Value.ToString();
            string sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='" + wgdh + "'";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("完工单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='" + pch + "'";

            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("材料出库单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            if (dgvwgd.SelectedRows[0].Cells["colzjbz"].Value.ToString() == "0")
            {
                MessageBox.Show("未质检，不用重新质检！", "系统提示");
                return;
            }
            sqlstr = "select count(1) as fcount from WMS_Bms_Inv_Info where pch='"+pch+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (int.Parse(ds.Tables[0].Rows[0]["fcount"].ToString()) > 0)
            {
                if (MessageBox.Show("已经生产，是否继续？继续将删除已生产的线材", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            sqlstr = "select count(1) as fcount from WMS_Bms_Inv_OutInfo where pch='"+pch+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (int.Parse(ds.Tables[0].Rows[0]["fcount"].ToString()) > 0)
            {
                MessageBox.Show("已经出库，不能重新质检", "系统提示"); return;
            }
            if (MessageBox.Show("是否重新质检，删除动作将不能恢复？", "系统警告", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                DbEntry.UsingTransaction(delegate()
                            {
                                sqlstr = "update WMS_Bms_Rec_WGD set PGBZ=0,wcbz=0,zjbz=0,sendend=0 where pch='" + pch + "'";

                                DbEntry.Context.ExecuteNonQuery(sqlstr);
                                sqlstr = "delete from WMS_Bms_Inv_Info where pch='" + pch + "'";
                                DbEntry.Context.ExecuteNonQuery(sqlstr);
                                
                                sqlstr = "delete from Wms_Bms_Inv_Bzzl where pch='" + pch + "'";
                                DbEntry.Context.ExecuteNonQuery(sqlstr);
                                sqlstr = "delete from  WMS_Bms_Rec_WGD_Liquid where pch='" + pch + "'";
                                DbEntry.Context.ExecuteNonQuery(sqlstr);
                                sqlstr = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper)" +
                                     " values('" + wgdh + "','0',' ',0,0,' ',0,'重新质检完工单','" + Public.usermangno + "')";
                                DbEntry.Context.ExecuteNonQuery(sqlstr);
                                MessageBox.Show("操作成功！");
                                searchwgd();
                            }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败:" + ex.Message, "系统提示");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvwgd.SelectedRows.Count == 0)
            {
                MessageBox.Show("选择完工单！", "系统提示");
                return;
            }
            if (!Public.getWeightManageAuthority(Public.usermangno, "DelWgd"))
            {
                MessageBox.Show("没有权限！", "系统提示");
                return;
            }
            string wgdh = dgvwgd.SelectedRows[0].Cells[0].Value.ToString();
            string pch = dgvwgd.SelectedRows[0].Cells[1].Value.ToString();
            string sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='" + wgdh + "'";
            DataSet ds = null;

            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("完工单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            sqlstr = "select top 3000 * from WMS_Com_Log where ComResult=1 and DOCID='" + pch + "'";

            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("材料出库单已经回传NC，是否继续？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            string wcbz=dgvwgd.SelectedRows[0].Cells["colwcbz"].ToString();
            string msg="";
            switch(wcbz)
            {
                case "0":
                    msg="是否删除？";
                    break;
                case "1":
                    msg="已经生产，是否删除？";
                    break;
                case "2":
                    msg="已经生产结束，是否删除?";
                    break;
                case "3":
                    msg="已经入库，是否删除？";
                    break;
                default:
                    msg="是否删除？";
                    break;
            }
            sqlstr = "select count(1) as fcount from WMS_Bms_Inv_OutInfo where pch='" + pch + "'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (int.Parse(ds.Tables[0].Rows[0]["fcount"].ToString()) > 0)
            {
                MessageBox.Show("已经出库，不能删除", "系统提示"); return;
            }
            if (MessageBox.Show(msg+"删除动作将不能恢复？", "系统警告", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                DbEntry.UsingTransaction(delegate()
                {
                    sqlstr = "delete WMS_Bms_Rec_WGD where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "delete WMS_Bms_Rec_WGD_item where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "delete from WMS_Bms_Inv_Info where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "delete from WMS_Bms_Rec_WGD_Free where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "delete from WMS_Bms_Rec_WGD_Item_Free where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    
                    sqlstr = "delete from Wms_Bms_Inv_Bzzl where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "delete from  WMS_Bms_Rec_WGD_Liquid where pch='" + pch + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    sqlstr = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper)" +
                         " values('" + wgdh + "','0',' ',0,0,' ',0,'删除完工单','" + Public.usermangno + "')";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    
                    MessageBox.Show("操作成功！");
                    searchwgd();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败:" + ex.Message, "系统提示");
            }
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchwgd();
        }

        private void dgvwgd_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvwgd.SelectedRows.Count == 0) return;
            string pch = dgvwgd.SelectedRows[0].Cells[1].Value.ToString();
            string sqlstr = "SELECT RANK() OVER (ORDER BY barcode DESC) AS 序号,* from WMS_Bms_Inv_Info  where 1=1 and pch='" + pch + "'  order by barcode";
            DataSet ds = null;
            
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            dgv.DataSource = ds.Tables[0];
        }
    }
}