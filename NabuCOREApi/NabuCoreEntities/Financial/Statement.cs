using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Statement : BaseType
    {
        [DataMember]
        public int? StatementID { get; set; }

        [DataMember]
        public StatementStatus Status { get; set; }

        [DataMember]
        public DateTime? StatementDate { get; set; }

        [DataMember]
        public DateTime? FromDate { get; set; }

        [DataMember]
        public DateTime? ToDate { get; set; }

        [DataMember]
        public decimal? OpeningBalance { get; set; }

        [DataMember]
        public decimal? ClosingBalance { get; set; }

        [DataMember]
        public AccountTransaction[] Transactions { get; set; }

        public Statement() : base()
        {
            StatementID = null;
        }

        public Statement(int pStatementID) : base()
        {
            StatementID = pStatementID;
        }

        public Statement(int? pStatementID) : base()
        {
            StatementID = pStatementID;
        }
    }
}
