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

public partial class SiteBll_PDMan_PDLeftTree :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

            TreeNode node = new TreeNode("盘点管理");

            if (this.CUSER.USERFUNCTION.Q_PDD)
            {
                TreeNode sonNode1 = new TreeNode("盘点粗盘单");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "CuPan.aspx";
                node.ChildNodes.Add(sonNode1);
            
                TreeNode sonNode2 = new TreeNode("盘点抽盘单");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "ChouPan.aspx";
                node.ChildNodes.Add(sonNode2);
            }

            if (this.CUSER.USERFUNCTION.UP_PDD)
            {
                TreeNode sonNode3 = new TreeNode("盘点数据上传");
                sonNode3.Target = "RightFrame";
                sonNode3.NavigateUrl = "PDData.aspx";
                node.ChildNodes.Add(sonNode3);
            }
            if (this.CUSER.USERFUNCTION.Q_PDD)
            {
                TreeNode sonNode4 = new TreeNode("自由盘点");
                sonNode4.Target = "RightFrame";
                sonNode4.NavigateUrl = "ZYPDData.aspx";
                node.ChildNodes.Add(sonNode4);
            }
            if (this.CUSER.USERFUNCTION.Q_PDD)
            {
                TreeNode sonNode5 = new TreeNode("盘点参考");
                sonNode5.Target = "RightFrame";
                sonNode5.NavigateUrl = "PDCKSearch.aspx";
                node.ChildNodes.Add(sonNode5);
            }
            this.TreeView1.Nodes.Add(node);
        }
    }
}
