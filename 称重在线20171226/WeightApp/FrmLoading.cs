using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WeightApp
{
    public partial class FrmLoading : Form
    {
        public FrmLoading(SplashObject o)
        {
            InitializeComponent();
            if (o.SplashFormInfo.GradualMode)
            {
                this.alphaBlendingBringer1.Interval = 200;
                this.alphaBlendingBringer1.SetAlphaBlending(this);
            }
            this.TopMost = o.SplashFormInfo.TopMost;
            if (o.SplashFormInfo.BackImage != null)
            {
                this.pictureBox1.Image = o.SplashFormInfo.BackImage;
            }
            if (o.SplashFormInfo.ShowCaption)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            this.Size = o.SplashFormInfo.FormSize;
            this.Text = o.SplashFormInfo.Text;
            this.splashObj = o;
        }
        private SplashObject splashObj;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.splashObj.Stop)
            {
                this.Close();
            }
        }

    }
}