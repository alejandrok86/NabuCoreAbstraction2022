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
    public class SpecimenTypeDOL : BaseDOL
    {
        public SpecimenTypeDOL() : base ()
        {
        }

        public SpecimenTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SpecimenType Get(int pSpecimenTypeID, int pLanguageID)
        {
            SpecimenType specimenType = new SpecimenType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenTypeID", pSpecimenTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specimenType = new SpecimenType(sqlDataReader.GetInt32(0));
                        specimenType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specimenType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenType;
        }

        public SpecimenType[] List(int pLanguageID)
        {
            List<SpecimenType> specimenTypes = new List<SpecimenType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecimenType specimenType = new SpecimenType(sqlDataReader.GetInt32(0));
                        specimenType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        specimenTypes.Add(specimenType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecimenType specimenType = new SpecimenType();
                    specimenType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimenTypes.Add(specimenType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenTypes.ToArray();
        }

        public SpecimenType Insert(SpecimenType pSpecimenType)
        {
            SpecimenType specimenType = new SpecimenType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenType_Insert]");
                try
                {
                    pSpecimenType.Detail = base.InsertTranslation(pSpecimenType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pSpecimenType.Detail.TranslationID));
                    SqlParameter specimenTypeID = sqlCommand.Parameters.Add("@SpecimenTypeID", SqlDbType.Int);
                    specimenTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    specimenType = new SpecimenType((Int32)specimenTypeID.Value);
                    specimenType.Detail = new Translation(pSpecimenType.Detail.TranslationID);
                    specimenType.Detail.Alias = pSpecimenType.Detail.Alias;
                    specimenType.Detail.Description = pSpecimenType.Detail.Description;
                    specimenType.Detail.Name = pSpecimenType.Detail.Name;
                }
                catch (Exception exc)
                {
                    specimenType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenType;
        }

        public SpecimenType Update(SpecimenType pSpecimenType)
        {
            SpecimenType specimenType = new SpecimenType();

            pSpecimenType.Detail = base.UpdateTranslation(pSpecimenType.Detail);

            specimenType = new SpecimenType(pSpecimenType.SpecimenTypeID);
            specimenType.Detail = new Translation(pSpecimenType.Detail.TranslationID);
            specimenType.Detail.Alias = pSpecimenType.Detail.Alias;
            specimenType.Detail.Description = pSpecimenType.Detail.Description;
            specimenType.Detail.Name = pSpecimenType.Detail.Name;

            return specimenType;
        }

        public SpecimenType Delete(SpecimenType pSpecimenType)
        {
            SpecimenType specimenType = new SpecimenType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenTypeID", pSpecimenType.SpecimenTypeID));

                    sqlCommand.ExecuteNonQuery();

                    specimenType = new SpecimenType(pSpecimenType.SpecimenTypeID);
                    base.DeleteAllTranslations(pSpecimenType.Detail);
                }
                catch (Exception exc)
                {
                    specimenType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenType;
        }
    }
}
