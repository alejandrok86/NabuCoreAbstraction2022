using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class UnitReport : BaseType
    {
        [DataMember]
        public int? UnitReportID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string ReportURI { get; set; }

        public UnitReport() : base()
        {
            UnitReportID = null;
        }

        public UnitReport(int pUnitReportID) : base()
        {
            UnitReportID = pUnitReportID;
        }

        public UnitReport(int? pUnitReportID) : base()
        {
            UnitReportID = pUnitReportID;
        }
    }
}
