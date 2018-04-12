using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;


namespace ACCTRUE.WMSBLL.Model
{
    public class ZYPdd
    {
        public static DataSet GetZDRY()
        {
            string strSql = "select distinct userid as PDUSER,username as PDUSERname from WMS_CHE_ZYPD a left join WMS_Pub_Users b "+
                            " on a.PDUSER=b.userid order by PDUSER";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(1) from WMS_CHE_ZYPD a left join wms_che_zypd_item b on a.pddh=b.pddh where 1=1 {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                double temp = Convert.ToDouble(result);
                allCount = Convert.ToInt32(temp);
                double pageCount = Math.Ceiling(temp / pageSize);
                return Convert.ToInt32(pageCount);
            }
            allCount = 0;
            return 0;
        }
        public static DataSet GetPDDItems(string pddh)
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "select * from WMS_CHE_ZYPD_ITEM where pddh='"+pddh+"'";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;
        }
        public static DataSet GetQueryFYD(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "a.pddh";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT a.*,c.wlh,c.wlmc,c.ph,c.gg,c.pch,c.zcsl,c.sx,c.sl,c.vfree1,c.vfree2,c.vfree3,pc,case a.statue when 0 then '新建' when 1 then  '执行' when 2 then '完成' end as statusms,case a.itype when 1 then '粗盘' when 2 then '抽盘' end as itypename,substring(hw,1,3) as ckid,b.username as pdusername,row_number() OVER (ORDER BY {0}) AS RowNumber from WMS_CHE_ZYPD " +
                "a left join WMS_Pub_Users b on a.PDUSER=b.userid left join wms_che_zypd_item c on a.pddh=c.pddh where 1=1 {1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            //string pagesql = "WITH TempDB AS (SELECT a.*,CAST(a.SJZL as numeric(10,3)) as zSJZL,CAST(a.JHZL as numeric(10,3)) as zJHZL,case a.yslb when 1 then '汽车发运' else '火车发运' end as Desc_yslb,case a.status when 0 then '未执行' when 1 then '已进厂' when 2 then '装车完毕' when 3 then '已出厂' when 4 then '已作废' else '正在装车' end as Desc_status,b.icnumber as ICNumber,row_number() OVER (ORDER BY {0}) AS RowNumber from wms_bms_pic_fyd a left outer join wms_pub_ic b on a.khbm=b.khid where 1=1{1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere += Sql_ZKD;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pagesql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
    }
}
