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
    public class DwellingDOL : BaseDOL
    {
        public DwellingDOL() : base()
        {
        }

        public DwellingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Dwelling Get(int pDwellingID, int pLanguageID)
        {
            Dwelling dwelling = new Dwelling();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Dwelling_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DwellingID", pDwellingID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        dwelling = new Dwelling(sqlDataReader.GetInt32(0));
                        dwelling.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    dwelling.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dwelling.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dwelling;
        }

        public Dwelling[] List(int pLanguageID)
        {
            List<Dwelling> dwellings = new List<Dwelling>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Dwelling_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Dwelling dwelling = new Dwelling(sqlDataReader.GetInt32(0));
                        dwelling.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        dwellings.Add(dwelling);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Dwelling dwelling = new Dwelling();
                    dwelling.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dwelling.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    dwellings.Add(dwelling);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dwellings.ToArray();
        }

        public Dwelling Insert(Dwelling pDwelling)
        {
            Dwelling dwelling = new Dwelling();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Dwelling_Insert]");
                try
                {
                    pDwelling.Detail = base.InsertTranslation(pDwelling.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDwelling.Detail.TranslationID));
                    SqlParameter dwellingID = sqlCommand.Parameters.Add("@DwellingID", SqlDbType.Int);
                    dwellingID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    dwelling = new Dwelling((Int32)dwellingID.Value);
                    dwelling.Detail = new Translation(pDwelling.Detail.TranslationID);
                    dwelling.Detail.Alias = pDwelling.Detail.Alias;
                    dwelling.Detail.Description = pDwelling.Detail.Description;
                    dwelling.Detail.Name = pDwelling.Detail.Name;
                }
                catch (Exception exc)
                {
                    dwelling.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dwelling.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dwelling;
        }

        public Dwelling Update(Dwelling pDwelling)
        {
            Dwelling dwelling = new Dwelling();

            pDwelling.Detail = base.UpdateTranslation(pDwelling.Detail);

            dwelling = new Dwelling(pDwelling.DwellingID);
            dwelling.Detail = new Translation(pDwelling.Detail.TranslationID);
            dwelling.Detail.Alias = pDwelling.Detail.Alias;
            dwelling.Detail.Description = pDwelling.Detail.Description;
            dwelling.Detail.Name = pDwelling.Detail.Name;

            return dwelling;
        }

        public Dwelling Delete(Dwelling pDwelling)
        {
            Dwelling dwelling = new Dwelling();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Dwelling_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DwellingID", pDwelling.DwellingID));

                    sqlCommand.ExecuteNonQuery();

                    dwelling = new Dwelling(pDwelling.DwellingID);
                    base.DeleteAllTranslations(pDwelling.Detail);
                }
                catch (Exception exc)
                {
                    dwelling.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dwelling.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dwelling;
        }
    }
}
