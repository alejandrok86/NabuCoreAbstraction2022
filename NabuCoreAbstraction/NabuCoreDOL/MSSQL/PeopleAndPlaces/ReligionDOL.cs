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
    public class ReligionDOL : BaseDOL
    {
        public ReligionDOL() : base()
        {
        }

        public ReligionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Religion Get(int pReligionID, int pLanguageID)
        {
            Religion religion = new Religion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Religion_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ReligionID", pReligionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        religion = new Religion(sqlDataReader.GetInt32(0));
                        religion.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    religion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    religion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return religion;
        }

        public Religion[] List(int pLanguageID)
        {
            List<Religion> religions = new List<Religion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Religion_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Religion religion = new Religion(sqlDataReader.GetInt32(0));
                        religion.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        religions.Add(religion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Religion religion = new Religion();
                    religion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    religion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    religions.Add(religion);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return religions.ToArray();
        }

        public Religion Insert(Religion pReligion)
        {
            Religion religion = new Religion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Religion_Insert]");
                try
                {
                    pReligion.Detail = base.InsertTranslation(pReligion.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pReligion.Detail.TranslationID));
                    SqlParameter religionID = sqlCommand.Parameters.Add("@ReligionID", SqlDbType.Int);
                    religionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    religion = new Religion((Int32)religionID.Value);
                    religion.Detail = new Translation(pReligion.Detail.TranslationID);
                    religion.Detail.Alias = pReligion.Detail.Alias;
                    religion.Detail.Description = pReligion.Detail.Description;
                    religion.Detail.Name = pReligion.Detail.Name;
                }
                catch (Exception exc)
                {
                    religion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    religion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return religion;
        }

        public Religion Update(Religion pReligion)
        {
            Religion religion = new Religion();

            pReligion.Detail = base.UpdateTranslation(pReligion.Detail);

            religion = new Religion(pReligion.ReligionID);
            religion.Detail = new Translation(pReligion.Detail.TranslationID);
            religion.Detail.Alias = pReligion.Detail.Alias;
            religion.Detail.Description = pReligion.Detail.Description;
            religion.Detail.Name = pReligion.Detail.Name;

            return religion;
        }

        public Religion Delete(Religion pReligion)
        {
            Religion religion = new Religion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Religion_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ReligionID", pReligion.ReligionID));

                    sqlCommand.ExecuteNonQuery();

                    religion = new Religion(pReligion.ReligionID);
                    base.DeleteAllTranslations(pReligion.Detail);
                }
                catch (Exception exc)
                {
                    religion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    religion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return religion;
        }
    }
}
