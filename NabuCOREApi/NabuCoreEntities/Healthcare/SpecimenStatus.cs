using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class SpecimenStatus : BaseType
    {
        [DataMember]
        public int? SpecimenStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public SpecimenStatus() : base()
        {
            SpecimenStatusID = null;
        }
        public SpecimenStatus(int pSpecimenStatusID) : base()
        {
            SpecimenStatusID = pSpecimenStatusID;
        }
        public SpecimenStatus(int? pSpecimenStatusID) : base()
        {
            SpecimenStatusID = pSpecimenStatusID;
        }
        public SpecimenStatus(int? pSpecimenStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SpecimenStatusID = pSpecimenStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
