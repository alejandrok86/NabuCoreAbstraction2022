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
    public class FeedbackDeclarationDOL : BaseDOL
    {
        public FeedbackDeclarationDOL() : base ()
        {
        }

        public FeedbackDeclarationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public FeedbackDeclaration Get(int pFeedbackDeclarationID)
        {
            FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[FeedbackDeclaration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclarationID", pFeedbackDeclarationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(0));
                        feedbackDeclaration.FeedbackDeclarationXML = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    feedbackDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    feedbackDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return feedbackDeclaration;
        }

        public FeedbackDeclaration[] List()
        {
            List<FeedbackDeclaration> feedbackDeclarations = new List<FeedbackDeclaration>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[FeedbackDeclaration_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(0));
                        feedbackDeclaration.FeedbackDeclarationXML = sqlDataReader.GetString(1);
                        feedbackDeclarations.Add(feedbackDeclaration);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration();
                    feedbackDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    feedbackDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    feedbackDeclarations.Add(feedbackDeclaration);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return feedbackDeclarations.ToArray();
        }

        public FeedbackDeclaration Insert(FeedbackDeclaration pFeedbackDeclaration)
        {
            FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[FeedbackDeclaration_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclaration", pFeedbackDeclaration.FeedbackDeclarationXML));
                    SqlParameter feedbackDeclarationID = sqlCommand.Parameters.Add("@FeedbackDeclarationID", SqlDbType.Int);
                    feedbackDeclarationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    feedbackDeclaration = new FeedbackDeclaration((Int32)feedbackDeclarationID.Value);
                    feedbackDeclaration.FeedbackDeclarationXML = pFeedbackDeclaration.FeedbackDeclarationXML;
                }
                catch (Exception exc)
                {
                    feedbackDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    feedbackDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return feedbackDeclaration;
        }

        public FeedbackDeclaration Update(FeedbackDeclaration pFeedbackDeclaration)
        {
            FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[FeedbackDeclaration_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclarationID", pFeedbackDeclaration.FeedbackDeclarationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclaration", pFeedbackDeclaration.FeedbackDeclarationXML));

                    sqlCommand.ExecuteNonQuery();

                    feedbackDeclaration = new FeedbackDeclaration(pFeedbackDeclaration.FeedbackDeclarationID);
                    feedbackDeclaration.FeedbackDeclarationXML = pFeedbackDeclaration.FeedbackDeclarationXML;
                }
                catch (Exception exc)
                {
                    feedbackDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    feedbackDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return feedbackDeclaration;
        }

        public FeedbackDeclaration Delete(FeedbackDeclaration pFeedbackDeclaration)
        {
            FeedbackDeclaration feedbackDeclaration = new FeedbackDeclaration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[FeedbackDeclaration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclarationID", pFeedbackDeclaration.FeedbackDeclarationID));

                    sqlCommand.ExecuteNonQuery();

                    feedbackDeclaration = new FeedbackDeclaration(pFeedbackDeclaration.FeedbackDeclarationID);
                }
                catch (Exception exc)
                {
                    feedbackDeclaration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    feedbackDeclaration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return feedbackDeclaration;
        }
    }
}
