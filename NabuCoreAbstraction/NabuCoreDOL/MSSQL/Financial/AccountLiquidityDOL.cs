using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountLiquidityDOL : BaseDOL
    {
        public AccountLiquidityDOL() : base()
        {
        }

        public AccountLiquidityDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountLiquidity Get(int pAccountLiquidityID, int pLanguageID)
        {
            AccountLiquidity accountLiquidity = new AccountLiquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountLiquidity_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountLiquidityID", pAccountLiquidityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountLiquidity = new AccountLiquidity(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                        {
                            accountLiquidity.Liquidity = new Liquidity(sqlDataReader.GetInt32(1));
                            if (sqlDataReader.IsDBNull(2) == false)
                                accountLiquidity.Liquidity.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                            if (sqlDataReader.IsDBNull(3) == false)
                                accountLiquidity.Liquidity.Days = sqlDataReader.GetInt32(3);
                        }
                        if(sqlDataReader.IsDBNull(4)==false)
                            accountLiquidity.Amount = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountLiquidity.Rolling = sqlDataReader.GetBoolean(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountLiquidity.SpecificDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountLiquidity.OtherDuration = sqlDataReader.GetInt32(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountLiquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountLiquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountLiquidity;
        }

        public AccountLiquidity[] List(int pAccountID, int pLanguageID)
        {
            List<AccountLiquidity> accountLiquiditys = new List<AccountLiquidity>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountLiquidity_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountLiquidity accountLiquidity = new AccountLiquidity(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                        {
                            accountLiquidity.Liquidity = new Liquidity(sqlDataReader.GetInt32(1));
                            if (sqlDataReader.IsDBNull(2) == false)
                                accountLiquidity.Liquidity.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                            if (sqlDataReader.IsDBNull(3) == false)
                                accountLiquidity.Liquidity.Days = sqlDataReader.GetInt32(3);
                        }
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountLiquidity.Amount = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountLiquidity.Rolling = sqlDataReader.GetBoolean(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountLiquidity.SpecificDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountLiquidity.OtherDuration = sqlDataReader.GetInt32(7);

                        accountLiquiditys.Add(accountLiquidity);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountLiquidity accountLiquidity = new AccountLiquidity();
                    accountLiquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountLiquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountLiquiditys.Add(accountLiquidity);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountLiquiditys.ToArray();
        }

        public AccountLiquidity Insert(AccountLiquidity pAccountLiquidity, int pAccountID)
        {
            AccountLiquidity accountLiquidity = new AccountLiquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountLiquidity_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityID", pAccountLiquidity.Liquidity.LiquidityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", ((pAccountLiquidity.Amount.HasValue) ? pAccountLiquidity.Amount : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rolling", ((pAccountLiquidity.Rolling.HasValue) ? pAccountLiquidity.Rolling : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificDate", ((pAccountLiquidity.SpecificDate.HasValue) ? pAccountLiquidity.SpecificDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@OtherDuration", ((pAccountLiquidity.OtherDuration.HasValue) ? pAccountLiquidity.OtherDuration : null)));
                    SqlParameter accountLiquidityID = sqlCommand.Parameters.Add("@AccountLiquidityID", SqlDbType.Int);
                    accountLiquidityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountLiquidity = new AccountLiquidity((Int32)accountLiquidityID.Value);
                    accountLiquidity.Amount = pAccountLiquidity.Amount;
                    accountLiquidity.Liquidity = pAccountLiquidity.Liquidity;
                    accountLiquidity.Rolling = pAccountLiquidity.Rolling;
                    accountLiquidity.SpecificDate = pAccountLiquidity.SpecificDate;
                    accountLiquidity.OtherDuration = pAccountLiquidity.OtherDuration;
                }
                catch (Exception exc)
                {
                    accountLiquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountLiquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountLiquidity;
        }

        public AccountLiquidity Update(AccountLiquidity pAccountLiquidity)
        {
            AccountLiquidity accountLiquidity = new AccountLiquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountLiquidity_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountLiquidityID", pAccountLiquidity.AccountLiquidityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityID", pAccountLiquidity.Liquidity.LiquidityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", ((pAccountLiquidity.Amount.HasValue) ? pAccountLiquidity.Amount : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rolling", ((pAccountLiquidity.Rolling.HasValue) ? pAccountLiquidity.Rolling : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificDate", ((pAccountLiquidity.SpecificDate.HasValue) ? pAccountLiquidity.SpecificDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@OtherDuration", ((pAccountLiquidity.OtherDuration.HasValue) ? pAccountLiquidity.OtherDuration : null)));

                    sqlCommand.ExecuteNonQuery();

                    accountLiquidity = new AccountLiquidity(pAccountLiquidity.AccountLiquidityID);
                    accountLiquidity.Amount = pAccountLiquidity.Amount;
                    accountLiquidity.Liquidity = pAccountLiquidity.Liquidity;
                    accountLiquidity.Rolling = pAccountLiquidity.Rolling;
                    accountLiquidity.SpecificDate = pAccountLiquidity.SpecificDate;
                    accountLiquidity.OtherDuration = pAccountLiquidity.OtherDuration;
                }
                catch (Exception exc)
                {
                    accountLiquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountLiquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountLiquidity;
        }

        public AccountLiquidity Delete(AccountLiquidity pAccountLiquidity)
        {
            AccountLiquidity accountLiquidity = new AccountLiquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountLiquidity_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountLiquidityID", pAccountLiquidity.AccountLiquidityID));

                    sqlCommand.ExecuteNonQuery();

                    accountLiquidity = new AccountLiquidity(pAccountLiquidity.AccountLiquidityID);
                }
                catch (Exception exc)
                {
                    accountLiquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountLiquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountLiquidity;
        }
    }
}
