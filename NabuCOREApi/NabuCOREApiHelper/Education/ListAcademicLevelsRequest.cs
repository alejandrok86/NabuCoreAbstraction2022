using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Education

{
    [DataContract]
    public class ListAcademicLevelsRequest
    {

        //public AcademicModality[] ListAcademicModalities(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        [DataMember]
        public AcademicLevel AcademicLevel { get; set; } = null;
        [DataMember]
        public AcademicStage AcademicStage { get; set; } = null;
        [DataMember]
        public EducationProvider EducationProvider { get; set; } = null;
        [DataMember]
        public Language language { get; set; } = null;
 

    }
}
