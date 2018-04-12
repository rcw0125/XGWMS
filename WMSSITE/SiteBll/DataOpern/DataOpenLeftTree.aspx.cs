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

public partial class SiteBll_DataOpern_DataOpenLeftTree : System.Web.UI.Page
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

            TreeNode node = new TreeNode("数据处理");
            if (user.USERFUNCTION.Data_MoveLog)
            {
                TreeNode sonNode1 = new TreeNode("迁移日志浏览");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "DataMoveBrowse.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (user.USERFUNCTION.Data_Return)
            {
                TreeNode sonNode1 = new TreeNode("数据回迁");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "DataReturn.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            TreeNode sonNode2 = new TreeNode("传输日志");
            sonNode2.Target = "RightFrame";
            sonNode2.NavigateUrl = "DataTraLog.aspx";
            node.ChildNodes.Add(sonNode2);

            if (user.USERFUNCTION.Log_Delete)
            {
                TreeNode sonNode1 = new TreeNode("日志删除");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "LogDelete.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            this.TreeView1.Nodes.Add(node);
        }
    }
}
