using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class DeliverableTypeDOL : BaseDOL
    {
        public DeliverableTypeDOL() : base()
        {
        }

        public DeliverableTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public DeliverableType Get(int pDeliverableTypeID, int pLanguageID)
        {
            DeliverableType deliverableType = new DeliverableType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DeliverableType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableTypeID", pDeliverableTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        deliverableType = new DeliverableType(sqlDataReader.GetInt32(0));
                        deliverableType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    deliverableType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverableType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverableType;
        }

        public DeliverableType GetByAlias(string pAlias, int pLanguageID)
        {
            DeliverableType deliverableType = new DeliverableType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DeliverableType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        deliverableType = new DeliverableType(sqlDataReader.GetInt32(0));
                        deliverableType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    deliverableType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverableType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverableType;
        }

        public DeliverableType[] List(int pLanguageID)
        {
            List<DeliverableType> deliverableTypes = new List<DeliverableType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DeliverableType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DeliverableType deliverableType = new DeliverableType(sqlDataReader.GetInt32(0));
                        deliverableType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        deliverableTypes.Add(deliverableType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DeliverableType deliverableType = new DeliverableType();
                    deliverableType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverableType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    deliverableTypes.Add(deliverableType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverableTypes.ToArray();
        }

        public DeliverableType Insert(DeliverableType pDeliverableType)
        {
            DeliverableType deliverableType = new DeliverableType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DeliverableType_Insert]");
                try
                {
                    pDeliverableType.Detail = base.InsertTranslation(pDeliverableType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDeliverableType.Detail.TranslationID));
                    SqlParameter DeliverableTypeID = sqlCommand.Parameters.Add("@DeliverableTypeID", SqlDbType.Int);
                    DeliverableTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    deliverableType = new DeliverableType((Int32)DeliverableTypeID.Value);
                    deliverableType.Detail = new Translation(pDeliverableType.Detail.TranslationID);
                    deliverableType.Detail.Alias = pDeliverableType.Detail.Alias;
                    deliverableType.Detail.Description = pDeliverableType.Detail.Description;
                    deliverableType.Detail.Name = pDeliverableType.Detail.Name;
                }
                catch (Exception exc)
                {
                    deliverableType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverableType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverableType;
        }

        public DeliverableType Update(DeliverableType pDeliverableType)
        {
            DeliverableType deliverableType = new DeliverableType();

            pDeliverableType.Detail = base.UpdateTranslation(pDeliverableType.Detail);

            deliverableType = new DeliverableType(pDeliverableType.DeliverableTypeID);
            deliverableType.Detail = new Translation(pDeliverableType.Detail.TranslationID);
            deliverableType.Detail.Alias = pDeliverableType.Detail.Alias;
            deliverableType.Detail.Description = pDeliverableType.Detail.Description;
            deliverableType.Detail.Name = pDeliverableType.Detail.Name;

            return deliverableType;
        }

        public DeliverableType Delete(DeliverableType pDeliverableType)
        {
            DeliverableType deliverableType = new DeliverableType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DeliverableType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DeliverableTypeID", pDeliverableType.DeliverableTypeID));

                    sqlCommand.ExecuteNonQuery();

                    deliverableType = new DeliverableType(pDeliverableType.DeliverableTypeID);
                    base.DeleteAllTranslations(pDeliverableType.Detail);
                }
                catch (Exception exc)
                {
                    deliverableType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    deliverableType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return deliverableType;
        }
    }
}
