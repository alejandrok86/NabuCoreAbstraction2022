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
    public class TravellerTypeDOL : BaseDOL
    {
        public TravellerTypeDOL() : base()
        {
        }

        public TravellerTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TravellerType Get(int pTravellerTypeID, int pLanguageID)
        {
            TravellerType travellerType = new TravellerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TravellerType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TravellerTypeID", pTravellerTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        travellerType = new TravellerType(sqlDataReader.GetInt32(0));
                        travellerType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    travellerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    travellerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return travellerType;
        }

        public TravellerType[] List(int pLanguageID)
        {
            List<TravellerType> travellerTypes = new List<TravellerType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TravellerType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TravellerType travellerType = new TravellerType(sqlDataReader.GetInt32(0));
                        travellerType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        travellerTypes.Add(travellerType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TravellerType travellerType = new TravellerType();
                    travellerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    travellerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    travellerTypes.Add(travellerType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return travellerTypes.ToArray();
        }

        public TravellerType Insert(TravellerType pTravellerType)
        {
            TravellerType travellerType = new TravellerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TravellerType_Insert]");
                try
                {
                    pTravellerType.Detail = base.InsertTranslation(pTravellerType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTravellerType.Detail.TranslationID));
                    SqlParameter travellerTypeID = sqlCommand.Parameters.Add("@TravellerTypeID", SqlDbType.Int);
                    travellerTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    travellerType = new TravellerType((Int32)travellerTypeID.Value);
                    travellerType.Detail = new Translation(pTravellerType.Detail.TranslationID);
                    travellerType.Detail.Alias = pTravellerType.Detail.Alias;
                    travellerType.Detail.Description = pTravellerType.Detail.Description;
                    travellerType.Detail.Name = pTravellerType.Detail.Name;
                }
                catch (Exception exc)
                {
                    travellerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    travellerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return travellerType;
        }

        public TravellerType Update(TravellerType pTravellerType)
        {
            TravellerType travellerType = new TravellerType();

            pTravellerType.Detail = base.UpdateTranslation(pTravellerType.Detail);

            travellerType = new TravellerType(pTravellerType.TravellerTypeID);
            travellerType.Detail = new Translation(pTravellerType.Detail.TranslationID);
            travellerType.Detail.Alias = pTravellerType.Detail.Alias;
            travellerType.Detail.Description = pTravellerType.Detail.Description;
            travellerType.Detail.Name = pTravellerType.Detail.Name;

            return travellerType;
        }

        public TravellerType Delete(TravellerType pTravellerType)
        {
            TravellerType travellerType = new TravellerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TravellerType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TravellerTypeID", pTravellerType.TravellerTypeID));

                    sqlCommand.ExecuteNonQuery();

                    travellerType = new TravellerType(pTravellerType.TravellerTypeID);
                    base.DeleteAllTranslations(pTravellerType.Detail);
                }
                catch (Exception exc)
                {
                    travellerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    travellerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return travellerType;
        }
    }
}
