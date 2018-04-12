using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class FYDQuery
    {
        //制单人
        public static DataSet GetZDRY()
        {
            string sqlzdr = "select distinct NCZDRY  from WMS_Bms_Pic_FYD group by NCZDRY";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlzdr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取发运单可用货位
        public static DataSet GetQueryFYDKYHW(string fydh,string ck,string wlh,string sx,string vfree1,string vfree2,string vfree3)
        {
   //         declare @vpcinfo varchar(50)
   //set @vpcinfo = ''
   //select @vpcinfo=PCInfo from WMS_Bms_Pic_FYD 
   //   where FYDH=@ifydh and CK=@ick and WLH=@iwlh and SX=@isx and vfree1=@vfree1 and vfree2=@vfree2 and vfree3=@vfree3 and Status<>4
   //set @vpcinfo = isnull(ltrim(@vpcinfo),'')
   //SELECT  HW,COUNT(*) AS NUM, PH+GG,SX,vfree1,vfree2,vfree3 FROM WMS_Bms_Inv_Info 
   //WHERE isnull(rtrim(ltrim(PCInfo)),'') = @vpcinfo 
   //and  NOT EXISTS (select  WGDH from WMS_Bms_Rec_WGD where ZPDJBZ=1 and 
   // WMS_Bms_Inv_Info.wgdh=WMS_Bms_Rec_WGD.wgdh)
   //GROUP BY CK, HW, WLH,PH+GG, SX,vfree1,vfree2,vfree3
   //HAVING (CK = @ick) AND (WLH = @iwlh) AND (SX = @isx) and (vfree1=@vfree1) and (vfree2=@vfree2) and (vfree3=@vfree3)
   //ORDER BY MIN(WeightRQ)
            string vpcinfo = "";
            AdoHelper helper = new SqlHelp();
            DataSet ds = null;
            string sqltmp = "select isnull(ltrim(pcinfo),'') as pcinfos from WMS_Bms_Pic_FYD where fydh='"+fydh+"' and wlh='"+wlh+"' and sx='"+sx+"' and vfree1='"+vfree1+
                "' and vfree2='"+vfree2+"' and vfree3='"+vfree3+"' and status<>4";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqltmp);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                vpcinfo = ds.Tables[0].Rows[0]["pcinfos"].ToString();
                if(string.IsNullOrEmpty(ck))
                    sqltmp = "select ck,hw,wlh,pch,wlmc,count(1) as num,sum(zl) as zls,PCInfo,ph,gg,sx,vfree1,vfree2,vfree3,CONVERT(varchar(100), max(weightRQ), 120) as rq from wms_bms_inv_info where isnull(rtrim(ltrim(pcinfo)),'')='" + vpcinfo +
                    "' and not exists(select wgdh from wms_bms_rec_wgd where zpdjbz=1 and wms_bms_inv_info.wgdh=wms_bms_rec_wgd.wgdh)" +
                    " group by ck,hw,wlh,pch,wlmc,ph,gg,sx,vfree1,vfree2,vfree3,PCInfo having ( wlh='" + wlh + "') and (sx='" + sx + "') and (vfree1='" + vfree1 +
                    "') and (vfree2='" + vfree2 + "') and (vfree3='" + vfree3 + "') order by min(weightRQ)";
                else
                    sqltmp = "select ck,hw,wlh,pch,wlmc,count(1) as num,sum(zl) as zls,PCInfo,ph,gg,sx,vfree1,vfree2,vfree3,CONVERT(varchar(100), max(weightRQ), 120) as rq from wms_bms_inv_info where isnull(rtrim(ltrim(pcinfo)),'')='" + vpcinfo +
                    "' and not exists(select wgdh from wms_bms_rec_wgd where zpdjbz=1 and wms_bms_inv_info.wgdh=wms_bms_rec_wgd.wgdh)"+
                    " group by ck,hw,wlh,pch,wlmc,ph,gg,sx,vfree1,vfree2,vfree3,PCInfo having(ck='"+ck+"') and ( wlh='" + wlh + "') and (sx='" + sx + "') and (vfree1='" + vfree1 +
                    "') and (vfree2='"+vfree2+"') and (vfree3='"+vfree3+"') order by min(weightRQ)";
                try
                {
                    ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqltmp);
                    return ds;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }
        }


        //获取发运单发货参考
        public static DataSet GetQueryFYDFHCK(string fydh)
        {
            AdoHelper helper = new SqlHelp();
            DataSet ds = null;
            string sqltmp = "SELECT * FROM v_delivery_ref V WHERE V.FYDH='" + fydh + "'";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqltmp);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               return ds;
            }
            else
            {
                return null;
            }
        }
        //获取发运单
        public static DataSet GetFYDY()
        {
            string sqlFYD = "select distinct TOP 1000 FYDH from WMS_Bms_Pic_FYD order by FYDH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlFYD);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取部门
        public static DataSet GetBMY()
        {
            string sqlBM = "select NCBM FROM WMS_BMS_PIC_FYD GROUP BY NCBM";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlBM);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
         //获取车牌号
        public static DataSet GetCPH()
        {
            string sqlCPH= "select distinct top 1000 CPH from WMS_Bms_Pic_FYD order by CPH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlCPH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取物料号
        public static DataSet GetWLH()
        {
            string sqlWLH = "select distinct top 1000 WLH  from WMS_Bms_Pic_FYD  order by WLH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlWLH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 获取牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPH()
        {
            string sqlPH = "select distinct top 1000 PH  from WMS_BMS_PIC_FYD order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取属性
        public static DataSet GetSX()
        {
            string sqlSX = "select SX from WMS_Pic_Doc GROUP by SX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlSX);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取规格
        public static DataSet GetGG()
        {
            string sqlGG = "select distinct GG  from WMS_BMS_PIC_FYD Where GG IS NOT NULL order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlGG);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取规格
        public static DataSet Getgg1()
        {
            string sqlgg1 = "select distinct GG AS gg1 from WMS_BMS_PIC_FYD Where GG is not null order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlgg1);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
        //获取特殊信息
        public static DataSet GetTSXX()
        {
            string sqlTSXX = "select distinct pcinfo from WMS_BMS_PIC_FYD order by pcinfo";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlTSXX);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取客户号
        public static DataSet GetKHH()
        {
            string sqlKHH = "select top 1000 KHID,KHID+'|'+KHName AS KHHNAME from WMS_Pub_Customer order by KHID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlKHH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //获取地址
        public static DataSet GetADD()
        {
            string sqlADD = "select distinct AimAdress  from WMS_BMS_PIC_FYD order by AimAdress desc";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlADD);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_bms_pic_fyd a where 1=1 {0}";
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 分页查询发运单信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">每页多少条</param>
        /// <param name="pageNum">当前显示的为第几页</param>
        /// <returns></returns>
        /// 
        public static DataSet GetQueryFYD(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "fydh";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT a.*,(select top 1 khname from WMS_Pub_Customer where khid=a.khbm) as khname,CAST(a.SJZL as numeric(10,4)) as zSJZL,CAST(a.JHZL as numeric(10,4)) as zJHZL,case a.yslb when 1 then '汽车发运' else '火车发运' end as Desc_yslb,case status when 0 then '未执行' when 1 then '已进厂' when 2 then '装车完毕' when 3 then '已出厂' when 4 then '已作废' else '正在装车' end as Desc_status,row_number() OVER (ORDER BY {0}) AS RowNumber from wms_bms_pic_fyd a where 1=1 {1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
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
        public static int GetPageCountQR(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_bms_pic_fyd a where status=2 and a.yslb=1  {0}";
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
        /// <summary>
        /// 发运数量确认查询
        /// </summary>
        /// <param name="Sql_ZKD"></param>
        /// <param name="orderKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public static DataSet GetQueryFYDQR(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "cph,fydh";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT a.*,(select top 1 khname from WMS_Pub_Customer where khid=a.khbm) as khname,"+
                "CAST(a.SJZL as numeric(10,4)) as zSJZL,CAST(a.JHZL as numeric(10,4)) as zJHZL,case a.yslb when 1 then '汽车发运' else '火车发运' "+
                "end as Desc_yslb,case status when 0 then '未执行' when 1 then '已进厂' when 2 then '装车完毕' when 3 then '已出厂' when 4 then '已作废' else '正在装车' end"+
                " as Desc_status,row_number() OVER (ORDER BY {0}) AS RowNumber from wms_bms_pic_fyd a where status=2 and a.yslb=1 {1})SELECT * FROM TempDB " +
                "WHERE RowNumber BETWEEN {2} and {3}";
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

        /// <summary>
        /// 修改车厢号
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <param name="newCPH">新车厢号</param>
        /// <returns></returns>
        public static int UpdateFYDCPH(string fydh,string newCPH)
        {
            string sqlU1 = "update WMS_Bms_Inv_OutInfo set CXH='"+newCPH+"' where FYDH='"+fydh+"'";
            string sqlU2 = "update WMS_Pic_Doc set CPH='"+newCPH+"' where CKDH='"+fydh+"'";
            string sqlU3 = "update wms_bms_pic_fyd set cph='" + newCPH + "' where fydh='" + fydh + "'";
            AdoHelper sqlHelp = new SqlHelp();

            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                sqlHelp.ExecuteNonQuery(tra, CommandType.Text, sqlU1);
                sqlHelp.ExecuteNonQuery(tra, CommandType.Text, sqlU2);
                sqlHelp.ExecuteNonQuery(tra, CommandType.Text, sqlU3);
                tra.Commit();
                con.Close();
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return 1;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return 0;
        }
        public static DataSet getfydPicPath(string fydh)
        {
            string sqlstr="";
            string pfydh = "";
            sqlstr = "select top 1 fydh from wms_bms_pic_fyd_Check where fydh like '%"+fydh+"%' order by qrsj desc";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            //ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    pfydh = ds.Tables[0].Rows[0]["fydh"].ToString();

            //}
            //if (pfydh != "")
            //{

                sqlstr = "select top 1 * from wms_fyd_pic where fydh like '%" + fydh + "%' order by scsj desc";
                helper = new SqlHelp();
                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else return null;
            //}
            //else return null;
        }
        public static DataSet GetFYDQRItems(string fydh)
        {
            string sqlstr="";
            string pfydh = "";
            sqlstr = "select top 1 fydh from wms_bms_pic_fyd_Check where fydh like '%"+fydh+"%' order by qrsj desc";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                pfydh = ds.Tables[0].Rows[0]["fydh"].ToString();

            }
            if (pfydh != "")
            {
                sqlstr = "select sl,qrsj,username as qrrname,case xh when 1 then '货管' when 2 then '签证室' when 3 then '门岗' " +
                            " end as rolename from wms_bms_pic_fyd_Check a left join WMS_Pub_Users b " +
                            " on a.qruser=b.userid where a.fydh='" + pfydh + "' order by qrsj";

                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds;
                return null;
            }
            else return null;
            
        }
      /// <summary>
        /// 获发运单明细
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetFYDItems(string strFYDH)
        {
            string sqlPCH = "select * from WMS_Bms_Inv_OutInfo where fydh='" + strFYDH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //作废
        public void Update(string strFYDH,string userid)
        {

            string strSql = "update WMS_Bms_Pic_FYD set Status=4,ZFR='"+userid+"',ZFTime=getdate() where fydh='" + strFYDH + "'";
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());

            strSql = "delete from wms_bms_pic_fyd_Check where fydh like '%"+strFYDH+"%'";
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            strSql = "delete from wms_bms_pic_fyd_Check_item where fydh like '%" + strFYDH + "%'";
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            strSql = "delete from wms_fyd_pic where fydh like '%" + strFYDH + "%'";
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        //取消完成
        public int CancleWC(string fydh, string ck, string wlh, string sx, string opid)
        {
            //string sqlstr = "";
            //sqlstr = "select * from wms_bms_pic_fyd_Check where fydh='"+fydh+"' and xh=2";
            //DataSet ds = null;
            //AdoHelper helper = new SqlHelp();
            //ds=helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            //if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            //{
            //    return 10000;
            //}

            string strProName = "L_Sell_CancelComplate";
            SqlParameter[] parameters = {
					new SqlParameter("@fydh", SqlDbType.VarChar),
					new SqlParameter("@ck", SqlDbType.VarChar),
					new SqlParameter("@wlh", SqlDbType.VarChar),
					new SqlParameter("@sx", SqlDbType.VarChar),
                    new SqlParameter("@oper",SqlDbType.VarChar),
                    new SqlParameter("@ReturnResult",SqlDbType.Int)};
            parameters[0].Value = fydh;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = ck;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = wlh;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Value = sx;
            parameters[3].Direction = ParameterDirection.Input;
            parameters[4].Value = opid;
            parameters[4].Direction = ParameterDirection.Input;

            parameters[5].Direction = ParameterDirection.ReturnValue;

            AdoHelper ado = new SqlHelp();
            ado.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strProName, parameters);
            return (Object.Equals(parameters[5].Value,null)||object.Equals(parameters[5].Value,DBNull.Value))?-1:Convert.ToInt32(parameters[5].Value);
        }


        /// <summary>
        /// 得到总计信息
        /// </summary>
        /// <returns>总数</returns>
        public static DataSet GetFYDCollection(string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "SELECT Count(*) as fCount,sum(jhsl) as sjhsl,sum(sjsl) as ssjsl,sum(jhzl) as sjhzl,sum(sjzl) as ssjzl from wms_bms_pic_fyd a where 1=1 ";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;
            }
            DataSet result = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null && result.Tables.Count>0 && result.Tables[0].Rows.Count>0)
                return result;
            return null;
        }
        public static DataSet GetFYDCollectionQR(string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "SELECT Count(*) as fCount,sum(jhsl) as sjhsl,sum(sjsl) as ssjsl,sum(jhzl) as sjhzl,sum(sjzl) as ssjzl from wms_bms_pic_fyd a where status=2 and a.yslb=1 ";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;
            }
            DataSet result = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                return result;
            return null;
        }
        public static int GetExeFYDCount()
        {
            string strSql = "select count(*) from WMS_Bms_Pic_FYD where status<>3 and status<>4";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);
            return 0;
        }
       
    }
}
