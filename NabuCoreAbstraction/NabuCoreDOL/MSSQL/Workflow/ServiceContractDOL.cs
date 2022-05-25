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
    public class ServiceContractDOL : BaseDOL
    {
        public ServiceContractDOL() : base()
        {
        }

        public ServiceContractDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ServiceContract Assign(int pPartyRoleID, int pContractID)
        {
            ServiceContract serviceContract = new ServiceContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyRoleContract_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractID));

                    sqlCommand.ExecuteNonQuery();

                    serviceContract = new ServiceContract(pContractID);
                }
                catch (Exception exc)
                {
                    serviceContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceContract;
        }

        public ServiceContract Remove(int pPartyRoleID, int pContractID)
        {
            ServiceContract serviceContract = new ServiceContract();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyRoleContract_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractID", pContractID));

                    sqlCommand.ExecuteNonQuery();

                    serviceContract = new ServiceContract(pContractID);
                }
                catch (Exception exc)
                {
                    serviceContract.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    serviceContract.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return serviceContract;
        }
    }
}
