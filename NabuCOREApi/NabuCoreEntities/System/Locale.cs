using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class Locale : BaseType
    {
        [DataMember]
        public int? LocaleID { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        public Locale() : base()
        {
            LocaleID = null;
        }

        public Locale(int pLocaleID) : base()
        {
            LocaleID = pLocaleID;
        }

        public Locale(int? pLocaleID) : base()
        {
            LocaleID = pLocaleID;
        }
    }
}
