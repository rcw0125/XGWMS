using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class BarcodeImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["BINCODE"]))
            {
                Create39BarCode(Request["BINCODE"]);
            }
        }
    }

    private void Create39BarCode(string binCode)
    {
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(380,190);
        Graphics g = Graphics.FromImage(image);

        try
        {
             //清空图片背景色
            g.Clear(Color.White);
            Font font = new System.Drawing.Font("3 of 9 Barcode",45);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString("*"+binCode+"*", font, drawBrush,10, 40, drawFormat);
            g.DrawString(binCode, new Font("宋体", 26, System.Drawing.FontStyle.Bold), drawBrush,110,100, drawFormat);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
}
