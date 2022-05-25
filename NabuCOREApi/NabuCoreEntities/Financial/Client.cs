using Octavo.Gate.Nabu.CORE.Entities.Core;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Client : Party
    {
        [DataMember]
        public string ClientReference { get; set; }

        [DataMember]
        public ClientStatus Status { get; set; }

        [DataMember]
        public ClientCategory Category { get; set; }

        [DataMember]
        public Account[] Accounts { get; set; }

        public Client() : base()
        {
        }

        public Client(int pClientID) : base(pClientID)
        {
        }

        public Client(int? pClientID) : base(pClientID)
        {
        }

        public void SetStatus(ClientStatus[] pClientStatuses)
        {
            if (pClientStatuses != null)
            {
                foreach (ClientStatus clientStatus in pClientStatuses)
                {
                    if (clientStatus.ErrorsDetected == false)
                    {
                        if (this.Status != null && this.Status.ErrorsDetected == false && this.Status.ClientStatusID.HasValue)
                        {
                            if (this.Status.ClientStatusID == clientStatus.ClientStatusID)
                            {
                                this.Status = clientStatus;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }
        public void SetCategory(ClientCategory[] pClientCategories)
        {
            if (pClientCategories != null)
            {
                foreach (ClientCategory clientCategory in pClientCategories)
                {
                    if (clientCategory.ErrorsDetected == false)
                    {
                        if (this.Category != null && this.Category.ErrorsDetected == false && this.Category.ClientCategoryID.HasValue)
                        {
                            if (this.Category.ClientCategoryID == clientCategory.ClientCategoryID)
                            {
                                this.Category = clientCategory;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }
    }
}
