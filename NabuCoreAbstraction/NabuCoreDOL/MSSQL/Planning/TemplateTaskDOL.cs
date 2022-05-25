using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class TemplateTaskDOL : BaseDOL
    {
        public TemplateTaskDOL() : base()
        {
        }

        public TemplateTaskDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TemplateTask Get(int? pTemplateTaskID)
        {
            TemplateTask templateTask = new TemplateTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TemplateTaskID", pTemplateTaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        templateTask = new TemplateTask(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            templateTask.TaskName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            templateTask.ExpectedDurationDays = sqlDataReader.GetDouble(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            templateTask.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTask;
        }

        public TemplateTask[] List(int pTemplateID)
        {
            List<TemplateTask> templateTasks = new List<TemplateTask>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TemplateID", pTemplateID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TemplateTask templateTask = new TemplateTask(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            templateTask.TaskName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            templateTask.ExpectedDurationDays = sqlDataReader.GetDouble(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            templateTask.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(3));
                        templateTasks.Add(templateTask);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TemplateTask templateTask = new TemplateTask();
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    templateTasks.Add(templateTask);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTasks.ToArray();
        }

        public TemplateTask[] ListChildren(int pParentTemplateTaskID)
        {
            List<TemplateTask> templateTasks = new List<TemplateTask>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentTemplateTaskID", pParentTemplateTaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TemplateTask templateTask = new TemplateTask(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            templateTask.TaskName = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            templateTask.ExpectedDurationDays = sqlDataReader.GetDouble(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            templateTask.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(3));
                        templateTasks.Add(templateTask);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TemplateTask templateTask = new TemplateTask();
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    templateTasks.Add(templateTask);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTasks.ToArray();
        }

        public TemplateTask Insert(TemplateTask pTemplateTask, int pTemplateID, int? pParentTemplateTaskID)
        {
            TemplateTask templateTask = new TemplateTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TemplateID", pTemplateID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskName", templateTask.TaskName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ExpectedDurationDays", templateTask.ExpectedDurationDays));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", templateTask.DeliverableType));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentTemplateTaskID", pParentTemplateTaskID));
                    SqlParameter templateTaskID = sqlCommand.Parameters.Add("@TemplateTaskID", SqlDbType.Int);
                    templateTaskID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    templateTask = new TemplateTask((Int32)templateTaskID.Value);
                    templateTask.TaskName = pTemplateTask.TaskName;
                    templateTask.ExpectedDurationDays = pTemplateTask.ExpectedDurationDays;
                    templateTask.DeliverableType = pTemplateTask.DeliverableType;
                }
                catch (Exception exc)
                {
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTask;
        }

        public TemplateTask Update(TemplateTask pTemplateTask, int pTemplateID, int? pParentTemplateTaskID)
        {
            TemplateTask templateTask = new TemplateTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TemplateID", pTemplateID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskName", templateTask.TaskName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ExpectedDurationDays", templateTask.ExpectedDurationDays));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", templateTask.DeliverableType));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentTemplateTaskID", pParentTemplateTaskID));

                    sqlCommand.ExecuteNonQuery();

                    templateTask = new TemplateTask(pTemplateTask.TemplateTaskID);
                    templateTask.TaskName = pTemplateTask.TaskName;
                    templateTask.ExpectedDurationDays = pTemplateTask.ExpectedDurationDays;
                    templateTask.DeliverableType = pTemplateTask.DeliverableType;
                }
                catch (Exception exc)
                {
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTask;
        }

        public TemplateTask Delete(TemplateTask pTemplateTask)
        {
            TemplateTask templateTask = new TemplateTask();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TemplateTask_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TemplateTaskID", pTemplateTask.TemplateTaskID));

                    sqlCommand.ExecuteNonQuery();

                    templateTask = new TemplateTask(pTemplateTask.TemplateTaskID);
                }
                catch (Exception exc)
                {
                    templateTask.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    templateTask.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return templateTask;
        }
    }
}

