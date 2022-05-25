using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class IssueLogDOL : BaseDOL
    {
        public IssueLogDOL() : base()
        {
        }

        public IssueLogDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public IssueLog Register(int? pProgrammeID, int? pProjectID)
        {
            IssueLog issueLog = new IssueLog();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueLog_Register]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    SqlParameter actionLogID = sqlCommand.Parameters.Add("@IssueLogID", SqlDbType.Int);
                    actionLogID.Direction = ParameterDirection.Output;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    issueLog = new Entities.Project.IssueLog(Convert.ToInt32(actionLogID.Value));

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issueLog.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueLog.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueLog;
        }
    }
}
