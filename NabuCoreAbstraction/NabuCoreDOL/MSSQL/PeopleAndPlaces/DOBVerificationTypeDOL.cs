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
    public class DOBVerificationTypeDOL : BaseDOL
    {
        public DOBVerificationTypeDOL() : base()
        {
        }

        public DOBVerificationTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public DOBVerificationType Get(int pDOBVerificationTypeID, int pLanguageID)
        {
            DOBVerificationType dobVerificationType = new DOBVerificationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[DOBVerificationType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DOBVerificationTypeID", pDOBVerificationTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        dobVerificationType = new DOBVerificationType(sqlDataReader.GetInt32(0));
                        dobVerificationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    dobVerificationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dobVerificationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dobVerificationType;
        }

        public DOBVerificationType[] List(int pLanguageID)
        {
            List<DOBVerificationType> dobVerificationTypes = new List<DOBVerificationType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[DOBVerificationType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DOBVerificationType dobVerificationType = new DOBVerificationType(sqlDataReader.GetInt32(0));
                        dobVerificationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        dobVerificationTypes.Add(dobVerificationType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DOBVerificationType dobVerificationType = new DOBVerificationType();
                    dobVerificationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dobVerificationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    dobVerificationTypes.Add(dobVerificationType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dobVerificationTypes.ToArray();
        }

        public DOBVerificationType Insert(DOBVerificationType pDOBVerificationType)
        {
            DOBVerificationType dobVerificationType = new DOBVerificationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[DOBVerificationType_Insert]");
                try
                {
                    pDOBVerificationType.Detail = base.InsertTranslation(pDOBVerificationType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDOBVerificationType.Detail.TranslationID));
                    SqlParameter dobVerificationTypeID = sqlCommand.Parameters.Add("@DOBVerificationTypeID", SqlDbType.Int);
                    dobVerificationTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    dobVerificationType = new DOBVerificationType((Int32)dobVerificationTypeID.Value);
                    dobVerificationType.Detail = new Translation(pDOBVerificationType.Detail.TranslationID);
                    dobVerificationType.Detail.Alias = pDOBVerificationType.Detail.Alias;
                    dobVerificationType.Detail.Description = pDOBVerificationType.Detail.Description;
                    dobVerificationType.Detail.Name = pDOBVerificationType.Detail.Name;
                }
                catch (Exception exc)
                {
                    dobVerificationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dobVerificationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dobVerificationType;
        }

        public DOBVerificationType Update(DOBVerificationType pDOBVerificationType)
        {
            DOBVerificationType dobVerificationType = new DOBVerificationType();

            pDOBVerificationType.Detail = base.UpdateTranslation(pDOBVerificationType.Detail);

            dobVerificationType = new DOBVerificationType(pDOBVerificationType.DOBVerificationTypeID);
            dobVerificationType.Detail = new Translation(pDOBVerificationType.Detail.TranslationID);
            dobVerificationType.Detail.Alias = pDOBVerificationType.Detail.Alias;
            dobVerificationType.Detail.Description = pDOBVerificationType.Detail.Description;
            dobVerificationType.Detail.Name = pDOBVerificationType.Detail.Name;

            return dobVerificationType;
        }

        public DOBVerificationType Delete(DOBVerificationType pDOBVerificationType)
        {
            DOBVerificationType dobVerificationType = new DOBVerificationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[DOBVerificationType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DOBVerificationTypeID", pDOBVerificationType.DOBVerificationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    dobVerificationType = new DOBVerificationType(pDOBVerificationType.DOBVerificationTypeID);
                    base.DeleteAllTranslations(pDOBVerificationType.Detail);
                }
                catch (Exception exc)
                {
                    dobVerificationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dobVerificationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dobVerificationType;
        }
    }
}
