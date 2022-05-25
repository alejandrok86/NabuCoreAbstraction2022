using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AllocationItemStatus : BaseType
    {
        [DataMember]
        public int? AllocationItemStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AllocationItemStatus() : base()
        {
            AllocationItemStatusID = null;
        }

        public AllocationItemStatus(int? pAllocationItemStatus) : base()
        {
            AllocationItemStatusID = pAllocationItemStatus;
        }

        public AllocationItemStatus(int pAllocationItemStatus) : base()
        {
            AllocationItemStatusID = pAllocationItemStatus;
        }
    }
}
