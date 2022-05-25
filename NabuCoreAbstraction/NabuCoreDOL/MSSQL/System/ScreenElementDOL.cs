using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class ScreenElementDOL : BaseDOL
    {
        public ScreenElementDOL() : base()
        {
        }

        public ScreenElementDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement Get(int pScreenElementID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenElementID", pScreenElementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement(sqlDataReader.GetInt32(0));
                        screenElement.Detail = base.GetTranslation(sqlDataReader.GetInt32(1),pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElement;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] List(int pScreenID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement> screenElements = new List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreenID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement(sqlDataReader.GetInt32(0));
                        screenElement.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        screenElements.Add(screenElement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    screenElements.Add(screenElement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElements.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] List(string pAssemblyName, string pModuleName, string pScreenName, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement> screenElements = new List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_ListByAliases]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssembyName", pAssemblyName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleName", pModuleName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenName", pScreenName));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement(sqlDataReader.GetInt32(0));
                        screenElement.Detail = new Translation(sqlDataReader.GetInt32(1), sqlDataReader.GetString(2), new Language(pLanguageID));
                        if(sqlDataReader.IsDBNull(3)==false)
                            screenElement.Detail.Name = sqlDataReader.GetString(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            screenElement.Detail.Description = sqlDataReader.GetString(4);
                        screenElements.Add(screenElement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    screenElements.Add(screenElement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElements.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement Insert(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement, int pScreenID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_Insert]");
                try
                {
                    pScreenElement.Detail = base.InsertTranslation(pScreenElement.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pScreenElement.Detail.TranslationID));
                    SqlParameter screenElementID = sqlCommand.Parameters.Add("@ScreenElementID", SqlDbType.Int);
                    screenElementID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement((Int32)screenElementID.Value);
                    screenElement.Detail = new Translation(pScreenElement.Detail.TranslationID);
                }
                catch (Exception exc)
                {
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElement;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement Update(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement, int pScreenID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_Update]");
                try
                {
                    pScreenElement.Detail = base.UpdateTranslation(pScreenElement.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenElementID", pScreenElement.ScreenElementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreenID));

                    sqlCommand.ExecuteNonQuery();

                    screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement(pScreenElement.ScreenElementID);
                    screenElement.Detail = new Translation(pScreenElement.Detail.TranslationID);
                }
                catch (Exception exc)
                {
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElement;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement Delete(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ScreenElement_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenElementID", pScreenElement.ScreenElementID));

                    sqlCommand.ExecuteNonQuery();

                    screenElement = new Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement(pScreenElement.ScreenElementID);
                }
                catch (Exception exc)
                {
                    screenElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screenElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screenElement;
        }
    }
}



