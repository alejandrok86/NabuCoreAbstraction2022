using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class QuotationDOL : BaseDOL
    {
        public QuotationDOL() : base()
        {
        }

        public QuotationDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Quotation Get(int pQuotationID)
        {
            Quotation quotation = new Quotation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationID", pQuotationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotation = new Quotation(sqlDataReader.GetInt32(0));
                        quotation.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotation.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotation.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotation.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotation.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotation.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotation.Reference = sqlDataReader.GetString(7);
                        quotation.Status = new QuotationStatus(sqlDataReader.GetInt32(8));
                        quotation.Type = new QuotationType(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotation;
        }

        public Quotation GetByReference(string pReference)
        {
            Quotation quotation = new Quotation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_GetByReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotation = new Quotation(sqlDataReader.GetInt32(0));
                        quotation.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotation.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotation.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotation.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotation.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotation.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotation.Reference = sqlDataReader.GetString(7);
                        quotation.Status = new QuotationStatus(sqlDataReader.GetInt32(8));
                        quotation.Type = new QuotationType(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotation;
        }

        public Quotation[] List(int pClientID)
        {
            List<Quotation> quotations = new List<Quotation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Quotation quotation = new Quotation(sqlDataReader.GetInt32(0));
                        quotation.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotation.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotation.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotation.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotation.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotation.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotation.Reference = sqlDataReader.GetString(7);
                        quotation.Status = new QuotationStatus(sqlDataReader.GetInt32(8));
                        quotation.Type = new QuotationType(sqlDataReader.GetInt32(9));

                        quotations.Add(quotation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Quotation quotation = new Quotation();
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    quotations.Add(quotation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotations.ToArray();
        }

        public Quotation[] ListByStatus(int pClientID, int pQuotationStatusID)
        {
            List<Quotation> quotations = new List<Quotation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_ListByStatus]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationStatusID", pQuotationStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Quotation quotation = new Quotation(sqlDataReader.GetInt32(0));
                        quotation.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotation.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotation.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotation.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotation.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotation.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotation.Reference = sqlDataReader.GetString(7);
                        quotation.Status = new QuotationStatus(sqlDataReader.GetInt32(8));
                        quotation.Type = new QuotationType(sqlDataReader.GetInt32(9));

                        quotations.Add(quotation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Quotation quotation = new Quotation();
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    quotations.Add(quotation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotations.ToArray();
        }

        public Quotation Insert(Quotation pQuotation)
        {
            Quotation quotation = new Quotation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pQuotation.Client.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", ((pQuotation.Account != null && pQuotation.Account.AccountID.HasValue) ? pQuotation.Account.AccountID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfIssue", pQuotation.DateOfIssue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfExpiration", pQuotation.DateOfExpiration));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pQuotation.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Total", pQuotation.Total));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pQuotation.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationStatusID", pQuotation.Status.QuotationStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationTypeID", pQuotation.Type.QuotationTypeID));
                    SqlParameter quotationID = sqlCommand.Parameters.Add("@QuotationID", SqlDbType.Int);
                    quotationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    quotation = pQuotation;
                    quotation.QuotationID = (Int32)quotationID.Value;
                }
                catch (Exception exc)
                {
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotation;
        }

        public Quotation Update(Quotation pQuotation)
        {
            Quotation quotation = new Quotation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationID", pQuotation.QuotationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pQuotation.Client.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", ((pQuotation.Account != null && pQuotation.Account.AccountID.HasValue) ? pQuotation.Account.AccountID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfIssue", pQuotation.DateOfIssue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfExpiration", pQuotation.DateOfExpiration));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pQuotation.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Total", pQuotation.Total));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pQuotation.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationStatusID", pQuotation.Status.QuotationStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationTypeID", pQuotation.Type.QuotationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    quotation = pQuotation;
                }
                catch (Exception exc)
                {
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotation;
        }

        public Quotation Delete(Quotation pQuotation)
        {
            Quotation quotation = new Quotation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Quotation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationID", pQuotation.QuotationID));

                    sqlCommand.ExecuteNonQuery();

                    quotation = new Quotation(pQuotation.QuotationID);
                }
                catch (Exception exc)
                {
                    quotation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotation;
        }
    }
}
