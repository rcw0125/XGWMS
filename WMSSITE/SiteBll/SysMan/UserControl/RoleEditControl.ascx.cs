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
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_SysMan_UserControl_RoleEditControl :AccCtrBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SetNewUI()
    {
        ClearUI();
    }

    //修改初始界面
    public void SetModifyUI(SysRole role)
    {
        this.txtRoleName.Text = role.RoleName;
        this.txtRoleName.Enabled = false;
        this.chk_Bar_BZ.Checked = role.Bar_BZ;
        this.chk_Bar_Print.Checked = role.Bar_Print;
        this.chk_BILLSENDLOG.Checked = role.BILLSENDLOG;
        this.chk_CANCELBILL.Checked = role.CANCELBILL;
        this.chk_Car_In.Checked = role.Car_In;
        this.chk_Car_Out.Checked = role.Car_Out;
        this.chk_CHE_QU.Checked = role.Che_Qu;
        this.chk_EXE_BARCK.Checked = role.EXE_BARCK;
        this.chk_EXE_BARPD.Checked = role.EXE_BARPD;
        this.chk_EXE_BARRK.Checked = role.EXE_BARRK;
        this.chk_EXE_CLOSE_ZKD.Checked = role.EXE_CLOSE_ZKD;
        this.chk_exe_delxtzhd.Checked = role.exe_delxtzhd;
        this.chk_exe_dpqry.Checked = role.exe_dpqry;
        this.chk_EXE_HWVIEW.Checked = role.EXE_HWVIEW;
        this.chk_exe_itembaseinfo.Checked = role.exe_itembaseinfo;
        this.chk_EXE_KCTZ.Checked = role.EXE_KCTZ;
        this.chk_EXE_PCHCK.Checked = role.EXE_PCHCK;
        this.chk_EXE_PCHPD.Checked = role.EXE_PCHPD;
        this.chk_EXE_PCHRK.Checked = role.EXE_PCHRK;
        this.chk_EXE_QCRK.Checked = role.EXE_QCRK;
        this.chk_EXE_QTCK.Checked = role.EXE_QTCK;
        this.chk_EXE_QTRK.Checked = role.EXE_QTRK;
        this.chk_EXE_SELL_CK.Checked = role.EXE_SELL_CK;
        this.chk_EXE_SHAPE.Checked = role.EXE_SHAPE;
        this.chk_EXE_TH.Checked = role.EXE_TH;
        this.chk_EXE_YW.Checked = role.EXE_YW;
        this.chk_EXE_ZYPD.Checked = role.EXE_ZYPD;
        this.chk_FYD_CancelFinish.Checked = role.FYD_CancelFinish;
        this.chk_FYD_UpdateCXH.Checked = role.FYD_UpdateCXH;
        this.chk_IC_FK.Checked = role.IC_FK;
        this.chk_IC_GS.Checked = role.IC_GS;
        this.chk_IC_ZT.Checked = role.IC_ZT;
        this.chk_IC_ZX.Checked = role.IC_ZX;
        this.chk_M_PDD.Checked = role.M_PDD;
        this.chk_Q_FYD.Checked = role.Q_FYD;
        this.chk_Q_KC.Checked = role.Q_KC;
        this.chk_Q_PDD.Checked = role.Q_PDD;
        this.chk_Q_THD.Checked = role.Q_THD;
        this.chk_Q_WGD.Checked = role.Q_WGD;
        this.chk_Q_YWD.Checked = role.Q_YWD;
        this.chk_Q_ZKD.Checked = role.Q_ZKD;
        this.chk_RESENDBILL.Checked = role.RESENDBILL;
        this.chk_SET_COMNC.Checked = role.SET_COMNC;
        this.chk_SET_HW.Checked = role.SET_HW;
        this.chk_Set_KH.Checked = role.SET_KH;
        this.chk_SET_Param.Checked = role.SET_Param;
        this.chk_SET_Role.Checked = role.SET_Role;
        this.chk_SET_SCX.Checked = role.SET_SCX;
        this.chk_SET_Store.Checked = role.SET_Store;
        this.chk_SET_User.Checked = role.SET_User;
        this.chk_SH_PDD.Checked = role.SH_PDD;
        this.chk_UP_PDD.Checked = role.UP_PDD;
        this.chk_zd_HBFYD.Checked = role.ZD_HBFYD;
        this.chk_zd_HBZKD.Checked = role.ZD_HBZKD;
        this.chk_ZD_QTCK.Checked = role.ZD_QTCK;
        this.chk_zd_ZYPD.Checked = role.ZD_ZYPD;
        this.chk_zd_ZZFYD.Checked = role.ZD_ZZFYD;
        this.chk_zd_ZZWGD.Checked = role.ZD_ZZWGD;
        this.chk_zd_ZZXTZHD.Checked = role.ZD_ZZXTZHD;
        this.chk_zd_ZZZKD.Checked = role.ZD_ZZZKD;
        this.chk_DataReturn.Checked = role.Data_return;
        this.chk_DataMoveLog.Checked = role.Data_MoveLog;
        this.chk_Log_Delete.Checked = role.Log_Delete;
        this.chk_Publish_Affiche.Checked = role.Publish_Affiche;
        this.chk_Login_History.Checked = role.Login_History;
        this.chk_SYSBZBZ.Checked = role.SYSBZBZ;
        this.chk_SYSCHQP.Checked = role.SYSCHQP;
        this.chk_Q_SXPC.Checked = role.Q_SXPC;
        this.chk_fyd_hgqr.Checked = role.FYD_HGQR;
        this.chk_fyd_zjqr.Checked = role.FYD_ZJQR;
        this.chk_fyd_mgqr.Checked = role.FYD_MGQR;
        this.chk_QZSManage.Checked = role.QZSManage;
        this.chk_FYD_QRSearch.Checked = role.FYD_QRSearch;
        this.chk_DoorManage.Checked = role.DoorManage;
    }
    //增加角色
    public bool AddNewRole()
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtRoleName.Text.Trim()))
            {
                this.PrintfError("角色名不能为空！");
                return false; ;
            }
            SysRole role = new SysRole();
            role.RoleName = this.txtRoleName.Text.Trim();
            if (role.Exists())
            {
                this.PrintfError("该角色在系统中已经存在！");
                this.txtRoleName.Text = "";
                this.txtRoleName.Focus();
                return false;
            }
            role.Bar_BZ = this.chk_Bar_BZ.Checked;
            role.Bar_Print = this.chk_Bar_Print.Checked;
            role.BILLSENDLOG = this.chk_BILLSENDLOG.Checked;
            role.CANCELBILL = this.chk_CANCELBILL.Checked;
            role.Car_In = this.chk_Car_In.Checked;
            role.Car_Out = this.chk_Car_Out.Checked;
            role.Che_Qu = this.chk_CHE_QU.Checked;
            role.EXE_BARCK = this.chk_EXE_BARCK.Checked;
            role.EXE_BARPD = this.chk_EXE_BARPD.Checked;
            role.EXE_BARRK = this.chk_EXE_BARRK.Checked;
            role.EXE_CLOSE_ZKD = this.chk_EXE_CLOSE_ZKD.Checked;
            role.exe_delxtzhd = this.chk_exe_delxtzhd.Checked;
            role.exe_dpqry = this.chk_exe_dpqry.Checked;
            role.EXE_HWVIEW = this.chk_EXE_HWVIEW.Checked;
            role.exe_itembaseinfo = this.chk_exe_itembaseinfo.Checked;
            role.EXE_KCTZ = this.chk_EXE_KCTZ.Checked;
            role.EXE_PCHCK = this.chk_EXE_PCHCK.Checked;
            role.EXE_PCHPD = this.chk_EXE_PCHPD.Checked;
            role.EXE_PCHRK = this.chk_EXE_PCHRK.Checked;
            role.EXE_QCRK = this.chk_EXE_QCRK.Checked;
            role.EXE_QTCK = this.chk_EXE_QTCK.Checked;
            role.EXE_QTRK = this.chk_EXE_QTRK.Checked;
            role.EXE_SELL_CK = this.chk_EXE_SELL_CK.Checked;
            role.EXE_SHAPE = this.chk_EXE_SHAPE.Checked;
            role.EXE_TH = this.chk_EXE_TH.Checked;
            role.EXE_YW = this.chk_EXE_YW.Checked;
            role.EXE_ZYPD = this.chk_EXE_ZYPD.Checked;
            role.FYD_CancelFinish = this.chk_FYD_CancelFinish.Checked;
            role.FYD_UpdateCXH = this.chk_FYD_UpdateCXH.Checked;
            role.IC_FK = this.chk_IC_FK.Checked;
            role.IC_GS = this.chk_IC_GS.Checked;
            role.IC_ZT = this.chk_IC_ZT.Checked;
            role.IC_ZX = this.chk_IC_ZX.Checked;
            role.M_PDD = this.chk_M_PDD.Checked;
            role.M_YWD = this.chk_Q_FYD.Checked;
            role.Q_FYD = this.chk_Q_FYD.Checked;
            role.Q_KC = this.chk_Q_KC.Checked;
            //role.Q_OutKC
            role.Q_PDD = this.chk_Q_PDD.Checked;
            role.Q_THD = this.chk_Q_THD.Checked;
            role.Q_WGD = this.chk_Q_WGD.Checked;
            role.Q_YWD = this.chk_Q_YWD.Checked;
            role.Q_ZKD = this.chk_Q_ZKD.Checked;
            role.RESENDBILL = this.chk_RESENDBILL.Checked;
            role.SET_COMNC = this.chk_SET_COMNC.Checked;
            role.SET_HW = this.chk_SET_HW.Checked;
            role.SET_KH = this.chk_Set_KH.Checked;
            role.SET_Param = this.chk_SET_Param.Checked;
            role.SET_Role = this.chk_SET_Role.Checked;
            role.SET_SCX = this.chk_SET_SCX.Checked;
            role.SET_Store = this.chk_SET_Store.Checked;
            role.SET_User = this.chk_SET_User.Checked;
            role.SH_PDD = this.chk_SH_PDD.Checked;
            role.UP_PDD = this.chk_UP_PDD.Checked;
            role.ZD_HBFYD = this.chk_zd_HBFYD.Checked;
            role.ZD_HBZKD = this.chk_zd_HBZKD.Checked;
            role.ZD_QTCK = this.chk_ZD_QTCK.Checked;
            role.ZD_ZYPD = this.chk_zd_ZYPD.Checked;
            role.ZD_ZZFYD = this.chk_zd_ZZFYD.Checked;
            role.ZD_ZZWGD = this.chk_zd_ZZWGD.Checked;
            role.ZD_ZZXTZHD = this.chk_zd_ZZXTZHD.Checked;
            role.ZD_ZZZKD = this.chk_zd_ZZZKD.Checked;
            role.Data_return = this.chk_DataReturn.Checked;
            role.Data_MoveLog = this.chk_DataMoveLog.Checked;
            role.Log_Delete = this.chk_Log_Delete.Checked;
            role.Publish_Affiche = this.chk_Publish_Affiche.Checked;
            role.Login_History = this.chk_Login_History.Checked;
            role.SYSBZBZ = this.chk_SYSBZBZ.Checked;
            role.SYSCHQP = this.chk_SYSCHQP.Checked;
            role.Q_SXPC = this.chk_Q_SXPC.Checked;
            role.FYD_HGQR = this.chk_fyd_hgqr.Checked;
            role.FYD_ZJQR = this.chk_fyd_zjqr.Checked;
            role.FYD_MGQR = this.chk_fyd_mgqr.Checked;
            role.DoorManage = this.chk_DoorManage.Checked;
            role.QZSManage = this.chk_QZSManage.Checked;
            role.FYD_QRSearch = this.chk_FYD_QRSearch.Checked;
            role.Add();
            this.PrintfError("新建角色成功！");
            return true;
        }
        catch
        {
            this.PrintfError("数据库操作失败，请重试！");
            return false;
        }
    }
    //清空UI
    public void ClearUI()
    {
        this.txtRoleName.Enabled = true;
        this.txtRoleName.Text = "";
        this.chk_Bar_BZ.Checked = false;
        this.chk_Bar_Print.Checked = false;
        this.chk_BILLSENDLOG.Checked = false;
        this.chk_CANCELBILL.Checked = false;
        this.chk_Car_In.Checked = false;
        this.chk_Car_Out.Checked = false;
        this.chk_CHE_QU.Checked = false;
        this.chk_EXE_BARCK.Checked = false;
        this.chk_EXE_BARPD.Checked = false;
        this.chk_EXE_BARRK.Checked = false;
        this.chk_EXE_CLOSE_ZKD.Checked = false;
        this.chk_exe_delxtzhd.Checked = false;
        this.chk_exe_dpqry.Checked = false;
        this.chk_EXE_HWVIEW.Checked = false;
        this.chk_exe_itembaseinfo.Checked = false;
        this.chk_EXE_KCTZ.Checked = false;
        this.chk_EXE_PCHCK.Checked = false;
        this.chk_EXE_PCHPD.Checked = false;
        this.chk_EXE_PCHRK.Checked = false;
        this.chk_EXE_QCRK.Checked = false;
        this.chk_EXE_QTCK.Checked = false;
        this.chk_EXE_QTRK.Checked = false;
        this.chk_EXE_SELL_CK.Checked = false;
        this.chk_EXE_SHAPE.Checked = false;
        this.chk_EXE_TH.Checked = false;
        this.chk_EXE_YW.Checked = false;
        this.chk_EXE_ZYPD.Checked = false;
        this.chk_FYD_CancelFinish.Checked = false;
        this.chk_FYD_UpdateCXH.Checked = false;
        this.chk_IC_FK.Checked = false;
        this.chk_IC_GS.Checked = false;
        this.chk_IC_ZT.Checked = false;
        this.chk_IC_ZX.Checked = false;
        this.chk_M_PDD.Checked = false;
        this.chk_Q_FYD.Checked = false;
        this.chk_Q_KC.Checked = false;
        this.chk_Q_PDD.Checked = false;
        this.chk_Q_THD.Checked = false;
        this.chk_Q_WGD.Checked = false;
        this.chk_Q_YWD.Checked = false;
        this.chk_Q_ZKD.Checked = false;
        this.chk_RESENDBILL.Checked = false;
        this.chk_SET_COMNC.Checked = false;
        this.chk_SET_HW.Checked = false;
        this.chk_Set_KH.Checked = false;
        this.chk_SET_Param.Checked = false;
        this.chk_SET_Role.Checked = false;
        this.chk_SET_SCX.Checked = false;
        this.chk_SET_Store.Checked = false;
        this.chk_SET_User.Checked = false;
        this.chk_SH_PDD.Checked = false;
        this.chk_UP_PDD.Checked = false;
        this.chk_zd_HBFYD.Checked = false;
        this.chk_zd_HBZKD.Checked = false;
        this.chk_ZD_QTCK.Checked = false;
        this.chk_zd_ZYPD.Checked = false;
        this.chk_zd_ZZFYD.Checked = false;
        this.chk_zd_ZZWGD.Checked = false;
        this.chk_zd_ZZXTZHD.Checked = false;
        this.chk_zd_ZZZKD.Checked = false;
        this.chk_DataReturn.Checked = false;
        this.chk_DataMoveLog.Checked = false;
        this.chk_Log_Delete.Checked = false;
        this.chk_Publish_Affiche.Checked = false;
        this.chk_Login_History.Checked = false;
        this.chk_SYSCHQP.Checked = false;
        this.chk_SYSBZBZ.Checked = false;
        this.chk_Q_SXPC.Checked = false;
        this.chk_fyd_mgqr.Checked = false;
        this.chk_fyd_hgqr.Checked = false;
        this.chk_fyd_zjqr.Checked = false;
        this.chk_DoorManage.Checked = false;
        this.chk_QZSManage.Checked = false;
        this.chk_FYD_QRSearch.Checked = false;
    }

    //更新角色
    public bool UpdateRole()
    {
        try
        {
            SysRole role = new SysRole();
            role.RoleName = this.txtRoleName.Text.Trim();
            role.Bar_BZ = this.chk_Bar_BZ.Checked;
            role.Bar_Print = this.chk_Bar_Print.Checked;
            role.BILLSENDLOG = this.chk_BILLSENDLOG.Checked;
            role.CANCELBILL = this.chk_CANCELBILL.Checked;
            role.Car_In = this.chk_Car_In.Checked;
            role.Car_Out = this.chk_Car_Out.Checked;
            role.Che_Qu = this.chk_CHE_QU.Checked;
            role.EXE_BARCK = this.chk_EXE_BARCK.Checked;
            role.EXE_BARPD = this.chk_EXE_BARPD.Checked;
            role.EXE_BARRK = this.chk_EXE_BARRK.Checked;
            role.EXE_CLOSE_ZKD = this.chk_EXE_CLOSE_ZKD.Checked;
            role.exe_delxtzhd = this.chk_exe_delxtzhd.Checked;
            role.exe_dpqry = this.chk_exe_dpqry.Checked;
            role.EXE_HWVIEW = this.chk_EXE_HWVIEW.Checked;
            role.exe_itembaseinfo = this.chk_exe_itembaseinfo.Checked;
            role.EXE_KCTZ = this.chk_EXE_KCTZ.Checked;
            role.EXE_PCHCK = this.chk_EXE_PCHCK.Checked;
            role.EXE_PCHPD = this.chk_EXE_PCHPD.Checked;
            role.EXE_PCHRK = this.chk_EXE_PCHRK.Checked;
            role.EXE_QCRK = this.chk_EXE_QCRK.Checked;
            role.EXE_QTCK = this.chk_EXE_QTCK.Checked;
            role.EXE_QTRK = this.chk_EXE_QTRK.Checked;
            role.EXE_SELL_CK = this.chk_EXE_SELL_CK.Checked;
            role.EXE_SHAPE = this.chk_EXE_SHAPE.Checked;
            role.EXE_TH = this.chk_EXE_TH.Checked;
            role.EXE_YW = this.chk_EXE_YW.Checked;
            role.EXE_ZYPD = this.chk_EXE_ZYPD.Checked;
            role.FYD_CancelFinish = this.chk_FYD_CancelFinish.Checked;
            role.FYD_UpdateCXH = this.chk_FYD_UpdateCXH.Checked;
            role.IC_FK = this.chk_IC_FK.Checked;
            role.IC_GS = this.chk_IC_GS.Checked;
            role.IC_ZT = this.chk_IC_ZT.Checked;
            role.IC_ZX = this.chk_IC_ZX.Checked;
            role.M_PDD = this.chk_M_PDD.Checked;
            role.M_YWD = this.chk_Q_FYD.Checked;
            role.Q_FYD = this.chk_Q_FYD.Checked;
            role.Q_KC = this.chk_Q_KC.Checked;
            //role.Q_OutKC
            role.Q_PDD = this.chk_Q_PDD.Checked;
            role.Q_THD = this.chk_Q_THD.Checked;
            role.Q_WGD = this.chk_Q_WGD.Checked;
            role.Q_YWD = this.chk_Q_YWD.Checked;
            role.Q_ZKD = this.chk_Q_ZKD.Checked;
            role.RESENDBILL = this.chk_RESENDBILL.Checked;
            role.SET_COMNC = this.chk_SET_COMNC.Checked;
            role.SET_HW = this.chk_SET_HW.Checked;
            role.SET_KH = this.chk_Set_KH.Checked;
            role.SET_Param = this.chk_SET_Param.Checked;
            role.SET_Role = this.chk_SET_Role.Checked;
            role.SET_SCX = this.chk_SET_SCX.Checked;
            role.SET_Store = this.chk_SET_Store.Checked;
            role.SET_User = this.chk_SET_User.Checked;
            role.SH_PDD = this.chk_SH_PDD.Checked;
            role.UP_PDD = this.chk_UP_PDD.Checked;
            role.ZD_HBFYD = this.chk_zd_HBFYD.Checked;
            role.ZD_HBZKD = this.chk_zd_HBZKD.Checked;
            role.ZD_QTCK = this.chk_ZD_QTCK.Checked;
            role.ZD_ZYPD = this.chk_zd_ZYPD.Checked;
            role.ZD_ZZFYD = this.chk_zd_ZZFYD.Checked;
            role.ZD_ZZWGD = this.chk_zd_ZZWGD.Checked;
            role.ZD_ZZXTZHD = this.chk_zd_ZZXTZHD.Checked;
            role.ZD_ZZZKD = this.chk_zd_ZZZKD.Checked;
            role.Data_return = this.chk_DataReturn.Checked;
            role.Data_MoveLog = this.chk_DataMoveLog.Checked;
            role.Log_Delete = this.chk_Log_Delete.Checked;
            role.Publish_Affiche = this.chk_Publish_Affiche.Checked;
            role.Login_History = this.chk_Login_History.Checked;
            role.SYSCHQP = this.chk_SYSCHQP.Checked;
            role.SYSBZBZ = this.chk_SYSBZBZ.Checked;
            role.Q_SXPC = this.chk_Q_SXPC.Checked;

            role.FYD_HGQR = this.chk_fyd_hgqr.Checked;
            role.FYD_ZJQR = this.chk_fyd_zjqr.Checked;
            role.FYD_MGQR = this.chk_fyd_mgqr.Checked;
            role.FYD_QRSearch = this.chk_FYD_QRSearch.Checked;
            role.DoorManage = this.chk_DoorManage.Checked;
            role.QZSManage = this.chk_QZSManage.Checked;
            role.Update();
            this.PrintfError("修改成功！");
            return true;
        }
        catch
        {
            this.PrintfError("数据库操作失败，请重试！");
            return false;
        }
    }
}
