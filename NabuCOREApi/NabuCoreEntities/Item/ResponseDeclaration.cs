using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class ResponseDeclaration : BaseType
    {
        [DataMember]
        public int? ResponseDeclarationID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string ResponseDeclarationXML { get; set; }

        public ResponseDeclaration() : base()
        {
            ResponseDeclarationID = null;
        }

        public ResponseDeclaration(int pResponseDeclarationID) : base()
        {
            ResponseDeclarationID = pResponseDeclarationID;
        }

        public ResponseDeclaration(int? pResponseDeclarationID) : base()
        {
            ResponseDeclarationID = pResponseDeclarationID;
        }

        public ResponseDeclaration(int? pResponseDeclarationID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ResponseDeclarationID = pResponseDeclarationID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
