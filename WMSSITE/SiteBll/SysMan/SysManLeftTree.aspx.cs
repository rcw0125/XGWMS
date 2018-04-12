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
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_SysMan_SysManLeftTree : System.Web.UI.Page
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
           
            TreeNode node = new TreeNode("系统设置");
            if (user.USERFUNCTION.SET_Param)
            {
                TreeNode sonNode1 = new TreeNode("参数设置");
                sonNode1.Target = "RightFrame";
                sonNode1.NavigateUrl = "ParamSet.aspx";
                node.ChildNodes.Add(sonNode1);
            }
            if (user.USERFUNCTION.SET_Store)
            {
                TreeNode sonNode2 = new TreeNode("仓库定义");
                sonNode2.Target = "RightFrame";
                sonNode2.NavigateUrl = "StoreSet.aspx";
                node.ChildNodes.Add(sonNode2);
            }
            if (user.USERFUNCTION.SET_Role)
            {
                TreeNode sonNode3 = new TreeNode("角色定义");
                sonNode3.Target = "RightFrame";
                sonNode3.NavigateUrl = "RoleSet.aspx";
                node.ChildNodes.Add(sonNode3);
            }
            if (user.USERFUNCTION.SET_User)
            {
                TreeNode sonNode4 = new TreeNode("用户权限");
                sonNode4.Target = "RightFrame";
                sonNode4.NavigateUrl = "UserRole.aspx";
                node.ChildNodes.Add(sonNode4);
            }
            if (user.USERFUNCTION.SET_KH)
            {
                TreeNode sonNode5 = new TreeNode("客户数据");
                sonNode5.Target = "RightFrame";
                sonNode5.NavigateUrl = "UserData.aspx";
                node.ChildNodes.Add(sonNode5);
            }
            if (user.USERFUNCTION.exe_itembaseinfo)
            {
                TreeNode sonNode6 = new TreeNode("物料基础信息");
                sonNode6.Target = "RightFrame";
                sonNode6.NavigateUrl = "ProductInfo.aspx";
                node.ChildNodes.Add(sonNode6);
            }
            if (user.USERFUNCTION.SET_HW)
            {
                TreeNode sonNode7 = new TreeNode("货位设置");
                sonNode7.Target = "RightFrame";
                sonNode7.NavigateUrl = "HWset.aspx";
                node.ChildNodes.Add(sonNode7);
            }
            if (user.USERFUNCTION.Syschqp)
            {
                TreeNode sonNode8 = new TreeNode("去皮设置");
                sonNode8.Target = "RightFrame";
                sonNode8.NavigateUrl = "QPset.aspx";
                node.ChildNodes.Add(sonNode8);
            }
            if (user.USERFUNCTION.Sysbzbz)
            {
                TreeNode sonNode9 = new TreeNode("包装扣重");
                sonNode9.Target = "RightFrame";
                sonNode9.NavigateUrl = "BZBZSet.aspx";
                node.ChildNodes.Add(sonNode9);
            }
            if (user.USERFUNCTION.Syskctw)
            {
                TreeNode sonNode922 = new TreeNode("头尾材扣重");
                sonNode922.Target = "RightFrame";
                sonNode922.NavigateUrl = "KCTWSet.aspx";
                node.ChildNodes.Add(sonNode922);
            }
            if (user.USERFUNCTION.Sysbzbz)
            {
                TreeNode sonNode91 = new TreeNode("属性设置");
                sonNode91.Target = "RightFrame";
                sonNode91.NavigateUrl = "SXSet.aspx";
                node.ChildNodes.Add(sonNode91);
            }
            if (user.USERFUNCTION.Syschqp)
            {
                TreeNode sonNode92 = new TreeNode("货位规则");
                sonNode92.Target = "RightFrame";
                sonNode92.NavigateUrl = "frmHWGZManage.aspx";
                node.ChildNodes.Add(sonNode92);
            }
            if (user.USERFUNCTION.doormanage)
            {
                TreeNode sonNode10 = new TreeNode("门岗设置");
                sonNode10.Target = "RightFrame";
                sonNode10.NavigateUrl = "DoorSet.aspx";
                node.ChildNodes.Add(sonNode10);
            }
            if (user.USERFUNCTION.qzsmanage)
            {
                TreeNode sonNode11 = new TreeNode("签证室设置");
                sonNode11.Target = "RightFrame";
                sonNode11.NavigateUrl = "QzsSet.aspx";
                node.ChildNodes.Add(sonNode11);
            }
            if (user.USERFUNCTION.Publish_Affiche)
            {
                TreeNode sonNode10 = new TreeNode("系统公告");
                sonNode10.Target = "RightFrame";
                sonNode10.NavigateUrl = "AfficheList.aspx";
                node.ChildNodes.Add(sonNode10);
            }
            this.TreeView1.Nodes.Add(node);

            //if (!string.IsNullOrEmpty(Request["TYPE"]))
            //{
            //    foreach (TreeNode snode in node.ChildNodes)
            //    {
            //        if (snode.Text == Request["TYPE"])
            //        {
            //            node.Select();
            //            break;
            //        }
            //    }
            //}
        }
    }
}
