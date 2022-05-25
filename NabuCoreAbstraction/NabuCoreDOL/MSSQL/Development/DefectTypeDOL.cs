using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class DefectTypeDOL : BaseDOL
    {
        public DefectTypeDOL() : base()
        {
        }

        public DefectTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType Get(int pDefectTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectTypeID", pDefectTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType(sqlDataReader.GetInt32(0));
                        defectType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType(sqlDataReader.GetInt32(0));
                        defectType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectType> defectTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType(sqlDataReader.GetInt32(0));
                        defectType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        defectTypes.Add(defectType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();
                    defectType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defectTypes.Add(defectType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType Insert(Octavo.Gate.Nabu.CORE.Entities.Development.DefectType pDefectType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectType_Insert]");
                try
                {
                    pDefectType.Detail = base.InsertTranslation(pDefectType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDefectType.Detail.TranslationID));
                    SqlParameter defectTypeID = sqlCommand.Parameters.Add("@DefectTypeID", SqlDbType.Int);
                    defectTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType((Int32)defectTypeID.Value);
                    defectType.Detail = new Translation(pDefectType.Detail.TranslationID);
                    defectType.Detail.Alias = pDefectType.Detail.Alias;
                    defectType.Detail.Description = pDefectType.Detail.Description;
                    defectType.Detail.Name = pDefectType.Detail.Name;
                }
                catch (Exception exc)
                {
                    defectType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType Update(Octavo.Gate.Nabu.CORE.Entities.Development.DefectType pDefectType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();

            pDefectType.Detail = base.UpdateTranslation(pDefectType.Detail);

            defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType(pDefectType.DefectTypeID);
            defectType.Detail = new Translation(pDefectType.Detail.TranslationID);
            defectType.Detail.Alias = pDefectType.Detail.Alias;
            defectType.Detail.Description = pDefectType.Detail.Description;
            defectType.Detail.Name = pDefectType.Detail.Name;

            return defectType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectType Delete(Octavo.Gate.Nabu.CORE.Entities.Development.DefectType pDefectType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectType defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectTypeID", pDefectType.DefectTypeID));

                    sqlCommand.ExecuteNonQuery();

                    defectType = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectType(pDefectType.DefectTypeID);
                    base.DeleteAllTranslations(pDefectType.Detail);
                }
                catch (Exception exc)
                {
                    defectType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectType;
        }
    }
}

