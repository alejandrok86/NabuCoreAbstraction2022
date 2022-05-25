using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class OutputDeclaration : BaseType
    {
        [DataMember]
        public int? OutputDeclarationID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string OutputDeclarationXML { get; set; }

        public OutputDeclaration() : base()
        {
            OutputDeclarationID = null;
        }

        public OutputDeclaration(int pOutputDeclarationID) : base()
        {
            OutputDeclarationID = pOutputDeclarationID;
        }

        public OutputDeclaration(int? pOutputDeclarationID) : base()
        {
            OutputDeclarationID = pOutputDeclarationID;
        }

        public OutputDeclaration(int? pOutputDeclarationID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            OutputDeclarationID = pOutputDeclarationID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
