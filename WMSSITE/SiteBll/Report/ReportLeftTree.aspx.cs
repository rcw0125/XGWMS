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

public partial class SiteBll_Report_ReportLeftTree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            InitMenu();
        }
    }

    private void InitMenu()
    {
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            this.TreeView1.ExpandImageUrl = "../../Images/tree/img-folder-open.gif";
            this.TreeView1.NoExpandImageUrl = "../../Images/tree/img-folder.gif";
            this.TreeView1.NodeStyle.NodeSpacing = 2;

            TreeNode node = new TreeNode("统计报表");
            TreeNode sonNode1 = new TreeNode("发运清单");
            sonNode1.Target = "RightFrame";
            sonNode1.NavigateUrl = "FYListView.aspx";
            node.ChildNodes.Add(sonNode1);

            TreeNode sonNode2 = new TreeNode("货场日报表");
            sonNode2.Target = "RightFrame";
            sonNode2.NavigateUrl = "HCDayReport.aspx";
            node.ChildNodes.Add(sonNode2);

            TreeNode sonNode3 = new TreeNode("库存明细表");
            sonNode3.Target = "RightFrame";
            sonNode3.NavigateUrl = "KCList.aspx";
            node.ChildNodes.Add(sonNode3);

            TreeNode sonNode4 = new TreeNode("高线月盘存表");
            sonNode4.Target = "RightFrame";
            sonNode4.NavigateUrl = "GXMonthReport.aspx";
            node.ChildNodes.Add(sonNode4);

            TreeNode sonNode5 = new TreeNode("月盘存明细表");
            sonNode5.Target = "RightFrame";
            sonNode5.NavigateUrl = "MonthPC.aspx";
            node.ChildNodes.Add(sonNode5);

            TreeNode sonNode6 = new TreeNode("工作量统计");
            sonNode6.Target = "RightFrame";
            sonNode6.NavigateUrl = "WorkLoadCount.aspx";
            node.ChildNodes.Add(sonNode6);

            TreeNode sonNode7 = new TreeNode("深加工批次查询");
            sonNode7.Target = "RightFrame";
            sonNode7.NavigateUrl = "SXPCSearch.aspx";
            node.ChildNodes.Add(sonNode7);

            TreeNode sonNode8 = new TreeNode("产量汇总数据查询");
            sonNode8.Target = "RightFrame";
            sonNode8.NavigateUrl = "CLHZSearch.aspx";
            node.ChildNodes.Add(sonNode8);

            TreeNode sonNode9 = new TreeNode("产量明细数据查询");
            sonNode9.Target = "RightFrame";
            sonNode9.NavigateUrl = "CLMXSearch.aspx";
            node.ChildNodes.Add(sonNode9); 

            this.TreeView1.Nodes.Add(node);

           
        }
    }
}
