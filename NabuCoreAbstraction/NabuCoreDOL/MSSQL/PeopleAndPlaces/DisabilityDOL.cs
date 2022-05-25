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
    public class DisabilityDOL : BaseDOL
    {
        public DisabilityDOL() : base()
        {
        }

        public DisabilityDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Disability Get(int pDisabilityID, int pLanguageID)
        {
            Disability disability = new Disability();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Disability_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DisabilityID", pDisabilityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        disability = new Disability(sqlDataReader.GetInt32(0));
                        disability.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    disability.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    disability.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return disability;
        }

        public Disability[] List(int pLanguageID)
        {
            List<Disability> disabilitys = new List<Disability>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Disability_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Disability disability = new Disability(sqlDataReader.GetInt32(0));
                        disability.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        disabilitys.Add(disability);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Disability disability = new Disability();
                    disability.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    disability.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    disabilitys.Add(disability);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return disabilitys.ToArray();
        }

        public Disability Insert(Disability pDisability)
        {
            Disability disability = new Disability();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Disability_Insert]");
                try
                {
                    pDisability.Detail = base.InsertTranslation(pDisability.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDisability.Detail.TranslationID));
                    SqlParameter disabilityID = sqlCommand.Parameters.Add("@DisabilityID", SqlDbType.Int);
                    disabilityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    disability = new Disability((Int32)disabilityID.Value);
                    disability.Detail = new Translation(pDisability.Detail.TranslationID);
                    disability.Detail.Alias = pDisability.Detail.Alias;
                    disability.Detail.Description = pDisability.Detail.Description;
                    disability.Detail.Name = pDisability.Detail.Name;
                }
                catch (Exception exc)
                {
                    disability.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    disability.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return disability;
        }

        public Disability Update(Disability pDisability)
        {
            Disability disability = new Disability();

            pDisability.Detail = base.UpdateTranslation(pDisability.Detail);

            disability = new Disability(pDisability.DisabilityID);
            disability.Detail = new Translation(pDisability.Detail.TranslationID);
            disability.Detail.Alias = pDisability.Detail.Alias;
            disability.Detail.Description = pDisability.Detail.Description;
            disability.Detail.Name = pDisability.Detail.Name;

            return disability;
        }

        public Disability Delete(Disability pDisability)
        {
            Disability disability = new Disability();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Disability_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DisabilityID", pDisability.DisabilityID));

                    sqlCommand.ExecuteNonQuery();

                    disability = new Disability(pDisability.DisabilityID);
                    base.DeleteAllTranslations(pDisability.Detail);
                }
                catch (Exception exc)
                {
                    disability.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    disability.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return disability;
        }
    }
}
