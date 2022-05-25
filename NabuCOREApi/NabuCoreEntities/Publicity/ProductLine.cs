using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class ProductLine : BaseType
    {
        [DataMember]
        public int? ProductLineID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Operations.Part[] Products { get; set; }

        public ProductLine() : base()
        {
            ProductLineID = null;
        }
        public ProductLine(int pProductLineID) : base()
        {
            ProductLineID = pProductLineID;
        }
        public ProductLine(int? pProductLineID) : base()
        {
            ProductLineID = pProductLineID;
        }
        public ProductLine(int? pProductLineID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ProductLineID = pProductLineID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
