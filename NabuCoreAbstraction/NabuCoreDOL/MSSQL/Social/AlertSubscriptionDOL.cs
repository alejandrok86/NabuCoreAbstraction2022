using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class AlertSubscriptionDOL : BaseDOL
    {
        public AlertSubscriptionDOL() : base()
        {
        }

        public AlertSubscriptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AlertSubscription Get(int pAlertSubscriptionID)
        {
            AlertSubscription alertSubscription = new AlertSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[AlertSubscription_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AlertSubscriptionID", pAlertSubscriptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        alertSubscription = new AlertSubscription(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            alertSubscription.LastAlerted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            alertSubscription.xmlAlertCriteria = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    alertSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    alertSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return alertSubscription;
        }

        public AlertSubscription[] List(int pSubscriberPartyID)
        {
            List<AlertSubscription> alertSubscriptions = new List<AlertSubscription>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[AlertSubscription_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AlertSubscription alertSubscription = new AlertSubscription(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            alertSubscription.LastAlerted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            alertSubscription.xmlAlertCriteria = sqlDataReader.GetString(2);
                        alertSubscriptions.Add(alertSubscription);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AlertSubscription alertSubscription = new AlertSubscription();
                    alertSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    alertSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    alertSubscriptions.Add(alertSubscription);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return alertSubscriptions.ToArray();
        }

        public AlertSubscription Insert(AlertSubscription pAlertSubscription, int pSubscriberPartyID)
        {
            AlertSubscription alertSubscription = new AlertSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[AlertSubscription_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastAlerted", pAlertSubscription.LastAlerted));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlAlertCriteria", pAlertSubscription.xmlAlertCriteria));
                    SqlParameter alertSubscriptionID = sqlCommand.Parameters.Add("@AlertSubscriptionID", SqlDbType.Int);
                    alertSubscriptionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    alertSubscription = new AlertSubscription((Int32)alertSubscriptionID.Value);
                    alertSubscription.LastAlerted = pAlertSubscription.LastAlerted;
                    alertSubscription.xmlAlertCriteria = pAlertSubscription.xmlAlertCriteria;
                }
                catch (Exception exc)
                {
                    alertSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    alertSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return alertSubscription;
        }

        public AlertSubscription Update(AlertSubscription pAlertSubscription)
        {
            AlertSubscription alertSubscription = new AlertSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[AlertSubscription_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AlertSubscriptionID", pAlertSubscription.AlertSubscriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastAlerted", pAlertSubscription.LastAlerted));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlAlertCriteria", pAlertSubscription.xmlAlertCriteria));

                    sqlCommand.ExecuteNonQuery();

                    alertSubscription = new AlertSubscription(pAlertSubscription.AlertSubscriptionID);
                    alertSubscription.LastAlerted = pAlertSubscription.LastAlerted;
                    alertSubscription.xmlAlertCriteria = pAlertSubscription.xmlAlertCriteria;
                }
                catch (Exception exc)
                {
                    alertSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    alertSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return alertSubscription;
        }

        public AlertSubscription Delete(AlertSubscription pAlertSubscription)
        {
            AlertSubscription alertSubscription = new AlertSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[AlertSubscription_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AlertSubscription", pAlertSubscription.AlertSubscriptionID));

                    sqlCommand.ExecuteNonQuery();

                    alertSubscription = new AlertSubscription(pAlertSubscription.AlertSubscriptionID);
                }
                catch (Exception exc)
                {
                    alertSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    alertSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return alertSubscription;
        }
    }
}
