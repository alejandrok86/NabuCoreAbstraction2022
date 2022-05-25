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
    public class PartyAttributeDataTypeDOL : BaseDOL
    {
        public PartyAttributeDataTypeDOL() : base()
        {
        }

        public PartyAttributeDataTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyAttributeDataType Get(int pPartyAttributeDataTypeID, int pLanguageID)
        {
            PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeDataType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeDataTypeID", pPartyAttributeDataTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttributeDataType = new PartyAttributeDataType(sqlDataReader.GetInt32(0));
                        partyAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeDataType;
        }

        public PartyAttributeDataType[] List(int pLanguageID)
        {
            List<PartyAttributeDataType> partyAttributeDataTypes = new List<PartyAttributeDataType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeDataType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType(sqlDataReader.GetInt32(0));
                        partyAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                        partyAttributeDataTypes.Add(partyAttributeDataType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType();
                    partyAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributeDataTypes.Add(partyAttributeDataType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeDataTypes.ToArray();
        }

        public PartyAttributeDataType Insert(PartyAttributeDataType pPartyAttributeDataType)
        {
            PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeDataType_Insert]");
                try
                {
                    pPartyAttributeDataType.Detail = base.InsertTranslation(pPartyAttributeDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyAttributeDataType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pPartyAttributeDataType.xmlDataTypeDefinition));
                    SqlParameter partyAttributeDataTypeID = sqlCommand.Parameters.Add("@PartyAttributeDataTypeID", SqlDbType.Int);
                    partyAttributeDataTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeDataType = new PartyAttributeDataType((Int32)partyAttributeDataTypeID.Value);
                    partyAttributeDataType.Detail = new Translation(pPartyAttributeDataType.Detail.TranslationID);
                    partyAttributeDataType.Detail.Alias = pPartyAttributeDataType.Detail.Alias;
                    partyAttributeDataType.Detail.Description = pPartyAttributeDataType.Detail.Description;
                    partyAttributeDataType.Detail.Name = pPartyAttributeDataType.Detail.Name;
                    partyAttributeDataType.xmlDataTypeDefinition = pPartyAttributeDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    partyAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeDataType;
        }

        public PartyAttributeDataType Update(PartyAttributeDataType pPartyAttributeDataType)
        {
            PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeDataType_Update]");
                try
                {
                    pPartyAttributeDataType.Detail = base.UpdateTranslation(pPartyAttributeDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeDataTypeID", pPartyAttributeDataType.PartyAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pPartyAttributeDataType.xmlDataTypeDefinition));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeDataType = new PartyAttributeDataType(pPartyAttributeDataType.PartyAttributeDataTypeID);
                    partyAttributeDataType.Detail = new Translation(pPartyAttributeDataType.Detail.TranslationID);
                    partyAttributeDataType.Detail.Alias = pPartyAttributeDataType.Detail.Alias;
                    partyAttributeDataType.Detail.Description = pPartyAttributeDataType.Detail.Description;
                    partyAttributeDataType.Detail.Name = pPartyAttributeDataType.Detail.Name;
                    partyAttributeDataType.xmlDataTypeDefinition = pPartyAttributeDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    partyAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeDataType;
        }

        public PartyAttributeDataType Delete(PartyAttributeDataType pPartyAttributeDataType)
        {
            PartyAttributeDataType partyAttributeDataType = new PartyAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeDataType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeDataTypeID", pPartyAttributeDataType.PartyAttributeDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeDataType = new PartyAttributeDataType(pPartyAttributeDataType.PartyAttributeDataTypeID);
                    base.DeleteAllTranslations(pPartyAttributeDataType.Detail);
                }
                catch (Exception exc)
                {
                    partyAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeDataType;
        }
    }
}
