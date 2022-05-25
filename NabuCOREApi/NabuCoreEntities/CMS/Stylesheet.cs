﻿using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class Stylesheet : Content.Content
    {
        public Stylesheet() : base()
        {
        }

        public Stylesheet(int pStylesheetID) : base(pStylesheetID)
        {
        }

        public Stylesheet(int? pStylesheetID) : base(pStylesheetID)
        {
        }
    }
}
