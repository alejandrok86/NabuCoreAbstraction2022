using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ResponseAuditDOL : BaseDOL
    {
        public ResponseAuditDOL() : base()
        {
        }

        public ResponseAuditDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ResponseAudit[] List(int pResponseID)
        {
            List<ResponseAudit> responseAuditItems = new List<ResponseAudit>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseAudit_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ResponseAudit responseAudit = new ResponseAudit(sqlDataReader.GetInt32(0));
                        responseAudit.UserAccountID = sqlDataReader.GetInt32(1);
                        responseAudit.RespondentID = sqlDataReader.GetInt32(2);
                        responseAudit.InstrumentID = sqlDataReader.GetInt32(3);
                        responseAudit.ResponseID = sqlDataReader.GetInt32(4);
                        if(sqlDataReader.IsDBNull(5)==false)
                            responseAudit.ItemResponseID = sqlDataReader.GetInt32(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            responseAudit.ItemID = sqlDataReader.GetInt32(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            responseAudit.AttemptID = sqlDataReader.GetInt32(7);
                        responseAudit.AuditType = sqlDataReader.GetString(8);
                        responseAudit.EventOcurredAt = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            responseAudit.ResponseValue = sqlDataReader.GetString(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            responseAudit.TextualOutcome = sqlDataReader.GetString(11);
                        responseAuditItems.Add(responseAudit);
                    }
                }
                catch (Exception exc)
                {
                    ResponseAudit error = new ResponseAudit();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseAuditItems.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseAuditItems.ToArray();
        }

        public ResponseAudit Insert(Octavo.Gate.Nabu.CORE.Entities.Response.ResponseAudit pResponseAudit)
        {
            ResponseAudit responseAudit = new ResponseAudit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseAudit_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pResponseAudit.UserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pResponseAudit.RespondentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pResponseAudit.InstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseAudit.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pResponseAudit.ItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pResponseAudit.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttemptID", pResponseAudit.AttemptID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditType", pResponseAudit.AuditType));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventOcurredAt", pResponseAudit.EventOcurredAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseValue", pResponseAudit.ResponseValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextualOutcome", pResponseAudit.TextualOutcome));
                    SqlParameter responseAuditID = sqlCommand.Parameters.Add("@ResponseAuditID", SqlDbType.Int);
                    responseAuditID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseAudit = new ResponseAudit((Int32)responseAuditID.Value);
                    responseAudit.UserAccountID = pResponseAudit.UserAccountID;
                    responseAudit.RespondentID = pResponseAudit.RespondentID;
                    responseAudit.InstrumentID = pResponseAudit.InstrumentID;
                    responseAudit.ResponseID = pResponseAudit.ResponseID;
                    responseAudit.ItemResponseID = pResponseAudit.ItemResponseID;
                    responseAudit.ItemID = pResponseAudit.ItemID;
                    responseAudit.AttemptID = pResponseAudit.AttemptID;
                    responseAudit.AuditType = pResponseAudit.AuditType;
                    responseAudit.EventOcurredAt = pResponseAudit.EventOcurredAt;
                    responseAudit.ResponseValue = pResponseAudit.ResponseValue;
                    responseAudit.TextualOutcome = pResponseAudit.TextualOutcome;
                }
                catch (Exception exc)
                {
                    responseAudit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseAudit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseAudit;
        }
    }
}
