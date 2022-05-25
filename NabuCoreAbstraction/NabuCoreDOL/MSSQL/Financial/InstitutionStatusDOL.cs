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
    public class InstitutionStatusDOL : BaseDOL
    {
        public InstitutionStatusDOL() : base()
        {
        }

        public InstitutionStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionStatus Get(int pInstitutionStatusID, int pLanguageID)
        {
            InstitutionStatus institutionStatus = new InstitutionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionStatusID", pInstitutionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(0));
                        institutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionStatus;
        }

        public InstitutionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            InstitutionStatus institutionStatus = new InstitutionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(0));
                        institutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionStatus;
        }

        public InstitutionStatus[] List(int pLanguageID)
        {
            List<InstitutionStatus> institutionStatuss = new List<InstitutionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionStatus institutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(0));
                        institutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        institutionStatuss.Add(institutionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionStatus institutionStatus = new InstitutionStatus();
                    institutionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionStatuss.Add(institutionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionStatuss.ToArray();
        }

        public InstitutionStatus Insert(InstitutionStatus pInstitutionStatus)
        {
            InstitutionStatus institutionStatus = new InstitutionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionStatus_Insert]");
                try
                {
                    pInstitutionStatus.Detail = base.InsertTranslation(pInstitutionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstitutionStatus.Detail.TranslationID));
                    SqlParameter institutionStatusID = sqlCommand.Parameters.Add("@InstitutionStatusID", SqlDbType.Int);
                    institutionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    institutionStatus = new InstitutionStatus((Int32)institutionStatusID.Value);
                    institutionStatus.Detail = new Translation(pInstitutionStatus.Detail.TranslationID);
                    institutionStatus.Detail.Alias = pInstitutionStatus.Detail.Alias;
                    institutionStatus.Detail.Description = pInstitutionStatus.Detail.Description;
                    institutionStatus.Detail.Name = pInstitutionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    institutionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionStatus;
        }

        public InstitutionStatus Update(InstitutionStatus pInstitutionStatus)
        {
            InstitutionStatus institutionStatus = new InstitutionStatus();

            pInstitutionStatus.Detail = base.UpdateTranslation(pInstitutionStatus.Detail);

            institutionStatus = new InstitutionStatus(pInstitutionStatus.InstitutionStatusID);
            institutionStatus.Detail = new Translation(pInstitutionStatus.Detail.TranslationID);
            institutionStatus.Detail.Alias = pInstitutionStatus.Detail.Alias;
            institutionStatus.Detail.Description = pInstitutionStatus.Detail.Description;
            institutionStatus.Detail.Name = pInstitutionStatus.Detail.Name;

            return institutionStatus;
        }

        public InstitutionStatus Delete(InstitutionStatus pInstitutionStatus)
        {
            InstitutionStatus institutionStatus = new InstitutionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionStatusID", pInstitutionStatus.InstitutionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    institutionStatus = new InstitutionStatus(pInstitutionStatus.InstitutionStatusID);
                    base.DeleteAllTranslations(pInstitutionStatus.Detail);
                }
                catch (Exception exc)
                {
                    institutionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionStatus;
        }
    }
}
