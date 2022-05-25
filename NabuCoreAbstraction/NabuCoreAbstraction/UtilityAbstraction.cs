using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Utility;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class UtilityAbstraction : BaseAbstraction
    {
        public UtilityAbstraction() : base()
        {
        }

        public UtilityAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Entity Attribute
         *********************************************************************/
        public EntityAttribute GetEntityAttribute(int? pEntityAttributeID)
        {
            return null;
        }

        public EntityAttribute[] ListEntityAttribute()
        {
            return null;
        }

        public EntityAttribute InsertEntityAttribute(EntityAttribute pEntityAttribute)
        {
            return null;
        }

        public EntityAttribute UpdateEntityAttribute(EntityAttribute pEntityAttribute)
        {
            return null;
        }

        public EntityAttribute DeleteEntityAttribute(EntityAttribute pEntityAttribute)
        {
            return null;
        }
    }
}
