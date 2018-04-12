using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ACCTRUE.WMSBLL.QueryBll;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class KCJG
    {
        
        public static DataSet GetDJMX(string fydh)
        {
            string strSql = "select * FROM dbo.WMS_Bms_Inv_OutInfo where fydh='" + fydh + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetGHXX(string fydh)
        {
            string strSql = "select distinct PCH,dbo.GetPGS(PCH,'" + fydh + "') as PGS FROM dbo.WMS_Bms_Inv_OutInfo where fydh='" + fydh + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetZCMX(string fydh)
        {
            string strSql = "select CK, PCH, WLMC,count(1) as js,sum(ZL) as zlhe,max(rq) as rq ,GG,PH FROM dbo.WMS_Bms_Inv_OutInfo where fydh='" + fydh + "' group by CK,PCH,WLH,WLMC,GG,PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetZCMX1(string fydh)
        {
            string strSql = "select xh=row_number() over(order by vdelivbillcode),t.* FROM v_fyd_details t where vdelivbillcode='" + fydh + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetZCMX2(string fydh)
        {
            string strSql = "select top(1) dbo.GetCZY('" + fydh + "') as czy";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetZCMX3(string fydh)
        {
            string strSql = "select  (select top(1) khname from WMS_Pub_Customer where (khid=a.khbm))  as  khname,case a.yslb when 1 then '汽运' else '火运' end as cx,cph,fydh FROM WMS_Bms_Pic_FYD a where fydh='" + fydh + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
        //锈蚀品信息查询
        public static DataSet GetXSP()
        {
            string strSql = "select PH,gg,pch,PCInfo,count(*) as js,sum(zl) as zl,min(WeightRQ) as zzscrq from WMS_Bms_Inv_Info where PCInfo like '%锈蚀%' group by PH,gg,pch, PCInfo order by ph,gg,js";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //库存结构信息查询
        public static DataSet GetKCJG()
        {
            string strSql = "select distinct sx sx,count(*) as js,sum(zl) as zl,min(weightrq) as zzscrq,max(weightrq) as zwscrq from WMS_Bms_Inv_Info group by sx order by zzscrq";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }


        //分属性的线材库存结构
        public static DataSet GetFSXJG()
        {
            string strSql = "select fsxkcjg.ph,fsxkcjg.gg,fsxkcjg.sx,count(*) as pcs,min(fsxkcjg.js) as zxpcjs,sum(fsxkcjg.js) as zjs,sum(fsxkcjg.zl) as zzl from " +
                "(select ph,gg,sx,pch,count(*) as js,sum(zl) as zl from WMS_Bms_Inv_Info group by ph,gg,sx,pch) fsxkcjg "+
                "group by fsxkcjg.ph,fsxkcjg.gg,fsxkcjg.sx order by fsxkcjg.sx,fsxkcjg.ph,fsxkcjg.gg";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //库龄分析
        public static DataSet GetKLFX()
        {
            string strSql = "select klfxjg.ph,klfxjg.gg,klfxjg.sx,klfxjg.zjs,klfxjg.zzl,klfxjg.zzscrq,klfxjg.zdkl from  " +
                "(select klfx.ph,klfx.gg,klfx.sx,sum(klfx.js) as zjs,sum(klfx.zl) as zzl,substring(convert(varchar,min(klfx.zzscrq), 120), 1, 10) as zzscrq,max(klfx.kuling) as zdkl from " +
                "(select ph,gg,sx,pch,count(*) as js,sum(zl) as zl,max(WeightRQ) as zzscrq,datediff(day, max(WeightRQ),getdate()) as kuling from WMS_Bms_Inv_Info group by ph,gg,sx,pch) klfx "+
                "group by klfx.ph, klfx.gg,klfx.sx) klfxjg order by klfxjg.zdkl desc";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }
}
