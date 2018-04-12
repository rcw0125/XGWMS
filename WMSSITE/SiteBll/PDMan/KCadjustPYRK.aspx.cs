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
public partial class SiteBll_PDMan_KCadjustPYRK : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.hidYSDH.Value = Request["YSDH"];
            Bind();
        }
    }

    #region 绑定主界面列表
    /// <summary>
    /// 绑定主界面列表
    /// </summary>
    private void Bind()
    {
        try
        {
            string YSDH = this.hidYSDH.Value.Trim();
            DataSet ds = PDParam.GetDSpyrk(YSDH);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.hidck.Value = ds.Tables[0].Rows[0]["ck"].ToString();
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击进行盘盈入库
    protected void btnPYRK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string YSDH = this.hidYSDH.Value.Trim();
            string pyrkbz = PDParam.GetPyrkbz(YSDH);
            if (pyrkbz == "2")
            {
                this.PrintfError("该盘点单已经处理过盘盈入库，不能重复操作");
                return;
            }
            if (CheckRkHW())
            {
                PDParam.Pyrk_Rkcz(YSDH, this.CUSER.UserID);
                this.PrintfError("盘盈入库完毕");
            }
        }
        catch
        {
            this.PrintfError("盘盈入库过程中出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 检查是否存在不能放入的货位
    /// <summary>
    /// 检查是否存在不能放入的货位
    /// </summary>
    /// <returns></returns>
    private bool CheckRkHW()
    {
        string YSDH = this.hidYSDH.Value.Trim();
        DataSet ds = PDParam.GetDSpyrk(YSDH);
        if (ds != null)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int result = PDParam.HWisOK(dr["barcode"].ToString(), dr["hw"].ToString(), dr["pch"].ToString(), dr["sx"].ToString());
                if (result == 0)
                {
                    this.PrintfError("物料：" + dr["barcode"].ToString() + "不能放到该货位");
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    #endregion
}
