using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class ContainerStatusDOL : BaseDOL
    {
        public ContainerStatusDOL() : base()
        {
        }

        public ContainerStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ContainerStatus Get(int pContainerStatusID, int pLanguageID)
        {
            ContainerStatus containerStatus = new ContainerStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerStatusID", pContainerStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        containerStatus = new ContainerStatus(sqlDataReader.GetInt32(0));
                        containerStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    containerStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerStatus;
        }

        public ContainerStatus GetByAlias(string pAlias, int pLanguageID)
        {
            ContainerStatus containerStatus = new ContainerStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        containerStatus = new ContainerStatus(sqlDataReader.GetInt32(0));
                        containerStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    containerStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerStatus;
        }

        public ContainerStatus[] List(int pLanguageID)
        {
            List<ContainerStatus> containerStatuss = new List<ContainerStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContainerStatus containerStatus = new ContainerStatus(sqlDataReader.GetInt32(0));
                        containerStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        containerStatuss.Add(containerStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContainerStatus containerStatus = new ContainerStatus();
                    containerStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    containerStatuss.Add(containerStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerStatuss.ToArray();
        }

        public ContainerStatus Insert(ContainerStatus pContainerStatus)
        {
            ContainerStatus containerStatus = new ContainerStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerStatus_Insert]");
                try
                {
                    pContainerStatus.Detail = base.InsertTranslation(pContainerStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContainerStatus.Detail.TranslationID));
                    SqlParameter containerStatusID = sqlCommand.Parameters.Add("@ContainerStatusID", SqlDbType.Int);
                    containerStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    containerStatus = new ContainerStatus((Int32)containerStatusID.Value);
                    containerStatus.Detail = new Translation(pContainerStatus.Detail.TranslationID);
                    containerStatus.Detail.Alias = pContainerStatus.Detail.Alias;
                    containerStatus.Detail.Description = pContainerStatus.Detail.Description;
                    containerStatus.Detail.Name = pContainerStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    containerStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerStatus;
        }

        public ContainerStatus Update(ContainerStatus pContainerStatus)
        {
            ContainerStatus containerStatus = new ContainerStatus();

            containerStatus.Detail = base.UpdateTranslation(pContainerStatus.Detail);

            return containerStatus;
        }

        public ContainerStatus Delete(ContainerStatus pContainerStatus)
        {
            ContainerStatus containerStatus = new ContainerStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerStatusID", pContainerStatus.ContainerStatusID));

                    sqlCommand.ExecuteNonQuery();

                    containerStatus = new ContainerStatus(pContainerStatus.ContainerStatusID);
                    base.DeleteAllTranslations(pContainerStatus.Detail);
                }
                catch (Exception exc)
                {
                    containerStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerStatus;
        }
    }
}

