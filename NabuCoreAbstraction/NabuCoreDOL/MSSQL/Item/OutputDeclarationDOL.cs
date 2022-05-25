using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class OutputDeclarationDOL : BaseDOL
    {
        public OutputDeclarationDOL() : base ()
        {
        }

        public OutputDeclarationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public OutputDeclaration Get(int pOutputDeclarationID, int pLanguageID)
        {
            OutputDeclaration outputDeclaration = new OutputDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclarationID", pOutputDeclarationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(0));
                        outputDeclaration.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        outputDeclaration.OutputDeclarationXML = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclaration;
        }

        public OutputDeclaration GetByAlias(string pAlias, int pLanguageID)
        {
            OutputDeclaration outputDeclaration = new OutputDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(0));
                        outputDeclaration.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        outputDeclaration.OutputDeclarationXML = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclaration;
        }

        public OutputDeclaration[] List(int pLanguageID)
        {
            List<OutputDeclaration> outputDeclarations = new List<OutputDeclaration>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OutputDeclaration outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(0));
                        outputDeclaration.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        outputDeclaration.OutputDeclarationXML = sqlDataReader.GetString(2);
                        outputDeclarations.Add(outputDeclaration);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    OutputDeclaration outputDeclaration = new OutputDeclaration();
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    outputDeclarations.Add(outputDeclaration);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclarations.ToArray();
        }

        public OutputDeclaration Insert(OutputDeclaration pOutputDeclaration)
        {
            OutputDeclaration outputDeclaration = new OutputDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_Insert]");
                try
                {
                    pOutputDeclaration.Detail = base.InsertTranslation(pOutputDeclaration.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pOutputDeclaration.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclaration", pOutputDeclaration.OutputDeclarationXML));
                    SqlParameter outputDeclarationID = sqlCommand.Parameters.Add("@OutputDeclarationID", SqlDbType.Int);
                    outputDeclarationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    outputDeclaration = new OutputDeclaration((Int32)outputDeclarationID.Value);
                    outputDeclaration.Detail = new Translation(pOutputDeclaration.Detail.TranslationID);
                    outputDeclaration.Detail.Alias = pOutputDeclaration.Detail.Alias;
                    outputDeclaration.Detail.Description = pOutputDeclaration.Detail.Description;
                    outputDeclaration.Detail.Name = pOutputDeclaration.Detail.Name;
                    outputDeclaration.OutputDeclarationXML = pOutputDeclaration.OutputDeclarationXML;
                }
                catch (Exception exc)
                {
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclaration;
        }

        public OutputDeclaration Update(OutputDeclaration pOutputDeclaration)
        {
            OutputDeclaration outputDeclaration = new OutputDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_Update]");
                try
                {
                    pOutputDeclaration.Detail = base.UpdateTranslation(pOutputDeclaration.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclarationID", pOutputDeclaration.OutputDeclarationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclaration", pOutputDeclaration.OutputDeclarationXML));

                    sqlCommand.ExecuteNonQuery();

                    outputDeclaration = new OutputDeclaration(pOutputDeclaration.OutputDeclarationID);
                    outputDeclaration.Detail = new Translation(pOutputDeclaration.Detail.TranslationID);
                    outputDeclaration.Detail.Alias = pOutputDeclaration.Detail.Alias;
                    outputDeclaration.Detail.Description = pOutputDeclaration.Detail.Description;
                    outputDeclaration.Detail.Name = pOutputDeclaration.Detail.Name;
                    outputDeclaration.OutputDeclarationXML = pOutputDeclaration.OutputDeclarationXML;
                }
                catch (Exception exc)
                {
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclaration;
        }

        public OutputDeclaration Delete(OutputDeclaration pOutputDeclaration)
        {
            OutputDeclaration outputDeclaration = new OutputDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[OutputDeclaration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclarationID", pOutputDeclaration.OutputDeclarationID));

                    sqlCommand.ExecuteNonQuery();

                    outputDeclaration = new OutputDeclaration(pOutputDeclaration.OutputDeclarationID);
                    base.DeleteAllTranslations(pOutputDeclaration.Detail);
                }
                catch (Exception exc)
                {
                    outputDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    outputDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return outputDeclaration;
        }
    }
}
