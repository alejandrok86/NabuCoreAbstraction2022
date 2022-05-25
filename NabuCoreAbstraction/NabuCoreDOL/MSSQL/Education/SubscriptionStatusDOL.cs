using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class SubscriptionStatusDOL : BaseDOL
    {
        public SubscriptionStatusDOL() : base()
        {
        }

        public SubscriptionStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.SubscriptionStatus Get(int pSubscriptionStatusID, int pLanguageID)
        {
            Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SubscriptionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriptionStatusID", pSubscriptionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        subscriptionStatus = new Entities.Education.SubscriptionStatus(sqlDataReader.GetInt32(0));
                        subscriptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    subscriptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    subscriptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return subscriptionStatus;
        }

        public Entities.Education.SubscriptionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SubscriptionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        subscriptionStatus = new Entities.Education.SubscriptionStatus(sqlDataReader.GetInt32(0));
                        subscriptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    subscriptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    subscriptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return subscriptionStatus;
        }

        public Entities.Education.SubscriptionStatus[] List(int pLanguageID)
        {
            List<Entities.Education.SubscriptionStatus> subscriptionStatuses = new List<Entities.Education.SubscriptionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SubscriptionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus(sqlDataReader.GetInt32(0));
                        subscriptionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        subscriptionStatuses.Add(subscriptionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();
                    subscriptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    subscriptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    subscriptionStatuses.Add(subscriptionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return subscriptionStatuses.ToArray();
        }

        public Entities.Education.SubscriptionStatus Insert(Entities.Education.SubscriptionStatus pSubscriptionStatus)
        {
            Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SubscriptionStatus_Insert]");
                try
                {
                    pSubscriptionStatus.Detail = base.InsertTranslation(pSubscriptionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pSubscriptionStatus.Detail.TranslationID));
                    SqlParameter subscriptionStatusID = sqlCommand.Parameters.Add("@SubscriptionStatusID", SqlDbType.Int);
                    subscriptionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    subscriptionStatus = new Entities.Education.SubscriptionStatus((Int32)subscriptionStatusID.Value);
                    subscriptionStatus.Detail = new Translation(pSubscriptionStatus.Detail.TranslationID);
                    subscriptionStatus.Detail.Alias = pSubscriptionStatus.Detail.Alias;
                    subscriptionStatus.Detail.Description = pSubscriptionStatus.Detail.Description;
                    subscriptionStatus.Detail.Name = pSubscriptionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    subscriptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    subscriptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return subscriptionStatus;
        }

        public Entities.Education.SubscriptionStatus Update(Entities.Education.SubscriptionStatus pSubscriptionStatus)
        {
            Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();

            pSubscriptionStatus.Detail = base.UpdateTranslation(pSubscriptionStatus.Detail);

            subscriptionStatus = new Entities.Education.SubscriptionStatus(pSubscriptionStatus.SubscriptionStatusID);
            subscriptionStatus.Detail = new Translation(pSubscriptionStatus.Detail.TranslationID);
            subscriptionStatus.Detail.Alias = pSubscriptionStatus.Detail.Alias;
            subscriptionStatus.Detail.Description = pSubscriptionStatus.Detail.Description;
            subscriptionStatus.Detail.Name = pSubscriptionStatus.Detail.Name;

            return subscriptionStatus;
        }

        public Entities.Education.SubscriptionStatus Delete(Entities.Education.SubscriptionStatus pSubscriptionStatus)
        {
            Entities.Education.SubscriptionStatus subscriptionStatus = new Entities.Education.SubscriptionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SubscriptionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriptionStatusID", pSubscriptionStatus.SubscriptionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    subscriptionStatus = new Entities.Education.SubscriptionStatus(pSubscriptionStatus.SubscriptionStatusID);
                    base.DeleteAllTranslations(pSubscriptionStatus.Detail);
                }
                catch (Exception exc)
                {
                    subscriptionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    subscriptionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return subscriptionStatus;
        }
    }
}
