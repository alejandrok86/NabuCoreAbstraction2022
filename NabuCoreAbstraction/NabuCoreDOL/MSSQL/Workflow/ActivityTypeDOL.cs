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
    public class ActivityTypeDOL : BaseDOL
    {
        public ActivityTypeDOL() : base()
        {
        }

        public ActivityTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType Get(int pActivityTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityTypeID", pActivityTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType(sqlDataReader.GetInt32(0));
                        activityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    activityType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType> activityTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType(sqlDataReader.GetInt32(0));
                        activityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activityTypes.Add(activityType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType();
                    activityType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    activityTypes.Add(activityType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType Insert(Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType pActivityType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityType_Insert]");
                try
                {
                    pActivityType.Detail = base.InsertTranslation(pActivityType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pActivityType.Detail.TranslationID));
                    SqlParameter activityTypeID = sqlCommand.Parameters.Add("@ActivityTypeID", SqlDbType.Int);
                    activityTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType((Int32)activityTypeID.Value);
                    activityType.Detail = new Translation(pActivityType.Detail.TranslationID);
                    activityType.Detail.Alias = pActivityType.Detail.Alias;
                    activityType.Detail.Description = pActivityType.Detail.Description;
                    activityType.Detail.Name = pActivityType.Detail.Name;
                }
                catch (Exception exc)
                {
                    activityType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType Update(Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType pActivityType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType();

            pActivityType.Detail = base.UpdateTranslation(pActivityType.Detail);

            activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType(pActivityType.ActivityTypeID);
            activityType.Detail = new Translation(pActivityType.Detail.TranslationID);
            activityType.Detail.Alias = pActivityType.Detail.Alias;
            activityType.Detail.Description = pActivityType.Detail.Description;
            activityType.Detail.Name = pActivityType.Detail.Name;

            return activityType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType Delete(Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType pActivityType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[ActivityType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityTypeID", pActivityType.ActivityTypeID));

                    sqlCommand.ExecuteNonQuery();

                    activityType = new Octavo.Gate.Nabu.CORE.Entities.Workflow.ActivityType(pActivityType.ActivityTypeID);
                    base.DeleteAllTranslations(pActivityType.Detail);
                }
                catch (Exception exc)
                {
                    activityType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activityType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activityType;
        }
    }
}
