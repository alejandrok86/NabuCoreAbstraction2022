using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Globalisation
{
    [DataContract]
    public class LanguageUsage : BaseType
    {
        [DataMember]
        public int? LanguageUsageID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public LanguageUsage()
        {
            LanguageUsageID = null;
        }

        public LanguageUsage(int pLanguageUsageID) : base()
        {
            LanguageUsageID = pLanguageUsageID;
        }

        public LanguageUsage(int? pLanguageUsageID) : base()
        {
            LanguageUsageID = pLanguageUsageID;
        }

        public LanguageUsage(int pLanguageUsageID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            LanguageUsageID = pLanguageUsageID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
