using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.QueryBll;
using Microsoft.Reporting.WebForms;

public partial class SiteBll_FormMan_PrintFYD :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["TYPE"]))
            {
                if (Request["TYPE"] == "0")
                {
                    SetReport("0");
                    return;
                }
                if (Request["TYPE"] == "1")
                {
                    SetReport("1");
                    return;
                }
                if (Request["TYPE"] == "2")
                {
                    SetReport("2");
                    return;
                }
                if (Request["TYPE"] == "3")
                {
                    SetReport("3");
                    return;
                }
            }
        }
    }

    //设置报表
    private void SetReport(String type)
    {
        this.ReportView1.ServerUrl = this.ReportURL;
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (type == "0")
        {
            this.ReportView1.Visible = false;
            string strPath = Server.MapPath("Reports");
            DataSet ds = KCJG.GetZCMX(Request["FYDH"]);
            DataSet ds2 = KCJG.GetZCMX2(Request["FYDH"]);
            DataSet ds3 = KCJG.GetZCMX3(Request["FYDH"]);
            DataSet ds4 = KCJG.GetGHXX(Request["FYDH"]);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0 && ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0 && ds4 != null && ds4.Tables.Count > 0 && ds4.Tables[0].Rows.Count > 0)
            {

                this.ReportViewer1.LocalReport.ReportPath = strPath + "\\FYDList.rdlc";
                ReportDataSource rds = new ReportDataSource("ZCMXDataSet_WMS_Bms_Inv_OutInfo", ds.Tables[0]);
                ReportDataSource rds1 = new ReportDataSource("ZCMXDataSet_ghxx", ds4.Tables[0]);
             
                ReportParameter rp = new ReportParameter("FYDH", Request["FYDH"]);
               
                ReportParameter rp2 = new ReportParameter("CX", ds3.Tables[0].Rows[0]["cx"].ToString());
                ReportParameter rp3 = new ReportParameter("CH", ds3.Tables[0].Rows[0]["cph"].ToString());
                ReportParameter rp4 = new ReportParameter("CZY", ds2.Tables[0].Rows[0]["czy"].ToString());
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
          
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp2 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp3 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp4 });
          
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.DataSources.Add(rds1);

            }
            else
            {
                this.PrintfError("无任何数据！");
            }
        
          
        }
        if (type == "1")
        {
            if (Common.IsOldData)
            {
                this.ReportView1.ReportPath = "/XGReportO/FYDRList";
            }
            else
                this.ReportView1.ReportPath = "/XGReportC/FYDRList";

            if (!string.IsNullOrEmpty(Request["FYDH"]))
                ReportView1.SetParameter("FYDH", Request["FYDH"]);
            if (!string.IsNullOrEmpty(Request["CK"]))
                ReportView1.SetParameter("CK", Request["CK"]);
            if (!string.IsNullOrEmpty(Request["KHH"]))
                ReportView1.SetParameter("KHBM", Request["KHH"]);
            if (!string.IsNullOrEmpty(Request["CPH"]))
                ReportView1.SetParameter("CPH", Server.UrlEncode(Request["CPH"]));
            if (!string.IsNullOrEmpty(Request["WLH"]))
                ReportView1.SetParameter("WLH", Request["WLH"]);
            if (!string.IsNullOrEmpty(Request["SX"]))
                ReportView1.SetParameter("SX", Server.UrlEncode(Request["SX"]));
            if (!string.IsNullOrEmpty(Request["TSXX"]))
                ReportView1.SetParameter("pcinfo", Server.UrlEncode(Request["TSXX"]));
            if (!string.IsNullOrEmpty(Request["PC"]))
                ReportView1.SetParameter("PCH", Request["PC"]);
            if (!string.IsNullOrEmpty(Request["PH"]))
                ReportView1.SetParameter("PH", Request["PH"]);
            if (!string.IsNullOrEmpty(Request["JMKH"]))
                ReportView1.SetParameter("INDOORID", Request["JMKH"]);
            if (!string.IsNullOrEmpty(Request["CMKH"]))
                ReportView1.SetParameter("OUTDOORID", Request["CMKH"]);
            if (!string.IsNullOrEmpty(Request["MIGG"]))
                ReportView1.SetParameter("MIGG", Server.UrlEncode(Request["MIGG"]));
            if (!string.IsNullOrEmpty(Request["MAGG"]))
                ReportView1.SetParameter("MAGG", Server.UrlEncode(Request["MAGG"]));
            if (!string.IsNullOrEmpty(Request["GG"]))
                ReportView1.SetParameter("GG", Server.UrlEncode(Request["GG"]));
            if (!string.IsNullOrEmpty(Request["YSLB"]))
                ReportView1.SetParameter("YSLB", Request["YSLB"]);
            if (!string.IsNullOrEmpty(Request["ZDR"]))
                ReportView1.SetParameter("NCZDRY", Server.UrlEncode(Request["ZDR"]));
            if (!string.IsNullOrEmpty(Request["BM"]))
                ReportView1.SetParameter("NCBM", Request["BM"]);
            if (!string.IsNullOrEmpty(Request["BM"]))
                ReportView1.SetParameter("NCBM", Request["BM"]);
            if (!string.IsNullOrEmpty(Request["STATUS"]))
                ReportView1.SetParameter("STATUS", Request["STATUS"]);
            if (!string.IsNullOrEmpty(Request["CSTATUS"]))
                ReportView1.SetParameter("CSTATUS", Request["CSTATUS"]);
            if (!string.IsNullOrEmpty(Request["ADD"]))
                ReportView1.SetParameter("AimAdress", Server.UrlEncode(Request["ADD"]));
            if (!string.IsNullOrEmpty(Request["SNCZDRQ"]))
                ReportView1.SetParameter("SNCZDRQ", Request["SNCZDRQ"]);
            if (!string.IsNullOrEmpty(Request["ENCZDRQ"]))
                ReportView1.SetParameter("ENCZDRQ", Request["ENCZDRQ"]);
            if (!string.IsNullOrEmpty(Request["SCKRQ"]))
                ReportView1.SetParameter("SCKRQ", Request["SCKRQ"]);
            if (!string.IsNullOrEmpty(Request["ECKRQ"]))
                ReportView1.SetParameter("ECKRQ", Request["ECKRQ"]);
            if (!string.IsNullOrEmpty(Request["SCZ_OTTime"]))
                ReportView1.SetParameter("SCZ_OTTime", Request["SCZ_OTTime"]);
            if (!string.IsNullOrEmpty(Request["ECZ_OTTime"]))
                ReportView1.SetParameter("ECZ_OTTime", Request["ECZ_OTTime"]);
            if (!string.IsNullOrEmpty(Request["SCZ_INTime"]))
                ReportView1.SetParameter("SCZ_INTime", Request["SCZ_INTime"]);
            if (!string.IsNullOrEmpty(Request["ECZ_INTime"]))
                ReportView1.SetParameter("ECZ_INTime", Request["ECZ_INTime"]);
            if (!string.IsNullOrEmpty(Request["sjsl"]))
                ReportView1.SetParameter("sjsl", Request["sjsl"]);
        }
        if (type == "2")
        {
            this.ReportView1.Visible = false;
            string strPath = Server.MapPath("Reports");
          
            DataSet ds = KCJG.GetDJMX(Request["FYDH"]);
            DataSet ds2 = KCJG.GetZCMX2(Request["FYDH"]);
            DataSet ds3 = KCJG.GetZCMX3(Request["FYDH"]);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0  && ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0 && ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            {
                this.ReportViewer1.LocalReport.ReportPath = strPath + "\\FYDDetails.rdlc";
                ReportDataSource rds = new ReportDataSource("ZCMXDataSet_WMS_Bms_Inv_OutInfo", ds.Tables[0]);
                ReportParameter rp = new ReportParameter("FYDH", Request["FYDH"]);
                ReportParameter rp2 = new ReportParameter("CX", ds3.Tables[0].Rows[0]["cx"].ToString());
                ReportParameter rp3 = new ReportParameter("CH", ds3.Tables[0].Rows[0]["cph"].ToString());
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp2 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp3 });
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            else
            {
                this.PrintfError("无任何数据！");
            }
        
        }
        if (type == "3")
        {
            this.ReportView1.Visible = false;
            string strPath = Server.MapPath("Reports");
            DataSet ds = KCJG.GetZCMX(Request["FYDH"]);
            DataSet ds1 = KCJG.GetZCMX1(Request["FYDH"]);
            DataSet ds2 = KCJG.GetZCMX2(Request["FYDH"]);
            DataSet ds3 = KCJG.GetZCMX3(Request["FYDH"]);
          
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 && ds2!= null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0 && ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            {

                    this.ReportViewer1.LocalReport.ReportPath = strPath + "\\ZCMXReport.rdlc";
                ReportDataSource rds = new ReportDataSource("ZCMXDataSet_WMS_Bms_Inv_OutInfo", ds.Tables[0]);
                ReportDataSource rds1 = new ReportDataSource("ZCMXDataSet_v_fyd_details", ds1.Tables[0]);
                ReportDataSource rds2 = new ReportDataSource("ZCMXDataSet_bwxx", ds2.Tables[0]);
                ReportDataSource rds3 = new ReportDataSource("ZCMXDataSet_byxx", ds3.Tables[0]);
                ReportParameter rp = new ReportParameter("fydh", Request["FYDH"]);
                ReportParameter rp1 = new ReportParameter("khname", ds3.Tables[0].Rows[0]["khname"].ToString());
                ReportParameter rp2 = new ReportParameter("cx", ds3.Tables[0].Rows[0]["cx"].ToString());
                ReportParameter rp3 = new ReportParameter("ch", ds3.Tables[0].Rows[0]["cph"].ToString());
                ReportParameter rp4 = new ReportParameter("czy", ds2.Tables[0].Rows[0]["czy"].ToString());
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[]{rp});
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp2 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp3 });
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp4 });
                ReportViewer1.LocalReport.DataSources.Add(rds1);
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.DataSources.Add(rds2);
                ReportViewer1.LocalReport.DataSources.Add(rds3);

               
            }
            else
            {
                this.PrintfError("无任何数据！");
            }
        
        
        
        
        }
        if (!string.IsNullOrEmpty(Request["ISWGDH"]))
            ReportView1.SetParameter("ISWGDH", "true");
    }
}
