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
    public class PartyContactMechanismDOL : BaseDOL
    {
        public PartyContactMechanismDOL() : base()
        {
        }

        public PartyContactMechanismDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyContactMechanism Get(int pPartyContactMechanismID)
        {
            PartyContactMechanism partyContactMechanism = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyContactMechanismID", pPartyContactMechanismID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyContactMechanism = new PartyContactMechanism(sqlDataReader.GetInt32(0));
                        partyContactMechanism.ContactMechanism = new Entities.PeopleAndPlaces.ContactMechanism(sqlDataReader.GetInt32(1));
                        partyContactMechanism.AllowSolicitation = sqlDataReader.GetBoolean(2);
                        partyContactMechanism.IsPreferredContactMechanism = sqlDataReader.GetBoolean(3);
                        partyContactMechanism.IsOverallPreferredContactMechanism = sqlDataReader.GetBoolean(4);
                        partyContactMechanism.AllowGlobalThirdPartyContact = sqlDataReader.GetBoolean(5);
                        partyContactMechanism.AllowLimitedThirdPartyContact = sqlDataReader.GetBoolean(6);
                        partyContactMechanism.FromDate = sqlDataReader.GetDateTime(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanism;
        }

        public PartyContactMechanism[] List(int pPartyID)
        {
            List<PartyContactMechanism> partyContactMechanisms = new List<PartyContactMechanism>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyContactMechanism partyContactMechanism = new PartyContactMechanism(sqlDataReader.GetInt32(0));
                        partyContactMechanism.ContactMechanism = new Entities.PeopleAndPlaces.ContactMechanism(sqlDataReader.GetInt32(1));
                        partyContactMechanism.AllowSolicitation = sqlDataReader.GetBoolean(2);
                        partyContactMechanism.IsPreferredContactMechanism = sqlDataReader.GetBoolean(3);
                        partyContactMechanism.IsOverallPreferredContactMechanism = sqlDataReader.GetBoolean(4);
                        partyContactMechanism.AllowGlobalThirdPartyContact = sqlDataReader.GetBoolean(5);
                        partyContactMechanism.AllowLimitedThirdPartyContact = sqlDataReader.GetBoolean(6);
                        partyContactMechanism.FromDate = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            partyContactMechanism.ContactMechanism.ContactMechanismType = new Entities.PeopleAndPlaces.ContactMechanismType(sqlDataReader.GetInt32(8));
                        partyContactMechanisms.Add(partyContactMechanism);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyContactMechanism partyContactMechanism = new PartyContactMechanism();
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyContactMechanisms.Add(partyContactMechanism);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanisms.ToArray();
        }

        public PartyContactMechanism[] ListWhereContactMechanismTypeIsLike(int pPartyID, string pContactMechanismPurposeTypeAlias)
        {
            List<PartyContactMechanism> partyContactMechanisms = new List<PartyContactMechanism>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_ListWhereContactMechanismTypeLikeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContactMechanismPurposeTypeAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyContactMechanism partyContactMechanism = new PartyContactMechanism(sqlDataReader.GetInt32(0));
                        partyContactMechanism.ContactMechanism = new Entities.PeopleAndPlaces.ContactMechanism(sqlDataReader.GetInt32(1));
                        partyContactMechanism.AllowSolicitation = sqlDataReader.GetBoolean(2);
                        partyContactMechanism.IsPreferredContactMechanism = sqlDataReader.GetBoolean(3);
                        partyContactMechanism.IsOverallPreferredContactMechanism = sqlDataReader.GetBoolean(4);
                        partyContactMechanism.AllowGlobalThirdPartyContact = sqlDataReader.GetBoolean(5);
                        partyContactMechanism.AllowLimitedThirdPartyContact = sqlDataReader.GetBoolean(6);
                        partyContactMechanism.FromDate = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            partyContactMechanism.ContactMechanism.ContactMechanismType = new Entities.PeopleAndPlaces.ContactMechanismType(sqlDataReader.GetInt32(8));
                        partyContactMechanisms.Add(partyContactMechanism);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyContactMechanism partyContactMechanism = new PartyContactMechanism();
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyContactMechanisms.Add(partyContactMechanism);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanisms.ToArray();
        }

        public PartyContactMechanism Insert(PartyContactMechanism pPartyContactMechanism, int pPartyID)
        {
            PartyContactMechanism partyContactMechanism = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismID", pPartyContactMechanism.ContactMechanism.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SoliciationIndicator", pPartyContactMechanism.AllowSolicitation));
                    sqlCommand.Parameters.Add(new SqlParameter("@TypePreferredIndicator", pPartyContactMechanism.IsPreferredContactMechanism));
                    sqlCommand.Parameters.Add(new SqlParameter("@OverallPreferredIndicator", pPartyContactMechanism.IsOverallPreferredContactMechanism));
                    sqlCommand.Parameters.Add(new SqlParameter("@GlobalThirdPartyIndicator", pPartyContactMechanism.AllowGlobalThirdPartyContact));
                    sqlCommand.Parameters.Add(new SqlParameter("@LimitedThirdPartyIndicator", pPartyContactMechanism.AllowLimitedThirdPartyContact));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyContactMechanism.FromDate));
                    SqlParameter partyContactMechanismID = sqlCommand.Parameters.Add("@PartyContactMechanismID", SqlDbType.Int);
                    partyContactMechanismID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyContactMechanism = new PartyContactMechanism((Int32)partyContactMechanismID.Value);
                    partyContactMechanism.ContactMechanism = new Entities.PeopleAndPlaces.ContactMechanism(pPartyContactMechanism.ContactMechanism.ContactMechanismID);
                    partyContactMechanism.AllowSolicitation = pPartyContactMechanism.AllowSolicitation;
                    partyContactMechanism.IsPreferredContactMechanism = pPartyContactMechanism.IsPreferredContactMechanism;
                    partyContactMechanism.IsOverallPreferredContactMechanism = pPartyContactMechanism.IsOverallPreferredContactMechanism;
                    partyContactMechanism.AllowGlobalThirdPartyContact = pPartyContactMechanism.AllowGlobalThirdPartyContact;
                    partyContactMechanism.AllowLimitedThirdPartyContact = pPartyContactMechanism.AllowLimitedThirdPartyContact;
                    partyContactMechanism.FromDate = pPartyContactMechanism.FromDate;
                }
                catch (Exception exc)
                {
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanism;
        }

        public PartyContactMechanism Update(PartyContactMechanism pPartyContactMechanism, int pPartyID)
        {
            PartyContactMechanism partyContactMechanism = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyContactMechanismID", pPartyContactMechanism.PartyContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismID", pPartyContactMechanism.ContactMechanism.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SoliciationIndicator", pPartyContactMechanism.AllowSolicitation));
                    sqlCommand.Parameters.Add(new SqlParameter("@TypePreferredIndicator", pPartyContactMechanism.IsPreferredContactMechanism));
                    sqlCommand.Parameters.Add(new SqlParameter("@OverallPreferredIndicator", pPartyContactMechanism.IsOverallPreferredContactMechanism));
                    sqlCommand.Parameters.Add(new SqlParameter("@GlobalThirdPartyIndicator", pPartyContactMechanism.AllowGlobalThirdPartyContact));
                    sqlCommand.Parameters.Add(new SqlParameter("@LimitedThirdPartyIndicator", pPartyContactMechanism.AllowLimitedThirdPartyContact));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyContactMechanism.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    partyContactMechanism = new PartyContactMechanism(pPartyContactMechanism.PartyContactMechanismID);
                    partyContactMechanism.ContactMechanism = new Entities.PeopleAndPlaces.ContactMechanism(pPartyContactMechanism.ContactMechanism.ContactMechanismID);
                    partyContactMechanism.AllowSolicitation = pPartyContactMechanism.AllowSolicitation;
                    partyContactMechanism.IsPreferredContactMechanism = pPartyContactMechanism.IsPreferredContactMechanism;
                    partyContactMechanism.IsOverallPreferredContactMechanism = pPartyContactMechanism.IsOverallPreferredContactMechanism;
                    partyContactMechanism.AllowGlobalThirdPartyContact = pPartyContactMechanism.AllowGlobalThirdPartyContact;
                    partyContactMechanism.AllowLimitedThirdPartyContact = pPartyContactMechanism.AllowLimitedThirdPartyContact;
                    partyContactMechanism.FromDate = pPartyContactMechanism.FromDate;
                }
                catch (Exception exc)
                {
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanism;
        }

        public PartyContactMechanism Delete(PartyContactMechanism pPartyContactMechanism)
        {
            PartyContactMechanism partyContactMechanism = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanism_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyContactMechanismID", pPartyContactMechanism.PartyContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    partyContactMechanism = new PartyContactMechanism(pPartyContactMechanism.PartyContactMechanismID);
                }
                catch (Exception exc)
                {
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanism;
        }

        public PartyContactMechanism AssignPurposeType(int pPartyContactMechanismID, int pContactMechanismPurposeTypeID, DateTime pFromDate)
        {
            PartyContactMechanism partyContactMechanism = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanismPurposeType_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyContactMechanismID", pPartyContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismPurposeTypeID", pContactMechanismPurposeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));

                    sqlCommand.ExecuteNonQuery();

                    partyContactMechanism = new PartyContactMechanism(pPartyContactMechanismID);
                }
                catch (Exception exc)
                {
                    partyContactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyContactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyContactMechanism;
        }

        public PartyContactMechanism RemovePurposeType(int pPartyContactMechanismID, int pContactMechanismPurposeTypeID)
        {
            PartyContactMechanism party = new PartyContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyContactMechanismPurposeType_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyContactMechanismID", pPartyContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismPurposeTypeID", pContactMechanismPurposeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    party = new PartyContactMechanism(pContactMechanismPurposeTypeID);
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

