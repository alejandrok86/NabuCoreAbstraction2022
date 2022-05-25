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
    public class TelecommsNumberDOL : BaseDOL
    {
        public TelecommsNumberDOL() : base()
        {
        }

        public TelecommsNumberDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TelecommsNumber Get(int pTelecommsNumberID, int pLanguageID)
        {
            TelecommsNumber telecommsNumber = new TelecommsNumber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TelecommsNumber_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TelecommsNumberID", pTelecommsNumberID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        telecommsNumber = new TelecommsNumber(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            telecommsNumber.FullNumber = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            telecommsNumber.CountryCode = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            telecommsNumber.AreaCode = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            telecommsNumber.ContactNumber = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            telecommsNumber.ExtensionNumber = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            telecommsNumber.IsNumberListed = sqlDataReader.GetBoolean(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    telecommsNumber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    telecommsNumber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return telecommsNumber;
        }

        public TelecommsNumber Insert(TelecommsNumber pTelecommsNumber)
        {
            TelecommsNumber telecommsNumber = new TelecommsNumber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TelecommsNumber_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TelecommsNumberID", pTelecommsNumber.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FullNumber", pTelecommsNumber.FullNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryCode", pTelecommsNumber.CountryCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@AreaCode", pTelecommsNumber.AreaCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactNumber", pTelecommsNumber.ContactNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ExtensionNumber", pTelecommsNumber.ExtensionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsNumberListed", pTelecommsNumber.IsNumberListed));

                    sqlCommand.ExecuteNonQuery();

                    telecommsNumber = new TelecommsNumber(pTelecommsNumber.ContactMechanismID);
                    telecommsNumber.FullNumber = pTelecommsNumber.FullNumber;
                    telecommsNumber.CountryCode = pTelecommsNumber.CountryCode;
                    telecommsNumber.AreaCode = pTelecommsNumber.AreaCode;
                    telecommsNumber.ContactNumber = pTelecommsNumber.ContactNumber;
                    telecommsNumber.ExtensionNumber = pTelecommsNumber.ExtensionNumber;
                    telecommsNumber.IsNumberListed = pTelecommsNumber.IsNumberListed;
                    telecommsNumber.ContactMechanismType = pTelecommsNumber.ContactMechanismType;
                    telecommsNumber.FromDate = pTelecommsNumber.FromDate;
                }
                catch (Exception exc)
                {
                    telecommsNumber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    telecommsNumber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return telecommsNumber;
        }

        public TelecommsNumber Update(TelecommsNumber pTelecommsNumber)
        {
            TelecommsNumber telecommsNumber = new TelecommsNumber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TelecommsNumber_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TelecommsNumberID", pTelecommsNumber.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FullNumber", pTelecommsNumber.FullNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryCode", pTelecommsNumber.CountryCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@AreaCode", pTelecommsNumber.AreaCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactNumber", pTelecommsNumber.ContactNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ExtensionNumber", pTelecommsNumber.ExtensionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsNumberListed", pTelecommsNumber.IsNumberListed));

                    sqlCommand.ExecuteNonQuery();

                    telecommsNumber = new TelecommsNumber(pTelecommsNumber.ContactMechanismID);
                    telecommsNumber.FullNumber = pTelecommsNumber.FullNumber;
                    telecommsNumber.CountryCode = pTelecommsNumber.CountryCode;
                    telecommsNumber.AreaCode = pTelecommsNumber.AreaCode;
                    telecommsNumber.ContactNumber = pTelecommsNumber.ContactNumber;
                    telecommsNumber.ExtensionNumber = pTelecommsNumber.ExtensionNumber;
                    telecommsNumber.IsNumberListed = pTelecommsNumber.IsNumberListed;
                    telecommsNumber.ContactMechanismType = pTelecommsNumber.ContactMechanismType;
                    telecommsNumber.FromDate = pTelecommsNumber.FromDate;
                }
                catch (Exception exc)
                {
                    telecommsNumber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    telecommsNumber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return telecommsNumber;
        }

        public TelecommsNumber Delete(TelecommsNumber pTelecommsNumber)
        {
            TelecommsNumber telecommsNumber = new TelecommsNumber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[TelecommsNumber_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TelecommsNumberID", pTelecommsNumber.ContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    telecommsNumber = new TelecommsNumber(pTelecommsNumber.ContactMechanismID);
                }
                catch (Exception exc)
                {
                    telecommsNumber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    telecommsNumber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return telecommsNumber;
        }
    }
}

