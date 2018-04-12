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

public partial class UserControl_SetDisplayList :AccCtrBase
{
    protected GridView grdView1;
    private int m_pageNbr;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        if (!this.IsPostBack)
        {
            if (Session[Config.Curren_User] == null)
            {
                return;
            }
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            string userId = user.UserID;
            initCheckList(userId,m_pageNbr);
            SetGridViewDisplay(grdView1);
        }
    }

    //初始化设置列表控件
    public void InitSetListControl(GridView gView, int pageNbr)
    {
        hidPageNbr.Value = pageNbr.ToString();
        int count = gView.Columns.Count;
        this.checkAll.Checked = true;
        m_pnlInfo.Controls.Clear();
        for (int i = 0; i < count; i++)
        {
            if (gView.Columns[i].HeaderText == "查看明细" || gView.Columns[i].HeaderText == "选择打印" || gView.Columns[i].HeaderText == "选择")
                continue;
            CheckBox box = new CheckBox();
            box.ID = "" + i;
            box.Checked = true;
            box.Text = gView.Columns[i].HeaderText;
            m_pnlInfo.Controls.Add(box);
        }
        if (Session[Config.Curren_User] == null)
        {
            return;
        }
        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
        string userId = user.UserID;
        initCheckList(userId, pageNbr);
        SetGridViewDisplay(gView);
    }
    //初始化checkBox选择框
    private void initCheckList(string userId,int pageNbr)
    {
        string values = "";
        string userID = "";
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User cUser = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            userID = cUser.UserID;
        }
        if (string.IsNullOrEmpty(this.hidShowList.Value))
        {
            ListViewModel mode = ListViewModel.GetListViewModelModel(userID, pageNbr);
            if (mode == null)
                return;
            this.drpHeadFont.SelectedValue = mode.HeadFont.ToString();
            this.drpListFont.SelectedValue = mode.ListFont.ToString();
            values = mode.ShowList;
            this.hidShowList.Value = mode.ShowList;
        }
        values = this.hidShowList.Value;
        checkAll.Checked = false;
        int count = 0;
        foreach (Control col in m_pnlInfo.Controls)
        {
            ((CheckBox)col).Checked = false;
            try
            {
                if (values.Trim() != "")
                {
                    string[] valuarray = values.Split(',');
                    foreach (string val in valuarray)
                    {
                        if (val == col.ID)
                        {
                            ((CheckBox)m_pnlInfo.FindControl(val)).Checked = true;
                            count++;
                            break;
                        }
                    }
                }
            }
            catch
            {
                continue;
            }
        }
        if (count == m_pnlInfo.Controls.Count)
            checkAll.Checked = true;//如果全部选中则全选
    }

    /// <summary>
    /// 设置GridView的显示
    /// </summary>
    /// <param name="grdView1"></param>
    public void SetGridViewDisplay(GridView gridView1)
    {
        if (gridView1 == null || gridView1.Columns.Count == 0)
            return;
        int count = gridView1.Columns.Count;
        for (int i = 0; i < count; i++)
        {
            if (grdView1.Columns[i].HeaderText == "查看明细" || grdView1.Columns[i].HeaderText=="选择打印" || grdView1.Columns[i].HeaderText=="选择")
                continue;
            gridView1.Columns[i].Visible = false;
        }
        string showInfo = this.getShowListInfo();
        //默认要显示的信息
        if (showInfo == "")
            return;
        string[] hihs = showInfo.Split(',');
        foreach (string his in hihs)
        {
            if (his == "")
                continue;
            gridView1.Columns[Convert.ToInt16(his)].Visible = true;
        }
        switch (this.drpHeadFont.SelectedValue)
        {
            case "9":
                gridView1.HeaderStyle.CssClass = "setFontHeader9";
                break;
            case "10":
                gridView1.HeaderStyle.CssClass = "setFontHeader10";
                break;
            case "11":
                gridView1.HeaderStyle.CssClass = "setFontHeader11";
                break;
        }
        switch (this.drpListFont.SelectedValue)
        {
            case "9":
                gridView1.RowStyle.CssClass = "setFont9";
                break;
            case "10":
                gridView1.RowStyle.CssClass = "setFont10";
                break;
            case "11":
                gridView1.RowStyle.CssClass = "setFont11";
                break;
        }
    }

    /// <summary>
    /// 得到要显示的列信息
    /// </summary>
    /// <returns></returns>
    private string getShowListInfo()
    {
        hidShowList.Value = ",";
        foreach (Control col in m_pnlInfo.Controls)
        {
            if (col is CheckBox)
            {
                if (((CheckBox)col).Checked)
                {
                    string id = ((CheckBox)col).ID;
                    hidShowList.Value += ((CheckBox)col).ID + ",";
                }
            }

        }
        string valus = hidShowList.Value;
        if (valus == "," || valus.Length < 3)
            hidShowList.Value = "";
        return hidShowList.Value.ToString();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SetGridViewDisplay(grdView1);
            saveModel();
            if (Session[Config.Curren_User] == null)
            {
                return;
            }   
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            string userId = user.UserID;
            initCheckList(userId, m_pageNbr);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    /*
		 * 保存自己的模板
		 */
    public void saveModel()
    {
        string userId = "";
        if (Session[Config.Curren_User] == null)
        {
            return;
        }
        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
        userId = user.UserID;

        string showList = ",";
        foreach (Control col in m_pnlInfo.Controls)
        {
            if (((CheckBox)col).Checked)
                showList += ((CheckBox)col).ID + ",";
        }
        this.hidShowList.Value = showList;
        ListViewModel listMode = ListViewModel.GetListViewModelModel(userId,m_pageNbr);
        if (listMode != null)
        {
            listMode.ShowList = showList;
            listMode.HeadFont = Convert.ToInt32(drpHeadFont.SelectedValue);
            listMode.ListFont = Convert.ToInt32(drpListFont.SelectedValue);
            listMode.Update();
            return;
        }
        listMode = new ListViewModel();
        listMode.PageNbr = m_pageNbr;
        listMode.ShowList = showList;
        listMode.HeadFont = Convert.ToInt32(drpHeadFont.SelectedValue);
        listMode.ListFont = Convert.ToInt32(drpListFont.SelectedValue);
        listMode.UserID = userId;
        listMode.Add();
    }

    /// <summary>
    /// 初始化控件
    /// </summary>
    public void SCInit(GridView grdView,int pageNbr)
    {
        m_pageNbr = pageNbr;
        if (grdView == null || grdView.Columns.Count == 0)
            return;
        this.grdView1 = grdView;
        int count = grdView.Columns.Count;
        for (int i = 0; i < count; i++)
        {
            if (grdView1.Columns[i].HeaderText.Trim() == "查看明细" || grdView1.Columns[i].HeaderText.Trim() == "选择打印" || grdView1.Columns[i].HeaderText == "选择")
                continue;
            CheckBox box = new CheckBox();
            box.ID = "" + i;
            box.Checked = true;
            box.Text = grdView.Columns[i].HeaderText;
            m_pnlInfo.Controls.Add(box);
        }
    }
}
