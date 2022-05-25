using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ResponseAudit : BaseType
    {
        [DataMember]
        public int? ResponseAuditID { get; set; }

        [DataMember]
	    public int UserAccountID { get; set; }

        [DataMember]
	    public int RespondentID { get; set; }

        [DataMember]
	    public int InstrumentID { get; set; }

        [DataMember]
	    public int ResponseID { get; set; }

        [DataMember]
	    public int? ItemResponseID { get; set; }

        [DataMember]
	    public int? ItemID { get; set; }

        [DataMember]
	    public int? AttemptID { get; set; }

        [DataMember]
	    public string AuditType { get; set; }

        [DataMember]
	    public DateTime EventOcurredAt { get; set; }

        [DataMember]
	    public string ResponseValue { get; set; }

        [DataMember]
    	public string TextualOutcome { get; set; }

        public ResponseAudit() : base()
        {
            ResponseAuditID = null;

            UserAccountID = 0;
            RespondentID = 0;
            InstrumentID = 0;
            ResponseID = 0;
            AuditType = "unspecified";
            EventOcurredAt = DateTime.Now;
        }

    public ResponseAudit(int pResponseAuditID) : base()
        {
            ResponseAuditID = pResponseAuditID;
        }

        public ResponseAudit(int? pResponseAuditID) : base()
        {
            ResponseAuditID = pResponseAuditID;
        }
    }
}
