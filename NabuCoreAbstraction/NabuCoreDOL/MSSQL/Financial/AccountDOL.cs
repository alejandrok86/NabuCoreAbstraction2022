using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountDOL : BaseDOL
    {
        public AccountDOL() : base()
        {
        }

        public AccountDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Account Get(int pAccountID)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account GetByAccountNumber(string pAccountNumber)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_GetByAccountNumber]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountNumber", pAccountNumber));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account GetByAccountReference(string pAccountReference)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_GetByAccountReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountReference", pAccountReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account GetParent(int pChildAccountID)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_GetParent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChildAccountID", pChildAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account[] List(int pClientID, int pAccountTypeID, int? pParentAccountID)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountID", pParentAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Account account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);

                        accounts.Add(account);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Account account = new Account();
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    account.StackTrace = exc.StackTrace;
                    accounts.Add(account);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accounts.ToArray();
        }

        public Account[] List(int pClientID, int pAccountTypeID)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_ListByType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Account account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);

                        accounts.Add(account);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Account account = new Account();
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accounts.Add(account);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accounts.ToArray();
        }

        public Account[] List(int pClientID, string pAccountTypeAliasLike)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_ListByTypeWhereAliasLike]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeLike", pAccountTypeAliasLike));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Account account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);

                        accounts.Add(account);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Account account = new Account();
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accounts.Add(account);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accounts.ToArray();
        }

        public Account[] ListChildren(int pParentAccountID)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountID", pParentAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Account account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);

                        accounts.Add(account);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Account account = new Account();
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accounts.Add(account);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accounts.ToArray();
        }

        public Account[] ListAll(int pClientID)
        {
            List<Account> accounts = new List<Account>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_ListAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Account account = new Account(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            account.Branch = new Branch(sqlDataReader.GetInt32(1));
                        account.Currency = new Currency(sqlDataReader.GetInt32(2));
                        account.Type = new AccountType(sqlDataReader.GetInt32(3));
                        account.Type.Detail = new Entities.Globalisation.Translation();
                        account.Type.Detail.Alias = sqlDataReader.GetString(4);
                        account.Status = new AccountStatus(sqlDataReader.GetInt32(5));
                        account.Status.Detail = new Entities.Globalisation.Translation();
                        account.Status.Detail.Alias = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            account.Name = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            account.Number = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            account.Reference = sqlDataReader.GetString(9);
                        account.IsOffShore = sqlDataReader.GetBoolean(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            account.IBAN = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            account.SWIFTBIC = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            account.Balance = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            account.BalanceDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            account.LinkedAccountID = sqlDataReader.GetInt32(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            account.Rate = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            account.DateOpened = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            account.DateClosed = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            account.ParentAccountID = sqlDataReader.GetInt32(19);

                        accounts.Add(account);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Account account = new Account();
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accounts.Add(account);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accounts.ToArray();
        }

        public Account Insert(Account pAccount, int pClientID, int? pParentAccountID)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BranchID", ((pAccount.Branch != null && pAccount.Branch.PartyID.HasValue) ? pAccount.Branch.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pAccount.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccount.Type.AccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountStatusID", pAccount.Status.AccountStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountName", pAccount.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountNumber", pAccount.Number));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountReference", pAccount.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsOffShore", pAccount.IsOffShore));
                    sqlCommand.Parameters.Add(new SqlParameter("@IBAN", pAccount.IBAN));
                    sqlCommand.Parameters.Add(new SqlParameter("@SWIFTBIC", pAccount.SWIFTBIC));
                    sqlCommand.Parameters.Add(new SqlParameter("@Balance", pAccount.Balance));
                    sqlCommand.Parameters.Add(new SqlParameter("@BalanceDate", pAccount.BalanceDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountID", pParentAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkedAccountID", pAccount.LinkedAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rate", pAccount.Rate));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOpened", pAccount.DateOpened));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateClosed", pAccount.DateClosed));
                    SqlParameter accountID = sqlCommand.Parameters.Add("@AccountID", SqlDbType.Int);
                    accountID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    account = new Account((Int32)accountID.Value);
                    account.Branch = pAccount.Branch;
                    account.Currency = pAccount.Currency;
                    account.Type = pAccount.Type;
                    account.Status = pAccount.Status;
                    account.Name = pAccount.Name;
                    account.Number = pAccount.Number;
                    account.Reference = pAccount.Reference;
                    account.IsOffShore = pAccount.IsOffShore;
                    account.IBAN = pAccount.IBAN;
                    account.SWIFTBIC = pAccount.SWIFTBIC;
                    account.Balance = pAccount.Balance;
                    account.BalanceDate = pAccount.BalanceDate;
                    account.LinkedAccountID = pAccount.LinkedAccountID;
                    account.Rate = pAccount.Rate;
                    account.DateOpened = pAccount.DateOpened;
                    account.DateClosed = pAccount.DateClosed;
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account Update(Account pAccount)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccount.AccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BranchID", ((pAccount.Branch != null && pAccount.Branch.PartyID.HasValue) ? pAccount.Branch.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pAccount.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccount.Type.AccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountStatusID", pAccount.Status.AccountStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountName", pAccount.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountNumber", pAccount.Number));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountReference", pAccount.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsOffShore", pAccount.IsOffShore));
                    sqlCommand.Parameters.Add(new SqlParameter("@IBAN", pAccount.IBAN));
                    sqlCommand.Parameters.Add(new SqlParameter("@SWIFTBIC", pAccount.SWIFTBIC));
                    sqlCommand.Parameters.Add(new SqlParameter("@Balance", pAccount.Balance));
                    sqlCommand.Parameters.Add(new SqlParameter("@BalanceDate", pAccount.BalanceDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkedAccountID", pAccount.LinkedAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rate", pAccount.Rate));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOpened", pAccount.DateOpened));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateClosed", pAccount.DateClosed));

                    sqlCommand.ExecuteNonQuery();

                    account = new Account(pAccount.AccountID);
                    account.Branch = pAccount.Branch;
                    account.Currency = pAccount.Currency;
                    account.Type = pAccount.Type;
                    account.Status = pAccount.Status;
                    account.Name = pAccount.Name;
                    account.Number = pAccount.Number;
                    account.Reference = pAccount.Reference;
                    account.IsOffShore = pAccount.IsOffShore;
                    account.IBAN = pAccount.IBAN;
                    account.SWIFTBIC = pAccount.SWIFTBIC;
                    account.Balance = pAccount.Balance;
                    account.BalanceDate = pAccount.BalanceDate;
                    account.LinkedAccountID = pAccount.LinkedAccountID;
                    account.Rate = pAccount.Rate;
                    account.DateOpened = pAccount.DateOpened;
                    account.DateClosed = pAccount.DateClosed;
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.ToString(), false);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "AccountID: " + pAccount.AccountID, false);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace.ToString());
                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }

        public Account Delete(Account pAccount)
        {
            Account account = new Account();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Account_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccount.AccountID));

                    sqlCommand.ExecuteNonQuery();

                    account = new Account(pAccount.AccountID);
                }
                catch (Exception exc)
                {
                    account.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    account.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return account;
        }
    }
}
