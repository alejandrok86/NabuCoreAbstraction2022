using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class IterationDOL : BaseDOL
    {
        public IterationDOL() : base()
        {
        }

        public IterationDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Development.Iteration Get(int? pIterationID)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        iteration = new Entities.Development.Iteration(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
		                    iteration.Duration = new Entities.Planning.Duration(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            iteration.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            iteration.Status = new Entities.Development.IterationStatus(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            iteration.Type = new Entities.Development.IterationType(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration[] List(int pProjectID)
        {
            List<Entities.Development.Iteration> iterations = new List<Entities.Development.Iteration>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Iteration iteration = new Entities.Development.Iteration(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            iteration.Duration = new Entities.Planning.Duration(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            iteration.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            iteration.Status = new Entities.Development.IterationStatus(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            iteration.Type = new Entities.Development.IterationType(sqlDataReader.GetInt32(4));
                        iterations.Add(iteration);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Iteration iteration = new Entities.Development.Iteration();
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    iterations.Add(iteration);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterations.ToArray();
        }

        public Entities.Development.Iteration Insert(Entities.Development.Iteration pIteration, int? pProjectID)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pIteration.Duration.DurationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationName", pIteration.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationStatusID", pIteration.Status.IterationStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationTypeID", pIteration.Type.IterationTypeID));
                    SqlParameter iterationID = sqlCommand.Parameters.Add("@IterationID", SqlDbType.Int);
                    iterationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration((Int32)iterationID.Value);
                    iteration.Duration = pIteration.Duration;
                    iteration.Name = pIteration.Name;
                    iteration.Status = pIteration.Status;
                    iteration.Type = pIteration.Type;
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration Update(Entities.Development.Iteration pIteration, int? pProjectID)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pIteration.Duration.DurationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationName", pIteration.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationStatusID", pIteration.Status.IterationStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationTypeID", pIteration.Type.IterationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration(pIteration.IterationID);
                    iteration.Duration = pIteration.Duration;
                    iteration.Name = pIteration.Name;
                    iteration.Status = pIteration.Status;
                    iteration.Type = pIteration.Type;
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration Update(Entities.Development.Iteration pIteration)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_UpdateSimple]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pIteration.Duration.DurationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationName", pIteration.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationStatusID", pIteration.Status.IterationStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationTypeID", pIteration.Type.IterationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration(pIteration.IterationID);
                    iteration.Duration = pIteration.Duration;
                    iteration.Name = pIteration.Name;
                    iteration.Status = pIteration.Status;
                    iteration.Type = pIteration.Type;
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration Delete(Entities.Development.Iteration pIteration)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Iteration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration(pIteration.IterationID);
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration Assign(Entities.Development.Iteration pIteration, Entities.Content.Content pContent)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration(pIteration.IterationID);
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }

        public Entities.Development.Iteration Remove(Entities.Development.Iteration pIteration, Entities.Content.Content pContent)
        {
            Entities.Development.Iteration iteration = new Entities.Development.Iteration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    iteration = new Entities.Development.Iteration(pIteration.IterationID);
                }
                catch (Exception exc)
                {
                    iteration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iteration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iteration;
        }
    }
}


