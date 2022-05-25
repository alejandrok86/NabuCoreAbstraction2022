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
    public class PartyRelationshipTypeDOL : BaseDOL
    {
        public PartyRelationshipTypeDOL() : base()
        {
        }

        public PartyRelationshipTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyRelationshipType Get(int pPartyRelationshipTypeID, int pLanguageID)
        {
            PartyRelationshipType partyRelationshipType = new PartyRelationshipType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationshipType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipTypeID", pPartyRelationshipTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(0));
                        partyRelationshipType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRelationshipType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationshipType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationshipType;
        }

        public PartyRelationshipType GetByAlias(string pAlias, int pLanguageID)
        {
            PartyRelationshipType partyRelationshipType = new PartyRelationshipType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationshipType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(0));
                        partyRelationshipType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRelationshipType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationshipType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationshipType;
        }

        public PartyRelationshipType[] List(int pLanguageID)
        {
            List<PartyRelationshipType> partyRelationshipTypes = new List<PartyRelationshipType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationshipType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyRelationshipType partyRelationshipType = new PartyRelationshipType(sqlDataReader.GetInt32(0));
                        partyRelationshipType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyRelationshipTypes.Add(partyRelationshipType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRelationshipType partyRelationshipType = new PartyRelationshipType();
                    partyRelationshipType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationshipType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRelationshipTypes.Add(partyRelationshipType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationshipTypes.ToArray();
        }

        public PartyRelationshipType Insert(PartyRelationshipType pPartyRelationshipType)
        {
            PartyRelationshipType partyRelationshipType = new PartyRelationshipType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationshipType_Insert]");
                try
                {
                    pPartyRelationshipType.Detail = base.InsertTranslation(pPartyRelationshipType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyRelationshipType.Detail.TranslationID));
                    SqlParameter partyRelationshipTypeID = sqlCommand.Parameters.Add("@PartyRelationshipTypeID", SqlDbType.Int);
                    partyRelationshipTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyRelationshipType = new PartyRelationshipType((Int32)partyRelationshipTypeID.Value);
                    partyRelationshipType.Detail = new Translation(pPartyRelationshipType.Detail.TranslationID);
                    partyRelationshipType.Detail.Alias = pPartyRelationshipType.Detail.Alias;
                    partyRelationshipType.Detail.Description = pPartyRelationshipType.Detail.Description;
                    partyRelationshipType.Detail.Name = pPartyRelationshipType.Detail.Name;
                }
                catch (Exception exc)
                {
                    partyRelationshipType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationshipType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationshipType;
        }

        public PartyRelationshipType Update(PartyRelationshipType pPartyRelationshipType)
        {
            PartyRelationshipType partyRelationshipType = new PartyRelationshipType();

            pPartyRelationshipType.Detail = base.UpdateTranslation(pPartyRelationshipType.Detail);

            partyRelationshipType = new PartyRelationshipType(pPartyRelationshipType.PartyRelationshipTypeID);
            partyRelationshipType.Detail = new Translation(pPartyRelationshipType.Detail.TranslationID);
            partyRelationshipType.Detail.Alias = pPartyRelationshipType.Detail.Alias;
            partyRelationshipType.Detail.Description = pPartyRelationshipType.Detail.Description;
            partyRelationshipType.Detail.Name = pPartyRelationshipType.Detail.Name;

            return partyRelationshipType;
        }

        public PartyRelationshipType Delete(PartyRelationshipType pPartyRelationshipType)
        {
            PartyRelationshipType partyRelationshipType = new PartyRelationshipType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRelationshipType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRelationshipTypeID", pPartyRelationshipType.PartyRelationshipTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyRelationshipType = new PartyRelationshipType(pPartyRelationshipType.PartyRelationshipTypeID);
                    base.DeleteAllTranslations(pPartyRelationshipType.Detail);
                }
                catch (Exception exc)
                {
                    partyRelationshipType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRelationshipType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRelationshipType;
        }
    }
}
