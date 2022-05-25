using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class AssumptionStatusDOL : BaseDOL
    {
        public AssumptionStatusDOL() : base()
        {
        }

        public AssumptionStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AssumptionStatus Get(int pAssumptionStatusID, int pLanguageID)
        {
            AssumptionStatus assumptionStatus = new AssumptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionStatusID", pAssumptionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assumptionStatus = new AssumptionStatus(sqlDataReader.GetInt32(0));
                        assumptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assumptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionStatus;
        }

        public AssumptionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            AssumptionStatus assumptionStatus = new AssumptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assumptionStatus = new AssumptionStatus(sqlDataReader.GetInt32(0));
                        assumptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assumptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionStatus;
        }

        public AssumptionStatus[] List(int pLanguageID)
        {
            List<AssumptionStatus> assumptionStatuss = new List<AssumptionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssumptionStatus assumptionStatus = new AssumptionStatus(sqlDataReader.GetInt32(0));
                        assumptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        assumptionStatuss.Add(assumptionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssumptionStatus assumptionStatus = new AssumptionStatus();
                    assumptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assumptionStatuss.Add(assumptionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionStatuss.ToArray();
        }

        public AssumptionStatus Insert(AssumptionStatus pAssumptionStatus)
        {
            AssumptionStatus assumptionStatus = new AssumptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionStatus_Insert]");
                try
                {
                    pAssumptionStatus.Detail = base.InsertTranslation(pAssumptionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAssumptionStatus.Detail.TranslationID));
                    SqlParameter assumptionStatusID = sqlCommand.Parameters.Add("@AssumptionStatusID", SqlDbType.Int);
                    assumptionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assumptionStatus = new AssumptionStatus((Int32)assumptionStatusID.Value);
                    assumptionStatus.Detail = new Translation(pAssumptionStatus.Detail.TranslationID);
                    assumptionStatus.Detail.Alias = pAssumptionStatus.Detail.Alias;
                    assumptionStatus.Detail.Description = pAssumptionStatus.Detail.Description;
                    assumptionStatus.Detail.Name = pAssumptionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    assumptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionStatus;
        }

        public AssumptionStatus Update(AssumptionStatus pAssumptionStatus)
        {
            AssumptionStatus assumptionStatus = new AssumptionStatus();

            pAssumptionStatus.Detail = base.UpdateTranslation(pAssumptionStatus.Detail);

            assumptionStatus = new AssumptionStatus(pAssumptionStatus.AssumptionStatusID);
            assumptionStatus.Detail = new Translation(pAssumptionStatus.Detail.TranslationID);
            assumptionStatus.Detail.Alias = pAssumptionStatus.Detail.Alias;
            assumptionStatus.Detail.Description = pAssumptionStatus.Detail.Description;
            assumptionStatus.Detail.Name = pAssumptionStatus.Detail.Name;

            return assumptionStatus;
        }

        public AssumptionStatus Delete(AssumptionStatus pAssumptionStatus)
        {
            AssumptionStatus assumptionStatus = new AssumptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[AssumptionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionStatusID", pAssumptionStatus.AssumptionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    assumptionStatus = new AssumptionStatus(pAssumptionStatus.AssumptionStatusID);
                    base.DeleteAllTranslations(pAssumptionStatus.Detail);
                }
                catch (Exception exc)
                {
                    assumptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptionStatus;
        }
    }
}
