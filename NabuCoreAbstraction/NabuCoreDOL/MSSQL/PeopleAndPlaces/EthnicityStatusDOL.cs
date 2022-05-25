using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces
{
    public class EthnicityStatusDOL : BaseDOL
    {
        public EthnicityStatusDOL() : base()
        {
        }

        public EthnicityStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EthnicityStatus Get(int pEthnicityStatusID, int pLanguageID)
        {
            EthnicityStatus ethnicityStatus = new EthnicityStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EthnicityStatusID", pEthnicityStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ethnicityStatus = new EthnicityStatus(sqlDataReader.GetInt32(0));
                        ethnicityStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ethnicityStatus.ProportionPercentage = sqlDataReader.GetFloat(2);
                        ethnicityStatus.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatus;
        }

        public EthnicityStatus[] List(int pPersonID, int pLanguageID)
        {
            List<EthnicityStatus> ethnicityStatuss = new List<EthnicityStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_ListForPerson]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EthnicityStatus ethnicityStatus = new EthnicityStatus(sqlDataReader.GetInt32(0));
                        ethnicityStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ethnicityStatus.ProportionPercentage = sqlDataReader.GetFloat(2);
                        ethnicityStatus.FromDate = sqlDataReader.GetDateTime(3);

                        ethnicityStatuss.Add(ethnicityStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EthnicityStatus ethnicityStatus = new EthnicityStatus();
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ethnicityStatuss.Add(ethnicityStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatuss.ToArray();
        }

        public EthnicityStatus[] List(int pLanguageID)
        {
            List<EthnicityStatus> ethnicityStatuss = new List<EthnicityStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EthnicityStatus ethnicityStatus = new EthnicityStatus(sqlDataReader.GetInt32(0));
                        ethnicityStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ethnicityStatus.ProportionPercentage = sqlDataReader.GetFloat(2);
                        ethnicityStatus.FromDate = sqlDataReader.GetDateTime(3);

                        ethnicityStatuss.Add(ethnicityStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EthnicityStatus ethnicityStatus = new EthnicityStatus();
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ethnicityStatuss.Add(ethnicityStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatuss.ToArray();
        }

        public EthnicityStatus Insert(EthnicityStatus pEthnicityStatus, int pPersonID)
        {
            EthnicityStatus ethnicityStatus = new EthnicityStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProportionPercentage", pEthnicityStatus.ProportionPercentage));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pEthnicityStatus.FromDate));
                    SqlParameter ethnicityStatusID = sqlCommand.Parameters.Add("@EthnicityStatusID", SqlDbType.Int);
                    ethnicityStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    ethnicityStatus = new EthnicityStatus((Int32)ethnicityStatusID.Value);
                    ethnicityStatus.Detail = new Translation(pEthnicityStatus.Detail.TranslationID);
                    ethnicityStatus.FromDate = pEthnicityStatus.FromDate;
                    ethnicityStatus.ProportionPercentage = pEthnicityStatus.ProportionPercentage;
                }
                catch (Exception exc)
                {
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatus;
        }

        public EthnicityStatus Update(EthnicityStatus pEthnicityStatus)
        {
            EthnicityStatus ethnicityStatus = new EthnicityStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EthnicityStatusID", pEthnicityStatus.EthnicityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProportionPercentage", pEthnicityStatus.ProportionPercentage));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pEthnicityStatus.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    ethnicityStatus = new EthnicityStatus(pEthnicityStatus.EthnicityID);
                    ethnicityStatus.Detail = new Translation(pEthnicityStatus.Detail.TranslationID);
                    ethnicityStatus.FromDate = pEthnicityStatus.FromDate;
                    ethnicityStatus.ProportionPercentage = pEthnicityStatus.ProportionPercentage;
                }
                catch (Exception exc)
                {
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatus;
        }

        public EthnicityStatus Delete(EthnicityStatus pEthnicityStatus)
        {
            EthnicityStatus ethnicityStatus = new EthnicityStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[EthnicityStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EthnicityStatusID", pEthnicityStatus.EthnicityID));

                    sqlCommand.ExecuteNonQuery();

                    ethnicityStatus = new EthnicityStatus(pEthnicityStatus.EthnicityID);
                }
                catch (Exception exc)
                {
                    ethnicityStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ethnicityStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ethnicityStatus;
        }
    }
}

