using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class QuotationStatusDOL : BaseDOL
    {
        public QuotationStatusDOL() : base()
        {
        }

        public QuotationStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public QuotationStatus Get(int pQuotationStatusID, int pLanguageID)
        {
            QuotationStatus quotationStatus = new QuotationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationStatusID", pQuotationStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotationStatus = new QuotationStatus(sqlDataReader.GetInt32(0));
                        quotationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationStatus;
        }

        public QuotationStatus GetByAlias(string pAlias, int pLanguageID)
        {
            QuotationStatus quotationStatus = new QuotationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotationStatus = new QuotationStatus(sqlDataReader.GetInt32(0));
                        quotationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationStatus;
        }

        public QuotationStatus[] List(int pLanguageID)
        {
            List<QuotationStatus> quotationStatuss = new List<QuotationStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        QuotationStatus quotationStatus = new QuotationStatus(sqlDataReader.GetInt32(0));
                        quotationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        quotationStatuss.Add(quotationStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    QuotationStatus quotationStatus = new QuotationStatus();
                    quotationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    quotationStatuss.Add(quotationStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationStatuss.ToArray();
        }

        public QuotationStatus Insert(QuotationStatus pQuotationStatus)
        {
            QuotationStatus quotationStatus = new QuotationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationStatus_Insert]");
                try
                {
                    pQuotationStatus.Detail = base.InsertTranslation(pQuotationStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pQuotationStatus.Detail.TranslationID));
                    SqlParameter quotationStatusID = sqlCommand.Parameters.Add("@QuotationStatusID", SqlDbType.Int);
                    quotationStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    quotationStatus = new QuotationStatus((Int32)quotationStatusID.Value);
                    quotationStatus.Detail = new Translation(pQuotationStatus.Detail.TranslationID);
                    quotationStatus.Detail.Alias = pQuotationStatus.Detail.Alias;
                    quotationStatus.Detail.Description = pQuotationStatus.Detail.Description;
                    quotationStatus.Detail.Name = pQuotationStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    quotationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationStatus;
        }

        public QuotationStatus Update(QuotationStatus pQuotationStatus)
        {
            QuotationStatus quotationStatus = new QuotationStatus();

            pQuotationStatus.Detail = base.UpdateTranslation(pQuotationStatus.Detail);

            quotationStatus = new QuotationStatus(pQuotationStatus.QuotationStatusID);
            quotationStatus.Detail = new Translation(pQuotationStatus.Detail.TranslationID);
            quotationStatus.Detail.Alias = pQuotationStatus.Detail.Alias;
            quotationStatus.Detail.Description = pQuotationStatus.Detail.Description;
            quotationStatus.Detail.Name = pQuotationStatus.Detail.Name;

            return quotationStatus;
        }

        public QuotationStatus Delete(QuotationStatus pQuotationStatus)
        {
            QuotationStatus quotationStatus = new QuotationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationStatusID", pQuotationStatus.QuotationStatusID));

                    sqlCommand.ExecuteNonQuery();

                    quotationStatus = new QuotationStatus(pQuotationStatus.QuotationStatusID);
                    base.DeleteAllTranslations(pQuotationStatus.Detail);
                }
                catch (Exception exc)
                {
                    quotationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationStatus;
        }
    }
}
