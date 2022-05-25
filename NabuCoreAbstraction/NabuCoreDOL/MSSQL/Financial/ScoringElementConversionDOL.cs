using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ScoringElementConversionDOL : BaseDOL
    {
        public ScoringElementConversionDOL() : base()
        {
        }

        public ScoringElementConversionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ScoringElementConversion Get(int pScoringElementConversionID)
        {
            ScoringElementConversion scoringElementConversion = new ScoringElementConversion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementConversion_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementConversionID", pScoringElementConversionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scoringElementConversion = new ScoringElementConversion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            scoringElementConversion.FromValue = sqlDataReader.GetDecimal(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            scoringElementConversion.ToValue = sqlDataReader.GetDecimal(2);
                        scoringElementConversion.Points = sqlDataReader.GetDecimal(3);
                        scoringElementConversion.Flag = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scoringElementConversion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementConversion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementConversion;
        }

        public ScoringElementConversion[] List(int pScoringElementID)
        {
            List<ScoringElementConversion> scoringElementConversions = new List<ScoringElementConversion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementConversion_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ScoringElementConversion scoringElementConversion = new ScoringElementConversion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            scoringElementConversion.FromValue = sqlDataReader.GetDecimal(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            scoringElementConversion.ToValue = sqlDataReader.GetDecimal(2);
                        scoringElementConversion.Points = sqlDataReader.GetDecimal(3);
                        scoringElementConversion.Flag = sqlDataReader.GetInt32(4);

                        scoringElementConversions.Add(scoringElementConversion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ScoringElementConversion scoringElementConversion = new ScoringElementConversion();
                    scoringElementConversion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementConversion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    scoringElementConversions.Add(scoringElementConversion);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementConversions.ToArray();
        }

        public ScoringElementConversion Insert(ScoringElementConversion pScoringElementConversion, int pScoringElementID)
        {
            ScoringElementConversion scoringElementConversion = new ScoringElementConversion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementConversion_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromValue", pScoringElementConversion.FromValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToValue", pScoringElementConversion.ToValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@Points", pScoringElementConversion.Points));
                    sqlCommand.Parameters.Add(new SqlParameter("@Flag", pScoringElementConversion.Flag));
                    SqlParameter scoringElementConversionID = sqlCommand.Parameters.Add("@InstitutionScoringElementConversionID", SqlDbType.Int);
                    scoringElementConversionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    scoringElementConversion = new ScoringElementConversion((Int32)scoringElementConversionID.Value);
                    scoringElementConversion.FromValue = pScoringElementConversion.FromValue;
                    scoringElementConversion.ToValue = pScoringElementConversion.ToValue;
                    scoringElementConversion.Points = pScoringElementConversion.Points;
                    scoringElementConversion.Flag = pScoringElementConversion.Flag;
                }
                catch (Exception exc)
                {
                    scoringElementConversion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementConversion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementConversion;
        }

        public ScoringElementConversion Update(ScoringElementConversion pScoringElementConversion)
        {
            ScoringElementConversion scoringElementConversion = new ScoringElementConversion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementConversion_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementConversionID", pScoringElementConversion.ElementConversionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromValue", pScoringElementConversion.FromValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToValue", pScoringElementConversion.ToValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@Points", pScoringElementConversion.Points));
                    sqlCommand.Parameters.Add(new SqlParameter("@Flag", pScoringElementConversion.Flag));

                    sqlCommand.ExecuteNonQuery();

                    scoringElementConversion = new ScoringElementConversion(pScoringElementConversion.ElementConversionID);
                    scoringElementConversion.FromValue = pScoringElementConversion.FromValue;
                    scoringElementConversion.ToValue = pScoringElementConversion.ToValue;
                    scoringElementConversion.Points = pScoringElementConversion.Points;
                    scoringElementConversion.Flag = pScoringElementConversion.Flag;
                }
                catch (Exception exc)
                {
                    scoringElementConversion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementConversion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementConversion;
        }

        public ScoringElementConversion Delete(ScoringElementConversion pScoringElementConversion)
        {
            ScoringElementConversion scoringElementConversion = new ScoringElementConversion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementConversion_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementConversionID", pScoringElementConversion.ElementConversionID));

                    sqlCommand.ExecuteNonQuery();

                    scoringElementConversion = new ScoringElementConversion(pScoringElementConversion.ElementConversionID);
                }
                catch (Exception exc)
                {
                    scoringElementConversion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementConversion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementConversion;
        }
    }
}
