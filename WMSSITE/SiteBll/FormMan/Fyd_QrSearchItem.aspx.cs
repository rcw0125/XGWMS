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
using ACCTRUE.WMSBLL.QueryBll;

public partial class SiteBll_FormMan_Fyd_QrSearchItem : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            if (!String.IsNullOrEmpty(Request["FYDH"]))
            {
                string strFYDH = Request["FYDH"];
                try
                {
                    DataSet ds = FYDQuery.GetFYDQRItems(strFYDH);
                    this.grvqr.DataSource = ds;
                    this.grvqr.DataBind();
                    DataSet dspic = FYDQuery.getfydPicPath(strFYDH);
                    this.imgdoorcph.ImageUrl = "../../images/Error.png";
                    this.imgdoorbody.ImageUrl = "../../images/Error.png";
                    this.imgqzscph.ImageUrl="../../images/Error.png";
                    this.imgqzsbody.ImageUrl = "../../images/Error.png";
                    string picpathper = "../../CapPic/";
                    if (dspic != null && dspic.Tables.Count > 0 && dspic.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dspic.Tables[0].Rows[0];
                        if (dr["doorcphissuccess"].ToString() == "Y" && dr["doorcphpicpath"].ToString()!="")
                        {
                            imgdoorcph.ImageUrl = picpathper + dr["doorcphpicpath"].ToString();
                            HyperLink3.NavigateUrl = "http://192.168.2.8/wmssite/CapPic/" + dr["doorcphpicpath"].ToString();
                        }
                        if (dr["doorbodyissuccess"].ToString() == "Y" && dr["doorbodypicpath"].ToString() != "")
                        {
                            imgdoorbody.ImageUrl = picpathper + dr["doorbodypicpath"].ToString();
                            HyperLink4.NavigateUrl = "http://192.168.2.8/wmssite/CapPic/" + dr["doorbodypicpath"].ToString();
                        }
                        if (dr["qzscphissuccess"].ToString() == "Y" && dr["qzscphpicpath"].ToString() != "")
                        {
                            imgqzscph.ImageUrl = picpathper + dr["qzscphpicpath"].ToString();
                            HyperLink1.NavigateUrl = "http://192.168.2.8/wmssite/CapPic/" + dr["qzscphpicpath"].ToString();
                        }
                        if (dr["qzsbodyissuccess"].ToString() == "Y" && dr["qzsbodypicpath"].ToString() != "")
                        {
                            imgqzsbody.ImageUrl = picpathper + dr["qzsbodypicpath"].ToString();
                            HyperLink2.NavigateUrl = "http://192.168.2.8/wmssite/CapPic/" + dr["qzsbodypicpath"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.PrintfError("数据访问失败！");
                    return;
                }
            }
        //}
    }
}
