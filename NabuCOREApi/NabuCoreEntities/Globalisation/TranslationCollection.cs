using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Globalisation
{
    [DataContract]
    public class TranslationCollection : BaseType
    {
        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public Translation[] Translations { get; set; }

        public TranslationCollection()
        {
            Alias = "";
        }
    }
}
