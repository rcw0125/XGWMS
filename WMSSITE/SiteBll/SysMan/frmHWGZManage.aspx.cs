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

public partial class SiteBll_SysMan_frmHWGZManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BandSX();
            BandHWGZ();
        }
    }
    protected void BandHWGZ()
    {
        DataSet ds = null;
        ds = HWGZ.GetHWGZList();
        GridSX.DataSource = ds.Tables[0];
        GridSX.DataBind();
    }

    protected void BandSX()
    {
        DataSet ds = null;
        ds = SXSet.GetSXList("");
        SX.Items.Clear();
        SX.Items.Add("无","无");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
           
            SX.Items.Add(dr["SX"].ToString(), dr["SX"].ToString());
        }
        
    }
    protected void ClearInput()
    {
        PH.Text = "";
        GG.Text = "";
        PCH.Text = "";
        fid.Text = "";
        PCINFO.Text = "";
        WLH.Text = "";
        SX.SelectedValue = "无";
        PHSET.SelectedIndex = 0;
        GGSET.SelectedIndex = 0;
        PCHSET.SelectedIndex = 0;
        SXSET.SelectedIndex = 0;
        PCINFOSET.SelectedIndex = 0;
        WLHSET.SelectedIndex = 0;
        YX.SelectedIndex = 0;
        txtYXJ.Text = "";
    }
    protected void btnSpeClear_Click(object sender, EventArgs e)
    {
        ClearInput();
    }
    protected void btnSpeAdd_Click(object sender, EventArgs e)
    {
        ClearInput();
    }
    protected void btnSpeSave_Click(object sender, EventArgs e)
    {
        if ((PHSET.SelectedIndex == 3)&&(PH.Text.Trim()==""))
        {
            Alert.Show("设定特定牌号规则必须录入牌号！");
            return;
        }
        if((GGSET.SelectedIndex==3)&&(GG.Text.Trim()==""))
        {
            Alert.Show("设定特定规格规则必须录入规格！");
            return;
        }
        if ((PCHSET.SelectedIndex == 3) && (PCH.Text.Trim() == ""))
        {
            Alert.Show("设定特定批次规则必须录入批次！");
            return;
        }
        if ((SXSET.SelectedIndex == 3) && (SX.SelectedValue.Trim() == "无"))
        {
            Alert.Show("设定特定属性规则必须选择属性！");
            return;
        }
        if ((PCINFOSET.SelectedIndex == 3) && (PCINFO.Text.Trim() == ""))
        {
            Alert.Show("设定特定特殊信息规则必须填写特殊信息！");
            return;
        }
        if ((WLHSET.SelectedIndex == 3) && (WLH.Text.Trim() == ""))
        {
            Alert.Show("设定特定物料信息规则必须填写特殊信息！");
            return;
        }
        if (string.IsNullOrEmpty(this.txtYXJ.Text))
        {
            Alert.Show("优先级为必填项！");
            return;
        }
        string ret = HWGZ.SaveHWSet(fid.Text, PHSET.SelectedValue, PH.Text, GGSET.SelectedValue, GG.Text, PCHSET.SelectedValue, PCH.Text, SXSET.SelectedValue, SX.SelectedValue,PCINFOSET.SelectedValue,PCINFO.Text,WLHSET.SelectedValue,WLH.Text, YX.SelectedValue,this.txtYXJ.Text);
        try
        {
            int vvv = int.Parse(ret);
            ClearInput();
            BandHWGZ();
            Alert.Show("保存成功！");
        }
        catch(Exception ex)
        {
            Alert.Show("保存失败：" + ret);
        }
    }
    protected void btnSpeDel_Click(object sender, EventArgs e)
    {
        if (fid.Text == "")
        {
            Alert.Show("请选择");
            return;
        }
        string ret = HWGZ.DeleteHWSET(fid.Text);
        if (ret != "")
        {
            Alert.Show("操作失败：" + ret);
        }
        else
        {
            ClearInput();
            BandHWGZ();
            Alert.Show("操作成功！");
        }
    }
    protected void GridSX_RowClick(object sender, GridRowClickEventArgs e)
    {
        ExtAspNet.GridRow dr = GridSX.Rows[e.RowIndex];
        fid.Text = dr.Values[0].ToString();
        PHSET.SelectedValue = dr.Values[1].ToString();
        if (PHSET.SelectedValue == "3")
            PH.Enabled = true;
        else PH.Enabled = false;
        PH.Text = dr.Values[3].ToString();

        GGSET.SelectedValue = dr.Values[4].ToString();
        if (GGSET.SelectedValue == "3")
            GG.Enabled = true;
        else GG.Enabled = false;
        GG.Text = dr.Values[6].ToString();

        PCHSET.SelectedValue = dr.Values[7].ToString();
        if (PCHSET.SelectedValue == "3")
            PCH.Enabled = true;
        else PCH.Enabled = false;
        PCH.Text = dr.Values[9].ToString();
        SXSET.SelectedValue=dr.Values[10].ToString();
        if (SXSET.SelectedValue == "3")
        {
            SX.Enabled = true;
        }
        else SX.Enabled = false;
        SX.SelectedValue = dr.Values[12].ToString();

        PCINFOSET.SelectedValue = dr.Values[13].ToString();
        if (PCINFOSET.SelectedValue == "3")
            PCINFO.Enabled = true;
        else PCINFO.Enabled = false;
        PCINFO.Text = dr.Values[15].ToString();

        WLHSET.SelectedValue = dr.Values[16].ToString();
        if (WLHSET.SelectedValue == "3")
            WLH.Enabled = true;
        else WLH.Enabled = false;
        WLH.Text = dr.Values[18].ToString();

        YX.SelectedValue = dr.Values[19].ToString();
        this.txtYXJ.Text = dr.Values[20].ToString();
        
    }

    protected void PHSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PHSET.SelectedIndex == 3) PH.Enabled = true;
        else PH.Enabled = false;
    }
    protected void GGSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GGSET.SelectedIndex == 3) GG.Enabled = true;
        else GG.Enabled = false;
    }
    protected void PCHSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PCHSET.SelectedIndex == 3) PCH.Enabled = true;
        else PCH.Enabled = false;
    }
    protected void SXSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SXSET.SelectedIndex == 3) SX.Enabled = true;
        else SX.Enabled =false;
    }
    protected void PCINFOSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PCINFOSET.SelectedIndex == 3) PCINFO.Enabled = true;
        else PCINFO.Enabled = false;
    }
    protected void WLHSET_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (WLHSET.SelectedIndex == 3) WLH.Enabled = true;
        else 
            WLH.Enabled = false;
    }
}
