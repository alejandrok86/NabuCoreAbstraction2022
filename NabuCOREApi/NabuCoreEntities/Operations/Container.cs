using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class Container : BaseType
    {
        [DataMember]
        public int? ContainerID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public TrackingCode TrackingCode { get; set; }

        [DataMember]
        public ContainerType ContainerType { get; set; }

        [DataMember]
        public ContainerStatus ContainerStatus { get; set; }

        [DataMember]
        public int? ParentContainerID { get; set; }

        public Container() : base()
        {
            ContainerID = null;
        }

        public Container(int? pContainerID) : base()
        {
            ContainerID = pContainerID;
        }

        public Container(int pContainerID) : base()
        {
            ContainerID = pContainerID;
        }

        public void SetType(ContainerType[] pContainerTypes)
        {
            if (ContainerType != null && ContainerType.ContainerTypeID.HasValue)
            {
                foreach (ContainerType containerType in pContainerTypes)
                {
                    if (containerType.ErrorsDetected == false)
                    {
                        if (containerType.ContainerTypeID == this.ContainerType.ContainerTypeID)
                        {
                            this.ContainerType = containerType;
                            break;
                        }
                    }
                }
            }
        }

        public void SetStatus(ContainerStatus[] pContainerStatuses)
        {
            if (ContainerStatus != null && ContainerStatus.ContainerStatusID.HasValue)
            {
                foreach (ContainerStatus containerStatus in pContainerStatuses)
                {
                    if (containerStatus.ErrorsDetected == false)
                    {
                        if (containerStatus.ContainerStatusID == this.ContainerStatus.ContainerStatusID)
                        {
                            this.ContainerStatus = containerStatus;
                            break;
                        }
                    }
                }
            }
        }
    }
}
