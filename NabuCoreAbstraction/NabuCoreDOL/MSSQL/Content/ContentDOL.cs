using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class ContentDOL : BaseDOL
    {
        public ContentDOL() : base ()
        {
        }

        public ContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Get(int pContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetByRetrievalIdentifier(Guid pUniqueRetrievalID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_GetByRetrievalIdentifier]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", pUniqueRetrievalID.ToString()));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetByTagID(int pTagID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_GetByTagID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTagID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }
        
        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetByTagPhrase(string pPhrase, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_GetByTagPhrase]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Phrase", pPhrase));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] List()
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4)); 
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForSpecification(int pSpecificationID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListForSpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForModule(int pModuleID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListForModule]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForUnit(int pUnitID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListForUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListChildren(int pParentContentID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContentID", pParentContentID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForParty(int pPartyID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForPartyAndContentTypeAlias(int pPartyID, string pContentTypeAlias, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByPartyAndContentTypeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContentTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForProgrammeAndContentTypeAlias(int pProgrammeID, string pContentTypeAlias, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByProgrammeAndContentTypeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContentTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForProjectAndContentTypeAlias(int pProjectID, string pContentTypeAlias, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByProjectAndContentTypeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContentTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForPart(int pPartID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForPartAndContentTypeAlias(int pPartID, string pContentTypeAlias, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByPartAndContentTypeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContentTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForDefect(int pDefectID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByDefect]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefectID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForIteration(int pIterationID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByIteration]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForRequirement(int pRequirementID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByRequirement]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirementID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForIncident(int pIncidentID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByIncident]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForProblem(int pProblemID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByProblem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblemID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListForChange(int pChangeID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_ListByChange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChangeID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Insert(Octavo.Gate.Nabu.CORE.Entities.Content.Content pContent, int? pParentContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pContent.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pContent.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pContent.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContentID", pParentContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", ((pContent.contentGUID == Guid.Empty) ? null : pContent.contentGUID.ToString()))); 
                    SqlParameter contentID = sqlCommand.Parameters.Add("@ContentID", SqlDbType.Int);
                    contentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content((Int32)contentID.Value);
                    content.Name = pContent.Name;
                    content.Description = pContent.Description;
                    content.UseVersionControls = pContent.UseVersionControls;
                    content.contentGUID = pContent.contentGUID;
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Update(Octavo.Gate.Nabu.CORE.Entities.Content.Content pContent, int? pParentContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pContent.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pContent.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pContent.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContentID", pParentContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", ((pContent.contentGUID == Guid.Empty) ? null : pContent.contentGUID.ToString()))); 

                    sqlCommand.ExecuteNonQuery();

                    content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(pContent.ContentID);
                    content.Name = pContent.Name;
                    content.Description = pContent.Description;
                    content.UseVersionControls = pContent.UseVersionControls;
                    content.contentGUID = pContent.contentGUID;
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Update(Octavo.Gate.Nabu.CORE.Entities.Content.Content pContent)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_UpdateIgnoreParent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pContent.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pContent.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pContent.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", ((pContent.contentGUID == Guid.Empty) ? null : pContent.contentGUID.ToString())));

                    sqlCommand.ExecuteNonQuery();

                    content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(pContent.ContentID);
                    content.Name = pContent.Name;
                    content.Description = pContent.Description;
                    content.UseVersionControls = pContent.UseVersionControls;
                    content.contentGUID = pContent.contentGUID;
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Delete(Octavo.Gate.Nabu.CORE.Entities.Content.Content pContent)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(pContent.ContentID);
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content DeleteComplete(Octavo.Gate.Nabu.CORE.Entities.Content.Content pContent)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_DeleteComplete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(pContent.ContentID);
                }
                catch (Exception exc)
                {
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return content;
        }
    }
}
