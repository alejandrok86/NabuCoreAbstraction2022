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
    public class AssemblyDOL : BaseDOL
    {
        public AssemblyDOL() : base ()
        {
        }

        public AssemblyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly Get(int pAssemblyID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssemblyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly(sqlDataReader.GetInt32(0));
                        assembly.Name = sqlDataReader.GetString(1);
                        assembly.DefaultLanguage = new Language(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assembly;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly GetByName(string pAssemblyName, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_GetByName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyName", pAssemblyName));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly(sqlDataReader.GetInt32(0));
                        assembly.Name = sqlDataReader.GetString(1);
                        assembly.DefaultLanguage = new Language(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assembly;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.Assembly> assemblys = new List<Octavo.Gate.Nabu.CORE.Entities.System.Assembly>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly(sqlDataReader.GetInt32(0));
                        assembly.Name = sqlDataReader.GetString(1);
                        assembly.DefaultLanguage = new Language(sqlDataReader.GetInt32(2));
                        assemblys.Add(assembly);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assemblys.Add(assembly);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assemblys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly Insert(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyName", pAssembly.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefaultLanguageID", pAssembly.DefaultLanguage.LanguageID));
                    SqlParameter assemblyID = sqlCommand.Parameters.Add("@AssemblyID", SqlDbType.Int);
                    assemblyID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly((Int32)assemblyID.Value);
                    assembly.Name = pAssembly.Name;
                    assembly.DefaultLanguage = new Language(pAssembly.DefaultLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assembly;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly Update(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID",pAssembly.AssemblyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyName", pAssembly.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefaultLanguageID", pAssembly.DefaultLanguage.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly(pAssembly.AssemblyID);
                    assembly.Name = pAssembly.Name;
                    assembly.DefaultLanguage = new Language(pAssembly.DefaultLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assembly;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly Delete(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Assembly assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Assembly_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssemblyID", pAssembly.AssemblyID));

                    sqlCommand.ExecuteNonQuery();

                    assembly = new Octavo.Gate.Nabu.CORE.Entities.System.Assembly(pAssembly.AssemblyID);
                }
                catch (Exception exc)
                {
                    assembly.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assembly.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assembly;
        }
    }
}

