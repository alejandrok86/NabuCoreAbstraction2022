using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class DefectPriorityDOL : BaseDOL
    {
        public DefectPriorityDOL() : base()
        {
        }

        public DefectPriorityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority Get(int pDefectPriorityID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectPriority_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectPriorityID", pDefectPriorityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority(sqlDataReader.GetInt32(0));
                        defectPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectPriority_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority(sqlDataReader.GetInt32(0));
                        defectPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defectPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority> defectPrioritys = new List<Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectPriority_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority(sqlDataReader.GetInt32(0));
                        defectPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        defectPrioritys.Add(defectPriority);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();
                    defectPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defectPrioritys.Add(defectPriority);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectPrioritys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority Insert(Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority pDefectPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectPriority_Insert]");
                try
                {
                    pDefectPriority.Detail = base.InsertTranslation(pDefectPriority.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDefectPriority.Detail.TranslationID));
                    SqlParameter defectPriorityID = sqlCommand.Parameters.Add("@DefectPriorityID", SqlDbType.Int);
                    defectPriorityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority((Int32)defectPriorityID.Value);
                    defectPriority.Detail = new Translation(pDefectPriority.Detail.TranslationID);
                    defectPriority.Detail.Alias = pDefectPriority.Detail.Alias;
                    defectPriority.Detail.Description = pDefectPriority.Detail.Description;
                    defectPriority.Detail.Name = pDefectPriority.Detail.Name;
                }
                catch (Exception exc)
                {
                    defectPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority Update(Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority pDefectPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();

            pDefectPriority.Detail = base.UpdateTranslation(pDefectPriority.Detail);

            defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority(pDefectPriority.DefectPriorityID);
            defectPriority.Detail = new Translation(pDefectPriority.Detail.TranslationID);
            defectPriority.Detail.Alias = pDefectPriority.Detail.Alias;
            defectPriority.Detail.Description = pDefectPriority.Detail.Description;
            defectPriority.Detail.Name = pDefectPriority.Detail.Name;

            return defectPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority Delete(Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority pDefectPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectPriority_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectPriorityID", pDefectPriority.DefectPriorityID));

                    sqlCommand.ExecuteNonQuery();

                    defectPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.DefectPriority(pDefectPriority.DefectPriorityID);
                    base.DeleteAllTranslations(pDefectPriority.Detail);
                }
                catch (Exception exc)
                {
                    defectPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defectPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defectPriority;
        }
    }
}

