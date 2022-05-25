using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class AnalysisStatusDOL : BaseDOL
    {
        public AnalysisStatusDOL() : base ()
        {
        }

        public AnalysisStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AnalysisStatus Get(int pAnalysisStatusID, int pLanguageID)
        {
            AnalysisStatus analysisStatus = new AnalysisStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStatusID", pAnalysisStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        analysisStatus = new AnalysisStatus(sqlDataReader.GetInt32(0));
                        analysisStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    analysisStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisStatus;
        }

        public AnalysisStatus[] List(int pLanguageID)
        {
            List<AnalysisStatus> analysisStatuss = new List<AnalysisStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AnalysisStatus analysisStatus = new AnalysisStatus(sqlDataReader.GetInt32(0));
                        analysisStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        analysisStatuss.Add(analysisStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AnalysisStatus analysisStatus = new AnalysisStatus();
                    analysisStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    analysisStatuss.Add(analysisStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisStatuss.ToArray();
        }

        public AnalysisStatus Insert(AnalysisStatus pAnalysisStatus)
        {
            AnalysisStatus analysisStatus = new AnalysisStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisStatus_Insert]");
                try
                {
                    pAnalysisStatus.Detail = base.InsertTranslation(pAnalysisStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAnalysisStatus.Detail.TranslationID));
                    SqlParameter analysisStatusID = sqlCommand.Parameters.Add("@AnalysisStatusID", SqlDbType.Int);
                    analysisStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    analysisStatus = new AnalysisStatus((Int32)analysisStatusID.Value);
                    analysisStatus.Detail = new Translation(pAnalysisStatus.Detail.TranslationID);
                    analysisStatus.Detail.Alias = pAnalysisStatus.Detail.Alias;
                    analysisStatus.Detail.Description = pAnalysisStatus.Detail.Description;
                    analysisStatus.Detail.Name = pAnalysisStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    analysisStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisStatus;
        }

        public AnalysisStatus Update(AnalysisStatus pAnalysisStatus)
        {
            AnalysisStatus analysisStatus = new AnalysisStatus();

            pAnalysisStatus.Detail = base.UpdateTranslation(pAnalysisStatus.Detail);

            analysisStatus = new AnalysisStatus(pAnalysisStatus.AnalysisStatusID);
            analysisStatus.Detail = new Translation(pAnalysisStatus.Detail.TranslationID);
            analysisStatus.Detail.Alias = pAnalysisStatus.Detail.Alias;
            analysisStatus.Detail.Description = pAnalysisStatus.Detail.Description;
            analysisStatus.Detail.Name = pAnalysisStatus.Detail.Name;

            return analysisStatus;
        }

        public AnalysisStatus Delete(AnalysisStatus pAnalysisStatus)
        {
            AnalysisStatus analysisStatus = new AnalysisStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStatusID", pAnalysisStatus.AnalysisStatusID));

                    sqlCommand.ExecuteNonQuery();

                    analysisStatus = new AnalysisStatus(pAnalysisStatus.AnalysisStatusID);
                    base.DeleteAllTranslations(pAnalysisStatus.Detail);
                }
                catch (Exception exc)
                {
                    analysisStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisStatus;
        }
    }
}
