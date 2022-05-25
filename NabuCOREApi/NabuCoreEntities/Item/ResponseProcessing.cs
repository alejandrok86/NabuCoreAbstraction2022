using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class ResponseProcessing : BaseType
    {
        [DataMember]
        public int? ResponseProcessingID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string ResponseProcessingXML { get; set; }

        public ResponseProcessing() : base()
        {
            ResponseProcessingID = null;
        }

        public ResponseProcessing(int pResponseProcessingID) : base()
        {
            ResponseProcessingID = pResponseProcessingID;
        }

        public ResponseProcessing(int? pResponseProcessingID) : base()
        {
            ResponseProcessingID = pResponseProcessingID;
        }

        public ResponseProcessing(int? pResponseProcessingID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ResponseProcessingID = pResponseProcessingID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
