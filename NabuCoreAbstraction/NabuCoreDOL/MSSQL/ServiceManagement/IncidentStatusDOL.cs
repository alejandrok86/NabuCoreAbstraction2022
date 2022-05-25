using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentStatusDOL : BaseDOL
    {
        public IncidentStatusDOL() : base()
        {
        }

        public IncidentStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus Get(int pIncidentStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentStatusID", pIncidentStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(0));
                        incidentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(0));
                        incidentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus> incidentStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(0));
                        incidentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        incidentStatuss.Add(incidentStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();
                    incidentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentStatuss.Add(incidentStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus pIncidentStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentStatus_Insert]");
                try
                {
                    pIncidentStatus.Detail = base.InsertTranslation(pIncidentStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIncidentStatus.Detail.TranslationID));
                    SqlParameter incidentStatusID = sqlCommand.Parameters.Add("@IncidentStatusID", SqlDbType.Int);
                    incidentStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus((Int32)incidentStatusID.Value);
                    incidentStatus.Detail = new Translation(pIncidentStatus.Detail.TranslationID);
                    incidentStatus.Detail.Alias = pIncidentStatus.Detail.Alias;
                    incidentStatus.Detail.Description = pIncidentStatus.Detail.Description;
                    incidentStatus.Detail.Name = pIncidentStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    incidentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus pIncidentStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();

            pIncidentStatus.Detail = base.UpdateTranslation(pIncidentStatus.Detail);

            incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus(pIncidentStatus.IncidentStatusID);
            incidentStatus.Detail = new Translation(pIncidentStatus.Detail.TranslationID);
            incidentStatus.Detail.Alias = pIncidentStatus.Detail.Alias;
            incidentStatus.Detail.Description = pIncidentStatus.Detail.Description;
            incidentStatus.Detail.Name = pIncidentStatus.Detail.Name;

            return incidentStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus pIncidentStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentStatusID", pIncidentStatus.IncidentStatusID));

                    sqlCommand.ExecuteNonQuery();

                    incidentStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentStatus(pIncidentStatus.IncidentStatusID);
                    base.DeleteAllTranslations(pIncidentStatus.Detail);
                }
                catch (Exception exc)
                {
                    incidentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentStatus;
        }
    }
}

