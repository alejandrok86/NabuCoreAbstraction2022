using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EvaluatorContractDOL : BaseDOL
    {
        public EvaluatorContractDOL() : base ()
        {
        }

        public EvaluatorContractDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EvaluatorContract Get(int pEvaluatorContractID)
        {
            EvaluatorContract evaluatorContract = new EvaluatorContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorContract_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID", pEvaluatorContractID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        evaluatorContract = new EvaluatorContract(sqlDataReader.GetInt32(0));
                        evaluatorContract.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        evaluatorContract.AssessmentSeries = new AssessmentSeries(sqlDataReader.GetInt32(2));
                        evaluatorContract.ContractStart = sqlDataReader.GetDateTime(3);
                        evaluatorContract.ContractEnd = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    evaluatorContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorContract;
        }

        public EvaluatorContract[] List(int pPartyID)
        {
            List<EvaluatorContract> evaluatorContracts = new List<EvaluatorContract>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorContract_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EvaluatorContract evaluatorContract = new EvaluatorContract(sqlDataReader.GetInt32(0));
                        evaluatorContract.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        evaluatorContract.AssessmentSeries = new AssessmentSeries(sqlDataReader.GetInt32(2));
                        evaluatorContract.ContractStart = sqlDataReader.GetDateTime(3);
                        evaluatorContract.ContractEnd = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EvaluatorContract evaluatorContract = new EvaluatorContract();
                    evaluatorContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    evaluatorContracts.Add(evaluatorContract);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorContracts.ToArray();
        }

        public EvaluatorContract Insert(EvaluatorContract pEvaluatorContract)
        {
            EvaluatorContract evaluatorContract = new EvaluatorContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorContract_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pEvaluatorContract.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pEvaluatorContract.AssessmentSeries.AssessmentSeriesID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractStart", pEvaluatorContract.ContractStart));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractEnd", pEvaluatorContract.ContractEnd));
                    SqlParameter evaluatorContractID = sqlCommand.Parameters.Add("@EvaluatorContractID", SqlDbType.Int);
                    evaluatorContractID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    evaluatorContract = new EvaluatorContract((Int32)evaluatorContractID.Value);
                    evaluatorContract.Party = new Entities.Core.Party(pEvaluatorContract.Party.PartyID);
                    evaluatorContract.AssessmentSeries = new AssessmentSeries(pEvaluatorContract.AssessmentSeries.AssessmentSeriesID);
                    evaluatorContract.ContractStart = pEvaluatorContract.ContractStart;
                    evaluatorContract.ContractEnd = pEvaluatorContract.ContractEnd;
                }
                catch (Exception exc)
                {
                    evaluatorContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorContract;
        }

        public EvaluatorContract Update(EvaluatorContract pEvaluatorContract)
        {
            EvaluatorContract evaluatorContract = new EvaluatorContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorContract_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID",pEvaluatorContract.EvaluatorContractID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pEvaluatorContract.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pEvaluatorContract.AssessmentSeries.AssessmentSeriesID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractStart", pEvaluatorContract.ContractStart));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractEnd", pEvaluatorContract.ContractEnd));

                    sqlCommand.ExecuteNonQuery();

                    evaluatorContract = new EvaluatorContract(pEvaluatorContract.EvaluatorContractID);
                    evaluatorContract.Party = new Entities.Core.Party(pEvaluatorContract.Party.PartyID);
                    evaluatorContract.AssessmentSeries = new AssessmentSeries(pEvaluatorContract.AssessmentSeries.AssessmentSeriesID);
                    evaluatorContract.ContractStart = pEvaluatorContract.ContractStart;
                    evaluatorContract.ContractEnd = pEvaluatorContract.ContractEnd;
                }
                catch (Exception exc)
                {
                    evaluatorContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorContract;
        }

        public EvaluatorContract Delete(EvaluatorContract pEvaluatorContract)
        {
            EvaluatorContract evaluatorContract = new EvaluatorContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EvaluatorContract_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EvaluatorContractID", pEvaluatorContract.EvaluatorContractID));

                    sqlCommand.ExecuteNonQuery();

                    evaluatorContract = new EvaluatorContract(pEvaluatorContract.EvaluatorContractID);
                }
                catch (Exception exc)
                {
                    evaluatorContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evaluatorContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evaluatorContract;
        }
    }
}
