using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class EmbeddedPageDefinitionDOL : BaseDOL
    {
        public EmbeddedPageDefinitionDOL() : base()
        {
        }

        public EmbeddedPageDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EmbeddedPageDefinition Get(int pDefinitionID)
        {
            EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmbeddedPageDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        embeddedPageDefinition = new EmbeddedPageDefinition(sqlDataReader.GetInt32(0));
                        embeddedPageDefinition.PageSource = new Uri(sqlDataReader.GetString(1));
                        if(sqlDataReader.IsDBNull(2)==false)
                            embeddedPageDefinition.AllowScrolling = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            embeddedPageDefinition.Name = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            embeddedPageDefinition.LongDescription = sqlDataReader.GetString(4);

                        embeddedPageDefinition.WidthPixels = sqlDataReader.GetString(5);
                        embeddedPageDefinition.HeightPixels = sqlDataReader.GetString(6);
                        
                        if (sqlDataReader.IsDBNull(7) == false)
                            embeddedPageDefinition.Alignment = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            embeddedPageDefinition.FrameBorder = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            embeddedPageDefinition.MarginWidth = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            embeddedPageDefinition.MarginHeight = sqlDataReader.GetString(10);

                        embeddedPageDefinition.SiteAllowsIFrames = sqlDataReader.GetBoolean(11);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    embeddedPageDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    embeddedPageDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return embeddedPageDefinition;
        }

        public EmbeddedPageDefinition[] List(int pCreatedByPartyID)
        {
            List<EmbeddedPageDefinition> embeddedPageDefinitions = new List<EmbeddedPageDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmbeddedPageDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition(sqlDataReader.GetInt32(0));
                        embeddedPageDefinition.PageSource = new Uri(sqlDataReader.GetString(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            embeddedPageDefinition.AllowScrolling = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            embeddedPageDefinition.Name = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            embeddedPageDefinition.LongDescription = sqlDataReader.GetString(4);

                        embeddedPageDefinition.WidthPixels = sqlDataReader.GetString(5);
                        embeddedPageDefinition.HeightPixels = sqlDataReader.GetString(6);

                        if (sqlDataReader.IsDBNull(7) == false)
                            embeddedPageDefinition.Alignment = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            embeddedPageDefinition.FrameBorder = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            embeddedPageDefinition.MarginWidth = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            embeddedPageDefinition.MarginHeight = sqlDataReader.GetString(10);

                        embeddedPageDefinition.SiteAllowsIFrames = sqlDataReader.GetBoolean(11);

                        embeddedPageDefinitions.Add(embeddedPageDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition();
                    embeddedPageDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    embeddedPageDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    embeddedPageDefinitions.Add(embeddedPageDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return embeddedPageDefinitions.ToArray();
        }

        public EmbeddedPageDefinition Insert(EmbeddedPageDefinition pEmbeddedPageDefinition, int pCreatedByPartyID)
        {
            EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmbeddedPageDefinition_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageSource", pEmbeddedPageDefinition.PageSource.OriginalString));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllowScrolling", ((pEmbeddedPageDefinition.AllowScrolling.Length > 0) ? pEmbeddedPageDefinition.AllowScrolling : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", ((pEmbeddedPageDefinition.Name.Length > 0) ? pEmbeddedPageDefinition.Name : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LongDescription", ((pEmbeddedPageDefinition.LongDescription.Length > 0) ? pEmbeddedPageDefinition.LongDescription : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@WidthPixels", pEmbeddedPageDefinition.WidthPixels));
                    sqlCommand.Parameters.Add(new SqlParameter("@HeightPixels", pEmbeddedPageDefinition.HeightPixels));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alignment", ((pEmbeddedPageDefinition.Alignment.Length > 0) ? pEmbeddedPageDefinition.Alignment : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FrameBorder", ((pEmbeddedPageDefinition.FrameBorder.Length > 0) ? pEmbeddedPageDefinition.FrameBorder : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MarginWidth", ((pEmbeddedPageDefinition.MarginWidth.Length > 0) ? pEmbeddedPageDefinition.MarginWidth : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MarginHeight", ((pEmbeddedPageDefinition.MarginHeight.Length > 0) ? pEmbeddedPageDefinition.MarginHeight : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteAllowsIFrames",pEmbeddedPageDefinition.SiteAllowsIFrames)); 
                    SqlParameter embeddedPageDefinitionID = sqlCommand.Parameters.Add("@DefinitionID", SqlDbType.Int);
                    embeddedPageDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    embeddedPageDefinition = new EmbeddedPageDefinition((Int32)embeddedPageDefinitionID.Value);
                    embeddedPageDefinition.Alignment = pEmbeddedPageDefinition.Alignment;
                    embeddedPageDefinition.AllowScrolling = pEmbeddedPageDefinition.AllowScrolling;
                    embeddedPageDefinition.FrameBorder = pEmbeddedPageDefinition.FrameBorder;
                    embeddedPageDefinition.HeightPixels = pEmbeddedPageDefinition.HeightPixels;
                    embeddedPageDefinition.LongDescription = pEmbeddedPageDefinition.LongDescription;
                    embeddedPageDefinition.MarginHeight = pEmbeddedPageDefinition.MarginHeight;
                    embeddedPageDefinition.MarginWidth = pEmbeddedPageDefinition.MarginWidth;
                    embeddedPageDefinition.Name = pEmbeddedPageDefinition.Name;
                    embeddedPageDefinition.PageSource = pEmbeddedPageDefinition.PageSource;
                    embeddedPageDefinition.WidthPixels = pEmbeddedPageDefinition.WidthPixels;
                    embeddedPageDefinition.SiteAllowsIFrames = pEmbeddedPageDefinition.SiteAllowsIFrames;
                }
                catch (Exception exc)
                {
                    embeddedPageDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    embeddedPageDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return embeddedPageDefinition;
        }

        public EmbeddedPageDefinition Update(EmbeddedPageDefinition pEmbeddedPageDefinition, int pCreatedByPartyID)
        {
            EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmbeddedPageDefinition_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID",pEmbeddedPageDefinition.DefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageSource", pEmbeddedPageDefinition.PageSource.OriginalString));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllowScrolling", ((pEmbeddedPageDefinition.AllowScrolling.Length > 0) ? pEmbeddedPageDefinition.AllowScrolling : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", ((pEmbeddedPageDefinition.Name.Length > 0) ? pEmbeddedPageDefinition.Name : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LongDescription", ((pEmbeddedPageDefinition.LongDescription.Length > 0) ? pEmbeddedPageDefinition.LongDescription : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@WidthPixels", pEmbeddedPageDefinition.WidthPixels));
                    sqlCommand.Parameters.Add(new SqlParameter("@HeightPixels", pEmbeddedPageDefinition.HeightPixels));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alignment", ((pEmbeddedPageDefinition.Alignment.Length > 0) ? pEmbeddedPageDefinition.Alignment : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FrameBorder", ((pEmbeddedPageDefinition.FrameBorder.Length > 0) ? pEmbeddedPageDefinition.FrameBorder : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MarginWidth", ((pEmbeddedPageDefinition.MarginWidth.Length > 0) ? pEmbeddedPageDefinition.MarginWidth : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MarginHeight", ((pEmbeddedPageDefinition.MarginHeight.Length > 0) ? pEmbeddedPageDefinition.MarginHeight : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteAllowsIFrames", pEmbeddedPageDefinition.SiteAllowsIFrames)); 

                    sqlCommand.ExecuteNonQuery();

                    embeddedPageDefinition = new EmbeddedPageDefinition(pEmbeddedPageDefinition.DefinitionID);
                    embeddedPageDefinition.Alignment = pEmbeddedPageDefinition.Alignment;
                    embeddedPageDefinition.AllowScrolling = pEmbeddedPageDefinition.AllowScrolling;
                    embeddedPageDefinition.FrameBorder = pEmbeddedPageDefinition.FrameBorder;
                    embeddedPageDefinition.HeightPixels = pEmbeddedPageDefinition.HeightPixels;
                    embeddedPageDefinition.LongDescription = pEmbeddedPageDefinition.LongDescription;
                    embeddedPageDefinition.MarginHeight = pEmbeddedPageDefinition.MarginHeight;
                    embeddedPageDefinition.MarginWidth = pEmbeddedPageDefinition.MarginWidth;
                    embeddedPageDefinition.Name = pEmbeddedPageDefinition.Name;
                    embeddedPageDefinition.PageSource = pEmbeddedPageDefinition.PageSource;
                    embeddedPageDefinition.WidthPixels = pEmbeddedPageDefinition.WidthPixels;
                    embeddedPageDefinition.SiteAllowsIFrames = pEmbeddedPageDefinition.SiteAllowsIFrames;
                }
                catch (Exception exc)
                {
                    embeddedPageDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    embeddedPageDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return embeddedPageDefinition;
        }

        public EmbeddedPageDefinition Delete(EmbeddedPageDefinition pEmbeddedPageDefinition)
        {
            EmbeddedPageDefinition embeddedPageDefinition = new EmbeddedPageDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmbeddedPageDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pEmbeddedPageDefinition.DefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    embeddedPageDefinition = new EmbeddedPageDefinition(pEmbeddedPageDefinition.DefinitionID);
                }
                catch (Exception exc)
                {
                    embeddedPageDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    embeddedPageDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return embeddedPageDefinition;
        }
    }
}
