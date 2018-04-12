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
using System.Text;
//徐慧杰
public partial class SiteBll_InDoor_InDoor : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.txtICID.Attributes.Add("onkeydown", "getICNumber()");
            this.txtCPH.Attributes.Add("onkeydown", "enterCPH();");
            this.btnAllowInDoor.Attributes.Add("onclick", "if(!confirm('是否已打印提货小票？')) return false");
            this.txtICID.Focus();
        }
    }

    #region 点击查询查询出发运单
    //点击查询查询出发运单
    protected void btnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtICID.Text.ToString().Trim()) || string.IsNullOrEmpty(this.txtICNumber.Text.ToString().Trim()))
            {
                Response.Write("<script>window.alert('请输入IC卡号!')</script>");
                this.txtICID.Focus();
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtCPH.Text.Trim()))
                {
                    Response.Write("<script>window.alert('请输入车牌号!')</script>");
                    this.txtICID.Focus();
                    return;
                }
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
                int r=InitFYD();
                if (r == -2)
                {
                    this.WriteClientJava("showdialog('" + this.txtICID.Text + "');");
                    InitFYD();
                }
                this.txtICID.Focus();
            }
            this.hidCValue.Value = "";
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 查询发运单绑定主界面列表
    /// <summary>
    /// 查询发运单绑定主界面列表
    /// </summary>
    private int InitFYD()
    {
        string strWhere = "";
        if (!string.IsNullOrEmpty(this.txtICID.Text.Trim()))    //IC卡ID
        {
            strWhere = " and wms_pub_ic.ICID = '" + this.txtICID.Text.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(this.txtICNumber.Text.Trim()))    //IC卡卡号
        {
            strWhere += " and wms_pub_ic.ICNumber = '" + this.txtICNumber.Text.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(this.txtPassword.Text.Trim()))        //IC卡密码
        {
            strWhere += "and  wms_pub_ic.ICPass = '" + this.txtPassword.Text.Trim() + "'";
        }

        try
        {
            DataSet ds = InDoorParam.GetICDataSet(strWhere);
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                this.PrintfError("卡号或密码输入有误！");
                this.txtICID.Focus();
                return -1;
            }
            else
            {

                if (ds.Tables[0].Rows[0]["flag"].ToString() == "挂失")
                {
                    this.PrintfError("该卡已经被挂失！");
                    this.txtICID.Focus();
                    return -1;
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["ICPass"].ToString() == "1")
                    {
                        return -2;
                    }
                    string strWhereFYD;
                    string KHID = ds.Tables[0].Rows[0]["KHID"].ToString();
                    string KHLB = ds.Tables[0].Rows[0]["KHLB"].ToString();
                    if (KHLB == "0")
                    {
                        strWhereFYD = " Status in (0,1,2,5) ";
                    }
                    else
                    {
                        strWhereFYD = " KHBM = '" + KHID + "' and Status in (0,1,2,5)";
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

                    DataSet dsFYD = InDoorParam.GetFYDDataSet(strWhereFYD);
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
                }
            }
            return 0;
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return -1;
        }
    }
    #endregion

    #region 允许进门
    /// <summary>
    /// 允许进门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAllowInDoor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidCPH.Value))
            {
                this.PrintfError("没有选择发运单！");
                this.txtICID.Focus();
                return;
            }
            InDoorParam indoor = new InDoorParam();
            bool isIndoor = indoor.IsInDoor(this.hidCPH.Value.ToString().Trim());
            if (isIndoor == true)
            {
                Response.Write("<script>window.alert('此车号的车已经在厂内，不允许二次进厂！')</script>");
                this.txtICID.Focus();
                return;
            }
            else
            {
                bool timeInterval = indoor.isTimeAllow(this.hidCPH.Value);
                if (timeInterval == false)
                {
                    Response.Write("<script>window.alert('该车号的时间间隔太短，不能二次进门！')</script>");
                    this.txtICID.Focus();
                    return;
                }
                else
                {
                    string status = indoor.getStatus(this.hidCValue.Value, this.hidCK.Value, this.hidWLH.Value, this.hidSX.Value);
                    if (status != "0")
                    {
                        this.PrintfError("该发运单不存在或当前状态已不允许进门！");
                        this.txtICID.Focus();
                        return;
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(this.hidICID.Value))
                        {
                            this.PrintfError("出现错误，请重新刷卡进门");
                            return;
                        }
                        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                        if (indoor.Update(this.hidCValue.Value, 1, user.UserID, DateTime.Now))
                        {
                            this.PrintfError("该发运单现在可以进门了！");
                            indoor.setICIDindoor(this.hidICID.Value.Trim(), this.hidCValue.Value.Trim());
                            InDoorCheckFYD();
                            this.txtICID.Focus();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("进门失败，请重试！");
            return;
        }
    }
    #endregion

    #region 清空文本框并激活车牌号输入框
    /// <summary>
    /// 清空文本框并激活车牌号输入框
    /// </summary>
    private void ClearForm()
    {
        this.txtCPH.ReadOnly = false;
        this.txtCPH.Text = "";
        this.txtICID.Text = "";
        this.txtICNumber.Text = "";
        this.txtPassword.Text = "";
        this.hidCK.Value = "";
        this.hidCPH.Value = "";
        this.hidCValue.Value = "";
        this.hidSX.Value = "";
        this.hidWLH.Value = "";
        this.hidVisable.Value = "false";
    }
    protected void btnshuaka2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClearForm();
            this.GridView1.DataSource = null;
            this.GridView1.DataBind();
            this.txtICID.Focus();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("界面有错误，请重试！");
            return;
        }
    }
    #endregion

    #region 允许进门后查询发运单绑定主界面列表
    /// <summary>
    /// 允许进门后查询发运单绑定主界面列表
    /// </summary>
    private void InDoorCheckFYD()
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
            string strWhereFYD;
            string KHID = ds.Tables[0].Rows[0]["KHID"].ToString();
            string KHLB = ds.Tables[0].Rows[0]["KHLB"].ToString();
            if (KHLB == "0")
            {
                strWhereFYD = " Status in (0,1,2,5) ";
            }
            else
            {
                strWhereFYD = " KHBM = '" + KHID + "' and Status in (0,1,2,5)";
            }
            //string KHID = ds.Tables[0].Rows[0]["KHID"].ToString();
            //string strWhereFYD = " KHBM = '" + KHID + "' and Status in (0,1,2,5)";
            string CPH = this.hidCheckCPH.Value.Trim();
            if (string.IsNullOrEmpty(CPH))
            {
                strWhereFYD += " and yslb = '1' ";
            }
            else
            {
                strWhereFYD += " and cph like '%" + CPH + "%' and yslb = '1'";
            }

            DataSet dsFYD = InDoorParam.GetFYDDataSet(strWhereFYD);
            this.GridView1.DataSource = dsFYD;
            this.GridView1.DataBind();
        }
        catch
        { }
    }
    #endregion

    //protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (string.IsNullOrEmpty(this.hidCValue.Value))
    //    {
    //        this.PrintfError("没有选择要打印的发运单！");
    //        return;
    //    }
    //    string url = CreateUrl();
    //    string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
    //    this.WriteClientJava(strClient);
    //}

    private string CreateUrl()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PrintTHXPreport.aspx?TYPE=1");
        sb.Append("&FYDH=" + hidCValue.Value.Trim());        

        return sb.ToString();
    }
}
