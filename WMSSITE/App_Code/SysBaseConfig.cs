using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// SysParams 的摘要说明
/// </summary>
public class SysBaseConfig
{
    public SysBaseConfig()
    {
    }
    /// <summary>
    /// 完工单查询页面编号
    /// </summary>
    public const int WGD_Q_PAGE = 1;
    /// <summary>
    /// 发运清单页面编号
    /// </summary>
    public const int FYQD = 2;
    /// <summary>
    /// 发运单查询页面编号
    /// </summary>
    public const int FYD_Q_PAGE = 3;
    /// <summary>
    /// 转库单查询页面编号
    /// </summary>
    public const int ZKD_Q_PAGE = 4;
    /// <summary>
    /// 移位单查询页面编号
    /// </summary>
    public const int YWD_Q_PAGE = 5;
    /// <summary>
    /// 退货单查询页面编号
    /// </summary>
    public const int THD_Q_PAGE = 6;
    /// <summary>
    /// 待判品查询
    /// </summary>
    public const int DPP_Q_PAGE = 7;
    /// <summary>
    /// 入库账簿查询
    /// </summary>
    public const int RKZB_Q_PAGE = 8;
    /// <summary>
    /// 出库账簿查询
    /// </summary>
    public const int CKZB_Q_PAGE = 9;
    /// <summary>
    /// 库存查询
    /// </summary>
    public const int KC_Q_PAGE = 10;
    /// <summary>
    /// 预约量查询
    /// </summary>
    public const int YYL_Q_PAGE = 11;

}
