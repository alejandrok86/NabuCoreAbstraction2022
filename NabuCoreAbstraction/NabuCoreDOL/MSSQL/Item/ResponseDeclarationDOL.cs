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
    public class ResponseDeclarationDOL : BaseDOL
    {
        public ResponseDeclarationDOL() : base ()
        {
        }

        public ResponseDeclarationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ResponseDeclaration Get(int pResponseDeclarationID, int pLanguageID)
        {
            ResponseDeclaration responseDeclaration = new ResponseDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseDeclaration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclarationID", pResponseDeclarationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(0));
                        responseDeclaration.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseDeclaration.ResponseDeclarationXML = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseDeclaration;
        }

        public ResponseDeclaration[] List(int pLanguageID)
        {
            List<ResponseDeclaration> responseDeclarations = new List<ResponseDeclaration>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseDeclaration_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ResponseDeclaration responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(0));
                        responseDeclaration.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseDeclaration.ResponseDeclarationXML = sqlDataReader.GetString(2);
                        responseDeclarations.Add(responseDeclaration);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ResponseDeclaration responseDeclaration = new ResponseDeclaration();
                    responseDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseDeclarations.Add(responseDeclaration);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseDeclarations.ToArray();
        }

        public ResponseDeclaration Insert(ResponseDeclaration pResponseDeclaration)
        {
            ResponseDeclaration responseDeclaration = new ResponseDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseDeclaration_Insert]");
                try
                {
                    pResponseDeclaration.Detail = base.InsertTranslation(pResponseDeclaration.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pResponseDeclaration.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclaration", pResponseDeclaration.ResponseDeclarationXML));
                    SqlParameter responseDeclarationID = sqlCommand.Parameters.Add("@ResponseDeclarationID", SqlDbType.Int);
                    responseDeclarationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseDeclaration = new ResponseDeclaration((Int32)responseDeclarationID.Value);
                    responseDeclaration.Detail = new Translation(pResponseDeclaration.Detail.TranslationID);
                    responseDeclaration.Detail.Alias = pResponseDeclaration.Detail.Alias;
                    responseDeclaration.Detail.Description = pResponseDeclaration.Detail.Description;
                    responseDeclaration.Detail.Name = pResponseDeclaration.Detail.Name;
                    responseDeclaration.ResponseDeclarationXML = pResponseDeclaration.ResponseDeclarationXML;
                }
                catch (Exception exc)
                {
                    responseDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseDeclaration;
        }

        public ResponseDeclaration Update(ResponseDeclaration pResponseDeclaration)
        {
            ResponseDeclaration responseDeclaration = new ResponseDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseDeclaration_Update]");
                try
                {
                    pResponseDeclaration.Detail = base.UpdateTranslation(pResponseDeclaration.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclarationID", pResponseDeclaration.ResponseDeclarationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclaration", pResponseDeclaration.ResponseDeclarationXML));

                    sqlCommand.ExecuteNonQuery();

                    responseDeclaration = new ResponseDeclaration(pResponseDeclaration.ResponseDeclarationID);
                    responseDeclaration.Detail = new Translation(pResponseDeclaration.Detail.TranslationID);
                    responseDeclaration.Detail.Alias = pResponseDeclaration.Detail.Alias;
                    responseDeclaration.Detail.Description = pResponseDeclaration.Detail.Description;
                    responseDeclaration.Detail.Name = pResponseDeclaration.Detail.Name;
                    responseDeclaration.ResponseDeclarationXML = pResponseDeclaration.ResponseDeclarationXML;
                }
                catch (Exception exc)
                {
                    responseDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseDeclaration;
        }

        public ResponseDeclaration Delete(ResponseDeclaration pResponseDeclaration)
        {
            ResponseDeclaration responseDeclaration = new ResponseDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseDeclaration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclarationID", pResponseDeclaration.ResponseDeclarationID));

                    sqlCommand.ExecuteNonQuery();

                    responseDeclaration = new ResponseDeclaration(pResponseDeclaration.ResponseDeclarationID);
                    base.DeleteAllTranslations(pResponseDeclaration.Detail);
                }
                catch (Exception exc)
                {
                    responseDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseDeclaration;
        }
    }
}
