using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class RiskLogDOL : BaseDOL
    {
        public RiskLogDOL() : base()
        {
        }

        public RiskLogDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public RiskLog Register(int? pProgrammeID, int? pProjectID)
        {
            RiskLog riskLog = new RiskLog();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskLog_Register]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    SqlParameter actionLogID = sqlCommand.Parameters.Add("@RiskLogID", SqlDbType.Int);
                    actionLogID.Direction = ParameterDirection.Output;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    riskLog = new Entities.Project.RiskLog(Convert.ToInt32(actionLogID.Value));
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskLog.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskLog.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskLog;
        }
    }
}
