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
//using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_FormMan_fyd_kyhw : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strWLH = Request["wlh"];
            string strSX = Request["sx"];
            string strVfree1 = Request["vfree1"];
            string strVfree2 = Request["vfree2"];
            string strVfree3 = Request["vfree3"];
            string FYDH = Request["FYDH"];
            string ck = Request["ck"];
            string sqlstr = "";
            DataSet ds = new DataSet();
            ds = FYDQuery.GetQueryFYDKYHW(FYDH, ck, strWLH, strSX, strVfree1, strVfree2, strVfree3);
            //this.grvFYD.DataSource = ds;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.Label1.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else this.Label1.Text = "无";

           // this.grvFYD.DataBind();
        }
    }
}
