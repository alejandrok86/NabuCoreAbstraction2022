using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class Brand : BaseType
    {
        [DataMember]
        public int? BrandID { get; set; }

        [DataMember]
        public Organisation Owner { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public ProductLine[] ProductLines { get; set; }

        public Brand() : base()
        {
            BrandID = null;
        }
        public Brand(int pBrandID) : base()
        {
            BrandID = pBrandID;
        }
        public Brand(int? pBrandID) : base()
        {
            BrandID = pBrandID;
        }
        public Brand(int? pBrandID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            BrandID = pBrandID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
