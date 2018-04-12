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
using System.Text;
public partial class SiteBll_InDoor_PrintTHXP : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDS();
        }
    }

    private string InitTable(string CKName,string WLMC,string SX,string JHSL,string JHZL,string FJLDW,string JSYQ,string Remark,string free1,string free2,string free3)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<tr><td style='width: 100%'><table width='100%' border='0'><tr><td style='width: 20%'>仓库</td><td style='width: 70%'>");
        sb.Append(CKName);
        sb.Append("</td></tr><tr><td style='width: 20%'>物料名称</td><td style='width: 70%'>");
        sb.Append(WLMC);
        sb.Append("</td></tr><tr><td style='width: 20%'>自由项</td><td style='width: 70%'>");
        sb.Append(free1);
        sb.Append("</td></tr><tr><td style='width: 20%'></td><td style='width: 70%'>");
        sb.Append(free2);
        sb.Append("</td></tr><tr><td style='width: 20%'></td><td style='width: 70%'>");
        sb.Append(free3);
        sb.Append("</td></tr><tr><td style='width: 20%'>属性</td><td style='width: 70%'>");
        sb.Append(SX);
        sb.Append("</td></tr><tr><td style='width: 20%'>计划数量</td><td style='width: 70%'>");
        sb.Append(JHSL);
        sb.Append("</td></tr><tr><td style='width: 20%'>计划重量</td><td style='width: 70%'>");
        sb.Append(JHZL);
        sb.Append(FJLDW);
        sb.Append("</td></tr><tr><td style='width: 20%'>技术要求</td><td style='width: 70%'>");
        sb.Append(JSYQ);
        sb.Append("</td></tr><tr><td style='width: 20%'>备注</td><td style='width: 70%'>");
        sb.Append(Remark);
        sb.Append("</td></tr></table></td></tr>");
        return sb.ToString();
    }


    #region 初始化页面时获取发运单DataSet并为打印页填充值
    /// <summary>
    /// 初始化页面时获取发运单DataSet并为打印页填充值
    /// </summary>
    private void InitDS()
    {
        try
        {
            this.Literal1.Text = "";
            string strInit = "";
            if (string.IsNullOrEmpty(Request["fydh"]))
            {
                this.PrintfError("没有选择要打印的发运单！");
                return;
            }
            else
            {
                //string strWhere = " FYDH = '" + Request["fydh"] + "' and CKDH = '"+Request["ckdh"]+"' and CK = '"+Request["ck"]+"' and WLH = '"+Request["wlh"]+"'";
                string strWhere = " FYDH = '" + Request["fydh"] + "'";
                DataSet ds = InDoorParam.getDS(strWhere);
                DataSet dsHJ = InDoorParam.getDSByFYDH(Request["fydh"]);


                int HJJHSL = 0;
                double HJJHZL = 0;
                foreach (DataRow dr in dsHJ.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(dr["JHSL"].ToString()))
                    {
                        HJJHSL += Convert.ToInt32(dr["JHSL"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["JHZL"].ToString()))
                    {
                        HJJHZL += Convert.ToDouble(dr["JHZL"].ToString());
                    }
                }

                ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                string userName = user.UserName;
                string PrintDate = DateTime.Now.ToShortDateString();
                this.txtCZ_User.Text = userName;
                this.txtRQ.Text = PrintDate;
                this.txtHJ_JHSL.Text = HJJHSL.ToString();
                this.txtHJ_JHZL.Text = HJJHZL.ToString();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.txtFYDH.Text = ds.Tables[0].Rows[0]["fydh"].ToString();
                    this.txtCPH.Text = ds.Tables[0].Rows[0]["CPH"].ToString();
                    this.txtKHName.Text = ds.Tables[0].Rows[0]["KHName"].ToString();
                    this.txtZDRY.Text = ds.Tables[0].Rows[0]["NCZDRY"].ToString();
                    this.txtZDRQ.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["NCZDRQ"].ToString()).ToShortDateString();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string FYDH;
                        if (string.IsNullOrEmpty(dr["FYDH"].ToString()))
                        {
                            FYDH = "";
                        }
                        else
                        {
                            FYDH = dr["FYDH"].ToString();
                        }

                        string CPH;
                        if (string.IsNullOrEmpty(dr["CPH"].ToString()))
                        {
                            CPH = "";
                        }
                        else
                        {
                            CPH = dr["CPH"].ToString();
                        }

                        string KHName;
                        if (string.IsNullOrEmpty(dr["KHName"].ToString()))
                        {
                            KHName = "";
                        }
                        else
                        {
                            KHName = dr["KHName"].ToString();
                        }

                        string NCZDRY;
                        if (string.IsNullOrEmpty(dr["NCZDRY"].ToString()))
                        {
                            NCZDRY = "";
                        }
                        else
                        {
                            NCZDRY = dr["NCZDRY"].ToString();
                        }

                        DateTime NCZDRQ = DateTime.Now;
                        string ZDRQ;
                        if (string.IsNullOrEmpty(dr["NCZDRQ"].ToString()))
                        {
                            ZDRQ = "";
                        }
                        else
                        {
                            NCZDRQ = Convert.ToDateTime(dr["NCZDRQ"]);
                            ZDRQ = NCZDRQ.ToShortDateString();
                        }

                        string CKName;
                        if (string.IsNullOrEmpty(dr["CKName"].ToString()))
                        {
                            CKName = "";
                        }
                        else
                        {
                            CKName = dr["CKName"].ToString();
                        }

                        string WLMC;
                        if (string.IsNullOrEmpty(dr["WLMC"].ToString()))
                        {
                            WLMC = "";
                        }
                        else
                        {
                            WLMC = dr["WLMC"].ToString();
                        }
                        string free;
                        string free1;
                        string free2;
                        string free3;
                        free1 = "【" + dr["vfree1"].ToString() + "】";
                        free2 = "【" + dr["vfree2"].ToString() + "】";
                        free3 = "【" + dr["vfree3"].ToString() + "】";
                        free = "【" + dr["vfree1"].ToString() + "】" + "【" + dr["vfree2"].ToString() + "】" + "【" + dr["vfree3"].ToString() + "】";
                        string SX;
                        if (string.IsNullOrEmpty(dr["SX"].ToString()))
                        {
                            SX = "";
                        }
                        else
                        {
                            SX = dr["SX"].ToString();
                        }

                        int JHSL;
                        if (string.IsNullOrEmpty(dr["JHSL"].ToString()))
                        {
                            JHSL = 0;
                        }
                        else
                        {
                            JHSL = Convert.ToInt32(dr["JHSL"].ToString());
                        }

                        double JHZL;
                        if (string.IsNullOrEmpty(dr["JHZL"].ToString()))
                        {
                            JHZL = 0;
                        }
                        else
                        {
                            JHZL = Convert.ToDouble(dr["JHZL"].ToString());
                        }

                        string FJLDW;
                        if (string.IsNullOrEmpty(dr["FJLDW"].ToString()))
                        {
                            FJLDW = "";
                        }
                        else
                        {
                            FJLDW = dr["FJLDW"].ToString();
                        }

                        string PCInfo;
                        if (string.IsNullOrEmpty(dr["PCInfo"].ToString()))
                        {
                            PCInfo = "";
                        }
                        else
                        {
                            PCInfo = dr["PCInfo"].ToString();
                        }

                        string Remark;
                        if (string.IsNullOrEmpty(dr["ZLDJ"].ToString()))
                        {
                            Remark = "";
                        }
                        else
                        {
                            Remark = dr["ZLDJ"].ToString();
                        }
                        if (string.IsNullOrEmpty(strInit))
                        {
                            strInit += InitTable(CKName, WLMC, SX, JHSL.ToString(), JHZL.ToString(), FJLDW, PCInfo, Remark,free1,free2,free3);
                        }
                        else
                        {
                            strInit += "<tr><td>&nbsp;</td></tr>";
                            strInit += InitTable(CKName, WLMC, SX, JHSL.ToString(), JHZL.ToString(), FJLDW, PCInfo, Remark,free1,free2,free3);
                        }
                    }
                    this.Literal1.Text = strInit;
                }
            }
        }
        catch
        {
            this.PrintfError("打印小票出现错误，请重试或退出系统后重新登陆");
            return;
        }
    }
    #endregion
}
