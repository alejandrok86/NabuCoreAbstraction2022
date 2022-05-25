using Octavo.Gate.Nabu.CORE.Entities.Error;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ResponseProgressDOL : BaseDOL
    {
        public ResponseProgressDOL() : base()
        {
        }

        public ResponseProgressDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseDecimal Get(Octavo.Gate.Nabu.CORE.Entities.Response.LearnerSubscriptionProgress pLearnerSubscriptionProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseDecimal result = new Octavo.Gate.Nabu.CORE.Entities.BaseDecimal(0);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearnerSubscriptionProgress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pLearnerSubscriptionProgress.LearnerSubscriptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        result.Value = sqlDataReader.GetDecimal(0);
                    sqlDataReader.Close();
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
        public Octavo.Gate.Nabu.CORE.Entities.BaseDecimal Get(Octavo.Gate.Nabu.CORE.Entities.Response.ModuleProgress pModuleProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseDecimal result = new Octavo.Gate.Nabu.CORE.Entities.BaseDecimal(0);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ModuleProgress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pModuleProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleProgress.ModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        result.Value = sqlDataReader.GetDecimal(0);
                    sqlDataReader.Close();
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
        public Octavo.Gate.Nabu.CORE.Entities.BaseDecimal Get(Octavo.Gate.Nabu.CORE.Entities.Response.UnitProgress pUnitProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseDecimal result = new Octavo.Gate.Nabu.CORE.Entities.BaseDecimal(0);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[UnitProgress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pUnitProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pUnitProgress.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitProgress.UnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        result.Value = sqlDataReader.GetDecimal(0);
                    sqlDataReader.Close();
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
        public Octavo.Gate.Nabu.CORE.Entities.BaseDecimal Get(Octavo.Gate.Nabu.CORE.Entities.Response.UnitComponentProgress pUnitComponentProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseDecimal result = new Octavo.Gate.Nabu.CORE.Entities.BaseDecimal(0);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[UnitComponentProgress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pUnitComponentProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pUnitComponentProgress.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitComponentProgress.UnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitComponentID", pUnitComponentProgress.UnitComponentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        result.Value = sqlDataReader.GetDecimal(0);
                    sqlDataReader.Close();
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

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean Update(Octavo.Gate.Nabu.CORE.Entities.Response.LearnerSubscriptionProgress pLearnerSubscriptionProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearnerSubscriptionProgress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pLearnerSubscriptionProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageProgress", pLearnerSubscriptionProgress.Value));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@LearnerSubscriptionID: " + pLearnerSubscriptionProgress.LearnerSubscriptionID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@PercentageProgress: " + pLearnerSubscriptionProgress.Value);

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
        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean Update(Octavo.Gate.Nabu.CORE.Entities.Response.ModuleProgress pModuleProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ModuleProgress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pModuleProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleProgress.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageProgress", pModuleProgress.Value));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@LearnerSubscriptionID: " + pModuleProgress.LearnerSubscriptionID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@ModuleID: " + pModuleProgress.ModuleID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@PercentageProgress: " + pModuleProgress.Value);

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
        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean Update(Octavo.Gate.Nabu.CORE.Entities.Response.UnitProgress pUnitProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[UnitProgress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pUnitProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pUnitProgress.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitProgress.UnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageProgress", pUnitProgress.Value));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@LearnerSubscriptionID: " + pUnitProgress.LearnerSubscriptionID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@ModuleID: " + pUnitProgress.ModuleID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@UnitID: " + pUnitProgress.UnitID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@PercentageProgress: " + pUnitProgress.Value);

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
        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean Update(Octavo.Gate.Nabu.CORE.Entities.Response.UnitComponentProgress pUnitComponentProgress)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[UnitComponentProgress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pUnitComponentProgress.LearnerSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pUnitComponentProgress.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitComponentProgress.UnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitComponentID", pUnitComponentProgress.UnitComponentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageProgress", pUnitComponentProgress.Value));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@LearnerSubscriptionID: " + pUnitComponentProgress.LearnerSubscriptionID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@ModuleID: " + pUnitComponentProgress.ModuleID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@UnitID: " + pUnitComponentProgress.UnitID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@UnitComponentID: " + pUnitComponentProgress.UnitComponentID);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@PercentageProgress: " + pUnitComponentProgress.Value);

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

