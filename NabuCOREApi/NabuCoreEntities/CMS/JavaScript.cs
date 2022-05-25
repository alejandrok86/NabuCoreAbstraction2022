using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class JavaScript : Content.Content
    {
        public JavaScript() : base()
        {
        }

        public JavaScript(int pJavaScriptID) : base(pJavaScriptID)
        {
        }

        public JavaScript(int? pJavaScriptID) : base(pJavaScriptID)
        {
        }
    }
}
