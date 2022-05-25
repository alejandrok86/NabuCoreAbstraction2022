using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class ShareLocationGroupDOL : BaseDOL
    {
        public ShareLocationGroupDOL() : base()
        {
        }

        public ShareLocationGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ShareLocationGroup Get(int pShareLocationGroupID)
        {
            ShareLocationGroup shareLocationGroup = new ShareLocationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID", pShareLocationGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        shareLocationGroup = new ShareLocationGroup(sqlDataReader.GetInt32(0));
                        shareLocationGroup.Name = sqlDataReader.GetString(1);
                        shareLocationGroup.ShareLocationType = new ShareLocationType(sqlDataReader.GetInt32(2));
                        shareLocationGroup.DisplaySequence = sqlDataReader.GetInt32(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    shareLocationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationGroup;
        }

        public ShareLocationGroup[] List(int pOwnerPartyID)
        {
            List<ShareLocationGroup> shareLocationGroups = new List<ShareLocationGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OnwerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ShareLocationGroup shareLocationGroup = new ShareLocationGroup(sqlDataReader.GetInt32(0));
                        shareLocationGroup.Name = sqlDataReader.GetString(1);
                        shareLocationGroup.ShareLocationType = new ShareLocationType(sqlDataReader.GetInt32(2));
                        shareLocationGroup.DisplaySequence = sqlDataReader.GetInt32(3);
                        shareLocationGroups.Add(shareLocationGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ShareLocationGroup shareLocationGroup = new ShareLocationGroup();
                    shareLocationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    shareLocationGroups.Add(shareLocationGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationGroups.ToArray();
        }

        public ShareLocationGroup Insert(ShareLocationGroup pShareLocationGroup, int pOwnerPartyID)
        {
            ShareLocationGroup shareLocationGroup = new ShareLocationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocationGroup.ShareLocationType.ShareLocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnwerPartyID", pOwnerPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pShareLocationGroup.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pShareLocationGroup.DisplaySequence));
                    SqlParameter shareLocationGroupID = sqlCommand.Parameters.Add("@ShareLocationGroupID", SqlDbType.Int);
                    shareLocationGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    shareLocationGroup = new ShareLocationGroup((Int32)shareLocationGroupID.Value);
                    shareLocationGroup.Name = pShareLocationGroup.Name;
                    shareLocationGroup.ShareLocationType = pShareLocationGroup.ShareLocationType;
                    shareLocationGroup.DisplaySequence = pShareLocationGroup.DisplaySequence;
                }
                catch (Exception exc)
                {
                    shareLocationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationGroup;
        }

        public ShareLocationGroup Update(ShareLocationGroup pShareLocationGroup)
        {
            ShareLocationGroup shareLocationGroup = new ShareLocationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID",pShareLocationGroup.ShareLocationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pShareLocationGroup.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocationGroup.ShareLocationType.ShareLocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pShareLocationGroup.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    shareLocationGroup = new ShareLocationGroup(pShareLocationGroup.ShareLocationGroupID);
                    shareLocationGroup.Name = pShareLocationGroup.Name;
                    shareLocationGroup.ShareLocationType = pShareLocationGroup.ShareLocationType;
                    shareLocationGroup.DisplaySequence = pShareLocationGroup.DisplaySequence;
                }
                catch (Exception exc)
                {
                    shareLocationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationGroup;
        }

        public ShareLocationGroup Delete(ShareLocationGroup pShareLocationGroup)
        {
            ShareLocationGroup shareLocationGroup = new ShareLocationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID", pShareLocationGroup.ShareLocationGroupID));

                    sqlCommand.ExecuteNonQuery();

                    shareLocationGroup = new ShareLocationGroup(pShareLocationGroup.ShareLocationGroupID);
                }
                catch (Exception exc)
                {
                    shareLocationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationGroup;
        }

        public BaseBoolean AddMember(int pShareLocationGroupID, int pMemberPartyID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_AddMember]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID", pShareLocationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MemberPartyID", pMemberPartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
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

        public BaseBoolean RemoveMember(int pShareLocationGroupID, int pMemberPartyID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_RemoveMember]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID", pShareLocationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MemberPartyID", pMemberPartyID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
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

        public Entities.Core.Party[] ListMembers(int pShareLocationGroupID)
        {
            List<Entities.Core.Party> members = new List<Entities.Core.Party>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationGroup_ListMembers]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationGroupID", pShareLocationGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Core.Party member = new Entities.Core.Party(sqlDataReader.GetInt32(0));
                        members.Add(member);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Core.Party error = new Entities.Core.Party();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    members.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return members.ToArray();
        }
    }
}
