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
    public class PartyDOL : BaseDOL
    {
        public PartyDOL() : base()
        {
        }

        public PartyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Party Get(int pPartyID, int pLanguageID)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        party = new Party(sqlDataReader.GetInt32(0));
                        party.PartyType = new PartyType(sqlDataReader.GetInt32(1));
                        party.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }

        public Party[] List(int pLanguageID)
        {
            List<Party> parties = new List<Party>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Party party = new Party(sqlDataReader.GetInt32(0));
                        party.PartyType = new PartyType(sqlDataReader.GetInt32(1));
                        party.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);

                        parties.Add(party);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Party party = new Party();
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parties.Add(party);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parties.ToArray();
        }

        public Party[] List(int pPartyTypeID, int pLanguageID)
        {
            List<Party> parties = new List<Party>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_ListByPartyType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Party party = new Party(sqlDataReader.GetInt32(0));
                        party.PartyType = new PartyType(sqlDataReader.GetInt32(1));
                        party.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);

                        parties.Add(party);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Party party = new Party();
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parties.Add(party);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parties.ToArray();
        }

        public Party Insert(Party pParty)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pParty.PartyType.PartyTypeID));
                    SqlParameter partyID = sqlCommand.Parameters.Add("@PartyID", SqlDbType.Int);
                    partyID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    party = new Party((Int32)partyID.Value);
                    party.PartyType = new PartyType(pParty.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }

        public Party Update(Party pParty)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pParty.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    party = new Party(pParty.PartyID);
                    party.PartyType = new PartyType(pParty.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }

        public Party Delete(Party pParty)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Party_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pParty.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    party = new Party(pParty.PartyID);
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }

        public Party AssignContent(int pPartyID, int pContentID)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    party = new Party(pPartyID);
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }

        public Party RemoveContent(int pPartyID, int pContentID)
        {
            Party party = new Party();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    party = new Party(pPartyID);
                }
                catch (Exception exc)
                {
                    party.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    party.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return party;
        }
    }
}

