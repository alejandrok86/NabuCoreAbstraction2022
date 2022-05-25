using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class FunctionalAreaDOL : BaseDOL
    {
        public FunctionalAreaDOL() : base ()
        {
        }

        public FunctionalAreaDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public FunctionalArea Get(int pFunctionalAreaID, int pLanguageID)
        {
            FunctionalArea functionalArea = new FunctionalArea();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[FunctionalArea_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FunctionalAreaID", pFunctionalAreaID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        functionalArea = new FunctionalArea(sqlDataReader.GetInt32(0));
                        functionalArea.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    functionalArea.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    functionalArea.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return functionalArea;
        }

        public FunctionalArea[] List(int pLanguageID)
        {
            List<FunctionalArea> functionalAreas = new List<FunctionalArea>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[FunctionalArea_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        FunctionalArea functionalArea = new FunctionalArea(sqlDataReader.GetInt32(0));
                        functionalArea.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        functionalAreas.Add(functionalArea);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    FunctionalArea functionalArea = new FunctionalArea();
                    functionalArea.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    functionalArea.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    functionalAreas.Add(functionalArea);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return functionalAreas.ToArray();
        }

        public FunctionalArea Insert(FunctionalArea pFunctionalArea)
        {
            FunctionalArea functionalArea = new FunctionalArea();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[FunctionalArea_Insert]");
                try
                {
                    pFunctionalArea.Detail = base.InsertTranslation(pFunctionalArea.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pFunctionalArea.Detail.TranslationID));
                    SqlParameter functionalAreaID = sqlCommand.Parameters.Add("@FunctionalAreaID", SqlDbType.Int);
                    functionalAreaID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    functionalArea = new FunctionalArea((Int32)functionalAreaID.Value);
                    functionalArea.Detail = new Translation(pFunctionalArea.Detail.TranslationID);
                    functionalArea.Detail.Alias = pFunctionalArea.Detail.Alias;
                    functionalArea.Detail.Description = pFunctionalArea.Detail.Description;
                    functionalArea.Detail.Name = pFunctionalArea.Detail.Name;
                }
                catch (Exception exc)
                {
                    functionalArea.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    functionalArea.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return functionalArea;
        }

        public FunctionalArea Update(FunctionalArea pFunctionalArea)
        {
            FunctionalArea functionalArea = new FunctionalArea();

            pFunctionalArea.Detail = base.UpdateTranslation(pFunctionalArea.Detail);

            functionalArea = new FunctionalArea(pFunctionalArea.FunctionalAreaID);
            functionalArea.Detail = new Translation(pFunctionalArea.Detail.TranslationID);
            functionalArea.Detail.Alias = pFunctionalArea.Detail.Alias;
            functionalArea.Detail.Description = pFunctionalArea.Detail.Description;
            functionalArea.Detail.Name = pFunctionalArea.Detail.Name;

            return functionalArea;
        }

        public FunctionalArea Delete(FunctionalArea pFunctionalArea)
        {
            FunctionalArea functionalArea = new FunctionalArea();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[FunctionalArea_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FunctionalAreaID", pFunctionalArea.FunctionalAreaID));

                    sqlCommand.ExecuteNonQuery();

                    functionalArea = new FunctionalArea(pFunctionalArea.FunctionalAreaID);
                    base.DeleteAllTranslations(pFunctionalArea.Detail);
                }
                catch (Exception exc)
                {
                    functionalArea.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    functionalArea.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return functionalArea;
        }
    }
}
