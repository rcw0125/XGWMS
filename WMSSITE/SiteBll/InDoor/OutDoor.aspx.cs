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
using System.Net;
using System.Net.Sockets;
//徐慧杰
public partial class SiteBll_InDoor_OutDoor : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtICID.Attributes.Add("onkeydown", "getICNumber()");
            this.txtCPH.Attributes.Add("onkeydown", "enterCPH();");
            this.txtICID.Focus();
        }
    }

    #region 查询发运单
    protected void btnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtICID.Text.ToString().Trim()) && string.IsNullOrEmpty(this.txtICNumber.Text.ToString().Trim()))
            {
                Response.Write("<script>window.alert('请输入IC卡信息!')</script>");
                this.txtICID.Focus();
                return;
            }
            
                if (string.IsNullOrEmpty(this.txtCPH.Text.Trim()))
                {
                    Response.Write("<script>window.alert('请输入车牌号!')</script>");
                    this.txtICID.Focus();
                    return;
                }
           
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                Response.Write("<script>window.alert('请输入密码!')</script>");
                this.txtPassword.Focus();
                return;
            }
            else
            {
                this.hidPassword.Value = this.txtPassword.Text;
                this.hidCheckCPH.Value = this.txtCPH.Text;
                this.hidFYDH.Value = this.txtFYDH.Text;
                InitFYD();
                this.txtICID.Focus();
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("查询发运单出现错误，请重试！");
            return;
        }
    }
    #endregion

    #region 查询发运单绑定主界面列表
    /// <summary>
    /// 查询发运单绑定主界面列表
    /// </summary>
    private void InitFYD()
    {
        try
        {
            string strWhere = "";

            
            if (!string.IsNullOrEmpty(this.txtICID.Text.Trim()))
            {
                strWhere = " and wms_pub_ic.ICID = '" + this.txtICID.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(this.txtICNumber.Text.Trim()))
            {
                strWhere += " and wms_pub_ic.ICNumber = '" + this.txtICNumber.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                strWhere += "and  wms_pub_ic.ICPass = '" + this.txtPassword.Text.Trim() + "'";
            }

            DataSet ds = InDoorParam.GetICDataSet(strWhere);
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                this.PrintfError("卡号或密码输入有误！");
                this.txtICID.Focus();
                return;
            }
            else
            {
                if (ds.Tables[0].Rows[0]["flag"].ToString() == "挂失")
                {
                    this.PrintfError("该卡已经被挂失！");
                    this.txtICID.Focus();
                    return;
                }
                else
                {
                    string strWhereFYD;
                    string KHID = ds.Tables[0].Rows[0]["KHID"].ToString();
                    string KHLB = ds.Tables[0].Rows[0]["KHLB"].ToString();
                    //2011-11-13取消客户编码限制
                    //if (KHLB == "0")
                    //{
                    //    strWhereFYD = " Status = 2 ";
                    //}
                    //else
                    //{
                    //    strWhereFYD = " KHBM = '" + KHID + "' and Status = 2";//取消了客户编码限制，与旧系统保持一致
                    //}
                    strWhereFYD = " Status = 2";

                    string CPH = this.txtCPH.Text.Trim();
                    if (string.IsNullOrEmpty(this.txtCPH.Text.Trim()))
                    {
                        strWhereFYD += " and yslb = '1' ";
                    }
                    else
                    {
                        strWhereFYD += " and cph like '%" + CPH + "%' and yslb = '1'";
                    }
                    if (!string.IsNullOrEmpty(this.txtFYDH.Text.Trim()))
                    {
                        strWhereFYD += " and FYDH = '" + this.txtFYDH.Text.Trim() + "'";
                    }
                    strWhereFYD += " and ckrq>=convert(varchar(19),getdate()-7,21)";
                    DataSet dsFYD = InDoorParam.GetFYDDataSet(strWhereFYD);
                    bool ise = false;
                    if (dsFYD != null && dsFYD.Tables.Count > 0 && dsFYD.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsFYD.Tables[0].Rows)
                        {
                            if (dr["khbmh"].ToString() == KHID)
                            {
                                ise = true;
                                break;
                            }
                        }
                        if(KHID=="0")
                            ise = true;
                        if (!ise)
                        {
                            this.PrintfError("使用正确的IC卡！");
                            return;
                        }
                    }
                    
                    if (dsFYD != null && dsFYD.Tables[0].Rows.Count > 0)
                    {
                        this.lblFYDsum.Text = dsFYD.Tables[0].Rows.Count.ToString();
                    }
                    this.GridView1.DataSource = dsFYD;
                    this.GridView1.DataBind();
                    if (this.GridView1.Rows.Count < 1)
                    {
                        this.PrintfError("您没有可选的发运单！");
                    }
                    this.txtICID.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("查询发运单方法出现错误，请重试！");
            return;
        }
    }
    #endregion

    private IPAddress serverIP = null;
    private IPEndPoint serverFullAddr;
    private Socket sock;

    private bool sendcmd(string fydh)
    {
        try
        {
            serverIP = IPAddress.Parse("192.168.0.102");
            serverFullAddr = new IPEndPoint(serverIP, 1000);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(serverFullAddr);
            if (sock.Connected)
            {
                string vt = "1111";
                byte[] byteSend = System.Text.Encoding.UTF8.GetBytes(vt.ToCharArray());
                sock.Send(byteSend);
            }
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
        
    }

    #region 允许出门
    protected void btnAllowOutDoor_Click(object sender, ImageClickEventArgs e)
    {
        //ACCTRUE.WMSBLL.Model.User user1 = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
        //this.PrintfError(user1.UserID);
        //return;
        try
        {
            if (string.IsNullOrEmpty(this.hidCValue.Value))
            {
                this.PrintfError("没有选择发运单！");
                return;
            }
            else
            {
                InDoorParam indoor = new InDoorParam();
                ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                int lstatus = Status(this.hidCValue.Value.Trim());
                switch (lstatus)
                {
                    case 1:
                        this.PrintfError("正在装车，不能出门！");
                        this.txtICID.Focus();
                        return;
                    case 2:
                        if (SysParam.GetParamValue("ZHQROUTDOOR") == "1")
                        {
                            string retstr = QuCheck.checkfydOutqrdoor(this.hidCValue.Value.Trim());
                            if (retstr != "")
                            {
                                this.PrintfError(retstr);
                                return;
                            }
                        }
                        if (SysParam.getwzip(user.UserID)!="")
                        {
                            string pzsl = SysParam.GetParamValue("PZOUTDOOR");
                            if (SysParam.GetParamValue("PZOUTDOOR") != "-1")
                            {
                                int v = 0;
                                try
                                {
                                    v = int.Parse(pzsl);
                                }
                                catch (System.Exception ex)
                                {
                                    this.PrintfError("允许拍照校验参数错误，联系系统管理人员！");
                                    return;
                                }
                                string retstr = QuCheck.checkfydOutPicIsSuccess(this.hidCValue.Value.Trim(), v);//拍照失败次数是否大于允许的次数
                                if (retstr != "")
                                {
                                    this.PrintfError(retstr);
                                    return;
                                }
                            }
                        }
                        
                        
                        if (indoor.Update2(this.hidCValue.Value.Trim(), 3, user.UserID, DateTime.Now))
                        {
                            this.PrintfError("该发运单现在可以出门了！");
                            indoor.setICIDoutdoor(this.hidICID.Value.Trim(), this.hidCValue.Value.Trim());
                            this.txtICID.Focus();
                        }
                        break;
                    case 3:
                        this.WriteClientJava("window.showModalDialog('OutDoorOK.aspx?FYDH='+document.getElementById('hidCValue').value+'&ICID='+document.getElementById('hidICID').value,window,'dialogLeft=200;dialogTop=200;dialogWidth:350px; dialogHeight:150px;scroll:no; status:no; scrollbars:no; dialogHide:no; help:No;')");
                        //this.WriteClientJava("window.open('OutDoorOK.aspx?FYDH='+document.getElementById('hidCValue').value+'&ICID='+document.getElementById('hidICID').value, 'okorcancel', 'height=100, width=260, top=300, left=300, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')");
                        break;
                    case 4:
                        this.PrintfError("进门后没有执行，不能出门，如果要出门，装货员需要执行完成操作！");
                        this.txtICID.Focus();
                        return;
                    case 5:
                        this.PrintfError("该车辆已经出门！");
                        this.txtICID.Focus();
                        return;
                    case 6:
                        this.PrintfError("还没有进门！");
                        this.txtICID.Focus();
                        return;
                }
                OutDoorCheckFYD();
            }
        }
        catch(Exception ex)
        {
            this.PrintfError("出门时出现错误，请重试或退出重新登陆重试"+ex.Message);
            return;
        }
    }
    #endregion

    #region 根据发运单状态数据集返回不同的当前发运单的执行情况
    /// <summary>
    /// 根据发运单状态数据集返回不同的当前发运单的执行情况
    /// </summary>
    /// <param name="FYDH"></param>
    /// <returns></returns>
    public int Status(string FYDH)
    {
        DataSet statusDS = InDoorParam.StatusDS(FYDH);
        int jmzt = 0;
        int zczt = 0;
        int wczt = 0;
        int cmzt = 0;
        int inizt = 0;
        foreach (DataRow dr in statusDS.Tables[0].Rows)
        {
            {
                switch (dr[0].ToString())
                {
                    case "0":
                        inizt = 1;
                        return 6;
                        break;
                    case "1":
                        jmzt = 1;
                        return 4;//刚进门
                        break;
                    case "2":
                        wczt = 1;
                        break;
                    case "3":
                        cmzt = 1;
                        return 5;
                        break;
                    case "5":
                        zczt = 1;
                        return 1;
                        break;
                }
            }
        }
        //for (int i = 0; i < statusDS.Tables[0].Rows.Count; i++)
        
        if (zczt == 1)
        {
            return 1;//有正在装车
        }
        if (wczt == 1)
        {
            if (jmzt == 1)
            {
                return 3;//有进门没有装车的，也有完成状态的
            }
            return 2;//有完成状态的           
        }
        if (jmzt == 1)
        {
            return 4;//刚进门
        }
        if (cmzt == 1)
        {
            return 5;//出门状态
        }
        if (inizt == 1)
        {
            return 6;//没有进门状态
        }
        return 0;        
    }
    #endregion

    #region 允许出门后查询发运单绑定主界面列表
    /// <summary>
    /// 允许出门后查询发运单绑定主界面列表
    /// </summary>
    private void OutDoorCheckFYD()
    {
        try
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(this.hidICID.Value))
            {
                strWhere = " and wms_pub_ic.ICID = '" + this.hidICID.Value.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(this.hidICNumber.Value))
            {
                strWhere += " and wms_pub_ic.ICNumber = '" + this.hidICNumber.Value.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(this.hidPassword.Value))
            {
                strWhere += "and  wms_pub_ic.ICPass = '" + this.hidPassword.Value.Trim() + "'";
            }


            DataSet ds = InDoorParam.GetICDataSet(strWhere);
            string KHID = ds.Tables[0].Rows[0]["KHID"].ToString();
            string KHLB = ds.Tables[0].Rows[0]["KHLB"].ToString();
            string strWhereFYD;
            if (KHLB == "0")
            {
                strWhereFYD = " Status = 2 ";
            }
            else
            {
                strWhereFYD = " KHBM = '" + KHID + "' and Status = 2";//取消了客户编码限制，与旧系统保持一致
            }
            string CPH = this.txtCPH.Text.Trim();
            if (string.IsNullOrEmpty(CPH))
            {
                strWhereFYD += " and yslb = '1' ";
            }
            else
            {
                strWhereFYD += " and cph like '%" + CPH + "%' and yslb = '1'";
            }
            if (!string.IsNullOrEmpty(this.hidFYDH.Value))
            {
                strWhereFYD += " and FYDH = '" + this.hidFYDH.Value.Trim() + "'";
            }
            DataSet dsFYD = InDoorParam.GetFYDDataSet(strWhereFYD);
            this.GridView1.DataSource = dsFYD;
            this.GridView1.DataBind();
            this.txtICID.Focus();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("允许出门后重新加载出现错误，请重试！");
            return;
        }
    }
    #endregion
    protected void btn_camer_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(this.hidCValue.Value))
        {
            this.PrintfError("没有选择发运单！");
            return;
        }
        else
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
            //string userid = Config.Curuserid;
            string fydh = hidCValue.Value.Trim();
            string v = QuCheck.sendcmddoor(fydh, user.UserID);
            if (v != "")
            {
                PrintfError("拍照失败！" + v);
                return;
            }
            else PrintfError("拍照成功！");
        }
    }
    protected void btnSCXH_Click(object sender, ImageClickEventArgs e)
    {
        string zcsl = txtCXH.Text.Trim();
        if (string.IsNullOrEmpty(txtCXH.Text.Trim()))
        {
            this.PrintfError("请输入装车数量！");
            return;
        }
        try
        {
            int v = int.Parse(zcsl);
        }
        catch (System.Exception ex)
        {
            this.PrintfError("装车数量必须为整数！");
            return;
        }
        string fydh = hidCValue.Value.Trim();
        string result = QuCheck.checkfydOutqr(fydh);
        if (result != "")
        {
            this.PrintfError(result);
            return;
        }
        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
        result = QuCheck.zhqrdoor(fydh, user.UserID, int.Parse(zcsl));
        if (result != "")
        {
            this.PrintfError(result);
            return;
        }
        else
        {
            PrintfError("操作成功！");
            //BindGridView();
        }
    }
}

