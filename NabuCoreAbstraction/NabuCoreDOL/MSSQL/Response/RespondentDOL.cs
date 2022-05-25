using Octavo.Gate.Nabu.CORE.Entities.Error;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class RespondentDOL : BaseDOL
    {
        public RespondentDOL() : base()
        {
        }

        public RespondentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Respondent Assign(int pRespondentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Respondent respondent = new Octavo.Gate.Nabu.CORE.Entities.Response.Respondent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Respondent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pRespondentID));

                    sqlCommand.ExecuteNonQuery();

                    respondent = new Octavo.Gate.Nabu.CORE.Entities.Response.Respondent(pRespondentID);
                }
                catch (Exception exc)
                {
                    respondent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    respondent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return respondent;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Respondent Remove(int pRespondentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Respondent respondent = new Octavo.Gate.Nabu.CORE.Entities.Response.Respondent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Respondent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pRespondentID));

                    sqlCommand.ExecuteNonQuery();

                    respondent = new Octavo.Gate.Nabu.CORE.Entities.Response.Respondent(pRespondentID);
                }
                catch (Exception exc)
                {
                    respondent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    respondent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return respondent;
        }
    }
}

