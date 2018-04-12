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
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_StockMan_BrowseQTCK :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {string action = Request.QueryString["action"];
            switch (action)
            {
                case "deldj":
                    string delckdh = Request.QueryString["ckdh"];
                    DataSet ds3 = QTCKQuery.GetQTCKstatus("ckdh", delckdh);
                    if (ds3 != null)
                    {
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("NotDel");
                            //this.PrintfError("该单据已经执行，不能删除");
                            return;
                        }
                    }
                    Response.Write("false");
                    //Response.Write("<script>if (!confirm('确实要删除此出库单吗?')) return false;</script>");
                 
                    break;
                case "zaideldj":
                    string zaicdelkdh = Request.QueryString["ckdh"];
                    QTCKQuery delqtck=new QTCKQuery();
                    delqtck.CKDHDel(zaicdelkdh);
                    break;
                case "ChongZhi":
                    string chongzhickdh = Request.QueryString["ckdh"];
                    DataSet ds4 = QTCKQuery.GetQTCKstatus("ckdh", chongzhickdh);
                    if (ds4 != null)
                    {
                        if (ds4.Tables[0].Rows.Count >= 1)
                        {
                            //this.PrintfError("该单据已经执行完成，不能重置");
                            Response.Write("NotChongZhi");
                            return;
                        }
                        if (ds4.Tables[0].Rows.Count == 0)
                        {
                            //this.PrintfError("不用重置");
                            Response.Write("NoYong");
                            return;
                        }
                        Response.Write("false");
                    }
                    break;
                case "ZaiChongZhi":
                    string zaickdh = Request.QueryString["ckdh"];
                    QTCKQuery czqtck = new QTCKQuery();
                    czqtck.CKDHChongZhi(zaickdh);
                    czqtck.ChongZhiStatus(zaickdh);
                    Response.Write("new");
                    break;
                    
                case "CancelDJ":
                    string cancelckdh = Request.QueryString["ckdh"];
                    int i = QTCKQuery.GetRecordCount(cancelckdh);
                    if (i < 2)
                    {
                        //this.PrintfError("不用取消");
                        Response.Write("NoCancel");
                        return;
                    }
                    if (i == 2)
                    {
                        Response.Write("false");
                    }
                    break;
                case "zaiCancelDJ":
                    string zaiCancelckdh = Request.QueryString["ckdh"];
                    string fhck = Request.QueryString["fhck"];
                    int j = QTCKQuery.Exec_cancelqtck(zaiCancelckdh, fhck, CUSER.UserID);
                    if (j == 1)
                    {
                        Response.Write("zhixing");//正在执行
                    }
                    else
                    {
                        Response.Write("wrong");//取消完成失败！
                    }
                    break;
                case"SaveDJ":  
                    string saveckdh=Request.QueryString["ckdh"];
                    string Current = Request.QueryString["Current"];
                    string status = Request.QueryString["status"];
                    string ck = Request.QueryString["ck"];
                    string ncdj = Request.QueryString["ncdj"];
                    string cph = Request.QueryString["cph"];
                    string txtTARGET = Request.QueryString["txtTARGET"];
                    string CYS=Request.QueryString["CYS"];
                    string SHDW=Request.QueryString["SHDW"];
                    string ZDR=Request.QueryString["ZDR"];
                    string ZDRQ=Request.QueryString["ZDRQ"];
                    int k = QTCKQuery.GetRecordCount(saveckdh);
                    if (k > 0)
                    {
                        Response.Write("NoMODI");
                        //this.PrintfError("该单据已经执行，不能修改");
                        return;
                    }

                    if (Current == "new")
                    {
 
                    }
                    break;
                case "ModiMX":
                    string MXckdh=Request.QueryString["ckdh"];
                    DataSet dsmx = QTCKQuery.GetQTCKitem("ckdh", MXckdh);
                    if (dsmx == null)
                    {
                        Response.Write("wrongmx");
                    }
                    break;
                case "DelMX":
                    string delmxckdh = Request.QueryString["ckdh"];
                    DataSet deldsmx = QTCKQuery.GetQTCKitem("ckdh", delmxckdh);
                    if (deldsmx == null)
                    {
                        Response.Write("Delmx");
                    }
                    break;
                case "zaiDelMX":
                    string zaidelmx = Request.QueryString["ckdh"];
                    QTCKQuery dsdel = new QTCKQuery();
                    dsdel.CKDHDel(zaidelmx);
                    Response.Write("success");
                    break;
                case "add":
                    string strFCKDH = Request.QueryString["fckdh"];
                    string strFCK = Request.QueryString["fhck"];
                    string strPCH = Request.QueryString["pch"];
                    string strSX = Request.QueryString["sx"];

                    string strWLH = Request.QueryString["wlh"];
                    string strWLMC = Request.QueryString["wlmc"];
                    string strPH = Request.QueryString["ph"];
                    string strGG = Request.QueryString["gg"];
                    string strSLDW = Request.QueryString["sldw"];
                    string strZLDW = Request.QueryString["zldw"];
                    string strJHSL = Request.QueryString["jhsl"];
                    string strJHZL = Request.QueryString["jhzl"];
                    QTCKQuery qtckquery = new QTCKQuery();
                    qtckquery.Add(strFCKDH, strPCH, strSX, strWLH, strWLMC, strPH, strGG, strJHSL, strJHZL, 0, 0, strSLDW, strZLDW);
                    Response.Write("ins_suss");
                    break;


            }
                    
        }
    }

   