using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightApp
{
    public partial class frmComSet : Form
    {
        public frmComSet()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        int pointwz;
        int jhcs;

        private void frmComSet_Load(object sender, EventArgs e)
        {
            cmbCom.SelectedIndex = cmbCom.Items.IndexOf(Public.GetXmlValue("port"));
            cmbStopBits.SelectedIndex = cmbStopBits.Items.IndexOf(Public.GetXmlValue("StopBits"));
            cmbparity.SelectedIndex = cmbparity.Items.IndexOf(Public.GetXmlValue("Parity"));
            txtDataBits.Text = Public.GetXmlValue("ByteSize");
            txtbaudRate.Text = Public.GetXmlValue("baudrate");

            cmbHandShake.SelectedIndex = cmbHandShake.Items.IndexOf(Public.GetXmlValue("HandShake"));
            cmbRtsEnable.SelectedIndex = cmbRtsEnable.Items.IndexOf(Public.GetXmlValue("RtsEnable"));
            cmbDtrEnable.SelectedIndex = cmbDtrEnable.Items.IndexOf(Public.GetXmlValue("DtrEnable"));
            if (Public.GetXmlNodeAttr("HandShake", "isuse") == "Y") ckHandShake.Checked = true; else ckHandShake.Checked = false;
            if (Public.GetXmlNodeAttr("RtsEnable", "isuse") == "Y") ckRtsEnable.Checked = true; else ckRtsEnable.Checked = false;
            if (Public.GetXmlNodeAttr("DtrEnable", "isuse") == "Y") ckDtrEnable.Checked = true; else ckDtrEnable.Checked = false;
            txtdatas.Text = Public.GetXmlValue("DataStar");
            if (Public.GetXmlNodeAttr("DataStar", "isuse") == "Y") ckdatas.Checked = true; else ckdatas.Checked = false;
            txtdatae.Text = Public.GetXmlValue("DataEnd");
            if (Public.GetXmlNodeAttr("DataEnd", "isuse") == "Y") ckdatae.Checked = true; else ckdatae.Checked = false;
            txtdataChars.Text = Public.GetXmlValue("DataStarChar");
            if (Public.GetXmlNodeAttr("DataEnd", "isuse") == "Y") ckdataChars.Checked = true; else ckdataChars.Checked = false;
            txtdataChare.Text = Public.GetXmlValue("DataEndChar");
            if (Public.GetXmlNodeAttr("DataEndChar", "isuse") == "Y") ckdataChare.Checked = true; else ckdataChare.Checked = false;
            txtpoint.Text = Public.GetXmlValue("Pointwz");
            if (Public.GetXmlNodeAttr("DataEndChar", "isuse") == "Y") ckpoint.Checked = true; else ckpoint.Checked = false;
            txtdatalen.Text = Public.GetXmlValue("DataLen");
            if (Public.GetXmlNodeAttr("DataEndChar", "isuse") == "Y") ckdatalen.Checked = true; else ckdatalen.Checked = false;

            pointwz = int.Parse(Public.GetXmlValue("Pointwz"));
            nujh.Value = int.Parse(Public.GetXmlValue("JHCS"));
            nudqsjg.Value = int.Parse(Public.GetXmlValue("QSJG"));
            jhcs = int.Parse(Public.GetXmlValue("JHCS"));
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存设置？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Public.SetXmlValue("port", cmbCom.Text);
                    Public.SetXmlValue("StopBits", cmbStopBits.Text);
                    Public.SetXmlValue("Parity", cmbparity.Text);
                    Public.SetXmlValue("baudrate", txtbaudRate.Text);
                    Public.SetXmlValue("ByteSize", txtDataBits.Text);

                    Public.SetXmlValue("HandShake", cmbHandShake.Text);
                    if (ckHandShake.Checked)
                    {
                        Public.SetXmlNodeAttr("HandShake", "isuse", "Y");
                    }
                    else
                        Public.SetXmlNodeAttr("HandShake", "isuse", "N");
                    Public.SetXmlValue("RtsEnable", cmbRtsEnable.Text);
                    if (ckRtsEnable.Checked) Public.SetXmlNodeAttr("RtsEnable", "isuse", "Y"); else Public.SetXmlNodeAttr("RtsEnable", "isuse", "N");
                    Public.SetXmlValue("DtrEnable", cmbDtrEnable.Text);
                    if (ckDtrEnable.Checked) Public.SetXmlNodeAttr("DtrEnable", "isuse", "Y"); else Public.SetXmlNodeAttr("DtrEnable", "isuse", "N");
                  
                    Public.SetXmlValue("DataStar", txtdatas.Text);
                    
                    if (ckdatas.Checked) 
                        Public.SetXmlNodeAttr("DataStar", "isuse", "Y"); 
                    else Public.SetXmlNodeAttr("DataStar", "isuse", "N");

                    Public.SetXmlValue("DataEnd", txtdatae.Text);
                    if (ckdatae.Checked)
                        Public.SetXmlNodeAttr("DataEnd", "isuse", "Y"); 
                    else 
                        Public.SetXmlNodeAttr("DataEnd", "isuse", "N");
                    Public.SetXmlValue("Pointwz", txtpoint.Text);
                    if (ckpoint.Checked) 
                        Public.SetXmlNodeAttr("Pointwz", "isuse", "Y"); 
                    else 
                        Public.SetXmlNodeAttr("Pointwz", "isuse", "N");
                    Public.SetXmlValue("DataStarChar", txtdataChars.Text);
                    if (ckdataChars.Checked) 
                        Public.SetXmlNodeAttr("DataStarChar", "isuse", "Y"); 
                    else 
                        Public.SetXmlNodeAttr("DataStarChar", "isuse", "N");
                    Public.SetXmlValue("DataEndChar", txtdataChare.Text);
                    if (ckdataChare.Checked) Public.SetXmlNodeAttr("DataEndChar", "isuse", "Y"); else Public.SetXmlNodeAttr("DataEndChar", "isuse", "N");
                        Public.SetXmlValue("DataLen", txtdatalen.Text);
                    if (ckdatalen.Checked) Public.SetXmlNodeAttr("DataLen", "isuse", "Y"); else Public.SetXmlNodeAttr("DataLen", "isuse", "N");

                    Public.SetXmlValue("JHCS", nujh.Value.ToString());
                    Public.SetXmlValue("QSJG",nudqsjg.Value.ToString());
                    jhcs = int.Parse(nujh.Value.ToString());
                    pointwz = int.Parse(txtpoint.Text);

                    MessageBox.Show("保存成功！");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("保存失败：" + ex.Message);
                }

            }
        }

        private void txtdataChare_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!s.IsOpen)
                {
                    if (!Public.openCom(s))
                    {
                        MessageBox.Show("打开失败！");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("打开成功！");
                    }
                }
            }
            else
            {
                if (!checkBox2.Checked)
                {
                    if (s.IsOpen)
                        s.Close();
                }
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
            txtError.Text += str + Environment.NewLine;
        }

        private void SetTextView(string sr)
        {
            txtError.Text += sr + Environment.NewLine;
        }

        private void s_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (s.BytesToRead <= 0) return;
                //txtError.Text += s.ReadExisting();
                int star = int.Parse(Public.GetXmlValue("DataStar"));
                int end = int.Parse(Public.GetXmlValue("DataEnd"));
                string startChar = Public.GetXmlValue("DataStarChar");
                int dataLength = int.Parse(Public.GetXmlValue("DataLen"));

                System.Threading.Thread.Sleep(int.Parse(nudqsjg.Value.ToString()));
                Control.CheckForIllegalCrossThreadCalls = false;
                string ss = s.ReadExisting();
                if (checkBox1.Checked)
                {
                    int startInt = ss.IndexOf(startChar);
                   // SetTwoShow(ss);
                    SetTextView("STARTCHAR:" + startChar+" LENGTH:"+dataLength.ToString()+" From:"+star.ToString()+" ALL:"+ ss);
                }
                if (checkBox2.Checked)
                {
                    int startInt = ss.IndexOf(startChar);
                    string jqStar = ss.Substring(startInt, dataLength);
                    SetTextView(" StartJQ:"+startInt.ToString()+" FirstSplit:"+jqStar);
                    //ss = ss.Substring(startInt, end - star);
                    ss = jqStar.Substring(star, end - star);
                    SetTextView("SPLIT:" + ss.ToString());
                    ss = int.Parse(ss).ToString();
                    if (ss != ssold)
                    {
                        SetLampStatus(false, lampZero);
                        zerocs = 0;
                    }
                    else
                    {
                        zerocs = zerocs + 1;
                        if (zerocs >= nujh.Value)
                        {
                            SetLampStatus(true, lampZero);
                        }
                        else
                        {
                            SetLampStatus(false, lampZero);
                        }
                    }
                    ssold = int.Parse(ss).ToString();
                    txtTestvalue.Text = ss;
                }

            }
            catch (Exception ex)
            {
                //txtError.Text += ex.Message + Environment.NewLine;
            }
        }
        string ssold = "";
        int zerocs = 0;
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
        private void frmComSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (s.IsOpen) s.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtError.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!s.IsOpen)
                {
                    if (!Public.openCom(s))
                    {
                        MessageBox.Show("打开失败！");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("打开成功！");
                    }
                }
            }
            else
            {

                if (!checkBox1.Checked)
                {
                    if (s.IsOpen)
                        s.Close();
                }
            }
        }
    }
}