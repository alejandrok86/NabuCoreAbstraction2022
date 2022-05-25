using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ChangeTypeDOL : BaseDOL
    {
        public ChangeTypeDOL() : base()
        {
        }

        public ChangeTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType Get(int pChangeTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeTypeID", pChangeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(0));
                        changeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(0));
                        changeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType> changeTypes = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(0));
                        changeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        changeTypes.Add(changeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();
                    changeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    changeTypes.Add(changeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType pChangeType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeType_Insert]");
                try
                {
                    pChangeType.Detail = base.InsertTranslation(pChangeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pChangeType.Detail.TranslationID));
                    SqlParameter changeTypeID = sqlCommand.Parameters.Add("@ChangeTypeID", SqlDbType.Int);
                    changeTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType((Int32)changeTypeID.Value);
                    changeType.Detail = new Translation(pChangeType.Detail.TranslationID);
                    changeType.Detail.Alias = pChangeType.Detail.Alias;
                    changeType.Detail.Description = pChangeType.Detail.Description;
                    changeType.Detail.Name = pChangeType.Detail.Name;
                }
                catch (Exception exc)
                {
                    changeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType pChangeType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();

            pChangeType.Detail = base.UpdateTranslation(pChangeType.Detail);

            changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType(pChangeType.ChangeTypeID);
            changeType.Detail = new Translation(pChangeType.Detail.TranslationID);
            changeType.Detail.Alias = pChangeType.Detail.Alias;
            changeType.Detail.Description = pChangeType.Detail.Description;
            changeType.Detail.Name = pChangeType.Detail.Name;

            return changeType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType pChangeType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeTypeID", pChangeType.ChangeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    changeType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeType(pChangeType.ChangeTypeID);
                    base.DeleteAllTranslations(pChangeType.Detail);
                }
                catch (Exception exc)
                {
                    changeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeType;
        }
    }
}

