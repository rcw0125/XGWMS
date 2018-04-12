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
//徐慧杰
public partial class SiteBll_InDoor_InDoorLeftTree : System.Web.UI.Page
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

            TreeNode node = new TreeNode("进出门管理");
            if (user.USERFUNCTION.Car_In)
            {
                TreeNode sonNode1 = new TreeNode("进门管理");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "InDoor.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (user.USERFUNCTION.Car_Out)
            {
                TreeNode sonNode2 = new TreeNode("出门管理");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "OutDoor.aspx";
                node.ChildNodes.Add(sonNode2);
            }
            this.TreeView1.Nodes.Add(node);  
          
            if (!string.IsNullOrEmpty(Request["TYPE"]))
            {
                foreach (TreeNode snode in node.ChildNodes)
                {
                    if (snode.Text == Request["TYPE"])
                    {
                        snode.Select();
                        break;
                    }
                }
            }
        }
    }
}
