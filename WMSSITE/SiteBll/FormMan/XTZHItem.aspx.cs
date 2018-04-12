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
using System.Text;
using ACCTRUE.WMSBLL.QueryBll;
using System.Collections.Generic;

public partial class SiteBll_FormMan_XTZHItem :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string action=Request.QueryString["action"];
            string zhdh=Request.QueryString["zhdh"];
            if(action=="item")
            {
                BindXTCopywl(zhdh);

            }
        }
    }
    //绑定第二个gridview
    private void BindXTCopywl(string sqlwhere)
    {
        try
        {

                DataSet ds2 = XTZHQuery.GetCopyXTItem(sqlwhere);
                if (ds2 != null)
                {
                    this.grvCOPYXTZH.DataSource = ds2;
                    this.grvCOPYXTZH.DataBind();
                }


            }
            catch
            {
                this.PrintfError("数据错误！");
                return;
            }


    }

}
