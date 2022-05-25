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
    public class ModuleDOL : BaseDOL
    {
        public ModuleDOL() : base ()
        {
        }

        public ModuleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Module Get(int pModuleID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        module = new Octavo.Gate.Nabu.CORE.Entities.System.Module(sqlDataReader.GetInt32(0));
                        module.Name = sqlDataReader.GetString(1);
                        module.FromDate = sqlDataReader.GetDateTime(2);
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

        public Octavo.Gate.Nabu.CORE.Entities.System.Module GetByName(int pAssemblyID, string pModuleName)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_GetByName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssemblyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleName", pModuleName));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        module = new Octavo.Gate.Nabu.CORE.Entities.System.Module(sqlDataReader.GetInt32(0));
                        module.Name = sqlDataReader.GetString(1);
                        module.FromDate = sqlDataReader.GetDateTime(2);
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

        public Octavo.Gate.Nabu.CORE.Entities.System.Module[] List(int pAssembyID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.Module> modules = new List<Octavo.Gate.Nabu.CORE.Entities.System.Module>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssembyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module(sqlDataReader.GetInt32(0));
                        module.Name = sqlDataReader.GetString(1);
                        module.FromDate = sqlDataReader.GetDateTime(2);
                        modules.Add(module);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();
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

        public Octavo.Gate.Nabu.CORE.Entities.System.Module Insert(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule, int pAssemblyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssemblyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleName", pModule.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pModule.FromDate));
                    SqlParameter moduleID = sqlCommand.Parameters.Add("@ModuleID", SqlDbType.Int);
                    moduleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    module = new Octavo.Gate.Nabu.CORE.Entities.System.Module((Int32)moduleID.Value);
                    module.Name = pModule.Name;
                    module.FromDate = pModule.FromDate;
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

        public Octavo.Gate.Nabu.CORE.Entities.System.Module Update(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule, int pAssemblyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID",pModule.ModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssemblyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleName", pModule.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pModule.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    module = new Octavo.Gate.Nabu.CORE.Entities.System.Module(pModule.ModuleID);
                    module.Name = pModule.Name;
                    module.FromDate = pModule.FromDate;
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

        public Octavo.Gate.Nabu.CORE.Entities.System.Module Delete(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Module module = new Octavo.Gate.Nabu.CORE.Entities.System.Module();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Module_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModule.ModuleID));

                    sqlCommand.ExecuteNonQuery();

                    module = new Octavo.Gate.Nabu.CORE.Entities.System.Module(pModule.ModuleID);
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
    }
}

