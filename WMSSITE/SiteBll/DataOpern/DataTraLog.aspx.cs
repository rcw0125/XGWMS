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
using ACCTRUE.WMSBLL.ReportBll;
using ACCTRUE.WMSBLL.QueryBll;
using System.Text;
using ACCTRUE.WMSBLL.DataOper;
using System.Xml;
using MSXML2;
using System.IO;
using ACCTRUE.WMSBLL;

public partial class SiteBll_DataOpern_DataTraLog :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            BindCK();
            this.txtSTime.Text = DateTime.Now.ToShortDateString();
            this.txtETime.Text = DateTime.Now.ToShortDateString();
            this.btnHandLoad.Attributes.Add("onClick", "var hidIndex=document.getElementById('hidRowIndex'); if(hidIndex.value==null ||hidIndex.value.length==0) {alert('没有要重发的单据'); return false;} if(!confirm('是否手动重发？')) return false;");
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }
    //绑定仓库
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpCK.DataSource = ds;
            this.drpCK.DataBind();
            this.drpCK.Items.Insert(0, new ListItem("请选择", "0"));
            drpCK.SelectedIndex = 0;
            this.hidRowIndex.Value = "";
            //this.txtResult.Text = "";
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    private string GetWhere()
    {
        string strWhere="";
        if (this.drpCK.SelectedValue != "0")
            strWhere += " AND CK='" + this.drpCK.SelectedValue+"' ";
        if (this.drpType.SelectedValue != "0")
            strWhere += " AND DOCType LIKE '%" + this.drpType.SelectedValue+"%' ";
        if (!string.IsNullOrEmpty(this.txtCode.Text))
            strWhere += " AND DOCID LIKE '%" + this.txtCode.Text + "%'";
        if (!string.IsNullOrEmpty(this.txtSTime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtSTime.Text + "',21),ComTime)>=0";
        if(!string.IsNullOrEmpty(this.txtETime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtETime.Text + "',21),ComTime)<=0";
        return strWhere;
    }
    private string GetWhereError()
    {
        string strWhere = "";
        if (this.drpCK.SelectedValue != "0")
            strWhere += " AND CK='" + this.drpCK.SelectedValue + "' ";
        if (this.drpType.SelectedValue != "0")
            strWhere += " AND DOCType LIKE '%" + this.drpType.SelectedValue + "%' ";
        if (!string.IsNullOrEmpty(this.txtCode.Text))
            strWhere += " AND DOCID LIKE '%" + this.txtCode.Text + "%'";
        if (!string.IsNullOrEmpty(this.txtSTime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtSTime.Text + "',21),ComTime)>=0";
        if (!string.IsNullOrEmpty(this.txtETime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtETime.Text + "',21),ComTime)<=0";
        string strWhereError = "";
        strWhereError += strWhere+" and comresult<>1 " +
            "and docid not in(select distinct docid from WMS_Com_Log where comresult=1 "+strWhere+") ";
        return strWhereError;
    }

    private bool CheckUI()
    {
        try
        {
            Convert.ToDateTime(this.txtSTime.Text);
            Convert.ToDateTime(this.txtETime.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            this.herror.Text = "0";
            SetPageCountView();
            BindGridView();
        }
        else
            this.PrintfError("时间日期格式不对！");
    }

    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetWhere();
            int outCount;
            int pageCount = DayReport.GetLogPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void SetPageCountViewError()
    {
        try
        {
            string sqlWhere = GetWhereError();
            int outCount;
            int pageCount = DayReport.GetLogPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    
    private void BindGridView()
    {
        try
        {
            string sql = GetWhere();
            DataSet ds = DayReport.QueryLOG(sql, "", this.PageControl1.GetPageSize(), this.PageControl1.GetCurrPage());
            this.grdLog.DataSource = ds;
            this.grdLog.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindGridViewError()
    {
        try
        {
            string sql = GetWhereError();
            DataSet ds = DayReport.QueryLOG(sql, "", this.PageControl1.GetPageSize(), this.PageControl1.GetCurrPage());
            this.grdLog.DataSource = ds;
            this.grdLog.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }

    //选择分页控件时
    private void SelectPageSizeChange()
    {
        if (this.herror.Text == "0")
        {
            SetPageCountView();
            BindGridView();
        }
        else
        {
            SetPageCountViewError();
            BindGridViewError();
        }
        return;
    }
    protected void grdLog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strComDes = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ComDes"));

            StringBuilder toolTip = new StringBuilder();
            toolTip.Append("发送结果：" + strComDes);
            e.Row.Attributes["title"] = toolTip.ToString().Trim();
            int index = e.Row.RowIndex;
            e.Row.Attributes.Add("onClick", "SelectLogRow('grdLog',"+index+");");
            
        }
    }
    protected void btnResend_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            
            int rowIndex = Convert.ToInt32(this.hidRowIndex.Value.Trim());
            Label lblDoc = (Label)this.grdLog.Rows[rowIndex].Cells[0].FindControl("lblDocID");
            if (!this.CUSER.USERFUNCTION.RESENDBILL)
            {
                this.PrintfError("对不起，您没有重发单据的权限！");
                return;
            }
            if (string.IsNullOrEmpty(this.hidRowIndex.Value))
            {
                this.PrintfError("没有选择的单据！");
                return;
            }
            
            string docType = this.grdLog.Rows[rowIndex].Cells[3].Text.Trim();
            if (docType == "4R")
            {
                this.PrintfError("盘点单据的重发需在【盘点数据上传】模块处理!");
                return;
            }
            if (docType == "A4")
            {
                string strWGD = lblDoc.Text.Trim();
                DataSet ds = WGDQuery.GetWGDInfo(strWGD);
                if (ds == null || Convert.ToInt32(ds.Tables[0].Rows[0]["wcbz"]) != 3)
                {
                    this.PrintfError("该完工单尚未完成入库，不能重发");
                    return;
                }
            }
            
            string docID = lblDoc.Text.Trim();
            string ck = this.grdLog.Rows[rowIndex].Cells[2].Text.Split('|')[0].Trim();
            int result = DataOperClass.ResendData(docID, docType, this.CUSER.UserID, ck);
            if (result == -1)
            {
                this.PrintfError("重发失败，请重试！");
                return;
            }
            this.PrintfError("单据重发完毕！");
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    protected void btnHandLoad_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(this.hidRowIndex.Value);
            string[] fileNames =this.grdLog.Rows[rowIndex].Cells[6].Text.Split('\\');
            string fileName = fileNames[fileNames.Length - 1];
            string path = "../../Logerror/" + DateTime.Now.ToShortDateString(); ;
            if (!Directory.Exists(Server.MapPath(path)))
            {
                Directory.CreateDirectory(Server.MapPath(path));
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("http://" + Common.INTERFACESERVER + "/acctruewms/" + fileName);
            doc.Save(Server.MapPath(path) +"/"+ fileName);//保存本地文件

            MSXML2.XMLHTTP xmlhttp = new MSXML2.XMLHTTPClass();
            xmlhttp.open("post", Common.NCWERBSERVER, false, "", "");
            DOMDocument sDoc = new DOMDocument();
            sDoc.loadXML(doc.InnerXml);
            xmlhttp.send(sDoc);
            if (xmlhttp.status == 200)
            {
                string comResult = "";
                string comDes = "";
                doc.LoadXml(xmlhttp.responseText);
                XmlElement rootRoot = doc.DocumentElement;
                string rootTag = rootRoot.GetAttribute("roottag");
                XmlNode node=rootRoot.SelectSingleNode(rootTag + "/resultcode");
                if (node != null)
                    comResult = node.InnerText.Trim();
                XmlNode nodeDes = rootRoot.SelectSingleNode(rootTag + "/resultdescription");
                if (nodeDes != null)
                    comDes = nodeDes.InnerText.Trim();
                HtmlInputHidden hidCom = (HtmlInputHidden)this.grdLog.Rows[rowIndex].Cells[0].FindControl("hidComid");
                string comID = hidCom.Value;
                int uResult = DataOperClass.ReLoadLog(comResult, comDes, comID);
                if (uResult == -1)
                {
                    PrintfError("数据访问失败！");
                    return;
                }
                BindGridView();
                PrintfError("手工加载成功");
            }
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    protected void imgBtnError_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            this.herror.Text = "1";
            SetPageCountViewError();
            BindGridViewError();
        }
        else
            this.PrintfError("时间日期格式不对！");
    }
}
