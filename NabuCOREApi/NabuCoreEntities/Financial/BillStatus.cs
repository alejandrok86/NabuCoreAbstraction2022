using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class BillStatus : BaseType
    {
        [DataMember]
        public int? BillStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public BillStatus() : base()
        {
            BillStatusID = null;
        }

        public BillStatus(int pBillStatusID) : base()
        {
            BillStatusID = pBillStatusID;
        }

        public BillStatus(int? pBillStatusID) : base()
        {
            BillStatusID = pBillStatusID;
        }

        public BillStatus(int pBillStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            BillStatusID = pBillStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
