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
using ACCTRUE.WMSBLL.Model;
using System.Xml;
using MSXML2;
using System.IO;
public partial class SiteBll_PDMan_AjaxLogic : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["TYPE"]))
        {
            string type = Request["TYPE"];
            string PDDH = Request["PDDH"];
            switch (type)
            {
                case "1":
                    try
                    {
                        string result = PDParam.DeleteCPD(PDDH);
                        if (result == "success")
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "2":
                    try
                    {
                        PDParam.fangkaiPDD(PDDH);
                        Response.Write("success");
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "3":
                    try
                    {
                        string result = PDParam.DeleteXPD(PDDH);
                        if (result == "success")
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "4":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        bool DonePDRK = PDParam.DonePYRK(YSDH);
                        if (DonePDRK)
                        {
                            Response.Write("DonePDRK");
                        }
                        else
                        {
                            Response.Write("NonePDRK");
                        }
                    }
                    catch
                    {
                        Response.Write("NonePDRK");
                    }
                    break;
                case "5":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        if (this.CUSER.USERFUNCTION.SH_PDD == false)
                        {
                            Response.Write("NoRole");
                        }
                        else
                        {
                            DataSet ds = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                string DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
                                if (DJZT == "已盘")
                                {
                                    Response.Write("yipan");
                                }
                                if (DJZT == "待盘")
                                {
                                    Response.Write("daipan");
                                }
                            }
                            else
                            {
                                Response.Write("bucunzai");
                            }
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "6":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string result = PDParam.shenheDataUp(YSDH, this.CUSER.UserID);
                        if (result == "success")
                        {
                            Response.Write("success");
                        }
                        else
                        {
                            string strResult = result.Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "");
                            Response.Write(Server.UrlEncode(strResult));
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "7":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        if (!this.CUSER.USERFUNCTION.EXE_KCTZ)
                        {
                            Response.Write("NoRole");
                        }
                        else
                        {
                            DataSet ds = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
                            if (ds == null || ds.Tables[0].Rows.Count < 1)
                            {
                                Response.Write("bucunzai");
                            }
                            else
                            {
                                string DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
                                if (DJZT != "已盘")
                                {
                                    Response.Write("DJZTerror");
                                }
                                else
                                {
                                    Response.Write("DJZTOK");
                                }
                            }
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "8":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string pkckbz = PDParam.Getpkckbz(YSDH);
                        if (pkckbz == "1")
                        {
                            Response.Write("PKCKed");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "9":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string pkckbz = PDParam.Getpkckbz(YSDH);
                        if (pkckbz == "1")
                        {
                            Response.Write("PKCKed");
                        }
                        else
                        {
                            int CKDH = PDParam.Getckdh();
                            bool result = PDParam.PKCK(YSDH, CKDH, this.CUSER.UserID);
                            if (result == false)
                            {
                                Response.Write("fail");
                            }
                            else
                            {
                                Response.Write("success");
                            }
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "10":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string pyrkbz = PDParam.GetPyrkbz(YSDH);
                        if (pyrkbz == "0")
                        {
                            bool result = PDParam.PYRK(YSDH, this.CUSER.UserID);
                            if (result == true)
                            {
                                Response.Write("success");
                            }
                            else
                            {
                                Response.Write("fail1");
                            }
                        }
                        else
                        {
                            Response.Write("pyrkbzNot0");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "11":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string pkckbz = PDParam.GetPyrkbz(YSDH);
                        if (pkckbz == "2")
                        {
                            Response.Write("PyrkbzIs2");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "12":
                    try
                    {
                        string YSDH1 = Request["YSDH"];
                        string barcode = Request["barcode"];
                        string pch = Request["pch"];
                        string sx = Request["sx"];
                        string ck = Request["ck"];
                        string hw = Request["drpHW"];
                        int pkckbz1 = PDParam.HWisOK(barcode, hw, pch, sx);
                        if (pkckbz1 == 1)
                        {
                            Response.Write("HWisOK");
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "13":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        string barcode = Request["barcode"];
                        string HW = Request["drpHW"];
                        PDParam.xiugaiHW(YSDH, barcode, HW);
                        Response.Write("success");
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
                case "14":
                    try
                    {
                        string YSDH = Request["YSDH"];
                        if (string.IsNullOrEmpty(YSDH))
                        {
                            DataSet dsfirst = PDParam.GetPDDNC("");
                            if (dsfirst != null)
                            {
                                YSDH = dsfirst.Tables[0].Rows[0]["YSDH"].ToString();
                                string CKID = dsfirst.Tables[0].Rows[0]["CK"].ToString();
                                string PDRQ = dsfirst.Tables[0].Rows[0]["PDRQ"].ToString();
                                string DJZT = dsfirst.Tables[0].Rows[0]["DJZT"].ToString();
                                Response.Write(YSDH + "," + CKID + "," + PDRQ + "," + DJZT);
                            }
                        }
                        else
                        {
                            DataSet ds = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
                            string CKID = ds.Tables[0].Rows[0]["CK"].ToString();
                            string PDRQ = ds.Tables[0].Rows[0]["PDRQ"].ToString();
                            string DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
                            Response.Write(YSDH + "," + CKID + "," + PDRQ + "," + DJZT);
                        }
                    }
                    catch
                    {
                        Response.Write("fail");
                    }
                    break;
            }
        }
    }
}