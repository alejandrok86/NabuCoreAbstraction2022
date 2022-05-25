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
    public class AnalysisTypeDOL : BaseDOL
    {
        public AnalysisTypeDOL() : base ()
        {
        }

        public AnalysisTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AnalysisType Get(int pAnalysisTypeID, int pLanguageID)
        {
            AnalysisType analysisType = new AnalysisType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisTypeID", pAnalysisTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        analysisType = new AnalysisType(sqlDataReader.GetInt32(0));
                        analysisType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    analysisType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisType;
        }

        public AnalysisType[] List(int pLanguageID)
        {
            List<AnalysisType> analysisTypes = new List<AnalysisType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AnalysisType analysisType = new AnalysisType(sqlDataReader.GetInt32(0));
                        analysisType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        analysisTypes.Add(analysisType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AnalysisType analysisType = new AnalysisType();
                    analysisType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    analysisTypes.Add(analysisType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisTypes.ToArray();
        }

        public AnalysisType Insert(AnalysisType pAnalysisType)
        {
            AnalysisType analysisType = new AnalysisType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisType_Insert]");
                try
                {
                    pAnalysisType.Detail = base.InsertTranslation(pAnalysisType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAnalysisType.Detail.TranslationID));
                    SqlParameter analysisTypeID = sqlCommand.Parameters.Add("@AnalysisTypeID", SqlDbType.Int);
                    analysisTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    analysisType = new AnalysisType((Int32)analysisTypeID.Value);
                    analysisType.Detail = new Translation(pAnalysisType.Detail.TranslationID);
                    analysisType.Detail.Alias = pAnalysisType.Detail.Alias;
                    analysisType.Detail.Description = pAnalysisType.Detail.Description;
                    analysisType.Detail.Name = pAnalysisType.Detail.Name;
                }
                catch (Exception exc)
                {
                    analysisType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisType;
        }

        public AnalysisType Update(AnalysisType pAnalysisType)
        {
            AnalysisType analysisType = new AnalysisType();

            pAnalysisType.Detail = base.UpdateTranslation(pAnalysisType.Detail);

            analysisType = new AnalysisType(pAnalysisType.AnalysisTypeID);
            analysisType.Detail = new Translation(pAnalysisType.Detail.TranslationID);
            analysisType.Detail.Alias = pAnalysisType.Detail.Alias;
            analysisType.Detail.Description = pAnalysisType.Detail.Description;
            analysisType.Detail.Name = pAnalysisType.Detail.Name;

            return analysisType;
        }

        public AnalysisType Delete(AnalysisType pAnalysisType)
        {
            AnalysisType analysisType = new AnalysisType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[AnalysisType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisTypeID", pAnalysisType.AnalysisTypeID));

                    sqlCommand.ExecuteNonQuery();

                    analysisType = new AnalysisType(pAnalysisType.AnalysisTypeID);
                    base.DeleteAllTranslations(pAnalysisType.Detail);
                }
                catch (Exception exc)
                {
                    analysisType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    analysisType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return analysisType;
        }
    }
}
