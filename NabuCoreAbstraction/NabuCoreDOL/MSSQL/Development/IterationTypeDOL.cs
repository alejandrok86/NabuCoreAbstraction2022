using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class IterationTypeDOL : BaseDOL
    {
        public IterationTypeDOL() : base()
        {
        }

        public IterationTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType Get(int pIterationTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationTypeID", pIterationTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType(sqlDataReader.GetInt32(0));
                        iterationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    iterationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType(sqlDataReader.GetInt32(0));
                        iterationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    iterationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.IterationType> iterationTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Development.IterationType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType(sqlDataReader.GetInt32(0));
                        iterationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        iterationTypes.Add(iterationType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();
                    iterationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    iterationTypes.Add(iterationType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType Insert(Octavo.Gate.Nabu.CORE.Entities.Development.IterationType pIterationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationType_Insert]");
                try
                {
                    pIterationType.Detail = base.InsertTranslation(pIterationType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIterationType.Detail.TranslationID));
                    SqlParameter iterationTypeID = sqlCommand.Parameters.Add("@IterationTypeID", SqlDbType.Int);
                    iterationTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType((Int32)iterationTypeID.Value);
                    iterationType.Detail = new Translation(pIterationType.Detail.TranslationID);
                    iterationType.Detail.Alias = pIterationType.Detail.Alias;
                    iterationType.Detail.Description = pIterationType.Detail.Description;
                    iterationType.Detail.Name = pIterationType.Detail.Name;
                }
                catch (Exception exc)
                {
                    iterationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType Update(Octavo.Gate.Nabu.CORE.Entities.Development.IterationType pIterationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();

            pIterationType.Detail = base.UpdateTranslation(pIterationType.Detail);

            iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType(pIterationType.IterationTypeID);
            iterationType.Detail = new Translation(pIterationType.Detail.TranslationID);
            iterationType.Detail.Alias = pIterationType.Detail.Alias;
            iterationType.Detail.Description = pIterationType.Detail.Description;
            iterationType.Detail.Name = pIterationType.Detail.Name;

            return iterationType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.IterationType Delete(Octavo.Gate.Nabu.CORE.Entities.Development.IterationType pIterationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.IterationType iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[IterationType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationTypeID", pIterationType.IterationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    iterationType = new Octavo.Gate.Nabu.CORE.Entities.Development.IterationType(pIterationType.IterationTypeID);
                    base.DeleteAllTranslations(pIterationType.Detail);
                }
                catch (Exception exc)
                {
                    iterationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    iterationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return iterationType;
        }
    }
}

