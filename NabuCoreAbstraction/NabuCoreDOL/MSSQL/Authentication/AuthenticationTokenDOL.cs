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
    public class AuthenticationTokenDOL : BaseDOL
    {
        public AuthenticationTokenDOL() : base ()
        {
        }

        public AuthenticationTokenDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AuthenticationToken Get(int pAuthenticationTokenID, int pLanguageID)
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthenticationTokenID", pAuthenticationTokenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        authenticationToken = new AuthenticationToken(sqlDataReader.GetInt32(0));
                        authenticationToken.Token = sqlDataReader.GetString(1);
                        authenticationToken.Party = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        authenticationToken.Party.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        authenticationToken.Party.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        if (sqlDataReader.IsDBNull(5) == false)
                            authenticationToken.TokenType = sqlDataReader.GetString(5);
                        authenticationToken.Party.PartyType.Detail.Alias = sqlDataReader.GetString(6);
                        authenticationToken.Party.PartyType.Detail.Name = sqlDataReader.GetString(7);
                        authenticationToken.Party.PartyType.Detail.Description = sqlDataReader.GetString(8);
                        authenticationToken.Party.PartyType.Detail.TranslationLanguage = new Language(pLanguageID);
                        if (sqlDataReader.IsDBNull(9) == false)
                            authenticationToken.License = new License(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationToken;
        }

        public AuthenticationToken GetByToken(string pToken, int pLanguageID)
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_GetByToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        authenticationToken = new AuthenticationToken(sqlDataReader.GetInt32(0));
                        authenticationToken.Token = sqlDataReader.GetString(1);
                        authenticationToken.Party = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        authenticationToken.Party.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        authenticationToken.Party.PartyType.Detail =new Translation(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            authenticationToken.TokenType = sqlDataReader.GetString(5);
                        authenticationToken.Party.PartyType.Detail.Alias = sqlDataReader.GetString(6);
                        authenticationToken.Party.PartyType.Detail.Name = sqlDataReader.GetString(7);
                        authenticationToken.Party.PartyType.Detail.Description = sqlDataReader.GetString(8);
                        authenticationToken.Party.PartyType.Detail.TranslationLanguage = new Language(pLanguageID);
                        if (sqlDataReader.IsDBNull(9) == false)
                            authenticationToken.License = new License(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationToken;
        }
       
        public AuthenticationToken[] List(int pLanguageID)
        {
            List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AuthenticationToken authenticationToken = new AuthenticationToken(sqlDataReader.GetInt32(0));
                        authenticationToken.Token = sqlDataReader.GetString(1);
                        authenticationToken.Party = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        authenticationToken.Party.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        authenticationToken.Party.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        if (sqlDataReader.IsDBNull(5) == false)
                            authenticationToken.TokenType = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            authenticationToken.License = new License(sqlDataReader.GetInt32(6));
                        authenticationTokens.Add(authenticationToken);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AuthenticationToken authenticationToken = new AuthenticationToken();
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    authenticationTokens.Add(authenticationToken);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationTokens.ToArray();
        }

        public AuthenticationToken[] ListForPartyID(int pPartyID, int pLanguageID)
        {
            List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_ListByPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AuthenticationToken authenticationToken = new AuthenticationToken(sqlDataReader.GetInt32(0));
                        authenticationToken.Token = sqlDataReader.GetString(1);
                        authenticationToken.Party = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        authenticationToken.Party.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        authenticationToken.Party.PartyType.Detail = new Translation(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            authenticationToken.TokenType = sqlDataReader.GetString(5);
                        authenticationToken.Party.PartyType.Detail.TranslationLanguage = new Language(pLanguageID);
                        authenticationToken.Party.PartyType.Detail.Alias = sqlDataReader.GetString(6);
                        authenticationToken.Party.PartyType.Detail.Name = sqlDataReader.GetString(7);
                        authenticationToken.Party.PartyType.Detail.Description = sqlDataReader.GetString(8);

                        if (sqlDataReader.IsDBNull(9) == false)
                            authenticationToken.License = new License(sqlDataReader.GetInt32(9));
                        authenticationTokens.Add(authenticationToken);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AuthenticationToken authenticationToken = new AuthenticationToken();
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    authenticationTokens.Add(authenticationToken);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationTokens.ToArray();
        }

        public AuthenticationToken Insert(AuthenticationToken pAuthenticationToken)
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken.Token));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pAuthenticationToken.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TokenType", pAuthenticationToken.TokenType));
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", ((pAuthenticationToken.License != null && pAuthenticationToken.License.LicenseID.HasValue) ? pAuthenticationToken.License.LicenseID : null)));
                    SqlParameter authenticationTokenID = sqlCommand.Parameters.Add("@AuthenticationTokenID", SqlDbType.Int);
                    authenticationTokenID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    authenticationToken = new AuthenticationToken((Int32)authenticationTokenID.Value);
                    authenticationToken.Token = pAuthenticationToken.Token;
                    authenticationToken.Party = new Entities.Core.Party(pAuthenticationToken.Party.PartyID);
                    authenticationToken.TokenType = pAuthenticationToken.TokenType;
                    authenticationToken.License = pAuthenticationToken.License;
                }
                catch (Exception exc)
                {
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationToken;
        }

        public AuthenticationToken Update(AuthenticationToken pAuthenticationToken)
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthenticationTokenID",pAuthenticationToken.AuthenticationTokenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken.Token));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pAuthenticationToken.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TokenType", pAuthenticationToken.TokenType));
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", ((pAuthenticationToken.License != null && pAuthenticationToken.License.LicenseID.HasValue) ? pAuthenticationToken.License.LicenseID : null)));

                    sqlCommand.ExecuteNonQuery();

                    authenticationToken = new AuthenticationToken(pAuthenticationToken.AuthenticationTokenID);
                    authenticationToken.Token = pAuthenticationToken.Token;
                    authenticationToken.Party = new Entities.Core.Party(pAuthenticationToken.Party.PartyID);
                    authenticationToken.TokenType = pAuthenticationToken.TokenType;
                    authenticationToken.License = pAuthenticationToken.License;
                }
                catch (Exception exc)
                {
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationToken;
        }

        public AuthenticationToken Delete(AuthenticationToken pAuthenticationToken)
        {
            AuthenticationToken authenticationToken = new AuthenticationToken();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[AuthenticationToken_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthenticationTokenID", pAuthenticationToken.AuthenticationTokenID));

                    sqlCommand.ExecuteNonQuery();

                    authenticationToken = new AuthenticationToken(pAuthenticationToken.AuthenticationTokenID);
                }
                catch (Exception exc)
                {
                    authenticationToken.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    authenticationToken.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return authenticationToken;
        }    
    }
}
