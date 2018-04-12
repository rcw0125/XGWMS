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
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_CheckQu_QuMain : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpPCH.Attributes.Add("onchange", "ChangePCH();");
            this.drpSCX.Attributes.Add("onchange", "ChangeSCX();");
            this.userno.Value = this.CUSER.UserID;
            
        }
    }
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
           BindGridView();
        
    }
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {

    }
    private string GetSqlWhere()
    {
        string sqlWhere = "";
        //批次号
        if (!string.IsNullOrEmpty(hidPCH.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND PCH like '%" + hidPCH.Value + "%'";
            }
            else
                sqlWhere += " and PCH like '%" + hidPCH.Value + "%'";
        }
        
        //生产线
        if (!string.IsNullOrEmpty(this.hidSCX.Value))
        {
            string tempStr = "ACCTRUE";
            string strSCXID = WGDQuery.GetSCXID(this.hidSCX.Value.Trim());
            if (!string.IsNullOrEmpty(strSCXID))
                tempStr = strSCXID;
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                
                sqlWhere += " AND SCX"+(this.Drptj.SelectedValue.Trim())+"'" + tempStr + "'";
            }
            else
                sqlWhere += " and SCX "+this.Drptj.SelectedValue.Trim()+"'" + tempStr + "'";
        }
        if (this.chkyzj.Checked)
        {
            sqlWhere += " and zjbz=1 ";
        }
        else
            sqlWhere += " and zjbz=0 ";
        sqlWhere = " and wcbz=0 " + sqlWhere;
        return sqlWhere;
    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            //DataSet ds = null;
            
            DataSet ds = QuCheck.QueryWGD(sql);

            
            this.grvWGD.DataSource = ds;
            this.grvWGD.DataBind();
            //SetSumInfo();
            //this.SetDisplayList1.InitSetListControl(this.grvWGD, SysBaseConfig.WGD_Q_PAGE);
            //this.SetDisplayList1.SetGridViewDisplay(grvWGD);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    protected void grvWGD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick",
                        "SelectDataGridRow('grvWGD',this.rowIndex);");
        }
        //e.Row.Attributes.Add("onclick", "GetWGDItem()");
    }
}
