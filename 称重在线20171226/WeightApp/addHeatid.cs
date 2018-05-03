using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WeightApp
{
    public partial class addHeatid : Form
    {
        public addHeatid()
        {
            InitializeComponent();
        }

        public bool add(string pch, ref string heatid)
        {
            label1.Text = "当前批次号为:"+pch;
            button1.Enabled = false;
            if (ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            heatid = textBox2.Text.Trim();
            return true;
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 9)
            {

                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            
            }

        }
    }
}
