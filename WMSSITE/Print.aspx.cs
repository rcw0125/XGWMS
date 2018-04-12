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
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL.Model;
public partial class Print :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["TYPE"]))
        {
            string type = Request["TYPE"];
            switch (type)
            {
                case "1"://打印完工单
                    if (!string.IsNullOrEmpty(Request["QUERYSQL"]))
                    {
                        try
                        {
                            DataSet ds = WGDQuery.QueryWGDExcel(Request["QUERYSQL"]);
                            string strPrin=this.DGPrint(ds.Tables[0]);
                            Response.Write(strPrin);
                        }
                        catch
                        {
                            return;
                        }
                    }
                    break;
                case "2"://打印IC卡信息
                        try
                        {
                            DataSet ds = ICParam.GetPrintDS(Request["QUERYSQL"]);
                            string strPrin = this.DGPrint(ds.Tables[0]);
                            Response.Write(strPrin);
                        }

                        catch
                        {
                            return;
                        }                   
                    break;
                case "3"://打印发运单(进出门管理的查看发运单模块)
                    try
                    {
                        DataSet ds1 = InDoorParam.GetPrintDS(Request["QUERYSQL"]);
                        string strPrin1 = this.DGPrint(ds1.Tables[0]);
                        Response.Write(strPrin1);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case"4"://打印发运单(查询)
                    
                    break;
                case"5"://打印转库单(查询)
                    try
                    {
                        DataSet ds = ZKDQuery.QueryZKDExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case"6"://打印移位单(查询)
                    try
                    {
                        DataSet ds = YWDQuery.QueryYWDExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case "7"://打印退货单(查询)
                    try
                    {
                        DataSet ds = THDQuery.QueryTHDExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case "8"://打印待判品查询单(查询)
                    try
                    {
                        DataSet ds =DPPQuery.QueryPDDExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case "9"://打印入库账簿单(查询)
                    try
                    {
                        DataSet ds = RKZBQuery.QueryRKZBExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
                case "10"://打印出库账簿单(查询)
                    try
                    {
                        DataSet ds = CKZBQuery.QueryCKZBExcel(Request["QUERYSQL"]);
                        string strPrin = this.DGPrint(ds.Tables[0]);
                        Response.Write(strPrin);
                    }
                    catch
                    {
                        return;
                    }
                    break;
            }
        }
    }
}
