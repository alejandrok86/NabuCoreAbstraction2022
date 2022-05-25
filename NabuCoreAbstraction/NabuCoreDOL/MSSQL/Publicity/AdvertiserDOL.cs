using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class AdvertiserDOL : BaseDOL
    {
        public AdvertiserDOL() : base()
        {
        }

        public AdvertiserDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Advertiser Get(int pAdvertiserID, int pLanguageID)
        {
            Advertiser advertiser = new Advertiser();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertiser_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertiserID", pAdvertiserID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        advertiser = new Advertiser(sqlDataReader.GetInt32(0));
                        advertiser.Name = sqlDataReader.GetString(1);
                        advertiser.PartyType = new PartyType(sqlDataReader.GetInt32(2));
                        advertiser.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    advertiser.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertiser.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertiser;
        }

        public Advertiser[] List(int pLanguageID)
        {
            List<Advertiser> advertisers = new List<Advertiser>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertiser_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Advertiser advertiser = new Advertiser(sqlDataReader.GetInt32(0));
                        advertiser.Name = sqlDataReader.GetString(1);
                        advertiser.PartyType = new PartyType(sqlDataReader.GetInt32(2));
                        advertiser.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);

                        advertisers.Add(advertiser);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Advertiser advertiser = new Advertiser();
                    advertiser.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertiser.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    advertisers.Add(advertiser);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisers.ToArray();
        }

        public Advertiser Insert(Advertiser pAdvertiser)
        {
            Advertiser advertiser = new Advertiser();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertiser_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAdvertiser.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAdvertiser.PartyType.PartyTypeID));
                    SqlParameter advertiserID = sqlCommand.Parameters.Add("@AdvertiserID", SqlDbType.Int);
                    advertiserID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    advertiser = new Advertiser((Int32)advertiserID.Value);
                    advertiser.Name = pAdvertiser.Name;
                    advertiser.PartyType = new PartyType(pAdvertiser.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    advertiser.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertiser.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertiser;
        }

        public Advertiser Update(Advertiser pAdvertiser)
        {
            Advertiser advertiser = new Advertiser();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertiser_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertiserID", pAdvertiser.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAdvertiser.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAdvertiser.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    advertiser = new Advertiser(pAdvertiser.PartyID);
                    advertiser.Name = pAdvertiser.Name;
                    advertiser.PartyType = new PartyType(pAdvertiser.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    advertiser.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertiser.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertiser;
        }

        public Advertiser Delete(Advertiser pAdvertiser)
        {
            Advertiser advertiser = new Advertiser();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertiser_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertiserID", pAdvertiser.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    advertiser = new Advertiser(pAdvertiser.PartyID);
                }
                catch (Exception exc)
                {
                    advertiser.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertiser.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertiser;
        }
    }
}
