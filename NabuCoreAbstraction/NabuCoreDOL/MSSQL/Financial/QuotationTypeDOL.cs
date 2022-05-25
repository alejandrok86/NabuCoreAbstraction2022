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
    public class QuotationTypeDOL : BaseDOL
    {
        public QuotationTypeDOL() : base()
        {
        }

        public QuotationTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public QuotationType Get(int pQuotationTypeID, int pLanguageID)
        {
            QuotationType quotationType = new QuotationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationTypeID", pQuotationTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotationType = new QuotationType(sqlDataReader.GetInt32(0));
                        quotationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationType;
        }

        public QuotationType GetByAlias(string pAlias, int pLanguageID)
        {
            QuotationType quotationType = new QuotationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotationType = new QuotationType(sqlDataReader.GetInt32(0));
                        quotationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationType;
        }

        public QuotationType[] List(int pLanguageID)
        {
            List<QuotationType> quotationTypes = new List<QuotationType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        QuotationType quotationType = new QuotationType(sqlDataReader.GetInt32(0));
                        quotationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        quotationTypes.Add(quotationType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    QuotationType quotationType = new QuotationType();
                    quotationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    quotationTypes.Add(quotationType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationTypes.ToArray();
        }

        public QuotationType Insert(QuotationType pQuotationType)
        {
            QuotationType quotationType = new QuotationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationType_Insert]");
                try
                {
                    pQuotationType.Detail = base.InsertTranslation(pQuotationType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pQuotationType.Detail.TranslationID));
                    SqlParameter quotationTypeID = sqlCommand.Parameters.Add("@QuotationTypeID", SqlDbType.Int);
                    quotationTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    quotationType = new QuotationType((Int32)quotationTypeID.Value);
                    quotationType.Detail = new Translation(pQuotationType.Detail.TranslationID);
                    quotationType.Detail.Alias = pQuotationType.Detail.Alias;
                    quotationType.Detail.Description = pQuotationType.Detail.Description;
                    quotationType.Detail.Name = pQuotationType.Detail.Name;
                }
                catch (Exception exc)
                {
                    quotationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationType;
        }

        public QuotationType Update(QuotationType pQuotationType)
        {
            QuotationType quotationType = new QuotationType();

            pQuotationType.Detail = base.UpdateTranslation(pQuotationType.Detail);

            quotationType = new QuotationType(pQuotationType.QuotationTypeID);
            quotationType.Detail = new Translation(pQuotationType.Detail.TranslationID);
            quotationType.Detail.Alias = pQuotationType.Detail.Alias;
            quotationType.Detail.Description = pQuotationType.Detail.Description;
            quotationType.Detail.Name = pQuotationType.Detail.Name;

            return quotationType;
        }

        public QuotationType Delete(QuotationType pQuotationType)
        {
            QuotationType quotationType = new QuotationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationTypeID", pQuotationType.QuotationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    quotationType = new QuotationType(pQuotationType.QuotationTypeID);
                    base.DeleteAllTranslations(pQuotationType.Detail);
                }
                catch (Exception exc)
                {
                    quotationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationType;
        }
    }
}
