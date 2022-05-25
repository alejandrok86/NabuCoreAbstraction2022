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
    public class PartyAttributeTypeDOL : BaseDOL
    {
        public PartyAttributeTypeDOL() : base()
        {
        }

        public PartyAttributeTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyAttributeType Get(int pPartyAttributeTypeID, int pLanguageID)
        {
            PartyAttributeType partyAttributeType = new PartyAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeTypeID", pPartyAttributeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttributeType = new PartyAttributeType(sqlDataReader.GetInt32(0));
                        partyAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(2));
                        partyAttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        partyAttributeType.DataType.xmlDataTypeDefinition = sqlDataReader.GetString(4);
                        partyAttributeType.Group = new PartyAttributeGroup(sqlDataReader.GetInt32(5));
                        partyAttributeType.Group.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        partyAttributeType.Sequence = sqlDataReader.GetInt32(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeType;
        }

        public PartyAttributeType GetByAlias(string pAlias, int pLanguageID)
        {
            PartyAttributeType partyAttributeType = new PartyAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttributeType = new PartyAttributeType(sqlDataReader.GetInt32(0));
                        partyAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(2));
                        partyAttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        partyAttributeType.DataType.xmlDataTypeDefinition = sqlDataReader.GetString(4);
                        partyAttributeType.Group = new PartyAttributeGroup(sqlDataReader.GetInt32(5));
                        partyAttributeType.Group.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        partyAttributeType.Sequence = sqlDataReader.GetInt32(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeType;
        }

        public PartyAttributeType[] List(int pPartyTypeID, int pLanguageID)
        {
            List<PartyAttributeType> partyAttributeTypes = new List<PartyAttributeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttributeType partyAttributeType = new PartyAttributeType(sqlDataReader.GetInt32(0));
                        partyAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(2));
                        partyAttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        partyAttributeType.DataType.xmlDataTypeDefinition = sqlDataReader.GetString(4);
                        partyAttributeType.Group = new PartyAttributeGroup(sqlDataReader.GetInt32(5));
                        partyAttributeType.Group.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        partyAttributeType.Sequence = sqlDataReader.GetInt32(7);
                        partyAttributeTypes.Add(partyAttributeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttributeType partyAttributeType = new PartyAttributeType();
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributeTypes.Add(partyAttributeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeTypes.ToArray();
        }

        public PartyAttributeType[] ListInGroup(int pPartyTypeID, int pPartyAttributeGroupID, int pLanguageID)
        {
            List<PartyAttributeType> partyAttributeTypes = new List<PartyAttributeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_ListInGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttributeType partyAttributeType = new PartyAttributeType(sqlDataReader.GetInt32(0));
                        partyAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeType.DataType = new PartyAttributeDataType(sqlDataReader.GetInt32(2));
                        partyAttributeType.DataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        partyAttributeType.DataType.xmlDataTypeDefinition = sqlDataReader.GetString(4);
                        partyAttributeType.Group = new PartyAttributeGroup(sqlDataReader.GetInt32(5));
                        partyAttributeType.Group.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        partyAttributeType.Sequence = sqlDataReader.GetInt32(7);
                        partyAttributeTypes.Add(partyAttributeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttributeType partyAttributeType = new PartyAttributeType();
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributeTypes.Add(partyAttributeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeTypes.ToArray();
        }

        public PartyAttributeType Insert(PartyAttributeType pPartyAttributeType, int pPartyTypeID)
        {
            PartyAttributeType partyAttributeType = new PartyAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_Insert]");
                try
                {
                    pPartyAttributeType.Detail = base.InsertTranslation(pPartyAttributeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeDataTypeID", pPartyAttributeType.DataType.PartyAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyAttributeType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeType.Group.PartyAttributeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pPartyAttributeType.Sequence));
                    SqlParameter partyAttributeTypeID = sqlCommand.Parameters.Add("@PartyAttributeTypeID", SqlDbType.Int);
                    partyAttributeTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeType = new PartyAttributeType((Int32)partyAttributeTypeID.Value);
                    partyAttributeType.Detail = new Translation(pPartyAttributeType.Detail.TranslationID);
                    partyAttributeType.Detail.Alias = pPartyAttributeType.Detail.Alias;
                    partyAttributeType.Detail.Description = pPartyAttributeType.Detail.Description;
                    partyAttributeType.Detail.Name = pPartyAttributeType.Detail.Name;
                    partyAttributeType.DataType = new PartyAttributeDataType(pPartyAttributeType.DataType.PartyAttributeDataTypeID);
                    partyAttributeType.Group = new PartyAttributeGroup(pPartyAttributeType.Group.PartyAttributeGroupID);
                    partyAttributeType.Sequence = pPartyAttributeType.Sequence;
                }
                catch (Exception exc)
                {
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeType;
        }

        public PartyAttributeType Update(PartyAttributeType pPartyAttributeType, int pPartyTypeID)
        {
            PartyAttributeType partyAttributeType = new PartyAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_Update]");
                try
                {
                    pPartyAttributeType.Detail = base.UpdateTranslation(pPartyAttributeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeTypeID", pPartyAttributeType.PartyAttributeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeDataTypeID", pPartyAttributeType.DataType.PartyAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeType.Group.PartyAttributeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pPartyAttributeType.Sequence));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeType = new PartyAttributeType(pPartyAttributeType.PartyAttributeTypeID);
                    partyAttributeType.Detail = new Translation(pPartyAttributeType.Detail.TranslationID);
                    partyAttributeType.Detail.Alias = pPartyAttributeType.Detail.Alias;
                    partyAttributeType.Detail.Description = pPartyAttributeType.Detail.Description;
                    partyAttributeType.Detail.Name = pPartyAttributeType.Detail.Name;
                    partyAttributeType.DataType = new PartyAttributeDataType(pPartyAttributeType.DataType.PartyAttributeDataTypeID);
                    partyAttributeType.Group = new PartyAttributeGroup(pPartyAttributeType.Group.PartyAttributeGroupID);
                    partyAttributeType.Sequence = pPartyAttributeType.Sequence;
                }
                catch (Exception exc)
                {
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeType;
        }

        public PartyAttributeType Delete(PartyAttributeType pPartyAttributeType)
        {
            PartyAttributeType partyAttributeType = new PartyAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeTypeID", pPartyAttributeType.PartyAttributeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeType = new PartyAttributeType(pPartyAttributeType.PartyAttributeTypeID);
                    base.DeleteAllTranslations(pPartyAttributeType.Detail);
                }
                catch (Exception exc)
                {
                    partyAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeType;
        }
    }
}
