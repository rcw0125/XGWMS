using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.ReportBll
{
    public class DayReport
    {
        //获取日报表
        public static DataSet GetDayReport(string store, string date, string orderBy)
        {
            int year = Convert.ToDateTime(date).Year;
            int month = Convert.ToDateTime(date).Month;
            string startDate = year.ToString() + "-" + month.ToString() + "-" + "1";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select phgglist.ck,phgglist.ph,phgglist.gg,(isnull(rkljphgg.rkljjs,0)-isnull(ckljphgg.ckljjs,0)) as qcsl,(isnull(rkljphgg.rkljzl,0)-isnull(ckljphgg.ckljzl,0)) as qczl,");
            strSql.Append("isnull(rkrphgg.rkrjs,0) as rkrjs,isnull(rkrphgg.rkrzl,0) as rkrzl,isnull(rkyljphgg.rkyljjs,0) as rkyljjs,isnull(rkyljphgg.rkyljzl,0) as rkyljzl,isnull(ckrphgg.ckrjs,0) as ckrjs,isnull(ckrphgg.ckrzl,0) as ckrzl,isnull(ckyljphgg.ckyljjs,0) as ckyljjs,isnull(ckyljphgg.ckyljzl,0) as ckyljzl,isnull(view_kc_day_phgg_clsx.kcsl,0) as kcsl,isnull(view_kc_day_phgg_clsx.kczl,0) as kczl,");
            strSql.Append("isnull(view_kc_day_phgg_clsx.clsl,0) as clsl,isnull(view_kc_day_phgg_clsx.clzl,0) as clzl,isnull(view_kc_day_phgg_clsx.bhgsl,0)  as bhgsl,isnull(view_kc_day_phgg_clsx.dpsl,0) as dpsl,isnull(view_kc_day_phgg_clsx.xysl,0) as xysl ");
            strSql.Append("from (select distinct ck,ph,gg from wms_rev_doc where ck='");
            strSql.Append(store);
            strSql.Append("') as phgglist left join (select ck,ph,gg,sum(sl) as rkljjs,sum(zl) as rkljzl from wms_rev_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,rktime,'");
            strSql.Append(startDate);
            strSql.Append("')>0 group by ck,ph,gg ) as rkljphgg on phgglist.ck=rkljphgg.ck and phgglist.ph=rkljphgg.ph and phgglist.gg=rkljphgg.gg ");
            strSql.Append("left join (select ck,ph,gg,sum(sl) as ckljjs,sum(zl) as ckljzl from wms_pic_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,cktime,'");
            strSql.Append(startDate);
            strSql.Append("')>0 group by ck,ph,gg ) as ckljphgg on phgglist.ck=ckljphgg.ck and phgglist.ph=ckljphgg.ph and phgglist.gg=ckljphgg.gg ");
            strSql.Append("left join (select ck,ph,gg,sum(sl) as rkrjs,sum(zl) as rkrzl from wms_rev_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,rktime,'");
            strSql.Append(date);
            strSql.Append("')=0 group by ck,ph,gg) as rkrphgg on phgglist.ck=rkrphgg.ck and phgglist.ph=rkrphgg.ph and phgglist.gg=rkrphgg.gg ");
            strSql.Append("left join (select ck,ph,gg,sum(sl) as rkyljjs,sum(zl) as rkyljzl from wms_rev_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,rktime,'");
            strSql.Append(date);
            strSql.Append("')>=0 and datediff(day,rktime,'");
            strSql.Append(startDate);
            strSql.Append("')<=0 group by ck,ph,gg) as rkyljphgg on phgglist.ck=rkyljphgg.ck and phgglist.ph=rkyljphgg.ph and phgglist.gg=rkyljphgg.gg ");
            strSql.Append("left join (select ck,ph,gg,sum(sl) as ckrjs,sum(zl) as ckrzl from wms_pic_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,cktime,'");
            strSql.Append(date);
            strSql.Append("')=0 and cktype='销售出库' group by ck,ph,gg) as ckrphgg on phgglist.ck=ckrphgg.ck and phgglist.ph=ckrphgg.ph and phgglist.gg=ckrphgg.gg ");
            strSql.Append("left join (select ck,ph,gg,sum(sl) as ckyljjs,sum(zl) as ckyljzl from wms_pic_doc where ck='");
            strSql.Append(store);
            strSql.Append("' and datediff(day,cktime,'");
            strSql.Append(date);
            strSql.Append("')>=0 and datediff(day,cktime,'");
            strSql.Append(startDate);
            strSql.Append("')<=0 and cktype='销售出库' group by ck,ph,gg) as ckyljphgg on phgglist.ck=ckyljphgg.ck and phgglist.ph=ckyljphgg.ph and phgglist.gg=ckyljphgg.gg ");
            strSql.Append("left join view_kc_day_phgg_clsx on phgglist.ck=view_kc_day_phgg_clsx.ck and phgglist.ph=view_kc_day_phgg_clsx.ph and phgglist.gg=view_kc_day_phgg_clsx.gg ");
            strSql.Append("where phgglist.ck='");
            strSql.Append(store);
            strSql.Append("'");
            if (!string.IsNullOrEmpty(orderBy))
            {
                strSql.Append(" order by phgglist.");
                strSql.Append(orderBy);
            }
            else
            {
                strSql.Append(" order by phgglist.ph");
            }
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 分页查询传输日志
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">每页多少条</param>
        /// <param name="pageNum">当前显示的为第几页</param>
        /// <returns></returns>
        public static DataSet QueryLOG(string strWhere, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = " where 1=1 ";
            string oKey = "Comid";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pageSql = "WITH TempDB AS (select *,ck+' | '+(select [CKName] from [WMS_Pub_Store] where [CKID]=CK) as CKNAME,row_number() OVER (ORDER BY {0} DESC) AS RowNumber FROM WMS_Com_Log {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere +=strWhere;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            sqlStr = sqlStr + " order by comtime desc";
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 得到日志总页数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetLogPageCount(string strWhere, int pageSize, out int allCount)
        {
            string strSql = "SELECT count(*) FROM [WMS_Com_Log] {0}";
            string sqlWhere = " where 1=1 ";
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
    }
}
