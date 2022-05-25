using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Qualification : BaseType
    {
        [DataMember]
        public int? QualificationID { get; set; }

        [DataMember]
        public QualificationType QualificationType { get; set; }

        [DataMember]
        public LineOfLearning LineOfLearning { get; set; }

        [DataMember]
        public FunctionalSkillSubject FunctionalSkillSubject { get; set; }

        [DataMember]
        public QualificationLevel QualificationLevel { get; set; }

        [DataMember]
        public GradingScheme GradingScheme { get; set; }

        [DataMember]
        public string SubjectSectorClassification { get; set; }

        public Qualification() : base()
        {
            QualificationID = null;
        }

        public Qualification(int? pQualificationID) : base()
        {
            QualificationID = pQualificationID;
        }

        public Qualification(int pQualificationID) : base()
        {
            QualificationID = pQualificationID;
        }
    }
}
