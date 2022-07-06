using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Education

{
    [DataContract]
    public class AssessmentInstrumentRequest
    {

        //public AcademicModality[] ListAcademicModalities(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
      
        [DataMember]
        public Language language { get; set; } = null;
        [DataMember]
        public Party pOwnedBy { get; set; } = null;

        [DataMember]
        public int? pUnitID { get; set; } = null;
       // [DataMember]
        //public int? pOwnedBy { get; set; } = null;





    }

}

