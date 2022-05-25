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
    public class PartyGroupDOL : BaseDOL
    {
        public PartyGroupDOL() : base()
        {
        }

        public PartyGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyGroup Get(int pPartyGroupID, int pLanguageID)
        {
            PartyGroup partyGroup = new PartyGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupID", pPartyGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyGroup = new PartyGroup(sqlDataReader.GetInt32(0));
                        partyGroup.PartyGroupType = new PartyGroupType(sqlDataReader.GetInt32(1));
                        partyGroup.PartyGroupType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroup;
        }
       
        public PartyGroup[] List(int pPartyID, int pLanguageID)
        {
            List<PartyGroup> partyGroups = new List<PartyGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyGroup partyGroup = new PartyGroup(sqlDataReader.GetInt32(0));
                        partyGroup.PartyGroupType = new PartyGroupType(sqlDataReader.GetInt32(1));
                        partyGroup.PartyGroupType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyGroups.Add(partyGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyGroup partyGroup = new PartyGroup();
                    partyGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyGroups.Add(partyGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroups.ToArray();
        }

        public PartyGroup Insert(PartyGroup pPartyGroup,int pPartyID)
        {
            PartyGroup partyGroup = new PartyGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroup_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupTypeID", pPartyGroup.PartyGroupType.PartyGroupTypeID));
                    SqlParameter partyGroupID = sqlCommand.Parameters.Add("@PartyGroupID", SqlDbType.Int);
                    partyGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyGroup = new PartyGroup((Int32)partyGroupID.Value);
                    partyGroup.PartyGroupType = pPartyGroup.PartyGroupType;
                    partyGroup.Members = pPartyGroup.Members;
                }
                catch (Exception exc)
                {
                    partyGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroup;
        }

        public PartyGroup Update(PartyGroup pPartyGroup, int pPartyID)
        {
            PartyGroup partyGroup = new PartyGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroup_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupID", pPartyGroup.PartyGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupTypeID", pPartyGroup.PartyGroupType.PartyGroupTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyGroup = new PartyGroup(pPartyGroup.PartyGroupID);
                    partyGroup.PartyGroupType = pPartyGroup.PartyGroupType;
                    partyGroup.Members = pPartyGroup.Members;
                }
                catch (Exception exc)
                {
                    partyGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroup;
        }

        public PartyGroup Delete(PartyGroup pPartyGroup)
        {
            PartyGroup partyGroup = new PartyGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupID", pPartyGroup.PartyGroupID));

                    sqlCommand.ExecuteNonQuery();

                    partyGroup = new PartyGroup(pPartyGroup.PartyGroupID);
                }
                catch (Exception exc)
                {
                    partyGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroup;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean AssignMember(int pPartyGroupID, int pPartyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupMember_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupID", pPartyGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;
                    result.Value = false;
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

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean RemoveMember(int pPartyGroupID, int pPartyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupMember_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupID", pPartyGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;
                    result.Value = false;
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
    }
}
