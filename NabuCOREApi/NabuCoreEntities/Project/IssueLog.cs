using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class IssueLog : BaseType
    {
        [DataMember]
        public int? IssueLogID { get; set; }

        [DataMember]
        public Issue[] Items { get; set; }

        public IssueLog() : base()
        {
            IssueLogID = null;
        }

        public IssueLog(int pIssueLogID) : base()
        {
            IssueLogID = pIssueLogID;
        }

        public IssueLog(int? pIssueLogID) : base()
        {
            IssueLogID = pIssueLogID;
        }
    }
}
