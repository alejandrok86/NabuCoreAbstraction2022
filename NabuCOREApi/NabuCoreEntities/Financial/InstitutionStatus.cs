using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionStatus : BaseType
    {
        [DataMember]
        public int? InstitutionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public InstitutionStatus() : base()
        {
            InstitutionStatusID = null;
        }

        public InstitutionStatus(int pInstitutionStatusID) : base()
        {
            InstitutionStatusID = pInstitutionStatusID;
        }

        public InstitutionStatus(int? pInstitutionStatusID) : base()
        {
            InstitutionStatusID = pInstitutionStatusID;
        }

        public InstitutionStatus(int pInstitutionStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            InstitutionStatusID = pInstitutionStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
