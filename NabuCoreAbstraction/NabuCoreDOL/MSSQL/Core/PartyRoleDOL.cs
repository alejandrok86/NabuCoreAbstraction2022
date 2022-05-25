using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class PartyRoleDOL : BaseDOL
    {
        public PartyRoleDOL() : base()
        {
        }

        public PartyRoleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyRole Get(int pPartyRoleID, int pLanguageID)
        {
            PartyRole partyRole = new PartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRole = new PartyRole(sqlDataReader.GetInt32(0));
                        partyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(1));
                        partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partyRole.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRole;
        }

        public PartyRole GetByAlias(int pPartyID, string pAlias, int pLanguageID)
        {
            PartyRole partyRole = new PartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRole = new PartyRole(sqlDataReader.GetInt32(0));
                        partyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(1));
                        partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partyRole.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRole;
        }

        public PartyRole[] List(int pPartyID, int pLanguageID)
        {
            List<PartyRole> partyRoles = new List<PartyRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_List]");
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
                        PartyRole partyRole = new PartyRole(sqlDataReader.GetInt32(0));
                        partyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(1));
                        partyRole.FromDate = sqlDataReader.GetDateTime(2);
                        partyRole.PartyRoleType.Detail = new Translation(sqlDataReader.GetInt32(3));
                        partyRole.PartyRoleType.Detail.TranslationLanguage = new Language(pLanguageID);
                        partyRole.PartyRoleType.Detail.Alias = sqlDataReader.GetString(4);
                        partyRole.PartyRoleType.Detail.Name = sqlDataReader.GetString(5);
                        partyRole.PartyRoleType.Detail.Description = sqlDataReader.GetString(6);
                        partyRoles.Add(partyRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRole partyRole = new PartyRole();
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRoles.Add(partyRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoles.ToArray();
        }

        public PartyRole Insert(PartyRole pPartyRole, int pPartyID)
        {
            PartyRole partyRole = new PartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRole.PartyRoleType.PartyRoleTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyRole.FromDate));
                    SqlParameter partyRoleID = sqlCommand.Parameters.Add("@PartyRoleID", SqlDbType.Int);
                    partyRoleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyRole = new PartyRole((Int32)partyRoleID.Value);
                    partyRole.PartyRoleType = new PartyRoleType(pPartyRole.PartyRoleType.PartyRoleTypeID);
                    partyRole.FromDate = pPartyRole.FromDate;
                }
                catch (Exception exc)
                {
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRole;
        }

        public PartyRole Update(PartyRole pPartyRole, int pPartyID)
        {
            PartyRole partyRole = new PartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRole.PartyRoleType.PartyRoleTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyRole.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    partyRole = new PartyRole(pPartyRole.PartyRoleID);
                    partyRole.PartyRoleType = new PartyRoleType(pPartyRole.PartyRoleType.PartyRoleTypeID);
                    partyRole.FromDate = pPartyRole.FromDate;
                }
                catch (Exception exc)
                {
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRole;
        }

        public PartyRole Delete(PartyRole pPartyRole)
        {
            PartyRole partyRole = new PartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRole_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRole.PartyRoleID));

                    sqlCommand.ExecuteNonQuery();

                    partyRole = new PartyRole(pPartyRole.PartyRoleID);
                }
                catch (Exception exc)
                {
                    partyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRole;
        }
    }
}

