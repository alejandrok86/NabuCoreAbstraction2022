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
    public class ContractDOL : BaseDOL
    {
        public ContractDOL() : base()
        {
        }

        public ContractDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Contract Get(int pContractID, int pLanguageID)
        {
            Contract contract = new Contract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Contract_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contract = new Contract(sqlDataReader.GetInt32(0));
                        contract.Activity = new Activity(sqlDataReader.GetInt32(1));
                        contract.Activity.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contract.Activity.ActivityType = new ActivityType(sqlDataReader.GetInt32(3));
                        contract.Activity.ActivityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        contract.Activity.Priority = sqlDataReader.GetFloat(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            contract.Activity.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contract;
        }

        public Contract[] List(int pActivityID, int pLanguageID)
        {
            List<Contract> contracts = new List<Contract>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Contract_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Contract contract = new Contract(sqlDataReader.GetInt32(0));
                        contract.Activity = new Activity(sqlDataReader.GetInt32(1));
                        contract.Activity.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contract.Activity.ActivityType = new ActivityType(sqlDataReader.GetInt32(3));
                        contract.Activity.ActivityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        contract.Activity.Priority = sqlDataReader.GetFloat(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            contract.Activity.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(6));
                        contracts.Add(contract);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Contract contract = new Contract();
                    contract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contracts.Add(contract);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contracts.ToArray();
        }

        public Contract Insert(Contract pContract)
        {
            Contract contract = new Contract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Contract_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pContract.Activity.ActivityID));
                    SqlParameter contractID = sqlCommand.Parameters.Add("@ContractID", SqlDbType.Int);
                    contractID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contract = new Contract((Int32)contractID.Value);
                    contract.Activity = new Activity(pContract.Activity.ActivityID);
                    contract.Activity.Detail = new Translation(pContract.Activity.Detail.TranslationID);
                    contract.Activity.Detail.Alias = pContract.Activity.Detail.Alias;
                    contract.Activity.ActivityType = new ActivityType(pContract.Activity.ActivityType.ActivityTypeID);
                    contract.Activity.ActivityType.Detail = new Translation(pContract.Activity.ActivityType.Detail.TranslationID);
                    contract.Activity.ActivityType.Detail.Alias = pContract.Activity.ActivityType.Detail.Alias;
                    contract.Activity.Priority = pContract.Activity.Priority;
                    if (pContract.Activity.Attributes != null)
                        contract.Activity.Attributes = new Entities.Utility.EntityAttributeCollection(pContract.Activity.Attributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    contract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contract;
        }

        public Contract Delete(Contract pContract)
        {
            Contract contract = new Contract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Contract_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContract.ContractID));

                    sqlCommand.ExecuteNonQuery();

                    contract = new Contract(pContract.ContractID);
                }
                catch (Exception exc)
                {
                    contract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contract;
        }
    }
}
