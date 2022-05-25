using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class BinaryDOL : BaseDOL
    {
        public BinaryDOL() : base()
        {
        }

        public BinaryDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Development.Binary Get(int? pBinaryID)
        {
            Entities.Development.Binary binary = new Entities.Development.Binary();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        binary = new Entities.Development.Binary(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
		                    binary.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            binary.Namespace = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            binary.GUID = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binary;
        }

        public Entities.Development.Binary GetByGUID(string pGUID)
        {
            Entities.Development.Binary binary = new Entities.Development.Binary();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_GetByGUID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GUID", pGUID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        binary = new Entities.Development.Binary(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            binary.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            binary.Namespace = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            binary.GUID = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binary;
        }

        public Entities.Development.Binary[] List()
        {
            List<Entities.Development.Binary> binarys = new List<Entities.Development.Binary>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Binary binary = new Entities.Development.Binary(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            binary.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            binary.Namespace = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            binary.GUID = sqlDataReader.GetString(3);
                        binarys.Add(binary);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Binary binary = new Entities.Development.Binary();
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    binarys.Add(binary);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binarys.ToArray();
        }

        public Entities.Development.Binary[] ListDependencies(int pBinaryID)
        {
            List<Entities.Development.Binary> binarys = new List<Entities.Development.Binary>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_ListDependencies]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Binary binary = new Entities.Development.Binary(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            binary.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            binary.Namespace = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            binary.GUID = sqlDataReader.GetString(3);
                        binarys.Add(binary);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Binary binary = new Entities.Development.Binary();
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    binarys.Add(binary);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binarys.ToArray();
        }

        public Entities.Development.Binary[] ListForProject(int pProjectID)
        {
            List<Entities.Development.Binary> binarys = new List<Entities.Development.Binary>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_ListForProject]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Binary binary = new Entities.Development.Binary(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            binary.Name = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            binary.Namespace = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            binary.GUID = sqlDataReader.GetString(3);
                        binarys.Add(binary);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Binary binary = new Entities.Development.Binary();
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    binarys.Add(binary);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binarys.ToArray();
        }

        public Entities.Development.Binary Insert(Entities.Development.Binary pBinary)
        {
            Entities.Development.Binary binary = new Entities.Development.Binary();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryName", pBinary.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Namespace", pBinary.Namespace));
                    sqlCommand.Parameters.Add(new SqlParameter("@GUID", pBinary.GUID));
                    SqlParameter binaryID = sqlCommand.Parameters.Add("@BinaryID", SqlDbType.Int);
                    binaryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    binary = new Entities.Development.Binary((Int32)binaryID.Value);
                    binary.Name = pBinary.Name;
                    binary.Namespace = pBinary.Namespace;
                    binary.GUID = pBinary.GUID;
                }
                catch (Exception exc)
                {
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binary;
        }

        public Entities.Development.Binary Update(Entities.Development.Binary pBinary)
        {
            Entities.Development.Binary binary = new Entities.Development.Binary();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinary.BinaryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryName", pBinary.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Namespace", pBinary.Namespace));
                    sqlCommand.Parameters.Add(new SqlParameter("@GUID", pBinary.GUID));

                    sqlCommand.ExecuteNonQuery();

                    binary = new Entities.Development.Binary(pBinary.BinaryID);
                    binary.Name = pBinary.Name;
                    binary.Namespace = pBinary.Namespace;
                    binary.GUID = pBinary.GUID;
                }
                catch (Exception exc)
                {
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binary;
        }

        public Entities.Development.Binary Delete(Entities.Development.Binary pBinary)
        {
            Entities.Development.Binary binary = new Entities.Development.Binary();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinary.BinaryID));

                    sqlCommand.ExecuteNonQuery();

                    binary = new Entities.Development.Binary(pBinary.BinaryID);
                }
                catch (Exception exc)
                {
                    binary.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    binary.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return binary;
        }

        public Entities.BaseBoolean RegisterDependency(int pBinaryID, int pDependentUponBinaryID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_RegisterDependency]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DependentUponBinaryID", pDependentUponBinaryID));

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

        public Entities.BaseBoolean RemoveDependency(int pBinaryID, int pDependentUponBinaryID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Binary_RemoveDependency]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DependentUponBinaryID", pDependentUponBinaryID));

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


