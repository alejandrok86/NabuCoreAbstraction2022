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
    public class PartyRoleTypeDOL : BaseDOL
    {
        public PartyRoleTypeDOL() : base()
        {
        }

        public PartyRoleTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyRoleType Get(int pPartyRoleTypeID, int pLanguageID)
        {
            PartyRoleType partyRoleType = new PartyRoleType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRoleTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRoleType = new PartyRoleType(sqlDataReader.GetInt32(0));
                        partyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleType;
        }

        public PartyRoleType Get(string pAlias, int pLanguageID)
        {
            PartyRoleType partyRoleType = new PartyRoleType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyRoleType = new PartyRoleType(sqlDataReader.GetInt32(0));
                        partyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleType;
        }

        public PartyRoleType[] List(int pLanguageID)
        {
            List<PartyRoleType> partyRoleTypes = new List<PartyRoleType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyRoleType partyRoleType = new PartyRoleType(sqlDataReader.GetInt32(0));
                        partyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyRoleTypes.Add(partyRoleType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRoleType partyRoleType = new PartyRoleType();
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRoleTypes.Add(partyRoleType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleTypes.ToArray();
        }

        public PartyRoleType[] List(Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            List<PartyRoleType> partyRoleTypes = new List<PartyRoleType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_ListForEducationProvider]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyRoleType partyRoleType = new PartyRoleType(sqlDataReader.GetInt32(0));
                        partyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyRoleTypes.Add(partyRoleType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyRoleType partyRoleType = new PartyRoleType();
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyRoleTypes.Add(partyRoleType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleTypes.ToArray();
        }

        public PartyRoleType Insert(PartyRoleType pPartyRoleType)
        {
            PartyRoleType partyRoleType = new PartyRoleType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_Insert]");
                try
                {
                    pPartyRoleType.Detail = base.InsertTranslation(pPartyRoleType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyRoleType.Detail.TranslationID));
                    SqlParameter partyRoleTypeID = sqlCommand.Parameters.Add("@PartyRoleTypeID", SqlDbType.Int);
                    partyRoleTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyRoleType = new PartyRoleType((Int32)partyRoleTypeID.Value);
                    partyRoleType.Detail = new Translation(pPartyRoleType.Detail.TranslationID);
                    partyRoleType.Detail.Alias = pPartyRoleType.Detail.Alias;
                    partyRoleType.Detail.Description = pPartyRoleType.Detail.Description;
                    partyRoleType.Detail.Name = pPartyRoleType.Detail.Name;
                }
                catch (Exception exc)
                {
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleType;
        }

        public PartyRoleType Update(PartyRoleType pPartyRoleType)
        {
            PartyRoleType partyRoleType = new PartyRoleType();

            pPartyRoleType.Detail = base.UpdateTranslation(pPartyRoleType.Detail);

            partyRoleType = new PartyRoleType(pPartyRoleType.PartyRoleTypeID);
            partyRoleType.Detail = new Translation(pPartyRoleType.Detail.TranslationID);
            partyRoleType.Detail.Alias = pPartyRoleType.Detail.Alias;
            partyRoleType.Detail.Description = pPartyRoleType.Detail.Description;
            partyRoleType.Detail.Name = pPartyRoleType.Detail.Name;

            return partyRoleType;
        }

        public PartyRoleType Delete(PartyRoleType pPartyRoleType)
        {
            PartyRoleType partyRoleType = new PartyRoleType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyRoleType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRoleType.PartyRoleTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partyRoleType = new PartyRoleType(pPartyRoleType.PartyRoleTypeID);
                    base.DeleteAllTranslations(pPartyRoleType.Detail);
                }
                catch (Exception exc)
                {
                    partyRoleType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyRoleType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyRoleType;
        }
    }
}
