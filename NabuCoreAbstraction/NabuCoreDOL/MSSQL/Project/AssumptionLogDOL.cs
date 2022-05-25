using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class AssumptionLogDOL : BaseDOL
    {
        public AssumptionLogDOL() : base()
        {
        }

        public AssumptionLogDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AssumptionLog Register(int? pProgrammeID, int? pProjectID)
        {
            AssumptionLog assumptionLog = new AssumptionLog();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionLog_Register]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    SqlParameter actionLogID = sqlCommand.Parameters.Add("@AssumptionLogID", SqlDbType.Int);
                    actionLogID.Direction = ParameterDirection.Output;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    assumptionLog = new Entities.Project.AssumptionLog(Convert.ToInt32(actionLogID.Value));

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assumptionLog.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionLog.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionLog;
        }
    }
}
