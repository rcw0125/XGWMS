using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// BarCode128PC 的摘要说明
/// </summary>
public class BarCode128PC
{

    #region Code patterns

    // in principle these rows should each have 6 elements
    // however, the last one -- STOP -- has 7. The cost of the
    // extra integers is trivial, and this lets the code flow
    // much more elegantly
    private readonly int[,] cPatterns = 
                     {
                        {2,1,2,2,2,2,0,0},  // 0
                        {2,2,2,1,2,2,0,0},  // 1
                        {2,2,2,2,2,1,0,0},  // 2
                        {1,2,1,2,2,3,0,0},  // 3
                        {1,2,1,3,2,2,0,0},  // 4
                        {1,3,1,2,2,2,0,0},  // 5
                        {1,2,2,2,1,3,0,0},  // 6
                        {1,2,2,3,1,2,0,0},  // 7
                        {1,3,2,2,1,2,0,0},  // 8
                        {2,2,1,2,1,3,0,0},  // 9
                        {2,2,1,3,1,2,0,0},  // 10
                        {2,3,1,2,1,2,0,0},  // 11
                        {1,1,2,2,3,2,0,0},  // 12
                        {1,2,2,1,3,2,0,0},  // 13
                        {1,2,2,2,3,1,0,0},  // 14
                        {1,1,3,2,2,2,0,0},  // 15
                        {1,2,3,1,2,2,0,0},  // 16
                        {1,2,3,2,2,1,0,0},  // 17
                        {2,2,3,2,1,1,0,0},  // 18
                        {2,2,1,1,3,2,0,0},  // 19
                        {2,2,1,2,3,1,0,0},  // 20
                        {2,1,3,2,1,2,0,0},  // 21
                        {2,2,3,1,1,2,0,0},  // 22
                        {3,1,2,1,3,1,0,0},  // 23
                        {3,1,1,2,2,2,0,0},  // 24
                        {3,2,1,1,2,2,0,0},  // 25
                        {3,2,1,2,2,1,0,0},  // 26
                        {3,1,2,2,1,2,0,0},  // 27
                        {3,2,2,1,1,2,0,0},  // 28
                        {3,2,2,2,1,1,0,0},  // 29
                        {2,1,2,1,2,3,0,0},  // 30
                        {2,1,2,3,2,1,0,0},  // 31
                        {2,3,2,1,2,1,0,0},  // 32
                        {1,1,1,3,2,3,0,0},  // 33
                        {1,3,1,1,2,3,0,0},  // 34
                        {1,3,1,3,2,1,0,0},  // 35
                        {1,1,2,3,1,3,0,0},  // 36
                        {1,3,2,1,1,3,0,0},  // 37
                        {1,3,2,3,1,1,0,0},  // 38
                        {2,1,1,3,1,3,0,0},  // 39
                        {2,3,1,1,1,3,0,0},  // 40
                        {2,3,1,3,1,1,0,0},  // 41
                        {1,1,2,1,3,3,0,0},  // 42
                        {1,1,2,3,3,1,0,0},  // 43
                        {1,3,2,1,3,1,0,0},  // 44
                        {1,1,3,1,2,3,0,0},  // 45
                        {1,1,3,3,2,1,0,0},  // 46
                        {1,3,3,1,2,1,0,0},  // 47
                        {3,1,3,1,2,1,0,0},  // 48
                        {2,1,1,3,3,1,0,0},  // 49
                        {2,3,1,1,3,1,0,0},  // 50
                        {2,1,3,1,1,3,0,0},  // 51
                        {2,1,3,3,1,1,0,0},  // 52
                        {2,1,3,1,3,1,0,0},  // 53
                        {3,1,1,1,2,3,0,0},  // 54
                        {3,1,1,3,2,1,0,0},  // 55
                        {3,3,1,1,2,1,0,0},  // 56
                        {3,1,2,1,1,3,0,0},  // 57
                        {3,1,2,3,1,1,0,0},  // 58
                        {3,3,2,1,1,1,0,0},  // 59
                        {3,1,4,1,1,1,0,0},  // 60
                        {2,2,1,4,1,1,0,0},  // 61
                        {4,3,1,1,1,1,0,0},  // 62
                        {1,1,1,2,2,4,0,0},  // 63
                        {1,1,1,4,2,2,0,0},  // 64
                        {1,2,1,1,2,4,0,0},  // 65
                        {1,2,1,4,2,1,0,0},  // 66
                        {1,4,1,1,2,2,0,0},  // 67
                        {1,4,1,2,2,1,0,0},  // 68
                        {1,1,2,2,1,4,0,0},  // 69
                        {1,1,2,4,1,2,0,0},  // 70
                        {1,2,2,1,1,4,0,0},  // 71
                        {1,2,2,4,1,1,0,0},  // 72
                        {1,4,2,1,1,2,0,0},  // 73
                        {1,4,2,2,1,1,0,0},  // 74
                        {2,4,1,2,1,1,0,0},  // 75
                        {2,2,1,1,1,4,0,0},  // 76
                        {4,1,3,1,1,1,0,0},  // 77
                        {2,4,1,1,1,2,0,0},  // 78
                        {1,3,4,1,1,1,0,0},  // 79
                        {1,1,1,2,4,2,0,0},  // 80
                        {1,2,1,1,4,2,0,0},  // 81
                        {1,2,1,2,4,1,0,0},  // 82
                        {1,1,4,2,1,2,0,0},  // 83
                        {1,2,4,1,1,2,0,0},  // 84
                        {1,2,4,2,1,1,0,0},  // 85
                        {4,1,1,2,1,2,0,0},  // 86
                        {4,2,1,1,1,2,0,0},  // 87
                        {4,2,1,2,1,1,0,0},  // 88
                        {2,1,2,1,4,1,0,0},  // 89
                        {2,1,4,1,2,1,0,0},  // 90
                        {4,1,2,1,2,1,0,0},  // 91
                        {1,1,1,1,4,3,0,0},  // 92
                        {1,1,1,3,4,1,0,0},  // 93
                        {1,3,1,1,4,1,0,0},  // 94
                        {1,1,4,1,1,3,0,0},  // 95
                        {1,1,4,3,1,1,0,0},  // 96
                        {4,1,1,1,1,3,0,0},  // 97
                        {4,1,1,3,1,1,0,0},  // 98
                        {1,1,3,1,4,1,0,0},  // 99
                        {1,1,4,1,3,1,0,0},  // 100
                        {3,1,1,1,4,1,0,0},  // 101
                        {4,1,1,1,3,1,0,0},  // 102
                        {2,1,1,4,1,2,0,0},  // 103
                        {2,1,1,2,1,4,0,0},  // 104
                        {2,1,1,2,3,2,0,0},  // 105
                        {2,3,3,1,1,1,2,0}   // 106
                     };


    #endregion Code patterns
    private const int cQuietWidth = 10;


    private Graphics _MainGraphics;
    private Bitmap _MainImage;
    public float PelsValue = 1F;

    private SolidBrush blackBrush = new SolidBrush(Color.Black);
    private SolidBrush whiteBrush = new SolidBrush(Color.White);

    //private int _Width;
    //private int _Height;

    //public int Width
    //{
    //    get
    //    {
    //        return _Width;
    //    }
    //    set
    //    {
    //        _Width = value;
    //    }
    //}
    public Graphics MainGraphics
    {
        get
        {
            return _MainGraphics;
        }
        set
        {
            _MainGraphics = value;
        }
    }

    private float PelsToMM(float cmValue)
    {
        //return (int)Math.Ceiling(_PelsValue * cmValue);
        return (cmValue / PelsValue);
    }

    /// <summary>
    /// 主图片大小
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public BarCode128PC(float width, float height)
    {
        width = PelsToMM(width);
        height = PelsToMM(height);
        //if (width <= 0 || height <= 0)
        //    return;
        if (width <= 0)
            width = 1;

        _MainImage = new System.Drawing.Bitmap((int)width, (int)height, PixelFormat.Format24bppRgb);//, PixelFormat.Format32bppRgb);

        _MainGraphics = Graphics.FromImage(_MainImage);
        //_MainGraphics.PageUnit = GraphicsUnit.Millimeter;
        _MainGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, width, height);
    }


    /// <summary>
    /// 主图片大小
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public BarCode128PC(Graphics g, float width, float height, float pelsValue)
    {
        PelsValue = pelsValue;
        width = PelsToMM(width);
        height = PelsToMM(height);

        if (width <= 0)
            width = 1;

        if (g != null)
        {
            _MainGraphics = g;

        }
        else
        {
            _MainImage = new System.Drawing.Bitmap((int)width, (int)height, PixelFormat.Format24bppRgb);//, PixelFormat.Format32bppRgb);

            _MainGraphics = Graphics.FromImage(_MainImage);
        }
        _MainGraphics.FillRectangle(System.Drawing.Brushes.White, 0, 0, width, height);
    }



    /// <summary>
    /// 绘制条码
    /// </summary>
    /// <param name="barCodeValue"></param>
    /// <param name="barWeight"></param>
    /// <param name="barHeight"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void DrawBarcode(string barCodeValue, float barHeight, float x, float y, bool viewText, bool cancel)
    {
        bool AddQuietZone = true;
        float barWeight = 1F / PelsValue;

        barHeight = PelsToMM(barHeight);
        x = PelsToMM(x);
        y = PelsToMM(y);


        Code128Content content = new Code128Content(barCodeValue);
        int[] codes = content.Codes;

        float width = ((codes.Length - 3) * 11 + 35) * barWeight;

        //height = Convert.ToInt32(System.Math.Ceiling(Convert.ToSingle(width) * .15F));
        if (AddQuietZone)
        {
            width += 2 * cQuietWidth * barWeight;
        }

        float cursor = x;//cQuietWidth * barWeight+x;

        for (int codeidx = 0; codeidx < codes.Length; codeidx++)
        {
            int code = codes[codeidx];


            for (int bar = 0; bar < 8; bar += 2)
            {

                float barwidth = cPatterns[code, bar] * barWeight;
                float spcwidth = cPatterns[code, bar + 1] * barWeight;


                if (barwidth > 0)
                {
                    _MainGraphics.FillRectangle(cancel ? whiteBrush : blackBrush, cursor, y, barwidth, barHeight);
                }

                cursor += (barwidth + spcwidth);
            }
        }

        if (viewText)
        {
            Font drawFont = new Font("宋体", 11);
            PointF drawPoint = new PointF(x, y + barHeight + 2);
            _MainGraphics.DrawString(barCodeValue, drawFont, cancel ? whiteBrush : blackBrush, drawPoint);
        }

    }


    /// <summary>
    /// 绘制文本
    /// </summary>
    /// <param name="barCodeValue"></param>
    /// <param name="barWeight"></param>
    /// <param name="barHeight"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void DrawText(string textValue, Font font, float x, float y, bool cancel)
    {
        x = PelsToMM(x);
        y = PelsToMM(y);


        if (font == null)
            font = new Font("宋体", 11);

        PointF drawPoint = new PointF(x, y);
        _MainGraphics.DrawString(textValue, font, cancel ? whiteBrush : blackBrush, drawPoint);
    }


    /// <summary>
    /// 绘制直线
    /// </summary>
    /// <param name="beginX"></param>
    /// <param name="beginY"></param>
    /// <param name="endX"></param>
    /// <param name="endY"></param>
    public void DrawLine(float lineWidth, float beginX, float beginY, float endX, float endY, bool cancel)
    {
        beginX = PelsToMM(beginX);
        beginY = PelsToMM(beginY);
        endX = PelsToMM(endX);
        endY = PelsToMM(endY);
        lineWidth = PelsToMM(lineWidth);


        Pen blackPen = new Pen(cancel ? Color.White : Color.Black, lineWidth);
        _MainGraphics.DrawLine(blackPen, beginX, beginY, endX, endY);
    }


    public Image Pictrue
    {
        get
        {
            return _MainImage;
        }
    }

    /// <summary>
    /// 绘制直线
    /// </summary>
    /// <param name="beginX"></param>
    /// <param name="beginY"></param>
    /// <param name="endX"></param>
    /// <param name="endY"></param>
    public void DrawClear(float x, float y)
    {
        x = PelsToMM(x);
        y = PelsToMM(y);
        _MainGraphics.FillRectangle(whiteBrush, x - 5, y - 5, 10, 10);
    }

    /// <summary>
    /// 画图片
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="addImage"></param>
    public void DrawImage(float x, float y, Image addImage)
    {
        x = PelsToMM(x);
        y = PelsToMM(y);

        if (addImage == null)
            return;

        _MainGraphics.DrawImage(addImage, x, y);
    }

}
