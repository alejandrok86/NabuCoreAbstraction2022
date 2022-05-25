using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class ContainerTypeDOL : BaseDOL
    {
        public ContainerTypeDOL() : base()
        {
        }

        public ContainerTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ContainerType Get(int pContainerTypeID, int pLanguageID)
        {
            ContainerType containerType = new ContainerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerTypeID", pContainerTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        containerType = new ContainerType(sqlDataReader.GetInt32(0));
                        containerType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    containerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerType;
        }

        public ContainerType GetByAlias(string pAlias, int pLanguageID)
        {
            ContainerType containerType = new ContainerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        containerType = new ContainerType(sqlDataReader.GetInt32(0));
                        containerType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    containerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerType;
        }

        public ContainerType[] List(int pLanguageID)
        {
            List<ContainerType> containerTypes = new List<ContainerType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContainerType containerType = new ContainerType(sqlDataReader.GetInt32(0));
                        containerType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        containerTypes.Add(containerType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContainerType containerType = new ContainerType();
                    containerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    containerTypes.Add(containerType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerTypes.ToArray();
        }

        public ContainerType Insert(ContainerType pContainerType)
        {
            ContainerType containerType = new ContainerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerType_Insert]");
                try
                {
                    pContainerType.Detail = base.InsertTranslation(pContainerType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContainerType.Detail.TranslationID));
                    SqlParameter containerTypeID = sqlCommand.Parameters.Add("@ContainerTypeID", SqlDbType.Int);
                    containerTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    containerType = new ContainerType((Int32)containerTypeID.Value);
                    containerType.Detail = new Translation(pContainerType.Detail.TranslationID);
                    containerType.Detail.Alias = pContainerType.Detail.Alias;
                    containerType.Detail.Description = pContainerType.Detail.Description;
                    containerType.Detail.Name = pContainerType.Detail.Name;
                }
                catch (Exception exc)
                {
                    containerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerType;
        }

        public ContainerType Update(ContainerType pContainerType)
        {
            ContainerType containerType = new ContainerType();

            containerType.Detail = base.UpdateTranslation(pContainerType.Detail);

            return containerType;
        }

        public ContainerType Delete(ContainerType pContainerType)
        {
            ContainerType containerType = new ContainerType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ContainerType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerTypeID", pContainerType.ContainerTypeID));

                    sqlCommand.ExecuteNonQuery();

                    containerType = new ContainerType(pContainerType.ContainerTypeID);
                    base.DeleteAllTranslations(pContainerType.Detail);
                }
                catch (Exception exc)
                {
                    containerType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    containerType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return containerType;
        }
    }
}

