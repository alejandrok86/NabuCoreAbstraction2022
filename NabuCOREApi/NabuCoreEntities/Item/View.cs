using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class View : BaseType
    {
        [DataMember]
        public int? ViewID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public View() : base()
        {
            ViewID = null;
        }
        public View(int pViewID) : base()
        {
            ViewID = pViewID;
        }
        public View(int? pViewID) : base()
        {
            ViewID = pViewID;
        }
        public View(int? pViewID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ViewID = pViewID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
