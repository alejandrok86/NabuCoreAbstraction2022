using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class CountryRating : BaseType
    {
        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public Rating Rating { get; set; }

        public CountryRating() : base()
        {
        }
    }
}
