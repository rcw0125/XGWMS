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
public partial class SiteBll_SysMan_SXSET : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // BandSx();
           // BandCZSX();
            BandPC();
            BandDJ();
            BandMRDJ();
        }
    }
    protected void BandSx()
    {
        DataSet ds = null;
        ds = SXSet.GetSXList("");
        GridSX.DataSource = ds.Tables[0];
        GridSX.DataBind();
    }
    private void BandCZSX()
    {
        DataSet ds = null;
        ds = SXSet.GetCZSXList("");
        GRIDCZSX.DataSource = ds.Tables[0];
        GRIDCZSX.DataBind();
    }
    private void BandPC()
    {
        this.PCSX.DataValueField = "SX";
        this.PCSX.DataTextField = "SX";
        DataSet ds = SXSet.GetSXList(" AND ISBATCH='Y'");
        PCSX.DataSource = ds;
        PCSX.DataBind();
        PCSX.Items.Insert(0, new ExtAspNet.ListItem("请选择", "0"));
        PCSX.SelectedIndex = 0;
    }
    private void BandDJ()
    {
        this.DJSX.DataValueField = "SX";
        this.DJSX.DataTextField = "SX";
        DataSet ds = SXSet.GetSXList(" AND ISKN='Y'");
        DJSX.DataSource = ds;
        DJSX.DataBind();
        DJSX.Items.Insert(0, new ExtAspNet.ListItem("请选择", "0"));
        DJSX.SelectedIndex = 0;
    }

    private void BandMRDJ()
    {
        this.MODJSX.DataValueField = "SX";
        this.MODJSX.DataTextField = "SX";
        DataSet ds = SXSet.GetSXList(" AND ISKN='Y'");
        MODJSX.DataSource = ds;
        MODJSX.DataBind();
        MODJSX.Items.Insert(0, new ExtAspNet.ListItem("请选择", "0"));
        MODJSX.SelectedIndex = 0;
    }
    protected void ClearInput()
    {
        SX.Text = "";
        SXName.Text = "";
        ISBATCH.SelectedIndex = 1;
        ISDEFAULTDJ.SelectedIndex = 0;
        ISKN.SelectedIndex = 1;
    }

    protected void ClearInputCZ()
    {
        this.PCSX.SelectedIndex=0;
        this.DJSX.SelectedIndex = 0;
        this.MODJSX.SelectedIndex = 0;
        this.TXTPX.Text = "0";
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
        if (SX.Text.Trim() == "")
        {
            Alert.Show("属性不能为空");
            return;
        }
        string ret = SXSet.SaveSXSet(SX.Text.Trim(), SXName.Text.Trim(), this.ISBATCH.SelectedValue.ToString(), this.ISDEFAULTDJ.SelectedValue.ToString(), this.ISKN.SelectedValue.ToString());
        if (ret != "")
        {
            Alert.Show("保存失败：" + ret);
        }
        else
        {
            ClearInput();
            BandSx();
            Alert.Show("保存成功！");
        }
    }
    protected void btnSpeDel_Click(object sender, EventArgs e)
    {
        int vv = GridSX.SelectedRowIndex;
        string sx = GridSX.Rows[vv].Values[0];
        string ret = SXSet.DeleteSxSet(sx);
        if (ret != "")
        {
            Alert.Show("操作失败：" + ret);
        }
        else
        {
            ClearInput();
            BandSx();
            Alert.Show("操作成功！");
        }
    }
    protected void GridSX_RowClick(object sender, GridRowClickEventArgs e)
    {
        ExtAspNet.GridRow dr = GridSX.Rows[e.RowIndex];
        SX.Text = dr.Values[0].ToString();
        SXName.Text = dr.Values[1].ToString();
        ISBATCH.SelectedValue = dr.Values[2].ToString();
        ISDEFAULTDJ.SelectedValue = dr.Values[3].ToString();
        ISKN.SelectedValue = dr.Values[4].ToString();
    }

    protected void GRIDCZSX_RowClick(object sender, GridRowClickEventArgs e)
    {
        ExtAspNet.GridRow dr = GRIDCZSX.Rows[e.RowIndex];
        PCSX.SelectedValue = dr.Values[0].ToString();
        MODJSX.SelectedValue = dr.Values[1].ToString();
        DJSX.SelectedValue = dr.Values[2].ToString();
        this.TXTPX.Text = dr.Values[3].ToString();
    }


    protected void btnSpeClearCZ_Click(object sender, EventArgs e)
    {
        ClearInputCZ();
    }

    protected void btnSpeSaveCZ_Click(object sender, EventArgs e)
    {
        if (PCSX.SelectedValue=="0")
        {
            Alert.Show("批次属性不能为空");
            return;
        }
        if (DJSX.SelectedValue == "0")
        {
            Alert.Show("单卷属性不能为空");
            return;
        }

        if (MODJSX.SelectedValue == "0")
        {
            Alert.Show("默认单卷属性不能为空");
            return;
        }
        DataSet ds = SXSet.GetCZSXList(" and PCSX='"+PCSX.SelectedValue.ToString()+"' and DJSX='"+DJSX.SelectedValue.ToString()+"' and MRDJSX='"+MODJSX.SelectedValue.ToString()+"'");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Alert.Show("批次属性、默认单卷属性、单卷属性对应配置已经存在！");
            return;
        }
        string ret = SXSet.SaveSXSetCZ(PCSX.SelectedValue.ToString(),MODJSX.SelectedValue.ToString(),DJSX.SelectedValue.ToString(),this.TXTPX.Text);
        if (ret != "")
        {
            Alert.Show("保存失败：" + ret);
        }
        else
        {
            ClearInputCZ();
            BandCZSX();
            Alert.Show("保存成功！");
        }
    }

    protected void btnSpeDelCZ_Click(object sender, EventArgs e)
    {
        int vv = GRIDCZSX.SelectedRowIndex;
        if (vv== -1)
        {
            Alert.Show("请选择要删除的称重属性！");
            return;
        }
        string pcsx = GRIDCZSX.Rows[vv].Values[0];
        string mrdj = GRIDCZSX.Rows[vv].Values[1];
        string djsx = GRIDCZSX.Rows[vv].Values[2];
        string ret = SXSet.DeleteSxSetCZ(pcsx, mrdj, djsx);
        if (ret != "")
        {
            Alert.Show("操作失败：" + ret);
        }
        else
        {
            ClearInputCZ();
            BandCZSX();
            Alert.Show("操作成功！");
        }
    }
    protected void btnQuery_TabIndexChanged(object sender, EventArgs e)
    {
        if (this.tabStrip.ActiveTabIndex == 0)
            BandSx();
        if (this.tabStrip.ActiveTabIndex == 1)
            BandCZSX();
    }
}
