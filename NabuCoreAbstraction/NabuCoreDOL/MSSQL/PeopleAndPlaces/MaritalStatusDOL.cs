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
    public class MaritalStatusDOL : BaseDOL
    {
        public MaritalStatusDOL() : base()
        {
        }

        public MaritalStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public MaritalStatus Get(int pMaritalStatusID, int pLanguageID)
        {
            MaritalStatus maritalStatus = new MaritalStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[MaritalStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatusID", pMaritalStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        maritalStatus = new MaritalStatus(sqlDataReader.GetInt32(0));
                        maritalStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    maritalStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    maritalStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return maritalStatus;
        }

        public MaritalStatus[] List(int pLanguageID)
        {
            List<MaritalStatus> maritalStatuss = new List<MaritalStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[MaritalStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        MaritalStatus maritalStatus = new MaritalStatus(sqlDataReader.GetInt32(0));
                        maritalStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        maritalStatuss.Add(maritalStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    MaritalStatus maritalStatus = new MaritalStatus();
                    maritalStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    maritalStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    maritalStatuss.Add(maritalStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return maritalStatuss.ToArray();
        }

        public MaritalStatus Insert(MaritalStatus pMaritalStatus)
        {
            MaritalStatus maritalStatus = new MaritalStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[MaritalStatus_Insert]");
                try
                {
                    pMaritalStatus.Detail = base.InsertTranslation(pMaritalStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pMaritalStatus.Detail.TranslationID));
                    SqlParameter maritalStatusID = sqlCommand.Parameters.Add("@MaritalStatusID", SqlDbType.Int);
                    maritalStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    maritalStatus = new MaritalStatus((Int32)maritalStatusID.Value);
                    maritalStatus.Detail = new Translation(pMaritalStatus.Detail.TranslationID);
                    maritalStatus.Detail.Alias = pMaritalStatus.Detail.Alias;
                    maritalStatus.Detail.Description = pMaritalStatus.Detail.Description;
                    maritalStatus.Detail.Name = pMaritalStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    maritalStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    maritalStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return maritalStatus;
        }

        public MaritalStatus Update(MaritalStatus pMaritalStatus)
        {
            MaritalStatus maritalStatus = new MaritalStatus();

            pMaritalStatus.Detail = base.UpdateTranslation(pMaritalStatus.Detail);

            maritalStatus = new MaritalStatus(pMaritalStatus.MaritalStatusID);
            maritalStatus.Detail = new Translation(pMaritalStatus.Detail.TranslationID);
            maritalStatus.Detail.Alias = pMaritalStatus.Detail.Alias;
            maritalStatus.Detail.Description = pMaritalStatus.Detail.Description;
            maritalStatus.Detail.Name = pMaritalStatus.Detail.Name;

            return maritalStatus;
        }

        public MaritalStatus Delete(MaritalStatus pMaritalStatus)
        {
            MaritalStatus maritalStatus = new MaritalStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[MaritalStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatusID", pMaritalStatus.MaritalStatusID));

                    sqlCommand.ExecuteNonQuery();

                    maritalStatus = new MaritalStatus(pMaritalStatus.MaritalStatusID);
                    base.DeleteAllTranslations(pMaritalStatus.Detail);
                }
                catch (Exception exc)
                {
                    maritalStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    maritalStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return maritalStatus;
        }
    }
}
