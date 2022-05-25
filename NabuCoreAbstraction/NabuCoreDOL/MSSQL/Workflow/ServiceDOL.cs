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
    public class ServiceDOL : BaseDOL
    {
        public ServiceDOL() : base()
        {
        }

        public ServiceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Service Get(int pServiceID, int pLanguageID)
        {
            Service service = new Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Service_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        service = new Service(sqlDataReader.GetInt32(0));
                        service.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        service.IsServiceActive = sqlDataReader.GetBoolean(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            service.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(3));
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

        public Service[] List(int pLanguageID)
        {
            List<Service> services = new List<Service>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Service_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Service service = new Service(sqlDataReader.GetInt32(0));
                        service.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        service.IsServiceActive = sqlDataReader.GetBoolean(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            service.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(3));
                        services.Add(service);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Service service = new Service();
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

        public Service Insert(Service pService, int? pParentServiceID)
        {
            Service service = new Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Service_Insert]");
                try
                {
                    pService.Detail = base.InsertTranslation(pService.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pService.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsServiceActive", pService.IsServiceActive));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pService.Attributes != null) ? ((pService.Attributes.ToXMLFragment().Length > 0) ? pService.Attributes.ToXMLFragment() : null) : null)));
                    SqlParameter serviceID = sqlCommand.Parameters.Add("@ServiceID", SqlDbType.Int);
                    serviceID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    service = new Service((Int32)serviceID.Value);
                    service.Detail = new Translation(pService.Detail.TranslationID);
                    service.Detail.Alias = pService.Detail.Alias;
                    service.IsServiceActive = pService.IsServiceActive;
                    service.Attributes = new Entities.Utility.EntityAttributeCollection(pService.Attributes.ToXMLFragment());
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

        public Service Update(Service pService, int? pParentServiceID)
        {
            Service service = new Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Service_Update]");
                try
                {
                    pService.Detail = base.UpdateTranslation(pService.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pService.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsServiceActive", pService.IsServiceActive));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pService.Attributes != null) ? ((pService.Attributes.ToXMLFragment().Length > 0) ? pService.Attributes.ToXMLFragment() : null) : null)));

                    sqlCommand.ExecuteNonQuery();

                    service = new Service(pService.ServiceID);
                    service.Detail = new Translation(pService.Detail.TranslationID);
                    service.Detail.Alias = pService.Detail.Alias;
                    service.IsServiceActive = pService.IsServiceActive;
                    service.Attributes = new Entities.Utility.EntityAttributeCollection(pService.Attributes.ToXMLFragment());
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

        public Service Delete(Service pService)
        {
            Service service = new Service();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Service_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pService.ServiceID));

                    sqlCommand.ExecuteNonQuery();

                    service = new Service(pService.ServiceID);
                    base.DeleteAllTranslations(pService.Detail);
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
