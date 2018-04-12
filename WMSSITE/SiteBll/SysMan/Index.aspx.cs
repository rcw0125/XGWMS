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

public partial class SiteBll_SysMan_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "参数设置")
                    RigthURL = "ParamSet.aspx";
                if (TYPE.Trim() == "仓库定义")
                    RigthURL = "StoreSet.aspx";
                if (TYPE.Trim() == "角色定义")
                    RigthURL = "RoleSet.aspx";
                if (TYPE.Trim() == "用户权限")
                    RigthURL = "UserRole.aspx";
                if (TYPE.Trim() == "客户数据")
                    RigthURL = "UserData.aspx";
                if (TYPE.Trim() == "物料基础信息")
                    RigthURL = "ProductInfo.aspx";
                if (TYPE.Trim() == "货位设置")
                    RigthURL = "HWset.aspx";
                if (TYPE.Trim() == "系统公告")
                    RigthURL = "AfficheList.aspx";
                if (TYPE.Trim() == "去皮设置")
                    RigthURL = "QPset.aspx";
                if (TYPE.Trim() == "包装扣重")
                    RigthURL = "BZBZSet.aspx";
                if (TYPE.Trim() == "门岗维护")
                    RigthURL = "DoorSet.aspx";
                if (TYPE.Trim() == "签证室维护")
                    RigthURL = "QzsSet.aspx";
                if (TYPE.Trim() == "属性设置")
                    RigthURL = "SXSet.aspx";
                if (TYPE.Trim() == "货位规则")
                    RigthURL = "frmHWGZManage.aspx";
                if (TYPE.Trim() == "头尾材扣重")
                    RigthURL = "KCTWSet.aspx";
            }
        }
    }
}
