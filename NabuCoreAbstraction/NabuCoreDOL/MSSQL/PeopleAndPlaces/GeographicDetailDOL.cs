using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces
{
    public class GeographicDetailDOL : BaseDOL
    {
        public GeographicDetailDOL() : base()
        {
        }

        public GeographicDetailDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public GeographicDetail Get(int pGeographicDetailID, int pLanguageID)
        {
            GeographicDetail geographicDetail = new GeographicDetail();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetail_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailID", pGeographicDetailID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        geographicDetail = new GeographicDetail(sqlDataReader.GetInt32(0));
                        geographicDetail.GeographicDetailType = new GeographicDetailType(sqlDataReader.GetInt32(1));
                        geographicDetail.GeographicDetailType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        geographicDetail.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    geographicDetail.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetail.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetail;
        }

        public GeographicDetail[] List(int pLanguageID)
        {
            List<GeographicDetail> geographicDetails = new List<GeographicDetail>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetail_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GeographicDetail geographicDetail = new GeographicDetail(sqlDataReader.GetInt32(0));
                        geographicDetail.GeographicDetailType = new GeographicDetailType(sqlDataReader.GetInt32(1));
                        geographicDetail.GeographicDetailType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        geographicDetail.FromDate = sqlDataReader.GetDateTime(3);

                        geographicDetails.Add(geographicDetail);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    GeographicDetail geographicDetail = new GeographicDetail();
                    geographicDetail.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetail.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    geographicDetails.Add(geographicDetail);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetails.ToArray();
        }

        public GeographicDetail Insert(GeographicDetail pGeographicDetail)
        {
            GeographicDetail geographicDetail = new GeographicDetail();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetail_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailTypeID", pGeographicDetail.GeographicDetailType.GeographicDetailTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pGeographicDetail.FromDate));
                    SqlParameter geographicDetailID = sqlCommand.Parameters.Add("@GeographicDetailID", SqlDbType.Int);
                    geographicDetailID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    geographicDetail = new GeographicDetail((Int32)geographicDetailID.Value);
                    geographicDetail.GeographicDetailType = new GeographicDetailType(pGeographicDetail.GeographicDetailType.GeographicDetailTypeID);
                    geographicDetail.FromDate = pGeographicDetail.FromDate;
                }
                catch (Exception exc)
                {
                    geographicDetail.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetail.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetail;
        }

        public GeographicDetail Update(GeographicDetail pGeographicDetail)
        {
            GeographicDetail geographicDetail = new GeographicDetail();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetail_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailID", pGeographicDetail.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailTypeID", pGeographicDetail.GeographicDetailType.GeographicDetailTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pGeographicDetail.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    geographicDetail = new GeographicDetail(pGeographicDetail.GeographicDetailID);
                    geographicDetail.GeographicDetailType = new GeographicDetailType(pGeographicDetail.GeographicDetailType.GeographicDetailTypeID);
                    geographicDetail.FromDate = pGeographicDetail.FromDate;
                }
                catch (Exception exc)
                {
                    geographicDetail.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetail.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetail;
        }

        public GeographicDetail Delete(GeographicDetail pGeographicDetail)
        {
            GeographicDetail geographicDetail = new GeographicDetail();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetail_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailID", pGeographicDetail.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    geographicDetail = new GeographicDetail(pGeographicDetail.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    geographicDetail.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetail.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetail;
        }
    }
}


