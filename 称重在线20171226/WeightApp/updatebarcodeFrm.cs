using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;
using System.IO;
using FastReport;
using System.Data.OracleClient;

namespace WeightApp
{
    public partial class updatebarcodeFrm : Form
    {

        private TfrxReportClass Report;

        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private int _pclx;

        public int Pclx
        {
            get { return _pclx; }
            set { _pclx = value; }
        }

        private string _produceData;

        public string ProduceData
        {
            get { return _produceData; }
            set { _produceData = value; }
        }

        private string _sx;

        public string Sx
        {
            get { return _sx; }
            set { _sx = value; }
        }
        private string _pch;

        public string Pch
        {
            get { return _pch; }
            set { _pch = value; }
        }

        private string _zxbz;


        public string Zxbz
        {
            get { return _zxbz; }
            set { _zxbz = value; }
        }
        private string _pcinfo;

        public string Pcinfo
        {
            get { return _pcinfo; }
            set { _pcinfo = value; }
        }

        private string _jz;

        public string Jz
        {
            get { return _jz; }
            set { _jz = value; }
        }

        public updatebarcodeFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            string wlh,wgdh,ph,gg,pch,jz,rq,bb,gh,bz,xlh,tm,zldj,wlmc,pcInfo;
            Boolean bck;
            DataSet qry;
            string ysx;

            int ygh,iType;
            Boolean ckznxflag;//出口转内销标志
            bool nxzckflag;//内销转出口标志
            string ypch,ckcxh,sx;
            bool zjbxflag;//出口转内销取联产品标志
            int inum;
            string barcode,ProduceData,errSeason;
            int yckcxh;

            string heatid = "", liaohao = "";

            inum = 0;
            if (PrintPCInfoCheckBox.Checked)
                iType = 3;
            else iType = 1;

            bck = false;

            errSeason = comBHG.Text;

            qry = DbEntry.Context.ExecuteDataset("select * from WMS_Bms_Inv_Info where barcode='"+_barcode+"'");
            barcode = createbarcode(_barcode);

            ygh = int.Parse(qry.Tables[0].Rows[0]["gh"].ToString());
            ysx = qry.Tables[0].Rows[0]["sx"].ToString();
            ProduceData = qry.Tables[0].Rows[0]["ProduceData"].ToString();
            yckcxh = int.Parse(qry.Tables[0].Rows[0]["ckcxh"].ToString() == "" ? "0" : qry.Tables[0].Rows[0]["ckcxh"].ToString());
            tm = barcode;

            sqlstr = "select count(1) as cksl from WMS_Bms_Inv_Info where gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') + " and gh<>" + ygh.ToString() +
                " and pch='" + _pch + "'";
            qry = DbEntry.Context.ExecuteDataset(sqlstr);

            inum = int.Parse(qry.Tables[0].Rows[0]["cksl"].ToString());

            if (inum >= 1)
            {
                MessageBox.Show("该钩号在本批次中已经使用！");
                return;
            }

            if (ygh != SpinEdit1.Value)
            {
                sqlstr = "select * from WMS_Bms_Rec_WGD_PaoGou where gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') + " and scx='" + Public.userdd + "'";
                qry = DbEntry.Context.ExecuteDataset(sqlstr);
                if (qry.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("该钩号跑钩！");
                    return;
                }
            }
            ckznxflag = false;
            nxzckflag = false;

            if (ysx == "CK" && cmbsx.Text != "CK")
            {
                ckznxflag = true;
            }
            if (ysx != "CK" && cmbsx.Text == "CK")
                nxzckflag = true;
            if (Pclx == 1) bck = true;
            if (MessageBox.Show("是否保存修改重新打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            sx = GetXCSX();
            bck = sx == "CK";

            sqlstr = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper)"+
                " values('"+tm+"',0,'"+sx+"','"+SpinEdit1.Value.ToString().PadLeft(2,'0')+"',0,'"+_sx+"','"+ygh+"','标牌修改','"+Public.userno+"')";


            bz = GetZXBZ(_pch,lbpcsx.Text,sx);
            try
            {
                DbEntry.UsingTransaction(delegate()
                {
                    if (ckznxflag)
                    {

                        sqlstr = "update WMS_Bms_Inv_Info set ProduceData='" + maskedit1.Text + "',barcode='" + barcode + "',gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') +
                            ",ckcxh=0,wlh=(select wlh from WMS_Bms_Rec_WGD_Item where ZJBXBZ=1 and pch='" + _pch + "'),sx='" + sx + "',errseason='" + errSeason + "'," +
                            " gg=(select gg from WMS_Bms_Rec_WGD_Item where ZJBXBZ=1 and pch='" + _pch +
                            "' ),ph=(select ph from WMS_Bms_Rec_WGD_Item where ZJBXBZ=1 and pch='" + _pch +
                            "'),wlmc=(select wlmc from WMS_Bms_Rec_WGD_Item where ZJBXBZ=1 and pch='" + _pch + "') where barcode='" + _barcode + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                    }
                    else if (nxzckflag)
                    {
                        sqlstr = "update WMS_Bms_Inv_Info set ProduceData='" + maskedit1.Text + "',barcode='" + barcode + "',gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') +
                             ",ckcxh=" + SpinEdit2.Value.ToString() + ",wlh=(select wlh from WMS_Bms_Rec_WGD where ZJBXBZ=1 and pch='" + _pch + "'),sx='" + sx +
                             "',errseason='" + errSeason + "'," +
                             " gg=(select gg from WMS_Bms_Rec_WGD where ZJBXBZ=1 and pch='" + _pch +
                             "' ),ph=(select ph from WMS_Bms_Rec_WGD where ZJBXBZ=1 and pch='" + _pch +
                             "'),wlmc=(select wlmc from WMS_Bms_Rec_WGD where ZJBXBZ=1 and pch='" + _pch + "') where barcode='" + _barcode + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                    }
                    else
                    {
                        sqlstr = "update wms_bms_inv_info set producedata='" + maskedit1.Text + "',barcode='" + barcode + "',ckcxh=" + SpinEdit2.Value.ToString() +
                            ",errseason='" + errSeason + "',gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') + ",sx='" + sx + "' where barcode='" + _barcode + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！");
                return;
            }
            if (lbpcsx.Text == "CK" && cmbsx.Text == "CK")
            {
                bck = true;
                sqlstr = "select ckcxh from wms_bms_rec_wgd_ckcxh where scx='" + Public.userdd + "'";
                qry = DbEntry.Context.ExecuteDataset(sqlstr);
                xlh = qry.Tables[0].Rows[0]["ckcxh"].ToString();
            }
            else if (lbpcsx.Text == "DP" && cmbsx.Text == "CK")
            {
                sqlstr = "select ckcxh from WMS_Bms_Rec_WGD_CKCXH where scx='" + Public.userdd + "'";
                qry = DbEntry.Context.ExecuteDataset(sqlstr);
                xlh = qry.Tables[0].Rows[0]["ckcxh"].ToString();
            }
            sqlstr = "select * from WMS_Bms_Inv_Info where pch='" + _pch + "' and gh=" + SpinEdit1.Value.ToString().PadLeft(2,'0') ;

            qry = DbEntry.Context.ExecuteDataset(sqlstr);

            DataRow dr = qry.Tables[0].Rows[0];

            gh = SpinEdit1.Value.ToString().PadLeft(2,'0');
            ph = dr["ph"].ToString();
            gg = dr["gg"].ToString();
            pch = _pch;
            jz = _jz;
            rq = dr["producedata"].ToString();
            bb = dr["bb"].ToString();
            bz = dr["bz"].ToString();
            tm = dr["barcode"].ToString();
            sx = dr["sx"].ToString();
            if (sx == "CK")
            {
                xlh = dr["ckcxh"].ToString();
                bck = true;
            }
            else
            {
                xlh = tm.Substring(9, 2);
                bck = false;
            }
            wlh = dr["wlh"].ToString();

            //2017-05-11 开始修改
            DataSet dsprintpch = null;
            DataRow drpch = null;
            dsprintpch = DbEntry.Context.ExecuteDataset("select * from WMS_Bms_Rec_WGD where pch='" + pch + "'");
            if (dsprintpch == null || dsprintpch.Tables.Count == 0 || dsprintpch.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("批次不存在！");
                
                return;
            }

            drpch = dsprintpch.Tables[0].Rows[0];
            if ((drpch["wcbz"].ToString() == "2") && (drpch["pgbz"].ToString() == "0"))
            {
                MessageBox.Show("已结束！");
               
                return;
            }

            //vfree0 炉号为空 则向nc查询
             heatid = drpch["vfree0"].ToString();
             liaohao = drpch["vfree4"].ToString();

             if (heatid == "")
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
                 DataSet ds = new DataSet();
                 oradap.Fill(ds);
                 conn.Close();
                 if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                 {
                     if (MessageBox.Show("该批次在NC中查不到炉号！是否打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                     {
                            return;
                     }

                 }
                 else
                 {
                     heatid = ds.Tables[0].Rows[0]["billet_heat_number"].ToString();
                     liaohao = ds.Tables[0].Rows[0]["customer_material_number"].ToString();
                     
                 }

             }
  

            if ((cmbsx.Text.ToString().Trim() != "AAA") && (cmbsx.Text.ToString().Trim() != "AA") && (cmbsx.Text.ToString().Trim() != "A") && (cmbsx.Text.ToString().Trim() != "CK"))
            {
                liaohao = "";
            }



            printpq(ph, gg, pch, jz, rq, bb, gh, bz, xlh, tm, sx, _pcinfo, bck, iType.ToString(), wlh,heatid,liaohao);
            this.DialogResult = DialogResult.OK;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GetZXBZ(string pch, string pcsx, string xcsx)
        {
            string ret = "";
            string sqlstr = "";
            if (_pclx == 0) sqlstr = "select zxbz from WMS_Bms_Rec_WGD_Item where pch='"+_pch+"'";
            else sqlstr = "select zxbz from WMS_Bms_Rec_WGD where pch='"+_pch+"'";

            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);

            ret = ds.Tables[0].Rows[0]["zxbz"].ToString();
            return ret;
        }
        private string createbarcode(string barcode)
        {
            DataSet ds = null;
            string sqlstr = "select pch,gh from wms_bms_inv_info where barcode='"+barcode+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            return barcode.Substring(0, 11) + SpinEdit1.Value.ToString().PadLeft(2, '0');
        }
        private bool checkwgditem(string pch)
        {
            DataSet ds = null;
            string sqlstr = "select * from wms_bms_rec_wgd_item where pch='"+pch+"' and zjbxbz=1";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds.Tables[0].Rows.Count > 0) return true;
            else return false;
        }
        private void inisx(string pch)
        {
            DataSet ds = null;
            string pcsx;
            string ph;
            string wlh;
            string sqlstr="select * from wms_bms_rec_wgd where pch='"+pch+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            pcsx = ds.Tables[0].Rows[0]["pcsx"].ToString();
            lbpcsx.Text = pcsx;
            maskedit1.Text = _produceData;
            ph = ds.Tables[0].Rows[0]["ph"].ToString();
            wlh = ds.Tables[0].Rows[0]["wlh"].ToString();

            cmbsx.Items.Clear();
            string moSX = GetMrSX(pch);
            sqlstr = "SELECT * FROM WMS_PUB_CZSX WHERE PCSX='" + pcsx + "' and MRDJSX='" + moSX + "' ORDER BY PCSX,ORDERNUM";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmbsx.Items.Add(dr["DJSX"].ToString());
            }
            cmbsx.SelectedIndex = cmbsx.Items.IndexOf(_sx);
            SpinEdit2.Value = int.Parse(lbbarcode.Text.Substring(9, 2));
        }

        public string GetMrSX(string pch)
        {
            string sqlstr = "select zjbz,pcsx,pclx,isnull(filed1,'') as defsx,zpdjbz from " +
                    "WMS_Bms_Rec_WGD where pch='" + pch + "' and zjbz=1";
            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
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
                    DataSet dsr = DbEntry.Context.ExecuteDataset(sqlstrf);
                    if (dsr != null && dsr.Tables.Count > 0 && dsr.Tables[0].Rows.Count > 0)
                    {
                        return dsr.Tables[0].Rows[0]["sx"].ToString();
                    }
                    else return "A";
                }
            }
            else return "A";

        }

        private void updatebarcodeFrm_Load(object sender, EventArgs e)
        {
            lbbarcode.Text = this._barcode;
            DataSet ds = null;
            string sqlstr = "select * from WMS_Bms_Inv_Info where barcode='"+_barcode+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            SpinEdit1.Value = int.Parse(ds.Tables[0].Rows[0]["gh"].ToString());
            inisx(_pch);
            BindBHGR();
            if (Report == null)
                Report = new TfrxReportClass();
        }

        private string GetXCSX()
        {
            return cmbsx.Text;
        }
        private void printpq(string ph, string gg, string pch, string jz, string rq, string bb, string gh, string bz, string xlh, string tm, string sx, string pcxx, bool ckflg, string itype, string wlh,string heatid,string liaohao)
        {
            string scriptstr = "";
            DataSet ds = null;
            string sqlstr = "";
            Boolean nocheck = false;
            string printmodual;
            string stpath;
            string bzstr;
            string tct;
            string SX = cmbsx.Text;
            //if (SX == "") return;
            printmodual = Public.GetXmlValue("PrintModuleName");
            if (printmodual == "") printmodual = "标准模板";
            stpath = Application.StartupPath + "\\report\\" + printmodual + "\\";
            if (!Directory.Exists(stpath))
            {
                MessageBox.Show("标签模板不存在！", "系统提示");
                return;
            }
            if ((SX == "B2") || (SX == "C2"))
            {
                nocheck = false;
            }
            else nocheck = true;
            scriptstr = "begin" + "\r\n";
            if (SX == "CK")
            {
                Report.LoadReportFromFile(stpath + "ckcz.fr3");
                scriptstr += "memspec.Text:='" + pcxx + "';";
                if (PrintPCInfoCheckBox.Checked)
                {
                    scriptstr += "memspec.visible:=true;";
                }
                else scriptstr += "memspec.visible:=false;";
            }
            else
            {
                switch (itype)
                {
                    case "1":
                        Report.LoadReportFromFile(stpath + "ptcz1.fr3");
                        break;
                    case "2":
                        Report.LoadReportFromFile(stpath + "ptcz2.fr3");
                        scriptstr += "memosx.text:='" + sx.Substring(0, 3) + "';";
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
                    case "3":
                        Report.LoadReportFromFile(stpath + "ptcz3.fr3");
                        scriptstr += "memopcinfo.text:='" + pcxx + "';";
                        if (!nocheck)
                        {
                            scriptstr += "memopcinfo.visible:=false;";
                        }
                        else scriptstr += "memopcinfo.visible:=true;";
                        break;
                    case "4":
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
            //scriptstr += "memojhzt.text:='" + getjhzt(wlh) + "';";
            double fjz = Math.Round(float.Parse(jz) * 1000, 1);
            scriptstr += "memojz.text:='" + fjz.ToString() + " kg';";
            scriptstr += "memorq.text:='" + rq + "';";
            scriptstr += "memogh.text:='" + gh + "';";
            //string bbtemp = "";
            //if (bb == "甲班") bbtemp = "A";
            //if (bb == "乙班") bbtemp = "B";
            //if (bb == "丙班") bbtemp = "C";
            //if (bb == "丁班") bbtemp = "D";
            //scriptstr += "memobb.text:='" + bbtemp + "';";

            if (liaohao!= "")
            {
                string sql = " SELECT invinfo.WGDH FROM WMS_Bms_Inv_Info AS invinfo LEFT OUTER JOIN WMS_Bms_Rec_WGD AS wgd ON invinfo.PCH = wgd.PCH WHERE (invinfo.WLH = wgd.YWLH) AND (invinfo.vfree1 = wgd.vfree1) AND ";

                sql += "  (wgd.yvfree1 = wgd.vfree1) AND (invinfo.vfree2 = wgd.vfree2) AND  (wgd.yvfree2 = wgd.vfree2) AND (invinfo.vfree3 = wgd.vfree3) AND (wgd.yvfree3 = wgd.vfree3) AND (invinfo.SX IN ('AAA', 'AA', 'A', 'CK')) AND ";
                sql += " invinfo.barcode='" + lbbarcode.Text.Trim() + "'";
                DataSet dstable = DbEntry.Context.ExecuteDataset(sql);
                if ((dstable == null) || (dstable.Tables.Count == 0) || dstable.Tables[0].Rows.Count == 0)
                {
                    liaohao = "";
                }
            }

            if (liaohao != "")
            {

                scriptstr += "Memliao.text:='" + liaohao+ "';";
                scriptstr += "Memliao.visible:=true;";
                scriptstr += "memliao1.visible:=true;";
                scriptstr += "Lineliao.visible:=true;";
            }

            //修改添加 炉次 删除班别
            scriptstr += "memobb.text:='" + heatid + "';";


            if (SX != "CK")
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
            
            Report.PrintOptions.ShowDialog = false;
            Report.PrintOptions.Copies = con;

            try
            {
                Report.PrintReport();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("打印错误：" + ex.Message + ".请补打！");
            }

        }


        void BindBHGR()
        {
            comBHG.Items.Clear();
            if (!string.IsNullOrEmpty(this.cmbsx.Text))
            {
                string sqlstr = "select Reason from WMS_PUB_SX_HPReason where sx='" + this.cmbsx.Text + "' order by Reason";
                DataSet ds = null;
                try
                {
                    ds = DbEntry.Context.ExecuteDataset(sqlstr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取质量原因失败：" + ex.Message);
                    return;
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this.comBHG.Enabled = true;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        comBHG.Items.Add(dr["Reason"].ToString());
                    }
                    comBHG.SelectedIndex = 0;
                }
                else
                {
                    this.comBHG.Text = "";
                    this.comBHG.Enabled = false;
                }
            }
            else
                this.comBHG.Enabled = false;
        }

        private void cmbsx_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBHGR();
        }
    }
}