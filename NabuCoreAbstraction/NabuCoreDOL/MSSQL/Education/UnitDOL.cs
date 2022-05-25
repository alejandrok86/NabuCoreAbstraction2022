using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class UnitDOL : BaseDOL
    {
        public UnitDOL() : base ()
        {
        }

        public UnitDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Unit Get(int pUnitID, int pLanguageID)
        {
            Unit unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unit = new Unit(sqlDataReader.GetInt32(0));
                        unit.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if(sqlDataReader.IsDBNull(2)==false)
                            unit.Tier = new Tier(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unit;
        }

        public Unit GetByAlias(string pAlias, int pLanguageID)
        {
            Unit unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unit = new Unit(sqlDataReader.GetInt32(0));
                        unit.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            unit.Tier = new Tier(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace; 
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unit;
        }

        public Unit GetByRSSFeedItem(int pRSSFeedItemID, int pLanguageID)
        {
            Unit unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_GetByRSSFeedItem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unit = new Unit(sqlDataReader.GetInt32(0));
                        unit.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            unit.Tier = new Tier(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unit;
        }

        public Unit[] List(int pLanguageID)
        {
            List<Unit> units = new List<Unit>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Unit unit = new Unit(sqlDataReader.GetInt32(0));
                        unit.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            unit.Tier = new Tier(sqlDataReader.GetInt32(2));
                        units.Add(unit);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Unit unit = new Unit();
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    units.Add(unit);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return units.ToArray();
        }

        public Unit[] ListForModule(int pModuleID, int pLanguageID)
        {
            List<Unit> units = new List<Unit>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_ListForModule]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Unit unit = new Unit(sqlDataReader.GetInt32(0));
                        unit.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            unit.Tier = new Tier(sqlDataReader.GetInt32(2));
                        units.Add(unit);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Unit unit = new Unit();
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    units.Add(unit);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return units.ToArray();
        }

        public Unit Insert(Unit pUnit)
        {
            Unit unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_Insert]");
                try
                {
                    pUnit.Detail = base.InsertTranslation(pUnit.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pUnit.Detail.TranslationID));
                    SqlParameter unitID = sqlCommand.Parameters.Add("@UnitID", SqlDbType.Int);
                    unitID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    unit = new Unit((Int32)unitID.Value);
                    unit.Detail = new Translation(pUnit.Detail.TranslationID);
                    unit.Detail.Alias = pUnit.Detail.Alias;
                    unit.Detail.Description = pUnit.Detail.Description;
                    unit.Detail.Name = pUnit.Detail.Name;
                    if (pUnit.Tier != null)
                        unit.Tier = new Tier(pUnit.Tier.TierID);
                }
                catch (Exception exc)
                {
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unit;
        }

        public Unit Update(Unit pUnit)
        {
            Unit unit = new Unit();

            pUnit.Detail = base.UpdateTranslation(pUnit.Detail);

            unit = new Unit(pUnit.UnitID);
            unit.Detail = new Translation(pUnit.Detail.TranslationID);
            unit.Detail.Alias = pUnit.Detail.Alias;
            unit.Detail.Description = pUnit.Detail.Description;
            unit.Detail.Name = pUnit.Detail.Name;
            if (pUnit.Tier != null)
                unit.Tier = new Tier(pUnit.Tier.TierID);

            return unit;
        }

        public Unit Delete(Unit pUnit)
        {
            Unit unit = new Unit();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnit.UnitID));

                    sqlCommand.ExecuteNonQuery();

                    unit = new Unit(pUnit.UnitID);
                    base.DeleteAllTranslations(pUnit.Detail);
                }
                catch (Exception exc)
                {
                    unit.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unit.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unit;
        }

        public BaseBoolean AssignInstrumentToUnit(int pUnitID, int pInstrumentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitInstrument_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveInstrumentFromUnit(int pUnitID, int pInstrumentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitInstrument_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AssignContentToUnit(int pUnitID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveContentFromUnit(int pUnitID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AssignRSSFeedToUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitRSSFeedDefinition_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveRSSFeedFromUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitRSSFeedDefinition_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AssignTwitterFeedToUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitTwitterFeedDefinition_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveTwitterFeedFromUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitTwitterFeedDefinition_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AssignEmbeddedPageToUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitEmbeddedPageDefinition_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveEmbeddedPageFromUnit(int pUnitID, int pDefinitionID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitEmbeddedPageDefinition_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AssignArticleToUnit(int pUnitID, int pArticleID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitArticle_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticleID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveArticleFromUnit(int pUnitID, int pArticleID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[UnitArticle_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticleID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseKeyPair[] ListComponents(int pUnitID, bool isAscendingByLastUpdated)
        {
            List<BaseKeyPair> keyPairs = new List<BaseKeyPair>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = null;
                if(isAscendingByLastUpdated)
                    sqlCommand = new SqlCommand("[SchEducation].[Unit_ListComponentsAscending]");
                else
                    sqlCommand = new SqlCommand("[SchEducation].[Unit_ListComponents]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        BaseKeyPair keyPair = null;

                        if (sqlDataReader.IsDBNull(1) == false)              // Article
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "Article", sqlDataReader.GetInt32(1).ToString());
                        else if (sqlDataReader.IsDBNull(2) == false)         // Content
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "Content", sqlDataReader.GetInt32(2).ToString());
                        else if (sqlDataReader.IsDBNull(3) == false)         // EmbeddedPageDefinition
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "EmbeddedPageDefinition", sqlDataReader.GetInt32(3).ToString());
                        else if (sqlDataReader.IsDBNull(4) == false)         // Instrument
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "Instrument", sqlDataReader.GetInt32(4).ToString());
                        else if (sqlDataReader.IsDBNull(5) == false)         // RSS
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "RSSFeedDefinition", sqlDataReader.GetInt32(5).ToString());
                        else if (sqlDataReader.IsDBNull(6) == false)         // RSS
                            keyPair = new BaseKeyPair(sqlDataReader.GetInt32(0), "TwitterFeedDefinition", sqlDataReader.GetInt32(6).ToString());

                        if(keyPair != null)
                            keyPairs.Add(keyPair);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    BaseKeyPair error = new BaseKeyPair();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    keyPairs.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return keyPairs.ToArray();
        }

        public BaseKeyPair GetUnitComponent(int pUnitComponentID)
        {
            BaseKeyPair unitComponent = new BaseKeyPair();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Unit_GetComponent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitComponentID", pUnitComponentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        if (sqlDataReader.IsDBNull(1) == false)              // Article
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "Article", sqlDataReader.GetInt32(1).ToString());
                        else if (sqlDataReader.IsDBNull(2) == false)         // Content
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "Content", sqlDataReader.GetInt32(2).ToString());
                        else if (sqlDataReader.IsDBNull(3) == false)         // EmbeddedPageDefinition
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "EmbeddedPageDefinition", sqlDataReader.GetInt32(3).ToString());
                        else if (sqlDataReader.IsDBNull(4) == false)         // Instrument
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "Instrument", sqlDataReader.GetInt32(4).ToString());
                        else if (sqlDataReader.IsDBNull(5) == false)         // RSS
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "RSSFeedDefinition", sqlDataReader.GetInt32(5).ToString());
                        else if (sqlDataReader.IsDBNull(6) == false)         // RSS
                            unitComponent = new BaseKeyPair(sqlDataReader.GetInt32(0), "TwitterFeedDefinition", sqlDataReader.GetInt32(6).ToString());
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unitComponent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unitComponent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unitComponent;
        }
    }
}
