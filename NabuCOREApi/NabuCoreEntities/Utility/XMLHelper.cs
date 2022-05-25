using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Utility
{
    [DataContract]
    public class XMLHelper : BaseType
    {
        public XMLHelper() : base()
        {
        }

        public TextAlignment GetTextAlignmentFromText(string pTextAlignment)
        {
            if (pTextAlignment.CompareTo("left") == 0)
            {
                // left align
                return TextAlignment.Left;
            }
            else if (pTextAlignment.CompareTo("right") == 0)
            {
                // right align
                return TextAlignment.Right;
            }
            else
            {
                // centre default
                return TextAlignment.Centre;
            }
        }

        public string ReplaceSpecialChars(string Value)
        {
            if (Value != null)
            {
                string strTemp = ReplaceNBSP(Value);
                strTemp = ReplacePound(strTemp);
                strTemp = ReplaceEuro(strTemp);
                strTemp = ReplaceDegree(strTemp);
                return strTemp;
            }
            else
            {
                return "";
            }
        }

        public string ReplaceDegree(string Value)
        {
            if (Value != null)
            {
                return Value.Replace("&deg;", "°");
            }
            else
            {
                return "";
            }
        }

        public string ReplaceNBSP(string Value)
        {
            if (Value != null)
            {
                return Value.Replace("&nbsp;", " ");
            }
            else
            {
                return "";
            }
        }

        public string ReplacePound(string Value)
        {
            if (Value != null)
            {
                return Value.Replace("&pound;", "£");
            }
            else
            {
                return "";
            }
        }

        public string ReplaceEuro(string Value)
        {
            if (Value != null)
            {
                return Value.Replace("&euro;", "€");
            }
            else
            {
                return "";
            }
        }

        public string XMLEncode(string Value)
        {
            if (Value != null)
            {
                string returnVal = Value.Replace("&", "&amp;");
                //returnVal = returnVal.Replace("'", "&apos;");
                //returnVal = returnVal.Replace("\"", "&quot;");
                //returnVal = returnVal.Replace("<", "&lt;");
                //returnVal = returnVal.Replace(">", "&gt;");
                return returnVal;
            }
            else
            {
                return "";
            }
        }

        public string XMLDecode(string Value)
        {
            if (Value != null)
            {
                string returnVal = Value.Replace("&amp;", "&");
                //returnVal = returnVal.Replace("&apos;", "'");
                //returnVal = returnVal.Replace("&lt;", "<");
                //returnVal = returnVal.Replace("&gt;", ">");
                return returnVal;
            }
            else
            {
                return "";
            }
        }
    }
}
