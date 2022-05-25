using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow
{
    public class ServiceWorkDOL : BaseDOL
    {
        public ServiceWorkDOL() : base()
        {
        }

        public ServiceWorkDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ServiceWork Get(int pWorkID, int pLanguageID)
        {
            ServiceWork serviceWork = new ServiceWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pWorkID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        serviceWork = new ServiceWork(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            serviceWork.ServerName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            serviceWork.InstanceIdentifier = sqlDataReader.GetString(2);
                        serviceWork.Service = new Service(sqlDataReader.GetInt32(3));
                        serviceWork.PID = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            serviceWork.LastCheckedDate = sqlDataReader.GetDateTime(5);
                        serviceWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWork;
        }

        public ServiceWork[] List(int pServiceID, int pLanguageID)
        {
            List<ServiceWork> serviceWorks = new List<ServiceWork>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ServiceWork serviceWork = new ServiceWork(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            serviceWork.ServerName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            serviceWork.InstanceIdentifier = sqlDataReader.GetString(2);
                        serviceWork.Service = new Service(sqlDataReader.GetInt32(3));
                        serviceWork.PID = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            serviceWork.LastCheckedDate = sqlDataReader.GetDateTime(5);
                        serviceWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(6));
                        serviceWorks.Add(serviceWork);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ServiceWork serviceWork = new ServiceWork();
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    serviceWorks.Add(serviceWork);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWorks.ToArray();
        }

        public ServiceWork[] ListChildren(int pParentWorkID, int pLanguageID)
        {
            List<ServiceWork> serviceWorks = new List<ServiceWork>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ServiceWork serviceWork = new ServiceWork(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            serviceWork.ServerName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            serviceWork.InstanceIdentifier = sqlDataReader.GetString(2);
                        serviceWork.Service = new Service(sqlDataReader.GetInt32(3));
                        serviceWork.PID = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            serviceWork.LastCheckedDate = sqlDataReader.GetDateTime(5);
                        serviceWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(6));
                        serviceWorks.Add(serviceWork);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ServiceWork serviceWork = new ServiceWork();
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    serviceWorks.Add(serviceWork);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWorks.ToArray();
        }

        public ServiceWork Insert(ServiceWork pServiceWork, int? pParentWorkID)
        {
            ServiceWork serviceWork = new ServiceWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServerName", pServiceWork.ServerName));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstanceIdentifier", pServiceWork.InstanceIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceWork.Service.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PID", pServiceWork.PID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastCheckedDate", pServiceWork.LastCheckedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pServiceWork.ContractedWork.ContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));
                    SqlParameter serviceWorkID = sqlCommand.Parameters.Add("@WorkID", SqlDbType.Int);
                    serviceWorkID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    serviceWork = new ServiceWork((Int32)serviceWorkID.Value);
                    serviceWork.ServerName = pServiceWork.ServerName;
                    serviceWork.InstanceIdentifier = pServiceWork.InstanceIdentifier;
                    serviceWork.Service = new Service(pServiceWork.Service.ServiceID);
                    serviceWork.PID = pServiceWork.PID;
                    serviceWork.LastCheckedDate = pServiceWork.LastCheckedDate;
                    serviceWork.ContractedWork = new ContractedWork(pServiceWork.ContractedWork.ContractedWorkID);
                }
                catch (Exception exc)
                {
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWork;
        }

        public ServiceWork Update(ServiceWork pServiceWork, int? pParentWorkID)
        {
            ServiceWork serviceWork = new ServiceWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pServiceWork.WorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServerName", pServiceWork.ServerName));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstanceIdentifier", pServiceWork.InstanceIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceWork.Service.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PID", pServiceWork.PID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastCheckedDate", pServiceWork.LastCheckedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pServiceWork.ContractedWork.ContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));
                    sqlCommand.ExecuteNonQuery();

                    serviceWork = new ServiceWork(pServiceWork.WorkID);
                    serviceWork.ServerName = pServiceWork.ServerName;
                    serviceWork.InstanceIdentifier = pServiceWork.InstanceIdentifier;
                    serviceWork.Service = new Service(pServiceWork.Service.ServiceID);
                    serviceWork.PID = pServiceWork.PID;
                    serviceWork.LastCheckedDate = pServiceWork.LastCheckedDate;
                    serviceWork.ContractedWork = new ContractedWork(pServiceWork.ContractedWork.ContractedWorkID);
                }
                catch (Exception exc)
                {
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWork;
        }

        public ServiceWork Delete(ServiceWork pServiceWork)
        {
            ServiceWork serviceWork = new ServiceWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ServiceWork_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pServiceWork.WorkID));

                    sqlCommand.ExecuteNonQuery();

                    serviceWork = new ServiceWork(pServiceWork.WorkID);
                }
                catch (Exception exc)
                {
                    serviceWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceWork;
        }
    }
}
