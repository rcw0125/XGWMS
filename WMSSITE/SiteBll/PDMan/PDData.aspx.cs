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
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;
using System.Xml;
using MSXML2;
using System.IO;
using System.Text;
public partial class SiteBll_PDMan_PDData : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.chkWLGL.Attributes.Add("onclick", "chk1()");
            //this.chkNoNCWL.Attributes.Add("onclick", "chk2()");
            this.btnDoSearch.Attributes.Add("onclick", "chooseCK()");
            this.btnPrint.Attributes.Add("onclick", "OpenPrintPDCYB()");
            this.btnShenhePDD.Attributes.Add("onclick", "if(!confirm('是否审核该盘点单据？')) return false");
            BindCK();
            if (!this.CUSER.USERFUNCTION.UP_PDD)
            {
                this.btndataUp.Enabled = false;
            }
        }
        if (this.chkWLGL.Checked)
        {
            this.chkNoNCWL.Enabled = false;
        }
        else
        {
            this.chkNoNCWL.Enabled = true;
        }
        if (this.chkNoNCWL.Checked)
        {
            this.chkWLGL.Enabled = false;
        }
        else
        {
            this.chkWLGL.Enabled = true;
        }
    }

    #region 绑定仓库下拉列表
    /// <summary>
    /// 绑定仓库下拉列表
    /// </summary>
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            if (ds != null)
            {
                this.drpCK.DataSource = ds;
                this.drpCK.DataTextField = "CKCKName";
                this.drpCK.ToolTip = "仓库";
                this.drpCK.DataValueField = "CKID";
                this.drpCK.DataBind();
                this.drpCK.Items.Insert(0, "请选择");
            }
        }
        catch
        {
            this.PrintfError("仓库下拉列表绑定出错");
            return;
        }
    }
    #endregion

    #region 点击进行查询
    protected void btnDoSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            if (string.IsNullOrEmpty(sqlWhere))
            {
                DataSet ds = PDParam.GetPDDNC("");
                if (ds != null)
                {
                    string YSDHfirst = ds.Tables[0].Rows[0]["YSDH"].ToString();
                    string CKID = ds.Tables[0].Rows[0]["CK"].ToString();
                    string PDRQ = ds.Tables[0].Rows[0]["PDRQ"].ToString();
                    string DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
                    BindGrid1(YSDHfirst);
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDHfirst, "", "", "", "", false);
                    this.hidYSDH.Value = YSDHfirst;
                    this.hidCKID.Value = CKID;
                }
            }
            else
            {
                DataSet ds = PDParam.GetPDDNC(sqlWhere);
                if (ds != null)
                {
                    string YSDH = ds.Tables[0].Rows[0]["YSDH"].ToString();
                    BindGrid1(YSDH);
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                    BinddrpDJH(YSDH);
                    this.hidYSDH.Value = YSDH;
                    this.hidCKID.Value = ds.Tables[0].Rows[0]["CK"].ToString();
                }
            }
        }
        catch
        {
            this.PrintfError("查询出错，请重试");
            return;
        }
    }
    #endregion

    #region 生成查询条件字符串
    /// <summary>
    /// 生成查询条件字符串
    /// </summary>
    /// <returns></returns>
    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(this.txtYSDH.Text))
        {
            sqlWhere += " YSDH = '" + this.txtYSDH.Text.Trim() + "'";
        }
        if ((!string.IsNullOrEmpty(this.drpCK.SelectedValue)) && (this.drpCK.SelectedValue != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and CK = '" + this.drpCK.SelectedValue.Trim() + "'";
            }
            else
            {
                sqlWhere += " CK = '" + this.drpCK.SelectedValue.Trim() + "'";
            }
        }
        return sqlWhere;
    }
    #endregion

    #region 绑定上方的Grid
    /// <summary>
    /// 绑定上方的Grid
    /// </summary>
    /// <param name="YSDH">原始单号</param>
    private void BindGrid1(string YSDH)
    {
        try
        {
            DataSet ds = PDParam.GetNCDetail(YSDH, "");
            this.grd1.DataSource = ds;
            this.grd1.DataBind();
        }
        catch
        {
            this.PrintfError("上方grid绑定出错");
            return;
        }
    }
    #endregion

    #region 绑定下方的Grid
    /// <summary>
    /// 绑定下方的Grid
    /// </summary>
    /// <param name="YSDH"></param>
    /// <param name="PDDH"></param>
    /// <param name="WLH"></param>
    /// <param name="PCH"></param>
    /// <param name="SX"></param>
    /// <param name="chkNoNCWLisChecked"></param>
    private void BindGrid2(string YSDH,string PDDH,string WLH,string PCH,string SX,bool chkNoNCWLisChecked)
    {
        try
        {
            DataSet ds = PDParam.GetPDDdetailDataUp(YSDH, PDDH, WLH, PCH, SX, chkNoNCWLisChecked, "");
            if (ds != null)
            {
                int ZCSL = 0;
                int SPSL = 0;
                double ZCZL = 0;
                double SPZL = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(dr["ZCSL"].ToString()))
                    {
                        ZCSL += Convert.ToInt32(dr["ZCSL"]);
                    }
                    if (!string.IsNullOrEmpty(dr["SPSL"].ToString()))
                    {
                        SPSL += Convert.ToInt32(dr["SPSL"]);
                    }
                    if (!string.IsNullOrEmpty(dr["ZCZL"].ToString()))
                    {
                        ZCZL += Convert.ToDouble(dr["ZCZL"]);
                    }
                    if (!string.IsNullOrEmpty(dr["SPZL"].ToString()))
                    {
                        SPZL += Convert.ToDouble(dr["SPZL"]);
                    }
                }
                this.lblzcsl.Text = ZCSL.ToString();
                this.lblspsl.Text = SPSL.ToString();
                this.lblzczl.Text = ZCZL.ToString();
                this.lblspzl.Text = SPZL.ToString();
            }
            this.grd2.DataSource = ds;
            this.grd2.DataBind();
        }
        catch
        {
            this.PrintfError("下方grid绑定出错");
            return;
        }
    }
    #endregion

    #region 绑定单据号下拉列表
    /// <summary>
    /// 绑定单据号下拉列表
    /// </summary>
    /// <param name="YSDH"></param>
    private void BinddrpDJH(string YSDH)
    {
        try
        {
            DataSet ds = PDParam.getPDDInfoByYSDH(YSDH);
            this.drpDJH.DataSource = ds;
            this.drpDJH.DataTextField = "PDDH";
            this.drpDJH.ToolTip = "单据号";
            this.drpDJH.DataValueField = "PDDH";
            this.drpDJH.DataBind();
            this.drpDJH.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("单据号下拉列表绑定出错");
            return;
        }
    }
    #endregion

    #region 点击进行物料关联查询
    protected void chkWLGL_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            string YSDH = this.txtYSDH.Text.Trim();
            if (this.chkWLGL.Checked)
            {
                DataSet dsYSDH = PDParam.GetNCDetail(YSDH, "");
                if (dsYSDH != null && dsYSDH.Tables[0].Rows.Count > 0)
                {
                    string WLH = dsYSDH.Tables[0].Rows[0]["barcode"].ToString();
                    string PCH = dsYSDH.Tables[0].Rows[0]["PCH"].ToString();
                    string SX = dsYSDH.Tables[0].Rows[0]["SX"].ToString();
                    if ((!string.IsNullOrEmpty(this.drpDJH.SelectedValue)) && (this.drpDJH.SelectedValue != "请选择"))
                    {
                        this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                        this.hidWLH.Value = WLH;
                        this.hidPCH.Value = PCH;
                        this.hidSX.Value = SX;
                        this.hidNoNcWL.Value = "false";
                        BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), WLH, PCH, SX, false);
                    }
                    else
                    {
                        this.hiddrpDJH.Value = "";
                        this.hidWLH.Value = WLH;
                        this.hidPCH.Value = PCH;
                        this.hidSX.Value = SX;
                        this.hidNoNcWL.Value = "false";
                        BindGrid2(YSDH, "", WLH, PCH, SX, false);
                    }
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.drpDJH.SelectedValue)) && (this.drpDJH.SelectedValue != "请选择"))
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", false);
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                }
            }
        }
        catch
        {
            this.PrintfError("进行物料关联查询时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击进行非NC物料查询
    protected void chkNoNCWL_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            string YSDH = this.txtYSDH.Text.Trim();
            if (this.chkNoNCWL.Checked)
            {
                if ((!string.IsNullOrEmpty(this.drpDJH.SelectedValue)) && (this.drpDJH.SelectedValue != "请选择"))
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "true";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", true);
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "true";
                    BindGrid2(YSDH, "", "", "", "", true);
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.drpDJH.SelectedValue)) && (this.drpDJH.SelectedValue != "请选择"))
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", false);
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                }
            }
        }
        catch
        {
            this.PrintfError("进行非NC物料关联查询时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 选择单据号下拉列表进行查询
    protected void drpDJH_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string YSDH = this.txtYSDH.Text.Trim();
            if ((!string.IsNullOrEmpty(this.drpDJH.SelectedValue)) && (this.drpDJH.SelectedValue != "请选择"))
            {
                if (this.chkWLGL.Checked)
                {
                    DataSet dsYSDH = PDParam.GetNCDetail(YSDH, "");
                    if (dsYSDH != null && dsYSDH.Tables[0].Rows.Count > 0)
                    {
                        string WLH = dsYSDH.Tables[0].Rows[0]["barcode"].ToString();
                        string PCH = dsYSDH.Tables[0].Rows[0]["PCH"].ToString();
                        string SX = dsYSDH.Tables[0].Rows[0]["SX"].ToString();
                        this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                        this.hidWLH.Value = WLH;
                        this.hidPCH.Value = PCH;
                        this.hidSX.Value = SX;
                        this.hidNoNcWL.Value = "false";
                        BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), WLH, PCH, SX, false);
                    }
                }
                else
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", false);
                }
                if (this.chkNoNCWL.Checked)
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "true";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", true);
                }
                else
                {
                    this.hiddrpDJH.Value = this.drpDJH.SelectedValue.Trim();
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, this.drpDJH.SelectedValue.Trim(), "", "", "", false);
                }
            }
            else
            {
                if (this.chkWLGL.Checked)
                {
                    DataSet dsYSDH = PDParam.GetNCDetail(YSDH, "");
                    if (dsYSDH != null && dsYSDH.Tables[0].Rows.Count > 0)
                    {
                        string WLH = dsYSDH.Tables[0].Rows[0]["barcode"].ToString();
                        string PCH = dsYSDH.Tables[0].Rows[0]["PCH"].ToString();
                        string SX = dsYSDH.Tables[0].Rows[0]["SX"].ToString();
                        this.hiddrpDJH.Value = "";
                        this.hidWLH.Value = WLH;
                        this.hidPCH.Value = PCH;
                        this.hidSX.Value = SX;
                        this.hidNoNcWL.Value = "false";
                        BindGrid2(YSDH, "", WLH, PCH, SX, false);
                    }
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                }
                if (this.chkNoNCWL.Checked)
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "true";
                    BindGrid2(YSDH, "", "", "", "", true);
                }
                else
                {
                    this.hiddrpDJH.Value = "";
                    this.hidWLH.Value = "";
                    this.hidPCH.Value = "";
                    this.hidSX.Value = "";
                    this.hidNoNcWL.Value = "false";
                    BindGrid2(YSDH, "", "", "", "", false);
                }
            }
        }
        catch
        {
            this.PrintfError("根据单据号进行查询时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击上传盘点单
    protected void btndataUp_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string YSDH = this.txtYSDH.Text.Trim();
            DataSet dsYSDH = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
            if (dsYSDH != null && dsYSDH.Tables[0].Rows.Count > 0)
            {
                string DJZT = dsYSDH.Tables[0].Rows[0]["DJZT"].ToString();
                if (DJZT != "已盘")
                {
                    this.PrintfError("只有审核过的单据才能上传");
                    return;
                }
            }
            else
            {
                this.PrintfError("没有可导出的数据");
                return;
            }
            string Fdownweb = Common.RFWEBSERVER;     // RF服务器地址         
            string Fuploadweb = Common.NCWERBSERVER;    //NC服务器地址        
            string wmsserver = Common.INTERFACESERVER;      //接口地址

            //string Fdownweb = "http://192.168.1.171/";//测试地址
            //string Fuploadweb = "http://localhost:800/WebSiteXML/Default.aspx";
            //string wmsserver = "http://192.168.1.171/";

            if ((string.IsNullOrEmpty(Fdownweb)) || (string.IsNullOrEmpty(Fuploadweb)))
            {
                this.PrintfError("服务器尚未正确设置");
            }
            else
            {
                XmlDocument docC = new XmlDocument();

                string filename = YSDH + ".xml";
                docC.Load(Fdownweb + filename);     //用XmlDocument类来下载Xml文件
                DOMDocument doc = new DOMDocument();
                XmlDocument resultdoc = new XmlDocument();
                string xml = docC.InnerXml;
                doc.loadXML(docC.InnerXml);     //将Xml文件赋给DOMDocument类型的doc
                IXMLDOMElement rootnode = doc.documentElement;
                bool XmlIsSended = PDParam.XmlIsSended(filename);
                if (XmlIsSended)
                {
                    rootnode.setAttribute("replace", "Y");
                    rootnode.setAttribute("proc", "update");
                }
                else
                {
                    rootnode.setAttribute("replace", "N");
                    rootnode.setAttribute("proc", "add");
                }
                string ArrSender = rootnode.getAttribute("sender").ToString();
                string Aroottag = rootnode.getAttribute("roottag").ToString();
                string ArrReceiver = rootnode.getAttribute("receiver").ToString();
                rootnode.setAttribute("sender", ArrReceiver);
                rootnode.setAttribute("receiver", ArrSender);
                DataSet dsNCDetail = PDParam.GetNCDetail(YSDH, "");
                string WLH;
                string PCH;
                string SX;
                string vfree1;
                string vfree2;
                string vfree3;
                string SPSL;
                string SPZL;
                IXMLDOMNode node;
                foreach (DataRow dr in dsNCDetail.Tables[0].Rows)
                {
                    WLH = dr["barcode"].ToString();
                    PCH = dr["PCH"].ToString();
                    SX = dr["SX"].ToString();
                    vfree1 = dr["vfree1"].ToString();
                    vfree2 = dr["vfree2"].ToString();
                    vfree3 = dr["vfree3"].ToString();
                    SPSL = dr["SPSL"].ToString();
                    SPZL = dr["SPZL"].ToString();
                    //修改实盘数量
                    node = rootnode.selectSingleNode(Aroottag + "/bill_body/item[cinventorycode/text()='" + WLH + "'][vbatchcode/text()='" + PCH + "'][cqualitylevelname/text()='" + SX + "'][vfree1/text()='" + vfree1 + "'][vfree2/text()='" + vfree2 + "'][vfree3/text()='" + vfree3 + "']/ncheckastnum");
                    if (node != null)
                    {
                        node.text = SPSL;
                    }
                    node = rootnode.selectSingleNode(Aroottag + "/bill_body/item[cinventorycode/text()='" + WLH + "'][vbatchcode/text()='" + PCH + "'][cqualitylevelname/text()='" + SX + "'][vfree1/text()='" + vfree1 + "'][vfree2/text()='" + vfree2 + "'][vfree3/text()='" + vfree3 + "']/nchecknum");
                    if (node != null)
                    {
                        node.text = SPZL;
                    }
                }
                //上传
                MSXML2.XMLHTTP MyHttp = new MSXML2.XMLHTTPClass();
                MyHttp.open("post", Fuploadweb, false, "", "");
                MyHttp.send(doc);

                int ComResult = 0;
                string Comdes = string.Empty;
                if (MyHttp.status == 200)
                {
                    resultdoc.LoadXml(MyHttp.responseText);
                    XmlElement resultRootnode = resultdoc.DocumentElement;
                    string Roottag = resultRootnode.GetAttribute("roottag");
                    XmlNode resultnode = resultRootnode.SelectSingleNode(Roottag + "/resultcode");
                    if (resultnode != null)
                    {
                        ComResult = Convert.ToInt32(resultnode.InnerText.Trim());
                    }
                    resultnode = resultRootnode.SelectSingleNode(Roottag + "/resultdescription");
                    if (resultnode != null)
                    {
                        Comdes = resultnode.InnerText.Trim();
                    }
                }
                string CKID = dsYSDH.Tables[0].Rows[0]["CK"].ToString();
                PDParam.AddXmlLog(CKID, filename, YSDH, Comdes, ComResult);
                if (ComResult == 1)
                {
                    this.PrintfError("传输成功");
                }
                else
                {
                    this.PrintfError("传输失败");
                }
                string apppathxml = "../../webinfo/xml";
                string pathName = Server.MapPath(apppathxml);
                if (!Directory.Exists(pathName))
                {
                    Directory.CreateDirectory(pathName);
                }
                doc.save(pathName + "/" + filename);
                SaveLocalXml(doc, Aroottag, YSDH);
            }
        }
        catch
        {
            this.PrintfError("上传出现错误，请确认服务器地址是否正确");
            return;
        }
    }
    #endregion

    #region 在本地保存Xml文件
    /// <summary>
    /// 在本地保存Xml文件
    /// </summary>
    /// <param name="doc"></param>
    /// <param name="Aroottag"></param>
    /// <param name="Aysdh"></param>
    private void SaveLocalXml(DOMDocument doc, string Aroottag, string Aysdh)
    {
        try
        {
            IXMLDOMElement rootnode = doc.documentElement;
            IXMLDOMNode modelNode = rootnode.selectNodes(Aroottag + "/bill_body/item")[0].cloneNode(true);
            IXMLDOMNode NewNode;
            IXMLDOMNode NewSubNode;
            IXMLDOMNode Parentnode;
            IXMLDOMNode body = rootnode.selectSingleNode(Aroottag + "/bill_body");
            for (int i = 0; i < body.childNodes.length; i++)
            {
                body.removeChild(body.childNodes[i]);
            }
            DataSet ds = PDParam.GetXmldata(Aysdh);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Parentnode = rootnode.selectSingleNode(Aroottag + "/bill_body");
                    if (i > 0)
                    {
                        modelNode = rootnode.selectNodes(Aroottag + "/bill_body/item")[0].cloneNode(true);
                    }
                    NewNode = Parentnode.appendChild(modelNode);
                    NewSubNode = NewNode.selectSingleNode("cinventorycode");
                    NewSubNode.text = ds.Tables[0].Rows[i]["wlh"].ToString();
                    NewSubNode = NewNode.selectSingleNode("vbatchcode");
                    NewSubNode.text = ds.Tables[0].Rows[i]["pch"].ToString();
                    NewSubNode = NewNode.selectSingleNode("vfree1");
                    NewSubNode.text = ds.Tables[0].Rows[i]["sx"].ToString();
                    NewSubNode = NewNode.selectSingleNode("naccountastnum");
                    NewSubNode.text = ds.Tables[0].Rows[i]["sumzcsl"].ToString();
                    NewSubNode = NewNode.selectSingleNode("naccountnum");
                    NewSubNode.text = ds.Tables[0].Rows[i]["sumzczl"].ToString();
                    NewSubNode = NewNode.selectSingleNode("ncheckastnum");
                    NewSubNode.text = ds.Tables[0].Rows[i]["sumspsl"].ToString();
                    NewSubNode = NewNode.selectSingleNode("nchecknum");
                    NewSubNode.text = ds.Tables[0].Rows[i]["sumspzl"].ToString();
                }
                string apppathxml = "../../webinfo/xml";
                string pathName = Server.MapPath(apppathxml);
                if (!Directory.Exists(pathName))
                {
                    Directory.CreateDirectory(pathName);
                }
                string filename = "Wms-" + Aysdh + ".xml";
                doc.save(pathName + "/" + filename);
            }
        }
        catch
        {
            this.PrintfError("本地保存Xml文件时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击对上方grd1排序
    protected void grd1_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidsort.Value))
            {
                this.hidsort.Value = "DESC";
            }
            else
            {
                if (this.hidsort.Value.Trim() == "DESC")
                {
                    this.hidsort.Value = "ASC";
                }
                else
                {
                    this.hidsort.Value = "DESC";
                }
            }
            string sortField = e.SortExpression.ToString();
            string sort = sortField + " " + this.hidsort.Value;
            DataSet dssort = PDParam.GetNCDetail(this.hidYSDH.Value.Trim(), sort);
            this.grd1.DataSource = dssort;
            this.grd1.DataBind();
        }
        catch
        {
            this.PrintfError("排序出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击对下方grd2排序
    protected void grd2_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidsort.Value))
            {
                this.hidsort.Value = "DESC";
            }
            else
            {
                if (this.hidsort.Value.Trim() == "DESC")
                {
                    this.hidsort.Value = "ASC";
                }
                else
                {
                    this.hidsort.Value = "DESC";
                }
            }
            string sortField = e.SortExpression.ToString();
            string sort = sortField + " " + this.hidsort.Value;
            this.hidStrSort.Value = sort;
            DataSet dssort;
            if (string.IsNullOrEmpty(this.hidNoNcWL.Value) || this.hidNoNcWL.Value.Trim() == "false")
            {
                dssort = PDParam.GetPDDdetailDataUp(this.hidYSDH.Value.Trim(), this.hiddrpDJH.Value.Trim(), this.hidWLH.Value.Trim(), this.hidPCH.Value.Trim(), this.hidSX.Value.Trim(), false, sort);
            }
            else
            {
                dssort = PDParam.GetPDDdetailDataUp(this.hidYSDH.Value.Trim(), this.hiddrpDJH.Value.Trim(), this.hidWLH.Value.Trim(), this.hidPCH.Value.Trim(), this.hidSX.Value.Trim(), true, sort);
            }
            this.grd2.DataSource = dssort;
            this.grd2.DataBind();
        }
        catch
        {
            this.PrintfError("排序出现错误，请重试");
            return;
        }
    }
    #endregion

    //#region 点击导出Excel
    //protected void btnExp_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(this.lblzcsl.Text) && this.lblzcsl.Text.Trim() != "0")
    //        {
    //            DataSet dsXls;
    //            if (string.IsNullOrEmpty(this.hidNoNcWL.Value) || this.hidNoNcWL.Value.Trim() == "false")
    //            {
    //                dsXls = PDParam.GetPDDdetailDataUpXls(this.hidYSDH.Value.Trim(), this.hiddrpDJH.Value.Trim(), this.hidWLH.Value.Trim(), this.hidPCH.Value.Trim(), this.hidSX.Value.Trim(), false, this.hidStrSort.Value.Trim());
    //            }
    //            else
    //            {
    //                dsXls = PDParam.GetPDDdetailDataUpXls(this.hidYSDH.Value.Trim(), this.hiddrpDJH.Value.Trim(), this.hidWLH.Value.Trim(), this.hidPCH.Value.Trim(), this.hidSX.Value.Trim(), true, this.hidStrSort.Value.Trim());
    //            }
    //            this.CreateExcel(dsXls.Tables[0], "PD.xls", dsXls.Tables[0].Rows.Count);
    //        }
    //    }
    //    catch
    //    {
    //        this.PrintfError("导出Excel时出现错误，请重试！");
    //        return;
    //    }
    //}
    //#endregion

    protected void btnPrintExp_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grd2.Rows.Count < 1)
        {
            this.PrintfError("没有要打印的记录！");
            return;
        }
        string url = CreateUrl();
        string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
        this.WriteClientJava(strClient);
    }

    private string CreateUrl()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PDDataExcel.aspx?TYPE=1");
        if (!string.IsNullOrEmpty(hidYSDH.Value))
        {
            sb.Append("&YSDH=" + hidYSDH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(hiddrpDJH.Value))
        {
            sb.Append("&PDDH=" + hiddrpDJH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(hidWLH.Value))
        {
            sb.Append("&WLH=" + hidWLH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(hidPCH.Value))
        {
            sb.Append("&PCH=" + hidPCH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(hidSX.Value))
        {
            sb.Append("&SX=" + hidSX.Value.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidNoNcWL.Value) && this.hidNoNcWL.Value.Trim() != "false")
        {
            sb.Append("&chkNoNCWLisChecked=true");
        }

        return sb.ToString();
    }

    protected void btnShenhePDD_Click(object sender, ImageClickEventArgs e)
    {
        string YSDH = this.txtYSDH.Text.Trim();
        if (!string.IsNullOrEmpty(YSDH))
        {
            if (this.CUSER.USERFUNCTION.SH_PDD == false)
            {
                this.PrintfError("您没有审核权限");
                return;
            }
            else
            {
                DataSet ds = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
                    if (DJZT == "已盘")
                    {
                        this.PrintfError("该单据已经被审核，不能再进行审核");
                        return;
                    }
                    if (DJZT == "待盘")
                    {
                        string result = PDParam.shenheDataUp(YSDH, this.CUSER.UserID);
                        if (result == "success")
                        {
                            this.PrintfError("审核成功");
                            BindGrid1(YSDH);
                            this.txtDJZT.Text = "已盘";
                        }
                        else
                        {
                            this.PrintfError("审核过程发生错误，请重试");
                            return;
                        }
                    }
                }
            }
        }
    }
}
