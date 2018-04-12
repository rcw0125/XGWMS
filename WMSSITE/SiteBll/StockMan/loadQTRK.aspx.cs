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
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL.ReportBll;
using System.Web.Caching;
using ACCTRUE.WMSBLL;
using System.Xml;

public partial class SiteBll_Report_loadQTRK :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = "";
            if (Request["TYPE"] == null)
            {
                return;
            }
            type = Request["TYPE"];
            switch (type)
            {
                case "1"://获取货位s
                    DataSet ds = null;
                    try
                    {
                        string ck = "";
                        if (!string.IsNullOrEmpty(Request.QueryString["ck"]))
                        {
                          ck = Request.QueryString["ck"];
                        }
                        ds = QTRKReport.GetCKHW(ck);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "ruku":
                    try
                    {
                        string rkhw = Request["rkhw"];
                        string zkdh = Request["ZKDH"];
                        string tm = Request["tm"];
                        string drpCKType = Request["drpCKType"];
                        string ck1 = Request["ck"];
                        string txtzl = Request["txtzl"];
                        int TMcount = QTRKReport.GetTM(tm);//查询是否在库中
                        if (TMcount >= 1)
                        {
                            Response.Write("1");
                            return;
                        }
                        int djzt = 0;
                        if (drpCKType == "盘亏出库")
                        {
                            DataSet pkds = QTRKReport.GetPKCK(zkdh);
                            if (pkds != null)
                            {
                                if (pkds.Tables[0].Columns[0].ToString() == "已盘")
                                {
                                    djzt = 1;
                                }
                                if (pkds.Tables[0].Columns[0].ToString() == "已审")
                                {
                                    djzt = 1;
                                }
                            }

                        }
                        if (drpCKType == "销售出库")
                        {

                            DataSet ds1 = QTRKReport.GetXSCK(zkdh);
                            if (ds1 != null)
                            {
                                if (ds1.Tables[0].Rows[0][0].ToString() == "3")
                                {
                                    djzt = 1;
                                }
                            }

                        }
                        if (drpCKType == "转库出库")
                        {
                            DataSet ds2 = QTRKReport.GetZHCK(zkdh);
                            if (ds2 != null)
                            {
                                if (Convert.ToBoolean(ds2.Tables[0].Rows[0][0].ToString()))
                                {
                                    djzt = 1;
                                }
                                else
                                {
                                    djzt = 0;
                                }
                            }

                        }
                        if (drpCKType == "其它出库")
                        {
                            DataSet ds3 = QTRKReport.GetQTCK(zkdh);
                            if (ds3 != null)
                            {
                                if (ds3.Tables[0].Rows[0][0].ToString() == "2")
                                {
                                    djzt = 1;
                                }
                                else
                                {
                                    djzt = 0;
                                }
                            }

                        }
                        if (drpCKType == "期初出库")
                        {
                            djzt = 1;
                        }
                        if (djzt != 1)
                        {
                            Response.Write("NotRu");
                            return;
                        }
                        int i = QTRKReport.execQTRKHW(tm, rkhw, zkdh);
                        if (i == 0)
                        {
                            Response.Write("NotHW");
                            return;
                        }
                        string userid = this.CUSER.UserID;
                        string strTime = DateTime.Now.ToString("yymmddhhmmss");
                        string str1 = "insert into WMS_Bms_Inv_Info (Barcode,WGDH,CK,HW,PCH,WLH,WLMC,SX,vfree1,vfree2,vfree3,ZLDJ,PH,GG,BB,GH,ZL,BZ,RQ,RKType,RKRY,WeightRQ,CKCXH,ProduceData) select Barcode,RKDH,'" + ck1 + "','" + rkhw + "',PCH,WLH,WLMC,SX,vfree1,vfree2,vfree3,ZLDJ,PH,GG,BB,GH," + Convert.ToDouble(txtzl) + ",BZ,getdate(),'其他入库','" + userid + "',WeightRQ,CKCXH,ProduceData from WMS_Bms_Inv_OutInfo where barcode='" + tm + "' and fydh='" + zkdh + "'";

                        string str2 = "insert into WMS_Rev_Doc(RKDH,CK,HW,RKType,PCH,WLH,WLMC,SX,vfree1,vfree2,vfree3,PH,GG,SL,ZL,RKTime,CPH) select 'QTRK" + tm + "','" + ck1 + "','" + rkhw + "','其他入库',pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,ph,gg,1,zl,getdate(),'" + strTime + "' from WMS_Bms_Inv_OutInfo where barcode='" + tm + "'";
                        string str3 = "delete from WMS_Bms_Inv_OutInfo where barcode='" + tm + "' and fydh='" + zkdh + "'";
                        QTRKReport qtrkrep = new QTRKReport();
                        int isSuss=qtrkrep.ModiQTRK(str1, str2, str3);
                        if (isSuss == -1)
                        {
                            Response.Write("ERROR");
                            return;
                        }
                        Response.Write("SUCCESS");
                    }
                    catch
                    {
                        Response.Write("ERROR");
                    }
                    break;
            }
        }
    }
}
