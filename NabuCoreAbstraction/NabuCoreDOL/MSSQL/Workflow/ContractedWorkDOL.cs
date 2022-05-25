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
    public class ContractedWorkDOL : BaseDOL
    {
        public ContractedWorkDOL() : base()
        {
        }

        public ContractedWorkDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContractedWork Get(int pContractedWorkID, int pLanguageID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWork_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contractedWork = new ContractedWork(sqlDataReader.GetInt32(0));
                        contractedWork.ContractedWorkType = new ContractedWorkType(sqlDataReader.GetInt32(1));
                        contractedWork.ContractedWorkType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contractedWork.Contract = new Contract(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            contractedWork.StartDate = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            contractedWork.StartDate = sqlDataReader.GetDateTime(5);
                        contractedWork.Priority = sqlDataReader.GetFloat(6);
                        contractedWork.Statement = new Statement(sqlDataReader.GetInt32(7));
                        contractedWork.State = new State(sqlDataReader.GetInt32(8));
                        contractedWork.State.Detail = base.GetTranslation(sqlDataReader.GetInt32(9), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork[] List(int pContractID, int pLanguageID)
        {
            List<ContractedWork> contractedWorks = new List<ContractedWork>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWork_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContractedWork contractedWork = new ContractedWork(sqlDataReader.GetInt32(0));
                        contractedWork.ContractedWorkType = new ContractedWorkType(sqlDataReader.GetInt32(1));
                        contractedWork.ContractedWorkType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contractedWork.Contract = new Contract(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            contractedWork.StartDate = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            contractedWork.StartDate = sqlDataReader.GetDateTime(5);
                        contractedWork.Priority = sqlDataReader.GetFloat(6);
                        contractedWork.Statement = new Statement(sqlDataReader.GetInt32(7));
                        contractedWork.State = new State(sqlDataReader.GetInt32(8));
                        contractedWork.State.Detail = base.GetTranslation(sqlDataReader.GetInt32(9), pLanguageID);
                        contractedWorks.Add(contractedWork);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContractedWork contractedWork = new ContractedWork();
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contractedWorks.Add(contractedWork);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWorks.ToArray();
        }

        public ContractedWork Insert(ContractedWork pContractedWork)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWork_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkTypeID", pContractedWork.ContractedWorkType.ContractedWorkTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractedWork.Contract.ContractID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pContractedWork.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pContractedWork.EndDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pContractedWork.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pContractedWork.Statement.StatementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pContractedWork.State.StateID));
                    SqlParameter contractedWorkID = sqlCommand.Parameters.Add("@ContractedWorkID", SqlDbType.Int);
                    contractedWorkID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork((Int32)contractedWorkID.Value);
                    contractedWork.ContractedWorkType = new ContractedWorkType(pContractedWork.ContractedWorkType.ContractedWorkTypeID);
                    contractedWork.Contract = new Contract(pContractedWork.Contract.ContractID);
                    contractedWork.StartDate = pContractedWork.StartDate;
                    contractedWork.StartDate = pContractedWork.EndDate;
                    contractedWork.Priority = pContractedWork.Priority;
                    contractedWork.Statement = new Statement(pContractedWork.Statement.StatementID);
                    contractedWork.State = new State(pContractedWork.State.StateID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork Update(ContractedWork pContractedWork)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWork_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWork.ContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkTypeID", pContractedWork.ContractedWorkType.ContractedWorkTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractedWork.Contract.ContractID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pContractedWork.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pContractedWork.EndDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pContractedWork.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pContractedWork.Statement.StatementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pContractedWork.State.StateID));
                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWork.ContractedWorkID);
                    contractedWork.ContractedWorkType = new ContractedWorkType(pContractedWork.ContractedWorkType.ContractedWorkTypeID);
                    contractedWork.Contract = new Contract(pContractedWork.Contract.ContractID);
                    contractedWork.StartDate = pContractedWork.StartDate;
                    contractedWork.StartDate = pContractedWork.EndDate;
                    contractedWork.Priority = pContractedWork.Priority;
                    contractedWork.Statement = new Statement(pContractedWork.Statement.StatementID);
                    contractedWork.State = new State(pContractedWork.State.StateID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork Delete(ContractedWork pContractedWork)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWork_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWork.ContractedWorkID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWork.ContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork AssignItem(int pContractedWorkID, int pItemID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkItem_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }
        public ContractedWork RemoveItem(int pContractedWorkID, int pItemID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkItem_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork AssignItemResponse(int pContractedWorkID, int pItemResponseID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkItemResponse_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }
        public ContractedWork RemoveItemResponse(int pContractedWorkID, int pItemResponseID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkItemResponse_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }

        public ContractedWork AssignResponse(int pContractedWorkID, int pResponseID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkResponse_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }
        public ContractedWork RemoveResponse(int pContractedWorkID, int pResponseID)
        {
            ContractedWork contractedWork = new ContractedWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkResponse_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWork = new ContractedWork(pContractedWorkID);
                }
                catch (Exception exc)
                {
                    contractedWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWork;
        }
    }
}

