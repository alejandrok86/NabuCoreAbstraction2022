using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication
{
    public class UserAccountSessionDOL : BaseDOL
    {
        public UserAccountSessionDOL() : base ()
        {
        }

        public UserAccountSessionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountSession Get(int pUserAccountSessionID, int pLanguageID)
        {
            UserAccountSession userAccountSession = new UserAccountSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountSession = new UserAccountSession(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            userAccountSession.UserDetail = new UserAccount(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
		                    userAccountSession.SessionStarted = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
		                    userAccountSession.SessionEnded = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
    		                userAccountSession.SessionGUID = Guid.Parse(sqlDataReader.GetString(4));
                        if(sqlDataReader.IsDBNull(5)==false)
		                    userAccountSession.PrivateKey = sqlDataReader.GetString(5);
                        if(sqlDataReader.IsDBNull(6)==false)
                            userAccountSession.LastAccessDateTime = sqlDataReader.GetDateTime(6);
                        if(sqlDataReader.IsDBNull(7)==false)
                            userAccountSession.SessionEndStatus = new Entities.System.SessionEndStatus(sqlDataReader.GetInt32(7));
                        if(sqlDataReader.IsDBNull(8)==false)
		                    userAccountSession.SystemSpecification = new Entities.System.SystemSpecification(sqlDataReader.GetInt32(8));
                        if(sqlDataReader.IsDBNull(9)==false)
		                    userAccountSession.Language = new Entities.Globalisation.Language(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            userAccountSession.IPAddress = sqlDataReader.GetString(10);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountSession;
        }

        public UserAccountSession[] List(int pUserAccountID, int pLanguageID)
        {
            List<UserAccountSession> userAccountSessions = new List<UserAccountSession>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccountSession userAccountSession = new UserAccountSession(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            userAccountSession.SessionStarted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            userAccountSession.SessionEnded = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccountSession.SessionGUID = Guid.Parse(sqlDataReader.GetString(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccountSession.PrivateKey = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccountSession.LastAccessDateTime = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                        {
                            userAccountSession.SessionEndStatus = new Entities.System.SessionEndStatus(sqlDataReader.GetInt32(6));
                            userAccountSession.SessionEndStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(7), pLanguageID);
                        }
                        if (sqlDataReader.IsDBNull(8) == false)
                            userAccountSession.SystemSpecification = new Entities.System.SystemSpecification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            userAccountSession.Language = new Entities.Globalisation.Language(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            userAccountSession.IPAddress = sqlDataReader.GetString(10);
                        userAccountSessions.Add(userAccountSession);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccountSession userAccountSession = new UserAccountSession();
                    userAccountSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccountSessions.Add(userAccountSession);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountSessions.ToArray();
        }

        public UserAccountSession Insert(UserAccountSession pUserAccountSession)
        {
            UserAccountSession userAccountSession = new UserAccountSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountSession.UserDetail.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionStarted", pUserAccountSession.SessionStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEnded", pUserAccountSession.SessionEnded));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionGUID", pUserAccountSession.SessionGUID.ToString()));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrivateKey", pUserAccountSession.PrivateKey));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastAccessDateTime", pUserAccountSession.LastAccessDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEndStatusID", ((pUserAccountSession.SessionEndStatus != null) ? pUserAccountSession.SessionEndStatus.SessionEndStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemSpecificationID", ((pUserAccountSession.SystemSpecification != null) ? pUserAccountSession.SystemSpecification.SystemSpecificationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pUserAccountSession.Language.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IPAddress", pUserAccountSession.IPAddress));
                    SqlParameter userAccountSessionID = sqlCommand.Parameters.Add("@UserAccountSessionID", SqlDbType.Int);
                    userAccountSessionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountSession = new UserAccountSession((Int32)userAccountSessionID.Value);
                    userAccountSession.SessionStarted = pUserAccountSession.SessionStarted;
                    userAccountSession.SessionEnded = pUserAccountSession.SessionEnded;
                    userAccountSession.SessionGUID = pUserAccountSession.SessionGUID;
                    userAccountSession.PrivateKey = pUserAccountSession.PrivateKey;
                    userAccountSession.LastAccessDateTime = pUserAccountSession.LastAccessDateTime;
                    if(pUserAccountSession.SessionEndStatus != null)
                        userAccountSession.SessionEndStatus = new Entities.System.SessionEndStatus(pUserAccountSession.SessionEndStatus.SessionEndStatusID);
                    if(pUserAccountSession.SystemSpecification != null)
                        userAccountSession.SystemSpecification = new Entities.System.SystemSpecification(pUserAccountSession.SystemSpecification.SystemSpecificationID);
                    userAccountSession.Language = new Entities.Globalisation.Language(pUserAccountSession.Language.LanguageID);
                    userAccountSession.UserDetail = new UserAccount(pUserAccountSession.UserDetail.PartyID);
                    if (pUserAccountSession.UserDetail.AccountStatus != null)
                    {
                        userAccountSession.UserDetail.AccountStatus = new UserAccountStatus(pUserAccountSession.UserDetail.AccountStatus.UserAccountStatusID);
                        userAccountSession.UserDetail.AccountStatus.Detail = new Translation();
                        userAccountSession.UserDetail.AccountStatus.Detail.Alias = pUserAccountSession.UserDetail.AccountStatus.Detail.Alias;
                    }
                    userAccountSession.UserDetail.AccountName = pUserAccountSession.UserDetail.AccountName;
                    userAccountSession.UserDetail.AccountPassword = pUserAccountSession.UserDetail.AccountPassword;
                    if(pUserAccountSession.UserDetail.ChallengeQuestion != null)
                        userAccountSession.UserDetail.ChallengeQuestion = new UserAccountQuestion(pUserAccountSession.UserDetail.ChallengeQuestion.UserAccountQuestionID);
                    if (pUserAccountSession.UserDetail.ChallengeQuestionAnswer != null)
                        userAccountSession.UserDetail.ChallengeQuestionAnswer = pUserAccountSession.UserDetail.ChallengeQuestionAnswer;
                    userAccountSession.UserDetail.IncorrectLoginAttempts = pUserAccountSession.UserDetail.IncorrectLoginAttempts;
                    userAccountSession.UserDetail.LastLogonDate = pUserAccountSession.UserDetail.LastLogonDate;
                    userAccountSession.UserDetail.LastPasswordChangedDate = pUserAccountSession.UserDetail.LastPasswordChangedDate;
                    if(pUserAccountSession.UserDetail.PartyType != null)
                        userAccountSession.UserDetail.PartyType = new Entities.Core.PartyType(pUserAccountSession.UserDetail.PartyType.PartyTypeID);
                    userAccountSession.UserDetail.PINCode = pUserAccountSession.UserDetail.PINCode;
                    if (pUserAccountSession.UserDetail.UserLicense != null)
                        userAccountSession.UserDetail.UserLicense = new License(pUserAccountSession.UserDetail.UserLicense.LicenseID);
                    userAccountSession.IPAddress = pUserAccountSession.IPAddress;
                }
                catch (Exception exc)
                {
                    userAccountSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountSession;
        }

        public UserAccountSession Update(UserAccountSession pUserAccountSession)
        {
            UserAccountSession userAccountSession = new UserAccountSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSession.UserAccountSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountSession.UserDetail.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionStarted", pUserAccountSession.SessionStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEnded", pUserAccountSession.SessionEnded));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionGUID", pUserAccountSession.SessionGUID.ToString()));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrivateKey", pUserAccountSession.PrivateKey));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastAccessDateTime", pUserAccountSession.LastAccessDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEndStatusAlias", pUserAccountSession.SessionEndStatus.Detail.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemSpecificationID", ((pUserAccountSession.SystemSpecification != null) ? pUserAccountSession.SystemSpecification.SystemSpecificationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pUserAccountSession.Language.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IPAddress", pUserAccountSession.IPAddress));

                    sqlCommand.ExecuteNonQuery();

                    userAccountSession = new UserAccountSession(pUserAccountSession.UserAccountSessionID);
                    userAccountSession.SessionStarted = pUserAccountSession.SessionStarted;
                    userAccountSession.SessionEnded = pUserAccountSession.SessionEnded;
                    userAccountSession.SessionGUID = pUserAccountSession.SessionGUID;
                    userAccountSession.PrivateKey = pUserAccountSession.PrivateKey;
                    userAccountSession.LastAccessDateTime = pUserAccountSession.LastAccessDateTime;
                    if (pUserAccountSession.SessionEndStatus != null)
                        userAccountSession.SessionEndStatus = new Entities.System.SessionEndStatus(pUserAccountSession.SessionEndStatus.SessionEndStatusID);
                    if (pUserAccountSession.SystemSpecification != null)
                        userAccountSession.SystemSpecification = new Entities.System.SystemSpecification(pUserAccountSession.SystemSpecification.SystemSpecificationID);
                    userAccountSession.Language = new Entities.Globalisation.Language(pUserAccountSession.Language.LanguageID);
                    userAccountSession.UserDetail = new UserAccount(pUserAccountSession.UserDetail.PartyID);
                    userAccountSession.IPAddress = pUserAccountSession.IPAddress;
                }
                catch (Exception exc)
                {
                    userAccountSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountSession;
        }

        public UserAccountSession Delete(UserAccountSession pUserAccountSession)
        {
            UserAccountSession userAccountSession = new UserAccountSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSession.UserAccountSessionID));

                    sqlCommand.ExecuteNonQuery();

                    userAccountSession = new UserAccountSession(pUserAccountSession.UserAccountSessionID);
                }
                catch (Exception exc)
                {
                    userAccountSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountSession;
        }

        public Entities.BaseBoolean DeleteForUserAccount(int pUserAccountID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_DeleteForUserAccount]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

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

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean Heartbeat(int pUserAccountSessionID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountSession_Heartbeat]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSessionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = true;
                    result.ErrorsDetected = true;
                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
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



