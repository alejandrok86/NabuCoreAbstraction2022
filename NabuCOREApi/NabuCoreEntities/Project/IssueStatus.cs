using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class IssueStatus : BaseType
    {
        [DataMember]
        public int? IssueStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IssueStatus() : base()
        {
            IssueStatusID = null;
        }

        public IssueStatus(int pIssueStatusID) : base()
        {
            IssueStatusID = pIssueStatusID;
        }

        public IssueStatus(int? pIssueStatusID) : base()
        {
            IssueStatusID = pIssueStatusID;
        }
    }
}
