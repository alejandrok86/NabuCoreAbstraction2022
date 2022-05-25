using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class PartyAttributeGroupDOL : BaseDOL
    {
        public PartyAttributeGroupDOL() : base()
        {
        }

        public PartyAttributeGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartyAttributeGroup Get(int pPartyAttributeGroupID, int pLanguageID)
        {
            PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttributeGroup = new PartyAttributeGroup(sqlDataReader.GetInt32(0));
                        partyAttributeGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeGroup.Sequence = sqlDataReader.GetInt32(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeGroup;
        }

        public PartyAttributeGroup GetByAlias(string pAlias, int pLanguageID)
        {
            PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partyAttributeGroup = new PartyAttributeGroup(sqlDataReader.GetInt32(0));
                        partyAttributeGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeGroup.Sequence = sqlDataReader.GetInt32(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeGroup;
        }

        public PartyAttributeGroup[] List(int pLanguageID)
        {
            List<PartyAttributeGroup> partyAttributeGroups = new List<PartyAttributeGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup(sqlDataReader.GetInt32(0));
                        partyAttributeGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        partyAttributeGroup.Sequence = sqlDataReader.GetInt32(2);
                        partyAttributeGroups.Add(partyAttributeGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partyAttributeGroups.Add(partyAttributeGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeGroups.ToArray();
        }

        public PartyAttributeGroup Insert(PartyAttributeGroup pPartyAttributeGroup)
        {
            PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_Insert]");
                try
                {
                    pPartyAttributeGroup.Detail = base.InsertTranslation(pPartyAttributeGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartyAttributeGroup.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pPartyAttributeGroup.Sequence));
                    SqlParameter partyAttributeGroupID = sqlCommand.Parameters.Add("@PartyAttributeGroupID", SqlDbType.Int);
                    partyAttributeGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeGroup = new PartyAttributeGroup((Int32)partyAttributeGroupID.Value);
                    partyAttributeGroup.Detail = new Translation(pPartyAttributeGroup.Detail.TranslationID);
                    partyAttributeGroup.Detail.Alias = pPartyAttributeGroup.Detail.Alias;
                    partyAttributeGroup.Detail.Description = pPartyAttributeGroup.Detail.Description;
                    partyAttributeGroup.Detail.Name = pPartyAttributeGroup.Detail.Name;
                    partyAttributeGroup.Sequence = pPartyAttributeGroup.Sequence;
                }
                catch (Exception exc)
                {
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeGroup;
        }

        public PartyAttributeGroup Update(PartyAttributeGroup pPartyAttributeGroup)
        {
            PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();

            partyAttributeGroup.Detail = base.UpdateTranslation(pPartyAttributeGroup.Detail);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_Update]");
                try
                {
                    pPartyAttributeGroup.Detail = base.InsertTranslation(pPartyAttributeGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeGroup.PartyAttributeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pPartyAttributeGroup.Sequence));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeGroup = new PartyAttributeGroup(pPartyAttributeGroup.PartyAttributeGroupID);
                    partyAttributeGroup.Detail = new Translation(pPartyAttributeGroup.Detail.TranslationID);
                    partyAttributeGroup.Detail.Alias = pPartyAttributeGroup.Detail.Alias;
                    partyAttributeGroup.Detail.Description = pPartyAttributeGroup.Detail.Description;
                    partyAttributeGroup.Detail.Name = pPartyAttributeGroup.Detail.Name;
                    partyAttributeGroup.Sequence = pPartyAttributeGroup.Sequence;
                }
                catch (Exception exc)
                {
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return partyAttributeGroup;
        }

        public PartyAttributeGroup Delete(PartyAttributeGroup pPartyAttributeGroup)
        {
            PartyAttributeGroup partyAttributeGroup = new PartyAttributeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartyAttributeGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyAttributeGroupID", pPartyAttributeGroup.PartyAttributeGroupID));

                    sqlCommand.ExecuteNonQuery();

                    partyAttributeGroup = new PartyAttributeGroup(pPartyAttributeGroup.PartyAttributeGroupID);
                    base.DeleteAllTranslations(pPartyAttributeGroup.Detail);
                }
                catch (Exception exc)
                {
                    partyAttributeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partyAttributeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partyAttributeGroup;
        }
    }
}
