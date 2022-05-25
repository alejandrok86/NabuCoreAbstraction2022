using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class QualityMethod : BaseType
    {
        [DataMember]
        public int? QualityMethodID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public QualityMethod() : base()
        {
            QualityMethodID = null;
        }

        public QualityMethod(int pQualityMethodID) : base()
        {
            QualityMethodID = pQualityMethodID;
        }

        public QualityMethod(int? pQualityMethodID) : base()
        {
            QualityMethodID = pQualityMethodID;
        }
    }
}
