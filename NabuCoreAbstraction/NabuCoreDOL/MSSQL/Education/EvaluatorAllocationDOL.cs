using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EvaluatorAllocationDOL : BaseDOL
    {
        public EvaluatorAllocationDOL() : base ()
        {
        }

        public EvaluatorAllocationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EvaluatorAllocation Get(int pEvaluatorAllocationID)
        {
            EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorAllocation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorAllocationID", pEvaluatorAllocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        evaluatorAllocation = new EvaluatorAllocation(sqlDataReader.GetInt32(0));
                        evaluatorAllocation.Item = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        evaluatorAllocation.AllocationItemStatus = new AllocationItemStatus(sqlDataReader.GetInt32(3));
                        evaluatorAllocation.PlannedAllocation = sqlDataReader.GetInt64(4);
                        evaluatorAllocation.ActualQty = sqlDataReader.GetInt64(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    evaluatorAllocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorAllocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorAllocation;
        }

        public EvaluatorAllocation[] List(int pEvaluatorContractID)
        {
            List<EvaluatorAllocation> evaluatorAllocations = new List<EvaluatorAllocation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorAllocation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID", pEvaluatorContractID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation(sqlDataReader.GetInt32(0));
                        evaluatorAllocation.Item = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        evaluatorAllocation.AllocationItemStatus = new AllocationItemStatus(sqlDataReader.GetInt32(3));
                        evaluatorAllocation.PlannedAllocation = sqlDataReader.GetInt64(4);
                        evaluatorAllocation.ActualQty = sqlDataReader.GetInt64(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation();
                    evaluatorAllocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorAllocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    evaluatorAllocations.Add(evaluatorAllocation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorAllocations.ToArray();
        }

        public EvaluatorAllocation Insert(EvaluatorAllocation pEvaluatorAllocation, int pEvaluatorContractID)
        {
            EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorAllocation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID", pEvaluatorContractID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pEvaluatorAllocation.Item.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocationItemStatusID", pEvaluatorAllocation.AllocationItemStatus.AllocationItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedAllocation", pEvaluatorAllocation.PlannedAllocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActualQty", pEvaluatorAllocation.ActualQty));
                    SqlParameter evaluatorAllocationID = sqlCommand.Parameters.Add("@EvaluatorAllocationID", SqlDbType.Int);
                    evaluatorAllocationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    evaluatorAllocation = new EvaluatorAllocation((Int32)evaluatorAllocationID.Value);
                    evaluatorAllocation.Item = new Entities.Item.Item(pEvaluatorAllocation.Item.ItemID);
                    evaluatorAllocation.AllocationItemStatus = new AllocationItemStatus(pEvaluatorAllocation.AllocationItemStatus.AllocationItemStatusID);
                    evaluatorAllocation.PlannedAllocation = pEvaluatorAllocation.PlannedAllocation;
                    evaluatorAllocation.ActualQty = pEvaluatorAllocation.ActualQty;
                }
                catch (Exception exc)
                {
                    evaluatorAllocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorAllocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorAllocation;
        }

        public EvaluatorAllocation Update(EvaluatorAllocation pEvaluatorAllocation, int pEvaluatorContractID)
        {
            EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorAllocation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorAllocationID",pEvaluatorAllocation.EvaluatorAllocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID", pEvaluatorContractID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pEvaluatorAllocation.Item.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocationItemStatusID", pEvaluatorAllocation.AllocationItemStatus.AllocationItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedAllocation", pEvaluatorAllocation.PlannedAllocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActualQty", pEvaluatorAllocation.ActualQty));

                    sqlCommand.ExecuteNonQuery();

                    evaluatorAllocation = new EvaluatorAllocation(pEvaluatorAllocation.EvaluatorAllocationID);
                    evaluatorAllocation.Item = new Entities.Item.Item(pEvaluatorAllocation.Item.ItemID);
                    evaluatorAllocation.AllocationItemStatus = new AllocationItemStatus(pEvaluatorAllocation.AllocationItemStatus.AllocationItemStatusID);
                    evaluatorAllocation.PlannedAllocation = pEvaluatorAllocation.PlannedAllocation;
                    evaluatorAllocation.ActualQty = pEvaluatorAllocation.ActualQty;
                }
                catch (Exception exc)
                {
                    evaluatorAllocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorAllocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorAllocation;
        }

        public EvaluatorAllocation Delete(EvaluatorAllocation pEvaluatorAllocation)
        {
            EvaluatorAllocation evaluatorAllocation = new EvaluatorAllocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorAllocation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorAllocationID", pEvaluatorAllocation.EvaluatorAllocationID));

                    sqlCommand.ExecuteNonQuery();

                    evaluatorAllocation = new EvaluatorAllocation(pEvaluatorAllocation.EvaluatorAllocationID);
                }
                catch (Exception exc)
                {
                    evaluatorAllocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorAllocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorAllocation;
        }
    }
}
