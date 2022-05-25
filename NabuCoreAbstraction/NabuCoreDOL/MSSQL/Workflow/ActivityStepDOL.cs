using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow
{
    public class ActivityStepDOL : BaseDOL
    {
        public ActivityStepDOL() : base()
        {
        }

        public ActivityStepDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ActivityStep Get(int pActivityStepID, int pLanguageID)
        {
            ActivityStep activityStep = new ActivityStep();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityStep_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStepID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        activityStep = new ActivityStep(sqlDataReader.GetInt32(0));
                        activityStep.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activityStep.IsStartingStep = sqlDataReader.GetBoolean(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    activityStep.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityStep.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityStep;
        }

        public ActivityStep[] List(int pActivityID, int pLanguageID)
        {
            List<ActivityStep> activitySteps = new List<ActivityStep>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityStep_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ActivityStep activityStep = new ActivityStep(sqlDataReader.GetInt32(0));
                        activityStep.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activityStep.IsStartingStep = sqlDataReader.GetBoolean(2);
                        activitySteps.Add(activityStep);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ActivityStep activityStep = new ActivityStep();
                    activityStep.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityStep.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    activitySteps.Add(activityStep);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activitySteps.ToArray();
        }

        public ActivityStep Insert(ActivityStep pActivityStep, int? pActivityID)
        {
            ActivityStep activityStep = new ActivityStep();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityStep_Insert]");
                try
                {
                    pActivityStep.Detail = base.InsertTranslation(pActivityStep.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pActivityStep.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsStartingStep", pActivityStep.IsStartingStep));
                    SqlParameter activityStepID = sqlCommand.Parameters.Add("@ActivityStepID", SqlDbType.Int);
                    activityStepID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    activityStep = new ActivityStep((Int32)activityStepID.Value);
                    activityStep.Detail = new Translation(pActivityStep.Detail.TranslationID);
                    activityStep.Detail.Alias = pActivityStep.Detail.Alias;
                    activityStep.IsStartingStep = pActivityStep.IsStartingStep;
                }
                catch (Exception exc)
                {
                    activityStep.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityStep.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityStep;
        }

        public ActivityStep Update(ActivityStep pActivityStep, int? pActivityID)
        {
            ActivityStep activityStep = new ActivityStep();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityStep_Update]");
                try
                {
                    pActivityStep.Detail = base.UpdateTranslation(pActivityStep.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStep.ActivityStepID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsStartingStep", pActivityStep.IsStartingStep));

                    sqlCommand.ExecuteNonQuery();

                    activityStep = new ActivityStep(pActivityStep.ActivityStepID);
                    activityStep.Detail = new Translation(pActivityStep.Detail.TranslationID);
                    activityStep.Detail.Alias = pActivityStep.Detail.Alias;
                    activityStep.IsStartingStep = pActivityStep.IsStartingStep;
                }
                catch (Exception exc)
                {
                    activityStep.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityStep.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityStep;
        }

        public ActivityStep Delete(ActivityStep pActivityStep)
        {
            ActivityStep activityStep = new ActivityStep();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityStep_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStep.ActivityStepID));

                    sqlCommand.ExecuteNonQuery();

                    activityStep = new ActivityStep(pActivityStep.ActivityStepID);
                    base.DeleteAllTranslations(pActivityStep.Detail);
                }
                catch (Exception exc)
                {
                    activityStep.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityStep.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityStep;
        }
    }
}
