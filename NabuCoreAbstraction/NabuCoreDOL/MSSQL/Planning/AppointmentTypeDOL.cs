using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class AppointmentTypeDOL : BaseDOL
    {
        public AppointmentTypeDOL() : base()
        {
        }

        public AppointmentTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AppointmentType Get(int pAppointmentTypeID, int pLanguageID)
        {
            AppointmentType appointmentType = new AppointmentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[AppointmentType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentTypeID", pAppointmentTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        appointmentType = new AppointmentType(sqlDataReader.GetInt32(0));
                        appointmentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    appointmentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointmentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointmentType;
        }

        public AppointmentType GetByAlias(string pAlias, int pLanguageID)
        {
            AppointmentType appointmentType = new AppointmentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[AppointmentType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        appointmentType = new AppointmentType(sqlDataReader.GetInt32(0));
                        appointmentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    appointmentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointmentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointmentType;
        }

        public AppointmentType[] List(int pLanguageID)
        {
            List<AppointmentType> appointmentTypes = new List<AppointmentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[AppointmentType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AppointmentType appointmentType = new AppointmentType(sqlDataReader.GetInt32(0));
                        appointmentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        appointmentTypes.Add(appointmentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AppointmentType appointmentType = new AppointmentType();
                    appointmentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointmentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    appointmentTypes.Add(appointmentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointmentTypes.ToArray();
        }

        public AppointmentType Insert(AppointmentType pAppointmentType)
        {
            AppointmentType appointmentType = new AppointmentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[AppointmentType_Insert]");
                try
                {
                    pAppointmentType.Detail = base.InsertTranslation(pAppointmentType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAppointmentType.Detail.TranslationID));
                    SqlParameter AppointmentTypeID = sqlCommand.Parameters.Add("@AppointmentTypeID", SqlDbType.Int);
                    AppointmentTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    appointmentType = new AppointmentType((Int32)AppointmentTypeID.Value);
                    appointmentType.Detail = new Translation(pAppointmentType.Detail.TranslationID);
                    appointmentType.Detail.Alias = pAppointmentType.Detail.Alias;
                    appointmentType.Detail.Description = pAppointmentType.Detail.Description;
                    appointmentType.Detail.Name = pAppointmentType.Detail.Name;
                }
                catch (Exception exc)
                {
                    appointmentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointmentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointmentType;
        }

        public AppointmentType Update(AppointmentType pAppointmentType)
        {
            AppointmentType appointmentType = new AppointmentType();

            pAppointmentType.Detail = base.UpdateTranslation(pAppointmentType.Detail);

            appointmentType = new AppointmentType(pAppointmentType.AppointmentTypeID);
            appointmentType.Detail = new Translation(pAppointmentType.Detail.TranslationID);
            appointmentType.Detail.Alias = pAppointmentType.Detail.Alias;
            appointmentType.Detail.Description = pAppointmentType.Detail.Description;
            appointmentType.Detail.Name = pAppointmentType.Detail.Name;

            return appointmentType;
        }

        public AppointmentType Delete(AppointmentType pAppointmentType)
        {
            AppointmentType appointmentType = new AppointmentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[AppointmentType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentTypeID", pAppointmentType.AppointmentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    appointmentType = new AppointmentType(pAppointmentType.AppointmentTypeID);
                    base.DeleteAllTranslations(pAppointmentType.Detail);
                }
                catch (Exception exc)
                {
                    appointmentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointmentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointmentType;
        }
    }
}
