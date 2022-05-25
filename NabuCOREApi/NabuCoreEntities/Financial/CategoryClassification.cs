using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class CategoryClassification : BaseType
    {
        [DataMember]
        public int? CategoryClassificationID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public CategoryClassification() : base()
        {
            CategoryClassificationID = null;
        }

        public CategoryClassification(int pCategoryClassificationID) : base()
        {
            CategoryClassificationID = pCategoryClassificationID;
        }

        public CategoryClassification(int? pCategoryClassificationID) : base()
        {
            CategoryClassificationID = pCategoryClassificationID;
        }

        public CategoryClassification(int pCategoryClassificationID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            CategoryClassificationID = pCategoryClassificationID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
