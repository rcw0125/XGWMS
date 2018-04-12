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
using ExtAspNet;
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_CheckQu_QuReason : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BandSX();
            BandSXReason();
            BandSXSearch();
        }
    }
    protected void BandSX()
    {
        DataSet ds = null;
        ds = SXSet.GetSXList("");
        SX.Items.Clear();
        SX.Items.Add("无", "无");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            SX.Items.Add(dr["SX"].ToString(), dr["SX"].ToString());
        }

    }
    protected void BandSXSearch()
    {
        DataSet ds = null;
        ds = SXSet.GetSXList("");

        SXSearch.Items.Clear();
        SXSearch.Items.Add("无", "无");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            SXSearch.Items.Add(dr["SX"].ToString(), dr["SX"].ToString());
        }

    }
    protected void BandSXReason()
    {
        string sqlstrf = "";
        if (SXSearch.SelectedValue != "")
        {
            sqlstrf = " and SX = '"+SXSearch.SelectedValue+"'";
            DataSet ds = ZLYY.GetZLYY(sqlstrf);
            GridSX.DataSource = ds.Tables[0];
            GridSX.DataBind();
        }
    }
    protected void BandGPReason()
    {
        string sqlstrf = "";
        DataSet ds = ZLYY.GetGPZLYY(sqlstrf);

        gridGP.DataSource = ds.Tables[0];
        gridGP.DataBind();
    }
    protected void ClearInput()
    {
        
        SX.SelectedValue = "无";
        Reason.Text = "";
        ysx.Text = "";
        yreason.Text = "";
    }
    protected void btnSpeClear_Click(object sender, EventArgs e)
    {
        ClearInput();
    }
    protected void btnGPClear_Click(object sender, EventArgs e)
    {
        GPZLYY.Text = "";
        yzlyy.Text = "";

    }
    protected void btnGPAdd_Click(object sender, EventArgs e)
    {
        GPZLYY.Text = "";
        yzlyy.Text = "";

    }
    protected void btnSpeAdd_Click(object sender, EventArgs e)
    {
        ClearInput();
    }
    protected void btnSpeSave_Click(object sender, EventArgs e)
    {
       
        if ((SX.SelectedValue == "无") || (Reason.Text.Trim() == ""))
        {
            Alert.Show("输入完整信息！");
            return;
        }
        string ret = ZLYY.SaveSXZLYY(SX.SelectedValue,Reason.Text,ysx.Text,yreason.Text);
        if (ret == "")
        {
            ClearInput();
            BandSXReason();
            Alert.Show("保存成功！");
        }
        else
        {
            Alert.Show("保存失败："+ret);
        }

        //string ret = HWGZ.SaveHWSet(fid.Text, PHSET.SelectedValue, PH.Text, GGSET.SelectedValue, GG.Text, PCHSET.SelectedValue, PCH.Text, SXSET.SelectedValue, SX.SelectedValue, PCINFOSET.SelectedValue, PCINFO.Text, YX.SelectedValue);
        //try
        //{
        //    int vvv = int.Parse(ret);
        //    ClearInput();
        //    BandHWGZ();
        //    Alert.Show("保存成功！");
        //}
        //catch (Exception ex)
        //{
        //    Alert.Show("保存失败：" + ret);
        //}
    }

    protected void btnGPSave_Click(object sender, EventArgs e)
    {

        if (GPZLYY.Text.Trim() == "")
        {
            Alert.Show("输入完整信息！");
            return;
        }
        string ret = ZLYY.saveGPZLYY(GPZLYY.Text, yzlyy.Text);

        if (ret == "")
        {
            GPZLYY.Text = "";
            yzlyy.Text = "";
            BandGPReason();
            Alert.Show("保存成功！");
        }
        else
        {
            Alert.Show("保存失败：" + ret);
        }
    }
    protected void btnSpeDel_Click(object sender, EventArgs e)
    {

        if (yreason.Text == "")
        {
            Alert.Show("请选择！");
            return;
        }
        string ret = ZLYY.delSXZLYY(ysx.Text,yreason.Text);
        if (ret != "")
        {
            Alert.Show("操作失败：" + ret);
        }
        else
        {
            ClearInput();
            BandSXReason();
            Alert.Show("操作成功！");
        }
    }

    protected void btnGPDel_Click(object sender, EventArgs e)
    {
        if (yzlyy.Text == "")
        {
            Alert.Show("请选择！");
            return;
        }
        string ret = ZLYY.delGPZLYY(yzlyy.Text);
        if (ret != "")
        {
            Alert.Show("操作失败：" + ret);
        }
        else
        {
            GPZLYY.Text = "";
            yzlyy.Text = "";
            BandGPReason();
            Alert.Show("操作成功！");
        }
    }
    protected void GridSX_RowClick(object sender, GridRowClickEventArgs e)
    {
        ExtAspNet.GridRow dr = GridSX.Rows[e.RowIndex];
        Reason.Text = dr.Values[1].ToString();
        SX.SelectedValue = dr.Values[0].ToString();
        ysx.Text = dr.Values[0].ToString();
        yreason.Text = dr.Values[1].ToString();
    }
    protected void gridGP_RowClick(object sender, GridRowClickEventArgs e)
    {
        ExtAspNet.GridRow dr = gridGP.Rows[e.RowIndex];
        GPZLYY.Text = dr.Values[0].ToString();
        yzlyy.Text = dr.Values[0].ToString();
    }

    protected void TabStrip1_TabIndexChanged(object sender, EventArgs e)
    {
        if (TabStrip1.ActiveTabIndex == 0)
            BandSXReason();
        else
            BandGPReason();
    }
    protected void SXSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BandSXReason();
    }
}
