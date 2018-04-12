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

public partial class UserControl_PageControlPost : System.Web.UI.UserControl
{
    public delegate void DeleBindGridView();
    public delegate void PageChangeDel();
    public PageChangeDel PageSizeChange;
    public DeleBindGridView BindPageGrid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //设置显示图片
    public void SetPicUrl(string firstUrl, string preUrl, string nextUrl, string lastUrl, string goUrl)
    {
        this.imgBtnFirst.ImageUrl = firstUrl;
        this.imgBtnPrePage.ImageUrl = preUrl;
        this.imgBtnNextPage.ImageUrl = nextUrl;
        this.imgBtnLastPage.ImageUrl = lastUrl;
        this.imgBtnGo.ImageUrl = goUrl;
    }

    public void SetInitView(int pageCount, int fieldCount)
    {
        if (pageCount == 0)
        {
            this.imgBtnFirst.Enabled = false;
            this.imgBtnGo.Enabled = false;
            this.imgBtnLastPage.Enabled = false;
            this.imgBtnNextPage.Enabled = false;
            this.imgBtnPrePage.Enabled = false;
            this.ddlListCount.Enabled = false;
            this.m_count.Text = "0";
            this.m_page.Text = "0";
            this.m_topage.Text = "0";
        }
        else
        {
            if (pageCount == 1)
            {
                this.imgBtnFirst.Enabled = false;
                this.imgBtnGo.Enabled = false;
                this.imgBtnLastPage.Enabled = false;
                this.imgBtnNextPage.Enabled = false;
                this.imgBtnPrePage.Enabled = false;
                this.ddlPageCount.Items.Clear();
                ListItem item = new ListItem("1", "1");
                this.ddlPageCount.Items.Add(item);
                this.ddlPageCount.SelectedValue = "1";
                this.m_count.Text = fieldCount.ToString();
                this.m_page.Text = "1";
                this.m_topage.Text = "1";
            }
            else
            {
                this.imgBtnFirst.Enabled = false;
                this.imgBtnGo.Enabled = true;
                this.imgBtnLastPage.Enabled = true;
                this.imgBtnNextPage.Enabled = true;
                this.imgBtnPrePage.Enabled = false;
                this.ddlPageCount.Items.Clear();
                for (int i = 1; i <= pageCount; i++)
                {
                    ddlPageCount.Items.Add(i.ToString());
                }
                this.ddlPageCount.SelectedValue = "1";
                this.m_count.Text = fieldCount.ToString();
                this.m_page.Text = "1";
                this.m_topage.Text = pageCount.ToString();
            }
            this.ddlListCount.Enabled = true;
        }
    }
    //首页
    protected void imgBtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlListCount.Enabled = true;
        int pageCount = Convert.ToInt32(m_topage.Text);
        if (pageCount > 0)
        {
            this.imgBtnFirst.Enabled = false;
            this.imgBtnPrePage.Enabled = false;
            if (pageCount > 1)
            {
                this.imgBtnLastPage.Enabled = true;
                this.imgBtnNextPage.Enabled = true;
                this.imgBtnGo.Enabled = true;
            }
            m_page.Text = "1";
            this.ddlPageCount.SelectedValue = "1";
            if (this.BindPageGrid != null)
                BindPageGrid();
        }
    }
    //上一页
    protected void imgBtnPrePage_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlListCount.Enabled = true;
        int cPage = Convert.ToInt32(this.m_page.Text) - 1;
        this.m_page.Text = cPage.ToString();
        this.ddlPageCount.SelectedValue = cPage.ToString();
        this.imgBtnLastPage.Enabled = true;
        this.imgBtnNextPage.Enabled = true;
        if (cPage <= 1)
        {
            this.imgBtnPrePage.Enabled = false;
            this.imgBtnFirst.Enabled = false;
        }
        if (this.BindPageGrid != null)
            BindPageGrid();
    }
    //下一页
    protected void imgBtnNextPage_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlListCount.Enabled = true;
        int cPage = Convert.ToInt32(this.m_page.Text) + 1;
        this.m_page.Text = cPage.ToString();
        this.ddlPageCount.SelectedValue = cPage.ToString();
        this.imgBtnPrePage.Enabled = true;
        this.imgBtnFirst.Enabled = true;
        if (cPage == Convert.ToInt32(this.m_topage.Text))
        {
            this.imgBtnNextPage.Enabled = false;
            this.imgBtnLastPage.Enabled = false;
        }
        if (this.BindPageGrid != null)
            BindPageGrid();
    }
    //尾页
    protected void imgBtnLastPage_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlListCount.Enabled = true;
        this.ddlPageCount.SelectedValue = m_topage.Text;
        this.m_page.Text = m_topage.Text;
        this.imgBtnFirst.Enabled = true;
        this.imgBtnPrePage.Enabled = true;
        this.imgBtnLastPage.Enabled = false;
        this.imgBtnNextPage.Enabled = false;
        if (this.BindPageGrid != null)
            BindPageGrid();
    }
    //转到
    protected void imgBtnGo_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlListCount.Enabled = true;
        int cPage = Convert.ToInt32(this.ddlPageCount.SelectedValue);
        //还是当前页
        if (cPage == Convert.ToInt32(m_page.Text))
            return;
        else
        {
            this.m_page.Text = cPage.ToString();
            if (cPage == 1)
            {
                this.imgBtnFirst.Enabled = false;
                this.imgBtnPrePage.Enabled = false;
                this.imgBtnNextPage.Enabled = true;
                this.imgBtnLastPage.Enabled = true;
            }
            if (cPage == Convert.ToInt32(this.m_topage.Text))
            {
                this.imgBtnFirst.Enabled = true;
                this.imgBtnPrePage.Enabled = true;
                this.imgBtnNextPage.Enabled = false;
                this.imgBtnLastPage.Enabled = false;
            }
        }
        if (this.BindPageGrid != null)
            BindPageGrid();
    }
    //页面变化时
    protected void ddlListCount_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.PageSizeChange != null)
            PageSizeChange();
    }

    /// <summary>
    /// 获取页面大小
    /// </summary>
    /// <returns></returns>
    public int GetPageSize()
    {
        return Convert.ToInt32(this.ddlListCount.SelectedValue);
    }
    /// <summary>
    /// 获取当前页面
    /// </summary>
    /// <returns></returns>
    public int GetCurrPage()
    {
        return Convert.ToInt32(m_page.Text);
    }
    /// <summary>
    /// 获取总记录数
    /// </summary>
    /// <returns></returns>
    public int GetRecordCount()
    {
        return Convert.ToInt32(m_count.Text);
    }
}
