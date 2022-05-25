using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class IssueType : BaseType
    {
        [DataMember]
        public int? IssueTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IssueType() : base()
        {
            IssueTypeID = null;
        }

        public IssueType(int pIssueTypeID) : base()
        {
            IssueTypeID = pIssueTypeID;
        }

        public IssueType(int? pIssueTypeID) : base()
        {
            IssueTypeID = pIssueTypeID;
        }
    }
}
