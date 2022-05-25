using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class CurrencyDOL : BaseDOL
    {
        public CurrencyDOL() : base()
        {
        }

        public CurrencyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Currency Get(int pCurrencyID)
        {
            Currency currency = new Currency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pCurrencyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        currency = new Currency(sqlDataReader.GetInt32(0));
                        currency.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(1));
                        currency.CurrencyName = sqlDataReader.GetString(2);
                        currency.CurrencyCode = sqlDataReader.GetString(3);
                        currency.UnicodeDecimalCharacters = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currency;
        }

        public Currency GetByCode(string pCurrencyCode)
        {
            Currency currency = new Currency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_GetByCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyCode", pCurrencyCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        currency = new Currency(sqlDataReader.GetInt32(0));
                        currency.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(1));
                        currency.CurrencyName = sqlDataReader.GetString(2);
                        currency.CurrencyCode = sqlDataReader.GetString(3);
                        currency.UnicodeDecimalCharacters = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currency;
        }

        public Currency[] List()
        {
            List<Currency> currencys = new List<Currency>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Currency currency = new Currency(sqlDataReader.GetInt32(0));
                        currency.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(1));
                        currency.CurrencyName = sqlDataReader.GetString(2);
                        currency.CurrencyCode = sqlDataReader.GetString(3);
                        currency.UnicodeDecimalCharacters = sqlDataReader.GetString(4);

                        currencys.Add(currency);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Currency currency = new Currency();
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    currencys.Add(currency);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currencys.ToArray();
        }

        public Currency Insert(Currency pCurrency)
        {
            Currency currency = new Currency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCurrency.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyName", pCurrency.CurrencyName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyCode", pCurrency.CurrencyCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnicodeDecimalCharacters", pCurrency.UnicodeDecimalCharacters));
                    SqlParameter institutionTypeID = sqlCommand.Parameters.Add("@CurrencyID", SqlDbType.Int);
                    institutionTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    currency = new Currency((Int32)institutionTypeID.Value);
                    currency.Country = new Entities.Globalisation.Country(pCurrency.Country.CountryID);
                    currency.CurrencyName = pCurrency.CurrencyName;
                    currency.CurrencyCode = pCurrency.CurrencyCode;
                    currency.UnicodeDecimalCharacters = pCurrency.UnicodeDecimalCharacters;
                }
                catch (Exception exc)
                {
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currency;
        }

        public Currency Update(Currency pCurrency)
        {
            Currency currency = new Currency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pCurrency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCurrency.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyName", pCurrency.CurrencyName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyCode", pCurrency.CurrencyCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnicodeDecimalCharacters", pCurrency.UnicodeDecimalCharacters));

                    sqlCommand.ExecuteNonQuery();

                    currency = new Currency(pCurrency.CurrencyID);
                    currency.Country = new Entities.Globalisation.Country(pCurrency.Country.CountryID);
                    currency.CurrencyName = pCurrency.CurrencyName;
                    currency.CurrencyCode = pCurrency.CurrencyCode;
                    currency.UnicodeDecimalCharacters = pCurrency.UnicodeDecimalCharacters;
                }
                catch (Exception exc)
                {
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currency;
        }

        public Currency Delete(Currency pCurrency)
        {
            Currency currency = new Currency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Currency_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pCurrency.CurrencyID));

                    sqlCommand.ExecuteNonQuery();

                    currency = new Currency(pCurrency.CurrencyID);
                }
                catch (Exception exc)
                {
                    currency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    currency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return currency;
        }
    }
}
