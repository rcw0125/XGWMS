using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;
using FastReport;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.OracleClient;

namespace WeightApp
{
    public partial class printBFrm : Form
    {
        public string portvalue; //串口
        public int baudRatevalue;//串口波特率
        public string fbytesize;
        public string fparity;
        public string fparitycheck;
        public string fstopbits;

        private string tablename;
        private string sqlQuery;

        delegate void SetWeight(string zl);
        SetWeight setWeightDel;

        double gpzlup = 1;//钢坯重量上限
        double gpzldown = 1;//钢坯重量下限
        double zldown;
        double zlup;
        double gpzl;//钢坯重量

        int star;//串口取数开始位置
        int end;//串口取数结束位置
        int dataLength;//取数长度
        int qsjg;//从串口取数间隔
        string strStartChar;//串口取数开始标志位
        
 
        public printBFrm()
        {
            InitializeComponent();
        }

        private void GetCKCS()
        {
            star = int.Parse(Public.GetXmlValue("DataStar").ToString());
            end = int.Parse(Public.GetXmlValue("DataEnd").ToString());
            dataLength = int.Parse(Public.GetXmlValue("DataLen"));//取数总长度
            strStartChar = Public.GetXmlValue("DataStarChar");//字符串开始长度
            qsjg = int.Parse(Public.GetXmlValue("QSJG"));//从串口取数时间间隔
        }

        private bool opencomm()
        {
            bool ret = false;
            try
            {
                if (!Public.openCom(serialPort1))
                {
                    MessageBox.Show("打开串口失败！");
                    this.btnCloseSeri.Text = "打开串口";
                    return false;
                }
                else
                {
                    this.btnCloseSeri.Text = "关闭串口";
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.btnCloseSeri.Text = "打开串口";
                MessageBox.Show("打开串口失败！" + ex.Message);
                return false;
            }
            return ret;

        }

        private void printBFrm_Load(object sender, EventArgs e)
        {
            try
            {
                GetCKCS();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            setWeightDel = new SetWeight(ShowWeight);
        }

        void ShowWeight(string strZl)
        {
            this.txtJZZL.Text = strZl;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(qsjg);
                Control.CheckForIllegalCrossThreadCalls = false;

                string ss = serialPort1.ReadExisting();
                int startInt = ss.IndexOf(strStartChar);
                string jqStar = ss.Substring(startInt, dataLength);
                string strResult = jqStar.Substring(star,end-star).Trim();
                if (!Regex.IsMatch(strResult, @"^[0-9]*$"))
                {
                    return;
                }
                this.Invoke(setWeightDel, strResult);
            }
            catch (Exception ex)
            {
                //txtError.Text += ex.Message + Environment.NewLine;
            }
        }

        private void btnCloseSeri_Click(object sender, EventArgs e)
        {
            if (this.btnCloseSeri.Text.Trim() == "打开串口")
            {
                if (Public.openCom(serialPort1))
                {
                    this.btnCloseSeri.Text = "关闭串口";
                    return;
                }
                else
                {
                    MessageBox.Show("打开串口失败");
                    this.btnCloseSeri.Text = "打开串口";
                    return;
                }
            }

            if (this.btnCloseSeri.Text == "关闭串口")
            {
                if (this.serialPort1.IsOpen)
                    this.serialPort1.Close();
                this.btnCloseSeri.Text = "打开串口";
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FrmBDSearch bdSearch = new FrmBDSearch();
            if (bdSearch.ShowDialog() == DialogResult.OK)
            {
                this.dgvData.AutoGenerateColumns = false;
                DataSet ds = DbEntry.Context.ExecuteDataset(bdSearch.SqlString);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    this.dgvData.DataSource = null;
                    ClearUI();
                    MessageBox.Show("没有查询结果！");
                    return;
                }
                tablename = bdSearch.TableName;
                sqlQuery=bdSearch.SqlString;
                this.dgvData.DataSource = ds.Tables[0];
            }
        }

        void ClearUI()
        {
            this.txtPH.Text = "";
            this.txtGG.Text = "";
            this.txtBC.Text = "";
            this.txtPCH.Text = "";
            this.txtZL.Text = "";
            this.txtDate.Text = "";
            this.txtBZ.Text = "";
            this.txtSX.Text = "";
            this.txtGH.Text = "";
            this.dataPickPdate.Text = "";
            this.txtLSH.Text = "";
            this.txtCKCXH.Text = "";
            this.txtJZZL.Text = "";

            this.txtPPH.Text = "";
            this.txtPGG.Text = "";
            this.txtPPCH.Text = "";
            this.txtPZL.Text = "";
            this.txtPGH.Text = "";
           
            this.txtPBZ.Text = "";
            this.txtPRQ.Text = "";
            this.txtPBAR.Text = "";

            this.txtheatid.Text = "";
            this.txtGgHeatid.Text = "";

            this.txtliaohao.Text = "";
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvData.SelectedRows[0];
                this.txtPH.Text = row.Cells[4].Value.ToString();
                this.txtGG.Text = row.Cells[7].Value.ToString();
                this.txtBC.Text = row.Cells[13].Value.ToString();
                this.txtPCH.Text=row.Cells[3].Value.ToString();
                this.txtZL.Text = Convert.ToDecimal(row.Cells[6].Value).ToString("f4");
                this.txtDate.Text=Convert.ToDateTime(row.Cells[14].Value).ToShortDateString();
                this.txtBZ.Text=row.Cells[8].Value.ToString();
                this.txtSX.Text = row.Cells[5].Value.ToString();
                this.txtGH.Text = row.Cells[1].Value.ToString();
                this.dataPickPdate.Text = Convert.ToDateTime(row.Cells[14].Value).ToShortDateString();
                this.txtLSH.Text = (row.Index+1).ToString();
                this.txtCKCXH.Text=row.Cells[12].Value.ToString();
               // this.txtJZZL.Text = (Convert.ToDecimal(row.Cells[6].Value) * 1000).ToString("f4");
                this.txtJZZL.Text=(Convert.ToDecimal(GetYZL(row.Cells[0].Value.ToString()))).ToString();
                this.txtPPH.Text = row.Cells[4].Value.ToString();
                this.txtPGG.Text = row.Cells[7].Value.ToString();
                this.txtPPCH.Text = row.Cells[3].Value.ToString();
                this.txtPZL.Text = Convert.ToDecimal(row.Cells[6].Value).ToString("f4");
                this.txtPGH.Text = row.Cells[1].Value.ToString();
                
                this.txtPBZ.Text = row.Cells[8].Value.ToString();
                this.txtPRQ.Text = Convert.ToDateTime(row.Cells[14].Value).ToShortDateString();
                this.txtPBAR.Text = row.Cells[0].Value.ToString();
                this.txtheatid.Text = row.Cells[15].Value.ToString();
                this.txtGgHeatid.Text = row.Cells[15].Value.ToString();
                this.txtliaohao.Text = row.Cells[16].Value.ToString();
            }
        }

        private double GetYZL(string barCode)
        {
            string strSele = "select * from WMS_Bms_Rec_Log_Print where barcode='" + barCode + "' order by usertime desc";
            DataSet ds = DbEntry.Context.ExecuteDataset(strSele);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return 0;
            else
                return Convert.ToDouble(ds.Tables[0].Rows[0]["ysmz"]);

        }

        //得到标准重量(去皮重量）
        private double getbzzl(string strwlh, string bzbz, double mz)
        {
            double result = 0;
            try
            {
                string sqlstr = "select count(1) as f from wms_pub_wlh_bzbz where wlh='" + strwlh + "' and bzbz='" + bzbz + "'";
                DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    result = Convert.ToDouble(ds.Tables[0].Rows[0]["f"]);
                }
                if (result != 0)
                {
                    string sqlSCX = "select * from WMS_Pub_SCX s where s.scxncid='" + Public.userdd + "'";
                    DataSet dsSCX = DbEntry.Context.ExecuteDataset(sqlSCX);
                    string strSXCBM = "";
                    if (dsSCX != null && dsSCX.Tables.Count > 0 && dsSCX.Tables[0].Rows.Count > 0)
                        strSXCBM = dsSCX.Tables[0].Rows[0]["SCXBM"].ToString();
                    if (string.IsNullOrEmpty(strSXCBM))
                        result = 0;
                    else
                    {
                        string strSQLZL = "select zl from wms_pub_bzbz where bzbz='" + bzbz + "' and scxbm='" + strSXCBM + "' and cast("+mz.ToString()+" as float)/1000>=zlmin and cast("+mz.ToString()+" as float)/1000<zlmax";
                        DataSet dsZL = DbEntry.Context.ExecuteDataset(strSQLZL);
                        //20180102修改
                        //if (dsZL != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        if (dsZL != null && dsZL.Tables.Count > 0 && dsZL.Tables[0].Rows.Count > 0)
                            result = Convert.ToDouble(dsZL.Tables[0].Rows[0]["zl"]);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }


        private double gettwzl(string strwlh)
        {
            double result = 0;
            try
            {

                string strSQLZL = "select kczl from WMS_Pub_KCTW where wlh='"+strwlh+"' and inuse=1";
                        DataSet dsZL = DbEntry.Context.ExecuteDataset(strSQLZL);
                        if (dsZL != null && dsZL.Tables.Count > 0 && dsZL.Tables[0].Rows.Count > 0)
                            result = Convert.ToDouble(dsZL.Tables[0].Rows[0]["kczl"]);
                        return result/1000;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }



        private void btnShit_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvData.DataSource == null)
            {
                MessageBox.Show("请先查询！");
                return;
            }
            if (this.dgvData.SelectedRows == null || this.dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要打印的信息!");
                return;
            }

            DataGridViewRow row = this.dgvData.SelectedRows[0];
           
            string ph,gg,pch,jz,rq,bb,gh,bz,xlh,tm,ErrSeason,psx;
            bool isckflag;
            int pchint,iType;
            double fjz,ffjz;
            
            if(this.txtPCH.Text.Length!=9)
            {
                MessageBox.Show("批次号位数不够");
                return;
            }
            jz=this.txtJZZL.Text.Trim();//输入的重量信息
            //如果是取原始重量
            if(this.chkYZL.Checked)
            {
                ffjz = Convert.ToDouble(this.txtZL.Text) * 1000;
                jz = ffjz.ToString();
            }
            else
            {
                //根据获得重量范围参数值
                getsysparam();
                //获取原始钢坯重量
                GetgpZL(row.Cells[3].Value.ToString());
                if (!IsCheckZL(Convert.ToDouble(jz)))//验证重量是否满足
                    return;
                //修改20180104
                //fjz = Convert.ToDouble(jz) / 1000 - getbzzl(row.Cells[2].Value.ToString(), row.Cells[11].Value.ToString(), Convert.ToDouble(this.txtJZZL.Text));
                fjz = Convert.ToDouble(jz) / 1000 - getbzzl(row.Cells[2].Value.ToString(), row.Cells[11].Value.ToString(), Convert.ToDouble(this.txtJZZL.Text)) - gettwzl(row.Cells[2].Value.ToString());
                jz=(fjz*1000).ToString();
            }

            if(string.IsNullOrEmpty(jz) || Convert.ToDouble(jz)==0)
            {
                this.txtJZZL.Text="000000";
                MessageBox.Show("重量错误!");
                return;
            }
           
            if(MessageBox.Show("打印信息是否确认无误,是否打印?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.No)
                    return;
            try
            {
                Public.WriteManLog(row.Cells[0].Value.ToString(),Convert.ToDouble(jz),this.txtSX.Text,Convert.ToInt32(this.txtGH.Text),Convert.ToDouble(this.txtZL.Text),this.txtSX.Text,Convert.ToInt32(this.txtGH.Text),"标牌补打",Public.userno);
                string strq="update "+tablename+" set zl="+(Convert.ToDouble(jz)/1000).ToString()+" where barcode='"+row.Cells[0].Value.ToString()+"'";
                DbEntry.Context.ExecuteNonQuery(strq);
                row.Cells[6].Value=(Convert.ToDouble(jz)/1000).ToString();
                if (this.chkYZL.Checked == false)
                {
                    string upYS = "update WMS_Bms_Rec_Log_Print set ysmz=" + this.txtJZZL.Text + ",usertime=getdate() where barcode='" + row.Cells[0].Value.ToString() + "'";
                    DbEntry.Context.ExecuteNonQuery(upYS);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误："+ex.Message);
                return;
            }
            if(this.numTxt.Value<=0)
                return;
            printpq(row.Cells[0].Value.ToString(),jz);
            
            //if (this.WindowState == FormWindowState.Minimized)
            //    this.WindowState = FormWindowState.Normal;
            //Thread.Sleep(1000);
            //this.Activate();
        }
        //获取生产线配置信息
        private void getsysparam()
        {
            string sqlstr = "select * from WMS_Pub_SCX where SCXNCID='" + Public.userdd + "'";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            DataRow dr = ds.Tables[0].Rows[0];

            if (string.IsNullOrEmpty(dr["GPZLUP"].ToString()))
                gpzlup = 0;
            else
                gpzlup = double.Parse(dr["GPZLUP"].ToString());
            if (string.IsNullOrEmpty(dr["GPZLDOWN"].ToString()))
                gpzldown = 0;
            else
                gpzldown = double.Parse(dr["GPZLDOWN"].ToString());
            if (string.IsNullOrEmpty(dr["zlxx"].ToString()))
                zldown = 0;
            else
                zldown = double.Parse(dr["zlxx"].ToString());
            if (string.IsNullOrEmpty(dr["zlsx"].ToString()))
                zlup = 0;
            else
                zlup = double.Parse(dr["zlsx"].ToString());
           
        }

        private void GetgpZL(string pch)
        {
            string sql = "select * from WMS_Bms_Rec_WGD where pch='" + pch + "'";
            DataSet ds = DbEntry.Context.ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                gpzl = 0;
            }
            else
                gpzl = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["GPZL"].ToString()) ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["GPZL"].ToString());
        }

        private bool IsCheckZL(double jzzl)
        {
            if (zlup != 0 && zldown != 0)
            {
                if (jzzl > zlup || jzzl < zldown)//大于上限，小于下限不允许打印
                {
                    MessageBox.Show("重量超出线材重量允许值范围，不能打印，如要打印，请先联系生产主管修改范围参数！");
                    return false;
                }
            }
            if (gpzlup != 0 && gpzldown != 0)
            {
                if (gpzl != 0)
                {
                    double blUp = gpzl * 1000 * gpzlup;
                    double blDown = gpzl * 1000 * gpzldown;
                    if ((jzzl > blUp && jzzl <= zlup) || (jzzl < blDown) && jzzl >= zldown)
                    {
                        if (MessageBox.Show("重量超出钢坯重量倍率允许值范围！但未超过线材重量允许范围，是否打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                            return false;
                        else
                            return true;
                    }
                }
            }
            return true;
        }

        private void printpq(string barcode,string strJz)
        {
            string scriptstr = "";
            string ph, gg, pch, jz, rq, bb, gh, bz, xlh, tm, ckcxh, sx, pcxx, bzstr, bbtemp, printmodual, stpath, tct, wlh;
            bool ckflg, nocheck;
            int iType;

            if (chkTSXX.Checked)
            {
                if (chkCPDJ.Checked)
                    iType = 4;
                else
                    iType = 3;
            }
            else
            {
                if (chkCPDJ.Checked)
                    iType = 2;
                else
                    iType = 1;
            }
            printmodual = Public.GetXmlValue("PrintModuleName");
            if (printmodual == "") printmodual = "标准模板";
            stpath = Application.StartupPath + "\\report\\" + printmodual + "\\";
            if (!Directory.Exists(stpath))
            {
                MessageBox.Show("标签模板不存在！", "系统提示");
                return;
            }


            
      


            string strSql = "select * from " + tablename + " where barcode='" + barcode.Trim() + "'";
            DataSet ds = DbEntry.Context.ExecuteDataset(strSql);
            ph = ds.Tables[0].Rows[0]["PH"].ToString();
            gg = ds.Tables[0].Rows[0]["GG"].ToString();
            pch = ds.Tables[0].Rows[0]["PCH"].ToString();
            jz = strJz;
            rq = ds.Tables[0].Rows[0]["ProduceData"].ToString();
            bb = ds.Tables[0].Rows[0]["bb"].ToString();
            pcxx = ds.Tables[0].Rows[0]["pcinfo"].ToString();
            gh = Convert.ToInt32(ds.Tables[0].Rows[0]["gh"]).ToString().PadLeft(2, '0');
            sx = ds.Tables[0].Rows[0]["SX"].ToString();
            if (sx.ToUpper() == "CK")
                bz = ds.Tables[0].Rows[0]["GH"].ToString().PadLeft(2, '0');
            else
                bz = ds.Tables[0].Rows[0]["bz"].ToString();
            xlh = this.txtLSH.Text;
            tm = barcode;
            wlh = ds.Tables[0].Rows[0]["wlh"].ToString();
            ckcxh = ds.Tables[0].Rows[0]["ckcxh"].ToString();

            if ((sx == "B2") || (sx == "C2"))
            {
                nocheck = false;
            }
            else nocheck = true;

            TfrxReportClass Report = new TfrxReportClass();
            scriptstr = "begin" + "\r\n";
            if (sx == "CK")
            {
                Report.LoadReportFromFile(stpath + "ckcz.fr3");
                scriptstr += "memspec.Text:='" + pcxx + "';";
                if (this.chkTSXX.Checked)
                {
                    scriptstr += "memspec.visible:=true;";
                }
                else scriptstr += "memspec.visible:=false;";
            }
            else
            {
                switch (iType)
                {
                    case 1:
                        Report.LoadReportFromFile(stpath + "ptcz1.fr3");
                        break;
                    case 2:
                        Report.LoadReportFromFile(stpath + "ptcz2.fr3");
                        scriptstr += "memosx.text:='" + sx + "';";
                        if (!nocheck)
                        {
                            scriptstr += "memosx.visible:=false;";
                            scriptstr += "Shape1.visible:=false;";
                        }
                        else
                        {
                            scriptstr += "memosx.visible:=true;";
                            scriptstr += "Shape1.visible:=true;";
                        }
                        break;
                    case 3:
                        Report.LoadReportFromFile(stpath + "ptcz3.fr3");
                        scriptstr += "memopcinfo.text:='" + pcxx + "';";
                        if (!nocheck)
                        {
                            scriptstr += "memopcinfo.visible:=false;";
                        }
                        else scriptstr += "memopcinfo.visible:=true;";
                        break;
                    case 4:
                        Report.LoadReportFromFile(stpath + "ptcz4.fr3");
                        scriptstr += "memopcinfo.text:='" + pcxx + "';";
                        if (!nocheck)
                        {
                            scriptstr += "memopcinfo.visible:=false;";
                            scriptstr += "Shape1.visible:=false;";
                        }
                        else
                        {
                            scriptstr += "memopcinfo.visible:=true;";
                            scriptstr += "Shape1.visible:=true;";
                        }
                        break;
                }
            }

            scriptstr += "Barcode1.text:='" + tm + "';";
            scriptstr += "memoph.text:='" + ph + "';";
            scriptstr += "memogg.text:='" + gg + "';";
            scriptstr += "memopch.text:='" + pch + "';";
            double fjz = Convert.ToDouble(jz); ;
            scriptstr += "memojz.text:='" + fjz.ToString() + " kg';";
            scriptstr += "memorq.text:='" + rq + "';";
            scriptstr += "memogh.text:='" + gh + "';";
            //bbtemp = "";
            //if (bb == "甲班") bbtemp = "A";
            //if (bb == "乙班") bbtemp = "B";
            //if (bb == "丙班") bbtemp = "C";
            //if (bb == "丁班") bbtemp = "D";
            //scriptstr += "memobb.text:='" + bbtemp + "';";

            //如果炉号为空，则再次查询nc
            if (txtheatid.Text.Trim() == "")
            {
                string loadSql = "";
                loadSql += "select mm_wr_b.pch,getbilletbatchcode(mm_wr_b.pch) billet_heat_number,";
                loadSql += " mm_po.xsddh customer_material_number";
                loadSql += " from mm_wr_b mm_wr_b, mm_mo mm_mo, mm_mosource mm_mosource, mm_po mm_po";
                loadSql += "  where mm_wr_b.scddid = mm_mo.pk_moid and mm_mo.pk_moid = mm_mosource.scddid";
                loadSql += "  and mm_mosource.lyid = mm_po.pk_poid  and mm_po.pk_corp = '1001'";
                loadSql += " and mm_po.dr = 0  and mm_mosource.pk_corp = '1001' and mm_mosource.dr = 0 ";
                loadSql += "  and mm_mo.pk_corp = '1001' and mm_mo.dr = 0 and mm_wr_b.pk_corp = '1001'";
                loadSql += "  and mm_wr_b.dr = 0  and mm_wr_b.pch = '" + pch + "'";
                //OracleConnection conn = new OracleConnection("Data Source=192.168.2.221/orcl;User ID=nctest;Password=nctest;");

                //OracleConnection conn = new OracleConnection("Data Source=nctest;User ID=nctest;Password=nctest;");
                OracleConnection conn = new OracleConnection("Data Source=ncv5;User ID=xgerp50;Password=xgerp204212350;");
                conn.Open();
                OracleCommand selectCmd = conn.CreateCommand();
                selectCmd.CommandText = loadSql;
                // selectCmd.BindByName = true;

                OracleDataAdapter oradap = new OracleDataAdapter(selectCmd);
                DataSet ds1 = new DataSet();
                oradap.Fill(ds1);
                conn.Close();
                if (ds1 == null || ds1.Tables.Count == 0 || ds1.Tables[0].Rows.Count == 0)
                {                

                }
                else
                {
                    txtheatid.Text = ds1.Tables[0].Rows[0]["billet_heat_number"].ToString();
                    txtGgHeatid.Text = ds1.Tables[0].Rows[0]["billet_heat_number"].ToString();
                    txtliaohao.Text = ds1.Tables[0].Rows[0]["customer_material_number"].ToString();

                }

            }


            //库内补打 料号判断  异常情况料号置空
            if ((txtliaohao.Text.ToString().Trim() != "") && (tablename == "WMS_Bms_Inv_Info"))
            {
                string  sql=" SELECT invinfo.WGDH FROM WMS_Bms_Inv_Info AS invinfo LEFT OUTER JOIN WMS_Bms_Rec_WGD AS wgd ON invinfo.PCH = wgd.PCH WHERE (invinfo.WLH = wgd.YWLH) AND (invinfo.vfree1 = wgd.vfree1) AND ";
      
                sql+="  (wgd.yvfree1 = wgd.vfree1) AND (invinfo.vfree2 = wgd.vfree2) AND  (wgd.yvfree2 = wgd.vfree2) AND (invinfo.vfree3 = wgd.vfree3) AND (wgd.yvfree3 = wgd.vfree3) AND (invinfo.SX IN ('AAA', 'AA', 'A', 'CK')) AND ";
                sql+=" invinfo.barcode='" + barcode.Trim() + "'";
                DataSet dstable = DbEntry.Context.ExecuteDataset(sql);
                if ((dstable == null) ||(dstable.Tables.Count ==0) || dstable.Tables[0].Rows.Count == 0)
                {
                    txtliaohao.Text = "";
                }
            }

            if (txtliaohao.Text.ToString().Trim() != "")
            {

                scriptstr += "Memliao.text:='" + txtliaohao.Text.ToString().Trim() + "';";
                scriptstr += "Memliao.visible:=true;";
                scriptstr += "memliao1.visible:=true;";
                scriptstr += "Lineliao.visible:=true;";
            }

            //修改添加 炉次 删除班别
            scriptstr += "memobb.text:='" + txtheatid.Text.ToString().Trim() + "';";


            if (sx != "CK")
            {
                string bzstrf = "";
                bzstrf = bz.Substring(bz.IndexOf('~') + 1);
                scriptstr += "memobz.text:='" + bzstrf + "';";
            }
            else
            {
                scriptstr += "memoxlh.text:='" + xlh + "';";
            }
            scriptstr += "memowlh.text:='" + wlh.Substring(0, 3) + "';";
            scriptstr += "end.";
            Report.ScriptText = scriptstr;
            Report.PrepareReport(true);
            int con = 2;
            if (this.numTxt.Value > 0)
            {
                con = int.Parse(numTxt.Value.ToString());
            }
            Report.PrintOptions.ShowDialog = false;
            Report.PrintOptions.Copies = con;
            try
            {
                if (this.chkBowse.Checked)
                {
                    Report.ShowReport();
                }
                else
                {
                    Report.PrintReport();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("打印错误：" + ex.Message + ".请补打！");
            }
        }

        private void btnPrintBatch_Click(object sender, EventArgs e)
        {
            if (this.dgvData.DataSource == null)
                return;
            DataTable dt = this.dgvData.DataSource as DataTable;
            if (dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        //(Convert.ToDouble(row["zl"].ToString()) * 1000).ToString();
                        //printpq(row["Barcode"].ToString(),row["zl"].ToString());
                        printpq(row["Barcode"].ToString(), (Convert.ToDouble(row["zl"].ToString()) * 1000).ToString());
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void printBFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.serialPort1.IsOpen)
            {
                this.serialPort1.Close();
            }
        }

        private void btnHeatid_Click(object sender, EventArgs e)
        {
            if (txtGgHeatid.Text.Trim() == txtheatid.Text.Trim())
            {
                MessageBox.Show("请更改炉号后再操作");
                return;
            }

            if (txtGgHeatid.Text.Trim().Length != 9)
            {
                MessageBox.Show("请检查炉号是否正确后再操作");
                return;
            }

            addheatid(txtGgHeatid.Text.Trim(), txtPCH.Text.Trim());
            txtheatid.Text = txtGgHeatid.Text.Trim();


        }


        public void addheatid(string heatid, string pch)
        {
            try
            {
                string sqlstr = "update  WMS_Bms_Rec_WGD set  vfree0='" + heatid + "' where pch='" + pch + "'";
                DbEntry.Context.ExecuteNonQuery(sqlstr);
            }
            catch
            {
                MessageBox.Show("写入失败");

            }

        }
    }
}