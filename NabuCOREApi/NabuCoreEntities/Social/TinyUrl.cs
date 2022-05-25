using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class TinyUrl : BaseType
    {
        [DataMember]
        public int? tinyUrlID { get; set; }

        [DataMember]
        public Uri fullyQualifiedUrl { get; set; }

        public TinyUrl() : base()
        {
            tinyUrlID = null;
        }

        public TinyUrl(int pTinyUrlID) : base()
        {
            tinyUrlID = pTinyUrlID;
        }

        public TinyUrl(int? pTinyUrlID) : base()
        {
            tinyUrlID = pTinyUrlID;
        }
    }
}
