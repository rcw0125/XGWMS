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
using System.Text;

public partial class SiteBll_SysMan_AfficheMan :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        if (!this.Page.IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["GUID"]))
                {
                    Affiche a = Affiche.GetAffiche(Request["GUID"]);
                    if (a != null)
                    {
                        this.m_txtTitle.Text = a.Title;
                    }
                    readFile(Request["GUID"]);
                }
            }
            catch
            {
                this.PrintfError("数据访问错误！");
                return;
            }
        }
    }
    /// <summary>
    /// 读取文件内容
    /// </summary>
    /// <param name="guid"></param>
    private void readFile(string guid)
    {
        string year = System.DateTime.Now.Date.Year.ToString();
        string path = Server.MapPath("../../AffFiles/" + year+"/" + guid + ".ini");
        StringBuilder sb = new StringBuilder();
        StreamReader read;
        string sLine = "";
        if (File.Exists(path))
        {
            read = File.OpenText(path);
            while (sLine != null)
            {
                sLine = read.ReadLine();
                if (sLine != null)
                    sb.Append(sLine);
            }
            read.Close();
        }
        if (sb.ToString() != "")
            this.FreeTextBox1.Text = sb.ToString();
    }
    protected void btnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.m_txtTitle.Text))
            {
                this.PrintfError("标题不能为空!");
                return;
            }

            Affiche aff = new Affiche();
            string des = FreeTextBox1.Text.ToString();
            string Guid = System.Guid.NewGuid().ToString();
            string Requestguid = this.Request["Guid"];
            if (!string.IsNullOrEmpty(Requestguid))
                Guid = Requestguid.ToString();
            aff.GUID = Guid;
            string year = System.DateTime.Now.Date.Year.ToString();
            string path = Server.MapPath("../../AffFiles/" + year + "/");
            if (!string.IsNullOrEmpty(des))
            {
                aff.TypeNbr = 1;//直接发布信息
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
                StreamWriter write;
                write = File.CreateText(path + "\\" + Guid + ".ini");
                write.Write(des);
                write.Close();
                aff.FileName = path + "\\" + Guid + ".ini";
            }
            else
                aff.TypeNbr = 0;
            aff.Title = this.m_txtTitle.Text;
            aff.PTime = DateTime.Now;
            aff.UserID = this.CUSER.UserID;
            aff.UserName = this.CUSER.UserName;
            if (!string.IsNullOrEmpty(Requestguid))
                aff.Update();
            else
                aff.Add();
            this.PrintfError("操作成功！");
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("AfficheList.aspx");
    }
}
