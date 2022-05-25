using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class SharingDOL : BaseDOL
    {
        public SharingDOL() : base ()
        {
        }

        public SharingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Sharing Get(int pShareID)
        {
            Sharing share = new Sharing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareID", pShareID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        share = new Sharing(sqlDataReader.GetInt32(0));
                        share.SharedBy = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        share.SharedOn = sqlDataReader.GetDateTime(2);
                        share.RetrievalToken = Guid.Parse(sqlDataReader.GetString(3));
                        share.ShareConfigurationXML = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return share;
        }

        public Sharing GetByRetrievalToken(string pRetrievalToken)
        {
            Sharing share = new Sharing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", pRetrievalToken));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        share = new Sharing(sqlDataReader.GetInt32(0));
                        share.SharedBy = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        share.SharedOn = sqlDataReader.GetDateTime(2);
                        share.RetrievalToken = Guid.Parse(sqlDataReader.GetString(3));
                        share.ShareConfigurationXML = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return share;
        }

        public Sharing[] List(int pPartyID)
        {
            List<Sharing> shares = new List<Sharing>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Sharing share = new Sharing(sqlDataReader.GetInt32(0));
                        share.SharedBy = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        share.SharedOn = sqlDataReader.GetDateTime(2);
                        share.RetrievalToken = Guid.Parse(sqlDataReader.GetString(3));
                        share.ShareConfigurationXML = sqlDataReader.GetString(4);
                        shares.Add(share);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Sharing share = new Sharing();
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    shares.Add(share);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shares.ToArray();
        }

        public Sharing Insert(Sharing pShare)
        {
            Sharing share = new Sharing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SharedByPartyID", pShare.SharedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SharedOn", pShare.SharedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", pShare.RetrievalToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareConfigurationXML", pShare.ShareConfigurationXML));
                    SqlParameter ShareID = sqlCommand.Parameters.Add("@ShareID", SqlDbType.Int);
                    ShareID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    share = new Sharing((Int32)ShareID.Value);
                    share.RetrievalToken = pShare.RetrievalToken;
                    share.ShareConfigurationXML = pShare.ShareConfigurationXML;
                    share.SharedBy = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(pShare.SharedBy.PartyID);
                    share.SharedOn = pShare.SharedOn;
                }
                catch (Exception exc)
                {
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return share;
        }

        public Sharing Update(Sharing pShare)
        {
            Sharing share = new Sharing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareID", pShare.ShareID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SharedByPartyID", pShare.SharedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SharedOn", pShare.SharedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", pShare.RetrievalToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareConfigurationXML", pShare.ShareConfigurationXML));

                    sqlCommand.ExecuteNonQuery();

                    share = new Sharing(pShare.ShareID);
                    share.RetrievalToken = pShare.RetrievalToken;
                    share.ShareConfigurationXML = pShare.ShareConfigurationXML;
                    share.SharedBy = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(pShare.SharedBy.PartyID);
                    share.SharedOn = pShare.SharedOn;
                }
                catch (Exception exc)
                {
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return share;
        }

        public Sharing Delete(Sharing pShare)
        {
            Sharing share = new Sharing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Sharing_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareID", pShare.ShareID));

                    sqlCommand.ExecuteNonQuery();

                    share = new Sharing(pShare.ShareID);
                }
                catch (Exception exc)
                {
                    share.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    share.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return share;
        }
    }
}

