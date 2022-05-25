using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Currency : BaseType
    {
        [DataMember]
        public int? CurrencyID { get; set; }

        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public string UnicodeDecimalCharacters { get; set; }

        public Currency() : base()
        {
            CurrencyID = null;
        }

        public Currency(int pCurrencyID) : base()
        {
            CurrencyID = pCurrencyID;
        }

        public Currency(int? pCurrencyID) : base()
        {
            CurrencyID = pCurrencyID;
        }

        public string GetCurrencySymbol()
        {
            string symbol = "";
            if (UnicodeDecimalCharacters.Trim().Length == 1)
                symbol = UnicodeDecimalCharacters;
            else
            {
                try
                {
                    int unicodeValue = Convert.ToInt32(UnicodeDecimalCharacters);
                    char c = (char)unicodeValue;
                    symbol = c.ToString();
                }
                catch
                {
                }
            }
            return symbol;
        }
        public string GetCurrencySymbolAsHTML()
        {
            // http://character-code.com/currency-html-codes.php

            string symbol = "";
            if (CurrencyCode != null && CurrencyCode.Trim().Length > 0)
            {
                if (CurrencyCode.ToUpper().CompareTo("GBP")==0)
                    symbol = "&pound;";
                else if (CurrencyCode.ToUpper().CompareTo("USD") == 0)
                    symbol = "$";
                else if (CurrencyCode.ToUpper().CompareTo("EUR") == 0)
                    symbol = "&euro;";
                else if (CurrencyCode.ToUpper().CompareTo("ARS") == 0)
                    symbol = "$";
            }
            return symbol;
        }
    }
}
