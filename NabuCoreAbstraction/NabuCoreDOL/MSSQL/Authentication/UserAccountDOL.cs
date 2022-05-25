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
    public class UserAccountDOL : BaseDOL
    {
        public UserAccountDOL() : base ()
        {
        }

        public UserAccountDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccount Get(int pUserAccountID, int pLanguageID)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccount = new UserAccount(sqlDataReader.GetInt32(0));
                        userAccount.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(1));
                        userAccount.PartyType.Detail = new Translation(sqlDataReader.GetInt32(2));
                        if(sqlDataReader.IsDBNull(3)==false)
		                    userAccount.AccountName = sqlDataReader.GetString(3);
                        if(sqlDataReader.IsDBNull(4)==false)
		                    userAccount.PINCode = sqlDataReader.GetString(4);
                        if(sqlDataReader.IsDBNull(5)==false)
    		                userAccount.AccountPassword = sqlDataReader.GetString(5);
                        if(sqlDataReader.IsDBNull(6)==false)
		                    userAccount.LastLogonDate = sqlDataReader.GetDateTime(6);
                        if(sqlDataReader.IsDBNull(7)==false)
		                    userAccount.LastPasswordChangedDate = sqlDataReader.GetDateTime(7);
                        if(sqlDataReader.IsDBNull(8)==false)
		                    userAccount.ChallengeQuestion = new UserAccountQuestion(sqlDataReader.GetInt32(8));
                        if(sqlDataReader.IsDBNull(9)==false)
		                    userAccount.ChallengeQuestionAnswer = sqlDataReader.GetString(9);
                        if(sqlDataReader.IsDBNull(10)==false)
		                    userAccount.AccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(10));
                        if(sqlDataReader.IsDBNull(11)==false)
		                    userAccount.AccountStatus.Detail = new Translation(sqlDataReader.GetInt32(11));
                        if(sqlDataReader.IsDBNull(12)==false)
		                    userAccount.IncorrectLoginAttempts = sqlDataReader.GetInt32(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            userAccount.UserLicense = new License(sqlDataReader.GetInt32(13));

                        userAccount.PartyType.Detail.TranslationLanguage = new Language(pLanguageID);
                        userAccount.PartyType.Detail.Alias = sqlDataReader.GetString(14);
                        userAccount.PartyType.Detail.Name = sqlDataReader.GetString(15);
                        userAccount.PartyType.Detail.Description = sqlDataReader.GetString(16);

                        userAccount.AccountStatus.Detail.TranslationLanguage = new Language(pLanguageID);
                        userAccount.AccountStatus.Detail.Alias = sqlDataReader.GetString(17);
                        userAccount.AccountStatus.Detail.Name = sqlDataReader.GetString(18);
                        userAccount.AccountStatus.Detail.Description = sqlDataReader.GetString(19);

                        if (sqlDataReader.IsDBNull(20) == false)
                            userAccount.CreatedDate = sqlDataReader.GetDateTime(20);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }

        public UserAccount GetByName(string  pAccountName, int pLanguageID)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_GetByName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountName", pAccountName));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccount = new UserAccount(sqlDataReader.GetInt32(0));
                        userAccount.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(1));
                        userAccount.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccount.AccountName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccount.PINCode = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccount.AccountPassword = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            userAccount.LastLogonDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            userAccount.LastPasswordChangedDate = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            userAccount.ChallengeQuestion = new UserAccountQuestion(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            userAccount.ChallengeQuestionAnswer = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            userAccount.AccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            userAccount.AccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            userAccount.IncorrectLoginAttempts = sqlDataReader.GetInt32(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            userAccount.UserLicense = new License(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            userAccount.CreatedDate = sqlDataReader.GetDateTime(14);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }

        public UserAccount GetByTelephoneNumber(string pTelephoneNumber, int pLanguageID)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_GetByTelephoneNumber]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TelephoneNumber", pTelephoneNumber));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccount = new UserAccount(sqlDataReader.GetInt32(0));
                        userAccount.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(1));
                        userAccount.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccount.AccountName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccount.PINCode = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccount.AccountPassword = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            userAccount.LastLogonDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            userAccount.LastPasswordChangedDate = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            userAccount.ChallengeQuestion = new UserAccountQuestion(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            userAccount.ChallengeQuestionAnswer = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            userAccount.AccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            userAccount.AccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            userAccount.IncorrectLoginAttempts = sqlDataReader.GetInt32(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            userAccount.UserLicense = new License(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            userAccount.CreatedDate = sqlDataReader.GetDateTime(14);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }

        public UserAccount[] List(int pLanguageID)
        {
            List<UserAccount> userAccounts = new List<UserAccount>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccount userAccount = new UserAccount(sqlDataReader.GetInt32(0));
                        userAccount.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(1));
                        userAccount.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccount.AccountName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccount.PINCode = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccount.AccountPassword = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            userAccount.LastLogonDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            userAccount.LastPasswordChangedDate = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            userAccount.ChallengeQuestion = new UserAccountQuestion(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            userAccount.ChallengeQuestionAnswer = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            userAccount.AccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            userAccount.AccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            userAccount.IncorrectLoginAttempts = sqlDataReader.GetInt32(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            userAccount.UserLicense = new License(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            userAccount.CreatedDate = sqlDataReader.GetDateTime(14);
                        userAccounts.Add(userAccount);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccount userAccount = new UserAccount();
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccounts.Add(userAccount);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccounts.ToArray();
        }

        public UserAccount Insert(UserAccount pUserAccount)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccount.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountName", pUserAccount.AccountName));
                    sqlCommand.Parameters.Add(new SqlParameter("@PINCode", pUserAccount.PINCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountPassword", pUserAccount.AccountPassword));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastLogonDate", pUserAccount.LastLogonDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastPasswordChangedDate", pUserAccount.LastPasswordChangedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountQuestionID", ((pUserAccount.ChallengeQuestion!=null) ? pUserAccount.ChallengeQuestion.UserAccountQuestionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountAnswer", pUserAccount.ChallengeQuestionAnswer));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountStatusAlias", pUserAccount.AccountStatus.Detail.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncorrectLoginAttempts", pUserAccount.IncorrectLoginAttempts));
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", ((pUserAccount.UserLicense!=null) ? pUserAccount.UserLicense.LicenseID : null)));

                    sqlCommand.ExecuteNonQuery();

                    userAccount = new UserAccount(pUserAccount.PartyID);
                    if(pUserAccount.PartyType != null)
                        userAccount.PartyType = pUserAccount.PartyType;
                    if (pUserAccount.AccountName != null)
                        userAccount.AccountName = pUserAccount.AccountName;
                    if (pUserAccount.PINCode != null)
                        userAccount.PINCode = pUserAccount.PINCode;
                    if (pUserAccount.AccountPassword != null)
                        userAccount.AccountPassword = pUserAccount.AccountPassword;
                    if (pUserAccount.LastLogonDate != null)
                        userAccount.LastLogonDate = pUserAccount.LastLogonDate;
                    if (pUserAccount.LastPasswordChangedDate != null)
                        userAccount.LastPasswordChangedDate = pUserAccount.LastPasswordChangedDate;
                    if (pUserAccount.ChallengeQuestion != null)
                        userAccount.ChallengeQuestion = pUserAccount.ChallengeQuestion;
                    if (pUserAccount.ChallengeQuestionAnswer != null)
                        userAccount.ChallengeQuestionAnswer = pUserAccount.ChallengeQuestionAnswer;
                    if (pUserAccount.AccountStatus != null)
                        userAccount.AccountStatus = pUserAccount.AccountStatus;
                    userAccount.IncorrectLoginAttempts = pUserAccount.IncorrectLoginAttempts;
                    if (pUserAccount.UserLicense != null)
                        userAccount.UserLicense = pUserAccount.UserLicense;
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }

        public UserAccount Update(UserAccount pUserAccount)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccount.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountName", pUserAccount.AccountName));
                    sqlCommand.Parameters.Add(new SqlParameter("@PINCode", pUserAccount.PINCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountPassword", pUserAccount.AccountPassword));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastLogonDate", pUserAccount.LastLogonDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastPasswordChangedDate", pUserAccount.LastPasswordChangedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountQuestionID", ((pUserAccount.ChallengeQuestion != null) ? pUserAccount.ChallengeQuestion.UserAccountQuestionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountAnswer", pUserAccount.ChallengeQuestionAnswer));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountStatusAlias", pUserAccount.AccountStatus.Detail.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncorrectLoginAttempts", pUserAccount.IncorrectLoginAttempts));
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", ((pUserAccount.UserLicense != null) ? pUserAccount.UserLicense.LicenseID : null)));

                    sqlCommand.ExecuteNonQuery();

                    userAccount = new UserAccount(pUserAccount.PartyID);
                    if(pUserAccount.PartyType != null)
                        userAccount.PartyType = new Entities.Core.PartyType(pUserAccount.PartyType.PartyTypeID);
                    if (pUserAccount.AccountName != null)
                        userAccount.AccountName = pUserAccount.AccountName;
                    if (pUserAccount.PINCode != null)
                        userAccount.PINCode = pUserAccount.PINCode;
                    if (pUserAccount.AccountPassword != null)
                        userAccount.AccountPassword = pUserAccount.AccountPassword;
                    if (pUserAccount.LastLogonDate != null)
                        userAccount.LastLogonDate = pUserAccount.LastLogonDate;
                    if (pUserAccount.LastPasswordChangedDate != null)
                        userAccount.LastPasswordChangedDate = pUserAccount.LastPasswordChangedDate;
                    if (pUserAccount.ChallengeQuestion != null)
                        userAccount.ChallengeQuestion = new UserAccountQuestion(pUserAccount.ChallengeQuestion.UserAccountQuestionID);
                    if (pUserAccount.ChallengeQuestionAnswer != null)
                        userAccount.ChallengeQuestionAnswer = pUserAccount.ChallengeQuestionAnswer;
                    if (pUserAccount.AccountStatus != null)
                        userAccount.AccountStatus = new UserAccountStatus(pUserAccount.AccountStatus.UserAccountStatusID);
                    userAccount.IncorrectLoginAttempts = pUserAccount.IncorrectLoginAttempts;
                    if (pUserAccount.UserLicense != null)
                        userAccount.UserLicense = new License(pUserAccount.UserLicense.LicenseID);
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }

        public UserAccount Delete(UserAccount pUserAccount)
        {
            UserAccount userAccount = new UserAccount();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccount_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccount.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    userAccount = new UserAccount(pUserAccount.PartyID);
                }
                catch (Exception exc)
                {
                    userAccount.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccount.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccount;
        }
    }
}


