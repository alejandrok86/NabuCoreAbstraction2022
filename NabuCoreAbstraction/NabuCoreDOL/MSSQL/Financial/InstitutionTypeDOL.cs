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
    public class InstitutionTypeDOL : BaseDOL
    {
        public InstitutionTypeDOL() : base()
        {
        }

        public InstitutionTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionType Get(int pInstitutionTypeID, int pLanguageID)
        {
            InstitutionType institutionType = new InstitutionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionTypeID", pInstitutionTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionType = new InstitutionType(sqlDataReader.GetInt32(0));
                        institutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionType;
        }

        public InstitutionType GetByAlias(string pAlias, int pLanguageID)
        {
            InstitutionType institutionType = new InstitutionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionType = new InstitutionType(sqlDataReader.GetInt32(0));
                        institutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionType;
        }
       
        public InstitutionType[] List(int pLanguageID)
        {
            List<InstitutionType> institutionTypes = new List<InstitutionType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionType institutionType = new InstitutionType(sqlDataReader.GetInt32(0));
                        institutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        institutionTypes.Add(institutionType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionType institutionType = new InstitutionType();
                    institutionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionTypes.Add(institutionType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTypes.ToArray();
        }

        public InstitutionType Insert(InstitutionType pInstitutionType)
        {
            InstitutionType institutionType = new InstitutionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionType_Insert]");
                try
                {
                    pInstitutionType.Detail = base.InsertTranslation(pInstitutionType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstitutionType.Detail.TranslationID));
                    SqlParameter institutionTypeID = sqlCommand.Parameters.Add("@InstitutionTypeID", SqlDbType.Int);
                    institutionTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    institutionType = new InstitutionType((Int32)institutionTypeID.Value);
                    institutionType.Detail = new Translation(pInstitutionType.Detail.TranslationID);
                    institutionType.Detail.Alias = pInstitutionType.Detail.Alias;
                    institutionType.Detail.Description = pInstitutionType.Detail.Description;
                    institutionType.Detail.Name = pInstitutionType.Detail.Name;
                }
                catch (Exception exc)
                {
                    institutionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionType;
        }

        public InstitutionType Update(InstitutionType pInstitutionType)
        {
            InstitutionType institutionType = new InstitutionType();

            pInstitutionType.Detail = base.UpdateTranslation(pInstitutionType.Detail);

            institutionType = new InstitutionType(pInstitutionType.InstitutionTypeID);
            institutionType.Detail = new Translation(pInstitutionType.Detail.TranslationID);
            institutionType.Detail.Alias = pInstitutionType.Detail.Alias;
            institutionType.Detail.Description = pInstitutionType.Detail.Description;
            institutionType.Detail.Name = pInstitutionType.Detail.Name;

            return institutionType;
        }

        public InstitutionType Delete(InstitutionType pInstitutionType)
        {
            InstitutionType institutionType = new InstitutionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionTypeID", pInstitutionType.InstitutionTypeID));

                    sqlCommand.ExecuteNonQuery();

                    institutionType = new InstitutionType(pInstitutionType.InstitutionTypeID);
                    base.DeleteAllTranslations(pInstitutionType.Detail);
                }
                catch (Exception exc)
                {
                    institutionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionType;
        }
    }
}
