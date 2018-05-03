using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;
using System.Threading;
using System.IO;
using FastReport;
using System.Text.RegularExpressions;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
//using Oracle.DataAccess.Client;
using System.Data.OracleClient;


namespace WeightApp
{
    public partial class frmWeight : Form
    {
        public frmWeight()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前静核稳定等待次数
        /// </summary>
        int curtime = 0;

        bool bOpen;
        public short DiValue;
        int DeviceHandle;
        int barcodenumber;

        DataSet dsbarcode = null;
        string ywlh;
        string ywlmc;
        string yzxbz;
        string ypcinfo;
        string yvfree0;
        string yvfree1;
        string yvfree2;
        string yvfree3;
        string yph;
        string ygg;
        bool isenter;

        string curwlmc, gpyy,curzxbz, curwlh, curpcinfo, curvfree0, curvfree1, curvfree2, curvfree3;
        /// <summary>
        /// 跑钩处理之前发运单号
        /// </summary>
        string yfpgpch;
        /// <summary>
        /// 当前批次号
        /// </summary>
        string curPch;
        double zerolow;
        double zerohight;
        bool errorflag;
        /// <summary>
        /// 窗口取数状态
        /// </summary>
        bool commstatus;
        /// <summary>
        /// 上升到位
        /// </summary>
        bool upflag;
        /// <summary>
        /// 下降到位
        /// </summary>
        bool downflag;
        /// <summary>
        /// 零点状态
        /// </summary>
        string zeroFlag;
        string upPrint;

        /// <summary>
        /// 是否改判
        /// </summary>
        bool gpflag;

        /// <summary>
        /// 自动取数标志参数
        /// </summary>
        bool AutoGetWeightFlag; 

        /// <summary>
        /// 自动取数时间参数
        /// </summary>
        int AutoGetWeightNum;  

        int jhcsKg;
        int jhcsS;
        int uptime = 100;

        /// <summary>
        /// 静荷次数
        /// </summary>
        int jhcs;

        /// <summary>
        /// 静荷的初始
        /// </summary>
        int zerocs;

        /// <summary>
        /// 判断静荷的中间变量
        /// </summary>
        string ssold;

        /// <summary>
        /// 静荷状态
        /// </summary>
        bool jistatus;

        /// <summary>
        /// 串口取数开始位置
        /// </summary>
        int star;
        /// <summary>
        /// 串口取数结束位置
        /// </summary>
        int end;
        /// <summary>
        /// 取数长度
        /// </summary>
        int dataLength;
        /// <summary>
        /// 从串口取数间隔
        /// </summary>
        int qsjg;
        /// <summary>
        /// 串口取数开始标志位
        /// </summary>
        string strStartChar;
        int jhwdcs;
        

        int x;
        int y;
        /// <summary>
        /// 钢坯重量上限
        /// </summary>
        double gpzlup = 1;
        /// <summary>
        /// 钢坯重量下限
        /// </summary>
        double gpzldown = 1;
        double zldown;
        double zlup;
        /// <summary>
        /// 钢坯重量
        /// </summary>
        double gpzl;
        //修改添加20170527
        private bool oldUpFlag;
        private StaticWeight curStaticWeight;
        private List<StaticWeight> upStaticWeights = new List<StaticWeight>();
        private bool downjistatus;
        private int downzerocs;
        private Dictionary<DateTime, double> valRecord = new Dictionary<DateTime, double>();

        private delegate void SetZLDel(string ss,int type);
        SetZLDel zlTextDel;

        private delegate void SetUpSinge();//设置上下到位代理在TIMER中执行
        SetUpSinge timeSetUpSinge;

        private TfrxReportClass Report;

        /// <summary>
        /// 获取属性列表
        /// </summary>
        public void GetSX()
        {
            cmbSX.Items.Clear();
            string sqlstr = "select * from WMS_PUB_SXSET WHERE ISBATCH='Y' order by SX";
            if (!string.IsNullOrEmpty(lbpcsx.Text))
            {
                string moSX = GetMrSX(this.cmbph.Text);
                sqlstr = "SELECT * FROM WMS_PUB_CZSX WHERE PCSX='" + lbpcsx.Text + "' and MRDJSX='"+moSX+"' ORDER BY PCSX,ORDERNUM";
            }
            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if(!string.IsNullOrEmpty(lbpcsx.Text))
                        cmbSX.Items.Add(dr["DJSX"].ToString());
                    else
                        cmbSX.Items.Add(dr["SX"].ToString());
                }
                if(cmbSX.Items!=null && cmbSX.Items.Count>0)
                    cmbSX.SelectedIndex = 0;
                GetZlYY(cmbSX.Text);
            }

            //cmbSX.();
        }

        private string GetMrSX(string pch)
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
                    else//非待检返回批次属性默认值
                    {
                        sqlstr = "select * from WMS_PUB_CZSX where PCSX='"+pcsx+"'";
                        ds = DbEntry.Context.ExecuteDataset(sqlstr);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            return ds.Tables[0].Rows[0]["MRDJSX"].ToString();
                        return "A";
                    }
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
        
        
        /// <summary>
        /// 根据选择的属性获取质量原因
        /// </summary>
        /// <param name="sx"></param>
        private void GetZlYY(string sx)
        {
            cmbZLYY.Items.Clear();
            cmbZLYY.Enabled = true;
            string sqlstr = "select Reason from WMS_PUB_SX_HPReason where sx='" + sx + "' order by Reason";
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
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmbZLYY.Items.Add(dr["Reason"].ToString());
                }
                cmbZLYY.SelectedIndex = 0;
            }
            else
                cmbZLYY.Enabled = false;
        }

        //获取串口取数相关参数
        private void GetCKCS()
        {
            star = int.Parse(Public.GetXmlValue("DataStar").ToString());
            end = int.Parse(Public.GetXmlValue("DataEnd").ToString());
            dataLength = int.Parse(Public.GetXmlValue("DataLen"));//取数总长度
            strStartChar = Public.GetXmlValue("DataStarChar");//字符串开始长度
            qsjg = int.Parse(Public.GetXmlValue("QSJG"));//从串口取数时间间隔
            jhwdcs = int.Parse(Public.GetXmlValue("DataEndChar"));//静荷稳定次数

            opencomm();//打开串口
        }

        private void frmWeight_Load(object sender, EventArgs e)
        {
            jhcs = int.Parse(Public.GetXmlValue("JHCS"));
            x = Screen.PrimaryScreen.Bounds.Width;
            y = Screen.PrimaryScreen.Bounds.Height;
            if((x!=800)&&(y!=600))
               ResolutionX.ChangeRes(800,590);

            GetCKCS();//获取窗口参数
            getsysparam();//获取生产线相关参数，高低重量限制
            label54.Text = "操作员：" + Public.userno;
            this.Text = "称重----当前生产线：" + Public.userdd;
            lbckrq.Text = DateTime.Now.ToString("yyyy.MM.dd");
            lbptrq.Text = DateTime.Now.ToString("yyyy.MM.dd");
            dtpscrq.Value = DateTime.Now;

            if (upPrint=="1") //如果启用上升到位控制打印
            {
                timeSetUpSinge = new SetUpSinge(SetUpDownSing);
                if (getPCLA())//获取开关量
                {
                    timerup.Interval = uptime;
                    timerup.Enabled = true;
                }
                else timerup.Enabled = false;
            }
            if (AutoGetWeightFlag)
            {
                lblAutoGetWeight.Visible = true;
                lblAutoGetWeight.Text = "0";
                curtime = 0;
            }
            else
            {
                label32.Visible = false;
                lblAutoGetWeight.Visible = false;
            }
            zlTextDel = new SetZLDel(SetTextZl);//设置自动取数相关代理

            try
            {
                getWgdPc();
            }
            catch (Exception ex)
            {
                errorflag = true;
                return;
            }
            Report = new TfrxReportClass();
        }

        //在串口取数后设置窗体控件元素 新添加
        private void SetTextZl2(string ss, int type)
        {
            if (type == 2)
            {
                this.lblCKError.Visible = true;
                this.lblCKError.Text = ss;
            }
            if (type == 3)
            {
                double num = Convert.ToDouble(ss);
                this.lblCKError.Visible = false;
                this.jistatus = false;
                this.edtzl.Text = ss;
                if (this.curtime == 0)
                {
                    this.lblAutoGetWeight.Text = ss;
                    this.lblAutoGetWeight.ForeColor = Color.Black;
                }
                if (this.upflag)
                {
                    if (!this.oldUpFlag)
                    {
                        this.valRecord.Clear();
                        this.label32.ForeColor = Color.Black;
                    }
                    this.valRecord.Add(DateTime.Now, num);
                    if (ss == this.ssold)
                    {
                        if (this.curStaticWeight == null)
                        {
                            this.curStaticWeight = new StaticWeight();
                        }
                        this.curStaticWeight.IncNum();
                        if (this.curStaticWeight.num >= this.jhcs)
                        {
                            this.jistatus = true;
                            if (!this.curStaticWeight.inCollection)
                            {
                                this.curStaticWeight.beginTime = DateTime.Now;
                                this.upStaticWeights.Add(this.curStaticWeight);
                                this.curStaticWeight.inCollection = true;
                            }
                        }
                        this.curStaticWeight.val = num;
                    }
                    else
                    {
                        this.curStaticWeight = null;
                    }
                }
                else if (this.oldUpFlag)
                {
                    if (this.AutoGetWeightFlag)
                    {
                        StaticWeight weight = null;
                        StaticWeight weight2 = null;
                        StaticWeight weight3 = null;
                        StaticWeight weight4 = null;
                        if (this.upStaticWeights.Count >= 1)
                        {
                            weight2 = weight3 = weight4 = this.upStaticWeights[0];
                            for (int i = 1; i < this.upStaticWeights.Count; i++)
                            {
                                StaticWeight weight5 = this.upStaticWeights[i];
                                if (weight5.num > weight2.num)
                                {
                                    weight2 = weight5;
                                }
                                if (weight5.beginTime > weight4.beginTime)
                                {
                                    weight4 = weight5;
                                }
                                if (weight5.val > weight3.val)
                                {
                                    weight3 = weight5;
                                }
                            }
                            if ((weight2 == weight4) && (weight2 == weight3))
                            {
                                weight = weight2;
                            }
                            else if (weight2 == weight4)
                            {
                                weight = weight2;
                            }
                            else if (weight2 == weight3)
                            {
                                weight = weight2;
                            }
                            else if (weight4 == weight3)
                            {
                                weight = weight3;
                            }
                            else
                            {
                                weight = weight2;
                            }
                        }
                        if (weight != null)
                        {
                            this.lblAutoGetWeight.Text = weight.val.ToString();
                            this.lblAutoGetWeight.ForeColor = Color.Red;
                            this.curtime = 1;
                        }
                        else
                        {
                            this.label32.ForeColor = Color.Red;
                            StringBuilder builder = new StringBuilder();
                            foreach (KeyValuePair<DateTime, double> pair in this.valRecord)
                            {
                                builder.AppendLine(pair.Key.ToString() + ":" + pair.Value.ToString());
                            }
                            File.AppendAllText(DateTime.Now.ToString("yyyyMMddHHmmss") + ".log", builder.ToString());
                        }
                    }
                    this.upStaticWeights.Clear();
                }
                this.oldUpFlag = this.upflag;
                this.downjistatus = false;
                if (this.downflag && (ss == this.ssold))
                {
                    this.downzerocs++;
                    if (this.downzerocs >= this.jhcs)
                    {
                        this.downjistatus = true;
                    }
                }
                if (!this.downjistatus)
                {
                    this.downzerocs = 0;
                }
                else
                {
                    try
                    {
                        if (double.Parse(this.edtzl.Text) > 0.0)
                        {
                            this.lblErr0.Visible = true;
                        }
                        else
                        {
                            this.lblErr0.Visible = false;
                        }
                    }
                    catch
                    {
                    }
                }
                if (this.jistatus)
                {
                    this.SetLampStatus(true, this.hhjh);
                }
                else
                {
                    this.SetLampStatus(false, this.hhjh);
                    this.zerocs = 0;
                }
                this.ssold = ss;
            }
        }


        //在串口取数后设置窗体控件元素
        private void SetTextZl(string ss,int type)//设置界面显示
        {
            if (type == 2)
            {
                lblCKError.Visible = true;
                lblCKError.Text = ss;
            }

            if (type == 3)
            {
                if (ss != ssold)
                {
                    SetLampStatus(false, hhjh);
                    jistatus = false;
                    zerocs = 0;
                }
                else
                {
                    zerocs = zerocs + 1;
                    if (zerocs >= jhcs)
                    {
                        SetLampStatus(true, hhjh);
                        jistatus = true;
                    }
                    else
                    {
                        SetLampStatus(false, hhjh);
                        jistatus = false;
                    }
                }
                if (jistatus && upflag)//如果上升到位并且静荷
                    curtime++;
                if (jistatus && downflag)//如果静荷并下降到位若不为0
                {
                    if (Convert.ToInt32(ss) != 0)
                        this.lblErr0.Visible = false;
                }
                this.edtzl.Text = ss;
                if (AutoGetWeightFlag)
                {
                    this.lblCKError.Visible = false;
                    if (curtime < jhwdcs)
                    {
                        lblAutoGetWeight.ForeColor = Color.Black;
                        lblAutoGetWeight.Text = ss;
                    }
                    if (curtime >= jhwdcs)
                        lblAutoGetWeight.ForeColor = Color.Red;
                }
                ssold = ss;
            }
            if (jistatus && downflag)//如果是静止状态并且为下降到位判断
            {
                try
                {
                    if (double.Parse(edtzl.Text) > 0)
                        lblErr0.Visible = true;
                    else
                        lblErr0.Visible = false;
                }
                catch
                { }
            }
        }

        //设置上下到位
        private void SetUpDownSing()
        {
            try
            {
                timeupEx();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (s.IsOpen)
            {
                s.DiscardInBuffer();
                s.Close();
                s.Dispose();
            }
            Close();
        }
        /// <summary>
        /// 归零
        /// </summary>
        private void goToZero()
        {
            lock (lblAutoGetWeight)
            {
                curtime = 0;
                lblAutoGetWeight.Text = "";
                lblAutoGetWeight.ForeColor = Color.Black;
            }
        }
        //获取改判属性
        protected string GetSXItem()
        {
            DataSet ds = null;
            string pch = cmbph.Text.Trim();
            if (pch == "") return "";
            string sqlstr = "select Filed1 from WMS_Bms_Rec_WGD where pch='" + pch + "'";
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Filed1"].ToString();
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问错误：" + ex.Message);
                return "";
            }
        }
        //获取执行标准
        protected string GetZxbz(string pch)
        {
            string zxbz = "";
            DataSet ds = null;
            string sqlstr = "";
            if (rbptxc.Checked)
            {
                sqlstr = "select zxbz from WMS_Bms_Rec_WGD where pch='" + pch + "'";
                try
                {
                    ds = DbEntry.Context.ExecuteDataset(sqlstr);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        zxbz = ds.Tables[0].Rows[0]["zxbz"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据访问失败：" + ex.Message);
                }
            }
            else//出口材
            {
                if (cmbSX.Text == "CK" || cmbSX.Text == "A" || cmbSX.Text == "AA" || cmbSX.Text == "AAA")//出口材
                    zxbz = "";
                else//出口转内销此处有可能有问题？？？？？？
                {
                    sqlstr = "select zxbz from WMS_Bms_Rec_WGD_Item where zjbxbz=1 and pch='" + pch + "'";
                    try
                    {
                        ds = DbEntry.Context.ExecuteDataset(sqlstr);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            zxbz = ds.Tables[0].Rows[0]["zxbz"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据访问失败：" + ex.Message);
                    }
                }
            }
            return zxbz;
        }

        private void frmWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerup.Enabled = false;
            timerup.Dispose();
            if (s != null)
            {
                if (s.IsOpen)
                {
                    s.Close();
                }
                s.Dispose();
            }
            if ((x != 800) && (y != 600))
                ResolutionX.ChangeRes(x, y);
        }

        /// //////////////////////开关量相关/////////////////////////////////////


        PT_DEVLISTARRAY devlistarray = new PT_DEVLISTARRAY();
        int MaxDevNameLen = 64;
        short gnNumOfSubdevices;
        uint dwDeviceNum;
        short MaxDev = 255;
        short outEntries;
        private void SetLampStatus(bool connected, LFY.UI.Controls.Glass.GlassLamp lamp)
        {
            if (connected)
            {
                lamp.Error = true;
                lamp.ErrorEx = true;
                lamp.DisabledGradient.Top = Color.Green;
                lamp.DisabledGradient.Bottom = Color.Green;
            }
            else
            {
                lamp.Error = false;
                lamp.ErrorEx = false;
                lamp.DisabledGradient.Top = Color.White;
                lamp.DisabledGradient.Bottom = Color.White;
            }
        }

        private void timeupEx()
        {
            timerup.Stop();
            if (bOpen)
            {
                int errcode = Advantech.Digital_ReadByteFromPort(DeviceHandle, short.Parse(Public.GetXmlValue("PCLPort")), out DiValue);
                UpdateLED();
            }
            timerup.Start();
        }

        private int getPCL730in(int chanel)
        {
            int vv = -1;
            switch (chanel)
            {
                case 0:
                    vv = 1;
                    break;
                case 1:
                    vv = 2;
                    break;
                case 2:
                    vv = 4;
                    break;
                case 3:
                    vv = 8;
                    break;
                case 4:
                    vv = 16;
                    break;
                case 5:
                    vv = 32;
                    break;
                case 6:
                    vv = 64;
                    break;
                case 7:
                    vv = 128;
                    break;

            }
            return vv;
        }

        private void UpdateLED()
        {
            //if(!commstatus)//串口关闭的情况下不进行设置
            //{
            //    return;
            //}
            int value = DiValue;
            int tmp = DiValue / getPCL730in(int.Parse(Public.GetXmlValue("PCLInterface")));//取整

            value = int.Parse(tmp.ToString());

            int LedStatus = value % 2;//取余
            if (LedStatus == 1)
            {
                SetLampStatus(false, hhup);
                upflag = false;
            }
            else
            {
                SetLampStatus(true, hhup);
                upflag = true;
            }
            tmp = DiValue / getPCL730in(int.Parse(Public.GetXmlValue("PCLInterfaceX")));

            value = int.Parse(tmp.ToString());
            int LedStatuss = value % 2;
            if (LedStatuss == 1)
            {
                SetLampStatus(false, hhdown);
                downflag = false;
            }
            else
            {
                SetLampStatus(true, hhdown);
                downflag = true;
            }
        }


        private bool getPCLA()
        {
            bool ret = false;
            short MaxEntries = 9;
            int i;
            int ii;
            string tempStr;
            int tempNum;
            try
            {
                int errcode = Advantech.GetDeviceList(out devlistarray, ref outEntries);
                if (errcode != 0)
                {
                    MessageBox.Show("获取设备列表失败，错误代码：" + errcode.ToString());
                }
                else
                {
                    errcode = Advantech.DRV_DeviceGetNumOfList(ref MaxEntries);
                    if (errcode != 0)
                    {
                        MessageBox.Show("获取设备数，错误代码：" + errcode.ToString());
                    }
                    else
                    {
                        for (i = 0; i < MaxEntries; i++)
                        {
                            tempStr = "";
                            tempStr = devlistarray.Devices[i].szDeviceName;
                            string deviceName = Public.GetXmlValue("type");
                            tempNum = tempStr.IndexOf(deviceName);
                            if (tempNum != -1)
                            {
                                gnNumOfSubdevices = devlistarray.Devices[i].nNumOfSubdevices;
                                if (gnNumOfSubdevices > MaxDev)
                                    gnNumOfSubdevices = MaxDev;
                                if (gnNumOfSubdevices == 0)
                                {
                                    dwDeviceNum = devlistarray.Devices[i].dwDeviceNum;
                                    errcode = Advantech.DRV_DeviceOpen(dwDeviceNum, ref DeviceHandle);
                                    if (errcode != 0)
                                    {
                                        MessageBox.Show("打开设备失败，错误代码：" + errcode.ToString());
                                    }
                                    else
                                    {
                                        ret = true;
                                        bOpen = true;
                                    }
                                    //PCLDevice.ptDevGetFeatures.buffer = &lpDevFeatures;
                                }
                            }
                            else
                            {
                                MessageBox.Show("没有安装"+deviceName);
                                ret = false;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
        /// //////////////////////开关量相关end/////////////////////////////////////

        /// <summary>
        /// 显示跑钩信息
        /// </summary>
        /// <param name="pch"></param>
        protected void SetPGLanel()
        {
            if (string.IsNullOrEmpty(this.cmbph.Text))
                return;
            DataRowView row = this.cmbph.SelectedItem as DataRowView;
            lbpg.Text = "";
            mempg.Text = "";
            DataSet ds = null;
            string str = "";
            string sqlstr = "select * from WMS_Bms_Rec_WGD_PaoGou where pch='" + this.cmbph.Text + "'";
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        str = str + "[" + dr["gh"].ToString() + "]";
                    }
                }
                lbpg.Text = str;
                mempg.Text = str;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问错误：" + ex.Message);
            }
        }


        private void timerup_Tick(object sender, EventArgs e)
        {
               //timeupEx();
            this.BeginInvoke(timeSetUpSinge);
        }


        protected void setCkcXLHDisplan()
        {
            string sqlstr = "";
            int itemnum;
            int maxckcxh;
            if (string.IsNullOrEmpty(this.cmbph.Text))
                return;
            sqlstr = "select count(1) as itemnum from WMS_Bms_Inv_Info where pch='" + cmbph.Text + "'";
            DataSet ds = null;
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                itemnum = int.Parse(ds.Tables[0].Rows[0]["itemnum"].ToString());
                sqlstr = "select count(1) as itemnum from WMS_Bms_Rec_WGD_PaoGou where pch='" + cmbph.Text + "'";
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                itemnum = itemnum + int.Parse(ds.Tables[0].Rows[0]["itemnum"].ToString());
                sqlstr = "select ckcxh from WMS_Bms_Rec_WGD_CKCXH where scx='" + Public.userdd + "'";
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (itemnum == 0)
                    {
                        SpinEdit2.Value = 1;
                        lbckxlh.Text = "1";
                    }
                    SpinEdit2.Enabled = true;
                }
                else
                {
                    maxckcxh = int.Parse(ds.Tables[0].Rows[0]["ckcxh"].ToString());
                    if (itemnum == 0)
                    {
                        SpinEdit2.Value = maxckcxh + 1;
                        SpinEdit2.Enabled = true;
                        lbckxlh.Text = SpinEdit2.Value.ToString();

                    }
                    else
                    {
                        SpinEdit2.Value = maxckcxh + 1;
                        //SpinEdit2.Enabled = true;
                        lbckxlh.Text = SpinEdit2.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问失败：" + ex.Message);

            }

        }

        protected int GetSetCKCXH(string scx, string nowdata)
        {
            barcodenumber = 0;
            int ret = 0;
            string sqlstr = "select  ckcxh from WMS_Bms_Rec_WGD_CKCXH where SCX='" + scx + "'";
            DataSet ds = null;
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds.Tables[0].Rows.Count == 0)
                {

                    SpinEdit2.Enabled = true;
                    ret = 1;
                }
                else
                {
                    ret = int.Parse(ds.Tables[0].Rows[0]["ckcxh"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据读取失败：" + ex.Message);
            }
            return ret;
        }


        protected void SetPcInfo()
        {
            if (string.IsNullOrEmpty(this.cmbph.Text))
                return;
            DataRowView row = this.cmbph.SelectedItem as DataRowView;
           // lbptbc.Text = row["BB"].ToString();
            try
            {
                if (row["PCLX"].ToString() == "1")
                    panelck.BringToFront();
                else
                    panelpt.BringToFront();
                ywlh = row["wlh"].ToString();
                ywlmc = row["wlmc"].ToString();
                yzxbz = row["zxbz"].ToString();
                ypcinfo = row["pcinfo"].ToString();
                yvfree0 = row["vfree0"].ToString();
                yvfree1 = row["vfree1"].ToString();
                yvfree2 = row["vfree2"].ToString();
                yvfree3 = row["vfree3"].ToString();

                lbckpch.Text = this.cmbph.Text;
                lbptpch.Text = this.cmbph.Text;
                lbckgg.Text = row["GG"].ToString();
                lbptgg.Text = row["GG"].ToString();
                lbckph.Text = row["PH"].ToString();
                lbptgh.Text = this.edtGouHao.Value.ToString().PadLeft(2,'0');
                lbptph.Text = row["PH"].ToString();
                lbckrq.Text = DateTime.Now.ToString("yy.MM.dd");
                lbptrq.Text = DateTime.Now.ToString("yy.MM.dd");
                // 将班次改为炉号
                //lbptbc.Text = row["BB"].ToString();
                lbptbc.Text = row["vfree0"].ToString();


                lbckbc.Text = row["BB"].ToString();
                lbptbz.Text = row["ZXBZ"].ToString();
                yph = row["PH"].ToString();
                ygg = row["GG"].ToString();
                yzxbz = row["ZXBZ"].ToString();
                PrintPCInfoCheckBox.Checked = false;
                PrintSXCheckBox.Checked = false;
                lbptgh.Text = "";
                lbckxlh.Text = "";
                lbpttm.Text = "";
                lbcktm.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问失败：" + ex.Message);
            }
        }

        private int GetLiquid(string FPch)
        {
            int liquidvalue=-1;
            string sqlstr = "select * from WMS_Bms_Rec_WGD_Liquid where pch='"+FPch+"'";
            DataSet ds = null;
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    liquidvalue = int.Parse(ds.Tables[0].Rows[0]["MaxLiquid"].ToString()) + 1;
                }
                else
                {
                    liquidvalue = 1;
                    DbEntry.Context.ExecuteNonQuery("insert into WMS_Bms_Rec_WGD_Liquid(pch,MaxLiquid) values('"+FPch+"',0)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问失败："+ex.Message);
            }
            return liquidvalue;

        }

        private string CreateCode(string Fpch)
        {
            return Fpch + GetLiquid(Fpch).ToString().PadLeft(2, '0') + edtGouHao.Value.ToString().PadLeft(2,'0');
        }

        private string getItem_pcsx()
        {
            string pch = cmbph.Text;
            if (pch == "") return "";
            DataSet ds = null;
            string sqlstr = "select sx from WMS_Bms_Rec_WGD_Item where zjbxbz=1 and pch='"+pch+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["sx"].ToString();
            else return "";
        }

        private string GetXCSX()
        {
            string pcsx;
            int pclx;
            string sx = "";
            pcsx = lbpcsx.Text.Trim();
            if (rbptxc.Checked) pclx = 0; else pclx = 1;
            sx = cmbSX.Text;
            if (pcsx == "CK")
            {
                if (this.cmbSX.Text == "A1") sx = getItem_pcsx();
            }
            else
            {
                if (pcsx == "DP")
                {
                    if (pclx == 1)//待判出口材
                    {
                        if (this.cmbSX.Text == "A1")
                            sx = getItem_pcsx();
                    }
                }
            }
            return sx;
        }

        private bool getDownFlag(double zl)
        {
            if ((zl >= zerolow) && (zl <= zerohight)) return true;
            else return false;
        }

        private string getzl(string receiveStr)
        {
            string ret = "";
            try
            {
                ret = receiveStr.Substring(star, end - star);
            }
            catch
            { }
            return ret;

        }

        private void getsysparam()
        {
            string sqlstr = "select * from WMS_Pub_SCX where SCXNCID='"+Public.userdd+"'";
            DataSet ds = null;
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["WeightUp"].ToString().ToUpper() == "TRUE")
                    upPrint = "1";
                else upPrint = "0";
                if (dr["SCXParamWeightDown"].ToString().ToUpper() == "TRUE")
                    zeroFlag = "1";
                else zeroFlag = "0";
                zerolow = double.Parse(dr["ZeroLow"].ToString());
                zerohight = double.Parse(dr["ZeroHight"].ToString());
                jhcsKg = int.Parse(dr["SCXParamRestKg"].ToString());
                jhcsS = int.Parse(dr["SCXParamRests"].ToString());
                uptime = int.Parse(dr["SCXParamUptime"].ToString());
                AutoGetWeightFlag = bool.Parse(dr["AutoGetWeightFlag"].ToString());
                AutoGetWeightNum = int.Parse(dr["AutoGetWeightNum"].ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show("获取生产线参数失败："+ex.Message);
                errorflag = true;
            }
        }
     
        private void sethead()
        {
            if (string.IsNullOrEmpty(this.cmbph.Text))
                return;
            DataRowView row = this.cmbph.SelectedItem as DataRowView;
            int pclx;
            edtzxbz.Text = row["zxbz"].ToString();
            pclx = int.Parse(row["PCLX"].ToString());
            lbpcsx.Text = row["PCSX"].ToString();
            if ((row["PCSX"].ToString() == "CK") || ((row["PCSX"].ToString() == "DP") && (pclx == 1)))
            {
                rbckc.Checked = true;
                SpinEdit2.Visible = true;
                SpinEdit2.Enabled = true;
                label29.Visible = true;
                SpinEdit2.Value = GetSetCKCXH(Public.userdd,DateTime.Now.ToString("yy.mm.dd"));
                panelck.BringToFront();
                setCkcXLHDisplan();
            }
            else
            {
                rbptxc.Checked = true;
                label29.Visible = false;
                SpinEdit2.Visible = false;
                panelpt.BringToFront();
            }
        }

        private void getWgdPc()
        {
            string sqlstr = "";
            barcodenumber = 0;
            try
            {
                sqlstr = "select * from WMS_Bms_Rec_WGD where (WCBZ=0 or WCBZ = 1) and ZJBZ=1 and SCX='" + Public.userdd + "'  order by PCH ";
                DataSet dspc = DbEntry.Context.ExecuteDataset(sqlstr);
                if (dspc != null && dspc.Tables.Count > 0 && dspc.Tables[0].Rows.Count > 0)
                {
                    cmbph.DataSource = dspc.Tables[0];
                    if (string.IsNullOrEmpty(curPch))
                    {
                        cmbph.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbph.SelectedValue = curPch;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取批次数据失败："+ex.Message);
            }

        }


        private bool opencomm()
        {
            bool ret=false;
            try
            {
                if (!Public.openCom(s))
                {
                    MessageBox.Show("打开串口失败！");
                    commstatus = false;
                    cbComKG.Checked = false;
                    cbComKG.Text = "已关闭";
                    errorflag = true;
                    ret = false;
                }
                else
                {
                    commstatus = true;
                    cbComKG.Checked = true;
                    cbComKG.Text = "已打开";
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开串口失败！" + ex.Message);
            }
            return ret;

        }

        private void GetWgdPgPc(string GouHao)
        {
            string sqlstr = "";
            sqlstr = "select * from WMS_Bms_Rec_WGD where pch=(select pch from WMS_Bms_Rec_WGD_PaoGou where SCX='"+Public.userdd+"' and GH='"+GouHao+"')";
            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                this.cmbph.SelectedValue = ds.Tables[0].Rows[0]["PCH"].ToString();
        }

        private void cmbSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sx = cmbSX.Text;
            GetZlYY(sx);
            string ph;
            string gg;
            if (sx == "") return;
            if (sx == lbpcsx.Text)
            {
                if(!string.IsNullOrEmpty(this.cmbph.Text))
                {
                    DataRowView pcRow = this.cmbph.SelectedItem as DataRowView;
                    ph = pcRow["PH"].ToString();
                    gg = pcRow["GG"].ToString();
                    lbptph.Text = ph;
                    lbptgg.Text = gg;
                    lbckph.Text = ph;
                    lbckgg.Text = gg;
                    ywlh = pcRow["WLH"].ToString();
                    ywlmc = pcRow["wlmc"].ToString();
                    yzxbz = pcRow["zxbz"].ToString();
                    ypcinfo = pcRow["pcinfo"].ToString();
                    yvfree0 = pcRow["vfree0"].ToString();
                    yvfree1 = pcRow["vfree1"].ToString();
                    yvfree2 = pcRow["vfree2"].ToString();
                    yvfree3 = pcRow["vfree3"].ToString();

                    if (gpflag)
                    {
                        lbckph.Text = yph;
                        lbckgg.Text = ygg;
                        lbptph.Text = yph;
                        lbptgg.Text = ygg;
                        lbptbz.Text = yzxbz;
                    }

                    gpflag = false;
                    
                    btngp.Enabled = true;
                    if (pcRow["PCLX"].ToString() == "1")
                    {
                        panelck.BringToFront();
                    }
                    else panelpt.BringToFront();
                    lbptbz.Text = GetZxbz(cmbph.Text);
                }
                else
                    return;
            }
            else
            {
                panelpt.BringToFront();
                if (rbckc.Checked)
                {
                    DataSet ds = null;
                    string sqlstr = "select * from WMS_Bms_Rec_WGD_Item where ZJBXBZ=1 and pch='"+cmbph.Text+"'";
                    ds = DbEntry.Context.ExecuteDataset(sqlstr);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr  = ds.Tables[0].Rows[0];
                        lbptph.Text = dr["PH"].ToString();
                        lbptgg.Text = dr["GG"].ToString();
                        lbptbz.Text = dr["zxbz"].ToString();
                        ywlh = dr["WLH"].ToString();
                        ywlmc = dr["WLMC"].ToString();
                        yzxbz = dr["ZXBZ"].ToString();
                        ypcinfo = dr["pcinfo"].ToString();
                        yvfree0 = dr["vfree0"].ToString();
                        yvfree1 = dr["vfree1"].ToString();
                        yvfree2 = dr["vfree2"].ToString();
                        yvfree3 = dr["vfree3"].ToString();
                        if (gpflag)
                        {
                            lbckph.Text = yph;
                            lbckgg.Text = ygg;
                            lbptph.Text = yph;
                            lbptgg.Text = ygg;
                            lbptbz.Text = yzxbz;
                        }
                        gpflag = false;
                        
                        if (Public.getWMSParam("GPXZ") == "1")
                            btngp.Enabled = true;
                        else btngp.Enabled = false;
                    }
                }
            }
        }

        //只负责取数其它均抽取出去
        private void s_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //GetCKCS();
                string strTemp = s.ReadExisting();
                System.Threading.Thread.Sleep(qsjg);
                Control.CheckForIllegalCrossThreadCalls = false;
                string ss = s.ReadExisting();
                //if (ss.Length < dataLength)
                //{
                //    this.Invoke(zlTextDel, "取数间隔短（"+ss+")", 2);
                //    return;
                //}
                int intStation = ss.IndexOf(strStartChar);
                //if ((ss.Length - intStation) < dataLength)
                //{
                //    this.Invoke(zlTextDel, "取数间隔短("+ss+")", 2);
                //    return;
                //}
                ss = ss.Substring(intStation, dataLength);
                string strQS = ss.Substring(star, end - star).Trim();//根据配置取数
                if (!Regex.IsMatch(strQS, @"^[0-9]*$"))
                {
                    //SetTextZl("取数不正确(" + strQS + ")", 2);
                    this.Invoke(zlTextDel, "取数不正确(" + strQS + ")", 2);
                    return;
                }
                int iStrQS = int.Parse(strQS);
                this.Invoke(zlTextDel, iStrQS.ToString(), 3);
                //SetTextZl(strQS, 3);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void SetTwoShow(string sr)
        {
            byte[] array = System.Text.Encoding.ASCII.GetBytes(sr);
            string str = null;
            for (int i = 0; i < array.Length; i++)
            {
                int asciicode = (int)(array[i]);
                str += Convert.ToString(asciicode) + " ";
            }
            str += str + Environment.NewLine;
        }
        /// <summary>
        /// 设置spinedit控件值被全选，并且foces
        /// </summary>
        /// <param name="nud"></param>
        private void SpinEditFocus(NumericUpDown nud)
        {
            ((TextBox)nud.Controls[1]).HideSelection = false;
            ((TextBox)nud.Controls[1]).SelectAll();
            nud.Focus();
        }

        private void SpinEdit1_Enter(object sender, EventArgs e)
        {
            SpinEditFocus(edtGouHao);
        }

        private void endpc(string FPCH)
        {
            string sqlstr = "update WMS_Bms_Rec_WGD set WCBZ=2 where pch='"+FPCH+"'";
            try
            {
                DbEntry.Context.ExecuteNonQuery(sqlstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！请重试："+ex.Message);
            }
        }

        private void btnendpc_Click(object sender, EventArgs e)
        {
            string delpch;
            DataSet ds = null;
            DataSet dstmp = null;
            string pch = cmbph.Text;
            delpch = pch;
            int wcbz = 0;
            if (pch == "") return;
            string sqlstr = "select WCBZ,PGBZ from WMS_Bms_Rec_WGD where pch='"+pch+"'";
            try
            {
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    wcbz = int.Parse(ds.Tables[0].Rows[0]["WCBZ"].ToString());
                    sqlstr = "select count(1) as pgnum from WMS_Bms_Rec_WGD_PaoGou where pch='" + pch + "'";
                    dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
                    if (int.Parse(dstmp.Tables[0].Rows[0]["pgnum"].ToString()) <= 0)
                    {
                        if (MessageBox.Show("是否结束该批次？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            edtGouHao.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("存在跑钩记录，不能结束批次！");
                        return;
                    }
                    switch(wcbz)
                    {
                        case 0:
                            MessageBox.Show("没有称重记录，不能结束！","系统提示");
                            edtGouHao.Focus();
                            return;
                        case 2:
                            MessageBox.Show("已经结束！不能操作！", "系统提示");
                            edtGouHao.Focus();
                            return;
                        case 3:
                            MessageBox.Show("已经入库！不能操作！", "系统提示");
                            edtGouHao.Focus();
                            return;
                    }
                    DbEntry.UsingTransaction(delegate()
                    {
                        sqlstr = "update WMS_Bms_Rec_WGD set pgbz=0 where pch='" + pch + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        sqlstr = "update WMS_Bms_Rec_WGD set WCBZ=2,PEnd_time=getdate() where pch='" + pch + "'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        sqlstr = "Zxy_Shell_WGD_NC '"+pch+"'";
                        DbEntry.Context.ExecuteNonQuery(sqlstr);
                        isenter = true;
                        curPch = "";
                        edtGouHao.Focus();
                    });
                }
                else
                {
                    MessageBox.Show("完工单不存在！");
                    edtGouHao.Focus();
                    return;
                }
                curPch = "";
                getWgdPc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("结束批次失败！");
                
            }
        }

        private void printpq(string ph,string gg,string pch,string jz,string rq,string bb,string gh,string bz,string xlh,string tm,string sx,string pcxx,bool ckflg,string itype,string wlh,string heatid,string liaohao)
        {
            string scriptstr = "";
            DataSet ds = null;
            string sqlstr = "";
            Boolean nocheck = false;
            string printmodual;
            string stpath;
            string bzstr;
            string tct;
            string SX = cmbSX.Text;
            StringBuilder sb = new StringBuilder();
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
                        // 在用的摸板
                        Report.LoadReportFromFile(stpath + "ptcz1.fr3");
                        break;
                    case "2":
                        // 该模板不在使用
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
            sb.Append("牌号: "+ph+"\r\n");
            sb.Append("规格: " + gg + "\r\n");

            sb.Append("批号: " + pch + "\r\n");
            sb.Append("炉号: " + heatid + "\r\n");

            sb.Append("净重: " + fjz.ToString() + "kg \r\n");

            

            sb.Append("日期: " + rq + "\r\n");

            sb.Append("钩号: " + gh + "\r\n");



            //修改添加料号
            if (liaohao != "")
            {

                scriptstr += "Memliao.text:='" +liaohao + "';";
                scriptstr += "Memliao.visible:=true;";
                scriptstr += "memliao1.visible:=true;";
                scriptstr += "Lineliao.visible:=true;";
            }

            //修改添加 炉次 删除班别
            scriptstr += "memobb.text:='" + heatid + "';";

            if (SX!="CK")
            {
                string bzstrf = "";
                bzstrf = bz.Substring(bz.IndexOf('~') + 1);
                scriptstr += "memobz.text:='" + bzstrf + "';";

                sb.Append("技术标准: " + bzstrf + "\r\n");
            }
            else
            {
                scriptstr += "memoxlh.text:='" + xlh + "';";
            }
            scriptstr += "memowlh.text:='" + wlh.Substring(0, 3) + "';";


            //string path = CreateCode(sb.ToString(), "Byte", "L", 8, 4);
            //Picture1  20170803175425000.jpg   Picture1.Picture.LoadFromFile("C:\称重2017\称重2017\称重2008\WeightApp\bin\Debug\Upload\20170803175425000.jpg");

           // scriptstr += "Picture1.Picture.LoadFromFile('" + path + "');";

            scriptstr += "end.";
           

            try
            {
                Report.ScriptText = scriptstr;
               

                Report.PrepareReport(true);
                



                int con = 2;
                if (edtPrintCount.Value > 0)
                {
                    con = int.Parse(edtPrintCount.Value.ToString());
                }
                Report.PrintOptions.ShowDialog = false;
                Report.PrintOptions.Copies = con;


                //Report.ShowReport();
                Report.PrintReport();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("打印错误：" + ex.Message + ".请补打！");
            }

            //rbhgp.Checked = true;
            //setiniprintsxche();
        }


        public string CreateCode(string strData, string qrEncoding, string level, int version, int scale)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            string encoding = qrEncoding;
            switch (encoding)
            {
                case "Byte":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
                case "AlphaNumeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                    break;
                case "Numeric":
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                    break;
                default:
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    break;
            }

            qrCodeEncoder.QRCodeScale = scale;
            qrCodeEncoder.QRCodeVersion = version;
            switch (level)
            {
                case "L":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                    break;
                case "M":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    break;
                case "Q":
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                    break;
                default:
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                    break;
            }
            //文字生成图片
            Image image = qrCodeEncoder.Encode(strData);
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString() + ".jpg";
            string path = Application.StartupPath + @"\Upload";
            //string filepath = Server.MapPath(@"~\Upload") + "\\" + filename;
            //如果文件夹不存在，则创建
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filepath = path + @"\" + filename;
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            fs.Close();
            image.Dispose();
            return filepath;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            string wlh,ph,gg,pch,jz,rq,bb,gh,bz,xlh,tm,wlmc,cwyy,pcxx;    //打印时增加cwyy不合格原因  pcxx批次信息
            string vfree0,vfree1,vfree2,vfree3;//20100128称重改判需求

            string znxflag;
            string sx;
            //添加炉号，料号
            string heatid = "", liaohao = "";
            int updateckc,iType;
            int ckcxh;
            bool isckflag;
            DataSet dstmp=null;

            string ErrSeason,PCInfo;
            string sqlstr;

            if (cbComKG.Checked)
            {
                if (lblAutoGetWeight.ForeColor != Color.Red) return;
            }
            //打印特殊信息
            if (PrintPCInfoCheckBox.Checked)
            {
                //打印产品等级
                if (PrintSXCheckBox.Checked) iType = 4;
                else iType = 3;
            }
            else
            {
                if (PrintSXCheckBox.Checked) iType = 2;
                else iType = 1;
            }
            if (edtGouHao.Value == 0)
            {
                MessageBox.Show("钩号不能为0!");
                SpinEditFocus(edtGouHao);
                return;
            }
            if (isenter == false)
            {
                MessageBox.Show("回车确认钩号！");
                SpinEditFocus(edtGouHao);
                return;
            }
            //if (commstatus)//串口打开状态
            //{
            //    if (upPrint == "1")//上升到位控制打印
            //    {
            //        if (!upflag)
            //        {
            //            MessageBox.Show("没有上升到位，不能打印");
            //            return;
            //        }
            //    }
            //    if (!jistatus)
            //    {
            //        MessageBox.Show("非静荷状态不能打印！");
            //        return;
            //    }
            //}
            if (AutoGetWeightFlag)
            {
                if (curtime == 0) jz = edtzl.Text;
                else jz = lblAutoGetWeight.Text;
            }
            else jz = edtzl.Text;//不自动取数
            if (!commstatus) jz = edtzl.Text;
            try
            {
                //线材称重(毛重)
                double jzzz = double.Parse(jz);
                if(zlup!=0 && zldown!=0)
                {
                    if (jzzz > zlup || jzzz < zldown)//大于上限，小于下限不允许打印
                    {
                        MessageBox.Show("重量超出线材重量允许值范围，不能打印，如要打印，请先联系生产主管修改范围参数！");
                        SpinEditFocus(edtGouHao);
                        return;
                    }
                }
                if (gpzlup != 0 && gpzldown != 0)
                {
                    if (gpzl != 0)
                    {
                        double blUp = gpzl * 1000 * gpzlup;
                        double blDown = gpzl * 1000 * gpzldown;
                        if ((jzzz > blUp && jzzz <= zlup) || (jzzz < blDown) && jzzz >= zldown)
                        {
                            if (MessageBox.Show("重量超出钢坯重量倍率允许值范围！但未超过线材重量允许范围，是否打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                SpinEditFocus(edtGouHao);
                                return;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("重量错误！");
                SpinEditFocus(edtGouHao);
                return;
            }
            if (MessageBox.Show("打印信息是否确认无误，是否打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                SpinEditFocus(edtGouHao);
                return;
            }
            if (cmbph.Text.Trim() == "")
            {
                MessageBox.Show("选择批次号！");
                SpinEditFocus(edtGouHao);
                return;
            }
            pch=cmbph.Text;


            DataSet dsprintpch = null;
            DataRow drpch = null;
            DataRow drbarcode = null;

            dsprintpch = DbEntry.Context.ExecuteDataset("select * from WMS_Bms_Rec_WGD where pch='"+cmbph.Text+"'");
            if (dsprintpch == null || dsprintpch.Tables.Count == 0 || dsprintpch.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("批次不存在！");
                SpinEditFocus(edtGouHao);
                return;
            }

            drpch = dsprintpch.Tables[0].Rows[0];
            if ((drpch["wcbz"].ToString() == "2") && (drpch["pgbz"].ToString() == "0"))
            {
                MessageBox.Show("已结束！");
                SpinEditFocus(edtGouHao);
                return;
            }

            //vfree0 炉号为空 则向nc查询
            if (drpch["vfree0"].ToString() == "")
            {
                string loadSql = "";
                loadSql += "select mm_wr_b.pch,getbilletbatchcode(mm_wr_b.pch) billet_heat_number,";
                loadSql += " mm_po.xsddh customer_material_number";
                loadSql += " from mm_wr_b mm_wr_b, mm_mo mm_mo, mm_mosource mm_mosource, mm_po mm_po";
                loadSql += "  where mm_wr_b.scddid = mm_mo.pk_moid and mm_mo.pk_moid = mm_mosource.scddid";
                loadSql += "  and mm_mosource.lyid = mm_po.pk_poid  and mm_po.pk_corp = '1001'";
                loadSql += " and mm_po.dr = 0  and mm_mosource.pk_corp = '1001' and mm_mosource.dr = 0 ";
                loadSql += "  and mm_mo.pk_corp = '1001' and mm_mo.dr = 0 and mm_wr_b.pk_corp = '1001'";
                loadSql += "  and mm_wr_b.dr = 0  and mm_wr_b.pch = '" + cmbph.Text.Trim() + "'";


                string nctest = Public.GetXmlValue("nctest").ToString();
                string ncConfig = "";

                if (nctest == "nctest")
                {
                    ncConfig = "Data Source=nctest;User ID=nctest;Password=nctest;";
                }
                else 
                {
                    ncConfig = "Data Source=ncv5;User ID=xgerp50;Password=xgerp204212350;";
                }

                try
                {

                    OracleConnection conn = new OracleConnection(ncConfig);
                    //OracleConnection conn = new OracleConnection("Data Source=nctest;User ID=nctest;Password=nctest;");
                    //OracleConnection conn = new OracleConnection("Data Source=ncv5;User ID=xgerp50;Password=xgerp204212350;");
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
                            SpinEditFocus(edtGouHao);
                            return;
                        }


                    }
                    else
                    {

                        heatid = ds.Tables[0].Rows[0]["billet_heat_number"].ToString();

                        liaohao = ds.Tables[0].Rows[0]["customer_material_number"].ToString();

                    }

                 
                }
                catch
                {
                    //MessageBox.Show("无法连接到NC,是否没有配置数据库?");
                
                }
                if (heatid == "")
                {
                    addHeatid addHeatidFrm = new addHeatid();
                    addHeatidFrm.add(cmbph.Text.Trim(), ref heatid);
                }

                if (heatid == "")
                {
                    if (MessageBox.Show("您没有手工输入炉号！是否继续打印？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        SpinEditFocus(edtGouHao);
                        return;
                    }
                }
                else
                {

                    pch = cmbph.Text.Trim();
                    addheatid(heatid, liaohao, pch);
                }

                

                

            }
            else
            {
                heatid = drpch["vfree0"].ToString();
                liaohao = drpch["vfree4"].ToString();
            }


            ///对整批属性是否改判进行判断  改判则料号为空
            ///
            if ((drpch["vfree1"].ToString() != drpch["yvfree1"].ToString()) || (drpch["vfree2"].ToString() != drpch["yvfree2"].ToString()) || (drpch["vfree3"].ToString() != drpch["yvfree3"].ToString()) || (drpch["wlh"].ToString() != drpch["ywlh"].ToString()))
            {
                liaohao = "";
            }

            //单卷属性不为 AAA  AA A CK   则料号为空

            if ((cmbSX.Text.ToString().Trim() != "AAA") && (cmbSX.Text.ToString().Trim() != "AA") && (cmbSX.Text.ToString().Trim() != "A") && (cmbSX.Text.ToString().Trim() != "CK"))
            {
                liaohao = "";
            }

            // 单卷是否改判
            if (gpflag)
            {
                liaohao = "";
            }




            updateckc = 0;//不修改出口材序号
            znxflag = "0";//转内销标志
            sx = cmbSX.Text;
            if (cmbZLYY.Enabled==true && !string.IsNullOrEmpty(cmbZLYY.Text))//质量原因
            {
                ErrSeason = cmbZLYY.Text;
            }
            sqlstr="select * from WMS_BMS_INV_INFO where pch='"+pch+"' and gh="+edtGouHao.Value.ToString();
            dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
            if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("已经打印，是否再次打印？", "操作提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2,MessageBoxOptions.DefaultDesktopOnly) == DialogResult.No)
                {
                    isenter = false;
                    SpinEditFocus(edtGouHao);
                    return;
                }
                drbarcode = dstmp.Tables[0].Rows[0];
                isenter = false;
                ph = drbarcode["ph"].ToString();
                gg = drbarcode["gg"].ToString();
                jz = drbarcode["zl"].ToString();
                rq = drbarcode["producedata"].ToString();
                bb = drbarcode["bb"].ToString();
                gh = drbarcode["gh"].ToString();
                bz = drbarcode["bz"].ToString();
                tm = drbarcode["barcode"].ToString();
                cwyy = drbarcode["Errseason"].ToString();
                pcxx = drbarcode["pcinfo"].ToString();
                sx = drbarcode["sx"].ToString();
                wlh = drbarcode["wlh"].ToString();
                if ((sx == "CK") || ((sx == "DP") && (rbckc.Checked)))
                {
                    xlh = drbarcode["ckcxh"].ToString();
                    isckflag = true;
                }
                else
                {
                    isckflag = false;
                    xlh = tm.Substring(9,2);
                }
                if (edtPrintCount.Value > 0)
                {
                    printpq(ph,gg,pch,jz,rq,bb,gh.PadLeft(2,'0'),bz,xlh,tm,sx,pcxx,isckflag,iType.ToString(),wlh,heatid,liaohao);
                    
                }
                lblAutoGetWeight.ForeColor = Color.Black;
                lblAutoGetWeight.Text = "0";
                curtime = 0;
                isenter = false;
                edtGouHao.Focus();
                return; //赵贺朝 2014-12-8添加
            }

            sqlstr = "select * from WMS_Bms_Inv_OutInfo where pch='" + pch + "' and gh=" + edtGouHao.Value.ToString();
            dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
            if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0) 
            {
                if (MessageBox.Show("已打印,该单卷位于出库仓库中，是否再次打印", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.No)
                {
                    isenter = false;
                    SpinEditFocus(edtGouHao);
                    return;
                }
                drbarcode = dstmp.Tables[0].Rows[0];
                isenter = false;
                ph = drbarcode["ph"].ToString();
                gg = drbarcode["gg"].ToString();
                jz = drbarcode["zl"].ToString();
                rq = drbarcode["producedata"].ToString();
                bb = drbarcode["bb"].ToString();
                gh = drbarcode["gh"].ToString();
                bz = drbarcode["bz"].ToString();
                tm = drbarcode["barcode"].ToString();
                cwyy = drbarcode["Errseason"].ToString();
                pcxx = drbarcode["pcinfo"].ToString();
                sx = drbarcode["sx"].ToString();
                wlh = drbarcode["wlh"].ToString();
                if ((sx == "CK") || ((sx == "DP") && (rbckc.Checked)))
                {
                    xlh = drbarcode["ckcxh"].ToString();
                    isckflag = true;
                }
                else
                {
                    isckflag = false;
                    xlh = tm.Substring(9, 2);
                }
                if (edtPrintCount.Value > 0)
                {
                    //itype??????????????????????????????????
                    printpq(ph, gg, pch, jz, rq, bb, gh.PadLeft(2,'0'), bz, xlh, tm, sx, pcxx, isckflag, iType.ToString(), wlh,heatid,liaohao);
                    //addheatid(heatid, liaohao, pch);
                }
                lblAutoGetWeight.ForeColor = Color.Black;
                lblAutoGetWeight.Text = "0";
                curtime = 0;
                edtGouHao.Focus();
                return; //赵贺朝 2014-12-8添加
            }

            sqlstr = "select pch,gh from WMS_Bms_Rec_WGD_PaoGou where gh='"+edtGouHao.Value.ToString()+"' and scx='"+Public.userdd+"'";
            dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
            if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
            {
                if (dstmp.Tables[0].Rows[0]["pch"].ToString() != cmbph.Text)
                {
                    MessageBox.Show("该钩在批次【"+dstmp.Tables[0].Rows[0]["pch"].ToString()+"】上跑钩！");
                    isenter = false;
                    SpinEditFocus(edtGouHao);
                    return;
                }
            }

            if ((rbckc.Checked) && (sx == "CK"))
            {
                isckflag = true;
                ph = dsprintpch.Tables[0].Rows[0]["PH"].ToString();
                gg = dsprintpch.Tables[0].Rows[0]["GG"].ToString();
                pch = lbckpch.Text;
                rq = dtpscrq.Value.ToString("yyyy.MM.dd");
                bb = dsprintpch.Tables[0].Rows[0]["BB"].ToString(); ;
                gh = edtGouHao.Value.ToString();
                bz = lbckbz.Text;
                tm = CreateCode(pch);
                lbcktm.Text = tm;
                xlh = tm.Substring(9, 2);
                lbckxlh.Text = xlh;
            }
            else
            {
                isckflag = false;
                ph = lbptph.Text;
                gg = lbptgg.Text;
                pch = lbptpch.Text;
                rq = dtpscrq.Value.ToString("yyyy.MM.dd");
                //班别会变成炉号
                DataRowView row = this.cmbph.SelectedItem as DataRowView;
                // lbptbc.Text = row["BB"].ToString();
                //bb = lbptbc.Text;
                bb = row["BB"].ToString();
                gh = edtGouHao.Value.ToString();
                bz = lbptbz.Text;
                tm = CreateCode(pch);
                lbpttm.Text = tm;
                xlh = tm.Substring(9,2);
            }
            ckcxh = 0;
            if ((lbpcsx.Text == "CK") || (lbpcsx.Text == "DP") && (rbckc.Checked))//设置出口材序号修改方式
            {
                if (sx != "CK") znxflag = "1";
                else
                {
                    znxflag = "2";
                    sqlstr = "select ckcxh from WMS_Bms_Rec_WGD_CKCXH where scx='"+Public.userdd+"'";
                    dstmp = DbEntry.Context.ExecuteDataset(sqlstr);
                    if (dstmp != null && dstmp.Tables.Count > 0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        if (SpinEdit2.Value != int.Parse(dstmp.Tables[0].Rows[0]["ckcxh"].ToString()) + 1)
                            updateckc = 2;//修改成新的
                        else updateckc = 3;//加一
                    }
                    else
                        updateckc = 1;//增加
                    ckcxh = int.Parse(SpinEdit2.Value.ToString());
                    SpinEdit2.Value = SpinEdit2.Value + 1;
                }
                
            }

            bz = GetZxbz(cmbph.Text);
            if (gpflag)
            {
                PCInfo = curpcinfo;
                vfree0 = curvfree0;
                vfree1 = curvfree1;
                vfree2 = curvfree2;
                vfree3 = curvfree3;
                wlmc = curwlmc;
                wlh = curwlh;
                bz = curzxbz;
                ErrSeason = gpyy;
            }
            else
            {
                PCInfo = ypcinfo;
                vfree0 = yvfree0;
                vfree1 = yvfree1;
                vfree2 = yvfree2;
                vfree3 = yvfree3;
                wlmc = ywlmc;
                wlh = ywlh;
                bz = yzxbz;
            }
            ErrSeason = cmbZLYY.Text;
            sqlstr = "WMS_Bms_Rec_WGD_CZDB '"+pch+"','"+tm+"','"+gg+"','"+ph+"','"+bb+"','"+gh+"','"+jz.Trim()+"','"+bz+"','"+xlh+
                   "','"+Public.userno+"','"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"','"+sx+
                   "','"+Public.userdd+"','"+znxflag+"','"+updateckc.ToString()+
                   "','"+ckcxh.ToString()+"','"+dtpscrq.Value.ToString("yyyy.MM.dd")+
                   "','" + PCInfo + "','" + ErrSeason + "','" + wlh + "','" + wlmc +
                   "','"+vfree0+"','"+vfree1+"','"+vfree2+"','"+
                   vfree3+"'";
            DbEntry.Context.ExecuteNonQuery(sqlstr);
            
            sqlstr="select * from WMS_Bms_Inv_Info where pch='"+cmbph.Text.Trim()+"' and gh="+edtGouHao.Value.ToString();
            dsbarcode = DbEntry.Context.ExecuteDataset(sqlstr);
            if (dsbarcode != null && dsbarcode.Tables.Count > 0 && dsbarcode.Tables[0].Rows.Count > 0)
            {
                drbarcode = dsbarcode.Tables[0].Rows[0];
                ph = drbarcode["ph"].ToString();
                gg = drbarcode["gg"].ToString();
                pch = drbarcode["pch"].ToString();
                jz = drbarcode["zl"].ToString();
                rq = drbarcode["producedata"].ToString();
                bb = drbarcode["bb"].ToString();
                bz = drbarcode["bz"].ToString();
                tm = drbarcode["barcode"].ToString();
                cwyy = drbarcode["ErrSeason"].ToString();
                pcxx = drbarcode["pcinfo"].ToString();
                xlh = tm.Substring(9,2);
                wlh = drbarcode["wlh"].ToString();
                sx = drbarcode["sx"].ToString();
                if ((sx == "CK") || ((sx == "DP") && (rbckc.Checked)))
                {
                    xlh = drbarcode["CKCXH"].ToString();
                }
                ckcxh = int.Parse(drbarcode["ckcxh"].ToString()) + 1;
                if (edtPrintCount.Value > 0)
                {

                    printpq(ph, gg, pch, jz, rq, bb, gh.PadLeft(2, '0'), bz, xlh, tm, sx, pcxx, isckflag, iType.ToString(), wlh, heatid, liaohao);
                    //addheatid(heatid, liaohao, pch);
                }
                   
                lblAutoGetWeight.ForeColor = Color.Black;
                lblAutoGetWeight.Text = "0";
                curtime = 0;
            }
            //if (!string.IsNullOrEmpty(yfpgpch))
            //{
            //    this.cmbph.SelectedValue = yfpgpch;
            //    yfpgpch = "";
            //}
            if (string.IsNullOrEmpty(yfpgpch))
                curPch = cmbph.SelectedValue.ToString();
            else
                curPch = yfpgpch;
            lblAutoGetWeight.ForeColor = Color.Black;
            lblAutoGetWeight.Text = "0";
            curtime = 0;
            yfpgpch = "";
            getWgdPc();
            //SetPcInfo();
            //bandBarcode(this.cmbph.Text);
            gpflag = false;//将改判标志改为未改判

           

            isenter = false;
           // GetSX();
            //SetPGLanel();//设置跑钩
           // edtzl.Text = "000000";
            SpinEditFocus(edtGouHao); 
        }

        //向完工单添加炉号料号

        public void addheatid(string heatid, string liaohao,string pch)
        {
            try
            {
                string sqlstr = "update  WMS_Bms_Rec_WGD set  vfree0='" + heatid + "',vfree4='" + liaohao + "' where pch='" + pch + "'";
                DbEntry.Context.ExecuteNonQuery(sqlstr);
            }
            catch
            {
                MessageBox.Show("写入失败");
            
            }
           
        }
        
        protected void bandBarcode(string fpch)
        {
            this.dgv.AutoGenerateColumns = false;
            string sqlstr = "select * from wms_bms_inv_info where pch='" + fpch + "'";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            dgv.DataSource=ds.Tables[0];
            if(dgv.Rows.Count>0)
                this.dgv.CurrentCell = this.dgv[0, this.dgv.Rows.Count - 1];
            SetSum(fpch);
        }

        protected void SetSum(string fpch)
        {
            string sqlstr = "select sum(zl) as sumzl,count(1) as sumsl from wms_bms_inv_info where pch='" + fpch + "'";
            DataSet ds = null;
            ds=DbEntry.Context.ExecuteDataset(sqlstr);
            string sumzl = ds.Tables[0].Rows[0]["sumzl"].ToString();
            string sumsl = ds.Tables[0].Rows[0]["sumsl"].ToString();
            lbsumsl.Text = sumsl;
            lbsumzl.Text = sumzl;
        }

        private void btnpg_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (cmbph.Text == "") return;
            if (edtGouHao.Value <= 0) return;
            sqlstr = "select count(1) as printpg from wms_bms_inv_info where pch='" + cmbph.Text + "' and gh=" + edtGouHao.Value.ToString();
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (int.Parse(ds.Tables[0].Rows[0]["printpg"].ToString()) != 0)
            {
                MessageBox.Show("已打印，不能跑钩！");
                return;
            }
            sqlstr = "select pch,gh from WMS_Bms_Rec_WGD_PaoGou where gh='"+edtGouHao.Value.ToString()+"'"+
               " and scx='"+Public.userdd+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["pch"].ToString() != cmbph.Text.Trim())
                {
                    MessageBox.Show("该钩在批次号【"+dr["pch"].ToString()+"】的批次上跑钩！");
                    return;
                }
            }

            if (MessageBox.Show("跑钩确认？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    sqlstr = "prc_wms_bms_rec_wgd_paogou '" + cmbph.Text + "'," + edtGouHao.Value.ToString() + ",'" + Public.userdd + "'";
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    SetPGLanel();
                    curtime = 0;
                    SpinEditFocus(edtGouHao);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("记录跑钩失败："+ex.Message);
                }
            }
            if (isenter)
                this.btnPrint.Focus();
        }

        private void edtzl_TextChanged(object sender, EventArgs e)
        {
            lbckzl.Text = edtzl.Text + " Kg";
            lbptzl.Text = edtzl.Text + " Kg";
            //if (curtime<=15)
            //    Label23.Text = edtzl.Text;
            //if (curtime >= 15)
            //    Label23.ForeColor = Color.Red;
        }

        private void cmbph_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbph.Text))
                    return;
                DataRowView row = this.cmbph.SelectedItem as DataRowView;
                string Fpch = cmbph.Text;
                bandBarcode(Fpch);
                sethead();
                SetPcInfo();
                SetPGLanel();
                GetSX();
                if (row["PCSX"].ToString() == "CK")
                    setCkcXLHDisplan();
                if (row["PCSX"].ToString() == "DP" && rbckc.Checked)
                    setCkcXLHDisplan();
                if ((row["PCSX"].ToString() == "DP") && (row["PCLX"].ToString() == "1"))
                    setCkcXLHDisplan();
                btngp.Enabled = true;
                string gpzlstr = row["GPZL"].ToString();
                gpzl = double.Parse(gpzlstr == "" ? "0" : gpzlstr);//钢坯重量

                if (gpflag)
                {
                    lbckph.Text = yph;
                    lbckgg.Text = ygg;
                    lbptph.Text = yph;
                    lbptgg.Text = ygg;
                    lbptbz.Text = yzxbz;
                }
                gpflag = false;
               
                SpinEditFocus(edtGouHao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SpinEdit1_Leave(object sender, EventArgs e)
        {
            if (btnendpc.Focused) return;
            if (btnExit.Focused) return;
            if (btnSearch.Focused) return;
            if (btnpgmanage.Focused) return;
            if (btnprintb.Focused) return;
            if (btntj.Focused) return;
            if (cbComKG.Focused) return;
            if (dgv.Focused) return;
            if (edtGouHao.Value == 0)
            {
                return;
            }
            if (Button3.Focused) return;
            if (!isenter)
            {
                MessageBox.Show("以回车键确认钩号的录入！");
                //SpinEditFocus(SpinEdit1);
                edtGouHao.Focus();
            }
        }

        private void rbptxc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbptxc.Checked)
                panelpt.BringToFront();
        }

        private void rbckc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbckc.Checked)
                panelck.BringToFront();
        }

        private void SpinEdit2_ValueChanged(object sender, EventArgs e)
        {
            lbckxlh.Text = SpinEdit2.Value.ToString();
        }

        private void cbComKG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComKG.Checked)
            {
                if (Public.openCom(s))
                {
                    commstatus = true;
                    cbComKG.Checked = true;
                    cbComKG.Text = "已打开";
                }
                else
                {
                    MessageBox.Show("打开串口失败.");
                    commstatus = false;
                    cbComKG.Checked = false;
                    cbComKG.Text = "已关闭";
                }
            }
            else
            {
                if (s.IsOpen)
                {
                    s.Close();
                    commstatus = false;
                    cbComKG.Checked = false;
                    cbComKG.Text = "已关闭";
                }
            }
            SpinEditFocus(edtGouHao);
        }
        //显示行号
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                                  e.RowBounds.Location.Y,
                                  dgv.RowHeadersWidth - 4,
                                  e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                    dgv.RowHeadersDefaultCellStyle.Font,
                    rectangle,
                    dgv.RowHeadersDefaultCellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtpscrq_ValueChanged(object sender, EventArgs e)
        {
            lbckrq.Text = dtpscrq.Value.ToString("yyyy.MM.dd");
            lbptrq.Text = dtpscrq.Value.ToString("yyyy.MM.dd");

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否归零？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                goToZero();
            }
            SpinEditFocus(edtGouHao);
        }

        private void btnpgmanage_Click(object sender, EventArgs e)
        {
            pgmanagerfrm frm = new pgmanagerfrm();
            frm.ShowDialog();
            SetPGLanel();
            SpinEditFocus(edtGouHao);
        }

        private void SpinEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            string tm="";
            if (e.KeyCode == Keys.Enter)
            {
                if (edtGouHao.Value == 0) return;
                DataSet ds = null;
                string sqlstr = "select * from WMS_Bms_Rec_WGD_PaoGou where  gh='" + edtGouHao.Value.ToString().PadLeft(2,'0') + "' and scx='" + Public.userdd + "'";
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)//存在跑钩记录
                {
                    tm = ds.Tables[0].Rows[0]["pch"].ToString() +
                        GetLiquid(ds.Tables[0].Rows[0]["pch"].ToString()).ToString().PadLeft(2, '0') +
                        edtGouHao.Value.ToString().PadLeft(2, '0');
                    MessageBox.Show("存在跑钩批次!");
                    yfpgpch = cmbph.Text;//保存原发运单批次号
                    GetWgdPgPc(edtGouHao.Value.ToString());
                }
                else//不存在跑钩记录
                {
                    yfpgpch = "";
                    if (cmbph.Text == "")
                    {
                        MessageBox.Show("没有批次号！");
                        edtGouHao.Value = 0;
                        return;
                    }
                    tm = CreateCode(cmbph.Text);
                }

                sqlstr = "select * from wms_bms_inv_info where gh=" + edtGouHao.Value.ToString().PadLeft(2,'0') + " and pch='" + cmbph.Text + "'";
                ds = DbEntry.Context.ExecuteDataset(sqlstr);
                if (ds.Tables[0].Rows.Count > 0)
                    tm = ds.Tables[0].Rows[0]["barcode"].ToString();
                lbptgh.Text = edtGouHao.Value.ToString().PadLeft(2,'0');
                lbckbz.Text = edtGouHao.Value.ToString().PadLeft(2,'0');//???
                lbpttm.Text = tm;
                lbcktm.Text = tm;
                if (gpflag)
                {
                    lbckph.Text = yph;
                    lbckgg.Text = ygg;
                    lbptph.Text = yph;
                    lbptgg.Text = ygg;
                    lbptbz.Text = yzxbz;
                }
                gpflag = false;
                
                isenter = true;
                btnPrint.Focus();
            }
            else
                isenter = false;
        }

        private void SpinEdit1_ValueChanged(object sender, EventArgs e)
        {
            this.lbckph.Text = edtGouHao.Value.ToString().PadLeft(2, '0');
            isenter = false;
        }

        private void btntj_Click(object sender, EventArgs e)
        {
            tjjFrm frm=null;
            Cursor.Current = Cursors.WaitCursor;
            if (string.IsNullOrEmpty(this.cmbph.Text))
                frm = new tjjFrm();
            else
                frm = new tjjFrm(this.cmbph.Text);
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
            SpinEditFocus(edtGouHao);
        }

        private void btnprintb_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.Isb = true;
            frm.ShowDialog();
            if (frm.IsLogin)
            {
                if (!frm.PrintBAuthority)
                {
                    MessageBox.Show("无补打权限！");
                    return;
                }
                else
                {
                    cbComKG.Checked = false;//关闭串口
                    printBFrm frmb = new printBFrm();
                    frmb.ShowDialog();
                    cbComKG.Checked = true;//打开串口
                }
            }
        }

        private void SpinEdit3_Leave(object sender, EventArgs e)
        {
            SpinEditFocus(edtGouHao);
        }

        private void cmbph_Leave(object sender, EventArgs e)
        {
            //opencomm();
            SpinEditFocus(edtGouHao);
        }

        private void btngp_Click(object sender, EventArgs e)
        {
            if (cmbph.Text == "") return;
            frmgp frm = new frmgp();
            frm.Pch = cmbph.Text;
            frm.Ph = yph;
            frm.Gg = ygg;
            frm.Zxbz = yzxbz;
            frm.Vfree0 = yvfree0;
            frm.Vfree1 = yvfree1;
            frm.Vfree2 = yvfree2;
            frm.Vfree3 = yvfree3;
            frm.Pcinfo = ypcinfo;
            frm.ShowDialog();
            if (frm.Gpflag)
            {
                lbckph.Text = frm.Ph;
                lbckgg.Text = frm.Gg;
                lbptph.Text = frm.Ph;
                lbptgg.Text = frm.Gg;
                lbptbz.Text = frm.Zxbz;
                curwlh = frm.Wlh;
                curwlmc = frm.Wlmc;
                curvfree0 = frm.Vfree0;
                curvfree1 = frm.Vfree1;
                curvfree2 = frm.Vfree2;
                curvfree3 = frm.Vfree3;
                curpcinfo = frm.Pcinfo;
                curzxbz = frm.Zxbz;
                gpyy = frm.Gpyy;

                gpflag = true;//改判标志为改判
            }
            else
                gpflag = false;
            if(isenter)
                btnPrint.Focus();
        }

        private void toolModify_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            if (dgv.SelectedRows.Count == 0) return;
            DataGridViewRow dr = dgv.SelectedRows[0];
            string barcode = dr.Cells[6].Value.ToString();
            string produceData = dr.Cells[8].Value.ToString();
            updatebarcodeFrm frm = new updatebarcodeFrm();
            frm.Barcode = barcode;
            frm.Pclx = rbckc.Checked ? 1 : 0;
            frm.ProduceData = produceData;
            frm.Sx = dr.Cells[4].Value.ToString();
            frm.Pch = dr.Cells[9].Value.ToString();
            if (dr.Cells[10].Value==null)
            {
                frm.Zxbz = "";
            }
            else
            {
                frm.Zxbz = dr.Cells[10].Value.ToString();
            }
            if (dr.Cells[11].Value != null)
            {
                frm.Pcinfo = dr.Cells[11].Value.ToString();
            }
            else
                frm.Pcinfo = "";
            frm.Jz = dr.Cells[3].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (rbckc.Checked)
                {
                    string sqlstr = "select CKCXH+1 as ckxxhnew from WMS_Bms_Rec_WGD_CKCXH where scx='" + Public.userdd + "'";
                    DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
                    SpinEdit2.Value = int.Parse(ds.Tables[0].Rows[0]["ckxxhnew"].ToString());
                }
            }
            SpinEditFocus(edtGouHao);
            bandBarcode(frm.Pch);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmQuery frm = new FrmQuery();
            frm.ShowDialog();
            SpinEditFocus(edtGouHao);
        }

        private void btnPrint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                this.Button3.Focus();
        }

        private void Button3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.btnPrint.Focus();
        }

        private void edtzl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnPrint.Focus();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {
            if (this.label32.ForeColor == Color.Red)
            {
                MessageBox.Show(string.Concat(new object[] { "没有取到稳定数据，数据记录为", this.valRecord.Values, Environment.NewLine, "上升到位后的数据记录为", this.upStaticWeights }));
            }
        }
    }

    public class StaticWeight
    {
        public DateTime beginTime = DateTime.Now;
        public bool inCollection;
        public int num;
        public double val;

        public void ClearNum()
        {
            this.num = 0;
        }

        public void IncNum()
        {
            this.num++;
        }
    }
    
}