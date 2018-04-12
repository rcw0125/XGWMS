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
using System.Text;
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL.QueryBll;

public partial class FirstPage :AccPageBase
{
    public int WGDCount;
    public int XTZHCount;
    public int YKDCount;
    public int PDDCount;
    public int FYDCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 在此处放置用户代码以初始化页面
            SetMyInfo();
            SetAffiche();
            SetOperForm();
        }
    }

    #region 显示公告的所有记录
    private void SetAffiche()
    {
        LitSysAffiche.Text = getHtml();
    }

    string getHtml()
    {
        StringBuilder Html = new StringBuilder();
        DataSet ds = Affiche.GetAllAffiches();
        if (ds != null)
        {
            int Count = ds.Tables[0].Rows.Count;
            int Nbr = 0;
            if (Count > 13)
            {
                Nbr = 13;
            }
            else
            {
                Nbr = Count;
            }
            Html.Append("<TABLE rules=\"rows\" cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" align=\"center\" border=\"0\" class=\"Flowtable\">");
            for (int i = 0; i < Nbr; i++)
            {
                DataRow Row = ds.Tables[0].Rows[i];
                string title = Row["Title"].ToString();
                string flag = Row["TypeNbr"].ToString();
                string guid = Row["Guid"].ToString();
                Html.Append("<TR>");
                Html.Append("<TD height=\"20\" width=\"5%\" class=\"SystemDashedTd\" vAlign=\"middle\"><IMG src=\"Images/down/ImWorkSmall.gif\">");
                Html.Append("</TD>");
                if (flag == "0")
                {
                    Html.Append("<TD height=\"20\" width=\"95%\" class=\"SystemDashedTd\" vAlign=\"center\" align=\"left\" style=\"PADDING-TOP: 4px\" nowrap=\"false\"><font style=\"COLOR: #94939B\">通告:" + title.Trim() + "</font>");
                }
                else
                {
                    Html.Append("<TD height=\"20\" width=\"95%\" class=\"SystemDashedTd\"  vAlign=\"center\" align=\"left\" style=\"PADDING-TOP: 4px\" nowrap=\"false\"><font style=\"COLOR: #94939B\">发文：</font><A title=\"" + title.Trim() + "\" target=\"_blank\" href=\"SiteBll/SysMan/AfficheView.aspx?GUID=" + guid + "\">" + title.Trim() + "</A>");
                }
                Html.Append("</TD>");
                Html.Append("</TR>");
            }
            if (Count > 13)
            {
                Html.Append("<TR>");
                Html.Append("<td colspan=\"2\" height=\"5\" width=\"100%\">");
                Html.Append("</td>");
                Html.Append("</TR>");
                Html.Append("<TR>");
                Html.Append("<td colspan=\"2\" vAlign=\"middle\" align=\"right\" width=\"100%\"><A href=\"SiteBll/SysMan/AfficheList.aspx\" target=\"frm\"><IMG src=\"Images/icon/More.gif\" border=\"0\"></A>");
                Html.Append("</td>");
                Html.Append("</TR>");
            }
            else
            {
                Html.Append("<TR>");
                Html.Append("<td colspan=\"2\" height=\"5\" width=\"100%\">");
                Html.Append("</td>");
                Html.Append("</TR>");
            }
            Html.Append("</TABLE>");
        }
        return Html.ToString();
    }
    #endregion

    #region 显示当前用户信息
    private void SetMyInfo()
    {
        StringBuilder Html = new StringBuilder();
        Html.Append("<TABLE cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" align=\"center\" border=\"0\">");
        Html.Append("<TR>");
        Html.Append("<TD><font style=\"COLOR: #94939B\">" + this.CUSER.UserName + "您好！今天是&nbsp;" + System.DateTime.Now.ToString("yyy年MM月dd日") + "&nbsp;" + changeDate(System.DateTime.Now.DayOfWeek.ToString()) + "</font>");
        Html.Append("</TD>");
        Html.Append("</TR>");
        Html.Append("</TABLE>");
        LitMyInfo.Text = Html.ToString();
    }

    private string changeDate(string day)
    {
        string[] english ={ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        string[] china ={ "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
        int j = 0;
        for (int i = 0; i <= 6; i++)
        {
            if (english[i] == day)
                j = i;
        }
        return china[j];
    }
    #endregion

    #region 显示当前系统中活动的单据
    private void SetOperForm()
    {
        this.WGDCount = WGDQuery.GetExeWGDCount();
        this.FYDCount = FYDQuery.GetExeFYDCount();
        this.XTZHCount = XTZHQuery.GetExeXTZHCount();
        this.PDDCount = PDParam.GetExePDDCount();
        this.YKDCount = ZKDQuery.GetExeZKDCount();
    }
    #endregion
    protected void lnk__SET_Param_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_Param)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE="+Server.UrlEncode("参数设置"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_SET_Store_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_Store)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("仓库定义"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_SET_Role_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_Role)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("角色定义"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnkUserRole_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_User)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("用户权限"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_Set_KH_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_KH)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("客户数据"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_exe_itembaseinfo_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.exe_itembaseinfo)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("物料基础信息"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_SET_HW_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_HW)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("货位设置"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_SysGG_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Publish_Affiche)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("系统公告"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_ICMAN_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.IC_FK||this.CUSER.USERFUNCTION.IC_GS || this.CUSER.USERFUNCTION.IC_ZT||this.CUSER.USERFUNCTION.IC_ZX)
        {
            Response.Redirect("SiteBll/ICMan/Index.aspx");
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_INDoor_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Car_In)
        {
            Response.Redirect("SiteBll/InDoor/Index.aspx?TYPE=" + Server.UrlEncode("进门管理"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_OutDoor_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Car_Out)
        {
            Response.Redirect("SiteBll/InDoor/Index.aspx?TYPE=" + Server.UrlEncode("出门管理"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QC_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Che_Qu)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("质检"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }

    protected void lnk_QR_Click(object sender, EventArgs e)
    {
        if (this.CUSER.WEIGTHQCFUNCTION.BHGYY)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("质量原因"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_BZ_Click(object sender, EventArgs e)
    {
        if (this.CUSER.WEIGTHQCFUNCTION.StandManage)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("标准维护"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_TXXX_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Che_Qu)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("特殊信息"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_JXX_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Che_Qu)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("卷信息查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_PDD)
        {
            Response.Redirect("SiteBll/PDMan/Index.aspx?TYPE=" + Server.UrlEncode("盘点粗盘单"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_CHOUP_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_PDD)
        {
            Response.Redirect("SiteBll/PDMan/Index.aspx?TYPE=" + Server.UrlEncode("盘点抽盘单"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_PDUP_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.UP_PDD)
        {
            Response.Redirect("SiteBll/PDMan/Index.aspx?TYPE=" + Server.UrlEncode("盘点数据上传"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_WGD)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("完工单查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QFYD_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_FYD)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("发运单查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_ZKD_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_ZKD)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("转库单查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QYWD_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_YWD)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("移位单查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QTH_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_THD)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("退货单查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QDP_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.exe_dpqry)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("待判品查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_QXT_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("形态转换"));
    }
    protected void lnk_RK_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("入库账簿"));
    }
    protected void lnk_CK_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("出库帐簿"));
    }
    protected void lnk_CKC_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("当前库存"));
    }
    protected void lnk_PC_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("批次管理"));
    }
    protected void lnk_HWView_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.EXE_HWVIEW)
        {
            Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("货位视图"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_FYList_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("发运清单"));
    }
    protected void lnk_HCDay_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("货场日报表"));
    }
    protected void lnk_KCList_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("库存明细表"));
    }
    protected void lnk_GXM_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("高线月盘存表"));
    }
    protected void lnk_MPC_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("月盘存明细表"));
    }
    protected void lnk_WC_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("工作量统计"));
    }
    protected void lnk_MovLog_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Data_MoveLog)
        {
            Response.Redirect("SiteBll/DataOpern/Index.aspx?TYPE=" + Server.UrlEncode("迁移日志浏览"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_DataReturn_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Data_Return)
        {
            Response.Redirect("SiteBll/DataOpern/Index.aspx?TYPE=" + Server.UrlEncode("数据回迁"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_TraLog_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/DataOpern/Index.aspx?TYPE=" + Server.UrlEncode("传输日志"));
    }
    protected void lnk_TraLogDel_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Log_Delete)
        {
            Response.Redirect("SiteBll/DataOpern/Index.aspx?TYPE=" + Server.UrlEncode("日志删除"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }

    protected void lnk_SET_Role_Click1(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.SET_Role)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("角色定义"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_EXE_QTRK_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.EXE_QTRK)
        {
            Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("其他入库"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_EXE_QTCK_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.ZD_QTCK)
        {
            Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("其他出库"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnkYYL_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("预约量查询"));
    }
    protected void lnk_Set_qp_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Syschqp)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("去皮设置"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_set_bzkz_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Sysbzbz)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("包装扣重"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void Lnk_Set_KCTW_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Syskctw)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("头尾材扣重"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void Lnk_Set_SX_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Sysbzbz)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("属性设置"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void Lnk_Set_HWGZ_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Syschqp)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("货位规则"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_SXPC_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_SXPC)
        {
            Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("深加工批次查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_fydqr_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.FYD_ZJQR)
        {
            Response.Redirect("SiteBll/CheckQu/Index.aspx?TYPE=" + Server.UrlEncode("签证装车确认"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_Set_door_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.doormanage)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("门岗维护"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void Lnk_Set_qzs_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.qzsmanage)
        {
            Response.Redirect("SiteBll/SysMan/Index.aspx?TYPE=" + Server.UrlEncode("签证室维护"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_fydqrsearch_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.fydqrsearch)
        {
            Response.Redirect("SiteBll/FormMan/Index.aspx?TYPE=" + Server.UrlEncode("发运单监控查询"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_PDD)
        {
            Response.Redirect("SiteBll/PDMan/Index.aspx?TYPE=" + Server.UrlEncode("自由盘点"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.Q_PDD)
        {
            Response.Redirect("SiteBll/PDMan/Index.aspx?TYPE=" + Server.UrlEncode("盘点参考"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }
    protected void lnk_KCJG_Click(object sender, EventArgs e)
    {
        if (this.CUSER.USERFUNCTION.EXE_HWVIEW)
        {
            Response.Redirect("SiteBll/StockMan/Index.aspx?TYPE=" + Server.UrlEncode("库存结构"));
        }
        else
            this.PrintfError("对不起，您没有权限！");
    }


    protected void lnk_CLHZ_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("产量信息汇总"));
    }
    protected void lnk_CLMX_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiteBll/Report/Index.aspx?TYPE=" + Server.UrlEncode("产量信息明细"));
    }
}
