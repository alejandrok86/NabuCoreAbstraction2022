using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Liquidity : BaseType
    {
        [DataMember]
        public int? LiquidityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public int? Days { get; set; }

        public Liquidity() : base()
        {
            LiquidityID = null;
        }

        public Liquidity(int pLiquidityID) : base()
        {
            LiquidityID = pLiquidityID;
        }

        public Liquidity(int? pLiquidityID) : base()
        {
            LiquidityID = pLiquidityID;
        }

        public Liquidity(int pLiquidityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            LiquidityID = pLiquidityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
