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

public partial class SiteBll_StockMan_StockManLeftTree : System.Web.UI.Page
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

            TreeNode node = new TreeNode("库存管理");

            if (user.USERFUNCTION.Q_KC)
            {
                TreeNode sonNode1 = new TreeNode("入库账簿");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "RKZBView.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (user.USERFUNCTION.Q_KC)
            {
                TreeNode sonNode2 = new TreeNode("出库帐簿");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "CKZBView.aspx";
                node.ChildNodes.Add(sonNode2);
            }
            if (user.USERFUNCTION.Q_KC)
            {
                TreeNode sonNode3 = new TreeNode("当前库存");
                sonNode3.Target = "RightFrame";
                sonNode3.NavigateUrl = "KuCunQuery.aspx";
                node.ChildNodes.Add(sonNode3);
            }
            if (user.USERFUNCTION.Q_KC)
            {
                TreeNode sonNode4 = new TreeNode("预约量查询");
                sonNode4.Target = "RightFrame";
                sonNode4.NavigateUrl = "YYLQuery.aspx";
                node.ChildNodes.Add(sonNode4);

            }
            if (user.USERFUNCTION.Q_KC)
            {
                TreeNode sonNode5 = new TreeNode("批次管理");
                sonNode5.Target = "RightFrame";
                sonNode5.NavigateUrl = "PICIQuery.aspx";
                node.ChildNodes.Add(sonNode5);
 
            }
            if (user.USERFUNCTION.EXE_QTRK)
            {
                TreeNode sonNode6 = new TreeNode("其它入库");
                sonNode6.Target = "RightFrame";
                sonNode6.NavigateUrl = "QTRKReport.aspx";
                node.ChildNodes.Add(sonNode6);

            }
            if (user.USERFUNCTION.ZD_QTCK)
            {
                TreeNode sonNode7 = new TreeNode("其它出库单");
                sonNode7.Target = "RightFrame";
                sonNode7.NavigateUrl = "QTCKDan.aspx";
                node.ChildNodes.Add(sonNode7);
            }
            if (user.USERFUNCTION.EXE_HWVIEW)
            {
                TreeNode sonNode8 = new TreeNode("货位视图");
                sonNode8.Target = "RightFrame";
                sonNode8.NavigateUrl = "HWView.aspx";
                node.ChildNodes.Add(sonNode8);
            }
            //库存结构
            if (user.USERFUNCTION.KCJG)
            {
                TreeNode sonNode8 = new TreeNode("库存结构");
                sonNode8.Target = "RightFrame";
                sonNode8.NavigateUrl = "KCJG.aspx";
                node.ChildNodes.Add(sonNode8);
            }
            this.TreeView1.Nodes.Add(node);
        }
    }
}
