using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class SharePriceDOL : BaseDOL
    {
        public SharePriceDOL() : base()
        {
        }

        public SharePriceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SharePrice Get(int pSharePriceID)
        {
            SharePrice sharePrice = new SharePrice();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SharePriceID", pSharePriceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        sharePrice = new SharePrice(sqlDataReader.GetInt32(0));
                        sharePrice.PriceDate = sqlDataReader.GetDateTime(1);
                        sharePrice.Currency = new Currency(sqlDataReader.GetInt32(2));
                        sharePrice.Price = sqlDataReader.GetDecimal(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrice;
        }

        public SharePrice[] List(int pInstitutionID)
        {
            List<SharePrice> sharePrices = new List<SharePrice>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SharePrice sharePrice = new SharePrice(sqlDataReader.GetInt32(0));
                        sharePrice.PriceDate = sqlDataReader.GetDateTime(1);
                        sharePrice.Currency = new Currency(sqlDataReader.GetInt32(2));
                        sharePrice.Price = sqlDataReader.GetDecimal(3);
                        sharePrices.Add(sharePrice);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SharePrice sharePrice = new SharePrice();
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    sharePrices.Add(sharePrice);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrices.ToArray();
        }

        public SharePrice[] ListByDateRange(int pInstitutionID, DateTime pFromDate, DateTime pToDate)
        {
            List<SharePrice> sharePrices = new List<SharePrice>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_ListByDateRange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SharePrice sharePrice = new SharePrice(sqlDataReader.GetInt32(0));
                        sharePrice.PriceDate = sqlDataReader.GetDateTime(1);
                        sharePrice.Currency = new Currency(sqlDataReader.GetInt32(2));
                        sharePrice.Price = sqlDataReader.GetDecimal(3);
                        sharePrices.Add(sharePrice);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SharePrice sharePrice = new SharePrice();
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    sharePrices.Add(sharePrice);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrices.ToArray();
        }

        public SharePrice Insert(SharePrice pSharePrice, int pInstitutionID)
        {
            SharePrice sharePrice = new SharePrice();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PriceDate", pSharePrice.PriceDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pSharePrice.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Price", pSharePrice.Price));
                    SqlParameter sharePriceID = sqlCommand.Parameters.Add("@SharePriceID", SqlDbType.Int);
                    sharePriceID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    sharePrice = new SharePrice((Int32)sharePriceID.Value);
                    sharePrice.PriceDate = pSharePrice.PriceDate;
                    sharePrice.Currency = pSharePrice.Currency;
                    sharePrice.Price = pSharePrice.Price;
                }
                catch (Exception exc)
                {
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrice;
        }

        public SharePrice Update(SharePrice pSharePrice)
        {
            SharePrice sharePrice = new SharePrice();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SharePriceID", pSharePrice.SharePriceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PriceDate", pSharePrice.PriceDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pSharePrice.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Price", pSharePrice.Price));

                    sqlCommand.ExecuteNonQuery();

                    sharePrice = new SharePrice(pSharePrice.SharePriceID);
                    sharePrice.PriceDate = pSharePrice.PriceDate;
                    sharePrice.Currency = pSharePrice.Currency;
                    sharePrice.Price = pSharePrice.Price;
                }
                catch (Exception exc)
                {
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrice;
        }

        public SharePrice Delete(SharePrice pSharePrice)
        {
            SharePrice sharePrice = new SharePrice();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[SharePrice_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SharePriceID", pSharePrice.SharePriceID));

                    sqlCommand.ExecuteNonQuery();

                    sharePrice = new SharePrice(pSharePrice.SharePriceID);
                }
                catch (Exception exc)
                {
                    sharePrice.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sharePrice.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sharePrice;
        }
    }
}
