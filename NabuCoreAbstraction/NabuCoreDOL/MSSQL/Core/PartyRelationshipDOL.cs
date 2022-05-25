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
    public class PartyRelationshipDOL : BaseDOL
    {
        public PartyRelationshipDOL() : base()
        {
        }

        public PartyRelationshipDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyRelationship Get(int pPartyRelationshipID, int pLanguageID)
        {
            PartyRelationship partyRelationship = new PartyRelationship();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipID", pPartyRelationshipID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRelationship = new PartyRelationship(sqlDataReader.GetInt32(0));
                        partyRelationship.FromPartyRole = new PartyRole(sqlDataReader.GetInt32(1));
                        partyRelationship.ToPartyRole = new PartyRole(sqlDataReader.GetInt32(2));
                        partyRelationship.PartyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(3));
                        partyRelationship.PartyRelationshipType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        partyRelationship.FromDate = sqlDataReader.GetDateTime(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationship;
        }

        public PartyRelationship GetByParties(int pFromPartyID, int pToPartyID, int pLanguageID)
        {
            PartyRelationship partyRelationship = new PartyRelationship();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_GetByParties]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FromPartyID", pFromPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToPartyID", pToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRelationship = new PartyRelationship(sqlDataReader.GetInt32(0));
                        partyRelationship.FromPartyRole = new PartyRole(sqlDataReader.GetInt32(1));
                        partyRelationship.ToPartyRole = new PartyRole(sqlDataReader.GetInt32(2));
                        partyRelationship.PartyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(3));
                        partyRelationship.PartyRelationshipType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        partyRelationship.FromDate = sqlDataReader.GetDateTime(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationship;
        }

        public PartyRelationship[] ListTo(int pToPartyID, int pLanguageID)
        {
            List<PartyRelationship> partyRelationships = new List<PartyRelationship>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_ListTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ToPartyID", pToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyRelationship partyRelationship = new PartyRelationship(sqlDataReader.GetInt32(0));
                        partyRelationship.FromPartyID = sqlDataReader.GetInt32(1);
                        partyRelationship.FromPartyRole = new PartyRole(sqlDataReader.GetInt32(2));
                        partyRelationship.FromPartyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(3));
                        partyRelationship.FromPartyRole.PartyRoleType.Detail = new Translation(sqlDataReader.GetInt32(4));
                        partyRelationship.ToPartyID = sqlDataReader.GetInt32(5);
                        partyRelationship.ToPartyRole = new PartyRole(sqlDataReader.GetInt32(6));
                        partyRelationship.ToPartyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(7));
                        partyRelationship.ToPartyRole.PartyRoleType.Detail = new Translation(sqlDataReader.GetInt32(8));
                        partyRelationship.PartyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(9));
                        partyRelationship.PartyRelationshipType.Detail = GetTranslation(sqlDataReader.GetInt32(10),pLanguageID);
                        partyRelationship.FromDate = sqlDataReader.GetDateTime(11);
                        partyRelationships.Add(partyRelationship);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRelationship partyRelationship = new PartyRelationship();
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRelationships.Add(partyRelationship);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationships.ToArray();
        }

        public PartyRelationship[] ListFrom(int pFromPartyID, int pLanguageID)
        {
            List<PartyRelationship> partyRelationships = new List<PartyRelationship>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_ListFrom]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FromPartyID", pFromPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyRelationship partyRelationship = new PartyRelationship(sqlDataReader.GetInt32(0));
                        partyRelationship.FromPartyID = sqlDataReader.GetInt32(1);
                        partyRelationship.FromPartyRole = new PartyRole(sqlDataReader.GetInt32(2));
                        partyRelationship.FromPartyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(3));
                        partyRelationship.FromPartyRole.PartyRoleType.Detail = new Translation(sqlDataReader.GetInt32(4));
                        partyRelationship.ToPartyID = sqlDataReader.GetInt32(5);
                        partyRelationship.ToPartyRole = new PartyRole(sqlDataReader.GetInt32(6));
                        partyRelationship.ToPartyRole.PartyRoleType = new PartyRoleType(sqlDataReader.GetInt32(7));
                        partyRelationship.ToPartyRole.PartyRoleType.Detail = new Translation(sqlDataReader.GetInt32(8));
                        partyRelationship.PartyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(9));
                        partyRelationship.PartyRelationshipType.Detail = GetTranslation(sqlDataReader.GetInt32(10),pLanguageID);
                        partyRelationship.FromDate = sqlDataReader.GetDateTime(11);
                        partyRelationships.Add(partyRelationship);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRelationship partyRelationship = new PartyRelationship();
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRelationships.Add(partyRelationship);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationships.ToArray();
        }

        public PartyRelationship Insert(PartyRelationship pPartyRelationship)
        {
            PartyRelationship partyRelationship = new PartyRelationship();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FromPartyRoleID", pPartyRelationship.FromPartyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToPartyRoleID", pPartyRelationship.ToPartyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipTypeID", pPartyRelationship.PartyRelationshipType.PartyRelationshipTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyRelationship.FromDate));
                    SqlParameter partyRelationshipID = sqlCommand.Parameters.Add("@PartyRelationshipID", SqlDbType.Int);
                    partyRelationshipID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyRelationship = new PartyRelationship((Int32)partyRelationshipID.Value);
                    partyRelationship.FromPartyRole = new PartyRole(pPartyRelationship.FromPartyRole.PartyRoleID);
                    partyRelationship.ToPartyRole = new PartyRole(pPartyRelationship.ToPartyRole.PartyRoleID);
                    partyRelationship.PartyRelationshipType = new PartyRelationshipType(pPartyRelationship.PartyRelationshipType.PartyRelationshipTypeID);
                    partyRelationship.FromDate = pPartyRelationship.FromDate; 
                }
                catch (Exception exc)
                {
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationship;
        }

        public PartyRelationship Update(PartyRelationship pPartyRelationship)
        {
            PartyRelationship partyRelationship = new PartyRelationship();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipID", pPartyRelationship.PartyRelationshipID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromPartyRoleID", pPartyRelationship.FromPartyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToPartyRoleID", pPartyRelationship.ToPartyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipTypeID", pPartyRelationship.PartyRelationshipType.PartyRelationshipTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPartyRelationship.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    partyRelationship = new PartyRelationship(pPartyRelationship.PartyRelationshipID);
                    partyRelationship.FromPartyRole = new PartyRole(pPartyRelationship.FromPartyRole.PartyRoleID);
                    partyRelationship.ToPartyRole = new PartyRole(pPartyRelationship.ToPartyRole.PartyRoleID);
                    partyRelationship.PartyRelationshipType = new PartyRelationshipType(pPartyRelationship.PartyRelationshipType.PartyRelationshipTypeID);
                    partyRelationship.FromDate = pPartyRelationship.FromDate;
                }
                catch (Exception exc)
                {
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationship;
        }

        public PartyRelationship Delete(PartyRelationship pPartyRelationship)
        {
            PartyRelationship partyRelationship = new PartyRelationship();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationship_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipID", pPartyRelationship.PartyRelationshipID));

                    sqlCommand.ExecuteNonQuery();

                    partyRelationship = new PartyRelationship(pPartyRelationship.PartyRelationshipID);
                }
                catch (Exception exc)
                {
                    partyRelationship.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationship.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationship;
        }
    }
}
