using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ServiceDOL : BaseDOL
    {
        public ServiceDOL() : base()
        {
        }

        public ServiceDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.ServiceManagement.Service Get(int? pServiceID)
        {
            Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Service_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        service = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            service.Code = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            service.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            service.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            service.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            service.LinkedToProject = new  Entities.Planning.Project(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    service.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    service.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return service;
        }

        public Entities.ServiceManagement.Service[] List(int pOwnerPartyID)
        {
            List<Entities.ServiceManagement.Service> services = new List<Entities.ServiceManagement.Service>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Service_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            service.Code = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            service.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            service.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            service.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            service.LinkedToProject = new Entities.Planning.Project(sqlDataReader.GetInt32(5));
                        services.Add(service);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service();
                    service.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    service.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    services.Add(service);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return services.ToArray();
        }

        public Entities.ServiceManagement.Service Insert(Entities.ServiceManagement.Service pService)
        {
            Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Service_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceCode", pService.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceName", pService.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceDescription", pService.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pService.Owner != null && pService.Owner.PartyID.HasValue) ? pService.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkedToProjectID", ((pService.LinkedToProject != null && pService.LinkedToProject.ProjectID.HasValue) ? pService.LinkedToProject.ProjectID : null)));
                    SqlParameter serviceID = sqlCommand.Parameters.Add("@ServiceID", SqlDbType.Int);
                    serviceID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    service = new Entities.ServiceManagement.Service((Int32)serviceID.Value);
                    service.Code = pService.Code;
                    service.Name = pService.Name;
                    service.Description = pService.Description;
                    service.Owner = pService.Owner;
                    service.LinkedToProject = pService.LinkedToProject;
                }
                catch (Exception exc)
                {
                    service.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    service.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return service;
        }

        public Entities.ServiceManagement.Service Update(Entities.ServiceManagement.Service pService)
        {
            Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Service_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pService.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceCode", pService.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceName", pService.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceDescription", pService.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pService.Owner != null && pService.Owner.PartyID.HasValue) ? pService.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkedToProjectID", ((pService.LinkedToProject != null && pService.LinkedToProject.ProjectID.HasValue) ? pService.LinkedToProject.ProjectID : null)));

                    sqlCommand.ExecuteNonQuery();

                    service = new Entities.ServiceManagement.Service(pService.ServiceID);
                    service.Code = pService.Code;
                    service.Name = pService.Name;
                    service.Description = pService.Description;
                    service.Owner = pService.Owner;
                    service.LinkedToProject = pService.LinkedToProject;
                }
                catch (Exception exc)
                {
                    service.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    service.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return service;
        }

        public Entities.ServiceManagement.Service Delete(Entities.ServiceManagement.Service pService)
        {
            Entities.ServiceManagement.Service service = new Entities.ServiceManagement.Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Service_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pService.ServiceID));

                    sqlCommand.ExecuteNonQuery();

                    service = new Entities.ServiceManagement.Service(pService.ServiceID);
                }
                catch (Exception exc)
                {
                    service.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    service.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return service;
        }
    }
}


