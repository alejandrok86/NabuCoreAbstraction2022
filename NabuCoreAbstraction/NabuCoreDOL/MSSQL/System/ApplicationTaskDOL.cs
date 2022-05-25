using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class ApplicationTaskDOL : BaseDOL
    {
        public ApplicationTaskDOL() : base ()
        {
        }

        public ApplicationTaskDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ApplicationTask Get(int pApplicationTaskID, int pLanguageID)
        {
            ApplicationTask applicationTask = new ApplicationTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTask_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTaskID", pApplicationTaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        applicationTask = new ApplicationTask(sqlDataReader.GetInt32(0));
                        applicationTask.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        applicationTask.FunctionalArea = new FunctionalArea(sqlDataReader.GetInt32(2));
                        applicationTask.FunctionalArea.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    applicationTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTask;
        }

        public ApplicationTask[] List(int pLanguageID)
        {
            List<ApplicationTask> applicationTasks = new List<ApplicationTask>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTask_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ApplicationTask applicationTask = new ApplicationTask(sqlDataReader.GetInt32(0));
                        applicationTask.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        applicationTask.FunctionalArea = new FunctionalArea(sqlDataReader.GetInt32(2));
                        applicationTask.FunctionalArea.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        applicationTasks.Add(applicationTask);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ApplicationTask applicationTask = new ApplicationTask();
                    applicationTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    applicationTasks.Add(applicationTask);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTasks.ToArray();
        }

        public ApplicationTask Insert(ApplicationTask pApplicationTask)
        {
            ApplicationTask applicationTask = new ApplicationTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTask_Insert]");
                try
                {
                    pApplicationTask.Detail = base.InsertTranslation(pApplicationTask.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FunctionalAreaID", pApplicationTask.FunctionalArea.FunctionalAreaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pApplicationTask.Detail.TranslationID));
                    SqlParameter applicationTaskID = sqlCommand.Parameters.Add("@ApplicationTaskID", SqlDbType.Int);
                    applicationTaskID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    applicationTask = new ApplicationTask((Int32)applicationTaskID.Value);
                    applicationTask.Detail = new Translation(pApplicationTask.Detail.TranslationID);
                    applicationTask.FunctionalArea = new FunctionalArea(pApplicationTask.FunctionalArea.FunctionalAreaID);
                }
                catch (Exception exc)
                {
                    applicationTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTask;
        }

        public ApplicationTask Update(ApplicationTask pApplicationTask)
        {
            ApplicationTask applicationTask = new ApplicationTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTask_Update]");
                try
                {
                    base.UpdateTranslation(pApplicationTask.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTaskID",pApplicationTask.ApplicationTaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FunctionalAreaID", pApplicationTask.FunctionalArea.FunctionalAreaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pApplicationTask.Detail.TranslationID));

                    sqlCommand.ExecuteNonQuery();

                    applicationTask = new ApplicationTask(pApplicationTask.ApplicationTaskID);
                    applicationTask.Detail = new Translation(pApplicationTask.Detail.TranslationID);
                    applicationTask.FunctionalArea = new FunctionalArea(pApplicationTask.FunctionalArea.FunctionalAreaID);
                }
                catch (Exception exc)
                {
                    applicationTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTask;
        }

        public ApplicationTask Delete(ApplicationTask pApplicationTask)
        {
            ApplicationTask applicationTask = new ApplicationTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTask_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTaskID", pApplicationTask.ApplicationTaskID));

                    sqlCommand.ExecuteNonQuery();

                    applicationTask = new ApplicationTask(pApplicationTask.ApplicationTaskID);
                    base.DeleteAllTranslations(pApplicationTask.Detail);
                }
                catch (Exception exc)
                {
                    applicationTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTask;
        }
    }
}
