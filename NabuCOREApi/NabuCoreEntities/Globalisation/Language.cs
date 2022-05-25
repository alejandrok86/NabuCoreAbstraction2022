using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Globalisation
{
    [DataContract]
    public class Language : BaseType
    {
        [DataMember]
        public int? LanguageID { get; set; }

        [DataMember]
        public string SystemName { get; set; }

        [DataMember]
        public string NativeName { get; set; }

        [DataMember]
        public string ISOCode { get; set; }

        [DataMember]
        public bool IsRightToLeftLanguage { get; set; }

        [DataMember]
        public string CultureInfo { get; set; }

        public Language() : base()
        {
            LanguageID = null;
            IsRightToLeftLanguage = false;
        }

        public Language(int? pLanguageID) : base()
        {
            LanguageID = pLanguageID;
        }

        public Language(int pLanguageID) : base()
        {
            LanguageID = pLanguageID;
        }

        public Language(int pLanguageID, string pNativeName) : base()
        {
            LanguageID = pLanguageID;
            NativeName = pNativeName;
        }
    }
}
