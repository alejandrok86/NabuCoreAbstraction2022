using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class ContainerDOL : BaseDOL
    {
        public ContainerDOL() : base ()
        {
        }

        public ContainerDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Container Get(int pContainerID, int pLanguageID)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        Container = new Container(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            Container.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            Container.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            Container.ContainerType = new ContainerType(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            Container.ContainerStatus = new ContainerStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            Container.ParentContainerID = sqlDataReader.GetInt32(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container GetByTrackingCode(string pTrackingCode, int pLanguageID)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_GetByTrackingCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pTrackingCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        Container = new Container(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            Container.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            Container.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            Container.ContainerType = new ContainerType(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            Container.ContainerStatus = new ContainerStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            Container.ParentContainerID = sqlDataReader.GetInt32(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container[] List(int pLocationID, int pLanguageID)
        {
            List<Container> Containers = new List<Container>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Container Container = new Container(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            Container.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            Container.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            Container.ContainerType = new ContainerType(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            Container.ContainerStatus = new ContainerStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            Container.ParentContainerID = sqlDataReader.GetInt32(5);
                        Containers.Add(Container);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Container Container = new Container();
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    Containers.Add(Container);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Containers.ToArray();
        }

        public Container[] ListChildren(int pContainerID, int pLanguageID)
        {
            List<Container> Containers = new List<Container>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Container Container = new Container(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            Container.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            Container.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            Container.ContainerType = new ContainerType(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            Container.ContainerStatus = new ContainerStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            Container.ParentContainerID = sqlDataReader.GetInt32(5);
                        Containers.Add(Container);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Container Container = new Container();
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    Containers.Add(Container);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Containers.ToArray();
        }

        public Container Insert(Container pContainer)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_Insert]");
                try
                {
                    if(pContainer.Detail != null)
                        pContainer.Detail = base.InsertTranslation(pContainer.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", ((pContainer.Detail != null && pContainer.Detail.TranslationID.HasValue) ? pContainer.Detail.TranslationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", ((pContainer.TrackingCode != null && pContainer.TrackingCode.TrackingCodeID.HasValue) ? pContainer.TrackingCode.TrackingCodeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerTypeID", pContainer.ContainerType.ContainerTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerStatusID", pContainer.ContainerStatus.ContainerStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContainerID", ((pContainer.ParentContainerID.HasValue) ? pContainer.ParentContainerID : null)));
                    SqlParameter ContainerID = sqlCommand.Parameters.Add("@ContainerID", SqlDbType.Int);
                    ContainerID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    Container = new Container((Int32)ContainerID.Value);
                    if (pContainer.TrackingCode != null)
                        Container.TrackingCode = pContainer.TrackingCode;
                    Container.ContainerType = pContainer.ContainerType;
                    Container.ContainerStatus = pContainer.ContainerStatus;
                    if (pContainer.ParentContainerID.HasValue)
                        Container.ParentContainerID = pContainer.ParentContainerID;
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container Update(Container pContainer)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_Update]");
                try
                {
                    if (pContainer.Detail != null)
                        pContainer.Detail = base.UpdateTranslation(pContainer.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainer.ContainerID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", ((pContainer.TrackingCode != null && pContainer.TrackingCode.TrackingCodeID.HasValue) ? pContainer.TrackingCode.TrackingCodeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerTypeID", pContainer.ContainerType.ContainerTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerStatusID", pContainer.ContainerStatus.ContainerStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContainerID", ((pContainer.ParentContainerID.HasValue) ? pContainer.ParentContainerID : null)));

                    sqlCommand.ExecuteNonQuery();

                    Container = new Container(pContainer.ContainerID);
                    if (pContainer.TrackingCode != null)
                        Container.TrackingCode = pContainer.TrackingCode;
                    Container.ContainerType = pContainer.ContainerType;
                    Container.ContainerStatus = pContainer.ContainerStatus;
                    if (pContainer.ParentContainerID.HasValue)
                        Container.ParentContainerID = pContainer.ParentContainerID;
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container Delete(Container pContainer)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_Delete]");
                try
                {
                    if (pContainer.Detail != null)
                        pContainer.Detail = base.DeleteTranslation(pContainer.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainer.ContainerID));

                    sqlCommand.ExecuteNonQuery();

                    Container = new Container(pContainer.ContainerID);
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container AssignToLocation(int pContainerID, int pLocationID)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_AssignToLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainerID));

                    sqlCommand.ExecuteNonQuery();

                    Container = new Container(pContainerID);
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }

        public Container RemoveFromLocation(int pContainerID, int pLocationID)
        {
            Container Container = new Container();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_RemoveFromLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainerID));

                    sqlCommand.ExecuteNonQuery();

                    Container = new Container(pContainerID);
                }
                catch (Exception exc)
                {
                    Container.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Container.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Container;
        }
    }
}
