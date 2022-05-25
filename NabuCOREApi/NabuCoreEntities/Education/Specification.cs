using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Specification : BaseType
    {
        [DataMember]
        public int? SpecificationID { get; set; }

        [DataMember]
        public FormalOrganisation Organisation { get; set; }

        [DataMember]
        public Qualification Qualification { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string NationalClassificationCode { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public bool IsPublicallyAvailable { get; set; }

        [DataMember]
        public Module[] Modules { get; set; }

        [DataMember]
        public AssessmentSession[] AssessmentSessions { get; set; }

        [DataMember]
        public Competency[] Competencies { get; set; }

        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public Specification() : base()
        {
            SpecificationID = null;
        }

        public Specification(int? pSpecificationID) : base()
        {
            SpecificationID = pSpecificationID;
        }

        public Specification(int pSpecificationID) : base()
        {
            SpecificationID = pSpecificationID;
        }

        public Specification(int? pSpecificationID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SpecificationID = pSpecificationID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Specification(int pSpecificationID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SpecificationID = pSpecificationID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }    
    }
}
