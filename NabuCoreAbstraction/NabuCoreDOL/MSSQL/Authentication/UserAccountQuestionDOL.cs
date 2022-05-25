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
    public class UserAccountQuestionDOL : BaseDOL
    {
        public UserAccountQuestionDOL() : base()
        {
        }

        public UserAccountQuestionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountQuestion Get(int pUserAccountQuestionID, int pLanguageID)
        {
            UserAccountQuestion userAccountQuestion = new UserAccountQuestion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountQuestion_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountQuestionID", pUserAccountQuestionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountQuestion = new UserAccountQuestion(sqlDataReader.GetInt32(0));
                        userAccountQuestion.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountQuestion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountQuestion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountQuestion;
        }

        public UserAccountQuestion Insert(UserAccountQuestion pUserAccountQuestion)
        {
            UserAccountQuestion userAccountQuestion = new UserAccountQuestion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountQuestion_Insert]");
                try
                {
                    pUserAccountQuestion.Detail = base.InsertTranslation(pUserAccountQuestion.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pUserAccountQuestion.Detail.TranslationID));
                    SqlParameter userAccountQuestionID = sqlCommand.Parameters.Add("@UserAccountQuestionID", SqlDbType.Int);
                    userAccountQuestionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountQuestion = new UserAccountQuestion((Int32)userAccountQuestionID.Value);
                    userAccountQuestion.Detail = new Translation(pUserAccountQuestion.Detail.TranslationID);
                    userAccountQuestion.Detail.Alias = pUserAccountQuestion.Detail.Alias;
                    userAccountQuestion.Detail.Description = pUserAccountQuestion.Detail.Description;
                    userAccountQuestion.Detail.Name = pUserAccountQuestion.Detail.Name;
                }
                catch (Exception exc)
                {
                    userAccountQuestion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountQuestion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountQuestion;
        }

        public UserAccountQuestion Delete(UserAccountQuestion pUserAccountQuestion)
        {
            UserAccountQuestion userAccountQuestion = new UserAccountQuestion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountQuestion_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountQuestionID", pUserAccountQuestion.UserAccountQuestionID));

                    sqlCommand.ExecuteNonQuery();

                    userAccountQuestion = new UserAccountQuestion(pUserAccountQuestion.UserAccountQuestionID);

                    base.DeleteAllTranslations(pUserAccountQuestion.Detail);
                }
                catch (Exception exc)
                {
                    userAccountQuestion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountQuestion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountQuestion;
        }
    }
}

