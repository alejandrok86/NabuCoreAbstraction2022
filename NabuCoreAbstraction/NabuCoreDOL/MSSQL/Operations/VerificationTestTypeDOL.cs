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
    public class VerificationTestTypeDOL : BaseDOL
    {
        public VerificationTestTypeDOL() : base()
        {
        }

        public VerificationTestTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public VerificationTestType Get(int pVerificationTestTypeID, int pLanguageID)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        verificationTestType = new VerificationTestType(sqlDataReader.GetInt32(0));
                        verificationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }

        public VerificationTestType GetByAlias(string pAlias, int pLanguageID)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        verificationTestType = new VerificationTestType(sqlDataReader.GetInt32(0));
                        verificationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }

        public VerificationTestType[] List(int pLanguageID)
        {
            List<VerificationTestType> verificationTestTypes = new List<VerificationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        VerificationTestType verificationTestType = new VerificationTestType(sqlDataReader.GetInt32(0));
                        verificationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        verificationTestTypes.Add(verificationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    VerificationTestType verificationTestType = new VerificationTestType();
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    verificationTestTypes.Add(verificationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestTypes.ToArray();
        }

        public VerificationTestType[] ListByPartType(int pPartTypeID, int pLanguageID)
        {
            List<VerificationTestType> verificationTestTypes = new List<VerificationTestType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_ListByPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        VerificationTestType verificationTestType = new VerificationTestType(sqlDataReader.GetInt32(0));
                        verificationTestType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        verificationTestTypes.Add(verificationTestType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    VerificationTestType verificationTestType = new VerificationTestType();
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    verificationTestTypes.Add(verificationTestType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestTypes.ToArray();
        }

        public VerificationTestType Insert(VerificationTestType pVerificationTestType)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_Insert]");
                try
                {
                    pVerificationTestType.Detail = base.InsertTranslation(pVerificationTestType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pVerificationTestType.Detail.TranslationID));
                    SqlParameter verificationTestTypeID = sqlCommand.Parameters.Add("@VerificationTestTypeID", SqlDbType.Int);
                    verificationTestTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    verificationTestType = new VerificationTestType((Int32)verificationTestTypeID.Value);
                    verificationTestType.Detail = new Translation(pVerificationTestType.Detail.TranslationID);
                    verificationTestType.Detail.Alias = pVerificationTestType.Detail.Alias;
                    verificationTestType.Detail.Description = pVerificationTestType.Detail.Description;
                    verificationTestType.Detail.Name = pVerificationTestType.Detail.Name;
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }

        public VerificationTestType Update(VerificationTestType pVerificationTestType)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            verificationTestType.Detail = base.UpdateTranslation(pVerificationTestType.Detail);

            return verificationTestType;
        }

        public VerificationTestType Delete(VerificationTestType pVerificationTestType)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestType.TestTypeID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTestType = new VerificationTestType(pVerificationTestType.TestTypeID);
                    base.DeleteAllTranslations(pVerificationTestType.Detail);
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }
        public VerificationTestType AssignToPartType(int pVerificationTestTypeID, int pPartTypeID)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_AssignToPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTestType = new VerificationTestType(pVerificationTestTypeID);
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }

        public VerificationTestType RemoveFromPartType(int pVerificationTestTypeID, int pPartTypeID)
        {
            VerificationTestType verificationTestType = new VerificationTestType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_RemoveFromPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTestType = new VerificationTestType(pVerificationTestTypeID);
                }
                catch (Exception exc)
                {
                    verificationTestType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestType;
        }
        public Entities.BaseBoolean AssignToPart(int pVerificationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_AssignToPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
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
        public Entities.BaseBoolean RemoveFromPart(int pVerificationTestTypeID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestType_RemoveFromPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
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
