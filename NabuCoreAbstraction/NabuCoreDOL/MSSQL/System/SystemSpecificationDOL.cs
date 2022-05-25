using Octavo.Gate.Nabu.CORE.Entities.System;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class SystemSpecificationDOL : BaseDOL
    {
        public SystemSpecificationDOL() : base ()
        {
        }

        public SystemSpecificationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SystemSpecification Get(int? pSystemSpecificationID)
        {
            return null;
        }

        public SystemSpecification[] List()
        {
            return null;
        }

        public SystemSpecification Insert(SystemSpecification pSystemSpecification)
        {
            return null;
        }

        public SystemSpecification Update(SystemSpecification pSystemSpecification)
        {
            return null;
        }

        public SystemSpecification Delete(SystemSpecification pSystemSpecification)
        {
            return null;
        }
    }
}
