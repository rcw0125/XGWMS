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
using ExtAspNet;

public partial class SiteBll_PDMan_PDCKSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCK();
        }
    }
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            if (ds != null)
            {
                cmbck.DataValueField = "ckid";
                cmbck.DataTextField = "CKCKName";
                cmbck.DataSource = ds.Tables[0];
                cmbck.DataBind();
            }
        }
        catch
        {
            this.PrintfError("仓库下拉列表绑定出错");
            return;
        }
    }
    private void InitGrid()
    {
        ExtAspNet.BoundField boundField1 = new ExtAspNet.BoundField();
        boundField1.DataField = "hw";
        boundField1.HeaderText = "货位";
        grid.Columns.Add(boundField1);

        ExtAspNet.BoundField boundField2 = new ExtAspNet.BoundField();
        boundField2.DataField = "b";
        boundField2.HeaderText = "盘点类型";
        grid.Columns.Add(boundField2);

        ExtAspNet.BoundField boundField3 = new ExtAspNet.BoundField();
        boundField3.DataField = "pddh";
        boundField3.HeaderText = "盘点单号";
        grid.Columns.Add(boundField3);

        ExtAspNet.BoundField boundField4 = new ExtAspNet.BoundField();
        boundField4.DataField = "pdtype";
        boundField4.HeaderText = "实际盘点类型";
        grid.Columns.Add(boundField4);

        ExtAspNet.BoundField boundField5 = new ExtAspNet.BoundField();
        boundField5.DataField = "djzt";
        boundField5.HeaderText = "单据状态";
        grid.Columns.Add(boundField5);
        
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DataSet ds = null;
        string zdrqq = "";
        string zdrqz = "";
        if (ckzdrq.Checked)
        {
            zdrqq = dtprqq.Text;
            zdrqz = dtprqz.Text;
        }
        grid.Columns.Clear();
        InitGrid();
        ds = PDParam.GetPDCK(cmbck.SelectedValue,zdrqq,zdrqz);
        if (ds != null)
        {
            grid.DataSource = ds.Tables[0];
            grid.DataBind();
        }
        else
        {
            Alert.Show("没有结果！");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ClearContent(); 
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls"); 
        Response.ContentType = "application/excel"; 
        Response.Write(GetGridTableHtml(grid)); 
        Response.End(); 
    }
    private string GetGridTableHtml(Grid grid) 
    { 
        StringBuilder sb = new StringBuilder(); 
        sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">"); 
        sb.Append("<tr>"); 
        foreach (GridColumn column in grid.Columns) 
        { 
            sb.AppendFormat("<td>{0}</td>", column.HeaderText); 
        } 
        sb.Append("</tr>"); 
        foreach (GridRow row in grid.Rows) 
        { 
            sb.Append("<tr>"); 
            foreach (object value in row.Values) 
            { 
                string html = value.ToString(); 
                sb.AppendFormat("<td>{0}</td>", html); 
            } sb.Append("</tr>"); 
        } sb.Append("</table>"); 
        return sb.ToString(); }  



}
