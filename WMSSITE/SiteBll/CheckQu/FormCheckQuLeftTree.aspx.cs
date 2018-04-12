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

public partial class SiteBll_CheckQu_FormCheckQuLeftTree : AccPageBase
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
            this.TreeView1.ExpandImageUrl = "../../Images/tree/img-folder-open.gif";
            this.TreeView1.NoExpandImageUrl = "../../Images/tree/img-folder.gif";
            this.TreeView1.NodeStyle.NodeSpacing = 2;
            TreeNode node = new TreeNode("质检管理");
            if (this.CUSER.USERFUNCTION.Che_Qu)
            {
                TreeNode sonNode1 = new TreeNode("质检");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "QuMain.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (this.CUSER.USERFUNCTION.Che_Qu&&this.CUSER.WEIGTHQCFUNCTION.BHGYY)
            {
                TreeNode sonNode2 = new TreeNode("质量原因");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "QuReason.aspx";
                node.ChildNodes.Add(sonNode2);
                //this.TreeView1.Nodes.Add(node);
            }
            //去掉标准维护功能
            //if (this.CUSER.WEIGTHQCFUNCTION.StandManage)
            //{
            //    TreeNode sonNode5 = new TreeNode("标准维护");
            //    sonNode5.Target = "RightFrame";
            //    sonNode5.NavigateUrl = "QuStand.aspx";
            //    node.ChildNodes.Add(sonNode5);
            //}
            if (this.CUSER.USERFUNCTION.Che_Qu)
            {
                TreeNode sonNode3 = new TreeNode("特殊信息");
                sonNode3.Target = "RightFrame";
                sonNode3.NavigateUrl = "QuSpecial.aspx";
                node.ChildNodes.Add(sonNode3);
                //this.TreeView1.Nodes.Add(node);
            }
            if (this.CUSER.USERFUNCTION.Che_Qu)
            {
                TreeNode sonNode4 = new TreeNode("卷信息查询");
                sonNode4.Target = "RightFrame";
                sonNode4.NavigateUrl = "QuBarcode.aspx";
                node.ChildNodes.Add(sonNode4);
                //this.TreeView1.Nodes.Add(node);
            }
            if (this.CUSER.USERFUNCTION.FYD_ZJQR)
            {
                TreeNode sonNode5 = new TreeNode("签证装车确认");
                sonNode5.Target = "RightFrame";
                sonNode5.NavigateUrl = "qufydqr.aspx";
                node.ChildNodes.Add(sonNode5);
                
            }
            this.TreeView1.Nodes.Add(node);
        }
    }
}
