using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ProblemStatusDOL : BaseDOL
    {
        public ProblemStatusDOL() : base()
        {
        }

        public ProblemStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus Get(int pProblemStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemStatusID", pProblemStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(0));
                        problemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(0));
                        problemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus> problemStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(0));
                        problemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        problemStatuss.Add(problemStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();
                    problemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    problemStatuss.Add(problemStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus pProblemStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemStatus_Insert]");
                try
                {
                    pProblemStatus.Detail = base.InsertTranslation(pProblemStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProblemStatus.Detail.TranslationID));
                    SqlParameter problemStatusID = sqlCommand.Parameters.Add("@ProblemStatusID", SqlDbType.Int);
                    problemStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus((Int32)problemStatusID.Value);
                    problemStatus.Detail = new Translation(pProblemStatus.Detail.TranslationID);
                    problemStatus.Detail.Alias = pProblemStatus.Detail.Alias;
                    problemStatus.Detail.Description = pProblemStatus.Detail.Description;
                    problemStatus.Detail.Name = pProblemStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    problemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus pProblemStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();

            pProblemStatus.Detail = base.UpdateTranslation(pProblemStatus.Detail);

            problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus(pProblemStatus.ProblemStatusID);
            problemStatus.Detail = new Translation(pProblemStatus.Detail.TranslationID);
            problemStatus.Detail.Alias = pProblemStatus.Detail.Alias;
            problemStatus.Detail.Description = pProblemStatus.Detail.Description;
            problemStatus.Detail.Name = pProblemStatus.Detail.Name;

            return problemStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus pProblemStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemStatusID", pProblemStatus.ProblemStatusID));

                    sqlCommand.ExecuteNonQuery();

                    problemStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemStatus(pProblemStatus.ProblemStatusID);
                    base.DeleteAllTranslations(pProblemStatus.Detail);
                }
                catch (Exception exc)
                {
                    problemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemStatus;
        }
    }
}

