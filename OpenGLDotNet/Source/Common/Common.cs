using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Common
{
    ///////////////////////////////////////////////////////////////////////////
    // Conversion functions
    ///////////////////////////////////////////////////////////////////////////
    #region Object: ConvertX...
    public static class ConvertX
    {
        private static string ReplaceSplitters(string prmValue)
        {
            prmValue = prmValue.Replace(';', ',');
            prmValue = prmValue.Replace(':', ',');
            prmValue = prmValue.Replace('.', ',');
            prmValue = prmValue.Replace('-', ',');
            prmValue = prmValue.Replace('_', ',');

            return prmValue;
        }

        private static string PreProcess(string prmValue, string prmPreProcess)
        {
            prmPreProcess = ReplaceSplitters(prmPreProcess);
            string[] strPreProcessValues = prmPreProcess.Split(',');

            for (int Counter = 0; Counter < strPreProcessValues.Length; Counter++)
            {
                string strPreProcessValue = strPreProcessValues[Counter].Trim().ToLower();

                if (!String.IsNullOrEmpty(strPreProcessValue))
                {
                    if (strPreProcessValue == "trim")
                    {
                        prmValue = prmValue.Trim();
                    }

                    if (strPreProcessValue == "lower")
                    {
                        prmValue = prmValue.ToLower();
                    }

                    if (strPreProcessValue == "upper")
                    {
                        prmValue = prmValue.ToUpper();
                    }

                    if (strPreProcessValue == "space")
                    {
                        prmValue = prmValue.Replace(" ", "");
                    }

                    if (strPreProcessValue == "whitespace")
                    {
                        while (prmValue.Contains("  "))
                        {
                            prmValue = prmValue.Replace("  ", " ");
                        }
                    }

                    if (strPreProcessValue == "striptags")
                    {
                        prmValue = HtmlX.StripTags(prmValue);
                    }
                }
            }

            return prmValue;
        }

        public static string ToString(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, string prmDefault)
        {
            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault;
                }
            }

            // Check Valid Values
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    CheckCount++;

                    if (strValidValue == prmValue)
                    {
                        ValidFound = true;
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                prmValue = prmDefault;
            }

            // Return result;
            return prmValue;
        }

        public static byte ToByte(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, byte prmDefault)
        {
            byte result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = Byte.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            byte ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = Byte.TryParse(strValidValue, out ValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (ValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static sbyte ToSByte(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, sbyte prmDefault)
        {
            sbyte result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = SByte.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            sbyte intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = SByte.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static ushort ToUShort(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, ushort prmDefault)
        {
            ushort result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = ushort.TryParse(prmValue, out result);
            
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            ushort intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = ushort.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static short ToShort(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, short prmDefault)
        {
            short result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = short.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            short intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = short.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static uint ToUInt(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, uint prmDefault)
        {
            uint result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = uint.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            uint intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = uint.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static int ToInt(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, int prmDefault)
        {
            int result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = int.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            int intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = int.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static ulong ToULong(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, ulong prmDefault)
        {
            ulong result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = ulong.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            ulong intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = ulong.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static long ToLong(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, long prmDefault)
        {
            long result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = long.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            long intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = long.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static float ToFloat(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, float prmDefault)
        {
            float result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = float.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            float intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = float.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static double ToDouble(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, double prmDefault)
        {
            double result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = double.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            double intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = double.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }

        public static decimal ToDecimal(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, decimal prmDefault)
        {
            decimal result;
            bool converted;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // First Try to Parse
            converted = decimal.TryParse(prmValue, out result);
            if (!converted)
            {
                result = prmDefault;
            }

            // Check Length
            if (prmLength != 0)
            {
                if (result.ToString().Length != prmLength)
                {
                    result = prmDefault;
                }
            }

            // Check Valid Values
            decimal intValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = decimal.TryParse(strValidValue, out intValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (intValidValue == result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                result = prmDefault;
            }

            // Return result;
            return result;
        }
    }
    #endregion

    ///////////////////////////////////////////////////////////////////////////
    // Value functions
    ///////////////////////////////////////////////////////////////////////////
    #region Object: ValueX...
    public static class ValueX
    {
        ///////////////////////////////////////////////////////////////////////////
        // "Bit" constants
        ///////////////////////////////////////////////////////////////////////////
        #region Bit constants...
        public enum Bits : uint
        {
            Bit00 = 0x00000001U,
            Bit01 = 0x00000002U,
            Bit02 = 0x00000004U,
            Bit03 = 0x00000008U,
            Bit04 = 0x00000010U,
            Bit05 = 0x00000020U,
            Bit06 = 0x00000040U,
            Bit07 = 0x00000080U,
            Bit08 = 0x00000100U,
            Bit09 = 0x00000200U,
            Bit10 = 0x00000400U,
            Bit11 = 0x00000800U,
            Bit12 = 0x00001000U,
            Bit13 = 0x00002000U,
            Bit14 = 0x00004000U,
            Bit15 = 0x00008000U,
            Bit16 = 0x00010000U,
            Bit17 = 0x00020000U,
            Bit18 = 0x00040000U,
            Bit19 = 0x00080000U,
            Bit20 = 0x00100000U,
            Bit21 = 0x00200000U,
            Bit22 = 0x00400000U,
            Bit23 = 0x00800000U,
            Bit24 = 0x01000000U,
            Bit25 = 0x02000000U,
            Bit26 = 0x04000000U,
            Bit27 = 0x08000000U,
            Bit28 = 0x10000000U,
            Bit29 = 0x20000000U,
            Bit30 = 0x40000000U,
            Bit31 = 0x80000000U
        }
        #endregion
    }
    #endregion

    ///////////////////////////////////////////////////////////////////////////
    // String functions
    ///////////////////////////////////////////////////////////////////////////
    #region Object: StringX...
    public class StringX
    {
        public string String = null;

        public StringX(string prmString)
        {
            this.String = prmString;
        }

        public override string ToString()
        {
            return this.String;
        }

        public static bool operator ==(StringX lhs, string rhs)
        {
            bool Result = false;

            if (Object.ReferenceEquals(lhs, rhs))
            {
                Result = true;
            }

            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null))
            {
                Result = true;
            }

            if (!Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null))
            {
                if (lhs.String == rhs || Object.ReferenceEquals(lhs.String, rhs))
                {
                    Result = true;
                }
            }

            return Result;
        }

        public static bool operator !=(StringX lhs, string rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator ==(string lhs, StringX rhs)
        {
            bool Result = false;

            if (Object.ReferenceEquals(lhs, rhs))
            {
                Result = true;
            }

            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null))
            {
                Result = true;
            }

            if (!Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null))
            {
                if (lhs == rhs.String || Object.ReferenceEquals(lhs, rhs.String))
                {
                    Result = true;
                }
            }

            return Result;
        }

        public static bool operator !=(string lhs, StringX rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator ==(StringX lhs, StringX rhs)
        {
            bool Result = false;

            if (Object.ReferenceEquals(lhs, rhs))
            {
                Result = true;
            }

            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null))
            {
                Result = true;
            }

            if (!Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null))
            {
                if (lhs.String == rhs.String)
                {
                    Result = true;
                }
            }

            return Result;
        }

        public static bool operator !=(StringX lhs, StringX rhs)
        {
            return !(lhs == rhs);
        }
        
        public static implicit operator string(StringX value)
        {
            if (Object.ReferenceEquals(value, null))
            {
                return null;
            }
            else
            {
                return value.String;
            }
        }

        public static implicit operator StringX(string value)
        {
            return new StringX(value);
        }

        public override bool Equals(object obj)
        {
            bool Result = false;

            // First, compare StringX to StringX
            if (this.GetType() == obj.GetType() && this is StringX && obj is StringX)
            {
                // Check whether we have same instance
                if (Object.ReferenceEquals(this, obj))
                {
                    Result = true;
                }

                // Check whether both objects are null
                if (Object.ReferenceEquals(this, null) && Object.ReferenceEquals(obj, null))
                {
                    Result = true;
                }

                // Check whether the "contents" are the same
                if (!Object.ReferenceEquals(this, null) && !Object.ReferenceEquals(obj, null))
                {
                    if (this.String == ((StringX)obj).String)
                    {
                        Result = true;
                    }
                }
            }

            // After that, compare StringX to String
            if (this.GetType() != obj.GetType() && this is StringX && obj is String)
            {
                // Check whether we have same instance
                if (Object.ReferenceEquals(this, obj))
                {
                    Result = true;
                }

                // Check whether both objects are null
                if (Object.ReferenceEquals(this, null) && Object.ReferenceEquals(obj, null))
                {
                    Result = true;
                }

                // Check whether the "contents" are the same
                if (!Object.ReferenceEquals(this, null) && !Object.ReferenceEquals(obj, null))
                {
                    if (this.String == ((String)obj))
                    {
                        Result = true;
                    }
                }
            }

            return Result;
        }

        public override int GetHashCode()
        {
            return this.String.GetHashCode();
        }

        public StringX ToLower(string CultureName = "tr")
        {
            System.Globalization.CultureInfo _CultureInfo = null;

            CultureName = CultureName.ToLower();

            switch (CultureName)
            {
                case "en":
                case "eng":
                    _CultureInfo = new System.Globalization.CultureInfo("en-US");
                    return new StringX(this.String.ToLower(_CultureInfo));

                case "tr":
                case "tur":
                    _CultureInfo = new System.Globalization.CultureInfo("tr-TR");
                    return new StringX(this.String.ToLower(_CultureInfo));

                default:
                    _CultureInfo = new System.Globalization.CultureInfo("tr-TR");
                    return new StringX(this.String.ToLower(_CultureInfo));
            }
        }

        public StringX ToUpper(string CultureName = "tr")
        {
            System.Globalization.CultureInfo _CultureInfo = null;

            CultureName = CultureName.ToLower();

            switch (CultureName)
            {
                case "en":
                case "eng":
                    _CultureInfo = new System.Globalization.CultureInfo("en-US");
                    return new StringX(this.String.ToUpper(_CultureInfo));

                case "tr":
                case "tur":
                    _CultureInfo = new System.Globalization.CultureInfo("tr-TR");
                    return new StringX(this.String.ToUpper(_CultureInfo));

                default:
                    _CultureInfo = new System.Globalization.CultureInfo("tr-TR");
                    return new StringX(this.String.ToUpper(_CultureInfo));
            }
        }

        public StringX Replace(char find, char replace)
        {
            return new StringX(this.String.Replace(find, replace));
        }

        public StringX Replace(string find, string replace)
        {
            return new StringX(this.String.Replace(find, replace));
        }

        public StringX Trim()
        {
            return new StringX(this.String.Trim());
        }

        public StringX TrimLeft()
        {
            return new StringX(this.String.TrimStart());
        }

        public StringX TrimRight()
        {
            return new StringX(this.String.TrimEnd());
        }

        public bool ToBoolean()
        {
            if (this.String == "1" || this.String == "on" || this.String == "true" || this.String == "yes" || this.String == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public StringX Quote()
        {
            return new StringX("'" + this.String.Replace("'", "''") + "'");
        }

        public int Length()
        {
            return this.String.Length;
        }

        public StringX SubString(int StartIndex, int Length)
        {
            return new StringX(this.String.Substring(StartIndex, Length));
        }

        public StringX SubString(int StartIndex)
        {
            return new StringX(this.String.Substring(StartIndex));
        }

        public StringX[] Split(char[] delimiter)
        {
            string[] splitted = this.String.Split(delimiter, StringSplitOptions.None);

            StringX[] result = new StringX[splitted.Length];

            for (uint counter = 0; counter < result.Length; counter++)
            {
                result[counter] = new StringX(splitted[counter]);
            }

            return result;
        }

        public StringX[] Split(string[] delimiter)
        {
            string[] splitted = this.String.Split(delimiter, StringSplitOptions.None);

            StringX[] result = new StringX[splitted.Length];

            for (uint counter = 0; counter < result.Length; counter++)
            {
                result[counter] = new StringX(splitted[counter]);
            }

            return result;
        }

        public StringX Join(char glue, string[] pieces)
        {
            string result = String.Empty;

            for (uint counter = 0; counter < pieces.Length; counter++)
            {
                if (!String.IsNullOrEmpty(pieces[counter]))
                {
                    if (String.IsNullOrEmpty(result))
                    {
                        result = pieces[counter];
                    }
                    else
                    {
                        result += glue + pieces[counter];
                    }
                }
            }

            return new StringX(result);
        }

        public StringX Join(string glue, string[] pieces)
        {
            string result = String.Empty;

            for (uint counter = 0; counter < pieces.Length; counter++)
            {
                if (!String.IsNullOrEmpty(pieces[counter]))
                {
                    if (String.IsNullOrEmpty(result))
                    {
                        result = pieces[counter];
                    }
                    else
                    {
                        result += glue + pieces[counter];
                    }
                }
            }

            return new StringX(result);
        }

        public StringX Empty()
        {
            return new StringX(String.Empty);
        }

        public bool IsEmpty()
        {
            return (this.String == String.Empty || this.String == "" || this.String == null);
        }

        public bool IsNullOrEmpty()
        {
            return String.IsNullOrEmpty(this.String);
        }

        public bool IsNullOrWhiteSpace()
        {
            string value = this.String.Trim();

            return String.IsNullOrEmpty(value);
        }

        public bool Contains(string SubString)
        {
            return this.String.Contains(SubString);
        }

        public int ScanLeft(char SubChar)
        {
            return this.String.IndexOf(SubChar);
        }

        public int ScanLeft(string SubString)
        {
            return this.String.IndexOf(SubString);
        }

        public int ScanRight(char SubChar)
        {
            return this.String.LastIndexOf(SubChar);
        }

        public int ScanRight(string SubString)
        {
            return this.String.LastIndexOf(SubString);
        }

        public char[] ToCharArray()
        {
            return this.String.ToCharArray();
        }

        public bool IsValidEmail()
        {
            // Shortest possible email address: a@a.co
            if (this.IsNullOrWhiteSpace() || this.Length() < 6)
            {
                return false;
            }
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,4})(\]?)$";
                Regex re = new Regex(strRegex);
                return re.IsMatch(this.String);
            }
        }

        public bool IsValidUrl()
        {
            string pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(this.String);
        }

        protected bool IsValidDecimal(char Decimal)
        {
            return (Decimal == '0' || Decimal == '1' || Decimal == '2' || Decimal == '3' || Decimal == '4' ||
                    Decimal == '5' || Decimal == '6' || Decimal == '7' || Decimal == '8' || Decimal == '9');
        }

        public bool IsValidDecimal()
        {
            bool result = true;

            char[] prmChars = this.String.ToCharArray();

            for (uint counter = 0; counter < prmChars.Length; counter++)
            {
                if (!IsValidDecimal(prmChars[counter]))
                {
                    result = false;
                }
            }

            return result;
        }

        protected bool IsValidHex(char Hex)
        {
            return (Hex == '0' || Hex == '1' || Hex == '2' || Hex == '3' || Hex == '4' || Hex == '5' || Hex == '6' ||
                    Hex == '7' || Hex == '8' || Hex == '9' || Hex == 'A' || Hex == 'B' || Hex == 'C' || Hex == 'D' ||
                    Hex == 'E' || Hex == 'F' || Hex == 'a' || Hex == 'b' || Hex == 'c' || Hex == 'd' || Hex == 'e' ||
                    Hex == 'f');
        }

        public bool IsValidHex()
        {
            bool result = true;

            char[] prmChars = this.String.ToUpper().ToCharArray();

            for (uint counter = 0; counter < prmChars.Length; counter++)
            {
                if (!IsValidHex(prmChars[counter]))
                {
                    result = false;
                }
            }

            return result;
        }

        public bool IsValidGuid()
        {
            bool result = false;

            if (this.Length() == 32)
            {
                result = this.IsValidHex();
            }

            if (this.Length() == 36)
            {
                StringX guidShort = this.Replace("-", "");

                result = (this.Length() == 36 && guidShort.Length() == 32 && guidShort.IsValidHex() &&
                          this.SubString(8, 1) == "-" && this.SubString(13, 1) == "-" &&
                          this.SubString(18, 1) == "-" && this.SubString(23, 1) == "-");
            }

            return result;
        }

        public bool IsValidIPv4()
        {
            bool result = true;
            byte IPv4Byte = 0;

            string[] IPv4Addresses = this.String.Split('.');

            if (IPv4Addresses.Length == 4)
            {
                for (int counter = 0; counter < IPv4Addresses.Length; counter++)
                {
                    IPv4Addresses[counter] = IPv4Addresses[counter].PadLeft(3, '0');

                    if (IPv4Addresses[counter].Length == 3)
                    {
                        if (!Byte.TryParse(IPv4Addresses[counter], out IPv4Byte))
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public string ToMD5()
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

            byte[] ByteArray = System.Text.Encoding.Unicode.GetBytes(this.String);
            ByteArray = MD5.ComputeHash(ByteArray);

            StringBuilder sb = new StringBuilder();

            foreach (byte Byte in ByteArray)
            {
                sb.Append(Byte.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
    #endregion

    ///////////////////////////////////////////////////////////////////////////
    // Date & Time functions
    ///////////////////////////////////////////////////////////////////////////
    #region Object: DateX...
    public class DateX
    {
        protected const short SQLYearMin = 1900;

        protected sbyte _day = -1;
        protected sbyte _month = -1;
        protected short _year = -1;
        protected sbyte _hour = -1;
        protected sbyte _minute = -1;
        protected sbyte _second = -1;
        protected short _millisecond = -1;

        protected void CheckDateLimits(string CheckType)
        {
            CheckType = CheckType.ToLower();

            if (CheckType == "short" || CheckType == "long")
            {
                if (CheckType == "short")
                {
                    if (this._day < 1 || this._day > 31)
                    {
                        this._day = -1;
                    }

                    if (this._month < 1 || this._month > 12)
                    {
                        this._month = -1;
                    }

                    if (this._year < SQLYearMin)
                    {
                        this._year = -1;
                    }

                    if (this._day == -1 || this._month == -1 || this._year == -1)
                    {
                        this._day = -1;
                        this._month = -1;
                        this._year = -1;
                    }
                }

                if (CheckType == "long")
                {
                    if (this._day < 1 || this._day > 31)
                    {
                        this._day = -1;
                    }

                    if (this._month < 1 || this._month > 12)
                    {
                        this._month = -1;
                    }

                    if (this._year < SQLYearMin)
                    {
                        this._year = -1;
                    }

                    if (this._hour < 0 || this._hour > 23)
                    {
                        this._hour = -1;
                    }

                    if (this._minute < 0 || this._minute > 59)
                    {
                        this._minute = -1;
                    }

                    if (this._second < 0 || this._second > 59)
                    {
                        this._second = -1;
                    }

                    if (this._millisecond < 0 || this._millisecond > 999)
                    {
                        this._millisecond = -1;
                    }

                    if (this._day == -1 || this._month == -1 || this._year == -1 || this._hour == -1 || this._minute == -1 || this._second == -1 || this._millisecond == -1)
                    {
                        this._day = -1;
                        this._month = -1;
                        this._year = -1;
                        this._hour = -1;
                        this._minute = -1;
                        this._second = -1;
                        this._millisecond = -1;
                    }
                }
            }
            else
            {
                this._day = -1;
                this._month = -1;
                this._year = -1;
                this._hour = -1;
                this._minute = -1;
                this._second = -1;
                this._millisecond = -1;
            }
        }
        
        public DateX(sbyte Day, sbyte Month, short Year)
        {
            this._day = Day;
            this._month = Month;
            this._year = Year;

            this.CheckDateLimits("short");
        }

        public DateX(sbyte Day, sbyte Month, short Year, sbyte Hour, sbyte Minute, sbyte Second, short MilliSecond)
        {
            this._day = Day;
            this._month = Month;
            this._year = Year;
            this._hour = Hour;
            this._minute = Minute;
            this._second = Second;
            this._millisecond = MilliSecond;

            this.CheckDateLimits("long");
        }

        public DateX(DateTime prmDateTime)
        {
            this._day = (sbyte)prmDateTime.Day;
            this._month = (sbyte)prmDateTime.Month;
            this._year = (short)prmDateTime.Year;
            this._hour = (sbyte)prmDateTime.Hour;
            this._minute = (sbyte)prmDateTime.Minute;
            this._second = (sbyte)prmDateTime.Second;
            this._millisecond = (short)prmDateTime.Millisecond;

            this.CheckDateLimits("long");
        }

        public DateX(string SQLDate)
        {
            //                  01234567890123456789012
            // SQL Date Format: 20130706                Length: 08 - ok
            if (SQLDate.Length == 8)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = 0;
                this._minute = 0;
                this._second = 0;
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 2013-07-06              Length: 10 - ok
            if (SQLDate.Length == 10)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(5, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._hour = 0;
                this._minute = 0;
                this._second = 0;
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 201307061324            Length: 12 - ok
            if (SQLDate.Length == 12)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(10, 2), 2, "", "trim,striptags", -1);
                this._second = 0;
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 20130706132456          Length: 14 - ok
            if (SQLDate.Length == 14)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(10, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(12, 2), 2, "", "trim,striptags", -1);
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 20130706 132456         Length: 15 - ok
            if (SQLDate.Length == 15)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(9, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(11, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(13, 2), 2, "", "trim,striptags", -1);
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 2013-07-06 13:24        Length: 16 - ok
            if (SQLDate.Length == 16)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(5, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(11, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(14, 2), 2, "", "trim,striptags", -1);
                this._second = 0;
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 20130706132456843       Length: 17 - ok
            if (SQLDate.Length == 17)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(10, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(12, 2), 2, "", "trim,striptags", -1);
                this._millisecond = ConvertX.ToShort(SQLDate.Substring(14, 3), 3, "", "trim,striptags", -1);
            }

            //                  01234567890123456789012
            // SQL Date Format: 20130706 132456843      Length: 18 - ok
            if (SQLDate.Length == 23)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(4, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(6, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(9, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(11, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(13, 2), 2, "", "trim,striptags", -1);
                this._millisecond = ConvertX.ToShort(SQLDate.Substring(15, 3), 3, "", "trim,striptags", -1);
            }

            //                  01234567890123456789012
            // SQL Date Format: 2013-07-06 13:24:56     Length: 19 - ok
            if (SQLDate.Length == 19)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(5, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(11, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(14, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(17, 2), 2, "", "trim,striptags", -1);
                this._millisecond = 0;
            }

            //                  01234567890123456789012
            // SQL Date Format: 2013-07-06 13:24:56.843 Length: 23 - ok
            if (SQLDate.Length == 23)
            {
                this._year = ConvertX.ToShort(SQLDate.Substring(0, 4), 4, "", "trim,striptags", -1);
                this._month = ConvertX.ToSByte(SQLDate.Substring(5, 2), 2, "", "trim,striptags", -1);
                this._day = ConvertX.ToSByte(SQLDate.Substring(8, 2), 2, "", "trim,striptags", -1);
                this._hour = ConvertX.ToSByte(SQLDate.Substring(11, 2), 2, "", "trim,striptags", -1);
                this._minute = ConvertX.ToSByte(SQLDate.Substring(14, 2), 2, "", "trim,striptags", -1);
                this._second = ConvertX.ToSByte(SQLDate.Substring(17, 2), 2, "", "trim,striptags", -1);
                this._millisecond = ConvertX.ToShort(SQLDate.Substring(20, 3), 3, "", "trim,striptags", -1);
            }

            this.CheckDateLimits("long");
        }

        public DateTime ToShortDateTime()
        {
            if (this._year == -1 || this._month == -1 || this._day == -1)
            {
                return new DateTime(SQLYearMin, 1, 1);
            }
            else
            {
                return new DateTime(this._year, this._month, this._day);
            }
        }

        public DateTime ToLongDateTime()
        {
            if (this._year == -1 || this._month == -1 || this._day == -1 || this._hour == -1 || this._minute == -1 || this._second == -1 || this._millisecond == -1)
            {
                return new DateTime(SQLYearMin, 1, 1, 0, 0, 0, 0);
            }
            else
            {
                return new DateTime(this._year, this._month, this._day, this._hour, this._minute, this._second, this._millisecond);
            }
        }

        public string ToSQLShortDate()
        {
            if (this._day == -1 || this._month == -1 || this._year == -1)
            {
                return String.Empty;
            }
            else
            {
                string strDay = this._day.ToString().PadLeft(2, '0');
                string strMonth = this._month.ToString().PadLeft(2, '0');
                string strYear = this._year.ToString().PadLeft(4, '0');

                return strYear + "-" + strMonth + "-" + strDay;
            }
        }

        public string ToSQLLongDate()
        {
            if (this._day == -1 || this._month == -1 || this._year == -1 || this._hour == -1 || this._minute == -1 || this._second == -1 || this._millisecond == -1)
            {
                return String.Empty;
            }
            else
            {
                string strDay = this._day.ToString().PadLeft(2, '0');
                string strMonth = this._month.ToString().PadLeft(2, '0');
                string strYear = this._year.ToString().PadLeft(4, '0');
                string strHour = this._hour.ToString().PadLeft(2, '0');
                string strMinute = this._minute.ToString().PadLeft(2, '0');
                string strSecond = this._second.ToString().PadLeft(2, '0');
                string strMilliSecond = this._millisecond.ToString().PadLeft(3, '0');

                return strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSecond + "." + strMilliSecond;
            }
        }
    }
    #endregion

    ///////////////////////////////////////////////////////////////////////////
    // HTML functions
    ///////////////////////////////////////////////////////////////////////////
    #region Object: HtmlX...
    public static class HtmlX
    {
        ///////////////////////////////////////////////////////////////////////////
        // HTML Cleaning functions
        ///////////////////////////////////////////////////////////////////////////
        public static string StripTags(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];

                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string CleanWord(string html)
        {
            html = html.Trim();

            if (String.IsNullOrEmpty(html))
            {
                html = "";
            }

            // start by completely removing all unwanted tags     
            html = Regex.Replace(html, @"<[/]?(img|span|xml|del|ins|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);
            // then run another pass over the html (twice), removing unwanted attributes     
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);

            return html;
        }

        ///////////////////////////////////////////////////////////////////////////
        // HTML IsEmpty functions
        ///////////////////////////////////////////////////////////////////////////
        public static bool IsEmpty(byte value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(sbyte value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(short value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(ushort value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(int value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(uint value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(long value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(ulong value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(decimal value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(float value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(double value1)
        {
            return (value1 == 0);
        }

        public static bool IsEmpty(char value1)
        {
            return (value1 == ' ' || value1 == '\0' || value1 == '0');
        }

        public static bool IsEmpty(string value1)
        {
            value1 = value1.Trim();

            return (String.IsNullOrEmpty(value1) || value1 == "0");
        }

        public static bool IsEmpty(object value1)
        {
            return (value1 == null || value1 is DBNull);
        }
    }
    #endregion

    public static class ToolsX
    {
        ///////////////////////////////////////////////////////////////////////////
        // Database IsNull functions
        ///////////////////////////////////////////////////////////////////////////
        #region IsNullDB overloads...
        public static byte IsNullDB(object value, byte replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToByte(value);
            }
        }

        public static sbyte IsNullDB(object value, sbyte replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToSByte(value);
            }
        }

        public static short IsNullDB(object value, short replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToInt16(value);
            }
        }

        public static ushort IsNullDB(object value, ushort replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToUInt16(value);
            }
        }

        public static int IsNullDB(object value, int replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        public static uint IsNullDB(object value, uint replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToUInt32(value);
            }
        }

        public static long IsNullDB(object value, long replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToInt64(value);
            }
        }

        public static ulong IsNullDB(object value, ulong replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToUInt64(value);
            }
        }

        public static decimal IsNullDB(object value, decimal replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }

        public static float IsNullDB(object value, float replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToSingle(value);
            }
        }

        public static double IsNullDB(object value, double replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToDouble(value);
            }
        }

        public static char IsNullDB(object value, char replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToChar(value);
            }
        }

        public static string IsNullDB(object value, string replacement)
        {
            if (value == null || value is DBNull)
            {
                return replacement;
            }
            else
            {
                return Convert.ToString(value);
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Minimum functions for value types
        ///////////////////////////////////////////////////////////////////////////
        #region Minimum of value types...
        public static byte Min(byte value1, byte value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static sbyte Min(sbyte value1, sbyte value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static short Min(short value1, short value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static ushort Min(ushort value1, ushort value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static int Min(int value1, int value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static uint Min(uint value1, uint value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static long Min(long value1, long value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static ulong Min(ulong value1, ulong value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static decimal Min(decimal value1, decimal value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static float Min(float value1, float value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static double Min(double value1, double value2)
        {
            if (value1 <= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Maximum functions for value types
        ///////////////////////////////////////////////////////////////////////////
        #region Maximum of value types...
        public static byte Max(byte value1, byte value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static sbyte Max(sbyte value1, sbyte value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static short Max(short value1, short value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static ushort Max(ushort value1, ushort value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static int Max(int value1, int value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static uint Max(uint value1, uint value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static long Max(long value1, long value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static ulong Max(ulong value1, ulong value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static decimal Max(decimal value1, decimal value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static float Max(float value1, float value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        public static double Max(double value1, double value2)
        {
            if (value1 >= value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Minimum functions for arrays[]
        ///////////////////////////////////////////////////////////////////////////
        #region Minimum of an array[] overloads...
        public static byte Min(byte[] array1)
        {
            byte Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'byte[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static sbyte Min(sbyte[] array1)
        {
            sbyte Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'sbyte[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static int Min(int[] array1)
        {
            int Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'int[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static uint Min(uint[] array1)
        {
            uint Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'uint[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static long Min(long[] array1)
        {
            long Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'long[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static ulong Min(ulong[] array1)
        {
            ulong Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'ulong[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static short Min(short[] array1)
        {
            short Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'short[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static ushort Min(ushort[] array1)
        {
            ushort Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'ushort[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static decimal Min(decimal[] array1)
        {
            decimal Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'decimal[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static float Min(float[] array1)
        {
            float Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'float[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }

        public static double Min(double[] array1)
        {
            double Minimum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Min: Empty 'double[]' array exception");
            }
            else
            {
                Minimum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] < Minimum)
                    {
                        Minimum = array1[counter];
                    }
                }

                return Minimum;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Maximum functions for arrays[]
        ///////////////////////////////////////////////////////////////////////////
        #region Maximum of an array[] overloads...
        public static byte Max(byte[] array1)
        {
            byte Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'byte[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static sbyte Max(sbyte[] array1)
        {
            sbyte Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'sbyte[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static int Max(int[] array1)
        {
            int Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'int[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static uint Max(uint[] array1)
        {
            uint Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'uint[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static long Max(long[] array1)
        {
            long Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'long[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static ulong Max(ulong[] array1)
        {
            ulong Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'ulong[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static short Max(short[] array1)
        {
            short Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'short[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static ushort Max(ushort[] array1)
        {
            ushort Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'ushort[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static float Max(float[] array1)
        {
            float Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'float[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static double Max(double[] array1)
        {
            double Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'double[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }

        public static decimal Max(decimal[] array1)
        {
            decimal Maximum;

            if (array1.Length == 0)
            {
                throw new Exception("Common.Tools.Max: Empty 'decimal[]' array exception");
            }
            else
            {
                Maximum = array1[0];

                for (int counter = 1; counter < array1.Length; counter++)
                {
                    if (array1[counter] > Maximum)
                    {
                        Maximum = array1[counter];
                    }
                }

                return Maximum;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Swap functions for primitives
        ///////////////////////////////////////////////////////////////////////////
        #region Swap values overloads...
        public static void Swap<T>(ref T val1, ref T val2)
        {
            T dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref byte val1, ref byte val2)
        {
            byte dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref sbyte val1, ref sbyte val2)
        {
            sbyte dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref short val1, ref short val2)
        {
            short dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref ushort val1, ref ushort val2)
        {
            ushort dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref int val1, ref int val2)
        {
            int dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref uint val1, ref uint val2)
        {
            uint dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref long val1, ref long val2)
        {
            long dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref ulong val1, ref ulong val2)
        {
            ulong dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref float val1, ref float val2)
        {
            float dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref double val1, ref double val2)
        {
            double dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref decimal val1, ref decimal val2)
        {
            decimal dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }

        public static void Swap(ref string val1, ref string val2)
        {
            string dummy;

            dummy = val1;
            val1 = val2;
            val2 = dummy;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // IsBetween functions for primitives
        ///////////////////////////////////////////////////////////////////////////
        #region IsBetween value overloads...
        public static bool IsBetween(byte X, byte LowerLimit, byte UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap (ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(sbyte X, sbyte LowerLimit, sbyte UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(ushort X, ushort LowerLimit, ushort UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(short X, short LowerLimit, short UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(uint X, uint LowerLimit, uint UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(int X, int LowerLimit, int UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(ulong X, ulong LowerLimit, ulong UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(long X, long LowerLimit, long UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(float X, float LowerLimit, float UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(double X, double LowerLimit, double UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        public static bool IsBetween(decimal X, decimal LowerLimit, decimal UpperLimit)
        {
            if (UpperLimit < LowerLimit) { ToolsX.Swap(ref LowerLimit, ref UpperLimit); }
            return (X >= LowerLimit) && (X <= UpperLimit);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // High & Low Nibble functions
        ///////////////////////////////////////////////////////////////////////////
        #region HighNibble & LowNibble overloads...
        public static byte HighNibble(byte value)
        {
            return (byte)(value >> 4);
        }

        public static byte LowNibble(byte value)
        {
            return (byte)(value & 0x0F);
        }

        public static byte HighNibble(ushort value)
        {
            return (byte)(value >> 8);
        }

        public static byte LowNibble(ushort value)
        {
            return (byte)(value & 0xFF);
        }

        public static ushort HighNibble(uint value)
        {
            return (ushort)(value >> 16);
        }

        public static ushort LowNibble(uint value)
        {
            return (ushort)(value & 0xFFFF);
        }

        public static uint HighNibble(ulong value)
        {
            return (uint)(value >> 32);
        }

        public static uint LowNibble(ulong value)
        {
            return (uint)(value & 0xFFFFFFFF);
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////
        // Value2String functions
        ///////////////////////////////////////////////////////////////////////////
        #region Value2String overloads...
        public static string Value2String(byte value)
        {
            return Convert.ToString((char)value);
        }

        public static string Value2String(ushort value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(HighNibble(value)) + Value2String(LowNibble(value));
            }
            else
            {
                return Value2String(LowNibble(value)) + Value2String(HighNibble(value));
            }
        }

        public static string Value2String(uint value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(HighNibble(value), LowNibbleFirst) + Value2String(LowNibble(value), LowNibbleFirst);
            }
            else
            {
                return Value2String(LowNibble(value), LowNibbleFirst) + Value2String(HighNibble(value), LowNibbleFirst);
            }
        }

        public static string Value2String(ulong value, bool LowNibbleFirst = false)
        {
            if (LowNibbleFirst == false)
            {
                return Value2String(HighNibble(value), LowNibbleFirst) + Value2String(LowNibble(value), LowNibbleFirst);
            }
            else
            {
                return Value2String(LowNibble(value), LowNibbleFirst) + Value2String(HighNibble(value), LowNibbleFirst);
            }
        }
        #endregion
    }
}