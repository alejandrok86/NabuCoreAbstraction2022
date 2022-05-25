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
    public class ValidationTestTypeDOL : BaseDOL
    {
        public ValidationTestTypeDOL() : base()
        {
        }

        public ValidationTestTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ValidationTestType Get(int pValidationTestTypeID, int pLanguageID)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        validationTestType = new ValidationTestType(sqlDataReader.GetInt32(0));
                        validationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }

        public ValidationTestType GetByAlias(string pAlias, int pLanguageID)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        validationTestType = new ValidationTestType(sqlDataReader.GetInt32(0));
                        validationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }

        public ValidationTestType[] List(int pLanguageID)
        {
            List<ValidationTestType> validationTestTypes = new List<ValidationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ValidationTestType validationTestType = new ValidationTestType(sqlDataReader.GetInt32(0));
                        validationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        validationTestTypes.Add(validationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ValidationTestType validationTestType = new ValidationTestType();
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    validationTestTypes.Add(validationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestTypes.ToArray();
        }

        public ValidationTestType[] ListByPartType(int pPartTypeID, int pLanguageID)
        {
            List<ValidationTestType> validationTestTypes = new List<ValidationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_ListByPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ValidationTestType validationTestType = new ValidationTestType(sqlDataReader.GetInt32(0));
                        validationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        validationTestTypes.Add(validationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ValidationTestType validationTestType = new ValidationTestType();
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    validationTestTypes.Add(validationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestTypes.ToArray();
        }

        public ValidationTestType Insert(ValidationTestType pValidationTestType)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_Insert]");
                try
                {
                    pValidationTestType.Detail = base.InsertTranslation(pValidationTestType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pValidationTestType.Detail.TranslationID));
                    SqlParameter validationTestTypeID = sqlCommand.Parameters.Add("@ValidationTestTypeID", SqlDbType.Int);
                    validationTestTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    validationTestType = new ValidationTestType((Int32)validationTestTypeID.Value);
                    validationTestType.Detail = new Translation(pValidationTestType.Detail.TranslationID);
                    validationTestType.Detail.Alias = pValidationTestType.Detail.Alias;
                    validationTestType.Detail.Description = pValidationTestType.Detail.Description;
                    validationTestType.Detail.Name = pValidationTestType.Detail.Name;
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }

        public ValidationTestType Update(ValidationTestType pValidationTestType)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            validationTestType.Detail = base.UpdateTranslation(pValidationTestType.Detail);

            return validationTestType;
        }

        public ValidationTestType Delete(ValidationTestType pValidationTestType)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestType.TestTypeID));

                    sqlCommand.ExecuteNonQuery();

                    validationTestType = new ValidationTestType(pValidationTestType.TestTypeID);
                    base.DeleteAllTranslations(pValidationTestType.Detail);
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }

        public ValidationTestType AssignToPartType(int pValidationTestTypeID, int pPartTypeID)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_AssignToPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    validationTestType = new ValidationTestType(pValidationTestTypeID);
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }

        public ValidationTestType RemoveFromPartType(int pValidationTestTypeID, int pPartTypeID)
        {
            ValidationTestType validationTestType = new ValidationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_RemoveFromPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    validationTestType = new ValidationTestType(pValidationTestTypeID);
                }
                catch (Exception exc)
                {
                    validationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestType;
        }
        public Entities.BaseBoolean AssignToPart(int pValidationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_AssignToPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
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
        public Entities.BaseBoolean RemoveFromPart(int pValidationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestType_RemoveFromPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
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
