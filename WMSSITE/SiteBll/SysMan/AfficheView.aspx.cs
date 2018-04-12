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

public partial class SiteBll_SysMan_AfficheView :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["GUID"]))
            {
                SetUI();
            }
        }
    }

    private void SetUI()
    {
        try
        {
            string guid = Request["GUID"];
            Affiche a = Affiche.GetAffiche(guid);
            this.lblTitle.Text = a.Title;
            this.lblUserName.Text = a.UserName;
            this.lblTime.Text = a.PTime.ToString();
            this.liContent.Text = ReadFile(a.FileName);
        }
        catch
        {
            PrintfError("数据访问错误！");
            return;
        }  
    }

    private string ReadFile(string fileName)
    {
        StringBuilder sb = new StringBuilder();
        if (File.Exists(fileName))
        {
            StreamReader read = File.OpenText(fileName);
            string sLine = "";
            while (sLine != null)
            {
                sLine = read.ReadLine();
                sb.Append(sLine);
            }
            read.Close();
        }
        return sb.ToString();
    }
}
