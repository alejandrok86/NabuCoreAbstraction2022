using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AcademicPeriod : BaseType
    {
        [DataMember]
        public int? AcademicPeriodID { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        public AcademicPeriod() : base()
        {
            AcademicPeriodID = null;
            EndDate = null;
        }

        public AcademicPeriod(int? pAcademicPeriodID) : base()
        {
            AcademicPeriodID = pAcademicPeriodID;
        }

        public AcademicPeriod(int pAcademicPeriodID) : base()
        {
            AcademicPeriodID = pAcademicPeriodID;
        }
    }
}
