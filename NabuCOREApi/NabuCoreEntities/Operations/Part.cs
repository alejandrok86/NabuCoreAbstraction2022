using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(Instrument))]
    [DataContract]
    [Serializable()]
    public class Part : BaseType
    {
        [DataMember]
        public int? PartID { get; set; }

        [DataMember]
        public string PartCode { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public PartType PartType { get; set; }

        [DataMember]
        public PartFeature[] PartFeatures { get; set; }

        [DataMember]
        public Content.Content[] Content { get; set; }

        public Part() : base()
        {
            PartID = null;
        }

        public Part(int? pPartID) : base()
        {
            PartID = pPartID;
        }

        public Part(int pPartID) : base()
        {
            PartID = pPartID;
        }

        public Part(int? pPartID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            PartID = pPartID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Part(int pPartID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            PartID = pPartID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public PartFeature GetPartFeatureByAlias(string pAlias)
        {
            PartFeature partFeature = new PartFeature();
            if (PartFeatures != null && PartFeatures.Length > 0)
            {
                foreach (PartFeature pf in PartFeatures)
                {
                    if (pf.ErrorsDetected == false)
                    {
                        if (pf.PartFeatureType != null && pf.PartFeatureType.ErrorsDetected == false)
                        {
                            if (pf.PartFeatureType.Detail != null && pf.PartFeatureType.Detail.Alias != null && pf.PartFeatureType.Detail.Alias.Trim().Length > 0)
                            {
                                if (pf.PartFeatureType.Detail.Alias.CompareTo(pAlias) == 0)
                                {
                                    partFeature = pf;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return partFeature;
        }
    }
}
