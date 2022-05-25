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
    public class PartyTypeDOL : BaseDOL
    {
        public PartyTypeDOL() : base()
        {
        }

        public PartyTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyType Get(int pPartyTypeID, int pLanguageID)
        {
            PartyType partyType = new PartyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyType = new PartyType(sqlDataReader.GetInt32(0));
                        partyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyType;
        }

        public PartyType GetByAlias(string pAlias, int pLanguageID)
        {
            PartyType partyType = new PartyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyType = new PartyType(sqlDataReader.GetInt32(0));
                        partyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyType;
        }
       
        public PartyType[] List(int pLanguageID)
        {
            List<PartyType> partyTypes = new List<PartyType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyType partyType = new PartyType(sqlDataReader.GetInt32(0));
                        partyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyTypes.Add(partyType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyType partyType = new PartyType();
                    partyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyTypes.Add(partyType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyTypes.ToArray();
        }

        public PartyType Insert(PartyType pPartyType)
        {
            PartyType partyType = new PartyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyType_Insert]");
                try
                {
                    pPartyType.Detail = base.InsertTranslation(pPartyType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyType.Detail.TranslationID));
                    SqlParameter partyTypeID = sqlCommand.Parameters.Add("@PartyTypeID", SqlDbType.Int);
                    partyTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyType = new PartyType((Int32)partyTypeID.Value);
                    partyType.Detail = new Translation(pPartyType.Detail.TranslationID);
                    partyType.Detail.Alias = pPartyType.Detail.Alias;
                    partyType.Detail.Description = pPartyType.Detail.Description;
                    partyType.Detail.Name = pPartyType.Detail.Name;
                }
                catch (Exception exc)
                {
                    partyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyType;
        }

        public PartyType Update(PartyType pPartyType)
        {
            PartyType partyType = new PartyType();

            pPartyType.Detail = base.UpdateTranslation(pPartyType.Detail);

            partyType = new PartyType(pPartyType.PartyTypeID);
            partyType.Detail = new Translation(pPartyType.Detail.TranslationID);
            partyType.Detail.Alias = pPartyType.Detail.Alias;
            partyType.Detail.Description = pPartyType.Detail.Description;
            partyType.Detail.Name = pPartyType.Detail.Name;

            return partyType;
        }

        public PartyType Delete(PartyType pPartyType)
        {
            PartyType partyType = new PartyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pPartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyType = new PartyType(pPartyType.PartyTypeID);
                    base.DeleteAllTranslations(pPartyType.Detail);
                }
                catch (Exception exc)
                {
                    partyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyType;
        }
    }
}
