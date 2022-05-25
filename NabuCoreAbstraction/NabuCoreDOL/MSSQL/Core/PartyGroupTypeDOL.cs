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
    public class PartyGroupTypeDOL : BaseDOL
    {
        public PartyGroupTypeDOL() : base()
        {
        }

        public PartyGroupTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyGroupType Get(int pPartyGroupTypeID, int pLanguageID)
        {
            PartyGroupType partyGroupType = new PartyGroupType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupTypeID", pPartyGroupTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyGroupType = new PartyGroupType(sqlDataReader.GetInt32(0));
                        partyGroupType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyGroupType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroupType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroupType;
        }

        public PartyGroupType GetByAlias(string pAlias, int pLanguageID)
        {
            PartyGroupType partyGroupType = new PartyGroupType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyGroupType = new PartyGroupType(sqlDataReader.GetInt32(0));
                        partyGroupType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyGroupType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroupType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroupType;
        }
       
        public PartyGroupType[] List(int pLanguageID)
        {
            List<PartyGroupType> partyGroupTypes = new List<PartyGroupType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyGroupType partyGroupType = new PartyGroupType(sqlDataReader.GetInt32(0));
                        partyGroupType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyGroupTypes.Add(partyGroupType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyGroupType partyGroupType = new PartyGroupType();
                    partyGroupType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroupType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyGroupTypes.Add(partyGroupType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroupTypes.ToArray();
        }

        public PartyGroupType Insert(PartyGroupType pPartyGroupType)
        {
            PartyGroupType partyGroupType = new PartyGroupType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupType_Insert]");
                try
                {
                    pPartyGroupType.Detail = base.InsertTranslation(pPartyGroupType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyGroupType.Detail.TranslationID));
                    SqlParameter partyGroupTypeID = sqlCommand.Parameters.Add("@PartyGroupTypeID", SqlDbType.Int);
                    partyGroupTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyGroupType = new PartyGroupType((Int32)partyGroupTypeID.Value);
                    partyGroupType.Detail = new Translation(pPartyGroupType.Detail.TranslationID);
                    partyGroupType.Detail.Alias = pPartyGroupType.Detail.Alias;
                    partyGroupType.Detail.Description = pPartyGroupType.Detail.Description;
                    partyGroupType.Detail.Name = pPartyGroupType.Detail.Name;
                }
                catch (Exception exc)
                {
                    partyGroupType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroupType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroupType;
        }

        public PartyGroupType Update(PartyGroupType pPartyGroupType)
        {
            PartyGroupType partyGroupType = new PartyGroupType();

            pPartyGroupType.Detail = base.UpdateTranslation(pPartyGroupType.Detail);

            partyGroupType = new PartyGroupType(pPartyGroupType.PartyGroupTypeID);
            partyGroupType.Detail = new Translation(pPartyGroupType.Detail.TranslationID);
            partyGroupType.Detail.Alias = pPartyGroupType.Detail.Alias;
            partyGroupType.Detail.Description = pPartyGroupType.Detail.Description;
            partyGroupType.Detail.Name = pPartyGroupType.Detail.Name;

            return partyGroupType;
        }

        public PartyGroupType Delete(PartyGroupType pPartyGroupType)
        {
            PartyGroupType partyGroupType = new PartyGroupType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyGroupType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyGroupTypeID", pPartyGroupType.PartyGroupTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyGroupType = new PartyGroupType(pPartyGroupType.PartyGroupTypeID);
                    base.DeleteAllTranslations(pPartyGroupType.Detail);
                }
                catch (Exception exc)
                {
                    partyGroupType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyGroupType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyGroupType;
        }
    }
}
