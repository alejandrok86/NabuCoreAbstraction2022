using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class SpecimenStatusDOL : BaseDOL
    {
        public SpecimenStatusDOL() : base ()
        {
        }

        public SpecimenStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SpecimenStatus Get(int pSpecimenStatusID, int pLanguageID)
        {
            SpecimenStatus specimenStatus = new SpecimenStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenStatusID", pSpecimenStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(0));
                        specimenStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specimenStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenStatus;
        }

        public SpecimenStatus[] List(int pLanguageID)
        {
            List<SpecimenStatus> specimenStatuss = new List<SpecimenStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecimenStatus specimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(0));
                        specimenStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        specimenStatuss.Add(specimenStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecimenStatus specimenStatus = new SpecimenStatus();
                    specimenStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimenStatuss.Add(specimenStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenStatuss.ToArray();
        }

        public SpecimenStatus Insert(SpecimenStatus pSpecimenStatus)
        {
            SpecimenStatus specimenStatus = new SpecimenStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenStatus_Insert]");
                try
                {
                    pSpecimenStatus.Detail = base.InsertTranslation(pSpecimenStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pSpecimenStatus.Detail.TranslationID));
                    SqlParameter specimenStatusID = sqlCommand.Parameters.Add("@SpecimenStatusID", SqlDbType.Int);
                    specimenStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    specimenStatus = new SpecimenStatus((Int32)specimenStatusID.Value);
                    specimenStatus.Detail = new Translation(pSpecimenStatus.Detail.TranslationID);
                    specimenStatus.Detail.Alias = pSpecimenStatus.Detail.Alias;
                    specimenStatus.Detail.Description = pSpecimenStatus.Detail.Description;
                    specimenStatus.Detail.Name = pSpecimenStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    specimenStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenStatus;
        }

        public SpecimenStatus Update(SpecimenStatus pSpecimenStatus)
        {
            SpecimenStatus specimenStatus = new SpecimenStatus();

            pSpecimenStatus.Detail = base.UpdateTranslation(pSpecimenStatus.Detail);

            specimenStatus = new SpecimenStatus(pSpecimenStatus.SpecimenStatusID);
            specimenStatus.Detail = new Translation(pSpecimenStatus.Detail.TranslationID);
            specimenStatus.Detail.Alias = pSpecimenStatus.Detail.Alias;
            specimenStatus.Detail.Description = pSpecimenStatus.Detail.Description;
            specimenStatus.Detail.Name = pSpecimenStatus.Detail.Name;

            return specimenStatus;
        }

        public SpecimenStatus Delete(SpecimenStatus pSpecimenStatus)
        {
            SpecimenStatus specimenStatus = new SpecimenStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenStatusID", pSpecimenStatus.SpecimenStatusID));

                    sqlCommand.ExecuteNonQuery();

                    specimenStatus = new SpecimenStatus(pSpecimenStatus.SpecimenStatusID);
                    base.DeleteAllTranslations(pSpecimenStatus.Detail);
                }
                catch (Exception exc)
                {
                    specimenStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenStatus;
        }
    }
}
