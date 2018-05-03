using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightApp
{
    public partial class frmPCLSet : Form
    {
        public frmPCLSet()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void frmPCLSet_Load(object sender, EventArgs e)
        {
            lampUp.DisabledGradient.Top = Color.White;
            lampUp.DisabledGradient.Bottom = Color.White;
            lampDown.DisabledGradient.Top = Color.White;
            lampDown.DisabledGradient.Bottom = Color.White;
            string port = Public.GetXmlValue("PCLPort");
            string rdport = "rdport" + port;
            Control[] rds = groupBox1.Controls.Find(rdport, false);
            RadioButton rd = (RadioButton)rds[0];
            rd.Checked = true;

            string rdupv = Public.GetXmlValue("PCLInterface");
            string rdupstr = "rd" + rdupv;
            Control[] rdups = groupBox2.Controls.Find(rdupstr, false);
            RadioButton rdup = (RadioButton)rdups[0];
            rdup.Checked = true;

            string rddownv = Public.GetXmlValue("PCLInterfaceX");
            string rddownstr = "rdx" + rddownv;
            Control[] rddowns = groupBox3.Controls.Find(rddownstr, false);
            RadioButton rddown = (RadioButton)rddowns[0];
            rddown.Checked = true;

            timeup.Interval = 300;

            string xType = Public.GetXmlValue("type");
            for (int i = 0; i < this.comType.Items.Count; i++)
            {
                if (this.comType.Items[i].ToString() == xType)
                {
                    this.comType.SelectedIndex = i;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.SetXmlValue("type", this.comType.Text);
            string port = "";
            foreach (Control ct in groupBox1.Controls)
            {
                RadioButton rd = (RadioButton)ct;
                if (rd.Checked)
                {
                    port = rd.Name;
                    port = port.Substring(port.Length-1, 1);
                    Public.SetXmlValue("PCLPort", port);
                    break;
                }
            }

            string upnum = "";
            foreach (Control ct in groupBox2.Controls)
            {
                RadioButton rd = (RadioButton)ct;
                if (rd.Checked)
                {
                    upnum = rd.Name;
                    upnum = upnum.Substring(upnum.Length - 1, 1);
                    Public.SetXmlValue("PCLInterface", upnum);
                    break;
                }
            }

            string downnum = "";

            foreach (Control ct in groupBox3.Controls)
            {
                RadioButton rd = (RadioButton)ct;
                if (rd.Checked)
                {
                    downnum = rd.Name;
                    downnum = downnum.Substring(downnum.Length - 1, 1);
                    Public.SetXmlValue("PCLInterfaceX", downnum);
                    break;
                }
            }
            MessageBox.Show("保存成功！");
        }


        short DiValue;
        short outEntries;
        short gnNumOfSubdevices;
        short MaxDev;
        uint dwDeviceNum;
        int DeviceHandle;
        bool bOpen;
        PT_DEVLISTARRAY devlistarray = new PT_DEVLISTARRAY();
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
                            MessageBox.Show(tempStr);
                            string pzDevice = Public.GetXmlValue("type");//获取设备类型
                            tempNum = tempStr.IndexOf(pzDevice);
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
                                MessageBox.Show("没有安装PCL-730");
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

        private void UpdateLED()
        {
            int value = DiValue;
            int tmp = DiValue / getPCL730in(int.Parse(Public.GetXmlValue("PCLInterface")));//取整
            
            value = int.Parse(tmp.ToString());

            int LedStatus = value % 2;//取余
            if (LedStatus == 1)
            {
                SetLampStatus(false, lampUp);
            }
            else
            {
                SetLampStatus(true, lampUp);
            }
            tmp = DiValue / getPCL730in(int.Parse(Public.GetXmlValue("PCLInterfaceX")));
            value = int.Parse(tmp.ToString());
            int LedStatuss = value % 2;
            if (LedStatuss == 1)
            {
                SetLampStatus(false, lampDown);
            }
            else
            {
                SetLampStatus(true, lampDown);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (getPCLA())
                    timeup.Enabled = true;
            }
            else
            {
                timeup.Enabled = false;
            }
        }

        private void timeup_Tick(object sender, EventArgs e)
        {
            timeupEx();
        }

        private void timeupEx()
        {
            if (bOpen)
            {

                int errcode = Advantech.Digital_ReadByteFromPort(DeviceHandle, short.Parse(Public.GetXmlValue("PCLPort")), out DiValue);

                UpdateLED();
            }
        }

    }
}