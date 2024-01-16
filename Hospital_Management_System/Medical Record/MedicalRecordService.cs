// MedicalRecordService.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_Management_System
{
    public class MedicalRecordService : IMedicalRecordService, IMedicalRecordViewer
    {
        private readonly string medicalRecordsFilePath = "C:\\Users\\bhuiy\\Desktop\\Hospital_Management_System\\MedicalRecords.txt";
        private readonly Dictionary<int, MedicalRecord> medicalRecords = new Dictionary<int, MedicalRecord>();

        public void StoreRecord(MedicalRecord medicalRecord)
        {
            medicalRecords[medicalRecord.PatientId] = medicalRecord;
            SaveMedicalRecords();
            Console.WriteLine($"Medical record stored for patient ID {medicalRecord.PatientId}");
        }

        public MedicalRecord RetrieveRecord(int patientId)
        {
            if (medicalRecords.ContainsKey(patientId))
            {
                return medicalRecords[patientId];
            }
            else
            {
                Console.WriteLine($"Medical record not found for patient ID {patientId}");
                return null;
            }
        }

        public void ViewMedicalRecord(int patientId)
        {
            var medicalRecord = RetrieveRecord(patientId);

            if (medicalRecord != null)
            {
                Console.WriteLine($"Medical Record for Patient ID {patientId}:");
                Console.WriteLine($"Details: {medicalRecord.Details}");
            }
        }

        private void SaveMedicalRecords()
        {
            // Save medical records to the text file
            using (StreamWriter writer = new StreamWriter(medicalRecordsFilePath))
            {
                foreach (var record in medicalRecords.Values)
                {
                    writer.WriteLine($"{record.PatientId},{record.Details}");
                }
            }
        }
    }
}
