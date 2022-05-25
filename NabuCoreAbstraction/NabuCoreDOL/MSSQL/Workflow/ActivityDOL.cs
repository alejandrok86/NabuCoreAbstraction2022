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
    public class ActivityDOL : BaseDOL
    {
        public ActivityDOL() : base()
        {
        }

        public ActivityDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Activity Get(int pActivityID, int pLanguageID)
        {
            Activity activity = new Activity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        activity = new Activity(sqlDataReader.GetInt32(0));
                        activity.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activity.ActivityType = new ActivityType(sqlDataReader.GetInt32(2));
                        activity.ActivityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        activity.Priority = sqlDataReader.GetFloat(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            activity.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activity;
        }

        public Activity[] List(int pLanguageID)
        {
            List<Activity> activitys = new List<Activity>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Activity activity = new Activity(sqlDataReader.GetInt32(0));
                        activity.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activity.ActivityType = new ActivityType(sqlDataReader.GetInt32(2));
                        activity.ActivityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        activity.Priority = sqlDataReader.GetFloat(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            activity.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(5));
                        activitys.Add(activity);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Activity activity = new Activity();
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    activitys.Add(activity);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activitys.ToArray();
        }

        public Activity[] ListChildren(int pParentActivityID, int pLanguageID)
        {
            List<Activity> activitys = new List<Activity>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentActivityID", pParentActivityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Activity activity = new Activity(sqlDataReader.GetInt32(0));
                        activity.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        activity.ActivityType = new ActivityType(sqlDataReader.GetInt32(2));
                        activity.ActivityType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        activity.Priority = sqlDataReader.GetFloat(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            activity.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(5));
                        activitys.Add(activity);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Activity activity = new Activity();
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    activitys.Add(activity);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activitys.ToArray();
        }

        public Activity Insert(Activity pActivity, int? pParentActivityID)
        {
            Activity activity = new Activity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_Insert]");
                try
                {
                    pActivity.Detail = base.InsertTranslation(pActivity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pActivity.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityTypeID", pActivity.ActivityType.ActivityTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pActivity.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pActivity.Attributes != null) ? ((pActivity.Attributes.ToXMLFragment().Length > 0) ? pActivity.Attributes.ToXMLFragment() : null) : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentActivityID", pParentActivityID));
                    SqlParameter activityID = sqlCommand.Parameters.Add("@ActivityID", SqlDbType.Int);
                    activityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    activity = new Activity((Int32)activityID.Value);
                    activity.Detail = new Translation(pActivity.Detail.TranslationID);
                    activity.Detail.Alias = pActivity.Detail.Alias;
                    activity.ActivityType = new ActivityType(pActivity.ActivityType.ActivityTypeID);
                    activity.ActivityType.Detail = new Translation(pActivity.ActivityType.Detail.TranslationID);
                    activity.ActivityType.Detail.Alias = pActivity.ActivityType.Detail.Alias;
                    activity.Attributes = new Entities.Utility.EntityAttributeCollection(pActivity.Attributes.ToXMLFragment());
                    activity.Priority = pActivity.Priority;
                }
                catch (Exception exc)
                {
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activity;
        }

        public Activity Update(Activity pActivity, int? pParentActivityID)
        {
            Activity activity = new Activity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_Update]");
                try
                {
                    pActivity.Detail = base.UpdateTranslation(pActivity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivity.ActivityType.ActivityTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityTypeID", pActivity.ActivityType.ActivityTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pActivity.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pActivity.Attributes != null) ? ((pActivity.Attributes.ToXMLFragment().Length > 0) ? pActivity.Attributes.ToXMLFragment() : null) : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentActivityID", pParentActivityID));

                    sqlCommand.ExecuteNonQuery();

                    activity = new Activity(pActivity.ActivityID);
                    activity.Detail = new Translation(pActivity.Detail.TranslationID);
                    activity.Detail.Alias = pActivity.Detail.Alias;
                    activity.ActivityType = new ActivityType(pActivity.ActivityType.ActivityTypeID);
                    activity.ActivityType.Detail = new Translation(pActivity.ActivityType.Detail.TranslationID);
                    activity.ActivityType.Detail.Alias = pActivity.ActivityType.Detail.Alias;
                    activity.Attributes = new Entities.Utility.EntityAttributeCollection(pActivity.Attributes.ToXMLFragment());
                    activity.Priority = pActivity.Priority;
                }
                catch (Exception exc)
                {
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activity;
        }

        public Activity Delete(Activity pActivity)
        {
            Activity activity = new Activity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Activity_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityID", pActivity.ActivityID));

                    sqlCommand.ExecuteNonQuery();

                    activity = new Activity(pActivity.ActivityID);
                    base.DeleteAllTranslations(pActivity.Detail);
                }
                catch (Exception exc)
                {
                    activity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    activity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return activity;
        }
    }
}
