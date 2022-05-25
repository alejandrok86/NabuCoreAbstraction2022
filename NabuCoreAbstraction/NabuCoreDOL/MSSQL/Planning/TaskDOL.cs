using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class TaskDOL : BaseDOL
    {
        public TaskDOL() : base()
        {
        }

        public TaskDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Task Get(int? pTaskID)
        {
            Task task = new Task();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        task = new Task(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            task.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            task.TaskOwner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            task.Duration = new Duration(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            task.PercentComplete = sqlDataReader.GetDouble(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            task.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return task;
        }

        public Task[] List(int pProjectID)
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Task task = new Task(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            task.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            task.TaskOwner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            task.Duration = new Duration(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            task.PercentComplete = sqlDataReader.GetDouble(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            task.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(5));
                        tasks.Add(task);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Task task = new Task();
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tasks.Add(task);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tasks.ToArray();
        }

        public Task[] ListChildren(int pTaskID)
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Task task = new Task(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            task.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            task.TaskOwner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            task.Duration = new Duration(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            task.PercentComplete = sqlDataReader.GetDouble(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            task.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(5));
                        tasks.Add(task);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Task task = new Task();
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tasks.Add(task);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tasks.ToArray();
        }

        public Task Insert(Task pTask, int pProjectID, int? pParentTaskID)
        {
            Task task = new Task();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", task.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskOwner", task.TaskOwner));
                    sqlCommand.Parameters.Add(new SqlParameter("@Duration", task.Duration));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentComplete", task.PercentComplete));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentTaskID", pParentTaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", task.DeliverableType));
                    SqlParameter taskID = sqlCommand.Parameters.Add("@TaskID", SqlDbType.Int);
                    taskID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    task = new Task((Int32)taskID.Value);
                    task.Name = pTask.Name;
                    task.TaskOwner = pTask.TaskOwner;
                    task.Duration = pTask.Duration;
                    task.PercentComplete = pTask.PercentComplete;
                    task.DeliverableType = pTask.DeliverableType;
                }
                catch (Exception exc)
                {
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return task;
        }

        public Task Update(Task pTask, int pProjectID, int? pParentTaskID)
        {
            Task task = new Task();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", task.TaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", task.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskOwner", task.TaskOwner));
                    sqlCommand.Parameters.Add(new SqlParameter("@Duration", task.Duration));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentComplete", task.PercentComplete));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentTaskID", pParentTaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", task.DeliverableType));

                    sqlCommand.ExecuteNonQuery();

                    task = new Task(pTask.TaskID);
                    task.Name = pTask.Name;
                    task.TaskOwner = pTask.TaskOwner;
                    task.Duration = pTask.Duration;
                    task.PercentComplete = pTask.PercentComplete;
                    task.DeliverableType = pTask.DeliverableType;
                }
                catch (Exception exc)
                {
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return task;
        }

        public Task Delete(Task pTask)
        {
            Task task = new Task();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));

                    sqlCommand.ExecuteNonQuery();

                    task = new Task(pTask.TaskID);
                }
                catch (Exception exc)
                {
                    task.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    task.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return task;
        }

        public Entities.BaseBoolean AssignResource(Task pTask, Entities.Core.Party pParty)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_AssignResource]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pParty.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Entities.BaseBoolean RemoveResource(Task pTask, Entities.Core.Party pParty)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Task_RemoveResource]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pParty.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}

