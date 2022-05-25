using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class BaseAbstraction
    {
        public string ConnectionString;

        public DatabaseType DBType;

        public string ErrorLogFile;

        public BaseAbstraction()
        {
        }

        public BaseAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile)
        {
            ConnectionString = pConnectionString;
            DBType = pDBType;
            ErrorLogFile = pErrorLogFile;
        }

        public void CustomLogError(string pModule, string pMethod, string pMessage)
        {
            Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
            DOL.LogError(pModule, pMethod, pMessage, false);
        }

        /**********************************************************************
         * Custom Queries
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean CustomNonQuery(string pSQL)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomNonQuery(pSQL);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string pSQL)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQuery(pSQL);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string pSQL, bool pLogErrorsToDB)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQuery(pSQL, pLogErrorsToDB);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string pSQL, bool pLogErrorsToDB, string pFieldSeparator)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQuery(pSQL, pLogErrorsToDB, pFieldSeparator);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQueryNoLogging(string pSQL)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQueryNoLogging(pSQL);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseDecimal CustomQueryAsDecimal(string pSQL)
        {
            BaseDecimal result = new BaseDecimal(0);
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                BaseString[] recordSet = DOL.CustomQuery(pSQL);
                if (recordSet != null)
                {
                    if (recordSet.Length == 1)
                    {
                        if (recordSet[0].ErrorsDetected == false)
                        {
                            if (recordSet[0].Value != null && recordSet[0].Value.Trim().Length > 0)
                            {
                                try
                                {
                                    result.Value = System.Convert.ToDecimal(recordSet[0].Value);
                                }
                                catch (System.Exception exc)
                                {
                                    result.ErrorsDetected = true;
                                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Caught: " + exc.Message));
                                    result.StackTrace = exc.StackTrace;
                                }
                            }
                            else
                            {
                                result.ErrorsDetected = true;
                                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "An empty value was returned by the query"));
                            }
                        }
                        else
                        {
                            result.ErrorsDetected = true;
                            result.ErrorDetails = recordSet[0].ErrorDetails;
                        }
                    }
                    else
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "More than a single record was returned, check your query."));
                    }
                }
                else
                {
                    result.ErrorsDetected = true;
                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "NULL recordset returned from Query"));
                }
            }
            else
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unsupported Database Type"));
            }
            return result;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseInteger CustomQueryAsInteger(string pSQL)
        {
            BaseInteger result = new BaseInteger(0);
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                BaseString[] recordSet = DOL.CustomQuery(pSQL);
                if (recordSet != null)
                {
                    if (recordSet.Length == 1)
                    {
                        if (recordSet[0].ErrorsDetected == false)
                        {
                            if (recordSet[0].Value != null && recordSet[0].Value.Trim().Length > 0)
                            {
                                try
                                {
                                    result.Value = System.Convert.ToInt32(recordSet[0].Value);
                                }
                                catch (System.Exception exc)
                                {
                                    result.ErrorsDetected = true;
                                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Caught: " + exc.Message));
                                    result.StackTrace = exc.StackTrace;
                                }
                            }
                            else
                            {
                                result.ErrorsDetected = true;
                                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "An empty value was returned by the query"));
                            }
                        }
                        else
                        {
                            result.ErrorsDetected = true;
                            result.ErrorDetails = recordSet[0].ErrorDetails;
                        }
                    }
                    else
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "More than a single record was returned, check your query."));
                    }
                }
                else
                {
                    result.ErrorsDetected = true;
                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "NULL recordset returned from Query"));
                }
            }
            else
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unsupported Database Type"));
            }
            return result;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseDateTime CustomQueryAsDateTime(string pSQL)
        {
            BaseDateTime result = new BaseDateTime();
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                BaseString[] recordSet = DOL.CustomQuery(pSQL);
                if (recordSet != null)
                {
                    if (recordSet.Length == 1)
                    {
                        if (recordSet[0].ErrorsDetected == false)
                        {
                            if (recordSet[0].Value != null && recordSet[0].Value.Trim().Length > 0)
                            {
                                try
                                {
                                    result.Value = System.DateTime.ParseExact(recordSet[0].Value.Replace("'", ""), "dd-MMM-yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                                }
                                catch (System.Exception exc)
                                {
                                    result.ErrorsDetected = true;
                                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Caught: " + exc.Message));
                                    result.StackTrace = exc.StackTrace;
                                }
                            }
                            else
                            {
                                result.ErrorsDetected = true;
                                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "An empty value was returned by the query"));
                            }
                        }
                        else
                        {
                            result.ErrorsDetected = true;
                            result.ErrorDetails = recordSet[0].ErrorDetails;
                        }
                    }
                    else
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "More than a single record was returned, check your query."));
                    }
                }
                else
                {
                    result.ErrorsDetected = true;
                    result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "NULL recordset returned from Query"));
                }
            }
            else
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unsupported Database Type"));
            }
            return result;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair[] CustomKeyPair(string pSQL)
        {
            return CustomKeyPair(pSQL, true);
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair[] CustomKeyPair(string pSQL, bool pLogErrorsToDB)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQueryKeyPair(pSQL, pLogErrorsToDB);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQueryDelimeted(string pSQL)
        {
            return CustomQueryDelimeted(pSQL, true);
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQueryDelimeted(string pSQL, bool pLogErrorsToDB)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQueryDelimeted(pSQL, pLogErrorsToDB);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString CustomQueryAsCSVString(string pSQL)
        {
            return CustomQueryAsCSVString(pSQL, true);
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString CustomQueryAsCSVString(string pSQL, bool pLogErrorsToDB)
        {
            if (DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new CORE.DOL.MSSQL.BaseDOL(ConnectionString, ErrorLogFile);
                return DOL.CustomQueryAsCSVString(pSQL, pLogErrorsToDB);
            }
            else
                return null;
        }


        /**********************************************************************
         * Connection String
         *********************************************************************/
        public string GetDatabaseNameFromConnectionString()
        {
            string initialCatalog = "";
            try
            {
                string semiColon = ";";
                string equals = "=";
                if (DBType == DatabaseType.MSSQL)
                {
                    //Data Source=KRISTIANKNO215C\SQLEXPRESS;Integrated Security=True;Initial Catalog=InsignisAMLive
                    if (ConnectionString.Contains(semiColon))
                    {
                        string[] keyPairs = ConnectionString.Split(semiColon.ToCharArray());
                        if (keyPairs.Length > 0)
                        {
                            foreach (string keyPair in keyPairs)
                            {
                                if (keyPair.Contains(equals))
                                {
                                    string[] parts = keyPair.Split(equals.ToCharArray());
                                    if (parts[0].ToLower().CompareTo("initial catalog") == 0)
                                    {
                                        initialCatalog = parts[1];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (DBType == DatabaseType.MySQL)
                {
                    // server=localhost;user=root;database=cgbilag;port=3306;password=tiamat;default command timeout=120;
                    if (ConnectionString.Contains(";"))
                    {
                        string[] keyPairs = ConnectionString.Split(semiColon.ToCharArray());
                        if (keyPairs.Length > 0)
                        {
                            foreach (string keyPair in keyPairs)
                            {
                                if (keyPair.Contains(equals))
                                {
                                    string[] parts = keyPair.Split(equals.ToCharArray());
                                    if (parts[0].ToLower().CompareTo("database") == 0)
                                    {
                                        initialCatalog = parts[1];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (DBType == DatabaseType.MSAccess)
                {
                }
            }
            catch
            {
            }
            return initialCatalog;
        }
    }
}
