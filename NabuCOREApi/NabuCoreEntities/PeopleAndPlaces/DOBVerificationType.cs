using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class DOBVerificationType : BaseType
    {
        [DataMember]
        public int? DOBVerificationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        public DOBVerificationType() : base()
        {
            DOBVerificationTypeID = null;
        }

        public DOBVerificationType(int pDOBVerificationTypeID) : base()
        {
            DOBVerificationTypeID = pDOBVerificationTypeID;
        }

        public DOBVerificationType(int? pDOBVerificationTypeID) : base()
        {
            DOBVerificationTypeID = pDOBVerificationTypeID;
        }

        public DOBVerificationType(int pDOBVerificationTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DOBVerificationTypeID = pDOBVerificationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public DOBVerificationType(int? pDOBVerificationTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DOBVerificationTypeID = pDOBVerificationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
