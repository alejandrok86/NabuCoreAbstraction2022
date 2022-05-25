using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentCategoryDOL : BaseDOL
    {
        public IncidentCategoryDOL() : base()
        {
        }

        public IncidentCategoryDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory Get(int pIncidentCategoryID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentCategory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentCategoryID", pIncidentCategoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(0));
                        incidentCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentCategory_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(0));
                        incidentCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory> incidentCategorys = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentCategory_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(0));
                        incidentCategory.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        incidentCategorys.Add(incidentCategory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();
                    incidentCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentCategorys.Add(incidentCategory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentCategorys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory pIncidentCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentCategory_Insert]");
                try
                {
                    pIncidentCategory.Detail = base.InsertTranslation(pIncidentCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIncidentCategory.Detail.TranslationID));
                    SqlParameter incidentCategoryID = sqlCommand.Parameters.Add("@IncidentCategoryID", SqlDbType.Int);
                    incidentCategoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory((Int32)incidentCategoryID.Value);
                    incidentCategory.Detail = new Translation(pIncidentCategory.Detail.TranslationID);
                    incidentCategory.Detail.Alias = pIncidentCategory.Detail.Alias;
                    incidentCategory.Detail.Description = pIncidentCategory.Detail.Description;
                    incidentCategory.Detail.Name = pIncidentCategory.Detail.Name;
                }
                catch (Exception exc)
                {
                    incidentCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory pIncidentCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();

            pIncidentCategory.Detail = base.UpdateTranslation(pIncidentCategory.Detail);

            incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory(pIncidentCategory.IncidentCategoryID);
            incidentCategory.Detail = new Translation(pIncidentCategory.Detail.TranslationID);
            incidentCategory.Detail.Alias = pIncidentCategory.Detail.Alias;
            incidentCategory.Detail.Description = pIncidentCategory.Detail.Description;
            incidentCategory.Detail.Name = pIncidentCategory.Detail.Name;

            return incidentCategory;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory pIncidentCategory)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentCategory_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentCategoryID", pIncidentCategory.IncidentCategoryID));

                    sqlCommand.ExecuteNonQuery();

                    incidentCategory = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentCategory(pIncidentCategory.IncidentCategoryID);
                    base.DeleteAllTranslations(pIncidentCategory.Detail);
                }
                catch (Exception exc)
                {
                    incidentCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentCategory;
        }
    }
}

