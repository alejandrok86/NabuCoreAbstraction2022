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
    public class EthnicityDOL : BaseDOL
    {
        public EthnicityDOL() : base()
        {
        }

        public EthnicityDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Ethnicity Get(int pEthnicityID, int pLanguageID)
        {
            Ethnicity ethnicity = new Ethnicity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Ethnicity_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EthnicityID", pEthnicityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ethnicity = new Ethnicity(sqlDataReader.GetInt32(0));
                        ethnicity.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ethnicity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicity;
        }

        public Ethnicity[] List(int pLanguageID)
        {
            List<Ethnicity> ethnicitys = new List<Ethnicity>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Ethnicity_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Ethnicity ethnicity = new Ethnicity(sqlDataReader.GetInt32(0));
                        ethnicity.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ethnicitys.Add(ethnicity);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Ethnicity ethnicity = new Ethnicity();
                    ethnicity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ethnicitys.Add(ethnicity);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicitys.ToArray();
        }

        public Ethnicity Insert(Ethnicity pEthnicity)
        {
            Ethnicity ethnicity = new Ethnicity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Ethnicity_Insert]");
                try
                {
                    pEthnicity.Detail = base.InsertTranslation(pEthnicity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pEthnicity.Detail.TranslationID));
                    SqlParameter ethnicityID = sqlCommand.Parameters.Add("@EthnicityID", SqlDbType.Int);
                    ethnicityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    ethnicity = new Ethnicity((Int32)ethnicityID.Value);
                    ethnicity.Detail = new Translation(pEthnicity.Detail.TranslationID);
                    ethnicity.Detail.Alias = pEthnicity.Detail.Alias;
                    ethnicity.Detail.Description = pEthnicity.Detail.Description;
                    ethnicity.Detail.Name = pEthnicity.Detail.Name;
                }
                catch (Exception exc)
                {
                    ethnicity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicity;
        }

        public Ethnicity Update(Ethnicity pEthnicity)
        {
            Ethnicity ethnicity = new Ethnicity();

            pEthnicity.Detail = base.UpdateTranslation(pEthnicity.Detail);

            ethnicity = new Ethnicity(pEthnicity.EthnicityID);
            ethnicity.Detail = new Translation(pEthnicity.Detail.TranslationID);
            ethnicity.Detail.Alias = pEthnicity.Detail.Alias;
            ethnicity.Detail.Description = pEthnicity.Detail.Description;
            ethnicity.Detail.Name = pEthnicity.Detail.Name;

            return ethnicity;
        }

        public Ethnicity Delete(Ethnicity pEthnicity)
        {
            Ethnicity ethnicity = new Ethnicity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Ethnicity_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EthnicityID", pEthnicity.EthnicityID));

                    sqlCommand.ExecuteNonQuery();

                    ethnicity = new Ethnicity(pEthnicity.EthnicityID);
                    base.DeleteAllTranslations(pEthnicity.Detail);
                }
                catch (Exception exc)
                {
                    ethnicity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicity;
        }
    }
}
