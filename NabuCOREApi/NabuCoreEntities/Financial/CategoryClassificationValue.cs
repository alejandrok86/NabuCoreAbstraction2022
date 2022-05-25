using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class CategoryClassificationValue : CategoryClassification
    {
        [DataMember]
        public decimal Value { get; set; }

        public CategoryClassificationValue() : base()
        {
        }

        public CategoryClassificationValue(int pCategoryClassificationID) : base(pCategoryClassificationID)
        {
        }

        public CategoryClassificationValue(int? pCategoryClassificationID) : base(pCategoryClassificationID)
        {
        }

        public CategoryClassificationValue(int pCategoryClassificationID, string pAlias, int pTranslationID, string pName, string pDescription, Octavo.Gate.Nabu.CORE.Entities.Globalisation.Language pLanguage) : base(pCategoryClassificationID, pAlias, pTranslationID, pName, pDescription, pLanguage)
        {
        }
    }
}
