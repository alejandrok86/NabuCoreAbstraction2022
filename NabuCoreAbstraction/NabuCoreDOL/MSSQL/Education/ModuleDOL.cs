using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class ModuleDOL : BaseDOL
    {
        public ModuleDOL() : base ()
        {
        }

        public ModuleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.Module Get(int pModuleID, int pLanguageID)
        {
            Entities.Education.Module module = new Entities.Education.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        module = new Entities.Education.Module(sqlDataReader.GetInt32(0));
                        module.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return module;
        }

        public Entities.Education.Module GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.Module module = new Entities.Education.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        module = new Entities.Education.Module(sqlDataReader.GetInt32(0));
                        module.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace; 
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return module;
        }

        public Entities.Education.Module[] List(int pLanguageID)
        {
            List<Entities.Education.Module> modules = new List<Entities.Education.Module>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.Module module = new Entities.Education.Module(sqlDataReader.GetInt32(0));
                        module.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        modules.Add(module);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.Module module = new Entities.Education.Module();
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    modules.Add(module);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return modules.ToArray();
        }

        public Entities.Education.Module[] ListForSpecification(int pSpecificationID, int pLanguageID)
        {
            List<Entities.Education.Module> modules = new List<Entities.Education.Module>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_ListForSpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.Module module = new Entities.Education.Module(sqlDataReader.GetInt32(0));
                        module.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        modules.Add(module);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.Module module = new Entities.Education.Module();
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    modules.Add(module);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return modules.ToArray();
        }

        public Entities.Education.Module Insert(Entities.Education.Module pModule)
        {
            Entities.Education.Module module = new Entities.Education.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_Insert]");
                try
                {
                    pModule.Detail = base.InsertTranslation(pModule.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pModule.Detail.TranslationID));
                    SqlParameter moduleID = sqlCommand.Parameters.Add("@ModuleID", SqlDbType.Int);
                    moduleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    module = new Entities.Education.Module((Int32)moduleID.Value);
                    module.Detail = new Translation(pModule.Detail.TranslationID);
                    module.Detail.Alias = pModule.Detail.Alias;
                    module.Detail.Description = pModule.Detail.Description;
                    module.Detail.Name = pModule.Detail.Name;
                }
                catch (Exception exc)
                {
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return module;
        }

        public Entities.Education.Module Update(Entities.Education.Module pModule)
        {
            Entities.Education.Module module = new Entities.Education.Module();

            pModule.Detail = base.UpdateTranslation(pModule.Detail);

            module = new Entities.Education.Module(pModule.ModuleID);
            module.Detail = new Translation(pModule.Detail.TranslationID);
            module.Detail.Alias = pModule.Detail.Alias;
            module.Detail.Description = pModule.Detail.Description;
            module.Detail.Name = pModule.Detail.Name;

            return module;
        }

        public Entities.Education.Module Delete(Entities.Education.Module pModule)
        {
            Entities.Education.Module module = new Entities.Education.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Module_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModule.ModuleID));

                    sqlCommand.ExecuteNonQuery();

                    module = new Entities.Education.Module(pModule.ModuleID);
                    base.DeleteAllTranslations(pModule.Detail);
                }
                catch (Exception exc)
                {
                    module.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    module.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return module;
        }

        public BaseBoolean AssignUnitToModule(int pModuleID, int pUnitID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ModuleUnit_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveUnitFromModule(int pModuleID, int pUnitID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ModuleUnit_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public BaseBoolean AssignContentToModule(int pModuleID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ModuleContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveContentFromModule(int pModuleID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ModuleContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
