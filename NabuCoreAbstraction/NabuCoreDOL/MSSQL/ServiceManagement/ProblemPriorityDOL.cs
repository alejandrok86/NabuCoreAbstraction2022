using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ProblemPriorityDOL : BaseDOL
    {
        public ProblemPriorityDOL() : base()
        {
        }

        public ProblemPriorityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority Get(int pProblemPriorityID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemPriority_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemPriorityID", pProblemPriorityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(0));
                        problemPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemPriority_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(0));
                        problemPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority> problemPrioritys = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemPriority_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(0));
                        problemPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        problemPrioritys.Add(problemPriority);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();
                    problemPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    problemPrioritys.Add(problemPriority);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemPrioritys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority pProblemPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemPriority_Insert]");
                try
                {
                    pProblemPriority.Detail = base.InsertTranslation(pProblemPriority.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProblemPriority.Detail.TranslationID));
                    SqlParameter problemPriorityID = sqlCommand.Parameters.Add("@ProblemPriorityID", SqlDbType.Int);
                    problemPriorityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority((Int32)problemPriorityID.Value);
                    problemPriority.Detail = new Translation(pProblemPriority.Detail.TranslationID);
                    problemPriority.Detail.Alias = pProblemPriority.Detail.Alias;
                    problemPriority.Detail.Description = pProblemPriority.Detail.Description;
                    problemPriority.Detail.Name = pProblemPriority.Detail.Name;
                }
                catch (Exception exc)
                {
                    problemPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority pProblemPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();

            pProblemPriority.Detail = base.UpdateTranslation(pProblemPriority.Detail);

            problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority(pProblemPriority.ProblemPriorityID);
            problemPriority.Detail = new Translation(pProblemPriority.Detail.TranslationID);
            problemPriority.Detail.Alias = pProblemPriority.Detail.Alias;
            problemPriority.Detail.Description = pProblemPriority.Detail.Description;
            problemPriority.Detail.Name = pProblemPriority.Detail.Name;

            return problemPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority pProblemPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemPriority_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemPriorityID", pProblemPriority.ProblemPriorityID));

                    sqlCommand.ExecuteNonQuery();

                    problemPriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemPriority(pProblemPriority.ProblemPriorityID);
                    base.DeleteAllTranslations(pProblemPriority.Detail);
                }
                catch (Exception exc)
                {
                    problemPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemPriority;
        }
    }
}

