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
    public class PartyWorkDOL : BaseDOL
    {
        public PartyWorkDOL() : base()
        {
        }

        public PartyWorkDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyWork Get(int pWorkID, int pLanguageID)
        {
            PartyWork partyWork = new PartyWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pWorkID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyWork = new PartyWork(sqlDataReader.GetInt32(0));
                        partyWork.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        partyWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWork;
        }

        public PartyWork[] List(int pPartyID, int pLanguageID)
        {
            List<PartyWork> partyWorks = new List<PartyWork>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyWork partyWork = new PartyWork(sqlDataReader.GetInt32(0));
                        partyWork.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        partyWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(2));
                        partyWorks.Add(partyWork);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyWork partyWork = new PartyWork();
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyWorks.Add(partyWork);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWorks.ToArray();
        }

        public PartyWork[] ListChildren(int pParentWorkID, int pLanguageID)
        {
            List<PartyWork> partyWorks = new List<PartyWork>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyWork partyWork = new PartyWork(sqlDataReader.GetInt32(0));
                        partyWork.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        partyWork.ContractedWork = new ContractedWork(sqlDataReader.GetInt32(2));
                        partyWorks.Add(partyWork);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyWork partyWork = new PartyWork();
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyWorks.Add(partyWork);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWorks.ToArray();
        }

        public PartyWork Insert(PartyWork pPartyWork, int? pParentWorkID)
        {
            PartyWork partyWork = new PartyWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyWork.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pPartyWork.ContractedWork.ContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));
                    SqlParameter partyWorkID = sqlCommand.Parameters.Add("@WorkID", SqlDbType.Int);
                    partyWorkID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyWork = new PartyWork((Int32)partyWorkID.Value);
                    partyWork.Party = new Entities.Core.Party(partyWork.Party.PartyID);
                    partyWork.ContractedWork = new ContractedWork(partyWork.ContractedWork.ContractedWorkID);
                }
                catch (Exception exc)
                {
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWork;
        }

        public PartyWork Update(PartyWork pPartyWork, int? pParentWorkID)
        {
            PartyWork partyWork = new PartyWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pPartyWork.WorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyWork.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContractedWorkID", pPartyWork.ContractedWork.ContractedWorkID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentWorkID", pParentWorkID));
                    sqlCommand.ExecuteNonQuery();

                    partyWork = new PartyWork(pPartyWork.WorkID);
                    partyWork.Party = new Entities.Core.Party(partyWork.Party.PartyID);
                    partyWork.ContractedWork = new ContractedWork(partyWork.ContractedWork.ContractedWorkID);
                }
                catch (Exception exc)
                {
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWork;
        }

        public PartyWork Delete(PartyWork pPartyWork)
        {
            PartyWork partyWork = new PartyWork();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[PartyWork_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WorkID", pPartyWork.WorkID));

                    sqlCommand.ExecuteNonQuery();

                    partyWork = new PartyWork(pPartyWork.WorkID);
                }
                catch (Exception exc)
                {
                    partyWork.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyWork.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyWork;
        }
    }
}
