using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class RequirementStatusDOL : BaseDOL
    {
        public RequirementStatusDOL() : base()
        {
        }

        public RequirementStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus Get(int pRequirementStatusID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementStatusID", pRequirementStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus(sqlDataReader.GetInt32(0));
                        requirementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus(sqlDataReader.GetInt32(0));
                        requirementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus> requirementStatuss = new List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus(sqlDataReader.GetInt32(0));
                        requirementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        requirementStatuss.Add(requirementStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();
                    requirementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirementStatuss.Add(requirementStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementStatuss.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus Insert(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus pRequirementStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementStatus_Insert]");
                try
                {
                    pRequirementStatus.Detail = base.InsertTranslation(pRequirementStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRequirementStatus.Detail.TranslationID));
                    SqlParameter requirementStatusID = sqlCommand.Parameters.Add("@RequirementStatusID", SqlDbType.Int);
                    requirementStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus((Int32)requirementStatusID.Value);
                    requirementStatus.Detail = new Translation(pRequirementStatus.Detail.TranslationID);
                    requirementStatus.Detail.Alias = pRequirementStatus.Detail.Alias;
                    requirementStatus.Detail.Description = pRequirementStatus.Detail.Description;
                    requirementStatus.Detail.Name = pRequirementStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    requirementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus Update(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus pRequirementStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();

            pRequirementStatus.Detail = base.UpdateTranslation(pRequirementStatus.Detail);

            requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus(pRequirementStatus.RequirementStatusID);
            requirementStatus.Detail = new Translation(pRequirementStatus.Detail.TranslationID);
            requirementStatus.Detail.Alias = pRequirementStatus.Detail.Alias;
            requirementStatus.Detail.Description = pRequirementStatus.Detail.Description;
            requirementStatus.Detail.Name = pRequirementStatus.Detail.Name;

            return requirementStatus;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus Delete(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus pRequirementStatus)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementStatusID", pRequirementStatus.RequirementStatusID));

                    sqlCommand.ExecuteNonQuery();

                    requirementStatus = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementStatus(pRequirementStatus.RequirementStatusID);
                    base.DeleteAllTranslations(pRequirementStatus.Detail);
                }
                catch (Exception exc)
                {
                    requirementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementStatus;
        }
    }
}

