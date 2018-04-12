using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

/// <summary>
/// PubOperator 的摘要说明
/// </summary>
/// <summary>
/// 图片类型
/// </summary>
public enum TxTDrawStyle
{
    BACKGROUND,
    TXT,
    LINE,
    BARCODE,
    IMAGE
}

/// <summary>
/// 对齐方式
/// </summary>
public enum AlignmentStyle
{
    Left = 0,
    Right = 1,
    Middle = 2
}

/// <summary>
/// 字体类型
/// </summary>
public enum TxTFontStyle
{
    Regular = 0,
    //
    // 摘要:
    //     加粗文本。
    Bold = 1,
    //
    // 摘要:
    //     倾斜文本。
    Italic = 2,
    //
    // 摘要:
    //     带下划线的文本。
    Underline = 4,
    //
    // 摘要:
    //     中间有直线通过的文本。
    Strikeout = 8
}

public class DataEnt
{

    private TxTDrawStyle _Style;
    private string _Value = "";
    private string _FieldName = "";
    //private string _FontName = "";
    //private int _FontValue = 11;
    //private TxTFontStyle _FontStyle = TxTFontStyle.Regular;
    private Point _EndPoint = new Point(1, 1);
    private AlignmentStyle _Alignment = AlignmentStyle.Left;
    private Font _Font = new Font("宋体", 9);




    public DataEnt(TxTDrawStyle style, string value, string fieldName
        //, string fontName, int fontValue, int fontStyle)
            , Font font, int alignmentIndex)
    {
        _Style = style;
        _Value = value;
        _FieldName = fieldName;
        //_FontName = fontName;
        //_FontValue = fontValue;
        //_FontStyle = (TxTFontStyle)fontStyle;
        _Font = font;
        _Alignment = (AlignmentStyle)alignmentIndex;
    }

    public AlignmentStyle Alignment
    {
        set
        {
            _Alignment = value;
        }
        get
        {
            return _Alignment;
        }
    }

    public Point EndPoint
    {
        set
        {
            _EndPoint = value;
        }
        get
        {
            return _EndPoint;
        }
    }

    public TxTDrawStyle Style
    {
        set
        {
            _Style = value;
        }
        get
        {
            return _Style;
        }
    }

    public Font Font
    {
        set
        {
            _Font = value;
        }
        get
        {
            return _Font;
        }
    }


    //public TxTFontStyle FontStyle
    //{
    //    set
    //    {
    //        _FontStyle = value;
    //    }
    //    get
    //    {
    //        return _FontStyle;
    //    }
    //}

    //public int FontValue
    //{
    //    set
    //    {
    //        _FontValue = value;
    //    }
    //    get
    //    {
    //        return _FontValue;
    //    }
    //}

    //public string FontName
    //{
    //    set
    //    {
    //        _FontName = value;
    //    }
    //    get
    //    {
    //        return _FontName;
    //    }
    //}

    public string Value
    {
        set
        {
            _Value = value;
        }
        get
        {
            return _Value;
        }
    }

    public string FieldName
    {
        set
        {
            _FieldName = value;
        }
        get
        {
            return _FieldName;
        }
    }


}

public static class PubOperator
{
    public static float PelsValue = 3.6f;
    public static string BindStr = "[BindingData]";



    public static float MMTOPels(decimal mmValue)
    {
        //return (int)Math.Ceiling(PelsValue * (float)mmValue);
        return PelsValue * (float)mmValue;
    }


    public static decimal PelsTOMM(int peValue)
    {
        //            return (int)Math.Ceiling(peValue / PelsValue);
        return Convert.ToDecimal(peValue / PelsValue);
    }


    public static PictureBox CreatePicBox(TxTDrawStyle style, string value
        , string name, decimal left, decimal top, decimal width
        , decimal height
        , Font font, int alignmentIndex
        , string fieldName)
    {
        PictureBox addPic = new PictureBox();
        addPic.Name = name;

        //字体的磅值=字体的实际高度(厘米)×1.073÷0.035
        addPic.BorderStyle = BorderStyle.FixedSingle;

        // moveEnt.SetControlMove(addPic);

        addPic.Width = (int)MMTOPels(width);
        addPic.Height = (int)MMTOPels(height);

        addPic.Left = (int)MMTOPels(left);
        addPic.Top = (int)MMTOPels(top);
        DataEnt data = new DataEnt(style, value, fieldName, font, alignmentIndex);


        addPic.Tag = data;
        return addPic;
    }


    public static PictureBox CreatePicBoxPil(TxTDrawStyle style, string value
        , string name, decimal left, decimal top, decimal width
        , decimal height
        , Font font, int alignmentIndex
        , string fieldName)
    {
        PictureBox addPic = new PictureBox();
        addPic.Name = name;

        addPic.BorderStyle = BorderStyle.FixedSingle;

        //moveEnt.SetControlMove(addPic);

        addPic.Width = (int)width;
        addPic.Height = (int)height;

        addPic.Left = (int)left;
        addPic.Top = (int)top;
        DataEnt data = new DataEnt(style, value, fieldName, font, alignmentIndex);


        addPic.Tag = data;
        return addPic;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToStr(object str)
    {
        if (Convert.IsDBNull(str) || str == null)
            return "";
        else
            return str.ToString();
    }

    /// <summary>
    /// 根据传过来的object,转换成decimal
    /// </summary>
    /// <param name="intStr"></param>
    /// <returns></returns>
    public static decimal ToDec(object intStr)
    {
        if (Convert.IsDBNull(intStr)
            || intStr == null
            || string.IsNullOrEmpty(intStr.ToString()))
            return 0;
        else
        {
            try
            {
                return decimal.Parse(intStr.ToString());
            }
            catch
            {
                return decimal.Parse("0");
            }
        }
    }


    /// <summary>
    /// 根据传过来的object,转换成float
    /// </summary>
    /// <param name="intStr"></param>
    /// <returns></returns>
    public static float ToFloat(object intStr)
    {
        if (Convert.IsDBNull(intStr)
            || intStr == null
            || string.IsNullOrEmpty(intStr.ToString()))
            return 0;
        else
        {
            try
            {
                return float.Parse(intStr.ToString());
            }
            catch
            {
                return float.Parse("0");
            }
        }
    }

    /// <summary>
    /// 根据传过来的object,转换成float
    /// </summary>
    /// <param name="intStr"></param>
    /// <returns></returns>
    public static int ToInt(string intStr)
    {
        try
        {
            if (Convert.IsDBNull(intStr) || intStr == null)
                return 0;
            return Int32.Parse(intStr);
        }
        catch
        {
            return 0;
        }
    }


    /// <summary>
    /// 根据传过来的object,转换成int
    /// </summary>
    /// <param name="intStr"></param>
    /// <returns></returns>
    public static int ToInt(object intStr)
    {
        try
        {
            return ToInt(intStr.ToString());
        }
        catch
        {
            try
            {
                return (int)(intStr);
            }
            catch
            {
                return 0;
            }
        }
    }

}
