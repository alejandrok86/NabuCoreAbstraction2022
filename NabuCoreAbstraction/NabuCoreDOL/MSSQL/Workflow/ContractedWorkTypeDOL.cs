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
    public class ContractedWorkTypeDOL : BaseDOL
    {
        public ContractedWorkTypeDOL() : base()
        {
        }

        public ContractedWorkTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType Get(int pContractedWorkTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkTypeID", pContractedWorkTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType(sqlDataReader.GetInt32(0));
                        contractedWorkType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contractedWorkType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWorkType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWorkType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType> contractedWorkTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType(sqlDataReader.GetInt32(0));
                        contractedWorkType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contractedWorkTypes.Add(contractedWorkType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType();
                    contractedWorkType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWorkType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contractedWorkTypes.Add(contractedWorkType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWorkTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType Insert(Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType pContractedWorkType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkType_Insert]");
                try
                {
                    pContractedWorkType.Detail = base.InsertTranslation(pContractedWorkType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContractedWorkType.Detail.TranslationID));
                    SqlParameter contractedWorkTypeID = sqlCommand.Parameters.Add("@ContractedWorkTypeID", SqlDbType.Int);
                    contractedWorkTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType((Int32)contractedWorkTypeID.Value);
                    contractedWorkType.Detail = new Translation(pContractedWorkType.Detail.TranslationID);
                    contractedWorkType.Detail.Alias = pContractedWorkType.Detail.Alias;
                    contractedWorkType.Detail.Description = pContractedWorkType.Detail.Description;
                    contractedWorkType.Detail.Name = pContractedWorkType.Detail.Name;
                }
                catch (Exception exc)
                {
                    contractedWorkType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWorkType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWorkType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType Update(Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType pContractedWorkType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType();

            pContractedWorkType.Detail = base.UpdateTranslation(pContractedWorkType.Detail);

            contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType(pContractedWorkType.ContractedWorkTypeID);
            contractedWorkType.Detail = new Translation(pContractedWorkType.Detail.TranslationID);
            contractedWorkType.Detail.Alias = pContractedWorkType.Detail.Alias;
            contractedWorkType.Detail.Description = pContractedWorkType.Detail.Description;
            contractedWorkType.Detail.Name = pContractedWorkType.Detail.Name;

            return contractedWorkType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType Delete(Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType pContractedWorkType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ContractedWorkType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkTypeID", pContractedWorkType.ContractedWorkTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contractedWorkType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ContractedWorkType(pContractedWorkType.ContractedWorkTypeID);
                    base.DeleteAllTranslations(pContractedWorkType.Detail);
                }
                catch (Exception exc)
                {
                    contractedWorkType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contractedWorkType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contractedWorkType;
        }
    }
}
