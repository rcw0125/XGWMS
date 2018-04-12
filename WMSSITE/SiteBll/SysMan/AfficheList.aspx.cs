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
using System.IO;

public partial class SiteBll_SysMan_AfficheList :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindGrid();
    }
    private void BindGrid()
    {
        try
        {
            DataSet ds = Affiche.GetAllAffiches();
            this.grdAffList.DataSource = ds;
            this.grdAffList.DataBind();
        }
        catch
        {
            this.PrintfError("系统错误！");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("AfficheMan.aspx");
    }

    protected void grdAffList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnModify = (ImageButton)e.Row.FindControl("imgBtnModify");
            ImageButton btnDelete = (ImageButton)e.Row.FindControl("imgBtnDel");
            ImageButton btnChakan = (ImageButton)e.Row.FindControl("imgBtnCha");
            string guid = DataBinder.Eval(e.Row.DataItem, "Guid").ToString();
            string title = DataBinder.Eval(e.Row.DataItem, "Title").ToString();
            btnDelete.Attributes.Add("onClick", "if(!confirm('确定要删除吗？')) return false;");

            btnModify.CommandArgument = guid;
            btnDelete.CommandArgument = e.Row.RowIndex.ToString();
            btnChakan.CommandArgument = guid;
            if (!this.CUSER.USERFUNCTION.Publish_Affiche)
            {
                btnModify.Enabled = false;
                btnDelete.Enabled = false;
                btnChakan.Enabled = false;
            }
            else
            {
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
                btnChakan.Enabled = true;
            }
        }
    }
    protected void grdAffList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "imgBtnModify")
            {
                string guid = e.CommandArgument.ToString();
                Server.Transfer("AfficheMan.aspx?GUID=" + guid);
            }
            if (e.CommandName == "imgBtnDel")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string guid = ((HtmlInputHidden)this.grdAffList.Rows[rowIndex].Cells[6].FindControl("hidGuid")).Value.Trim();
                string fileName = ((HtmlInputHidden)this.grdAffList.Rows[rowIndex].Cells[6].FindControl("hidFileName")).Value.Trim();
                Affiche aff = new Affiche();
                aff.GUID = guid;
                aff.Delete();
                BindGrid();
                deleteFile(fileName);
                return;
            }
            if (e.CommandName == "imgBtnCha")
            {
                string guid = e.CommandArgument.ToString();
                string strJV = "window.open('AfficheView.aspx?GUID=" + guid + "','','toolbar=0,status=0,location=0,menubar=0,scrollbars=0');";
                this.WriteClientJava(strJV);
            }
        }
        catch
        {
            this.PrintfError("系统错误！");
            return;
        }
    }

    /// <summary>
    /// 删除操作
    /// </summary>
    /// <param name="guid"></param>
    void deleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
    }
}