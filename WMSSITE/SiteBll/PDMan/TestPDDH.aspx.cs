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
public partial class SiteBll_PDMan_TestPDDH : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["PDDH"].ToString().Trim()))
                {
                    string PDDH = Request["PDDH"].Trim();
                    string DJLX = Request["DJLX"].Trim();
                    DataSet ds;
                    if (DJLX == "1")
                    {
                        ds = PDParam.TestPDDH(PDDH, "粗盘");
                    }
                    else
                    {
                        ds = PDParam.TestPDDH(PDDH, "抽盘");
                    }
                    if ((ds == null) || (ds.Tables[0].Rows.Count < 1))
                    {
                        Response.Write("no");
                    }
                    else
                    {
                        Response.Write(ds.Tables[0].Rows[0]["YSDH"].ToString() + "," + ds.Tables[0].Rows[0]["CK"].ToString() + "," + ds.Tables[0].Rows[0]["CKName"].ToString() + "," + ds.Tables[0].Rows[0]["PDRQ"].ToString() + "," + ds.Tables[0].Rows[0]["ZDRQ"].ToString() + "," + ds.Tables[0].Rows[0]["ZDUser"].ToString() + "," + ds.Tables[0].Rows[0]["SHUser"].ToString() + "," + ds.Tables[0].Rows[0]["SHUserName"].ToString() + "," + ds.Tables[0].Rows[0]["SHRQ"].ToString() + "," + ds.Tables[0].Rows[0]["DJZT"].ToString());
                    }
                }
            }
            catch
            {
                this.PrintfError("数据错误！");
            }
        }
    }
}
