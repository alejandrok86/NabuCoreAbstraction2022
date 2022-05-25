using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Globalisation
{
    [DataContract]
    public class Translation : BaseType
    {
        [DataMember]
        public int? TranslationID { get; set; }

        [DataMember]
        public Language TranslationLanguage { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        public Translation() : base()
        {
            TranslationID = null;
            Name = null;
            Description = null;
        }

        public Translation(int? pTranslationID) : base()
        {
            TranslationID = pTranslationID;
        }

        public Translation(int pTranslationID) : base()
        {
            TranslationID = pTranslationID;
        }

        public Translation(int pTranslationID, string pAlias, Language pTranslationLanguage) : base()
        {
            Alias = pAlias;
            TranslationID = pTranslationID;
            TranslationLanguage = pTranslationLanguage;
        }

        public Translation(int pTranslationID, string pAlias, Language pTranslationLanguage, string pName, string pDescription) : base()
        {
            TranslationID = pTranslationID;
            Alias = pAlias;
            Name = pName;
            Description = pDescription;
            TranslationLanguage = pTranslationLanguage;
        }

        public Translation(string pAlias, Language pTranslationLanguage, string pName, string pDescription) : base()
        {
            TranslationID = null;
            Alias = pAlias;
            Name = pName;
            Description = pDescription;
            TranslationLanguage = pTranslationLanguage;
        }
    }
}
