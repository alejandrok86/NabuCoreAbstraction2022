using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    public class BaseResultRow
    {
        public List<BaseResultColumn> columns { get; set; }

        public BaseResultRow()
        {
            columns = new List<BaseResultColumn>();
        }
    }
}
