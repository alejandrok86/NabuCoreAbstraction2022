using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Knowledge
{
    [DataContract]
    public class Category : BaseType
    {
        [DataMember]
        public int? CategoryID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Category[] Children { get; set; }

        [DataMember]
        public int? ParentID { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        public Category() : base()
        {
            CategoryID = null;
            DisplaySequence = 1;
        }

        public Category(int pCategoryID) : base()
        {
            CategoryID = pCategoryID;
        }

        public Category(int? pCategoryID) : base()
        {
            CategoryID = pCategoryID;
        }

        public Category(int pCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            CategoryID = pCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
