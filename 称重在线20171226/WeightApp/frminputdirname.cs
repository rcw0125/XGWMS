using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightApp
{
    public partial class frminputdirname : Form
    {
        public static string inputmodename = "";
        public frminputdirname()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputmodename = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_modename.Text == "")
            {
                MessageBox.Show("输入模板套名称！","系统提示");
                return;
            }
            inputmodename = txt_modename.Text;
            Close();
        }
    }
}