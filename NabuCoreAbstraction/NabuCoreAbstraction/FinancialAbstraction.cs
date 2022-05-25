using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class FinancialAbstraction : BaseAbstraction
    {
        public FinancialAbstraction() : base()
        {
        }

        public FinancialAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }
        /**********************************************************************
         * Account
         *********************************************************************/
        public Account GetAccount(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountID);
            }
            else
                return null;
        }

        public Account GetAccountByNumber(string pAccountNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAccountNumber(pAccountNumber);
            }
            else
                return null;
        }

        public Account GetAccountByReference(string pAccountReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAccountReference(pAccountReference);
            }
            else
                return null;
        }

        public Account GetAccountParent(int pChildAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetParent(pChildAccountID);
            }
            else
                return null;
        }

        public Account[] ListAccounts(int pClientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAll(pClientID);
            }
            else
                return null;
        }

        public Account[] ListAccounts(int pClientID, int pAccountTypeID, int? pParentAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID,  pAccountTypeID, pParentAccountID);
            }
            else
                return null;
        }

        public Account[] ListAccounts(int pClientID, int pAccountTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID, pAccountTypeID);
            }
            else
                return null;
        }
        public Account[] ListAccounts(int pClientID, string pAccountTypeAliasLike)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID, pAccountTypeAliasLike);
            }
            else
                return null;
        }

        public Account[] ListAccountChildren(int pParentAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentAccountID);
            }
            else
                return null;
        }

        public Account InsertAccount(Account pAccount, int pClientID, int? pParentAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccount,pClientID, pParentAccountID);
            }
            else
                return null;
        }

        public Account UpdateAccount(Account pAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccount);
            }
            else
                return null;
        }

        public Account DeleteAccount(Account pAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccount);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Attribute
         *********************************************************************/
        public AccountAttribute GetAccountAttribute(int pAccountID, int pAccountAttributeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountID, pAccountAttributeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttribute[] ListAccountAttributes(int pAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttribute InsertAccountAttribute(AccountAttribute pAccountAttribute, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountAttribute, pAccountID);
            }
            else
                return null;
        }

        public AccountAttribute UpdateAccountAttribute(AccountAttribute pAccountAttribute, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountAttribute, pAccountID);
            }
            else
                return null;
        }

        public AccountAttribute DeleteAccountAttribute(AccountAttribute pAccountAttribute, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountAttribute, pAccountID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Attribute Data Type
         *********************************************************************/
        public AccountAttributeDataType GetAccountAttributeDataType(int pAccountAttributeDataTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountAttributeDataTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeDataType GetAccountAttributeDataTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeDataType[] ListAccountAttributeDataTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeDataType InsertAccountAttributeDataType(AccountAttributeDataType pAccountAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountAttributeDataType);
            }
            else
                return null;
        }

        public AccountAttributeDataType UpdateAccountAttributeDataType(AccountAttributeDataType pAccountAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountAttributeDataType);
            }
            else
                return null;
        }

        public AccountAttributeDataType DeleteAccountAttributeDataType(AccountAttributeDataType pAccountAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountAttributeDataType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Attribute Type
         *********************************************************************/
        public AccountAttributeType GetAccountAttributeType(int pAccountAttributeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountAttributeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeType GetAccountAttributeTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeType[] ListAccountAttributeTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeType[] ListAccountAttributeTypes(int pAccountTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountAttributeType InsertAccountAttributeType(AccountAttributeType pAccountAttributeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountAttributeType);
            }
            else
                return null;
        }

        public AccountAttributeType UpdateAccountAttributeType(AccountAttributeType pAccountAttributeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountAttributeType);
            }
            else
                return null;
        }

        public AccountAttributeType DeleteAccountAttributeType(AccountAttributeType pAccountAttributeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountAttributeType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Definition
         *********************************************************************/
        public AccountDefinition GetAccountDefinition(int pAccountDefinitionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountDefinitionID, pLanguageID);
            }
            else
                return null;
        }
        public AccountDefinition[] ListAccountDefinitions(int pInstitutionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID, pLanguageID);
            }
            else
                return null;
        }
        public AccountDefinition[] ListAccountDefinitionsUpdatedAfter(int pInstitutionID, DateTime pUpdatedAfter, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListUpdatedAfter(pInstitutionID, pUpdatedAfter, pLanguageID);
            }
            else
                return null;
        }
        public AccountDefinition InsertAccountDefinition(AccountDefinition pAccountDefinition, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountDefinition, pInstitutionID);
            }
            else
                return null;
        }
        public AccountDefinition UpdateAccountDefinition(AccountDefinition pAccountDefinition, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountDefinition, pInstitutionID);
            }
            else
                return null;
        }
        public AccountDefinition DeleteAccountDefinition(AccountDefinition pAccountDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountDefinitionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountDefinition);
            }
            else
                return null;
        }
        /**********************************************************************
         * AccountFee
         *********************************************************************/
        public AccountFee GetAccountFee(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountFeeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountFeeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountID);
            }
            else
                return null;
        }

        public AccountFee UpdateAccountFee(AccountFee pAccountFee, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountFeeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountFeeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountFee, pAccountID);
            }
            else
                return null;
        }

        public AccountFee DeleteAccountFee(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountFeeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountFeeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountID);
            }
            else
                return null;
        }
        /**********************************************************************
         * AccountLiquidity
         *********************************************************************/
        public AccountLiquidity GetAccountLiquidity(int pAccountLiquidityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountLiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.AccountLiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountLiquidityID, pLanguageID);
            }
            else
                return null;
        }

        public AccountLiquidity[] ListAccountLiquidities(int pAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountLiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.AccountLiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID, pLanguageID);
            }
            else
                return null;
        }

        public AccountLiquidity InsertAccountLiquidity(AccountLiquidity pAccountLiquidity, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountLiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.AccountLiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountLiquidity, pAccountID);
            }
            else
                return null;
        }

        public AccountLiquidity UpdateAccountLiquidity(AccountLiquidity pAccountLiquidity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountLiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.AccountLiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountLiquidity);
            }
            else
                return null;
        }

        public AccountLiquidity DeleteAccountLiquidity(AccountLiquidity pAccountLiquidity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountLiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.AccountLiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountLiquidity);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Rate History
         *********************************************************************/
        public AccountRateHistory GetAccountRateHistory(int pAccountRateHistoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL DOL = new CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountRateHistoryID);
            }
            else
                return null;
        }

        public AccountRateHistory[] ListAccountRateHistories(int pAccountID, bool pAscending)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL DOL = new CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                if (pAscending)
                    return DOL.ListAscending(pAccountID);
                else
                    return DOL.ListDescending(pAccountID);
            }
            else
                return null;
        }

        public AccountRateHistory InsertAccountRateHistory(AccountRateHistory pAccountRateHistory, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL DOL = new CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountRateHistory, pAccountID);
            }
            else
                return null;
        }

        public AccountRateHistory UpdateAccountRateHistory(AccountRateHistory pAccountRateHistory, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL DOL = new CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountRateHistory, pAccountID);
            }
            else
                return null;
        }

        public AccountRateHistory DeleteAccountRateHistory(int pAccountRateHistoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL DOL = new CORE.DOL.MSSQL.Financial.AccountRateHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountRateHistoryID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Status
         *********************************************************************/
        public AccountStatus GetAccountStatus(int pAccountStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountStatusID, pLanguageID);
            }
            else
                return null;
        }

        public AccountStatus GetAccountStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AccountStatus[] ListAccountStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AccountStatus InsertAccountStatus(AccountStatus pAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountStatus);
            }
            else
                return null;
        }

        public AccountStatus UpdateAccountStatus(AccountStatus pAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountStatus);
            }
            else
                return null;
        }

        public AccountStatus DeleteAccountStatus(AccountStatus pAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountStatusDOL DOL = new CORE.DOL.MSSQL.Financial.AccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Transaction
         *********************************************************************/
        public AccountTransaction GetAccountTransaction(int pAccountTransactionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountTransactionID);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactions(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactionsDescending(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListDescending(pAccountID);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactions(int pAccountID, int pTransactionStatusID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID, pTransactionStatusID);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactions(int pAccountID, DateTime pFromDate, DateTime pToDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID, pFromDate, pToDate);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactions(int pAccountID, int pTransactionStatusID, DateTime pFromDate, DateTime pToDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID, pTransactionStatusID,pFromDate, pToDate);
            }
            else
                return null;
        }

        public AccountTransaction[] ListAccountTransactionsByType(int pAccountID, string pTransactionTypeAlias, DateTime pFromDate, DateTime pToDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByType(pAccountID, pTransactionTypeAlias, pFromDate, pToDate);
            }
            else
                return null;
        }

        public AccountTransaction InsertAccountTransaction(AccountTransaction pAccountTransaction, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountTransaction, pAccountID);
            }
            else
                return null;
        }

        public AccountTransaction UpdateAccountTransaction(AccountTransaction pAccountTransaction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountTransaction);
            }
            else
                return null;
        }

        public BaseBoolean UpdateAccountTransaction(int? pAccountTransactionID, int? pRelatedAccountID, int? pRelatedTransactionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountTransactionID, pRelatedAccountID, pRelatedTransactionID);
            }
            else
                return null;
        }

        public AccountTransaction DeleteAccountTransaction(AccountTransaction pAccountTransaction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTransactionDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTransactionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountTransaction);
            }
            else
                return null;
        }
        /**********************************************************************
         * Account Type
         *********************************************************************/
        public AccountType GetAccountType(int pAccountTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAccountTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountType GetAccountTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AccountType[] ListAccountTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAll(pLanguageID);
            }
            else
                return null;
        }

        public AccountType[] ListAccountTypes(int? pParentAccountTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pParentAccountTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AccountType InsertAccountType(AccountType pAccountType, int? pParentAccountTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAccountType, pParentAccountTypeID);
            }
            else
                return null;
        }

        public AccountType UpdateAccountType(AccountType pAccountType, int? pParentAccountTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAccountType, pParentAccountTypeID);
            }
            else
                return null;
        }

        public AccountType DeleteAccountType(AccountType pAccountType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AccountTypeDOL DOL = new CORE.DOL.MSSQL.Financial.AccountTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAccountType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Assessing Organisation
         *********************************************************************/
        public AssessingOrganisation GetAssessingOrganisation(int pAssessingOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL DOL = new CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessingOrganisationID);
            }
            else
                return null;
        }

        public AssessingOrganisation[] ListAssessingOrganisations()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL DOL = new CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public AssessingOrganisation InsertAssessingOrganisation(AssessingOrganisation pAssessingOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL DOL = new CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessingOrganisation);
            }
            else
                return null;
        }

        public AssessingOrganisation DeleteAssessingOrganisation(AssessingOrganisation pAssessingOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL DOL = new CORE.DOL.MSSQL.Financial.AssessingOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessingOrganisation);
            }
            else
                return null;
        }
        /**********************************************************************
         * Bill
         *********************************************************************/
        public Bill GetBill(int pBillID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBillID);
            }
            else
                return null;
        }

        public Bill GetBillByBarcode(string pBarcode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByBarcode(pBarcode);
            }
            else
                return null;
        }

        public Bill GetBillByReference(string pReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByReference(pReference);
            }
            else
                return null;
        }

        public Bill[] ListBills(int pClientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID);
            }
            else
                return null;
        }

        public Bill[] ListBillsByStatus(int pClientID, int pBillStatusID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByStatus(pClientID, pBillStatusID);
            }
            else
                return null;
        }

        public Bill InsertBill(Bill pBill)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBill);
            }
            else
                return null;
        }

        public Bill UpdateBill(Bill pBill)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBill);
            }
            else
                return null;
        }

        public Bill DeleteBill(Bill pBill)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillDOL DOL = new CORE.DOL.MSSQL.Financial.BillDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBill);
            }
            else
                return null;
        }
        /**********************************************************************
         * BillLine
         *********************************************************************/
        public BillLine GetBillLine(int pBillLineID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillLineDOL DOL = new CORE.DOL.MSSQL.Financial.BillLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBillLineID);
            }
            else
                return null;
        }

        public BillLine[] ListBillLines(int pBillID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillLineDOL DOL = new CORE.DOL.MSSQL.Financial.BillLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pBillID);
            }
            else
                return null;
        }

        public BillLine InsertBillLine(BillLine pBillLine, int pBillID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillLineDOL DOL = new CORE.DOL.MSSQL.Financial.BillLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBillLine, pBillID);
            }
            else
                return null;
        }

        public BillLine UpdateBillLine(BillLine pBillLine)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillLineDOL DOL = new CORE.DOL.MSSQL.Financial.BillLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBillLine);
            }
            else
                return null;
        }

        public BillLine DeleteBillLine(BillLine pBillLine)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillLineDOL DOL = new CORE.DOL.MSSQL.Financial.BillLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBillLine);
            }
            else
                return null;
        }
        /**********************************************************************
         * BillStatus
         *********************************************************************/
        public BillStatus GetBillStatus(int pBillStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBillStatusID, pLanguageID);
            }
            else
                return null;
        }

        public BillStatus GetBillStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public BillStatus[] ListBillStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public BillStatus InsertBillStatus(BillStatus pBillStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBillStatus);
            }
            else
                return null;
        }

        public BillStatus UpdateBillStatus(BillStatus pBillStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBillStatus);
            }
            else
                return null;
        }

        public BillStatus DeleteBillStatus(BillStatus pBillStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillStatusDOL DOL = new CORE.DOL.MSSQL.Financial.BillStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBillStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * BillType
         *********************************************************************/
        public BillType GetBillType(int pBillTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBillTypeID, pLanguageID);
            }
            else
                return null;
        }

        public BillType GetBillTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public BillType[] ListBillTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public BillType InsertBillType(BillType pBillType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBillType);
            }
            else
                return null;
        }

        public BillType UpdateBillType(BillType pBillType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBillType);
            }
            else
                return null;
        }

        public BillType DeleteBillType(BillType pBillType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BillTypeDOL DOL = new CORE.DOL.MSSQL.Financial.BillTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBillType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Branch
         *********************************************************************/
        public Branch GetBranch(int pBranchID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BranchDOL DOL = new CORE.DOL.MSSQL.Financial.BranchDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBranchID);
            }
            else
                return null;
        }

        public Branch[] ListBranches()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BranchDOL DOL = new CORE.DOL.MSSQL.Financial.BranchDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Branch InsertBranch(Branch pBranch)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BranchDOL DOL = new CORE.DOL.MSSQL.Financial.BranchDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBranch);
            }
            else
                return null;
        }

        public Branch UpdateBranch(Branch pBranch)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BranchDOL DOL = new CORE.DOL.MSSQL.Financial.BranchDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBranch);
            }
            else
                return null;
        }

        public Branch DeleteBranch(Branch pBranch)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.BranchDOL DOL = new CORE.DOL.MSSQL.Financial.BranchDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBranch);
            }
            else
                return null;
        }
        /**********************************************************************
         * Category Classification
         *********************************************************************/
        public CategoryClassification GetCategoryClassification(int pCategoryClassificationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCategoryClassificationID, pLanguageID);
            }
            else
                return null;
        }

        public CategoryClassification[] ListCategoryClassifications(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public CategoryClassification InsertCategoryClassification(CategoryClassification pCategoryClassification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCategoryClassification);
            }
            else
                return null;
        }

        public CategoryClassification UpdateCategoryClassification(CategoryClassification pCategoryClassification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCategoryClassification);
            }
            else
                return null;
        }

        public CategoryClassification DeleteCategoryClassification(CategoryClassification pCategoryClassification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCategoryClassification);
            }
            else
                return null;
        }
        /**********************************************************************
         * Category Classification Value
         *********************************************************************/
        public CategoryClassificationValue GetCategoryClassificationValue(int pInstitionScoreID, int pCategoryClassificationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitionScoreID, pCategoryClassificationID, pLanguageID);
            }
            else
                return null;
        }

        public CategoryClassificationValue[] ListCategoryClassificationValues(int pInstitionScoreID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitionScoreID, pLanguageID);
            }
            else
                return null;
        }

        public CategoryClassificationValue InsertCategoryClassificationValue(CategoryClassificationValue pCategoryClassificationValue, int pInstitionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCategoryClassificationValue, pInstitionScoreID);
            }
            else
                return null;
        }

        public CategoryClassificationValue UpdateCategoryClassificationValue(CategoryClassificationValue pCategoryClassificationValue, int pInstitionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCategoryClassificationValue, pInstitionScoreID);
            }
            else
                return null;
        }

        public CategoryClassificationValue DeleteCategoryClassificationValue(int pInstitionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL DOL = new CORE.DOL.MSSQL.Financial.CategoryClassificationValueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitionScoreID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Client
         *********************************************************************/
        public Client GetClient(int pClientID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                Client client =  DOL.Get(pClientID);
                if(client.ErrorsDetected == false)
                {
                    if(client.Status != null && client.Status.ClientStatusID.HasValue)
                        client.Status = GetClientStatus((int)client.Status.ClientStatusID, pLanguageID);
                    if (client.Category != null && client.Category.ClientCategoryID.HasValue)
                        client.Category = GetClientCategory((int)client.Category.ClientCategoryID, pLanguageID);
                }
                return client;
            }
            else
                return null;
        }

        public Client GetClientByAccountID(int pAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);

                Client client = new Client();
                BaseString[] recordSet = DOL.CustomQuery("SELECT ClientID FROM [SchFinancial].[Account] WHERE AccountID=" + pAccountID);
                if (recordSet.Length > 0)
                {
                    if (recordSet[0].ErrorsDetected == false)
                    {
                        string[] fields = recordSet[0].GetFields();

                        client = DOL.Get(Convert.ToInt32(fields[0].Replace("'","")));
                        if (client.ErrorsDetected == false && client.PartyID.HasValue)
                        {
                            if (client.Status != null && client.Status.ClientStatusID.HasValue)
                                client.Status = GetClientStatus((int)client.Status.ClientStatusID, pLanguageID);
                            if (client.Category != null && client.Category.ClientCategoryID.HasValue)
                                client.Category = GetClientCategory((int)client.Category.ClientCategoryID, pLanguageID);
                        }
                    }
                }
                return client;
            }
            else
                return null;
        }

        public Client GetClientByReference(string pClientReference, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                Client client = DOL.GetByReference(pClientReference);
                if (client.ErrorsDetected == false)
                {
                    if (client.Status != null && client.Status.ClientStatusID.HasValue)
                        client.Status = GetClientStatus((int)client.Status.ClientStatusID, pLanguageID);
                    if (client.Category != null && client.Category.ClientCategoryID.HasValue)
                        client.Category = GetClientCategory((int)client.Category.ClientCategoryID, pLanguageID);
                }
                return client;
            }
            else
                return null;
        }

        public Client[] ListClients()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }
        public Client[] ListClientsLike(string pClientReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListReferenceLike(pClientReference);
            }
            else
                return null;
        }

        public Client InsertClient(Client pClient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClient);
            }
            else
                return null;
        }

        public Client UpdateClient(Client pClient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClient);
            }
            else
                return null;
        }

        public Client DeleteClient(Client pClient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientDOL DOL = new CORE.DOL.MSSQL.Financial.ClientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClient);
            }
            else
                return null;
        }
        /**********************************************************************
         * Client Category
         *********************************************************************/
        public ClientCategory GetClientCategory(int pClientCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClientCategoryID, pLanguageID);
            }
            else
                return null;
        }

        public ClientCategory GetClientCategoryByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ClientCategory[] ListClientCategories(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ClientCategory InsertClientCategory(ClientCategory pClientCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClientCategory);
            }
            else
                return null;
        }

        public ClientCategory UpdateClientCategory(ClientCategory pClientCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClientCategory);
            }
            else
                return null;
        }

        public ClientCategory DeleteClientCategory(ClientCategory pClientCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.ClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClientCategory);
            }
            else
                return null;
        }
        /**********************************************************************
         * Client Status
         *********************************************************************/
        public ClientStatus GetClientStatus(int pClientStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClientStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ClientStatus GetClientStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ClientStatus[] ListClientStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ClientStatus InsertClientStatus(ClientStatus pClientStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClientStatus);
            }
            else
                return null;
        }

        public ClientStatus UpdateClientStatus(ClientStatus pClientStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClientStatus);
            }
            else
                return null;
        }

        public ClientStatus DeleteClientStatus(ClientStatus pClientStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ClientStatusDOL DOL = new CORE.DOL.MSSQL.Financial.ClientStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClientStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Country Rating
         *********************************************************************/
        public CountryRating[] ListCountryRatings(int pCountryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CountryRatingDOL DOL = new CORE.DOL.MSSQL.Financial.CountryRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCountryID);
            }
            else
                return null;
        }

        public CountryRating InsertCountryRating(CountryRating pCountryRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CountryRatingDOL DOL = new CORE.DOL.MSSQL.Financial.CountryRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCountryRating);
            }
            else
                return null;
        }

        public CountryRating DeleteCountryRating(CountryRating pCountryRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CountryRatingDOL DOL = new CORE.DOL.MSSQL.Financial.CountryRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCountryRating);
            }
            else
                return null;
        }
        public CountryRating DeleteCountryRatingForCountry(int pCountryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CountryRatingDOL DOL = new CORE.DOL.MSSQL.Financial.CountryRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteForCountry(pCountryID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Currency
         *********************************************************************/
        public Currency GetCurrency(int pCurrencyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCurrencyID);
            }
            else
                return null;
        }

        public Currency GetCurrencyByCode(string pCurrencyCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByCode(pCurrencyCode);
            }
            else
                return null;
        }

        public Currency[] ListCurrencies(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Currency InsertCurrency(Currency pCurrency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCurrency);
            }
            else
                return null;
        }

        public Currency UpdateCurrency(Currency pCurrency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCurrency);
            }
            else
                return null;
        }

        public Currency DeleteCurrency(Currency pCurrency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.CurrencyDOL DOL = new CORE.DOL.MSSQL.Financial.CurrencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCurrency);
            }
            else
                return null;
        }
        /**********************************************************************
         * Institution
         *********************************************************************/
        public Institution GetInstitution(int pInstitutionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionID, pLanguageID);
            }
            else
                return null;
        }

        public Institution GetInstitutionByShortName(string pBankShortName, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForShortName(pBankShortName, pLanguageID);
            }
            else
                return null;
        }

        public Institution GetInstitutionByShortNameAndClientType(string pBankShortName, string pClientTypeName, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForShortNameAndClientType(pBankShortName, pClientTypeName, pLanguageID);
            }
            else
                return null;
        }

        public Institution GetInstitutionByPart(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForPart(pPartID);
            }
            else
                return null;
        }

        public Institution[] ListInstitutions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Institution[] ListInstitutionsForClientCategory(string pClientCategoryName, int pLanguageID, bool pAcceptsDeposits, bool pIsOffshore)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Institution[] ListInstitutionsWhereAccountFeatureUpdatedAfter(DateTime pUpdatedAfter, int pPartFeatureTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWhereAccountFeatureUpdatedAfter(pUpdatedAfter, pPartFeatureTypeID, pLanguageID);
            }
            else
                return null;
        }

        public Institution[] ListInstitutionsWhereAccountDefinitionUpdatedAfter(DateTime pUpdatedAfter, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWhereAccountDefinitionUpdatedAfter(pUpdatedAfter, pLanguageID);
            }
            else
                return null;
        }

        public Institution InsertInstitution(Institution pInstitution)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL organisationDOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Core.Organisation organisation = new Entities.Core.Organisation();
                organisation.Name = pInstitution.Name;
                organisation.PartyType = new Entities.Core.PartyType(pInstitution.PartyType.PartyTypeID);
                organisation = organisationDOL.Insert(organisation);
                if (organisation.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.FormalOrganisationDOL formalOrganisationDOL = new CORE.DOL.MSSQL.Core.FormalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                    Entities.Core.FormalOrganisation formalOrganisation = formalOrganisationDOL.Assign(new Entities.Core.FormalOrganisation(organisation.PartyID));
                    if (formalOrganisation.ErrorsDetected == false)
                    {
                        pInstitution.PartyID = formalOrganisation.PartyID;
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                        return DOL.Insert(pInstitution);
                    }
                    else
                    {
                        pInstitution.ErrorsDetected = true;
                        pInstitution.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, formalOrganisation.ErrorDetails[0].ErrorMessage));
                        return pInstitution;
                    }
                }
                else
                {
                    pInstitution.ErrorsDetected = true;
                    pInstitution.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, organisation.ErrorDetails[0].ErrorMessage));
                    return pInstitution;
                }
            }
            else
                return null;
        }

        public Institution UpdateInstitution(Institution pInstitution)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL organisationDOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Core.Organisation organisation = new Entities.Core.Organisation();
                organisation.PartyID = pInstitution.PartyID;
                organisation.Name = pInstitution.Name;
                organisation.PartyType = new Entities.Core.PartyType(pInstitution.PartyType.PartyTypeID);
                organisation = organisationDOL.Update(organisation);
                if (organisation.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                    return DOL.Update(pInstitution);
                }
                else
                {
                    pInstitution.ErrorsDetected = true;
                    pInstitution.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, organisation.ErrorDetails[0].ErrorMessage));
                    return pInstitution;
                }
            }
            else
                return null;
        }

        public Institution DeleteInstitution(Institution pInstitution)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionDOL(base.ConnectionString, base.ErrorLogFile);
                Institution institution = DOL.Delete(pInstitution);
                if (institution.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.FormalOrganisationDOL formalOrganisationDOL = new CORE.DOL.MSSQL.Core.FormalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                    formalOrganisationDOL.Remove(new Entities.Core.FormalOrganisation(pInstitution.PartyID));

                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL organisationDOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                    organisationDOL.Delete(new Entities.Core.Organisation(pInstitution.PartyID));
                }
                return institution;
            }
            else
                return null;
        }

        /**********************************************************************
         * Institution Client Category
         *********************************************************************/
        public InstitutionClientCategory GetInstitutionClientCategory(int pInstitutionClientCategoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionClientCategoryID);
            }
            else
                return null;
        }

        public InstitutionClientCategory[] ListInstitutionClientCategories(int pInstitutionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionClientCategory InsertInstitutionClientCategory(InstitutionClientCategory pInstitutionClientCategory, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionClientCategory, pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionClientCategory UpdateInstitutionClientCategory(InstitutionClientCategory pInstitutionClientCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionClientCategory);
            }
            else
                return null;
        }

        public InstitutionClientCategory DeleteInstitutionClientCategory(InstitutionClientCategory pInstitutionClientCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionClientCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionClientCategory);
            }
            else
                return null;
        }

        /**********************************************************************
         * Institution Rating
         *********************************************************************/
        public InstitutionRating GetInstitutionRating(int pInstitutionRatingID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionRatingDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionRatingID);
            }
            else
                return null;
        }

        public InstitutionRating[] ListInstitutionRatings(int pInstitutionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionRatingDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionRating InsertInstitutionRating(InstitutionRating pInstitutionRating, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionRatingDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionRating, pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionRating UpdateInstitutionRating(InstitutionRating pInstitutionRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionRatingDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionRating);
            }
            else
                return null;
        }

        public InstitutionRating DeleteInstitutionRating(InstitutionRating pInstitutionRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionRatingDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionRatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionRating);
            }
            else
                return null;
        }
        /**********************************************************************
         * Institution Score
         *********************************************************************/
        public InstitutionScore GetInstitutionScore(int pInstitutionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionScoreID);
            }
            else
                return null;
        }

        public InstitutionScore[] ListInstitutionScores(int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionScore InsertInstitutionScore(InstitutionScore pInstitutionScore, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionScore, pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionScore UpdateInstitutionScore(InstitutionScore pInstitutionScore)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionScore);
            }
            else
                return null;
        }

        public InstitutionScore DeleteInstitutionScore(InstitutionScore pInstitutionScore)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionScore);
            }
            else
                return null;
        }
        public BaseBoolean DeleteAllInstitutionScores(int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionScoreDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteAll(pInstitutionID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Institution Status
         *********************************************************************/
        public InstitutionStatus GetInstitutionStatus(int pInstitutionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionStatus GetInstitutionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionStatus[] ListInstitutionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public InstitutionStatus InsertInstitutionStatus(InstitutionStatus pInstitutionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionStatus);
            }
            else
                return null;
        }

        public InstitutionStatus UpdateInstitutionStatus(InstitutionStatus pInstitutionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionStatus);
            }
            else
                return null;
        }

        public InstitutionStatus DeleteInstitutionStatus(InstitutionStatus pInstitutionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Institution Ticker
         *********************************************************************/
        public InstitutionTicker GetInstitutionTicker(int pInstitutionID, int pAssessingOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTickerDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTickerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionID, pAssessingOrganisationID);
            }
            else
                return null;
        }

        public InstitutionTicker[] ListInstitutionTickers(int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTickerDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTickerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionTicker InsertInstitutionTicker(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTickerDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTickerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionTicker, pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionTicker UpdateInstitutionTicker(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTickerDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTickerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionTicker, pInstitutionID);
            }
            else
                return null;
        }

        public InstitutionTicker DeleteInstitutionTicker(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTickerDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTickerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionTicker, pInstitutionID);
            }
            else
                return null;
        }
        /**********************************************************************
         * InstitutionType
         *********************************************************************/
        public InstitutionType GetInstitutionType(int pInstitutionTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionTypeID, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionType GetInstitutionTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public InstitutionType[] ListInstitutionTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public InstitutionType InsertInstitutionType(InstitutionType pInstitutionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstitutionType);
            }
            else
                return null;
        }

        public InstitutionType UpdateInstitutionType(InstitutionType pInstitutionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstitutionType);
            }
            else
                return null;
        }

        public InstitutionType DeleteInstitutionType(InstitutionType pInstitutionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstitutionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.InstitutionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstitutionType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Instrument
         *********************************************************************/
        public Instrument GetInstrument(int pInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstrumentDOL DOL = new CORE.DOL.MSSQL.Financial.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstrumentID, pLanguageID);
            }
            else
                return null;
        }

        public Instrument[] ListInstruments(int pInstitutionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstrumentDOL DOL = new CORE.DOL.MSSQL.Financial.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID, pLanguageID);
            }
            else
                return null;
        }

        public Instrument InsertInstrument(Instrument pInstrument, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstrumentDOL DOL = new CORE.DOL.MSSQL.Financial.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstrument, pInstitutionID);
            }
            else
                return null;
        }

        public Instrument UpdateInstrument(Instrument pInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstrumentDOL DOL = new CORE.DOL.MSSQL.Financial.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstrument);
            }
            else
                return null;
        }

        public Instrument DeleteInstrument(Instrument pInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.InstrumentDOL DOL = new CORE.DOL.MSSQL.Financial.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstrument);
            }
            else
                return null;
        }
        /**********************************************************************
         * Liquidity
         *********************************************************************/
        public Liquidity GetLiquidity(int pLiquidityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.LiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.LiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLiquidityID, pLanguageID);
            }
            else
                return null;
        }

        public Liquidity[] ListLiquidities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.LiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.LiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Liquidity InsertLiquidity(Liquidity pLiquidity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.LiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.LiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLiquidity);
            }
            else
                return null;
        }

        public Liquidity UpdateLiquidity(Liquidity pLiquidity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.LiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.LiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLiquidity);
            }
            else
                return null;
        }

        public Liquidity DeleteLiquidity(Liquidity pLiquidity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.LiquidityDOL DOL = new CORE.DOL.MSSQL.Financial.LiquidityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLiquidity);
            }
            else
                return null;
        }
        /**********************************************************************
         * Payment
         *********************************************************************/
        public Payment GetPayment(int pPaymentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentID);
            }
            else
                return null;
        }

        public Payment GetPaymentByReference(string pReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByReference(pReference);
            }
            else
                return null;
        }

        public Payment GetPaymentForTransaction(int pTransactionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForTransaction(pTransactionID);
            }
            else
                return null;
        }

        public Payment[] ListPayments(int pBillID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pBillID);
            }
            else
                return null;
        }

        public Payment InsertPayment(Payment pPayment, int pBillID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPayment, pBillID);
            }
            else
                return null;
        }

        public Payment UpdatePayment(Payment pPayment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPayment);
            }
            else
                return null;
        }

        public Payment DeletePayment(Payment pPayment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPayment);
            }
            else
                return null;
        }
        /**********************************************************************
         * PaymentMethod
         *********************************************************************/
        public PaymentMethod GetPaymentMethod(int pPaymentMethodID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentMethodID);
            }
            else
                return null;
        }

        public PaymentMethod[] ListPaymentMethods(int pClientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID);
            }
            else
                return null;
        }

        public PaymentMethod InsertPaymentMethod(PaymentMethod pPaymentMethod, int pClientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPaymentMethod, pClientID);
            }
            else
                return null;
        }

        public PaymentMethod UpdatePaymentMethod(PaymentMethod pPaymentMethod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPaymentMethod);
            }
            else
                return null;
        }

        public PaymentMethod DeletePaymentMethod(PaymentMethod pPaymentMethod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPaymentMethod);
            }
            else
                return null;
        }
        /**********************************************************************
         * PaymentMethodStatus
         *********************************************************************/
        public PaymentMethodStatus GetPaymentMethodStatus(int pPaymentMethodStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentMethodStatusID, pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodStatus GetPaymentMethodStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodStatus[] ListPaymentMethodStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodStatus InsertPaymentMethodStatus(PaymentMethodStatus pPaymentMethodStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPaymentMethodStatus);
            }
            else
                return null;
        }

        public PaymentMethodStatus UpdatePaymentMethodStatus(PaymentMethodStatus pPaymentMethodStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPaymentMethodStatus);
            }
            else
                return null;
        }

        public PaymentMethodStatus DeletePaymentMethodStatus(PaymentMethodStatus pPaymentMethodStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPaymentMethodStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * PaymentMethodType
         *********************************************************************/
        public PaymentMethodType GetPaymentMethodType(int pPaymentMethodTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentMethodTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodType GetPaymentMethodTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodType[] ListPaymentMethodTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PaymentMethodType InsertPaymentMethodType(PaymentMethodType pPaymentMethodType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPaymentMethodType);
            }
            else
                return null;
        }

        public PaymentMethodType UpdatePaymentMethodType(PaymentMethodType pPaymentMethodType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPaymentMethodType);
            }
            else
                return null;
        }

        public PaymentMethodType DeletePaymentMethodType(PaymentMethodType pPaymentMethodType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentMethodTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPaymentMethodType);
            }
            else
                return null;
        }
        /**********************************************************************
         * PaymentStatus
         *********************************************************************/
        public PaymentStatus GetPaymentStatus(int pPaymentStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentStatusID, pLanguageID);
            }
            else
                return null;
        }

        public PaymentStatus GetPaymentStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PaymentStatus[] ListPaymentStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PaymentStatus InsertPaymentStatus(PaymentStatus pPaymentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPaymentStatus);
            }
            else
                return null;
        }

        public PaymentStatus UpdatePaymentStatus(PaymentStatus pPaymentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPaymentStatus);
            }
            else
                return null;
        }

        public PaymentStatus DeletePaymentStatus(PaymentStatus pPaymentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentStatusDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPaymentStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * PaymentType
         *********************************************************************/
        public PaymentType GetPaymentType(int pPaymentTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPaymentTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PaymentType GetPaymentTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PaymentType[] ListPaymentTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PaymentType InsertPaymentType(PaymentType pPaymentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPaymentType);
            }
            else
                return null;
        }

        public PaymentType UpdatePaymentType(PaymentType pPaymentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPaymentType);
            }
            else
                return null;
        }

        public PaymentType DeletePaymentType(PaymentType pPaymentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.PaymentTypeDOL DOL = new CORE.DOL.MSSQL.Financial.PaymentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPaymentType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Quotation
         *********************************************************************/
        public Quotation GetQuotation(int pQuotationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pQuotationID);
            }
            else
                return null;
        }

        public Quotation GetQuotationByReference(string pReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByReference(pReference);
            }
            else
                return null;
        }

        public Quotation[] ListQuotations(int pClientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pClientID);
            }
            else
                return null;
        }

        public Quotation[] ListQuotationsByStatus(int pClientID, int pQuotationStatusID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByStatus(pClientID, pQuotationStatusID);
            }
            else
                return null;
        }

        public Quotation InsertQuotation(Quotation pQuotation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pQuotation);
            }
            else
                return null;
        }

        public Quotation UpdateQuotation(Quotation pQuotation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pQuotation);
            }
            else
                return null;
        }

        public Quotation DeleteQuotation(Quotation pQuotation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pQuotation);
            }
            else
                return null;
        }
        /**********************************************************************
         * QuotationLine
         *********************************************************************/
        public QuotationLine GetQuotationLine(int pQuotationLineID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationLineDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pQuotationLineID);
            }
            else
                return null;
        }

        public QuotationLine[] ListQuotationLines(int pQuotationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationLineDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pQuotationID);
            }
            else
                return null;
        }

        public QuotationLine InsertQuotationLine(QuotationLine pQuotationLine, int pQuotationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationLineDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pQuotationLine, pQuotationID);
            }
            else
                return null;
        }

        public QuotationLine UpdateQuotationLine(QuotationLine pQuotationLine)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationLineDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pQuotationLine);
            }
            else
                return null;
        }

        public QuotationLine DeleteQuotationLine(QuotationLine pQuotationLine)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationLineDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pQuotationLine);
            }
            else
                return null;
        }
        /**********************************************************************
         * QuotationStatus
         *********************************************************************/
        public QuotationStatus GetQuotationStatus(int pQuotationStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pQuotationStatusID, pLanguageID);
            }
            else
                return null;
        }

        public QuotationStatus GetQuotationStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public QuotationStatus[] ListQuotationStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public QuotationStatus InsertQuotationStatus(QuotationStatus pQuotationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pQuotationStatus);
            }
            else
                return null;
        }

        public QuotationStatus UpdateQuotationStatus(QuotationStatus pQuotationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pQuotationStatus);
            }
            else
                return null;
        }

        public QuotationStatus DeleteQuotationStatus(QuotationStatus pQuotationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationStatusDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pQuotationStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * QuotationType
         *********************************************************************/
        public QuotationType GetQuotationType(int pQuotationTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pQuotationTypeID, pLanguageID);
            }
            else
                return null;
        }

        public QuotationType GetQuotationTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public QuotationType[] ListQuotationTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public QuotationType InsertQuotationType(QuotationType pQuotationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pQuotationType);
            }
            else
                return null;
        }

        public QuotationType UpdateQuotationType(QuotationType pQuotationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pQuotationType);
            }
            else
                return null;
        }

        public QuotationType DeleteQuotationType(QuotationType pQuotationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.QuotationTypeDOL DOL = new CORE.DOL.MSSQL.Financial.QuotationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pQuotationType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Rating
         *********************************************************************/
        public Rating GetRating(int pRatingID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingDOL DOL = new CORE.DOL.MSSQL.Financial.RatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRatingID);
            }
            else
                return null;
        }

        public Rating[] ListRatings(int pRatingAgencyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingDOL DOL = new CORE.DOL.MSSQL.Financial.RatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pRatingAgencyID);
            }
            else
                return null;
        }

        public Rating InsertRating(Rating pRating, int pRatingAgencyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingDOL DOL = new CORE.DOL.MSSQL.Financial.RatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRating, pRatingAgencyID);
            }
            else
                return null;
        }

        public Rating UpdateRating(Rating pRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingDOL DOL = new CORE.DOL.MSSQL.Financial.RatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRating);
            }
            else
                return null;
        }

        public Rating DeleteRating(Rating pRating)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingDOL DOL = new CORE.DOL.MSSQL.Financial.RatingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRating);
            }
            else
                return null;
        }
        /**********************************************************************
         * Rating Agency
         *********************************************************************/
        public RatingAgency GetRatingAgency(int pRatingAgencyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingAgencyDOL DOL = new CORE.DOL.MSSQL.Financial.RatingAgencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRatingAgencyID, pLanguageID);
            }
            else
                return null;
        }

        public RatingAgency[] ListRatingAgencies()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingAgencyDOL DOL = new CORE.DOL.MSSQL.Financial.RatingAgencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public RatingAgency InsertRatingAgency(RatingAgency pRatingAgency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingAgencyDOL DOL = new CORE.DOL.MSSQL.Financial.RatingAgencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRatingAgency);
            }
            else
                return null;
        }

        public RatingAgency UpdateRatingAgency(RatingAgency pRatingAgency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingAgencyDOL DOL = new CORE.DOL.MSSQL.Financial.RatingAgencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRatingAgency);
            }
            else
                return null;
        }

        public RatingAgency DeleteRatingAgency(RatingAgency pRatingAgency)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingAgencyDOL DOL = new CORE.DOL.MSSQL.Financial.RatingAgencyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRatingAgency);
            }
            else
                return null;
        }
        /**********************************************************************
         * Rating Grade
         *********************************************************************/
        public RatingGrade GetRatingGrade(int pRatingGradeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingGradeDOL DOL = new CORE.DOL.MSSQL.Financial.RatingGradeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRatingGradeID, pLanguageID);
            }
            else
                return null;
        }

        public RatingGrade[] ListRatingGrades(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingGradeDOL DOL = new CORE.DOL.MSSQL.Financial.RatingGradeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RatingGrade InsertRatingGrade(RatingGrade pRatingGrade)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingGradeDOL DOL = new CORE.DOL.MSSQL.Financial.RatingGradeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRatingGrade);
            }
            else
                return null;
        }

        public RatingGrade UpdateRatingGrade(RatingGrade pRatingGrade)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingGradeDOL DOL = new CORE.DOL.MSSQL.Financial.RatingGradeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRatingGrade);
            }
            else
                return null;
        }

        public RatingGrade DeleteRatingGrade(RatingGrade pRatingGrade)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingGradeDOL DOL = new CORE.DOL.MSSQL.Financial.RatingGradeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRatingGrade);
            }
            else
                return null;
        }
        /**********************************************************************
         * Rating Outlook
         *********************************************************************/
        public RatingOutlook GetRatingOutlook(int pRatingOutlookID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingOutlookDOL DOL = new CORE.DOL.MSSQL.Financial.RatingOutlookDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRatingOutlookID, pLanguageID);
            }
            else
                return null;
        }

        public RatingOutlook[] ListRatingOutlooks(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingOutlookDOL DOL = new CORE.DOL.MSSQL.Financial.RatingOutlookDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RatingOutlook InsertRatingOutlook(RatingOutlook pRatingOutlook)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingOutlookDOL DOL = new CORE.DOL.MSSQL.Financial.RatingOutlookDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRatingOutlook);
            }
            else
                return null;
        }

        public RatingOutlook UpdateRatingOutlook(RatingOutlook pRatingOutlook)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingOutlookDOL DOL = new CORE.DOL.MSSQL.Financial.RatingOutlookDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRatingOutlook);
            }
            else
                return null;
        }

        public RatingOutlook DeleteRatingOutlook(RatingOutlook pRatingOutlook)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingOutlookDOL DOL = new CORE.DOL.MSSQL.Financial.RatingOutlookDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRatingOutlook);
            }
            else
                return null;
        }
        /**********************************************************************
         * Rating Term
         *********************************************************************/
        public RatingTerm GetRatingTerm(int pRatingTermID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRatingTermID, pLanguageID);
            }
            else
                return null;
        }

        public RatingTerm GetRatingTermForRating(int pRatingID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForRating(pRatingID, pLanguageID);
            }
            else
                return null;
        }

        public RatingTerm[] ListRatingTerms(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RatingTerm InsertRatingTerm(RatingTerm pRatingTerm)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRatingTerm);
            }
            else
                return null;
        }

        public RatingTerm UpdateRatingTerm(RatingTerm pRatingTerm)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRatingTerm);
            }
            else
                return null;
        }

        public RatingTerm DeleteRatingTerm(RatingTerm pRatingTerm)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RatingTermDOL DOL = new CORE.DOL.MSSQL.Financial.RatingTermDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRatingTerm);
            }
            else
                return null;
        }
        /**********************************************************************
         * Risk Bucket
         *********************************************************************/
        public RiskBucket GetRiskBucket(int pRiskBucketID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RiskBucketDOL DOL = new CORE.DOL.MSSQL.Financial.RiskBucketDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRiskBucketID, pLanguageID);
            }
            else
                return null;
        }

        public RiskBucket[] ListRiskBuckets(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RiskBucketDOL DOL = new CORE.DOL.MSSQL.Financial.RiskBucketDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RiskBucket InsertRiskBucket(RiskBucket pRiskBucket)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RiskBucketDOL DOL = new CORE.DOL.MSSQL.Financial.RiskBucketDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRiskBucket);
            }
            else
                return null;
        }

        public RiskBucket UpdateRiskBucket(RiskBucket pRiskBucket)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RiskBucketDOL DOL = new CORE.DOL.MSSQL.Financial.RiskBucketDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRiskBucket);
            }
            else
                return null;
        }

        public RiskBucket DeleteRiskBucket(RiskBucket pRiskBucket)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.RiskBucketDOL DOL = new CORE.DOL.MSSQL.Financial.RiskBucketDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRiskBucket);
            }
            else
                return null;
        }
        /**********************************************************************
         * ScoringElement
         *********************************************************************/
        public ScoringElement GetScoringElement(int pScoringElementID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pScoringElementID, pLanguageID);
            }
            else
                return null;
        }

        public ScoringElement GetScoringElementByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ScoringElement[] ListScoringElements(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ScoringElement InsertScoringElement(ScoringElement pScoringElement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pScoringElement);
            }
            else
                return null;
        }

        public ScoringElement UpdateScoringElement(ScoringElement pScoringElement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pScoringElement);
            }
            else
                return null;
        }

        public ScoringElement DeleteScoringElement(ScoringElement pScoringElement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pScoringElement);
            }
            else
                return null;
        }
        /**********************************************************************
         * ScoringElementConversion
         *********************************************************************/
        public ScoringElementConversion GetScoringElementConversion(int pScoringElementConversionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pScoringElementConversionID);
            }
            else
                return null;
        }

        public ScoringElementConversion[] ListScoringElementConversions(int pScoringElementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pScoringElementID);
            }
            else
                return null;
        }

        public ScoringElementConversion InsertScoringElementConversion(ScoringElementConversion pScoringElementConversion, int pScoringElementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pScoringElementConversion, pScoringElementID);
            }
            else
                return null;
        }

        public ScoringElementConversion UpdateScoringElementConversion(ScoringElementConversion pScoringElementConversion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pScoringElementConversion);
            }
            else
                return null;
        }

        public ScoringElementConversion DeleteScoringElementConversion(ScoringElementConversion pScoringElementConversion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementConversionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pScoringElementConversion);
            }
            else
                return null;
        }
        /**********************************************************************
         * ScoringElementScore
         *********************************************************************/
        public ScoringElementScore GetScoringElementScore(int pScoringElementScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pScoringElementScoreID);
            }
            else
                return null;
        }

        public ScoringElementScore[] ListScoringElementScores(int pInstitutionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionScoreID);
            }
            else
                return null;
        }

        public ScoringElementScore InsertScoringElementScore(ScoringElementScore pScoringElementScore, int pInstitutionScoreID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pScoringElementScore, pInstitutionScoreID);
            }
            else
                return null;
        }

        public ScoringElementScore UpdateScoringElementScore(ScoringElementScore pScoringElementScore)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pScoringElementScore);
            }
            else
                return null;
        }

        public ScoringElementScore DeleteScoringElementScore(ScoringElementScore pScoringElementScore)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL DOL = new CORE.DOL.MSSQL.Financial.ScoringElementScoreDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pScoringElementScore);
            }
            else
                return null;
        }
        /**********************************************************************
         * Shareholder
         *********************************************************************/
        public Shareholder GetShareholder(int pInstitutionID, int pShareholderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ShareholderDOL DOL = new CORE.DOL.MSSQL.Financial.ShareholderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstitutionID, pShareholderID);
            }
            else
                return null;
        }

        public Shareholder[] ListShareholders(int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ShareholderDOL DOL = new CORE.DOL.MSSQL.Financial.ShareholderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID);
            }
            else
                return null;
        }

        public Shareholder InsertShareholder(Shareholder pShareholder, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ShareholderDOL DOL = new CORE.DOL.MSSQL.Financial.ShareholderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShareholder, pInstitutionID);
            }
            else
                return null;
        }

        public Shareholder UpdateShareholder(Shareholder pShareholder, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ShareholderDOL DOL = new CORE.DOL.MSSQL.Financial.ShareholderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShareholder, pInstitutionID);
            }
            else
                return null;
        }

        public Shareholder DeleteShareholder(Shareholder pShareholder, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.ShareholderDOL DOL = new CORE.DOL.MSSQL.Financial.ShareholderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShareholder, pInstitutionID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Share Price
         *********************************************************************/
        public SharePrice GetSharePrice(int pSharePriceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSharePriceID);
            }
            else
                return null;
        }

        public SharePrice[] ListSharePrices(int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstitutionID);
            }
            else
                return null;
        }

        public SharePrice[] ListSharePrices(int pInstitutionID, DateTime pFromDate, DateTime pToDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByDateRange(pInstitutionID, pFromDate, pToDate);
            }
            else
                return null;
        }
        
        public SharePrice InsertSharePrice(SharePrice pSharePrice, int pInstitutionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSharePrice, pInstitutionID);
            }
            else
                return null;
        }

        public SharePrice UpdateSharePrice(SharePrice pSharePrice)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSharePrice);
            }
            else
                return null;
        }

        public SharePrice DeleteSharePrice(SharePrice pSharePrice)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.SharePriceDOL DOL = new CORE.DOL.MSSQL.Financial.SharePriceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSharePrice);
            }
            else
                return null;
        }
        /**********************************************************************
         * Statement
         *********************************************************************/
        public Statement GetStatement(int pStatementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementDOL DOL = new CORE.DOL.MSSQL.Financial.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStatementID);
            }
            else
                return null;
        }

        public Statement[] ListStatements(int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementDOL DOL = new CORE.DOL.MSSQL.Financial.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAccountID);
            }
            else
                return null;
        }

        public Statement InsertStatement(Statement pStatement, int pAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementDOL DOL = new CORE.DOL.MSSQL.Financial.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStatement, pAccountID);
            }
            else
                return null;
        }

        public Statement UpdateStatement(Statement pStatement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementDOL DOL = new CORE.DOL.MSSQL.Financial.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pStatement);
            }
            else
                return null;
        }

        public Statement DeleteStatement(Statement pStatement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementDOL DOL = new CORE.DOL.MSSQL.Financial.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStatement);
            }
            else
                return null;
        }
        /**********************************************************************
         * Statement Status
         *********************************************************************/
        public StatementStatus GetStatementStatus(int pStatementStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementStatusDOL DOL = new CORE.DOL.MSSQL.Financial.StatementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStatementStatusID, pLanguageID);
            }
            else
                return null;
        }

        public StatementStatus[] ListStatementStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementStatusDOL DOL = new CORE.DOL.MSSQL.Financial.StatementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public StatementStatus InsertStatementStatus(StatementStatus pStatementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementStatusDOL DOL = new CORE.DOL.MSSQL.Financial.StatementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStatementStatus);
            }
            else
                return null;
        }

        public StatementStatus UpdateStatementStatus(StatementStatus pStatementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementStatusDOL DOL = new CORE.DOL.MSSQL.Financial.StatementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pStatementStatus);
            }
            else
                return null;
        }

        public StatementStatus DeleteStatementStatus(StatementStatus pStatementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.StatementStatusDOL DOL = new CORE.DOL.MSSQL.Financial.StatementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStatementStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Transaction Status
         *********************************************************************/
        public TransactionStatus GetTransactionStatus(int pTransactionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTransactionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public TransactionStatus GetTransactionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TransactionStatus[] ListTransactionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TransactionStatus InsertTransactionStatus(TransactionStatus pTransactionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTransactionStatus);
            }
            else
                return null;
        }

        public TransactionStatus UpdateTransactionStatus(TransactionStatus pTransactionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTransactionStatus);
            }
            else
                return null;
        }

        public TransactionStatus DeleteTransactionStatus(TransactionStatus pTransactionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionStatusDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTransactionStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Transaction Type
         *********************************************************************/
        public TransactionType GetTransactionType(int pTransactionTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTransactionTypeID, pLanguageID);
            }
            else
                return null;
        }

        public TransactionType GetTransactionTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TransactionType[] ListTransactionTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TransactionType InsertTransactionType(TransactionType pTransactionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTransactionType);
            }
            else
                return null;
        }

        public TransactionType UpdateTransactionType(TransactionType pTransactionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTransactionType);
            }
            else
                return null;
        }

        public TransactionType DeleteTransactionType(TransactionType pTransactionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial.TransactionTypeDOL DOL = new CORE.DOL.MSSQL.Financial.TransactionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTransactionType);
            }
            else
                return null;
        }
    }
}
