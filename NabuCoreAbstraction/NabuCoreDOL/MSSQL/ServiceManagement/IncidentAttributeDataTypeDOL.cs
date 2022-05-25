using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentAttributeDataTypeDOL : BaseDOL
    {
        public IncidentAttributeDataTypeDOL() : base()
        {
        }

        public IncidentAttributeDataTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType Get(int pIncidentAttributeDataTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttributeDataType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttributeDataTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType(sqlDataReader.GetInt32(0));
                        incidentAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributeDataType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttributeDataType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType(sqlDataReader.GetInt32(0));
                        incidentAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributeDataType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType> incidentAttributeDataTypes = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttributeDataType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType(sqlDataReader.GetInt32(0));
                        incidentAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        incidentAttributeDataTypes.Add(incidentAttributeDataType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();
                    incidentAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentAttributeDataTypes.Add(incidentAttributeDataType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributeDataTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType pIncidentAttributeDataType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttributeDataType_Insert]");
                try
                {
                    pIncidentAttributeDataType.Detail = base.InsertTranslation(pIncidentAttributeDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIncidentAttributeDataType.Detail.TranslationID));
                    SqlParameter incidentAttributeDataTypeID = sqlCommand.Parameters.Add("@IncidentAttributeDataTypeID", SqlDbType.Int);
                    incidentAttributeDataTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType((Int32)incidentAttributeDataTypeID.Value);
                    incidentAttributeDataType.Detail = new Translation(pIncidentAttributeDataType.Detail.TranslationID);
                    incidentAttributeDataType.Detail.Alias = pIncidentAttributeDataType.Detail.Alias;
                    incidentAttributeDataType.Detail.Description = pIncidentAttributeDataType.Detail.Description;
                    incidentAttributeDataType.Detail.Name = pIncidentAttributeDataType.Detail.Name;
                }
                catch (Exception exc)
                {
                    incidentAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributeDataType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType pIncidentAttributeDataType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();

            pIncidentAttributeDataType.Detail = base.UpdateTranslation(pIncidentAttributeDataType.Detail);

            incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType(pIncidentAttributeDataType.IncidentAttributeDataTypeID);
            incidentAttributeDataType.Detail = new Translation(pIncidentAttributeDataType.Detail.TranslationID);
            incidentAttributeDataType.Detail.Alias = pIncidentAttributeDataType.Detail.Alias;
            incidentAttributeDataType.Detail.Description = pIncidentAttributeDataType.Detail.Description;
            incidentAttributeDataType.Detail.Name = pIncidentAttributeDataType.Detail.Name;

            return incidentAttributeDataType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType pIncidentAttributeDataType)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttributeDataType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttributeDataType.IncidentAttributeDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    incidentAttributeDataType = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.IncidentAttributeDataType(pIncidentAttributeDataType.IncidentAttributeDataTypeID);
                    base.DeleteAllTranslations(pIncidentAttributeDataType.Detail);
                }
                catch (Exception exc)
                {
                    incidentAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributeDataType;
        }
    }
}

