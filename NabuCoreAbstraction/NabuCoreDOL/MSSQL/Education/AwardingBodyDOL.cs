using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AwardingBodyDOL : BaseDOL
    {
        public AwardingBodyDOL() : base ()
        {
        }

        public AwardingBodyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AwardingBody Get(int pAwardingBodyID, int pLanguageID)
        {
            AwardingBody awardingBody = new AwardingBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AwardingBody_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAwardingBodyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        awardingBody = new AwardingBody(sqlDataReader.GetInt32(0));
                        awardingBody.Name = sqlDataReader.GetString(1);
                        awardingBody.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        awardingBody.PartyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(3));
                        awardingBody.PartyType.Detail.Alias = sqlDataReader.GetString(4);
                        awardingBody.PartyType.Detail.Name = sqlDataReader.GetString(5);
                        awardingBody.PartyType.Detail.Description = sqlDataReader.GetString(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    awardingBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    awardingBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return awardingBody;
        }

        public AwardingBody[] List(int pLanguageID)
        {
            List<AwardingBody> awardingBodys = new List<AwardingBody>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AwardingBody_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AwardingBody awardingBody = new AwardingBody(sqlDataReader.GetInt32(0));
                        awardingBody.Name = sqlDataReader.GetString(1);
                        awardingBody.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        awardingBody.PartyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(3));
                        awardingBody.PartyType.Detail.Alias = sqlDataReader.GetString(4);
                        awardingBody.PartyType.Detail.Name = sqlDataReader.GetString(5);
                        awardingBody.PartyType.Detail.Description = sqlDataReader.GetString(6);
                        awardingBodys.Add(awardingBody);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AwardingBody awardingBody = new AwardingBody();
                    awardingBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    awardingBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    awardingBodys.Add(awardingBody);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return awardingBodys.ToArray();
        }

        public AwardingBody Insert(AwardingBody pAwardingBody)
        {
            AwardingBody awardingBody = new AwardingBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AwardingBody_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAwardingBody.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAwardingBody.PartyType.PartyTypeID));
                    SqlParameter awardingBodyID = sqlCommand.Parameters.Add("@AwardingBodyID", SqlDbType.Int);
                    awardingBodyID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    awardingBody = new AwardingBody((Int32)awardingBodyID.Value);
                    awardingBody.Name = pAwardingBody.Name;
                    awardingBody.PartyType = new Entities.Core.PartyType(pAwardingBody.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    awardingBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    awardingBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return awardingBody;
        }

        public AwardingBody Update(AwardingBody pAwardingBody)
        {
            AwardingBody awardingBody = new AwardingBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AwardingBody_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAwardingBody.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAwardingBody.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAwardingBody.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    awardingBody = new AwardingBody(pAwardingBody.PartyID);
                    awardingBody.Name = pAwardingBody.Name;
                    awardingBody.PartyType = new Entities.Core.PartyType(pAwardingBody.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    awardingBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    awardingBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return awardingBody;
        }

        public AwardingBody Delete(AwardingBody pAwardingBody)
        {
            AwardingBody awardingBody = new AwardingBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AwardingBody_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAwardingBody.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    awardingBody = new AwardingBody(pAwardingBody.PartyID);
                }
                catch (Exception exc)
                {
                    awardingBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    awardingBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return awardingBody;
        }
    }
}
