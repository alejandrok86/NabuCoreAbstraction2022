using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class ConditionDOL : BaseDOL
    {
        public ConditionDOL() : base ()
        {
        }

        public ConditionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Condition Get(int pConditionID, int pLanguageID)
        {
            Condition condition = new Condition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Condition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ConditionID", pConditionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        condition = new Condition(sqlDataReader.GetInt32(0));
                        condition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    condition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    condition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return condition;
        }

        public Condition[] List(int pLanguageID)
        {
            List<Condition> conditions = new List<Condition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Condition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Condition condition = new Condition(sqlDataReader.GetInt32(0));
                        condition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        conditions.Add(condition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Condition condition = new Condition();
                    condition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    condition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    conditions.Add(condition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return conditions.ToArray();
        }

        public Condition Insert(Condition pCondition)
        {
            Condition condition = new Condition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Condition_Insert]");
                try
                {
                    pCondition.Detail = base.InsertTranslation(pCondition.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCondition.Detail.TranslationID));
                    SqlParameter conditionID = sqlCommand.Parameters.Add("@ConditionID", SqlDbType.Int);
                    conditionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    condition = new Condition((Int32)conditionID.Value);
                    condition.Detail = new Translation(pCondition.Detail.TranslationID);
                    condition.Detail.Alias = pCondition.Detail.Alias;
                    condition.Detail.Description = pCondition.Detail.Description;
                    condition.Detail.Name = pCondition.Detail.Name;
                }
                catch (Exception exc)
                {
                    condition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    condition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return condition;
        }

        public Condition Update(Condition pCondition)
        {
            Condition condition = new Condition();

            pCondition.Detail = base.UpdateTranslation(pCondition.Detail);

            condition = new Condition(pCondition.ConditionID);
            condition.Detail = new Translation(pCondition.Detail.TranslationID);
            condition.Detail.Alias = pCondition.Detail.Alias;
            condition.Detail.Description = pCondition.Detail.Description;
            condition.Detail.Name = pCondition.Detail.Name;

            return condition;
        }

        public Condition Delete(Condition pCondition)
        {
            Condition condition = new Condition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Condition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ConditionID", pCondition.ConditionID));

                    sqlCommand.ExecuteNonQuery();

                    condition = new Condition(pCondition.ConditionID);
                    base.DeleteAllTranslations(pCondition.Detail);
                }
                catch (Exception exc)
                {
                    condition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    condition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return condition;
        }
    }
}
