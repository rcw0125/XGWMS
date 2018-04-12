using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

/// <summary>
/// BarCode128Manager 的摘要说明
/// </summary>
public class BarCode128Manager
{
    private DataTable _FormatTable = null;
    private Object _CurrentRow = null;
    //private Object _CurrentEnt = null;

    public BarCode128Manager(DataTable formatTable)
    {
        if (formatTable == null)
            throw new Exception();
        _FormatTable = formatTable;

    }

    /// <summary>
    /// 根据数据行返回图片
    /// </summary>
    /// <param name="oneRow"></param>
    /// <param name="moduleTable"></param>
    /// <returns></returns>
    public Image CreateImage(Object oneRow)
    {
        _CurrentRow = oneRow;
        return DrawPrintPic(null, oneRow, _FormatTable);
    }



    /// <summary>
    /// 预览
    /// </summary>
    /// <param name="oneRow"></param>
    public void Preview(Object oneRow)
    {
        _CurrentRow = oneRow;
        PrintDocument printDoc = new PrintDocument();
        printDoc.PrintPage += printDocPrintPage;
        PrintPreviewDialog preview = new PrintPreviewDialog();
        preview.Document = printDoc;

        preview.ShowDialog();
    }


    /// <summary>
    /// 打印
    /// </summary>
    /// <param name="oneRow"></param>
    public void Print(Object oneRow)
    {
        _CurrentRow = oneRow;
        PrintDocument printDoc = new PrintDocument();
        printDoc.PrintPage += printDocPrintPage;
        printDoc.Print();
    }



    private void printDocPrintPage(object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;

        float a = g.DpiX;
        float b = g.DpiY;
        //float c = newImage.HorizontalResolution;

        //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //g.DrawImage(newImage, 50, 110);


        //Code128Rendering.MakeBarcodeImage(
        //    g, txtInput.Text, int.Parse(txtWeight.Text), 0, true
        //    , 100, 200);

        g.PageUnit = GraphicsUnit.Millimeter;

        DrawPrintPic(g, _CurrentRow, _FormatTable);

    }

    /// <summary>
    /// 根据模版及数据信息绘制相应的图片
    /// </summary>
    /// <param name="g"></param>
    /// <param name="dataObject"></param>
    /// <param name="formatTable"></param>
    /// <returns></returns>
    private Image DrawPrintPic(Graphics g, Object dataObject, DataTable formatTable)
    {
        if (dataObject == null || formatTable == null)
            return null;

        //DataRow dataRow = null;
        //if (dataObject is DataRow)
        //    dataRow = (DataRow)dataObject;

        BarCode128PC barCode = null;
        foreach (DataRow oneRow in formatTable.Rows)
        {
            TxTDrawStyle drawStyle = (TxTDrawStyle)(Convert.ToInt32(oneRow["CONTROLSTYLE"]));
            switch (drawStyle)
            {
                case TxTDrawStyle.BACKGROUND:
                    float width = PubOperator.ToFloat(oneRow["ENDX"]) - PubOperator.ToFloat(oneRow["BEGINX"]);
                    float height = PubOperator.ToFloat(oneRow["ENDY"]) - PubOperator.ToFloat(oneRow["BEGINY"]);
                    barCode = new BarCode128PC(g, width, height, g == null ? 1F : PubOperator.PelsValue);

                    break;
                case TxTDrawStyle.TXT:
                    Font font = new Font(oneRow["FONTNAME"].ToString()
                        , PubOperator.ToFloat(oneRow["FONTVALUE"])
                        , (FontStyle)PubOperator.ToInt(oneRow["FONTSTYLE"]));
                    float beginX = 0;

                    string valueStr = ReturnValue(dataObject, oneRow);
                    SizeF stringSize = barCode.MainGraphics.MeasureString(valueStr, font);

                    switch ((AlignmentStyle)PubOperator.ToInt(oneRow["ALIGNMENT"]))
                    {
                        case AlignmentStyle.Right:

                            beginX = PubOperator.ToFloat(oneRow["IMAGEWIDTH"]) - stringSize.Width;
                            break;
                        case AlignmentStyle.Middle:
                            beginX = PubOperator.ToFloat(oneRow["IMAGEWIDTH"]) / 2 - stringSize.Width / 2 - 1;
                            break;
                        default:
                            beginX = 0;
                            break;
                    }
                    if (beginX < 0)
                        beginX = 0;
                    string s = oneRow["BEGINX"].ToString();
                    barCode.DrawText(valueStr, font, PubOperator.ToFloat(oneRow["BEGINX"]) + beginX, PubOperator.ToFloat(oneRow["BEGINY"]), false);
                    break;
                case TxTDrawStyle.LINE:
                    barCode.DrawLine(PubOperator.ToFloat(oneRow["CONTROLVALUE"]) / 10 * PubOperator.PelsValue
                        , PubOperator.ToFloat(oneRow["BEGINX"]), PubOperator.ToFloat(oneRow["BEGINY"])
                        , PubOperator.ToFloat(oneRow["ENDX"]) - PubOperator.ToFloat(oneRow["BEGINX"]) < 10 ? PubOperator.ToFloat(oneRow["BEGINX"]) : PubOperator.ToFloat(oneRow["ENDX"])
                        , PubOperator.ToFloat(oneRow["ENDY"]) - PubOperator.ToFloat(oneRow["BEGINY"]) < 10 ? PubOperator.ToFloat(oneRow["BEGINY"]) : PubOperator.ToFloat(oneRow["ENDY"]), false);
                    break;
                case TxTDrawStyle.BARCODE:
                    barCode.DrawBarcode(
                        ReturnValue(dataObject, oneRow)
                        , PubOperator.ToFloat(oneRow["IMAGEHEIGHT"])
                        , PubOperator.ToFloat(oneRow["BEGINX"]), PubOperator.ToFloat(oneRow["BEGINY"]), false, false);

                    break;
                case TxTDrawStyle.IMAGE:
                    Bitmap bm = null;
                    using (MemoryStream mem = new MemoryStream(Convert.FromBase64String(oneRow["CONTROLVALUE"].ToString())))
                    {
                        bm = Bitmap.FromStream(mem) as Bitmap;
                    }

                    barCode.DrawImage(PubOperator.ToFloat(oneRow["BEGINX"]), PubOperator.ToFloat(oneRow["BEGINY"]), bm);

                    break;
                default:
                    break;
            }
        }
        return barCode.Pictrue;
    }


    /// <summary>
    /// 返回绑定数据值
    /// </summary>
    /// <param name="dataObject"></param>
    /// <param name="formatRow"></param>
    /// <returns></returns>
    private string ReturnValue(object dataObject, DataRow formatRow)
    {
        string fieldName = formatRow["FIELDNAME"].ToString();
        string value = "";
        if (string.IsNullOrEmpty(fieldName))
        {
            value = formatRow["CONTROLVALUE"].ToString();
        }
        else if (dataObject is DataRow)
        {
            value = ((DataRow)dataObject)[fieldName].ToString();
        }
        else
        {
            PropertyInfo proInfo = dataObject.GetType().GetProperty(fieldName);
            if (proInfo != null)
                value = proInfo.GetValue(dataObject, null).ToString();
        }

        return value;
    }
}
