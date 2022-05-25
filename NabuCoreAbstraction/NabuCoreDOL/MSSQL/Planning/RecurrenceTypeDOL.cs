using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class RecurrenceTypeDOL : BaseDOL
    {
        public RecurrenceTypeDOL() : base()
        {
        }

        public RecurrenceTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RecurrenceType Get(int pRecurrenceTypeID, int pLanguageID)
        {
            RecurrenceType recurrenceType = new RecurrenceType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[RecurrenceType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceTypeID", pRecurrenceTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        recurrenceType = new RecurrenceType(sqlDataReader.GetInt32(0));
                        recurrenceType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    recurrenceType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrenceType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrenceType;
        }

        public RecurrenceType GetByAlias(string pAlias, int pLanguageID)
        {
            RecurrenceType recurrenceType = new RecurrenceType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[RecurrenceType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        recurrenceType = new RecurrenceType(sqlDataReader.GetInt32(0));
                        recurrenceType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    recurrenceType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrenceType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrenceType;
        }

        public RecurrenceType[] List(int pLanguageID)
        {
            List<RecurrenceType> recurrenceTypes = new List<RecurrenceType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[RecurrenceType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RecurrenceType recurrenceType = new RecurrenceType(sqlDataReader.GetInt32(0));
                        recurrenceType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        recurrenceTypes.Add(recurrenceType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RecurrenceType recurrenceType = new RecurrenceType();
                    recurrenceType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrenceType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    recurrenceTypes.Add(recurrenceType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrenceTypes.ToArray();
        }

        public RecurrenceType Insert(RecurrenceType pRecurrenceType)
        {
            RecurrenceType recurrenceType = new RecurrenceType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[RecurrenceType_Insert]");
                try
                {
                    pRecurrenceType.Detail = base.InsertTranslation(pRecurrenceType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRecurrenceType.Detail.TranslationID));
                    SqlParameter RecurrenceTypeID = sqlCommand.Parameters.Add("@RecurrenceTypeID", SqlDbType.Int);
                    RecurrenceTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    recurrenceType = new RecurrenceType((Int32)RecurrenceTypeID.Value);
                    recurrenceType.Detail = new Translation(pRecurrenceType.Detail.TranslationID);
                    recurrenceType.Detail.Alias = pRecurrenceType.Detail.Alias;
                    recurrenceType.Detail.Description = pRecurrenceType.Detail.Description;
                    recurrenceType.Detail.Name = pRecurrenceType.Detail.Name;
                }
                catch (Exception exc)
                {
                    recurrenceType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrenceType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrenceType;
        }

        public RecurrenceType Update(RecurrenceType pRecurrenceType)
        {
            RecurrenceType recurrenceType = new RecurrenceType();

            pRecurrenceType.Detail = base.UpdateTranslation(pRecurrenceType.Detail);

            recurrenceType = new RecurrenceType(pRecurrenceType.RecurrenceTypeID);
            recurrenceType.Detail = new Translation(pRecurrenceType.Detail.TranslationID);
            recurrenceType.Detail.Alias = pRecurrenceType.Detail.Alias;
            recurrenceType.Detail.Description = pRecurrenceType.Detail.Description;
            recurrenceType.Detail.Name = pRecurrenceType.Detail.Name;

            return recurrenceType;
        }

        public RecurrenceType Delete(RecurrenceType pRecurrenceType)
        {
            RecurrenceType recurrenceType = new RecurrenceType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[RecurrenceType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceTypeID", pRecurrenceType.RecurrenceTypeID));

                    sqlCommand.ExecuteNonQuery();

                    recurrenceType = new RecurrenceType(pRecurrenceType.RecurrenceTypeID);
                    base.DeleteAllTranslations(pRecurrenceType.Detail);
                }
                catch (Exception exc)
                {
                    recurrenceType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrenceType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrenceType;
        }
    }
}
