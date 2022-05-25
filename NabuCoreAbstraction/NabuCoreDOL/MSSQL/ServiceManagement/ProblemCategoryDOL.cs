using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ProblemCategoryDOL : BaseDOL
    {
        public ProblemCategoryDOL() : base()
        {
        }

        public ProblemCategoryDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory Get(int pProblemCategoryID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemCategory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemCategoryID", pProblemCategoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(0));
                        problemCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemCategory_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(0));
                        problemCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problemCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory> problemCategorys = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemCategory_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(0));
                        problemCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        problemCategorys.Add(problemCategory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();
                    problemCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    problemCategorys.Add(problemCategory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemCategorys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory pProblemCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemCategory_Insert]");
                try
                {
                    pProblemCategory.Detail = base.InsertTranslation(pProblemCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProblemCategory.Detail.TranslationID));
                    SqlParameter problemCategoryID = sqlCommand.Parameters.Add("@ProblemCategoryID", SqlDbType.Int);
                    problemCategoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory((Int32)problemCategoryID.Value);
                    problemCategory.Detail = new Translation(pProblemCategory.Detail.TranslationID);
                    problemCategory.Detail.Alias = pProblemCategory.Detail.Alias;
                    problemCategory.Detail.Description = pProblemCategory.Detail.Description;
                    problemCategory.Detail.Name = pProblemCategory.Detail.Name;
                }
                catch (Exception exc)
                {
                    problemCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory pProblemCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();

            pProblemCategory.Detail = base.UpdateTranslation(pProblemCategory.Detail);

            problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory(pProblemCategory.ProblemCategoryID);
            problemCategory.Detail = new Translation(pProblemCategory.Detail.TranslationID);
            problemCategory.Detail.Alias = pProblemCategory.Detail.Alias;
            problemCategory.Detail.Description = pProblemCategory.Detail.Description;
            problemCategory.Detail.Name = pProblemCategory.Detail.Name;

            return problemCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory pProblemCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemCategory_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemCategoryID", pProblemCategory.ProblemCategoryID));

                    sqlCommand.ExecuteNonQuery();

                    problemCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ProblemCategory(pProblemCategory.ProblemCategoryID);
                    base.DeleteAllTranslations(pProblemCategory.Detail);
                }
                catch (Exception exc)
                {
                    problemCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problemCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problemCategory;
        }
    }
}

