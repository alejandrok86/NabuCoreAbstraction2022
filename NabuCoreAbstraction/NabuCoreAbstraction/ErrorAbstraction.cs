using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ErrorAbstraction : BaseAbstraction
    {
        public ErrorAbstraction() : base()
        {
        }

        public ErrorAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Error Detail
         *********************************************************************/
        public ErrorDetail InsertErrorDetail(string pErrorMessage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.LogError("ErrorAbstraction","InsertErrorDetail",pErrorMessage);
            }
            else
                return null;
        }

        /**********************************************************************
         * ErrorCode
         *********************************************************************/
        public ErrorCode GetErrorCode(int pErrorCodeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.Get(pErrorCodeID, pLanguageID);
            }
            else
                return null;
        }

        public ErrorCode GetErrorCodeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ErrorCode GetErrorCodeByAlias(string pAlias, string pDefaultMessage, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.GetByAliasWithDefault(pAlias, pDefaultMessage, pLanguageID);
            }
            else
                return null;
        }

        public ErrorCode[] ListErrorCodes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ErrorCode InsertErrorCode(ErrorCode pErrorCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.Insert(pErrorCode);
            }
            else
                return null;
        }

        public ErrorCode UpdateErrorCode(ErrorCode pErrorCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.Update(pErrorCode);
            }
            else
                return null;
        }

        public ErrorCode DeleteErrorCode(ErrorCode pErrorCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error.ErrorCodeDOL errorCodeDOL = new CORE.DOL.MSSQL.Error.ErrorCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return errorCodeDOL.Delete(pErrorCode);
            }
            else
                return null;
        }
    }
}
