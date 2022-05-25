using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionType : BaseType
    {
        [DataMember]
        public int? InstitutionTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public InstitutionType() : base()
        {
            InstitutionTypeID = null;
        }

        public InstitutionType(int pInstitutionTypeID) : base()
        {
            InstitutionTypeID = pInstitutionTypeID;
        }

        public InstitutionType(int? pInstitutionTypeID) : base()
        {
            InstitutionTypeID = pInstitutionTypeID;
        }

        public InstitutionType(int pInstitutionTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            InstitutionTypeID = pInstitutionTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
