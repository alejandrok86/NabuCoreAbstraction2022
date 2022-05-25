using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class UserInterfaceSkinDOL : BaseDOL
    {
        public UserInterfaceSkinDOL() : base()
        {
        }

        public UserInterfaceSkinDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserInterfaceSkin Get(int pUserInterfaceSkinID, int pLanguageID)
        {
            UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[UserInterfaceSkin_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserInterfaceSkinID", pUserInterfaceSkinID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userInterfaceSkin = new UserInterfaceSkin(sqlDataReader.GetInt32(0));
                        userInterfaceSkin.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userInterfaceSkin.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userInterfaceSkin.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userInterfaceSkin;
        }

        public UserInterfaceSkin[] List(int pLanguageID)
        {
            List<UserInterfaceSkin> userInterfaceSkins = new List<UserInterfaceSkin>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[UserInterfaceSkin_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin(sqlDataReader.GetInt32(0));
                        userInterfaceSkin.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        userInterfaceSkins.Add(userInterfaceSkin);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin();
                    userInterfaceSkin.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userInterfaceSkin.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userInterfaceSkins.Add(userInterfaceSkin);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userInterfaceSkins.ToArray();
        }

        public UserInterfaceSkin Insert(UserInterfaceSkin pUserInterfaceSkin)
        {
            UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[UserInterfaceSkin_Insert]");
                try
                {
                    pUserInterfaceSkin.Detail = base.InsertTranslation(pUserInterfaceSkin.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pUserInterfaceSkin.Detail.TranslationID));
                    SqlParameter userInterfaceSkinID = sqlCommand.Parameters.Add("@UserInterfaceSkinID", SqlDbType.Int);
                    userInterfaceSkinID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userInterfaceSkin = new UserInterfaceSkin((Int32)userInterfaceSkinID.Value);
                    userInterfaceSkin.Detail = new Translation(pUserInterfaceSkin.Detail.TranslationID);
                    userInterfaceSkin.Detail.Alias = pUserInterfaceSkin.Detail.Alias;
                    userInterfaceSkin.Detail.Description = pUserInterfaceSkin.Detail.Description;
                    userInterfaceSkin.Detail.Name = pUserInterfaceSkin.Detail.Name;
                }
                catch (Exception exc)
                {
                    userInterfaceSkin.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userInterfaceSkin.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userInterfaceSkin;
        }

        public UserInterfaceSkin Update(UserInterfaceSkin pUserInterfaceSkin)
        {
            UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin();

            pUserInterfaceSkin.Detail = base.UpdateTranslation(pUserInterfaceSkin.Detail);

            userInterfaceSkin = new UserInterfaceSkin(pUserInterfaceSkin.UserInterfaceSkinID);
            userInterfaceSkin.Detail = new Translation(pUserInterfaceSkin.Detail.TranslationID);
            userInterfaceSkin.Detail.Alias = pUserInterfaceSkin.Detail.Alias;
            userInterfaceSkin.Detail.Description = pUserInterfaceSkin.Detail.Description;
            userInterfaceSkin.Detail.Name = pUserInterfaceSkin.Detail.Name;

            return userInterfaceSkin;
        }

        public UserInterfaceSkin Delete(UserInterfaceSkin pUserInterfaceSkin)
        {
            UserInterfaceSkin userInterfaceSkin = new UserInterfaceSkin();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[UserInterfaceSkin_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserInterfaceSkinID", pUserInterfaceSkin.UserInterfaceSkinID));

                    sqlCommand.ExecuteNonQuery();

                    userInterfaceSkin = new UserInterfaceSkin(pUserInterfaceSkin.UserInterfaceSkinID);
                    base.DeleteAllTranslations(pUserInterfaceSkin.Detail);
                }
                catch (Exception exc)
                {
                    userInterfaceSkin.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userInterfaceSkin.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userInterfaceSkin;
        }
    }
}

