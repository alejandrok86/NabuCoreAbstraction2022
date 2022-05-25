using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class ClientCategory : BaseType
    {
        [DataMember]
        public int? ClientCategoryID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public bool IsIndividual { get; set; }

        [DataMember]
        public int? DisplaySequence { get; set; }

        public ClientCategory() : base()
        {
            ClientCategoryID = null;
            IsIndividual = false;
        }

        public ClientCategory(int pClientCategoryID) : base()
        {
            ClientCategoryID = pClientCategoryID;
        }

        public ClientCategory(int? pClientCategoryID) : base()
        {
            ClientCategoryID = pClientCategoryID;
        }

        public ClientCategory(int pClientCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ClientCategoryID = pClientCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
