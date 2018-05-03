using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;
using System.IO;


namespace WeightApp
{
    public partial class tjjFrm : Form
    {
        private string strWhere;

        public tjjFrm()
        {
            Cursor.Current = Cursors.Default;
            InitializeComponent();
        }

        public tjjFrm(string pch)
        {
            Cursor.Current = Cursors.Default;
            strWhere = " and pch='"+pch+"'";
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FrmTJSearch bdSearch = new FrmTJSearch();
            if (bdSearch.ShowDialog() == DialogResult.OK)
            {
                strWhere = bdSearch.sqlfilter;
                //BindReprot();
                BindGrid();
                GetHZdata();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tjjFrm_Load(object sender, EventArgs e)
        {
            try
            {
                //   BindReprot();
                BindGrid();
                GetHZdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DataSet GetTjData(string strWhere)
        {
            string strSql = "select pch,ph,gg,sum(zl) as zl,count(1) as sl,sx,dbo.GetZPBHGJS(PCH,SX,count(1)) AS ZPBHGJS,"+
                        "dbo.GetZPBHGZL(PCH,SX,sum(zl)) AS ZPBHGZL,dbo.GETXYJS(PCH,SX,count(1)) AS XYJS,dbo.GETXYZL(PCH,SX,sum(zl)) AS XYZL,"+
                        "dbo.GETLXJS(PCH,SX,count(1)) AS LXJS,dbo.GETLXZL(PCH,SX,sum(zl)) AS LXZL,dbo.GETZNXJS(PCH,SX,count(1)) AS ZNXJS,dbo.GETZNXZL(PCH,SX,sum(zl)) AS ZNXZL,dbo.GETTWCJS(PCH,SX,sum(zl)) AS TWCJS,dbo.GETTWCZL(PCH,SX,sum(zl)) AS TWCZL " +
                        " from WMS_Bms_Inv_Info where 1=1 " + strWhere + "  group by pch,ph,gg,sx order by pch,ph,gg ";
            GetHZdata();
            DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
            return ds;
        }

        private string GetReportName()
        {
            DirectoryInfo mDir = new DirectoryInfo(Application.StartupPath);
            return mDir.FullName + "\\report\\TjReprot.rdlc";
        }

        //void BindReprot()
        //{
        //    this.reportViewer1.LocalReport.DataSources.Clear();
        //    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
        //    this.reportViewer1.LocalReport.ReportPath = GetReportName();
        //    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TJDataSet", GetTjData(strWhere).Tables[0]));
        //    this.reportViewer1.RefreshReport();       
        //}

        void BindGrid()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.DataSource = GetTjData(strWhere).Tables[0];
        }

        void GetHZdata()
        {
            string strSql="select sum(zl) as zzl,count(1) as zjs from WMS_Bms_Inv_Info where 1=1 "+strWhere;
            DataSet ds=DbEntry.Context.ExecuteDataset(strSql);
            if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                this.txtZJS.Text=ds.Tables[0].Rows[0]["zjs"].ToString();
                string strZZL = ds.Tables[0].Rows[0]["zzl"].ToString();
                if (string.IsNullOrEmpty(strZZL))
                    strZZL = "0";
                this.txtZZL.Text = strZZL;
                this.txtJZ.Text = (Convert.ToDouble(strZZL) / Convert.ToInt32(ds.Tables[0].Rows[0]["zjs"])).ToString("0.000");
            }
        }
    }
}