using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentNotificationMethodDOL : BaseDOL
    {
        public IncidentNotificationMethodDOL() : base()
        {
        }

        public IncidentNotificationMethodDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod Get(int pIncidentNotificationMethodID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentNotificationMethod_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentNotificationMethodID", pIncidentNotificationMethodID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(0));
                        incidentNotificationMethod.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentNotificationMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentNotificationMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentNotificationMethod;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentNotificationMethod_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(0));
                        incidentNotificationMethod.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentNotificationMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentNotificationMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentNotificationMethod;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod> incidentNotificationMethods = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentNotificationMethod_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(0));
                        incidentNotificationMethod.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        incidentNotificationMethods.Add(incidentNotificationMethod);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();
                    incidentNotificationMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentNotificationMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentNotificationMethods.Add(incidentNotificationMethod);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentNotificationMethods.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod pIncidentNotificationMethod)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentNotificationMethod_Insert]");
                try
                {
                    pIncidentNotificationMethod.Detail = base.InsertTranslation(pIncidentNotificationMethod.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIncidentNotificationMethod.Detail.TranslationID));
                    SqlParameter incidentNotificationMethodID = sqlCommand.Parameters.Add("@IncidentNotificationMethodID", SqlDbType.Int);
                    incidentNotificationMethodID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod((Int32)incidentNotificationMethodID.Value);
                    incidentNotificationMethod.Detail = new Translation(pIncidentNotificationMethod.Detail.TranslationID);
                    incidentNotificationMethod.Detail.Alias = pIncidentNotificationMethod.Detail.Alias;
                    incidentNotificationMethod.Detail.Description = pIncidentNotificationMethod.Detail.Description;
                    incidentNotificationMethod.Detail.Name = pIncidentNotificationMethod.Detail.Name;
                }
                catch (Exception exc)
                {
                    incidentNotificationMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentNotificationMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentNotificationMethod;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod pIncidentNotificationMethod)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();

            pIncidentNotificationMethod.Detail = base.UpdateTranslation(pIncidentNotificationMethod.Detail);

            incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod(pIncidentNotificationMethod.IncidentNotificationMethodID);
            incidentNotificationMethod.Detail = new Translation(pIncidentNotificationMethod.Detail.TranslationID);
            incidentNotificationMethod.Detail.Alias = pIncidentNotificationMethod.Detail.Alias;
            incidentNotificationMethod.Detail.Description = pIncidentNotificationMethod.Detail.Description;
            incidentNotificationMethod.Detail.Name = pIncidentNotificationMethod.Detail.Name;

            return incidentNotificationMethod;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod pIncidentNotificationMethod)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentNotificationMethod_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentNotificationMethodID", pIncidentNotificationMethod.IncidentNotificationMethodID));

                    sqlCommand.ExecuteNonQuery();

                    incidentNotificationMethod = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentNotificationMethod(pIncidentNotificationMethod.IncidentNotificationMethodID);
                    base.DeleteAllTranslations(pIncidentNotificationMethod.Detail);
                }
                catch (Exception exc)
                {
                    incidentNotificationMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentNotificationMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentNotificationMethod;
        }
    }
}

