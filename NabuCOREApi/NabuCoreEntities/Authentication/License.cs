using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class License : BaseType
    {
        [DataMember]
        public int? LicenseID { get; set; }

        [DataMember]
        public string LicenseKey { get; set; }

        [DataMember]
        public DateTime ActiveFrom { get; set; }

        [DataMember]
        public DateTime? ActiveTo { get; set; }

        public License() : base()
        {
            LicenseID = null;
            ActiveTo = null;
        }

        public License(int pLicenseID) : base()
        {
            LicenseID = pLicenseID;
        }

        public License(int? pLicenseID) : base()
        {
            LicenseID = pLicenseID;
        }

        public bool IsActive()
        {
            bool result = false;

            if (DateTime.Now.CompareTo(ActiveFrom) >= 0)
            {
                if (ActiveTo.HasValue)
                {
                    if (DateTime.Now.CompareTo(ActiveTo.Value) < 0)
                    {
                        result = true;
                    }
                }
                else
                    result = true;
            }
            return result;
        }

        public bool HasExpired()
        {
            bool hasExpired = false;
            if (DateTime.Now.CompareTo(ActiveFrom) >= 0)
            {
                if (ActiveTo.HasValue)
                {
                    if (DateTime.Now.CompareTo(ActiveTo.Value) < 0)
                    {
                        hasExpired = true;
                    }
                }
            }
            return hasExpired;
        }
    }
}
