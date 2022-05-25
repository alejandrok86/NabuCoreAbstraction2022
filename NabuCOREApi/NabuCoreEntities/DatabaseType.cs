using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public enum DatabaseType
    {
        Unspecified,
        MSAccess,
        MSSQL,
        MySQL,
        Oracle
    }

    [DataContract]
    public static class ConvertDatabaseType
    {
        public static DatabaseType FromString(string pDatabaseType)
        {
            if (pDatabaseType.CompareTo("MSAccess") == 0)
                return DatabaseType.MSAccess;
            else if (pDatabaseType.CompareTo("MySQL") == 0)
                return DatabaseType.MySQL;
            else if (pDatabaseType.CompareTo("Oracle") == 0)
                return DatabaseType.Oracle;
            else
                return DatabaseType.MSSQL;
        }

        public static string ToString(DatabaseType pDatabaseType)
        {
            if (pDatabaseType == DatabaseType.MSAccess)
                return "MSAccess";
            else if (pDatabaseType == DatabaseType.MySQL)
                return "MySQL";
            else if (pDatabaseType == DatabaseType.Oracle)
                return "Oracle";
            else
                return "MSSQL";
        }
    }
}
