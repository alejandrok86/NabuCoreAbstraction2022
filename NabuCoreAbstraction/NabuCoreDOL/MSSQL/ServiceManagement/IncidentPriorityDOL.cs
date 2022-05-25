using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentPriorityDOL : BaseDOL
    {
        public IncidentPriorityDOL() : base()
        {
        }

        public IncidentPriorityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority Get(int pIncidentPriorityID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentPriority_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentPriorityID", pIncidentPriorityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(0));
                        incidentPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentPriority_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(0));
                        incidentPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority> incidentPrioritys = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentPriority_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(0));
                        incidentPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        incidentPrioritys.Add(incidentPriority);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();
                    incidentPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentPrioritys.Add(incidentPriority);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentPrioritys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority pIncidentPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentPriority_Insert]");
                try
                {
                    pIncidentPriority.Detail = base.InsertTranslation(pIncidentPriority.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIncidentPriority.Detail.TranslationID));
                    SqlParameter incidentPriorityID = sqlCommand.Parameters.Add("@IncidentPriorityID", SqlDbType.Int);
                    incidentPriorityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority((Int32)incidentPriorityID.Value);
                    incidentPriority.Detail = new Translation(pIncidentPriority.Detail.TranslationID);
                    incidentPriority.Detail.Alias = pIncidentPriority.Detail.Alias;
                    incidentPriority.Detail.Description = pIncidentPriority.Detail.Description;
                    incidentPriority.Detail.Name = pIncidentPriority.Detail.Name;
                }
                catch (Exception exc)
                {
                    incidentPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority pIncidentPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();

            pIncidentPriority.Detail = base.UpdateTranslation(pIncidentPriority.Detail);

            incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority(pIncidentPriority.IncidentPriorityID);
            incidentPriority.Detail = new Translation(pIncidentPriority.Detail.TranslationID);
            incidentPriority.Detail.Alias = pIncidentPriority.Detail.Alias;
            incidentPriority.Detail.Description = pIncidentPriority.Detail.Description;
            incidentPriority.Detail.Name = pIncidentPriority.Detail.Name;

            return incidentPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority pIncidentPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentPriority_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentPriorityID", pIncidentPriority.IncidentPriorityID));

                    sqlCommand.ExecuteNonQuery();

                    incidentPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentPriority(pIncidentPriority.IncidentPriorityID);
                    base.DeleteAllTranslations(pIncidentPriority.Detail);
                }
                catch (Exception exc)
                {
                    incidentPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentPriority;
        }
    }
}

