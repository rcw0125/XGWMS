using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace ACCTRUE.WMSBLL.Model
{
    public class QuCheck
    {
        private static IPAddress serverIP = null;
        private static IPEndPoint serverFullAddr;
        private static Socket sock;
        public QuCheck()
        { }
        public static string sendcmddoor(string fydh, string userid)
        {
            string sqlstr = "";
            sqlstr = "select isnull(serverip,' ') as sip,isnull(port,-1) as sport from WMS_Pub_Users a left join wms_pub_door b " +
                "on a.doorno=b.doorno where a.userid='" + userid + "'";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            try
            {
                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string sip = ds.Tables[0].Rows[0]["sip"].ToString();
                    if (sip.Trim() == "") return "没有设置对应门岗或者对应门岗没有设置正确的地址！";
                    int sport = int.Parse(ds.Tables[0].Rows[0]["sport"].ToString());
                    serverIP = IPAddress.Parse(sip);
                    serverFullAddr = new IPEndPoint(serverIP, sport);
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sock.Connect(serverFullAddr);
                    if (sock.Connected)
                    {
                        string vt = "FYD|1|" + fydh;
                        byte[] byteSend = System.Text.Encoding.ASCII.GetBytes(vt.ToCharArray());
                        sock.Send(byteSend);

                        byte[] bytes = new byte[1024];
                        int bytesRead = sock.Receive(bytes);
                        string resstr = Encoding.Unicode.GetString(bytes);
                        resstr = resstr.Trim('\0');
                        string[] vtc = resstr.Split('|');
                        if (vtc[0].ToString() == "success")
                        {
                            //"success"+"|"+fydhstr + "|" + wz + "|" + pcph + "|" + cphissuccess + "|" + pbody + "|" + bodyissuccess;
                            string vcttt = saveCapPicture(vtc[1].ToString(), int.Parse(vtc[2].ToString()), vtc[3].ToString(), vtc[4].ToString(), vtc[5].ToString(), vtc[6].ToString());
                            if (vcttt == "0")
                            {
                                return "";
                            }
                            else return "操作失败：" + vcttt;
                        }
                        else return resstr;
                    }
                    else return "无法连接到拍照地址，联系管理员！";
                }
                else
                {
                    return "用户配置错误，没有指定门岗，或者指定的门岗没有配置正确的拍照地址！";
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static string saveCapPicture(string fydh, int wz, String cphpicname, String cphissuccess, String bodypicname, String bodyissuccess)
        {
            SqlConnection SqlCon = null;

            try
            {
                SqlCon = new SqlConnection(Common.GetConnectString());
                SqlCon.Open();

                SqlCommand scmd = new SqlCommand("L_fyd_pic", SqlCon);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.Add(new SqlParameter("@fydh", SqlDbType.VarChar, 200)).Value = fydh;
                scmd.Parameters.Add(new SqlParameter("@wz", SqlDbType.Int, 20)).Value = wz;
                scmd.Parameters.Add(new SqlParameter("@cphpicname", SqlDbType.VarChar, 100)).Value = cphpicname;
                scmd.Parameters.Add(new SqlParameter("@cphissuccess", SqlDbType.VarChar, 1)).Value = cphissuccess;
                scmd.Parameters.Add(new SqlParameter("@bodypicname", SqlDbType.VarChar, 100)).Value = bodypicname;
                scmd.Parameters.Add(new SqlParameter("@bodyissuccess", SqlDbType.VarChar, 1)).Value = bodyissuccess;
                scmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;
                //scmd.Parameters["ReturnValue"].Value.ToString();
                scmd.ExecuteNonQuery();
                //return "1111";
                return scmd.Parameters["ReturnValue"].Value.ToString();
            }
            catch (System.Exception ex)
            {
                //Common.LogError("Loc:L_fyd_pic\t\t" + ex.ToString());
                return ex.Message;
            }
            finally
            {
                SqlCon.Close();
            }
        }
        public static string sendcmd(string fydh,string userid)
        {
            string sqlstr = "";
            sqlstr = "select isnull(serverip,' ') as sip,isnull(port,-1) as sport from WMS_Pub_Users a left join wms_pub_qzs b "+
                "on a.QZS_no=b.qzs_no where a.userid='"+userid+"'";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            try
            {
                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    string sip = ds.Tables[0].Rows[0]["sip"].ToString();
                    if (sip.Trim() == "") return "没有设置对应签证室或者对应签证室没有设置正确的地址！";
                    int sport = int.Parse(ds.Tables[0].Rows[0]["sport"].ToString());
                    serverIP = IPAddress.Parse(sip);
                    serverFullAddr = new IPEndPoint(serverIP, sport);
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sock.Connect(serverFullAddr);
                    if (sock.Connected)
                    {
                        string vt = "FYD|0|" + fydh;
                        byte[] byteSend = System.Text.Encoding.ASCII.GetBytes(vt.ToCharArray());
                        sock.Send(byteSend);
                        //return "";
                        byte[] bytes = new byte[1024];
                        int bytesRead = sock.Receive(bytes);
                        string resstr = Encoding.Unicode.GetString(bytes);
                        resstr = resstr.Trim('\0');
                        string[] vtc=resstr.Split('|');
                        if (vtc[0].ToString() == "success")
                        {
                            //"success"+"|"+fydhstr + "|" + wz + "|" + pcph + "|" + cphissuccess + "|" + pbody + "|" + bodyissuccess;
                            string vcttt = saveCapPicture(vtc[1].ToString(), int.Parse(vtc[2].ToString()), vtc[3].ToString(), vtc[4].ToString(), vtc[5].ToString(), vtc[6].ToString());
                            if (vcttt == "0")
                            {
                                return "";
                            }
                            else return "操作失败：" + vcttt;
                        }
                        else return resstr;
                        
                    }
                    else return "无法连接到拍照地址，联系管理员！";
                    
                }
                else
                {
                    return "用户配置错误，没有指定签证室，或者指定的签证室没有配置正确的拍照地址！";
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static string zhqrdoor(string fydh, string userid, int zcsl)
        {
            string sqlstr = "";
            

            AdoHelper helper = new SqlHelp();
            
            try
            {
                string fydhlist = fydh.Replace(",", "','");
                fydhlist = "'" + fydhlist + "'";
                sqlstr = "select sum(SJSL)as sjsl from WMS_Bms_Pic_FYD where FYDH in(" + fydhlist + ")";
                DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    if (zcsl!=int.Parse(ds.Tables[0].Rows[0]["sjsl"].ToString()))
                    {
                        return "确认数量与实际装车数量不符！";
                    }
                }
                string[] strFydList = fydh.Split(',');
                //对发运单进行排序
                Array.Sort(strFydList);
                string sortFyd = "";
                for (int i = 0; i < strFydList.Length; i++)
                {
                    if (string.IsNullOrEmpty(sortFyd))
                        sortFyd = strFydList[i];
                    else
                        sortFyd += "," + strFydList[i];
                }
                sqlstr = "insert into wms_bms_pic_fyd_Check(fydh,xh,sl,qruser)values('" + sortFyd + "',3," + zcsl.ToString() + ",'" + userid + "')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static string zhqr(string fydh,string userid, int zcsl)
        {
            SqlConnection SqlCon = null;
            SqlTransaction tarn = null;
            string sqlstr = "";
            string[] fydhlist = fydh.Split(',');
            //对发运单进行排序
            Array.Sort(fydhlist);
            string sortFyd = "";
            for (int i = 0; i < fydhlist.Length; i++)
            {
                if (string.IsNullOrEmpty(sortFyd))
                    sortFyd = fydhlist[i];
                else
                    sortFyd += "," + fydhlist[i];
            }
            try
            {
                SqlCon = new SqlConnection(Common.GetConnectString());
                SqlCon.Open();
                SqlCommand scmd = new SqlCommand();
                scmd.Connection = SqlCon;
                tarn = SqlCon.BeginTransaction();
                scmd.Transaction = tarn;
                sqlstr = "insert into wms_bms_pic_fyd_Check(fydh,xh,sl,qruser,qrsj)values('" + sortFyd + "',2," + zcsl.ToString() + ",'" + userid + "',convert(varchar(19),getdate(),21))";
                scmd.CommandText = sqlstr;
                scmd.ExecuteNonQuery();
                foreach (string fydhf in fydhlist)
                {
                    sqlstr = "insert into wms_bms_pic_fyd_check_item(fydh,ffydh,xh,qrsj) values('" + fydhf + "','" + sortFyd + "',2,CONVERT(varchar(19), GETDATE(), 21))";
                    scmd.CommandText = sqlstr;
                    scmd.ExecuteNonQuery();
                }
                tarn.Commit();
                return "";
            }
            catch (System.Exception ex)
            {
                tarn.Rollback();
                return ex.Message;
            }
        }
        public static string checkfydOutPicIsSuccess(string fydh, int sbsl) //允许出门时的拍照判断
        {
            string sqlstr = "select * from wms_fyd_pic where fydh='"+fydh+"'";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int issuccess = 0;
                if (ds.Tables[0].Rows[0]["doorcphissuccess"].ToString() != "Y") issuccess++;
                if (ds.Tables[0].Rows[0]["doorbodyissuccess"].ToString() != "Y") issuccess++;
                if (ds.Tables[0].Rows[0]["qzscphissuccess"].ToString() != "Y") issuccess++;
                if (ds.Tables[0].Rows[0]["qzsbodyissuccess"].ToString() != "Y") issuccess++;
                if (issuccess>sbsl)
                {
                    return "拍照失败次数大于允许的次数，不允许出厂！";
                }
                return "";
            }
            else return "没有拍照，不允许出厂！";
        }

        public static string checkfydOutqrdoor(string fydh) //允许出门时装货数量确认的判断
        {
            string sqlstr = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                string fydhlist = fydh.Replace(",", "','");
                fydhlist = "'"+fydhlist + "'";
                //对发运单进行排序
                string[] fydStrings = fydh.Split(',');
                Array.Sort(fydStrings);
                string sortFyd = "";
                for (int i = 0; i < fydStrings.Length; i++)
                {
                    if (string.IsNullOrEmpty(sortFyd))
                        sortFyd = fydStrings[i];
                    else
                        sortFyd += "," + fydStrings[i];
                }
                sqlstr = "select sum(SJSL)as sjsl from WMS_Bms_Pic_FYD where FYDH in(" + fydhlist + ")";
                DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int sjsl = int.Parse(ds.Tables[0].Rows[0]["sjsl"].ToString());
                    sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=1 order by qrsj desc";
                    DataSet dstmp = null;
                    dstmp = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        int hgqrsl = int.Parse(dstmp.Tables[0].Rows[0]["sl"].ToString());
                        if (hgqrsl != sjsl)
                        {
                            return "货管确认数量与实际装车数量不符！";
                        }
                        else
                        {
                            sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=2 order by qrsj desc";
                            DataSet dstmp1 = null;
                            dstmp1 = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                            if (dstmp1 != null && dstmp1.Tables.Count > 0 && dstmp1.Tables[0].Rows.Count > 0)
                            {
                                int qzsqrsl = int.Parse(dstmp1.Tables[0].Rows[0]["sl"].ToString());
                                if (qzsqrsl != sjsl)
                                {
                                    return "签证室确认数量与实际装车数量不符！";
                                }
                                else
                                {
                                    sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=3 order by qrsj desc";
                                    DataSet dstmp2 = null;
                                    dstmp2 = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                                    if (dstmp2 != null && dstmp2.Tables.Count > 0 && dstmp2.Tables[0].Rows.Count > 0)
                                    {
                                        int mgqrsl = int.Parse(dstmp2.Tables[0].Rows[0]["sl"].ToString());
                                        if (mgqrsl != sjsl)
                                        {
                                            return "门岗确认数量与实际装车数量不符！";
                                        }
                                        else return "";
                                    }
                                    else
                                    {
                                        return "门岗没有进行装车确认！";
                                    }
                                    
                                }
                                    
                            }
                            else
                            {
                                return "签证室还没有确认！";
                            }

                        }

                    }
                    else
                    {
                        return "还没有货管确认！";
                    }

                }
                else
                    return "发运单不存在！";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static string checkfydOutqr(string fydh)
        {
            string sqlstr = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                string fydhlist = fydh.Replace(",", "','");
                fydhlist = "'" + fydhlist + "'";
                sqlstr = "select sum(SJSL)as sjsl from WMS_Bms_Pic_FYD where FYDH in(" + fydhlist + ")";
                DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int sjsl = int.Parse(ds.Tables[0].Rows[0]["sjsl"].ToString());
                    //先排序再查询
                    string[] fydStrings = fydh.Split(',');
                    Array.Sort(fydStrings);
                    string sortFyd = "";
                    for (int i = 0; i < fydStrings.Length; i++)
                    {
                        if (string.IsNullOrEmpty(sortFyd))
                            sortFyd = fydStrings[i];
                        else
                            sortFyd += "," + fydStrings[i];
                    }
                    sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=1 order by qrsj desc";
                    DataSet dstmp = null;
                    dstmp = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        int hgqrsl = int.Parse(dstmp.Tables[0].Rows[0]["sl"].ToString());
                        if (hgqrsl != sjsl)
                        {
                            return "货管确认数量与实际装车数量不符！";

                        }
                        else
                        {
                            sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=2 order by qrsj desc";
                            DataSet dstmp1 = null;
                            dstmp1 = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                            //dstmp1 = GetQRInfo(fydh, 2);
                            if (dstmp1 != null && dstmp1.Tables.Count > 0 && dstmp1.Tables[0].Rows.Count > 0)
                            {
                                int qzsqrsl = int.Parse(dstmp1.Tables[0].Rows[0]["sl"].ToString());
                                if (qzsqrsl!=sjsl)
                                {
                                    return "签证室确认数量与实际装车数量不符！";
                                }
                                else
                                   return "";
                            }
                            else
                            {
                                return "签证室还没有确认！";
                            }                 
                        }
                    }
                    else
                    {
                        return "还没有货管确认！";
                    }

                }
                else
                    return "发运单不存在！";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static string checkfydqr(string fydh)

        {
            string sqlstr = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                string fydhlist = fydh.Replace(",", "','");
                fydhlist="'"+fydhlist+"'";
                sqlstr = "select sum(SJSL)as sjsl from WMS_Bms_Pic_FYD where FYDH in (" + fydhlist + ") and status=2 and yslb=1";
                DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int sjsl = int.Parse(ds.Tables[0].Rows[0]["sjsl"].ToString());
                    //先排序再查询
                    string[] fydStrings = fydh.Split(',');
                    Array.Sort(fydStrings);
                    string sortFyd = "";
                    for (int i = 0; i < fydStrings.Length; i++)
                    {
                        if (string.IsNullOrEmpty(sortFyd))
                            sortFyd = fydStrings[i];
                        else
                            sortFyd += "," + fydStrings[i];
                    }
                    sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + sortFyd + "' and xh=1 order by qrsj desc";
                    DataSet dstmp = null;
                    dstmp = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                    //dstmp = GetQRInfo(fydh, 1);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        int hgqrsl = int.Parse(dstmp.Tables[0].Rows[0]["sl"].ToString());
                        if (hgqrsl != sjsl)
                        {
                            return "货管确认数量与实际装车数量不符！";

                        }
                        else return "";
                        
                    }
                    else
                    {
                        return "还没有货管确认！";
                    }

                }
                else
                    return "发运单不存在！";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            
        }

        private static DataSet GetQRInfo(string fydh, int xh)
        {
            string[] strList = fydh.Split(',');
            if (strList == null || strList.Length == 0)
                return null;
            ArrayList list = new ArrayList();
            for (int i = 0; i < strList.Length; i++)
            {
                list.Add(strList[i]);
            }
            ArrayList rList = new ArrayList();
            string[] strPX = new string[strList.Length];
            GetCurStr(strPX.Length, strPX, list, rList);

            for (int k = 0; k < rList.Count; k++)
            {
                string[] aa = rList[k] as string[];
                string line = "";
                for (int l = 0; l < aa.Length; l++)
                {
                    if (string.IsNullOrEmpty(line))
                        line = aa[l];
                    else
                        line = line + "," + aa[l];
                }
                //将每种排序都测试是否与数据库中的相等
                string sqlstr = "select top 1 sl from wms_bms_pic_fyd_Check where fydh='" + fydh + "' and xh="+xh+" order by qrsj desc";
                DataSet dstmp = null;
                AdoHelper helper = new SqlHelp();
                dstmp = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    return dstmp;
            }
            return null;
                
        }
        /// <summary>
        /// 将字符串排列组合
        /// </summary>
        /// <param name="k">第几位</param>
        /// <param name="newString">临时字符串</param>
        /// <param name="strList">排列组合结果</param>
        /// <param name="list">要排列组合的值</param>
        private static void GetCurStr(int k, string[] newString, ArrayList strList, ArrayList list)
        {
            if (strList.Count == 1)
            {
                newString[k - 1] = strList[0].ToString();
                string[] nnString = new string[newString.Length];
                for (int i = 0; i < nnString.Length; i++)
                {
                    nnString[i] = newString[i];
                }
                list.Add(nnString);
            }
            else
            {
                for (int m = 0; m < strList.Count; m++)
                {
                    newString[k - 1] = strList[m].ToString();
                    ArrayList lList = new ArrayList();
                    for (int l = 0; l < strList.Count; l++)
                    {
                        if (strList[l].ToString() != strList[m].ToString())
                        {
                            lList.Add(strList[l].ToString());
                        }
                    }
                    GetCurStr(k - 1, newString, lList, list);
                }
            }
        }

        public static string GetDefaultSx(string pch)
        {
            string sqlstr = "";
            try
            {
                sqlstr = "select zjbz,pcsx,pclx,isnull(filed1,'') as defsx,zpdjbz from " +
                    "WMS_Bms_Rec_WGD where pch='" + pch + "' and zjbz=1";
                AdoHelper helper = new SqlHelp();
                DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    string pcsx = ds.Tables[0].Rows[0]["pcsx"].ToString();
                    string pclx = ds.Tables[0].Rows[0]["pclx"].ToString();
                    string filed1 = ds.Tables[0].Rows[0]["defsx"].ToString();
                    string zpdjbz = ds.Tables[0].Rows[0]["zpdjbz"].ToString();
                    if (pclx == "0")
                    {
                        if (zpdjbz == "1") return filed1;
                        else return "A";
                    }
                    else
                    {
                        string sqlstrf = "select sx from WMS_Bms_Rec_WGD_item where pch='" + pch + "' and zjbxbz=1";
                        DataSet dsr = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstrf);
                        if (dsr != null && dsr.Tables.Count > 0 && dsr.Tables[0].Rows.Count > 0)
                        {
                            return dsr.Tables[0].Rows[0]["sx"].ToString();
                        }
                        else return "A";
                    }
                }
                else return "A";
            }
            catch
            {
                return "";
            }
        }
        public static string GetDefaultItem(string pch,string ph)
        {
            string sqlstr = "";
            sqlstr = "select zjbz,vfree1,vfree2,vfree3,pcsx,pclx from WMS_Bms_Rec_WGD where pch='"+pch+"'";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string vfree3 = "";
                string pcsx = ds.Tables[0].Rows[0]["pcsx"].ToString();
                string pclx = ds.Tables[0].Rows[0]["pclx"].ToString();
                vfree3 = ds.Tables[0].Rows[0]["vfree3"].ToString();
                if (ds.Tables[0].Rows[0]["zjbz"].ToString() == "0")
                {
                    sqlstr = "select  WLH+'|'+ PH+'|'+GG +'|'+ zxbz+'|'+vfree2+'|'+vfree3 as ZHX FROM "+
                        "WMS_Bms_Rec_WGD_Item where pch='"+pch+"' and ph='"+ph+"' and vfree3='"+vfree3+"'";
                }
                else
                {
                    if (pclx == "1")
                        sqlstr = "select  WLH+'|'+ PH+'|'+GG +'|'+ zxbz+'|'+vfree2+'|'+vfree3 as ZHX FROM " +
                            "WMS_Bms_Rec_WGD_Item where pch='" + pch + "' and zjbxbz=1 ";
                    else
                        sqlstr = "select  WLH+'|'+ PH+'|'+GG +'|'+ zxbz+'|'+vfree2+'|'+vfree3 as ZHX FROM " +
                        "WMS_Bms_Rec_WGD where pch='" + pch +"'";
                }
                DataSet dsr = helper.ExecuteDataset(Common.GetConnectString(),CommandType.Text,sqlstr);
                if (dsr != null && dsr.Tables.Count > 0 && dsr.Tables[0].Rows.Count > 0)
                {
                    return  dsr.Tables[0].Rows[0]["zhx"].ToString();
                }
                else
                    return "";
            }
            else return "";
        }
        public static DataSet QueryWGD(string strWhere)//完工单查询
        {
            string sqlstr = null;
            sqlstr = "select top 100 * from  WMS_Bms_Rec_WGD left join WMS_Bms_Rec_WGD_SXXZ on WMS_Bms_Rec_WGD.pch=WMS_Bms_Rec_WGD_SXXZ.sxpch where 1=1 " + strWhere + " order by PCH ";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetWGDItemsPH(string strpch)
        {
            string sqlPCH = "SELECT distinct ph FROM WMS_Bms_Rec_WGD_Item WHERE PCH='" + strpch + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetWGDItems(string strPCH) //获取完工单条目
        {
            string sqlPCH = "SELECT * FROM WMS_Bms_Rec_WGD_Item WHERE PCH='" + strPCH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetWLSX(string strWLH) //获取物料属性
        {
            string sqlstr = null;
            //sqlstr = "select SX from WMS_BMS_WL_SX where wlh='" + strWLH + "' and SX<>'R1/2合格'";
            sqlstr = "select SX from WMS_PUB_SXSET where ShowFlag='Y' order by SX" ;
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetWLSXNEW(string strWLH, string type) //获取物料属性
        {
            string sqlstr = null;
            //sqlstr = "select SX from WMS_BMS_WL_SX where wlh='" + strWLH + "' and SX<>'R1/2合格'";
            if(type=="0")
                sqlstr = "select SX from WMS_PUB_SXSET where ISBATCH='Y' order by SX";
            else
                sqlstr = "select SX from WMS_PUB_SXSET where ISDEFAULTDJ='Y' order by SX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetPHZXBZ(string strPH)//获取执行标准
        {
            string sqlstr = null;
            sqlstr = "select ZXBZValue from WMS_Pub_PerStd where ZXBZPH='" + strPH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetWGDItemZH(string strPCH, string ph)  //获取完工单条目的组合项
        {
            string sqlstr = null;
            sqlstr = "SELECT WLH+'|'+ PH+'|'+GG +'|'+ vfree1+'|'+vfree2+'|'+vfree3 as ZHX,zjbxbz,SX as zjbxSX FROM WMS_Bms_Rec_WGD_Item where pch='" + strPCH + "'and ph='" + ph + "' order by zjbxbz desc";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getWgdStatus(string strPCH)//获取完工单状态
        {
            string sqlstr = null;
            sqlstr = "select zjbz from WMS_Bms_Rec_WGD where pch='" + strPCH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getWgdSCZT(string strPCH)//获取完工单生产状态
        {
            string sqlstr = null;
            sqlstr = "select wcbz from WMS_Bms_Rec_WGD where pch='" + strPCH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getwgdzjbxx(string strPCH)
        {
            string sqlstr = null;
            sqlstr = "select wlh,wlmc,ph,gg,sx,zxbz,Vfree1,Vfree2,Vfree3 from WMS_Bms_Rec_WGD_Item where pch='" + strPCH + "' and zjbxbz=1";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }
        public static string isgp(string strPCH)
        {
            string sqlstr = null;
            sqlstr = "select pclx,wlh,ph,gg,zxbz,ywlh,ywlmc,yph,ygg,yzxbz,vfree1,vfree2,vfree3 from WMS_Bms_Rec_WGD where pch='" + strPCH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["pclx"].ToString() == "0")
                {
                    string wlh = null;
                    string ph = null;
                    string gg = null;
                    string zxbz = null;
                    string ywlh = null;
                    string yph = null;
                    string ygg = null;
                    string yzxbz = null;
                    wlh = ds.Tables[0].Rows[0]["wlh"].ToString();
                    ph = ds.Tables[0].Rows[0]["ph"].ToString();
                    gg = ds.Tables[0].Rows[0]["gg"].ToString();
                    zxbz = ds.Tables[0].Rows[0]["zxbz"].ToString();
                    ywlh = ds.Tables[0].Rows[0]["ywlh"].ToString();
                    yph = ds.Tables[0].Rows[0]["yph"].ToString();
                    ygg = ds.Tables[0].Rows[0]["ygg"].ToString();
                    yzxbz = ds.Tables[0].Rows[0]["yzxbz"].ToString();
                    if (!(wlh == ywlh && ph == yph && gg == ygg))
                        return "1";
                    else
                        return "0";
                }
                else
                    return "0";
            }
            else
                return "0";

        }
        public static string CheckQu(string pch, string pclx, string pcsx, string zxbz, string isgp, string zpdjbz,
                              string itemwlh, string itemph, string itemgg, string itemzxbz, string itemsx, string userno, 
                              string free1, string free2, string free3,string sxqgz,string wlhper,string sxqgg,string sxqvfree)
        {
            if (string.IsNullOrEmpty(userno))
                return "质检人信息为空，请重新登陆！";
            SqlConnection conn = new SqlConnection(Common.GetConnectString());
            conn.Open();
            SqlCommand ckcomm = new SqlCommand();
            SqlTransaction ckTran;
            ckTran = conn.BeginTransaction();
            try
            {
                string sqlstr = "";
                ckcomm.Connection = conn;
                ckcomm.Transaction = ckTran;
                //sqlstr = "update WMS_Bms_Rec_WGD_item set zjbxbz=0,sx='',zxbz='' where PCH='"+pch+"'";  //还原质检备选项
                sqlstr = "update WMS_Bms_Rec_WGD_item set zjbxbz=0,sx='' where PCH='" + pch + "'";  //还原质检备选项,去掉执行执行标准
                ckcomm.CommandText = sqlstr.ToString();
                ckcomm.ExecuteNonQuery();
                if (pclx == "0") //普通材
                {
                    if (isgp == "1") //改判
                    {
                        //    dm_server.conn.Execute('update WMS_Bms_Rec_WGD set NCWLBMID='+#39+trim(G_ui.userno)+#39+',FEW_SCX='+#39+formatdatetime('yyyy.mm.dd',now)+#39+
                        //  ',wlh='+#39+wlh+#39+',wlmc='+#39+wlmc+#39+',zjbz=1,pclx=0,gg='+#39+gg+#39+',ph='+#39+ph+#39+',zpdjbz='+
                        //     inttostr(zpdjbz)+',PCSX='+#39+SXItem+#39+
                        //',ZXBZ='+#39+trim(edtzxbz.Text)+#39+' where wgdh='+#39+trim(qrywgd.fieldbyname('WGDH').AsString)+#39);

                        //sqlstr = "update WMS_Bms_Rec_WGD set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)," +
                        //    "wlh='" + itemwlh + "',wlmc=(select top 1 wlmc from WMS_Bms_Rec_WGD_item where pch='" + pch + "' and wlh='" + itemwlh + "'),zjbz=1,pclx=0," +
                        //  "gg='" + itemgg + "',ph='" + itemph + "',zpdjbz=" + zpdjbz + ",PCSX='" + pcsx + "',zxbz='" + itemzxbz + "' where pch='" + pch + "'";
                        sqlstr = "update WMS_Bms_Rec_WGD set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)," +
                            "wlh='" + itemwlh + "',wlmc=(select top 1 wlmc from WMS_Bms_Rec_WGD_item where pch='" + pch + "' and wlh='" + itemwlh + "'),zjbz=1,pclx=0," +
                            "gg='" + itemgg + "',zxbz='" + itemzxbz + "',vfree1='" + free1 + "',vfree2='" + free2 + "',vfree3='" + free3 + "',ph='" + itemph + "',zpdjbz=" + zpdjbz + ",PCSX='" + pcsx + "' where pch='" + pch + "'";//去掉执行标准

                        //sqlstr = "";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                    }
                    else       //非改判
                    {
                        //      dm_server.conn.Execute('update wms_bms_rec_wgd set NCWLBMID='+#39+trim(G_ui.userno)+#39+',FEW_SCX='+#39+formatdatetime('yyyy.mm.dd',now)+#39+
                        //',zjbz=1,pclx=0,zxbz='+#39+trim(edtzxbz.Text)+#39+',PCSX='+#39+sx+#39+',zpdjbz='+inttostr(zpdjbz)+
                        //              ' where wgdh='+#39+trim(qrywgd.fieldbyname('wgdh').AsString)+#39);

                        //sqlstr = "update WMS_Bms_Rec_WGD set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)" +
                        //",zjbz=1,pclx=0,zpdjbz=" + zpdjbz + ",PCSX='" + pcsx + "',zxbz='" + zxbz + "' where pch='" + pch + "'";
                        sqlstr = "update WMS_Bms_Rec_WGD set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)" +
                           ",zjbz=1,pclx=0,zpdjbz=" + zpdjbz + ",PCSX='" + pcsx + "' where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();

                    }
                    if (pcsx == "DP")
                    {
                        sqlstr = "update wms_bms_rec_wgd set Filed1='" + itemsx + "' where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                    }
                }
                else //出口材
                {
                    if (itemwlh == "")//没有联产品
                    {
                        //                dm_server.conn.BeginTrans;
                        //dm_server.conn.Execute('update wms_bms_rec_wgd_item set zjbxbz=0 where  wgdh='+#39+trim(qrywgd.fieldbyname('WGDH').AsString)+#39);
                        //dm_server.conn.Execute('update wms_bms_rec_wgd set NCWLBMID='+#39+trim(G_ui.userno)+#39+',FEW_SCX='+#39+formatdatetime('yyyy.mm.dd',now)+#39+
                        //              ',zjbz=1,PCSX='+#39+sx+#39+',pclx=1,zpdjbz='+inttostr(zpdjbz)+' where wgdh='+#39+trim(qrywgd.fieldbyname('WGDH').AsString)+#39);
                        sqlstr = "update wms_bms_rec_wgd_item set zjbxbz=0 where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                        sqlstr = "update wms_bms_rec_wgd set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)," +
                            "zjbz=1,PCSX='" + pcsx + "',pclx=1,zpdjbz=" + zpdjbz + " where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                        if (pcsx == "DP")
                        {
                            sqlstr = "update wms_bms_rec_wgd set Filed1= 'CK' where pch='" + pch + "'";
                            ckcomm.CommandText = sqlstr;
                            ckcomm.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //                dm_server.conn.Execute('update wms_bms_rec_wgd_item set zjbxbz=0 where wgdh='+#39+trim(qrywgd.fieldbyname('WGDH').AsString)+#39);
                        //dm_server.conn.Execute('update wms_bms_rec_wgd_item set zjbxbz=1,SX='+#39+trim(sxcombobox.Text)+#39+','+
                        //                         'zxbz='+#39+trim(zxbzedit.Text)+#39+' where (wgdh='+#39+
                        //                         trim(qrywgd.fieldbyname('wgdh').AsString)+#39+') and (wlh+'+#39+' | '+#39+'+ph+'+
                        //                         #39+' | '+#39+'+gg='+#39+trim(phggcombobox.Text)+#39+')');
                        //dm_server.conn.Execute('update wms_bms_rec_wgd set NCWLBMID='+#39+trim(G_ui.userno)+#39+',FEW_SCX='+#39+formatdatetime('yyyy.mm.dd',now)+#39+
                        //             ',zjbz=1,PCSX='+#39+sx+#39+',pclx=1,zpdjbz='+inttostr(zpdjbz)+' where wgdh='+#39+trim(qrywgd.fieldbyname('WGDH').AsString)+#39);
                        sqlstr = "update wms_bms_rec_wgd_item set zjbxbz=0 where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                        //sqlstr = "update wms_bms_rec_wgd_item set zjbxbz=1,SX='" + itemsx + "',zxbz='" + itemzxbz + "' where pch='" + pch + "' and wlh='" + itemwlh + "'";
                        sqlstr = "update wms_bms_rec_wgd_item set zjbxbz=1,SX='" + itemsx + "' where pch='" + pch +
                            "' and wlh='" + itemwlh + "' and Vfree1='" + free1 + "' and Vfree2='" + free2 + "' and Vfree3='" + free3 + "' and zxbz='" + itemzxbz + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                        sqlstr = "update wms_bms_rec_wgd set NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102)," +
                            "zjbz=1,PCSX='" + pcsx + "',pclx=1,zpdjbz=" + zpdjbz + " where pch='" + pch + "'";
                        ckcomm.CommandText = sqlstr;
                        ckcomm.ExecuteNonQuery();
                        if (pcsx == "DP")
                        {
                            sqlstr = "update wms_bms_rec_wgd set Filed1= 'CK'  where pch='" + pch + "'";
                            ckcomm.CommandText = sqlstr;
                            ckcomm.ExecuteNonQuery();
                        }

                    }

                }
                //if (pclx == "0" && isgp == "0")  //普通材无改判质检
                //{
                //    sqlstr = "update WMS_Bms_Rec_WGD set zxbz='"+zxbz+"',zjbz=1,pcsx='" + pcsx + "',pclx='" + pclx + "',NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102) where pch='" + pch + "'";
                //    ckcomm.CommandText = sqlstr;
                //    ckcomm.ExecuteNonQuery();
                //}
                //if (pclx == "0" && isgp == "1") //普通材改判质检
                //{
                //    sqlstr = "update WMS_Bms_Rec_WGD_item set sx='"+itemsx+"',zxbz='"+itemzxbz+"' where pch='"+pch+"' and wlh='"+itemwlh+"'";
                //    ckcomm.CommandText = sqlstr;
                //    ckcomm.ExecuteNonQuery();
                //    string fzpdjbz = "";
                //    if (pcsx == "待判")
                //        fzpdjbz = "1";
                //    else fzpdjbz = "0";
                //    sqlstr = "update WMS_Bms_Rec_WGD set Pcsx='" + itemsx + "',zxbz='" + itemzxbz + "',pclx='" + pclx + "',wlh='" + itemwlh + "',ph='" + itemph +
                //                 "',gg='" + itemgg + "',zjbz=1,zpdjbz='" + fzpdjbz + "',NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102) where pch='" + pch + "'";
                //    ckcomm.CommandText = sqlstr;
                //    ckcomm.ExecuteNonQuery();
                //}
                //if (pclx == "1")  //出口材质检
                //{
                //    string fzpdjbz = "";
                //    if (pcsx == "待判")
                //        fzpdjbz = "1";
                //    else fzpdjbz = "0";
                //    sqlstr = "update WMS_Bms_Rec_WGD set PCsx='" + pcsx + "',zxbz='" + zxbz + "',pclx='" + pclx + "',zjbz=1,zpdjbz='" + fzpdjbz + "',NCWLBMID='" + userno + "',FEW_SCX=convert(varchar(20),getdate(),102) where pch='" + pch + "'";
                //    ckcomm.CommandText = sqlstr;
                //    ckcomm.ExecuteNonQuery();
                //    sqlstr = "update WMS_Bms_Rec_WGD_item set sx='" + itemsx + "',zxbz='" + itemzxbz +  "',zjbxbz=1 where pch='" + pch + "' and wlh='"+itemwlh+"'";
                //    ckcomm.CommandText = sqlstr;
                //    ckcomm.ExecuteNonQuery();
                //}
                if (pch.Substring(0, 1) == "A" || pch.Substring(0, 1) == "B" || pch.Substring(0, 1) == "9")//酸洗的
                {
                    sqlstr = "delete from WMS_Bms_Rec_WGD_SXXZ where sxpch='"+pch+"'";
                    ckcomm.CommandText = sqlstr;
                    ckcomm.ExecuteNonQuery();
                    sqlstr = "insert into  WMS_Bms_Rec_WGD_SXXZ(sxpch,wlhper,sxqgz,sxqgg,sxqvfree) values('"+pch+"','"+wlhper+"','"+sxqgz+"','"+sxqgg+"','"+sxqvfree+"')";
                    ckcomm.CommandText = sqlstr;
                    ckcomm.ExecuteNonQuery();
                }
                ckTran.Commit();
                return "0";
            }
            catch (Exception ex)
            {
                ckTran.Rollback();
                string aa = ex.Message;
                return aa;
            }

        }
        public static DataSet GetBhgReason(string itype)
        {
            string sqlstr = "";
            if (itype == "0")
            {
                sqlstr = "select * from WMS_PUB_SX_HPReason";
            }
            else if(itype=="1")
                sqlstr = "select * from WMS_PUB_SX_LXBHGPReason";
            else
                sqlstr = "select * from WMS_PUB_SX_GPReason";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static string saveReason(string itype, string reasontype, string newReason, string oldReason)
        {
            DataSet ds = new DataSet();
            AdoHelper datahelp = new SqlHelp();
            string sqlstr = null;
            if (itype == "0")  //新增
            {
                if (reasontype == "0")//黄牌原因
                    sqlstr = "select * from WMS_PUB_SX_HPReason where Reason='" + newReason + "'";
                else if (reasontype == "1") //不合格原因
                    sqlstr = "select * from WMS_PUB_SX_LXBHGPReason where Reason='" + newReason + "'";
                else sqlstr = "select * from WMS_PUB_SX_GPReason where Reason='" + newReason + "'";
            }
            else   //修改
            {
                if (reasontype == "0")//黄牌原因
                    sqlstr = "select * from WMS_PUB_SX_HPReason where Reason='" + newReason + "' and reason<>'" + oldReason + "'";
                else if (reasontype == "1") 
                    sqlstr = "select * from WMS_PUB_SX_LXBHGPReason where Reason='" + newReason + "' and reason<>'" + oldReason + "'";
                else sqlstr = "select * from WMS_PUB_SX_GPReason where Reason='" + newReason + "' and reason<>'" + oldReason + "'";
            }
            ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return "1";   //存在重复的数据
            else
            {
                try
                {
                    if (itype == "0") //新增
                    {
                        if (reasontype == "0")//黄牌
                        {
                            sqlstr = "insert into WMS_PUB_SX_HPReason(reason) values('" + newReason + "')";
                        }
                        else if (reasontype == "1") //不合格
                        {
                            sqlstr = "insert into WMS_PUB_SX_LXBHGPReason(reason) values('" + newReason + "')";
                        }
                        else sqlstr = "insert into WMS_PUB_SX_GPReason(reason) values('" + newReason + "')";
                    }
                    else  //修改
                    {
                        if (reasontype == "0")//黄牌
                        {
                            sqlstr = "update WMS_PUB_SX_HPReason set reason='" + newReason + "' where reason='" + oldReason + "'";
                        }
                        else if (reasontype == "1")   //不合格
                        {
                            sqlstr = "update WMS_PUB_SX_LXBHGPReason set reason='" + newReason + "' where reason='" + oldReason + "'";
                        }
                        else sqlstr = "update WMS_PUB_SX_GPReason set reason='" + newReason + "' where reason='" + oldReason + "'";
                    }
                    SqlConnection conn = new SqlConnection(Common.GetConnectString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sqlstr;
                    cmd.ExecuteNonQuery();
                    return "0";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public static string delReason(string reasontype, string sreason)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sqlstr = null;
                if (reasontype == "0")//黄牌
                {
                    sqlstr = "delete from WMS_PUB_SX_HPReason where reason='" + sreason + "'";
                }
                else if (reasontype == "1")
                {
                    sqlstr = "delete from WMS_PUB_SX_LXBHGPReason where reason = '" + sreason + "'";
                }
                else sqlstr = "delete from WMS_PUB_SX_GPReason where reason = '" + sreason + "'";
                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataSet getPHZXBZ()
        {
            string sqlstr = "";
            sqlstr = "select * from WMS_PUB_PerStd";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static string savezxbz(string zxbz, string ph, string opetype, string oldph, string oldzxbz)//保存执行标准
        {
            DataSet ds = new DataSet();
            AdoHelper datahelp = new SqlHelp();
            string sqlstr = null;
            if (opetype == "0")  //新增
            {
                sqlstr = "select * from WMS_PUB_PerStd where ZXBZPH='" + ph + "' and ZXBZValue = '" + zxbz + "'";
            }
            else   //修改
            {
                sqlstr = "select * from WMS_PUB_PerStd where ZXBZPH='" + ph + "' and ZXBZValue = '" + zxbz +
                    "' and not (ZXBZPH='" + oldph + "' and ZXBZValue='" + oldzxbz + "')";
            }
            ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return "1";   //存在重复的数据
            else
            {
                try
                {
                    if (opetype == "0") //新增
                    {


                        sqlstr = "insert into WMS_PUB_PerStd(ZXBZPH,ZXBZValue) values('" + ph + "','" + zxbz + "')";

                    }
                    else  //修改
                    {

                        sqlstr = "update WMS_PUB_PerStd set ZXBZPH='" + ph + "',ZXBZValue='" + zxbz +
                            "' where ZXBZPH='" + oldph + "' and ZXBZValue='" + oldzxbz + "'";

                    }
                    SqlConnection conn = new SqlConnection(Common.GetConnectString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sqlstr;
                    cmd.ExecuteNonQuery();
                    return "0";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public static string delzxbz(string zxbz, string ph)   //删除执行标准
        {
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sqlstr = null;

                sqlstr = "delete from WMS_PUB_PerStd where ZXBZPH = '" + ph + "' and ZXBZValue='" + zxbz + "'";

                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataSet getseleds(string fname, string tbname) //获取字段列表
        {
            string sqlstr = "";
            sqlstr = "select distinct top 1000  " + fname + " from " + tbname + " order by " + fname + " desc";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        public static DataSet getbarcode(string itype, string sqlfilter)//获取单卷信息  itype:0 库存 1： 出库 sqlfilter:过滤条件
        {
            string sqlstr = "";
            AdoHelper dataHelp = new SqlHelp();
            if (itype == "0")
            {
                sqlstr = " select * from WMS_Bms_Inv_Info where 1=1 " + sqlfilter.ToString();
            }
            else
            {
                sqlstr = " select * from WMS_Bms_Inv_outInfo where 1=1 " + sqlfilter.ToString();
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="itype"></param>
        /// <param name="sqlfilter"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public static DataSet getbarcodePage(string itype, string sqlfilter, string orderKey, int pageSize, int pageNum)
        {
            string oKey = "Barcode";
            int pSize = 20;
            int pNum = 1;
            string pageSql = "";
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            if (itype == "0")
            {
                pageSql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber from WMS_Bms_Inv_Info where 1=1 {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            }
            else
            {
                pageSql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber from WMS_Bms_Inv_outInfo where 1=1 {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey, sqlfilter, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
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
        public static int GetPageCount(string itype, string strWhere, int pageSize, out int allCount, out decimal sZL)
        {
            string strSql = "";
            sZL = 0;
            if (itype == "0")
            {
                strSql = "select Count(*) AS JS,SUM(ZL) AS ZL from WMS_Bms_Inv_Info where 1=1 {0}";
            }
            else
                strSql = "select Count(*) AS JS,SUM(ZL) AS ZL from WMS_Bms_Inv_outInfo where 1=1 {0}";
            strSql = string.Format(strSql, strWhere);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                double temp = Convert.ToDouble(ds.Tables[0].Rows[0]["JS"]);
                allCount = Convert.ToInt32(temp);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ZL"].ToString()))
                {
                    sZL = Convert.ToDecimal(ds.Tables[0].Rows[0]["ZL"]);
                }
                double pageCount = Math.Ceiling(temp / pageSize);
                return Convert.ToInt32(pageCount);
            }
            sZL = 0;
            allCount = 0;
            return 0;
        }

        public static string SetPcInfo(string itype, string pch, string barcode, string selpcinfo, string newpcinfo, string sx)
        {
            string sqlstr = "";
            string pcinfovalue = "";
            if (selpcinfo == "")
                pcinfovalue = newpcinfo;
            else
                pcinfovalue = selpcinfo;
            if (itype == "0")  //修改完工单
            {
                sqlstr = "update WMS_Bms_Rec_WGD set pcinfo = '" + pcinfovalue + "' where pch = '" + pch + "'";
            }
            if (itype == "2")  //修改库存 批次属性 pcinfo
            {
                sqlstr = "update Wms_bms_Inv_Info set pcinfo='" + pcinfovalue + "' where pch = '" + pch + "' and sx='" + sx + "'";
            }
            if (itype == "3")
            {
                sqlstr = "update Wms_bms_Inv_Info set pcinfo = '" + pcinfovalue + "' where barcode='" + barcode + "'";
            }
            if (sqlstr == "")
                return "1";
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand comd = new SqlCommand();
                comd.CommandText = sqlstr.ToString();
                comd.Connection = conn;
                comd.ExecuteNonQuery();
                //comd.CommandText = "";  插入wms_pbu_pcinfo中不存在的pcinfo
                AdoHelper datahelp = new SqlHelp();
                DataSet ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, "select pcinfo from wms_pub_pcinfo where pcinfo='" + pcinfovalue + "'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return "0";
                else
                {
                    comd.CommandText = "insert into wms_pub_pcinfo(PCInfo) values('" + pcinfovalue + "')";
                    comd.ExecuteNonQuery();
                }
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataSet getWgdGZ(string wlhper)
        {
            string sqlstr = "select distinct ph from WMS_Bms_Inv_Info where substring(wlh,1,3)='" + wlhper + "'";
            AdoHelper helper=new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getWgdvfree(string wlhper, string ph, string gg)
        {
            string sqlstr = "select distinct vfree1+vfree2+vfree3 as vfree from WMS_Bms_Inv_Info where substring(wlh,1,3)='" + wlhper
                + "' and ph='" + ph + "' and gg='"+gg+"'";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getWgdgg(string wlhper,string ph)
        {
            string sqlstr = "select distinct gg from WMS_Bms_Inv_Info where substring(wlh,1,3)='" + wlhper + "' and ph='"+ph+"'";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet getQPInfo(string wlhper)
        {
            string sqlstr = "select * from (select distinct a.wlh,isnull(b.isqp,'0')as isqp,isnull(b.bzbzstr,'')as bzbzstr from WMS_BMS_WL_SX a left join WMS_PUB_WLH_QP b on "+
                            " a.wlh=b.wlh)c  where wlh like '"+wlhper+"%' order by c.isqp desc,wlh ";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if(ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                return ds;
            return null;

        }
        public static DataSet getQPBzbz(string wlh)
        {
            string sqlstr = "select distinct bzbz,'0' as ischeck from WMS_PUB_BZBZ order by bzbz";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlstr = "select * from wms_pub_wlh_bzbz where wlh='"+wlh+"' and bzbz='"+dr["bzbz"].ToString()+"'";
                    DataSet dstmp = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        dr["ischeck"] = "1";
                    }
                }
                return ds;
            }
            else  
                return null;
        }
        public static string setall(string wlh)
        {
            string sqlstr = "";
            SqlConnection conn = new SqlConnection(Common.GetConnectString());
            conn.Open();
            SqlCommand ckcomm = new SqlCommand();
            SqlTransaction ckTran;
            ckTran = conn.BeginTransaction();
            try
            {
                ckcomm.Connection = conn;
                ckcomm.Transaction = ckTran;
                sqlstr = "delete from  wms_pub_wlh_bzbz  where wlh='" + wlh + "'"; 
                ckcomm.CommandText = sqlstr.ToString();
                ckcomm.ExecuteNonQuery();
                sqlstr = "insert into wms_pub_wlh_bzbz(bzbz,wlh) select distinct bzbz,'" + wlh + "' from WMS_PUB_BZBZ";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();

                DataSet ds = null;
                AdoHelper helper = new SqlHelp();
                sqlstr = "select distinct bzbz from wms_pub_bzbz order by bzbz";
                ds=helper.ExecuteDataset(ckTran, CommandType.Text, sqlstr);
                string bzbzlist = "";
                if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    foreach ( DataRow dr in ds.Tables[0].Rows)
                    {
                        bzbzlist+=dr["bzbz"].ToString()+",";
                    }
                    
                    
                }
                if (bzbzlist != "")
                {
                    bzbzlist = bzbzlist.Substring(0, bzbzlist.Length - 1);
                }
                sqlstr = "delete from  WMS_PUB_WLH_QP where wlh='"+wlh+"'";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();
                sqlstr = "insert into WMS_PUB_WLH_QP(wlh,isqp,updatetime,bzbzstr) values('" + wlh + "',1,convert(varchar(19),getdate(),21),'"+bzbzlist+"')";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();
                ckTran.Commit();
                return bzbzlist;
            }
            catch (Exception ex)
            {
                ckTran.Rollback();
                return "ERROR:" + ex.Message;
            }
        }
        public static string setbzbz(string wlh, string bzbz, string ope)
        {
            string sqlstr = "";
            SqlConnection conn = new SqlConnection(Common.GetConnectString());
            conn.Open();
            SqlCommand ckcomm = new SqlCommand();
            SqlTransaction ckTran;
            ckTran = conn.BeginTransaction();
            try
            {
                ckcomm.Connection = conn;
                ckcomm.Transaction = ckTran;
                string bzbzlist = "";
                sqlstr = "delete from wms_pub_wlh_bzbz where wlh='"+wlh+"' and bzbz='"+bzbz+"'";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();
                if (ope=="1")
                {
                    sqlstr = "insert into wms_pub_wlh_bzbz(wlh,bzbz) values('" + wlh + "','" + bzbz + "')";
                    ckcomm.CommandText = sqlstr;
                    ckcomm.ExecuteNonQuery();
                }
                
                sqlstr = "select distinct bzbz from wms_pub_wlh_bzbz where wlh='"+wlh+"' order by bzbz";
                DataSet ds = null;
                AdoHelper helper = new SqlHelp();
                ds = helper.ExecuteDataset(ckTran, CommandType.Text, sqlstr);
                int flag = 0;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        bzbzlist += dr["bzbz"].ToString() + ",";
                    }
                    flag = 1;
                }
                if (bzbzlist!="")
                {
                    bzbzlist = bzbzlist.Substring(0, bzbzlist.Length - 1);
                }
                sqlstr = "delete from  WMS_PUB_WLH_QP where wlh='" + wlh + "'";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();
                sqlstr = "insert into WMS_PUB_WLH_QP(wlh,isqp,updatetime,bzbzstr) values('" + wlh + "',"+flag.ToString()+",convert(varchar(19),getdate(),21),'" + bzbzlist + "')";
                ckcomm.CommandText = sqlstr;
                ckcomm.ExecuteNonQuery();
                ckTran.Commit();
                return bzbzlist;
            }
            catch (System.Exception ex)
            {
                ckTran.Rollback();
                return "ERROR:" + ex.Message;
            }
        }
        public static string saveqp(string wlh, string isqp, string oldwlh, string opetype)
        {
            DataSet ds = new DataSet();
            AdoHelper datahelp = new SqlHelp();
            string sqlstr = null;
            if (opetype == "0")  //新增
            {
                sqlstr = "select * from WMS_PUB_WLH_QP where wlh='" + wlh + "'";
            }
            else   //修改
            {
                sqlstr = "select * from WMS_PUB_WLH_QP where wlh='" + wlh + "' and not (fid='" + oldwlh + "')";
            }
            ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return "1";   //存在重复的数据
            else
            {
                try
                {
                    if (opetype == "0") //新增
                    {


                        sqlstr = "insert into WMS_PUB_WLH_QP(wlh,isqp) values('" + wlh + "','" + isqp + "')";

                    }
                    else  //修改
                    {

                        sqlstr = "update WMS_PUB_WLH_QP set wlh='" + wlh + "',isqp='" + isqp +
                            "' where fid='" + oldwlh + "'";

                    }
                    SqlConnection conn = new SqlConnection(Common.GetConnectString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sqlstr;
                    cmd.ExecuteNonQuery();
                    return "0";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public static string delwlh(string wlh)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "delete from WMS_PUB_WLH_QP where wlh='"+wlh+"'";
            try
            {
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return "0";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataSet getBZBZInfo()
        {
            string sqlstr = "SELECT A.*,S.SCXName FROM WMS_PUB_BZBZ A LEFT JOIN WMS_PUB_SCX S ON A.SCXBM=S.SCXBM ORDER BY A.SCXBM,A.BZBZ,A.ZLMIN";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static string savebzbz(string txtbzbz, string bzxx, string bzsx, string clkz, string bz, string fid, string opetype,string scx)
        {
            DataSet ds = new DataSet();
            AdoHelper datahelp = new SqlHelp();
            string sqlstr = null;
            if (opetype == "0")  //新增
            {
                sqlstr = "select * from WMS_PUB_BZBZ where scxbm='" + scx + "' and bzbz='" + txtbzbz + "' and zlmin='" + bzxx + "' and zlmax='" + bzsx + "'";
            }
            else   //修改
            {
                sqlstr = "select * from WMS_PUB_BZBZ where scxbm='"+scx+"' and bzbz='" + txtbzbz + "' and zlmin='" + bzxx + "' and zlmax='" + bzsx + "' and not (fid='" + fid + "')";
            }
            ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return "1";   //存在重复的数据
            else
            {
                try
                {
                    if (opetype == "0") //新增
                    {
                        sqlstr = "insert into WMS_PUB_BZBZ(bzbz,zlmin,zlmax,zl,bz,scxbm) values('" + txtbzbz + "','" + bzxx + "','"+bzsx+"','"+clkz+"','"+bz+"','"+scx+"')";
                    }
                    else  //修改
                    {

                        sqlstr = "update WMS_PUB_BZBZ set bzbz='" + txtbzbz + "',zlmin='" + bzxx +
                            "',zlmax='"+bzsx+"',zl='"+clkz+"',bz='"+bz+"',scxbm='"+scx+"' where fid='" + fid + "'";

                    }
                    SqlConnection conn = new SqlConnection(Common.GetConnectString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sqlstr;
                    cmd.ExecuteNonQuery();
                    return "0";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public static string delbzbz(string fid)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "delete from WMS_PUB_BZBZ where fid='" + fid + "'";
            try
            {
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return "0";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        public static DataSet getwlh()
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "select distinct wlh from WMS_BMS_WL_SX order by wlh";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;

        }
        public static string setQp(string wlh)
        {
            try
            {
                string sqlstr = "select count(1) as f from WMS_PUB_WLH_QP where wlh='" + wlh + "'";
                DataSet ds = null;
                AdoHelper helper = new SqlHelp();
                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds.Tables[0].Rows[0]["f"].ToString() != "0")
                {
                    sqlstr = "update WMS_PUB_WLH_QP set isqp=cast(((cast(isqp as int)+1)%2) as char(1)) where wlh='" + wlh + "'";
                }
                else sqlstr = "insert into WMS_PUB_WLH_QP(wlh,isqp)values('" + wlh + "','1')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return "";
            }
            catch (System.Exception ex)
            {
                return "ERROR:" + ex.Message;
            }
            

        }

        //头尾材扣重设置
        public static DataSet getKCTW()
        {
            string sqlstr = "SELECT WLH,PH,GG,CAST(PPRICE as decimal(18,2)) as PPRICE,CAST(FPRICE as decimal(18,2)) as FPRICE,CAST(TWZL as decimal(18,1)) as TWZL,CAST(KCZL as decimal(18,1)) as KCZL,INUSE FROM WMS_PUB_KCTW";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //头尾材扣重设置
        public static DataSet getKCTW(string wlh)
        {
            string sqlstr = "SELECT WLH,PH,GG,CAST(PPRICE as decimal(18,2)) as PPRICE,CAST(FPRICE as decimal(18,2)) as FPRICE,CAST(TWZL as decimal(18,1)) as TWZL,CAST(KCZL as decimal(18,1)) as KCZL,INUSE FROM WMS_PUB_KCTW where wlh like '%"+wlh+"%'";
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //保存
        public static string saveKCTW(string opetype, string WLH, string PH, string GG, string PPRICE, string FPRICE, string TWZL,string userID)
        {
            DataSet ds = new DataSet();
            AdoHelper datahelp = new SqlHelp();
            string sqlstr = "select * from WMS_PUB_KCTW where WLH='" + WLH + "'";

           double fKCZL=0;
            try{

             double fTWZL=double.Parse(TWZL);
             double fFPRICE=double.Parse(FPRICE);
             double fPPRICE=double.Parse(PPRICE);
                if(fPPRICE<=0)
                {
                    return "产品价格必须大于0";
                }
                fKCZL=fTWZL-fTWZL*fFPRICE/fPPRICE;
                fKCZL = Math.Round(fKCZL,1);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            string sqlstr2 = "";
            ds = datahelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sqlstr = string.Format("UPDATE WMS_PUB_KCTW SET PH='{0}',GG='{1}',PPRICE={2},FPRICE={3},TWZL={4},KCZL={5},TS=getdate(),edituser='{6}' WHERE WLH='{7}'", PH, GG, PPRICE, FPRICE, TWZL, fKCZL, userID, WLH);
                //sqlstr2 = string.Format("INSERT INTO WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER,EDITTYPE) VALUES('{0}','{1}','{2}',{3},{4},{5},{6},getdate(),'{7}','修改')", WLH, PH, GG, PPRICE, FPRICE, TWZL, fKCZL, userID);
                sqlstr2 = "修改";
            }
            else
            {
                sqlstr = string.Format("INSERT INTO WMS_PUB_KCTW(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER) VALUES('{0}','{1}','{2}',{3},{4},{5},{6},getdate(),'{7}')", WLH, PH, GG, PPRICE, FPRICE, TWZL, fKCZL, userID);
                sqlstr2 = "添加";
                //sqlstr2 = string.Format("INSERT INTO WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER,EDITTYPE) VALUES('{0}','{1}','{2}',{3},{4},{5},{6},getdate(),'{7}','添加')", WLH, PH, GG, PPRICE, FPRICE, TWZL, fKCZL, userID);
            }
            // return "1";   //存在数据

            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();
                LogKCTW(conn, WLH, userID, sqlstr2);
               
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public static string delKCTW(string WLH,string userID)
        {
            string sqlstr = "DELETE from WMS_PUB_KCTW where WLH='" + WLH + "'";
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                LogKCTW(conn, WLH, userID, "删除");
                //try
                //{
                    //SqlCommand cmd2 = new SqlCommand();
                    //cmd2.Connection = conn;
                    //cmd2.CommandText = "insert into WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER,EDITTYPE) (select WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,getdate() as TS,'" + userID + "' as edituser,'删除' as edittype from WMS_PUB_KCTW where WLH='" + WLH + "')";
                    //cmd2.ExecuteNonQuery();
                //}
                //catch
                //{

                //}

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();
               
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string setKCTWStatus(string WLH, string status,string userID)
        {
            string sqlstr = "UPDATE WMS_PUB_KCTW set INUSE=" + status + " where WLH='" + WLH + "'";
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();
                LogKCTW(conn, WLH, userID, "改变状态");
                ////try
                ////{
                //    SqlCommand cmd2 = new SqlCommand();
                //    cmd2.Connection = conn;
                //    cmd2.CommandText = "insert into WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER,EDITTYPE) (select WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,getdate() as TS,'" + userID + "' as edituser,'改变状态' as edittype from WMS_PUB_KCTW where WLH='"+WLH+"')";
                //    cmd2.ExecuteNonQuery();
                ////}
                ////catch
                ////{

                ////}
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string setKCTWStatus(string status,string userID)
        {
            string sqlstr = "UPDATE WMS_PUB_KCTW set INUSE=" + status;
            try
            {
                SqlConnection conn = new SqlConnection(Common.GetConnectString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlstr;
                cmd.ExecuteNonQuery();

                //try
                //{
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,TS,EDITUSER,EDITTYPE) select WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,getdate() as TS,'" + userID + "' as edituser,'改变状态' as edittype from WMS_PUB_KCTW";
                    cmd2.ExecuteNonQuery();
                //}
                //catch
                //{

                //}
               // conn.Close();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void LogKCTW(SqlConnection conn,string WLH,string userID,string editType)
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "insert into WMS_PUB_KCTW_His(WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,INUSE,TS,EDITUSER,EDITTYPE) (select WLH,PH,GG,PPRICE,FPRICE,TWZL,KCZL,INUSE,getdate() as TS,'" + userID + "' as edituser,'" + editType + "' as edittype from WMS_PUB_KCTW where WLH='" + WLH + "')";
            cmd2.ExecuteNonQuery();
        }
    }
}
