using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACCTRUE.WMSBLL.QueryBll;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class SiteBll_StockMan_KCJG : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.Reset();
        if (this.drpType.SelectedIndex != 0)
        {
            string strPath = Server.MapPath("Reports");
            if (this.drpType.SelectedIndex == 1)
            {
                DataSet ds = KCJG.GetXSP();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.ReportViewer1.LocalReport.ReportPath = strPath + "\\SpReport.rdlc";
                    ReportDataSource rds = new ReportDataSource("SpDataSet_SpData", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    this.PrintfError("无任何数据！");
                }
                
            }
            if (this.drpType.SelectedIndex == 2)
            {
                DataSet ds = KCJG.GetKCJG();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.ReportViewer1.LocalReport.ReportPath = strPath + "\\KCJGReport.rdlc";
                    ReportDataSource rds = new ReportDataSource("KCJGData_KCJG", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    this.PrintfError("无任何数据！");
                }
            }
            if (this.drpType.SelectedIndex == 3)
            {
                DataSet ds = KCJG.GetFSXJG();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.ReportViewer1.LocalReport.ReportPath = strPath + "\\FSXReport.rdlc";
                    ReportDataSource rds = new ReportDataSource("FSXJGData_FSXData", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    this.PrintfError("无任何数据！");
                }
            }
            if (this.drpType.SelectedIndex ==4)
            {
                DataSet ds = KCJG.GetKLFX();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.ReportViewer1.LocalReport.ReportPath = strPath + "\\KLReport.rdlc";
                    ReportDataSource rds = new ReportDataSource("KLDataSet_KLData", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    this.PrintfError("无任何数据！");
                }
            }
        }
        ReportViewer1.LocalReport.Refresh();
    }
}
