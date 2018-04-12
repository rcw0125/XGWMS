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

public partial class SiteBll_Report_Index : System.Web.UI.Page
{
    public string TYPE;
    public string RigthURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["TYPE"]))
            {
                TYPE = Request["TYPE"].Trim();
                if (TYPE.Trim() == "发运清单")
                    RigthURL = "FYListView.aspx";
                if (TYPE.Trim() == "货场日报表")
                    RigthURL = "HCDayReport.aspx";
                if (TYPE.Trim() == "库存明细表")
                    RigthURL = "KCList.aspx";
                if (TYPE.Trim() == "高线月盘存表")
                    RigthURL = "GXMonthReport.aspx";
                if (TYPE.Trim() == "月盘存明细表")
                    RigthURL = "MonthPC.aspx";
                if (TYPE.Trim() == "工作量统计")
                    RigthURL = "WorkLoadCount.aspx";
                if (TYPE.Trim() == "深加工批次查询")
                    RigthURL = "SXPCSearch.aspx";
                if (TYPE.Trim() == "产量信息汇总")
                    RigthURL = "CLHZSearch.aspx";
                if (TYPE.Trim() == "产量信息明细")
                    RigthURL = "CLMXSearch.aspx";
            }
        }
    }
}
