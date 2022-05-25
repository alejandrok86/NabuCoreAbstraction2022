using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class DefectStatusDOL : BaseDOL
    {
        public DefectStatusDOL() : base()
        {
        }

        public DefectStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus Get(int pDefectStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectStatusID", pDefectStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus(sqlDataReader.GetInt32(0));
                        defectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus(sqlDataReader.GetInt32(0));
                        defectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus> defectStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus(sqlDataReader.GetInt32(0));
                        defectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        defectStatuss.Add(defectStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();
                    defectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defectStatuss.Add(defectStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus Insert(Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus pDefectStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectStatus_Insert]");
                try
                {
                    pDefectStatus.Detail = base.InsertTranslation(pDefectStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDefectStatus.Detail.TranslationID));
                    SqlParameter defectStatusID = sqlCommand.Parameters.Add("@DefectStatusID", SqlDbType.Int);
                    defectStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus((Int32)defectStatusID.Value);
                    defectStatus.Detail = new Translation(pDefectStatus.Detail.TranslationID);
                    defectStatus.Detail.Alias = pDefectStatus.Detail.Alias;
                    defectStatus.Detail.Description = pDefectStatus.Detail.Description;
                    defectStatus.Detail.Name = pDefectStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    defectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus Update(Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus pDefectStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();

            pDefectStatus.Detail = base.UpdateTranslation(pDefectStatus.Detail);

            defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus(pDefectStatus.DefectStatusID);
            defectStatus.Detail = new Translation(pDefectStatus.Detail.TranslationID);
            defectStatus.Detail.Alias = pDefectStatus.Detail.Alias;
            defectStatus.Detail.Description = pDefectStatus.Detail.Description;
            defectStatus.Detail.Name = pDefectStatus.Detail.Name;

            return defectStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus Delete(Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus pDefectStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectStatusID", pDefectStatus.DefectStatusID));

                    sqlCommand.ExecuteNonQuery();

                    defectStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectStatus(pDefectStatus.DefectStatusID);
                    base.DeleteAllTranslations(pDefectStatus.Detail);
                }
                catch (Exception exc)
                {
                    defectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectStatus;
        }
    }
}

