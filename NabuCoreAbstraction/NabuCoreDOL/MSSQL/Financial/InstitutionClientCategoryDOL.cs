using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class InstitutionClientCategoryDOL : BaseDOL
    {
        public InstitutionClientCategoryDOL() : base()
        {
        }

        public InstitutionClientCategoryDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionClientCategory Get(int pInstitutionClientCategoryID)
        {
            InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionClientCategory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionClientCategoryID", pInstitutionClientCategoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionClientCategory = new InstitutionClientCategory(sqlDataReader.GetInt32(0));
                        institutionClientCategory.ClientCategory = new ClientCategory(sqlDataReader.GetInt32(1));
                        institutionClientCategory.CategoryClassification = new CategoryClassification(sqlDataReader.GetInt32(2));
                        institutionClientCategory.IsOffshore = sqlDataReader.GetBoolean(3);
                        institutionClientCategory.AcceptsDeposits = sqlDataReader.GetBoolean(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            institutionClientCategory.Comment = new Entities.Social.Comment(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionClientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionClientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionClientCategory;
        }

        public InstitutionClientCategory[] List(int pInstitutionID,int pLanguageID)
        {
            List<InstitutionClientCategory> institutionClientCategorys = new List<InstitutionClientCategory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionClientCategory_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory(sqlDataReader.GetInt32(0));
                        institutionClientCategory.ClientCategory = new ClientCategory(sqlDataReader.GetInt32(1));
                        institutionClientCategory.ClientCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(2),pLanguageID);
                        institutionClientCategory.CategoryClassification = new CategoryClassification(sqlDataReader.GetInt32(3));
                        institutionClientCategory.CategoryClassification.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        institutionClientCategory.IsOffshore = sqlDataReader.GetBoolean(5);
                        institutionClientCategory.AcceptsDeposits = sqlDataReader.GetBoolean(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            institutionClientCategory.Comment = new Entities.Social.Comment(sqlDataReader.GetInt32(7));
                        institutionClientCategorys.Add(institutionClientCategory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory();
                    institutionClientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionClientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionClientCategorys.Add(institutionClientCategory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionClientCategorys.ToArray();
        }

        public InstitutionClientCategory Insert(InstitutionClientCategory pInstitutionClientCategory, int pInstitutionID)
        {
            InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionClientCategory_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", pInstitutionClientCategory.ClientCategory.ClientCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pInstitutionClientCategory.CategoryClassification.CategoryClassificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsOffshore", pInstitutionClientCategory.IsOffshore));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcceptsDeposits", pInstitutionClientCategory.AcceptsDeposits));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", ((pInstitutionClientCategory.Comment != null && pInstitutionClientCategory.Comment.CommentID != null) ? pInstitutionClientCategory.Comment.CommentID : null)));
                    SqlParameter institutionClientCategoryID = sqlCommand.Parameters.Add("@InstitutionClientCategoryID", SqlDbType.Int);
                    institutionClientCategoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    institutionClientCategory = new InstitutionClientCategory((Int32)institutionClientCategoryID.Value);
                    institutionClientCategory.ClientCategory = new ClientCategory(pInstitutionClientCategory.ClientCategory.ClientCategoryID);
                    institutionClientCategory.CategoryClassification = new CategoryClassification(pInstitutionClientCategory.CategoryClassification.CategoryClassificationID);
                    institutionClientCategory.IsOffshore = pInstitutionClientCategory.IsOffshore;
                    institutionClientCategory.AcceptsDeposits = pInstitutionClientCategory.AcceptsDeposits;
                    if (pInstitutionClientCategory.Comment != null)
                        institutionClientCategory.Comment = pInstitutionClientCategory.Comment;
                }
                catch (Exception exc)
                {
                    institutionClientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionClientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionClientCategory;
        }

        public InstitutionClientCategory Update(InstitutionClientCategory pInstitutionClientCategory)
        {
            InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionClientCategory_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionClientCategoryID", pInstitutionClientCategory.InstitutionClientCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", pInstitutionClientCategory.ClientCategory.ClientCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pInstitutionClientCategory.CategoryClassification.CategoryClassificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsOffshore", pInstitutionClientCategory.IsOffshore));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcceptsDeposits", pInstitutionClientCategory.AcceptsDeposits));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", ((pInstitutionClientCategory.Comment != null) ? pInstitutionClientCategory.Comment.CommentID : null)));

                    sqlCommand.ExecuteNonQuery();

                    institutionClientCategory = new InstitutionClientCategory(pInstitutionClientCategory.InstitutionClientCategoryID);
                    institutionClientCategory.ClientCategory = new ClientCategory(pInstitutionClientCategory.ClientCategory.ClientCategoryID);
                    institutionClientCategory.CategoryClassification = new CategoryClassification(pInstitutionClientCategory.CategoryClassification.CategoryClassificationID);
                    institutionClientCategory.IsOffshore = pInstitutionClientCategory.IsOffshore;
                    institutionClientCategory.AcceptsDeposits = pInstitutionClientCategory.AcceptsDeposits;
                    if (pInstitutionClientCategory.Comment != null)
                        institutionClientCategory.Comment = pInstitutionClientCategory.Comment;
                }
                catch (Exception exc)
                {
                    institutionClientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionClientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionClientCategory;
        }

        public InstitutionClientCategory Delete(InstitutionClientCategory pInstitutionClientCategory)
        {
            InstitutionClientCategory institutionClientCategory = new InstitutionClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionClientCategory_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionClientCategoryID", pInstitutionClientCategory.InstitutionClientCategoryID));

                    sqlCommand.ExecuteNonQuery();

                    institutionClientCategory = new InstitutionClientCategory(pInstitutionClientCategory.InstitutionClientCategoryID);
                }
                catch (Exception exc)
                {
                    institutionClientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionClientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionClientCategory;
        }

    }
}
