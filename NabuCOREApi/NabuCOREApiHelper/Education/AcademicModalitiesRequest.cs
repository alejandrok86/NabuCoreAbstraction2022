using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Education

{
    [DataContract]
    public class AcademicModalitiesRequest
    {
        

        [DataMember]
        public AcademicLevel AcademicLevel { get; set; } = null;
        [DataMember]
        public AcademicStage AcademicStage { get; set; } = null;
        [DataMember]
        public EducationProvider EducationProvider { get; set; } = null;

        [DataMember]
        public AcademicModality AcademicModality { get; set; } = null;
        [DataMember]
        public Language language { get; set; } = null;

       



    }
}
