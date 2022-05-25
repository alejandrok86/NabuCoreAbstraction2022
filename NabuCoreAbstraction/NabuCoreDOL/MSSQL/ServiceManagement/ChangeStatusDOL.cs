using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ChangeStatusDOL : BaseDOL
    {
        public ChangeStatusDOL() : base()
        {
        }

        public ChangeStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus Get(int pChangeStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeStatusID", pChangeStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(0));
                        changeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(0));
                        changeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus> changeStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(0));
                        changeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        changeStatuss.Add(changeStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();
                    changeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    changeStatuss.Add(changeStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus pChangeStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeStatus_Insert]");
                try
                {
                    pChangeStatus.Detail = base.InsertTranslation(pChangeStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pChangeStatus.Detail.TranslationID));
                    SqlParameter changeStatusID = sqlCommand.Parameters.Add("@ChangeStatusID", SqlDbType.Int);
                    changeStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus((Int32)changeStatusID.Value);
                    changeStatus.Detail = new Translation(pChangeStatus.Detail.TranslationID);
                    changeStatus.Detail.Alias = pChangeStatus.Detail.Alias;
                    changeStatus.Detail.Description = pChangeStatus.Detail.Description;
                    changeStatus.Detail.Name = pChangeStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    changeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus pChangeStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();

            pChangeStatus.Detail = base.UpdateTranslation(pChangeStatus.Detail);

            changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus(pChangeStatus.ChangeStatusID);
            changeStatus.Detail = new Translation(pChangeStatus.Detail.TranslationID);
            changeStatus.Detail.Alias = pChangeStatus.Detail.Alias;
            changeStatus.Detail.Description = pChangeStatus.Detail.Description;
            changeStatus.Detail.Name = pChangeStatus.Detail.Name;

            return changeStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus pChangeStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeStatusID", pChangeStatus.ChangeStatusID));

                    sqlCommand.ExecuteNonQuery();

                    changeStatus = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangeStatus(pChangeStatus.ChangeStatusID);
                    base.DeleteAllTranslations(pChangeStatus.Detail);
                }
                catch (Exception exc)
                {
                    changeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changeStatus;
        }
    }
}

