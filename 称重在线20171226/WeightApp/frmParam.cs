using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lephone.Data;

namespace WeightApp
{
    public partial class frmParam : Form
    {
        public static bool isRunManMain;
        public frmParam()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool WeightUp;
        bool SCXParamWeightDown;
        int ZeroLow;
        int ZeroHight;
        int SCXParamRestKg;
        int SCXParamRests;
        int SCXParamUptime;
        bool AutoGetWeightFlag;
        int AutoGetWeightNum;
        double gpzlup;
        double gpzldown;
        double zlup;
        double zldown;

        private void frmParam_Load(object sender, EventArgs e)
        {
            
            string sqlstr = "select * from WMS_Pub_SCX where SCXNCID='"+Public.userdd+"'";
            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                WeightUp = bool.Parse(dr["WeightUp"].ToString());
                SCXParamWeightDown = bool.Parse(dr["SCXParamWeightDown"].ToString());
                ZeroLow = int.Parse(dr["ZeroLow"].ToString());
                ZeroHight = int.Parse(dr["ZeroHight"].ToString());
                SCXParamRestKg = int.Parse(dr["SCXParamRestKg"].ToString());
                SCXParamRests = int.Parse(dr["SCXParamRests"].ToString());
                SCXParamUptime = int.Parse(dr["SCXParamUptime"].ToString());
                AutoGetWeightFlag = bool.Parse(dr["AutoGetWeightFlag"].ToString());
                AutoGetWeightNum = int.Parse(dr["AutoGetWeightNum"].ToString());
                label9.Text = dr["scxname"].ToString();
                gpzlup = double.Parse(dr["GPZLUP"].ToString()==""?"0":dr["gpzlup"].ToString());
                gpzldown = double.Parse(dr["GPZLDOWN"].ToString() == "" ? "0" : dr["GPZLDOWN"].ToString());
                
                zlup = double.Parse(dr["zlsx"].ToString() == "" ? "0" : dr["zlsx"].ToString());
                zldown = double.Parse(dr["zlxx"].ToString() == "" ? "0" : dr["zlxx"].ToString());
                ckWeightUp.Checked = WeightUp;
                ckSCXParamWeightDown.Checked = SCXParamWeightDown;
                nudZeroLow.Value = ZeroLow;
                nudZeroHight.Value = ZeroHight;
                //nudSCXParamRestKg.Value = SCXParamRestKg;
                //nudSCXParamRests.Value = SCXParamRests;
                nudSCXParamUptime.Value = SCXParamUptime;
                ckAutoGetWeightFlag.Checked = AutoGetWeightFlag;
                nudAutoGetWeightNum.Value = AutoGetWeightNum;

                nudweightdown.Value = decimal.Parse(zldown.ToString());
                nudweightup.Value = decimal.Parse(zlup.ToString());
                nudGPZLUP.Value = decimal.Parse(gpzlup.ToString());
                nudGPZLDOWN.Value = decimal.Parse(gpzldown.ToString());
            }
            else
            {
                MessageBox.Show("操作员没有指定生产线,不能设置！");
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WeightUp = ckWeightUp.Checked;
                SCXParamWeightDown = ckSCXParamWeightDown.Checked;
                ZeroLow =int.Parse( nudZeroLow.Value.ToString());
                ZeroHight = int.Parse(nudZeroHight.Value.ToString());
                //SCXParamRestKg = int.Parse(nudSCXParamRestKg.Value.ToString());
                //SCXParamRests = int.Parse(nudSCXParamRests.Value.ToString());
                SCXParamUptime = int.Parse(nudSCXParamUptime.Value.ToString());
                AutoGetWeightFlag =ckAutoGetWeightFlag.Checked;
                AutoGetWeightNum = int.Parse(nudAutoGetWeightNum.Value.ToString());

                zlup = (double)nudweightup.Value;
                zldown = (double)nudweightdown.Value;

                gpzldown = (double)nudGPZLDOWN.Value;
                gpzlup = (double)nudGPZLUP.Value;

                string WeightUpv = WeightUp == true ? "1" : "0";
                string SCXParamWeightDownv = SCXParamWeightDown == true ? "1" : "0";
                string AutoGetWeightFlagv = AutoGetWeightFlag == true ? "1" : "0";

                string sqlstr = "update WMS_Pub_SCX set WeightUp=" + WeightUpv +
                    ",SCXParamWeightDown=" + SCXParamWeightDownv +
                    ",ZeroLow=" + ZeroLow.ToString() +
                    ",ZeroHight=" + ZeroHight.ToString() +
                    //",SCXParamRestKg=" + SCXParamRestKg.ToString() +
                    //",SCXParamRests=" + SCXParamRests.ToString() +
                    ",SCXParamUptime=" + SCXParamUptime.ToString() +
                    ",AutoGetWeightFlag=" + AutoGetWeightFlagv +
                    ",gpzlup=" + gpzlup.ToString() +
                    ",gpzldown=" + gpzldown.ToString() +
                    ",zlsx=" + zlup.ToString()+
                    ",zlxx="+zldown.ToString()+
                    ",AutoGetWeightNum=" + AutoGetWeightNum.ToString() + "  where SCXNCID='" + Public.userdd + "'";
                try
                {
                    DbEntry.Context.ExecuteNonQuery(sqlstr);
                    MessageBox.Show("设置成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("设置失败："+ex.Message);
                }
            }
        }

        private void ckWeightUp_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}