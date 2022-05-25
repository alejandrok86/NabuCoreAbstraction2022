using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class BillType : BaseType
    {
        [DataMember]
        public int? BillTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public BillType() : base()
        {
            BillTypeID = null;
        }

        public BillType(int pBillTypeID) : base()
        {
            BillTypeID = pBillTypeID;
        }

        public BillType(int? pBillTypeID) : base()
        {
            BillTypeID = pBillTypeID;
        }

        public BillType(int pBillTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            BillTypeID = pBillTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
