using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace WeightApp
{
    public class SplashObject : IDisposable
    {
        private SplashInfo splashFormInfo;
        /// <summary>
        /// Splash闪屏窗体的各种设置信息，例如标题，背景图片、窗体大小等
        /// </summary>
        public SplashInfo SplashFormInfo
        {
            get { return splashFormInfo; }
            set { splashFormInfo = value; }
        }

        private bool stop = false;
        /// <summary>
        /// 通过设置此值为true来关闭闪屏
        /// </summary>
        public bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }

        /// <summary>
        /// SplashObject构建完成后，自动显示闪屏
        /// </summary>
        /// <param name="splashInfo"></param>
        public SplashObject(SplashInfo splashInfo)
        {
            this.splashFormInfo = splashInfo;
            Thread splashThread = new Thread(new ParameterizedThreadStart(StartThread));
            splashThread.Start(this);
        }

        /// <summary>
        /// 关闭闪屏
        /// </summary>
        public void Dispose()
        {
            this.stop = true;
        }

        private static void StartThread(object o)
        {
            SplashObject so = o as SplashObject;
            FrmLoading splashForm = new FrmLoading(so);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// 取得程序启动闪屏
        /// </summary>
        /// <returns>SplashObject</returns>
        public static SplashObject GetSplash()
        {
            SplashInfo si = new SplashInfo();
            si.BackImage = SplashResource.Splash;
            si.ShowCaption = false;
            si.TopMost = true;
            si.GradualMode = true;
            si.FormSize = new Size(989, 198);
            return new SplashObject(si);
        }

        /// <summary>
        /// 取得正在加载窗体
        /// </summary>
        /// <returns>SplashObject</returns>
        public static SplashObject GetLoading()
        {
            SplashInfo si = new SplashInfo();
            si.BackImage = SplashResource.Loading;
            si.ShowCaption = false;
            si.TopMost = true;
            si.GradualMode = true;
            si.FormSize = new Size(220, 120);
            return new SplashObject(si);
        }

        /// <summary>
        /// Splash闪屏窗体的各种设置信息，例如标题，背景图片、窗体大小等
        /// </summary>
        public class SplashInfo
        {
            private string text;
            /// <summary>
            /// 窗体标题
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }

            private bool showCaption;
            /// <summary>
            /// 设置是否显示Caption
            /// </summary>
            public bool ShowCaption
            {
                get { return showCaption; }
                set { showCaption = value; }
            }

            private bool gradualMode;
            /// <summary>
            /// 设置是否采用渐进模式
            /// </summary>
            public bool GradualMode
            {
                get { return gradualMode; }
                set { gradualMode = value; }
            }

            private bool topMost;
            /// <summary>
            /// 设置是否在最前端显示
            /// </summary>
            public bool TopMost
            {
                get { return topMost; }
                set { topMost = value; }
            }

            private Image backImage;
            /// <summary>
            /// 设置背景图片
            /// </summary>
            public Image BackImage
            {
                get { return backImage; }
                set { backImage = value; }
            }

            private Size formSize;
            /// <summary>
            /// 设置闪屏窗体大小
            /// </summary>
            public Size FormSize
            {
                get { return formSize; }
                set { formSize = value; }
            }
        }
    }
}
