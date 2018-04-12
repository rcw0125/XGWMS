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

public partial class SiteBll_FormMan_FormManLeftTree : System.Web.UI.Page
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

            TreeNode node = new TreeNode("单据管理");
            if (user.USERFUNCTION.Q_WGD)
            {
                TreeNode sonNode1 = new TreeNode("完工单查询");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "QWGD.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (user.USERFUNCTION.Q_FYD)
            {
                TreeNode sonNode2 = new TreeNode("发运单查询");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "QFYD.aspx";
                node.ChildNodes.Add(sonNode2);
            }
            if (user.USERFUNCTION.Q_ZKD)
            {
                TreeNode sonNode3 = new TreeNode("转库单查询");
                sonNode3.Target = "RightFrame";
                sonNode3.NavigateUrl = "QZKD.aspx";
                node.ChildNodes.Add(sonNode3);
            }
            if (user.USERFUNCTION.Q_YWD)
            {
                TreeNode sonNode4 = new TreeNode("移位单查询");
                sonNode4.Target = "RightFrame";
                sonNode4.NavigateUrl = "QYWD.aspx";
                node.ChildNodes.Add(sonNode4);
            }
            if (user.USERFUNCTION.Q_THD)
            {
                TreeNode sonNode5 = new TreeNode("退货单查询");
                sonNode5.Target = "RightFrame";
                sonNode5.NavigateUrl = "QTHD.aspx";
                node.ChildNodes.Add(sonNode5);
            }
            if (user.USERFUNCTION.exe_dpqry)
            {
                TreeNode sonNode6 = new TreeNode("待判品查询");
                sonNode6.Target = "RightFrame";
                sonNode6.NavigateUrl = "QDPP.aspx";
                node.ChildNodes.Add(sonNode6);
            }
            if (user.USERFUNCTION.fydqrsearch)
            {
                TreeNode sonNode8 = new TreeNode("发运单监控查询");
                sonNode8.Target = "RightFrame";
                sonNode8.NavigateUrl = "Fyd_QrSearch.aspx";
                node.ChildNodes.Add(sonNode8);
            }
            TreeNode sonNode7 = new TreeNode("形态转换");
            sonNode7.Target = "RightFrame";
            sonNode7.NavigateUrl = "QXTZH.aspx";
            node.ChildNodes.Add(sonNode7);
            this.TreeView1.Nodes.Add(node);
        }
    }
}
