using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class Sharing : BaseType
    {
        [DataMember]
        public int? ShareID { get; set; }

        [DataMember]
        public Party SharedBy { get; set; }

        [DataMember]
        public DateTime SharedOn { get; set; }

        [DataMember]
        public Guid RetrievalToken { get; set; }

        [DataMember]
        public string ShareConfigurationXML { get; set; }

        public Sharing() : base()
        {
            ShareID = null;
        }

        public Sharing(int pShareID) : base()
        {
            ShareID = pShareID;
        }

        public Sharing(int? pShareID) : base()
        {
            ShareID = pShareID;
        }
    }
}
