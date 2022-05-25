using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ChangePriorityDOL : BaseDOL
    {
        public ChangePriorityDOL() : base()
        {
        }

        public ChangePriorityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority Get(int pChangePriorityID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangePriority_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangePriorityID", pChangePriorityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(0));
                        changePriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changePriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changePriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changePriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangePriority_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(0));
                        changePriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    changePriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changePriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changePriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority> changePrioritys = new List<Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangePriority_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(0));
                        changePriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        changePrioritys.Add(changePriority);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();
                    changePriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changePriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    changePrioritys.Add(changePriority);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changePrioritys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority Insert(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority pChangePriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangePriority_Insert]");
                try
                {
                    pChangePriority.Detail = base.InsertTranslation(pChangePriority.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pChangePriority.Detail.TranslationID));
                    SqlParameter changePriorityID = sqlCommand.Parameters.Add("@ChangePriorityID", SqlDbType.Int);
                    changePriorityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority((Int32)changePriorityID.Value);
                    changePriority.Detail = new Translation(pChangePriority.Detail.TranslationID);
                    changePriority.Detail.Alias = pChangePriority.Detail.Alias;
                    changePriority.Detail.Description = pChangePriority.Detail.Description;
                    changePriority.Detail.Name = pChangePriority.Detail.Name;
                }
                catch (Exception exc)
                {
                    changePriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changePriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changePriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority Update(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority pChangePriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();

            pChangePriority.Detail = base.UpdateTranslation(pChangePriority.Detail);

            changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority(pChangePriority.ChangePriorityID);
            changePriority.Detail = new Translation(pChangePriority.Detail.TranslationID);
            changePriority.Detail.Alias = pChangePriority.Detail.Alias;
            changePriority.Detail.Description = pChangePriority.Detail.Description;
            changePriority.Detail.Name = pChangePriority.Detail.Name;

            return changePriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority Delete(Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority pChangePriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangePriority_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangePriorityID", pChangePriority.ChangePriorityID));

                    sqlCommand.ExecuteNonQuery();

                    changePriority = new Octavo.Gate.Nabu.CORE.Entities.ServiceManagement.ChangePriority(pChangePriority.ChangePriorityID);
                    base.DeleteAllTranslations(pChangePriority.Detail);
                }
                catch (Exception exc)
                {
                    changePriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    changePriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changePriority;
        }
    }
}

