using Octavo.Gate.Nabu.CORE.Entities.Core;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Branch : FormalOrganisation
    {
        [DataMember]
        public string SortCode { get; set; }

        public Branch() : base()
        {
        }

        public Branch(int pBranchID) : base(pBranchID)
        {
        }

        public Branch(int? pBranchID) : base(pBranchID)
        {
        }
    }
}
