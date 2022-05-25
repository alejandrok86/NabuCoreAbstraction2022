using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class DeliverableDOL : BaseDOL
    {
        public DeliverableDOL() : base()
        {
        }

        public DeliverableDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Deliverable Get(int? pDeliverableID, Entities.Planning.Project pProject)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pDeliverableID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Project ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Get(int? pDeliverableID, Entities.Planning.Programme pProgramme)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverable_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pDeliverableID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Programme ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Get(int? pDeliverableID, Entities.Planning.Task pTask)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverable_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pDeliverableID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Task ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable[] List(Entities.Planning.Project pProject)
        {
            List<Deliverable> deliverables = new List<Deliverable>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pProject.ProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Deliverable deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Project ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Deliverable deliverable = new Deliverable();
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    deliverables.Add(deliverable);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverables.ToArray();
        }

        public Deliverable[] List(Entities.Planning.Programme pProgramme)
        {
            List<Deliverable> deliverables = new List<Deliverable>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverable_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pProgramme.ProgrammeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Deliverable deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Programme ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Deliverable deliverable = new Deliverable();
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    deliverables.Add(deliverable);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverables.ToArray();
        }

        public Deliverable[] List(Entities.Planning.Task pTask)
        {
            List<Deliverable> deliverables = new List<Deliverable>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverable_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pTask.TaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Deliverable deliverable = new Deliverable(sqlDataReader.GetInt32(0));
                        //if (sqlDataReader.IsDBNull(1) == false)
                        //    deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(1));  // Programme ID
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            deliverable.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(2) == false)
                            deliverable.DeliverableType = new DeliverableType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Deliverable deliverable = new Deliverable();
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    deliverables.Add(deliverable);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverables.ToArray();
        }

        public Deliverable Insert(Deliverable pDeliverable, Programme pProgramme)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverable_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));
                    SqlParameter deliverableID = sqlCommand.Parameters.Add("@ProgrammeDeliverableID", SqlDbType.Int);
                    deliverableID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable((Int32)deliverableID.Value);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Insert(Deliverable pDeliverable, Entities.Planning.Project pProject)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));
                    SqlParameter deliverableID = sqlCommand.Parameters.Add("@ProjectDeliverableID", SqlDbType.Int);
                    deliverableID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable((Int32)deliverableID.Value);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Insert(Deliverable pDeliverable, Entities.Planning.Task pTask)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));
                    SqlParameter deliverableID = sqlCommand.Parameters.Add("@TaskDeliverableID", SqlDbType.Int);
                    deliverableID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable((Int32)deliverableID.Value);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Update(Deliverable pDeliverable, Programme pProgramme)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverable_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Update(Deliverable pDeliverable, Entities.Planning.Project pProject)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Update(Deliverable pDeliverable, Entities.Planning.Task pTask)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverable_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableName", deliverable.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableDescription", deliverable.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableType", deliverable.DeliverableType.DeliverableTypeID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                    deliverable.ContentItems = pDeliverable.ContentItems;
                    deliverable.DeliverableType = pDeliverable.DeliverableType;
                    deliverable.Description = pDeliverable.Description;
                    deliverable.Name = pDeliverable.Name;
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Delete(Deliverable pDeliverable, Programme pProgramme)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverable_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pDeliverable.DeliverableID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Delete(Deliverable pDeliverable, Entities.Planning.Project pProject)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverable_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pDeliverable.DeliverableID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Deliverable Delete(Deliverable pDeliverable, Entities.Planning.Task pTask)
        {
            Deliverable deliverable = new Deliverable();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverable_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pDeliverable.DeliverableID));

                    sqlCommand.ExecuteNonQuery();

                    deliverable = new Deliverable(pDeliverable.DeliverableID);
                }
                catch (Exception exc)
                {
                    deliverable.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverable.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverable;
        }

        public Entities.BaseBoolean Assign(Deliverable pDeliverable, Entities.Planning.Task pTask, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverableContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

        public Entities.BaseBoolean Assign(Deliverable pDeliverable, Entities.Planning.Project pProject, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverableContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

        public Entities.BaseBoolean Assign(Deliverable pDeliverable, Entities.Planning.Programme pProgramme, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverableContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

        public Entities.BaseBoolean Remove(Deliverable pDeliverable, Entities.Planning.Project pProject, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectDeliverableContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

        public Entities.BaseBoolean Remove(Deliverable pDeliverable, Entities.Planning.Programme pProgramme, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeDeliverableContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

        public Entities.BaseBoolean Remove(Deliverable pDeliverable, Entities.Planning.Task pTask, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[TaskDeliverableContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskDeliverableID", pDeliverable.DeliverableID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

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

