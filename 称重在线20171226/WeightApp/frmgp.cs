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
    public partial class frmgp : Form
    {
        private string pch;

        

        public string Pch
        {
            get { return pch; }
            set { pch = value; }
        }

        private bool gpflag;

        public bool Gpflag
        {
            get { return gpflag; }
            set { gpflag = value; }
        }


        private string ph;

        public string Ph
        {
            get { return ph; }
            set { ph = value; }
        }
        private string gg;

        public string Gg
        {
            get { return gg; }
            set { gg = value; }
        }
        private string zxbz;

        public string Zxbz
        {
            get { return zxbz; }
            set { zxbz = value; }
        }
        private string wlh;

        public string Wlh
        {
            get { return wlh; }
            set { wlh = value; }
        }
        private string vfree0;

        public string Vfree0
        {
            get { return vfree0; }
            set { vfree0 = value; }
        }
        private string vfree1;

        public string Vfree1
        {
            get { return vfree1; }
            set { vfree1 = value; }
        }
        private string vfree2;

        public string Vfree2
        {
            get { return vfree2; }
            set { vfree2 = value; }
        }
        private string vfree3;

        public string Vfree3
        {
            get { return vfree3; }
            set { vfree3 = value; }
        }
        private string wlmc;

        public string Wlmc
        {
            get { return wlmc; }
            set { wlmc = value; }
        }
        private string pcinfo;

        public string Pcinfo
        {
            get { return pcinfo; }
            set { pcinfo = value; }
        }
        private string gpyy;

        public string Gpyy
        {
            get { return gpyy; }
            set { gpyy = value; }
        }

        public frmgp()
        {
            gpflag = false;
            InitializeComponent();
        }

        private void frmgp_Load(object sender, EventArgs e)
        {
            string sqlstr = "select distinct ph as phgg from wms_bms_rec_wgd_item where pch='"+pch+"'";
            lbyxx.Text = this.ph + ' ' + this.gg + ' ' + this.zxbz + ' ' + this.vfree0 + ' ' + this.vfree1 + ' ' + this.vfree2 + ' ' + this.vfree2;
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmbph.Items.Add(dr["phgg"].ToString());
            }
            sqlstr = "select distinct * from wms_pub_sx_gpreason";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmbgpyy.Items.Add(dr["Reason"].ToString());
            }
        }

        private void cmbph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbph.Text == "")
            {
                cmbphgg.Items.Clear();
                return;
            }
            string sqlstr = "select gg+'|'+isnull(zxbz,'')+'|'+isnull(vfree0,'')+'|'+" +
                "isnull(vfree1,'')+'|'+isnull(vfree2,'')+'|'+isnull(vfree3,'')+'|'+wlh+'|'+wlmc+'|'+" +
                "isnull(pcinfo,'') as phgg,ph,gg,zxbz from wms_bms_rec_wgd_item where pch='" + this.pch + "' and ph='"+cmbph.Text+
                "' and vfree3='"+this.vfree3+"' ";
            DataSet ds = null;
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmbphgg.Items.Add(dr["phgg"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gpflag = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbph.Text))
            {
                MessageBox.Show("牌号不能为空!");
                return; 
            }
            if (string.IsNullOrEmpty(cmbphgg.Text))
            {
                MessageBox.Show("改判项不能为空!");
                return;
            }
            if (MessageBox.Show("确认信息无误，是否改判？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                gpflag = false;
                return;
            }
            string[] vv = cmbphgg.Text.Split('|');
            this.ph = cmbph.Text;
            this.gg = vv[0];
            this.zxbz = vv[1];
            this.vfree0 = vv[2];
            this.vfree1 = vv[3];
            this.vfree2 = vv[4];
            this.vfree3 = vv[5];
            wlh = vv[6];
            wlmc = vv[7];
            pcinfo = vv[8];
            gpflag = true;
            gpyy = cmbgpyy.Text;
            Close();
        }
    }
}