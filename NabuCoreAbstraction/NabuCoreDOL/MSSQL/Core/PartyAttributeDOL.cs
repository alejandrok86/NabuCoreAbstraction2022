using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class PartyAttributeDOL : BaseDOL
    {
        public PartyAttributeDOL() : base()
        {
        }

        public PartyAttributeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyAttribute Get(int pPartyAttributeID, int pLanguageID)
        {
            PartyAttribute partyAttribute = new PartyAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeID", pPartyAttributeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttribute = new PartyAttribute(sqlDataReader.GetInt32(0));
                        partyAttribute.AttributeType = new PartyAttributeType(sqlDataReader.GetInt32(1));
                        partyAttribute.AttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partyAttribute.AttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(3));
                        partyAttribute.AttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        partyAttribute.AttributeValue = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttribute;
        }

        public PartyAttribute[] List(int pPartyID, int pLanguageID)
        {
            List<PartyAttribute> partyAttributes = new List<PartyAttribute>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttribute partyAttribute = new PartyAttribute(sqlDataReader.GetInt32(0));
                        partyAttribute.AttributeType = new PartyAttributeType(sqlDataReader.GetInt32(1));
                        partyAttribute.AttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partyAttribute.AttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(3));
                        partyAttribute.AttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        partyAttribute.AttributeValue = sqlDataReader.GetString(5);

                        partyAttributes.Add(partyAttribute);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttribute partyAttribute = new PartyAttribute();
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributes.Add(partyAttribute);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributes.ToArray();
        }

        public PartyAttribute[] ListInGroup(int pPartyID, int pPartyAttributeGroupID, int pLanguageID)
        {
            List<PartyAttribute> partyAttributes = new List<PartyAttribute>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_ListInGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttribute partyAttribute = new PartyAttribute(sqlDataReader.GetInt32(0));
                        partyAttribute.AttributeType = new PartyAttributeType(sqlDataReader.GetInt32(1));
                        partyAttribute.AttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partyAttribute.AttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(3));
                        partyAttribute.AttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        partyAttribute.AttributeValue = sqlDataReader.GetString(5);

                        partyAttributes.Add(partyAttribute);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttribute partyAttribute = new PartyAttribute();
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributes.Add(partyAttribute);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributes.ToArray();
        }

        public PartyAttribute Insert(PartyAttribute pPartyAttribute, int pPartyID)
        {
            PartyAttribute partyAttribute = new PartyAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeTypeID", pPartyAttribute.AttributeType.PartyAttributeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttributeValue", pPartyAttribute.AttributeValue));
                    SqlParameter partyAttributeID = sqlCommand.Parameters.Add("@PartyAttributeID", SqlDbType.Int);
                    partyAttributeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyAttribute = new PartyAttribute((Int32)partyAttributeID.Value);
                    partyAttribute.AttributeType = new PartyAttributeType(pPartyAttribute.AttributeType.PartyAttributeTypeID);
                    partyAttribute.AttributeValue = pPartyAttribute.AttributeValue;
                }
                catch (Exception exc)
                {
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttribute;
        }

        public PartyAttribute Update(PartyAttribute pPartyAttribute)
        {
            PartyAttribute partyAttribute = new PartyAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeID", pPartyAttribute.PartyAttributeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttributeValue", pPartyAttribute.AttributeValue));

                    sqlCommand.ExecuteNonQuery();

                    partyAttribute = new PartyAttribute(pPartyAttribute.PartyAttributeID);
                    partyAttribute.AttributeType = new PartyAttributeType(pPartyAttribute.AttributeType.PartyAttributeTypeID);
                    partyAttribute.AttributeValue = pPartyAttribute.AttributeValue;
                }
                catch (Exception exc)
                {
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttribute;
        }

        public PartyAttribute Delete(PartyAttribute pPartyAttribute)
        {
            PartyAttribute partyAttribute = new PartyAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttribute_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeID", pPartyAttribute.PartyAttributeID));

                    sqlCommand.ExecuteNonQuery();

                    partyAttribute = new PartyAttribute(pPartyAttribute.PartyAttributeID);
                }
                catch (Exception exc)
                {
                    partyAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttribute;
        }
    }
}

