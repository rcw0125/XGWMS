using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.ServiceProcess;
using System.Text;
//该源码下载自C#编程网|www.cpbcw.com
namespace WeightApp
{
    /// <summary>
    /// 渐进模式
    /// </summary>
    partial class AlphaBlendingBringer : Component
    {
        System.Windows.Forms.Form form = null;

        public AlphaBlendingBringer()
        {
            InitializeComponent();
        }

        public AlphaBlendingBringer(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            double d = 1000.0 / fadeTimer.Interval / 100.0;
            if (form.Opacity + d >= 1.0)
            {
                form.Opacity = 1.0;
                fadeTimer.Stop();
            }
            else
            {
                form.Opacity += d;
            }
        }

        public void SetAlphaBlending(System.Windows.Forms.Form form)
        {
            this.form = form;
            this.form.Opacity = 0.0;
            this.form.Activate();
            this.form.Refresh();
            fadeTimer.Start();
        }

        public int Interval
        {
            set
            {
                this.fadeTimer.Interval = value;
            }
        }
    }
}
