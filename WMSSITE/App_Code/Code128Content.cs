using System;
using System.Text;

/// <summary>
/// Code128Content 的摘要说明
/// </summary>
public enum CodeSet
{
    CodeA
    , CodeB
    // ,CodeC   
}


public class Code128Content
{
    private int[] mCodeList;


    public Code128Content(string AsciiData)
    {
        mCodeList = StringToCode128(AsciiData);
    }


    public int[] Codes
    {
        get
        {
            return mCodeList;
        }
    }


    private int[] StringToCode128(string AsciiData)
    {

        byte[] asciiBytes = Encoding.ASCII.GetBytes(AsciiData);


        Code128Code.CodeSetAllowed csa1 = asciiBytes.Length > 0 ? Code128Code.CodesetAllowedForChar(asciiBytes[0]) : Code128Code.CodeSetAllowed.CodeAorB;
        Code128Code.CodeSetAllowed csa2 = asciiBytes.Length > 1 ? Code128Code.CodesetAllowedForChar(asciiBytes[1]) : Code128Code.CodeSetAllowed.CodeAorB;
        CodeSet currcs = GetBestStartSet(csa1, csa2);


        System.Collections.ArrayList codes = new System.Collections.ArrayList(asciiBytes.Length + 3); // assume no codeset changes, account for start, checksum, and stop
        codes.Add(Code128Code.StartCodeForCodeSet(currcs));

        for (int i = 0; i < asciiBytes.Length; i++)
        {
            int thischar = asciiBytes[i];
            int nextchar = asciiBytes.Length > (i + 1) ? asciiBytes[i + 1] : -1;

            codes.AddRange(Code128Code.CodesForChar(thischar, nextchar, ref currcs));
        }


        int checksum = (int)(codes[0]);
        for (int i = 1; i < codes.Count; i++)
        {
            checksum += i * (int)(codes[i]);
        }
        codes.Add(checksum % 103);

        codes.Add(Code128Code.StopCode());

        int[] result = codes.ToArray(typeof(int)) as int[];
        return result;
    }


    private CodeSet GetBestStartSet(Code128Code.CodeSetAllowed csa1, Code128Code.CodeSetAllowed csa2)
    {
        int vote = 0;

        vote += (csa1 == Code128Code.CodeSetAllowed.CodeA) ? 1 : 0;
        vote += (csa1 == Code128Code.CodeSetAllowed.CodeB) ? -1 : 0;
        vote += (csa2 == Code128Code.CodeSetAllowed.CodeA) ? 1 : 0;
        vote += (csa2 == Code128Code.CodeSetAllowed.CodeB) ? -1 : 0;

        return (vote > 0) ? CodeSet.CodeA : CodeSet.CodeB;   // ties go to codeB due to my own prejudices
    }
}


public static class Code128Code
{
    #region Constants

    private const int cSHIFT = 98;
    private const int cCODEA = 101;
    private const int cCODEB = 100;

    private const int cSTARTA = 103;
    private const int cSTARTB = 104;
    private const int cSTOP = 106;

    #endregion


    public static int[] CodesForChar(int CharAscii, int LookAheadAscii, ref CodeSet CurrCodeSet)
    {
        int[] result;
        int shifter = -1;

        if (!CharCompatibleWithCodeset(CharAscii, CurrCodeSet))
        {

            if ((LookAheadAscii != -1) && !CharCompatibleWithCodeset(LookAheadAscii, CurrCodeSet))
            {

                switch (CurrCodeSet)
                {
                    case CodeSet.CodeA:
                        shifter = cCODEB;
                        CurrCodeSet = CodeSet.CodeB;
                        break;
                    case CodeSet.CodeB:
                        shifter = cCODEA;
                        CurrCodeSet = CodeSet.CodeA;
                        break;
                }
            }
            else
            {

                shifter = cSHIFT;
            }
        }

        if (shifter != -1)
        {
            result = new int[2];
            result[0] = shifter;
            result[1] = CodeValueForChar(CharAscii);
        }
        else
        {
            result = new int[1];
            result[0] = CodeValueForChar(CharAscii);
        }

        return result;
    }


    public static CodeSetAllowed CodesetAllowedForChar(int CharAscii)
    {
        if (CharAscii >= 32 && CharAscii <= 95)
        {
            return CodeSetAllowed.CodeAorB;
        }
        else
        {
            return (CharAscii < 32) ? CodeSetAllowed.CodeA : CodeSetAllowed.CodeB;
        }
    }


    public static bool CharCompatibleWithCodeset(int CharAscii, CodeSet currcs)
    {
        CodeSetAllowed csa = CodesetAllowedForChar(CharAscii);
        return csa == CodeSetAllowed.CodeAorB
                 || (csa == CodeSetAllowed.CodeA && currcs == CodeSet.CodeA)
                 || (csa == CodeSetAllowed.CodeB && currcs == CodeSet.CodeB);
    }


    public static int CodeValueForChar(int CharAscii)
    {
        return (CharAscii >= 32) ? CharAscii - 32 : CharAscii + 64;
    }


    public static int StartCodeForCodeSet(CodeSet cs)
    {
        return cs == CodeSet.CodeA ? cSTARTA : cSTARTB;
    }


    public static int StopCode()
    {
        return cSTOP;
    }


    public enum CodeSetAllowed
    {
        CodeA,
        CodeB,
        CodeAorB
    }

}
