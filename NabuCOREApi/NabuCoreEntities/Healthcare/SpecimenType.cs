using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class SpecimenType : BaseType
    {
        [DataMember]
        public int? SpecimenTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public SpecimenType() : base()
        {
            SpecimenTypeID = null;
        }
        public SpecimenType(int pSpecimenTypeID) : base()
        {
            SpecimenTypeID = pSpecimenTypeID;
        }
        public SpecimenType(int? pSpecimenTypeID) : base()
        {
            SpecimenTypeID = pSpecimenTypeID;
        }
        public SpecimenType(int? pSpecimenTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SpecimenTypeID = pSpecimenTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
