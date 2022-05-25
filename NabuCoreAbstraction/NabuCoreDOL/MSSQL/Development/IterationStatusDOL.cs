using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class IterationStatusDOL : BaseDOL
    {
        public IterationStatusDOL() : base()
        {
        }

        public IterationStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus Get(int pIterationStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationStatusID", pIterationStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus(sqlDataReader.GetInt32(0));
                        iterationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    iterationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus(sqlDataReader.GetInt32(0));
                        iterationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    iterationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus> iterationStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus(sqlDataReader.GetInt32(0));
                        iterationStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        iterationStatuss.Add(iterationStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();
                    iterationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    iterationStatuss.Add(iterationStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus Insert(Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus pIterationStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationStatus_Insert]");
                try
                {
                    pIterationStatus.Detail = base.InsertTranslation(pIterationStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIterationStatus.Detail.TranslationID));
                    SqlParameter iterationStatusID = sqlCommand.Parameters.Add("@IterationStatusID", SqlDbType.Int);
                    iterationStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus((Int32)iterationStatusID.Value);
                    iterationStatus.Detail = new Translation(pIterationStatus.Detail.TranslationID);
                    iterationStatus.Detail.Alias = pIterationStatus.Detail.Alias;
                    iterationStatus.Detail.Description = pIterationStatus.Detail.Description;
                    iterationStatus.Detail.Name = pIterationStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    iterationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus Update(Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus pIterationStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();

            pIterationStatus.Detail = base.UpdateTranslation(pIterationStatus.Detail);

            iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus(pIterationStatus.IterationStatusID);
            iterationStatus.Detail = new Translation(pIterationStatus.Detail.TranslationID);
            iterationStatus.Detail.Alias = pIterationStatus.Detail.Alias;
            iterationStatus.Detail.Description = pIterationStatus.Detail.Description;
            iterationStatus.Detail.Name = pIterationStatus.Detail.Name;

            return iterationStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus Delete(Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus pIterationStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationStatusID", pIterationStatus.IterationStatusID));

                    sqlCommand.ExecuteNonQuery();

                    iterationStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationStatus(pIterationStatus.IterationStatusID);
                    base.DeleteAllTranslations(pIterationStatus.Detail);
                }
                catch (Exception exc)
                {
                    iterationStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationStatus;
        }
    }
}

