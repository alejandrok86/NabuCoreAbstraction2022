using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentAttributeDOL : BaseDOL
    {
        public IncidentAttributeDOL() : base()
        {
        }

        public IncidentAttributeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.ServiceManagement.IncidentAttribute Get(int pIncidentID, int pIncidentAttributeDataTypeID)
        {
            Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttribute_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttributeDataTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();
                        incidentAttribute.DataType = new Entities.ServiceManagement.IncidentAttributeDataType(sqlDataReader.GetInt32(2));
                        incidentAttribute.Value = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incidentAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttribute;
        }

        public Entities.ServiceManagement.IncidentAttribute[] List(int pIncidentID)
        {
            List<Entities.ServiceManagement.IncidentAttribute> incidentAttributes = new List<Entities.ServiceManagement.IncidentAttribute>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttribute_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();
                        incidentAttribute.DataType = new Entities.ServiceManagement.IncidentAttributeDataType(sqlDataReader.GetInt32(2));
                        incidentAttribute.Value = sqlDataReader.GetString(3);
                        incidentAttributes.Add(incidentAttribute);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();
                    incidentAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidentAttributes.Add(incidentAttribute);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttributes.ToArray();
        }

        public Entities.ServiceManagement.IncidentAttribute Insert(Entities.ServiceManagement.IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttribute_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttribute.DataType.IncidentAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pIncidentAttribute.Value));

                    sqlCommand.ExecuteNonQuery();

                    incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();
                    incidentAttribute.DataType = pIncidentAttribute.DataType;
                    incidentAttribute.Value = pIncidentAttribute.Value;
                }
                catch (Exception exc)
                {
                    incidentAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttribute;
        }

        public Entities.ServiceManagement.IncidentAttribute Update(Entities.ServiceManagement.IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttribute_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttribute.DataType.IncidentAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pIncidentAttribute.Value));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    incidentAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttribute;
        }

        public Entities.ServiceManagement.IncidentAttribute Delete(Entities.ServiceManagement.IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            Entities.ServiceManagement.IncidentAttribute incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentAttribute_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentAttributeDataTypeID", pIncidentAttribute.DataType.IncidentAttributeDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    incidentAttribute = new Entities.ServiceManagement.IncidentAttribute();
                }
                catch (Exception exc)
                {
                    incidentAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incidentAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidentAttribute;
        }
    }
}


