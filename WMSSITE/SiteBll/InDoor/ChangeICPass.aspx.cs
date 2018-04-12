using System;
using System.Drawing;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL;
using System.Data;
using ACCTRUE.WMSBLL.Model;


public partial class SiteBll_InDoor_ChangeICPass : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(!string.IsNullOrEmpty(Request["ICNUM"]))
            {
                this.lblICNum.Text = Request["ICNUM"];
                ICParam parm=new ICParam();
                DataSet ds = parm.GetICInforbyID(Request["ICNUM"]);
                if(ds==null || ds.Tables.Count== 0|| ds.Tables[0].Rows.Count==0)
                {
                    this.PrintfError("不存在该IC卡！");
                    return;
                }
                else
                {
                    this.lblICNum.Text=Request["ICNUM"];
                    this.lblName.Text=ds.Tables[0].Rows[0]["KHName"].ToString();
                    this.txtPassword.Text="";
                    this.txtConfirm.Text="";
                }
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtPassword.Text=="1")
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "修改口令失败：口令不能为初始值！";
                return;
            }
            ICParam parm = new ICParam();
            parm.ChangeICPass(this.lblICNum.Text, this.txtPassword.Text);
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "修改口令成功！";
        }
        catch
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "修改口令失败:数据访问失败！";
        }

    }
}
