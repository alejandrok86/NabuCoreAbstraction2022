using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ResponseOutcomeDOL : BaseDOL
    {
        public ResponseOutcomeDOL() : base()
        {
        }

        public ResponseOutcomeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ResponseOutcome Get(int pResponseOutcomeID)
        {
            ResponseOutcome responseOutcome = new ResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseOutcomeID", pResponseOutcomeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseOutcome = new ResponseOutcome(sqlDataReader.GetInt32(0));
                        responseOutcome.InstrumentOutcome = new Entities.Core.InstrumentOutcome(sqlDataReader.GetInt32(1));
                        responseOutcome.NumericalOutcome = sqlDataReader.GetDouble(2);
                        responseOutcome.TextualOutcome = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseOutcome;
        }

        public ResponseOutcome[] List(int pResponseID)
        {
            List<ResponseOutcome> responseOutcomes = new List<ResponseOutcome>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ResponseOutcome responseOutcome = new ResponseOutcome(sqlDataReader.GetInt32(0));
                        responseOutcome.InstrumentOutcome = new Entities.Core.InstrumentOutcome(sqlDataReader.GetInt32(1));
                        responseOutcome.NumericalOutcome = sqlDataReader.GetDouble(2);
                        responseOutcome.TextualOutcome = sqlDataReader.GetString(3);

                        responseOutcomes.Add(responseOutcome);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ResponseOutcome responseOutcome = new ResponseOutcome();
                    responseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseOutcomes.Add(responseOutcome);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseOutcomes.ToArray();
        }

        public ResponseOutcome Insert(ResponseOutcome pResponseOutcome, int pResponseID)
        {
            ResponseOutcome responseOutcome = new ResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentOutcomeID", pResponseOutcome.InstrumentOutcome.InstrumentOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NumericalOutcome", pResponseOutcome.NumericalOutcome));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextualOutcome", pResponseOutcome.TextualOutcome));
                    SqlParameter responseOutcomeID = sqlCommand.Parameters.Add("@ResponseOutcomeID", SqlDbType.Int);
                    responseOutcomeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseOutcome = new ResponseOutcome((Int32)responseOutcomeID.Value);
                    responseOutcome.InstrumentOutcome = new Entities.Core.InstrumentOutcome(pResponseOutcome.InstrumentOutcome.InstrumentOutcomeID);
                    responseOutcome.NumericalOutcome = pResponseOutcome.NumericalOutcome;
                    responseOutcome.TextualOutcome = pResponseOutcome.TextualOutcome;
                }
                catch (Exception exc)
                {
                    responseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseOutcome;
        }

        public ResponseOutcome Update(ResponseOutcome pResponseOutcome, int pResponseID)
        {
            ResponseOutcome responseOutcome = new ResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseOutcomeID", pResponseOutcome.ResponseOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentOutcomeID", pResponseOutcome.InstrumentOutcome.InstrumentOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NumericalOutcome", pResponseOutcome.NumericalOutcome));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextualOutcome", pResponseOutcome.TextualOutcome));

                    sqlCommand.ExecuteNonQuery();

                    responseOutcome = new ResponseOutcome(pResponseOutcome.ResponseOutcomeID);
                    responseOutcome.InstrumentOutcome = new Entities.Core.InstrumentOutcome(pResponseOutcome.InstrumentOutcome.InstrumentOutcomeID);
                    responseOutcome.NumericalOutcome = pResponseOutcome.NumericalOutcome;
                    responseOutcome.TextualOutcome = pResponseOutcome.TextualOutcome;
                }
                catch (Exception exc)
                {
                    responseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseOutcome;
        }

        public ResponseOutcome Delete(ResponseOutcome pResponseOutcome)
        {
            ResponseOutcome responseOutcome = new ResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseOutcomeID", pResponseOutcome.ResponseOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    responseOutcome = new ResponseOutcome(pResponseOutcome.ResponseOutcomeID);
                }
                catch (Exception exc)
                {
                    responseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseOutcome;
        }

        public BaseType DeleteForResponse(int pResponseID)
        {
            BaseType result = new BaseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseOutcome_DeleteForResponse]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    sqlCommand.ExecuteNonQuery();
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
    }
}




