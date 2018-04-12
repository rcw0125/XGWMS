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

public partial class SiteBll_FormMan_ZKDItems :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string action = Request.QueryString["action"];
            switch (action)
            {
                case "item":

                    if (Request["ZKDH"] != null)
                    {
                        string strZKDH = Request["ZKDH"];
                        try
                        {
                            DataSet ds = ZKDQuery.GetZKDItems(strZKDH);
                            this.grdGridList.DataSource = ds;
                            this.grdGridList.DataBind();
                        }
                        catch
                        {
                            this.PrintfError("数据访问失败！");
                            return;
                        }
                        
                    }
                    break;
                case "closedj":

                    if (Request["ZKDH"] != null)
                    {
                        string strZKDH = Request["ZKDH"];
                        try
                        {
                            ZKDQuery zkdquery = new ZKDQuery();
                            zkdquery.UpdteZKD(strZKDH);
                            Response.Write("<script>alert('单据已关闭');window.location='QZKD.aspx';</script>");
                        }
                        catch
                        {
                            this.PrintfError("数据访问失败！");
                            return;
                        }

                    }
                    break;
                case"chongzhi":
                    if (Request["ZKDH"] != null)
                    {
                        string strZKDH = Request.QueryString["ZKDH"];
                        string strPCH = Request.QueryString["PCH"];
                        string strSX = Request.QueryString["SX"];
                        ZKDQuery zkdquery = new ZKDQuery(strZKDH, strPCH, strSX);
                        int result = zkdquery.execZKD();
                        if (result == 0)
                        {
                            this.PrintfError("");
                            Response.Write("<script>alert('单据重置完毕，现在可以重新进行转入操作！');window.location='QZKD.aspx';</script>");

                        }
                        

                    }
                    break;
                   
            }
        }
    }
}
