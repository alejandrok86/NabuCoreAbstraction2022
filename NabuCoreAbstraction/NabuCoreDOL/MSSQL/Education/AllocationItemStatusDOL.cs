using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AllocationItemStatusDOL : BaseDOL
    {
        public AllocationItemStatusDOL() : base ()
        {
        }

        public AllocationItemStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AllocationItemStatus Get(int pAllocationItemStatusID, int pLanguageID)
        {
            AllocationItemStatus allocationItemStatus = new AllocationItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AllocationItemStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocationItemStatusID", pAllocationItemStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        allocationItemStatus = new AllocationItemStatus(sqlDataReader.GetInt32(0));
                        allocationItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    allocationItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    allocationItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return allocationItemStatus;
        }

        public AllocationItemStatus[] List(int pLanguageID)
        {
            List<AllocationItemStatus> allocationItemStatuss = new List<AllocationItemStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AllocationItemStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AllocationItemStatus allocationItemStatus = new AllocationItemStatus(sqlDataReader.GetInt32(0));
                        allocationItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        allocationItemStatuss.Add(allocationItemStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AllocationItemStatus allocationItemStatus = new AllocationItemStatus();
                    allocationItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    allocationItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    allocationItemStatuss.Add(allocationItemStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return allocationItemStatuss.ToArray();
        }

        public AllocationItemStatus Insert(AllocationItemStatus pAllocationItemStatus)
        {
            AllocationItemStatus allocationItemStatus = new AllocationItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AllocationItemStatus_Insert]");
                try
                {
                    pAllocationItemStatus.Detail = base.InsertTranslation(pAllocationItemStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAllocationItemStatus.Detail.TranslationID));
                    SqlParameter allocationItemStatusID = sqlCommand.Parameters.Add("@AllocationItemStatusID", SqlDbType.Int);
                    allocationItemStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    allocationItemStatus = new AllocationItemStatus((Int32)allocationItemStatusID.Value);
                    allocationItemStatus.Detail = new Translation(pAllocationItemStatus.Detail.TranslationID);
                    allocationItemStatus.Detail.Alias = pAllocationItemStatus.Detail.Alias;
                    allocationItemStatus.Detail.Description = pAllocationItemStatus.Detail.Description;
                    allocationItemStatus.Detail.Name = pAllocationItemStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    allocationItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    allocationItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return allocationItemStatus;
        }

        public AllocationItemStatus Update(AllocationItemStatus pAllocationItemStatus)
        {
            AllocationItemStatus allocationItemStatus = new AllocationItemStatus();

            pAllocationItemStatus.Detail = base.UpdateTranslation(pAllocationItemStatus.Detail);

            allocationItemStatus = new AllocationItemStatus(pAllocationItemStatus.AllocationItemStatusID);
            allocationItemStatus.Detail = new Translation(pAllocationItemStatus.Detail.TranslationID);
            allocationItemStatus.Detail.Alias = pAllocationItemStatus.Detail.Alias;
            allocationItemStatus.Detail.Description = pAllocationItemStatus.Detail.Description;
            allocationItemStatus.Detail.Name = pAllocationItemStatus.Detail.Name;

            return allocationItemStatus;
        }

        public AllocationItemStatus Delete(AllocationItemStatus pAllocationItemStatus)
        {
            AllocationItemStatus allocationItemStatus = new AllocationItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AllocationItemStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocationItemStatusID", pAllocationItemStatus.AllocationItemStatusID));

                    sqlCommand.ExecuteNonQuery();

                    allocationItemStatus = new AllocationItemStatus(pAllocationItemStatus.AllocationItemStatusID);
                    base.DeleteAllTranslations(pAllocationItemStatus.Detail);
                }
                catch (Exception exc)
                {
                    allocationItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    allocationItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return allocationItemStatus;
        }
    }
}
