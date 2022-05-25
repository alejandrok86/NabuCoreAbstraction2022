using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Enrollment : BaseType
    {
        [DataMember]
        public int? EnrollmentID { get; set; }

        [DataMember]
        public int? EducationProviderID { get; set; }

        [DataMember]
        public int? LearnerID { get; set; }

        [DataMember]
        public AcademicPeriod Period { get; set; }

        [DataMember]
        public AcademicStage Stage { get; set; }

        [DataMember]
        public AcademicCycle Cycle { get; set; }

        [DataMember]
        public AcademicLevel Level { get; set; }

        [DataMember]
        public AcademicModality Modality { get; set; }

        [DataMember]
        public ClassGroup Class { get; set; }

        [DataMember]
        public EnrollmentStatus Status { get; set; }

        public Enrollment() : base()
        {
            EnrollmentID = null;
        }

        public Enrollment(int? pEnrollmentID) : base()
        {
            EnrollmentID = pEnrollmentID;
        }

        public Enrollment(int pEnrollmentID) : base()
        {
            EnrollmentID = pEnrollmentID;
        }
    }
}
