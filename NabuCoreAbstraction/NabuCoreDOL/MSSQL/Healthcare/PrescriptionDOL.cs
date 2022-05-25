using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class PrescriptionDOL : BaseDOL
    {
        public PrescriptionDOL() : base ()
        {
        }

        public PrescriptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Prescription Get(int? pPrescriptionID)
        {
            Prescription prescription = new Prescription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Prescription_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        prescription = new Prescription(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            prescription.Physician = sqlDataReader.GetString(1);
                        if(sqlDataReader.IsDBNull(2)==false)
                            prescription.Started = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            prescription.Ended = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    prescription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescription;
        }

        public Prescription[] List(int pPartyID)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Prescription_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Prescription prescription = new Prescription(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            prescription.Physician = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            prescription.Started = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            prescription.Ended = sqlDataReader.GetDateTime(3); prescriptions.Add(prescription);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Prescription prescription = new Prescription();
                    prescription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    prescriptions.Add(prescription);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescriptions.ToArray();
        }

        public Prescription Insert(Prescription pPrescription, int pPartyID)
        {
            Prescription prescription = new Prescription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Prescription_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Physician", pPrescription.Physician));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pPrescription.Started));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pPrescription.Ended));
                    SqlParameter prescriptionID = sqlCommand.Parameters.Add("@PrescriptionID", SqlDbType.Int);
                    prescriptionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    prescription = new Prescription((Int32)prescriptionID.Value);
                    prescription.Ended = pPrescription.Ended;
                    prescription.Physician = pPrescription.Physician;
                    prescription.Started = pPrescription.Started;
                }
                catch (Exception exc)
                {
                    prescription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescription;
        }

        public Prescription Update(Prescription pPrescription, int pPartyID)
        {
            Prescription prescription = new Prescription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Prescription_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescription.PrescriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Physician", pPrescription.Physician));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pPrescription.Started));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pPrescription.Ended));

                    sqlCommand.ExecuteNonQuery();

                    prescription = new Prescription(pPrescription.PrescriptionID);
                    prescription.Ended = pPrescription.Ended;
                    prescription.Physician = pPrescription.Physician;
                    prescription.Started = pPrescription.Started;
                }
                catch (Exception exc)
                {
                    prescription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescription;
        }

        public Prescription Delete(Prescription pPrescription)
        {
            Prescription prescription = new Prescription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Prescription_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescription.PrescriptionID));

                    sqlCommand.ExecuteNonQuery();

                    prescription = new Prescription(pPrescription.PrescriptionID);
                }
                catch (Exception exc)
                {
                    prescription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescription;
        }
    }
}
