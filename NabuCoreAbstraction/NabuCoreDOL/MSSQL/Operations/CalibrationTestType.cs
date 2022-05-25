using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class CalibrationTestTypeDOL : BaseDOL
    {
        public CalibrationTestTypeDOL() : base()
        {
        }

        public CalibrationTestTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public CalibrationTestType Get(int pCalibrationTestTypeID, int pLanguageID)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        calibrationTestType = new CalibrationTestType(sqlDataReader.GetInt32(0));
                        calibrationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }

        public CalibrationTestType GetByAlias(string pAlias, int pLanguageID)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        calibrationTestType = new CalibrationTestType(sqlDataReader.GetInt32(0));
                        calibrationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }

        public CalibrationTestType[] List(int pLanguageID)
        {
            List<CalibrationTestType> calibrationTestTypes = new List<CalibrationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CalibrationTestType calibrationTestType = new CalibrationTestType(sqlDataReader.GetInt32(0));
                        calibrationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        calibrationTestTypes.Add(calibrationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CalibrationTestType calibrationTestType = new CalibrationTestType();
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    calibrationTestTypes.Add(calibrationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestTypes.ToArray();
        }

        public CalibrationTestType[] ListByPartType(int pPartTypeID, int pLanguageID)
        {
            List<CalibrationTestType> calibrationTestTypes = new List<CalibrationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_ListByPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CalibrationTestType calibrationTestType = new CalibrationTestType(sqlDataReader.GetInt32(0));
                        calibrationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        calibrationTestTypes.Add(calibrationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CalibrationTestType calibrationTestType = new CalibrationTestType();
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    calibrationTestTypes.Add(calibrationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestTypes.ToArray();
        }

        public CalibrationTestType Insert(CalibrationTestType pCalibrationTestType)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_Insert]");
                try
                {
                    pCalibrationTestType.Detail = base.InsertTranslation(pCalibrationTestType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCalibrationTestType.Detail.TranslationID));
                    SqlParameter calibrationTestTypeID = sqlCommand.Parameters.Add("@CalibrationTestTypeID", SqlDbType.Int);
                    calibrationTestTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestType = new CalibrationTestType((Int32)calibrationTestTypeID.Value);
                    calibrationTestType.Detail = new Translation(pCalibrationTestType.Detail.TranslationID);
                    calibrationTestType.Detail.Alias = pCalibrationTestType.Detail.Alias;
                    calibrationTestType.Detail.Description = pCalibrationTestType.Detail.Description;
                    calibrationTestType.Detail.Name = pCalibrationTestType.Detail.Name;
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }

        public CalibrationTestType Update(CalibrationTestType pCalibrationTestType)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            calibrationTestType.Detail = base.UpdateTranslation(pCalibrationTestType.Detail);

            return calibrationTestType;
        }

        public CalibrationTestType Delete(CalibrationTestType pCalibrationTestType)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestType.TestTypeID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestType = new CalibrationTestType(pCalibrationTestType.TestTypeID);
                    base.DeleteAllTranslations(pCalibrationTestType.Detail);
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }
        public CalibrationTestType AssignToPartType(int pCalibrationTestTypeID, int pPartTypeID)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_AssignToPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestType = new CalibrationTestType(pCalibrationTestTypeID);
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }

        public CalibrationTestType RemoveFromPartType(int pCalibrationTestTypeID, int pPartTypeID)
        {
            CalibrationTestType calibrationTestType = new CalibrationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_RemoveFromPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestType = new CalibrationTestType(pCalibrationTestTypeID);
                }
                catch (Exception exc)
                {
                    calibrationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestType;
        }
        public Entities.BaseBoolean AssignToPart(int pCalibrationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_AssignToPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public Entities.BaseBoolean RemoveFromPart(int pCalibrationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestType_RemoveFromPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
