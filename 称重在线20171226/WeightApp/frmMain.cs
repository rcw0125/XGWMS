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
    public partial class frmMain : Form
    {
        public static bool isRunMain;
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出？", "操作提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Public.userno != "") return;
            frmLogin frm = new frmLogin();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Public.userno != "")
            {
                if (MessageBox.Show("是否注销？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            Public.userno = "";
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Public.userno != "")
            {
                if (MessageBox.Show("是否注销？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            Public.userno = "";
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Public.userno != "") return;
            frmLogin frm = new frmLogin();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void 开关量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmPCLSet frmC = new frmPCLSet();
                frmC.ShowDialog();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmComSet frmC = new frmComSet();
                frmC.ShowDialog();
            }
        }

        private void 串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmComSet frmC = new frmComSet();
                frmC.ShowDialog();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmPCLSet frmC = new frmPCLSet();
                frmC.ShowDialog();
            }
        }

        private void 称重参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmParam.isRunManMain)
            {
                frmParam frmf = new frmParam();
                frmf.ShowDialog();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmManageMain frmman = new frmManageMain();
                frmman.ShowDialog();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmWeight frm = new frmWeight();
            frm.ShowDialog();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            toolStripButton7_Click(sender, e);
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void czToolBar_Click(object sender, EventArgs e)
        {
            frmManageLogin frm = new frmManageLogin();
            frm.ShowDialog();
            if (frmManageMain.isRunManMain == true)
            {
                frmManageMain frmman = new frmManageMain();
                frmman.ShowDialog();
            }
        }

        private void toolMenuBD_Click(object sender, EventArgs e)
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
                    printBFrm frmb = new printBFrm();
                    frmb.ShowDialog();
                }
            }
        }
    }
}