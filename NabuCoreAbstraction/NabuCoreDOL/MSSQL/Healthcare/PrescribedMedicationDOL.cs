using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class PrescribedMedicationDOL : BaseDOL
    {
        public PrescribedMedicationDOL() : base ()
        {
        }

        public PrescribedMedicationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PrescribedMedication Get(int? pMedicationID)
        {
            PrescribedMedication prescribedMedication = new PrescribedMedication();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MedicationID", pMedicationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        prescribedMedication = new PrescribedMedication(sqlDataReader.GetInt32(0));
                        prescribedMedication.Name = sqlDataReader.GetString(1);
                        prescribedMedication.Strength = sqlDataReader.GetDecimal(2);
		                prescribedMedication.DoseDescription = sqlDataReader.GetString(3);
                        prescribedMedication.TotalPrescribedQuantity = sqlDataReader.GetDecimal(4);
                        prescribedMedication.QuantityPerDose = sqlDataReader.GetDecimal(5);
                        prescribedMedication.DailyFrequency = sqlDataReader.GetDecimal(6);
                        prescribedMedication.CalculatedDailyDose = sqlDataReader.GetDecimal(7);
		                prescribedMedication.Instructions = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedication;
        }

        public PrescribedMedication[] List(int pPrescriptionID)
        {
            List<PrescribedMedication> prescribedMedications = new List<PrescribedMedication>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PrescribedMedication prescribedMedication = new PrescribedMedication(sqlDataReader.GetInt32(0));
                        prescribedMedication.Name = sqlDataReader.GetString(1);
                        prescribedMedication.Strength = sqlDataReader.GetDecimal(2);
                        prescribedMedication.DoseDescription = sqlDataReader.GetString(3);
                        prescribedMedication.TotalPrescribedQuantity = sqlDataReader.GetDecimal(4);
                        prescribedMedication.QuantityPerDose = sqlDataReader.GetDecimal(5);
                        prescribedMedication.DailyFrequency = sqlDataReader.GetDecimal(6);
                        prescribedMedication.CalculatedDailyDose = sqlDataReader.GetDecimal(7);
                        prescribedMedication.Instructions = sqlDataReader.GetString(8);
                        prescribedMedications.Add(prescribedMedication);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PrescribedMedication prescribedMedication = new PrescribedMedication();
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    prescribedMedications.Add(prescribedMedication);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedications.ToArray();
        }

        public PrescribedMedication[] ListByPartyID(int pPartyID)
        {
            List<PrescribedMedication> prescribedMedications = new List<PrescribedMedication>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_ListByPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PrescribedMedication prescribedMedication = new PrescribedMedication(sqlDataReader.GetInt32(0));
                        prescribedMedication.Name = sqlDataReader.GetString(1);
                        prescribedMedication.Strength = sqlDataReader.GetDecimal(2);
                        prescribedMedication.DoseDescription = sqlDataReader.GetString(3);
                        prescribedMedication.TotalPrescribedQuantity = sqlDataReader.GetDecimal(4);
                        prescribedMedication.QuantityPerDose = sqlDataReader.GetDecimal(5);
                        prescribedMedication.DailyFrequency = sqlDataReader.GetDecimal(6);
                        prescribedMedication.CalculatedDailyDose = sqlDataReader.GetDecimal(7);
                        prescribedMedication.Instructions = sqlDataReader.GetString(8);
                        prescribedMedications.Add(prescribedMedication);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PrescribedMedication prescribedMedication = new PrescribedMedication();
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    prescribedMedications.Add(prescribedMedication);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedications.ToArray();
        }

        public PrescribedMedication[] ListCurrentByPartyID(int pPartyID, DateTime pDateTimeNow)
        {
            List<PrescribedMedication> prescribedMedications = new List<PrescribedMedication>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_ListCurrentByPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateTimeNow", pDateTimeNow));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PrescribedMedication prescribedMedication = new PrescribedMedication(sqlDataReader.GetInt32(0));
                        prescribedMedication.Name = sqlDataReader.GetString(1);
                        prescribedMedication.Strength = sqlDataReader.GetDecimal(2);
                        prescribedMedication.DoseDescription = sqlDataReader.GetString(3);
                        prescribedMedication.TotalPrescribedQuantity = sqlDataReader.GetDecimal(4);
                        prescribedMedication.QuantityPerDose = sqlDataReader.GetDecimal(5);
                        prescribedMedication.DailyFrequency = sqlDataReader.GetDecimal(6);
                        prescribedMedication.CalculatedDailyDose = sqlDataReader.GetDecimal(7);
                        prescribedMedication.Instructions = sqlDataReader.GetString(8);
                        prescribedMedications.Add(prescribedMedication);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PrescribedMedication prescribedMedication = new PrescribedMedication();
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    prescribedMedications.Add(prescribedMedication);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedications.ToArray();
        }

        public Prescription[] ListCurrentByPartyWithinPeriod(int pPartyID, DateTime pFromPrescriptionDate, DateTime pToPrescriptionDate)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_ListByPartyWithinPeriod]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromPrescriptionDate", pFromPrescriptionDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToPrescriptionDate", pToPrescriptionDate));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Prescription prescription = new Prescription(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            prescription.Physician = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            prescription.Started = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            prescription.Ended = sqlDataReader.GetDateTime(3);
                        List<PrescribedMedication> prescribedMedications = new List<PrescribedMedication>();
                        PrescribedMedication prescribedMedication = new PrescribedMedication(sqlDataReader.GetInt32(4));
                        prescribedMedication.Name = sqlDataReader.GetString(5);
                        prescribedMedication.Strength = sqlDataReader.GetDecimal(6);
                        prescribedMedication.DoseDescription = sqlDataReader.GetString(7);
                        prescribedMedication.TotalPrescribedQuantity = sqlDataReader.GetDecimal(8);
                        prescribedMedication.QuantityPerDose = sqlDataReader.GetDecimal(9);
                        prescribedMedication.DailyFrequency = sqlDataReader.GetDecimal(10);
                        prescribedMedication.CalculatedDailyDose = sqlDataReader.GetDecimal(11);
                        prescribedMedication.Instructions = sqlDataReader.GetString(12);
                        prescribedMedications.Add(prescribedMedication);
                        prescription.items = prescribedMedications.ToArray();

                        prescriptions.Add(prescription);
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

        public PrescribedMedication Insert(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            PrescribedMedication prescribedMedication = new PrescribedMedication();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MedicationID", pPrescribedMedication.MedicationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Strength", pPrescribedMedication.Strength));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoseDescription", pPrescribedMedication.DoseDescription));
                    sqlCommand.Parameters.Add(new SqlParameter("@TotalPrescribedQuantity", pPrescribedMedication.TotalPrescribedQuantity));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuantityPerDose", pPrescribedMedication.QuantityPerDose));
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyFrequency", pPrescribedMedication.DailyFrequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalculatedDailyDose", pPrescribedMedication.CalculatedDailyDose));
                    sqlCommand.Parameters.Add(new SqlParameter("@Instructions",pPrescribedMedication.Instructions));

                    sqlCommand.ExecuteNonQuery();

                    prescribedMedication = new PrescribedMedication(pPrescribedMedication.MedicationID);
                    prescribedMedication.Name = pPrescribedMedication.Name;
                    prescribedMedication.Strength = pPrescribedMedication.Strength;
                    prescribedMedication.DoseDescription = pPrescribedMedication.DoseDescription;
                    prescribedMedication.TotalPrescribedQuantity = pPrescribedMedication.TotalPrescribedQuantity;
                    prescribedMedication.QuantityPerDose = pPrescribedMedication.QuantityPerDose;
                    prescribedMedication.DailyFrequency = pPrescribedMedication.DailyFrequency;
                    prescribedMedication.CalculatedDailyDose = pPrescribedMedication.CalculatedDailyDose;
                    prescribedMedication.Instructions = pPrescribedMedication.Instructions;
                }
                catch (Exception exc)
                {
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedication;
        }

        public PrescribedMedication Update(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            PrescribedMedication prescribedMedication = new PrescribedMedication();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MedicationID", pPrescribedMedication.MedicationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Strength", pPrescribedMedication.Strength));
                    sqlCommand.Parameters.Add(new SqlParameter("@DoseDescription", pPrescribedMedication.DoseDescription));
                    sqlCommand.Parameters.Add(new SqlParameter("@TotalPrescribedQuantity", pPrescribedMedication.TotalPrescribedQuantity));
                    sqlCommand.Parameters.Add(new SqlParameter("@QuantityPerDose", pPrescribedMedication.QuantityPerDose));
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyFrequency", pPrescribedMedication.DailyFrequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalculatedDailyDose", pPrescribedMedication.CalculatedDailyDose));
                    sqlCommand.Parameters.Add(new SqlParameter("@Instructions", pPrescribedMedication.Instructions));

                    sqlCommand.ExecuteNonQuery();

                    prescribedMedication = new PrescribedMedication(pPrescribedMedication.MedicationID);
                    prescribedMedication.Name = pPrescribedMedication.Name;
                    prescribedMedication.Strength = pPrescribedMedication.Strength;
                    prescribedMedication.DoseDescription = pPrescribedMedication.DoseDescription;
                    prescribedMedication.TotalPrescribedQuantity = pPrescribedMedication.TotalPrescribedQuantity;
                    prescribedMedication.QuantityPerDose = pPrescribedMedication.QuantityPerDose;
                    prescribedMedication.DailyFrequency = pPrescribedMedication.DailyFrequency;
                    prescribedMedication.CalculatedDailyDose = pPrescribedMedication.CalculatedDailyDose;
                    prescribedMedication.Instructions = pPrescribedMedication.Instructions;
                }
                catch (Exception exc)
                {
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedication;
        }

        public PrescribedMedication Delete(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            PrescribedMedication prescribedMedication = new PrescribedMedication();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MedicationID", pPrescribedMedication.MedicationID));

                    sqlCommand.ExecuteNonQuery();

                    prescribedMedication = new PrescribedMedication(pPrescribedMedication.MedicationID);
                }
                catch (Exception exc)
                {
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedication;
        }

        public PrescribedMedication DeleteByPrescription(int pPrescriptionID)
        {
            PrescribedMedication prescribedMedication = new PrescribedMedication();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PrescriptionMedication_DeleteByPrescriptionID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PrescriptionID", pPrescriptionID));

                    sqlCommand.ExecuteNonQuery();

                    prescribedMedication = new PrescribedMedication();
                }
                catch (Exception exc)
                {
                    prescribedMedication.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    prescribedMedication.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return prescribedMedication;
        }
    }
}
