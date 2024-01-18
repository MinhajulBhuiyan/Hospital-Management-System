// MedicalRecordViewer.cs
using System;

namespace Hospital_Management_System
{
    public class MedicalRecordViewer : IViewer<MedicalRecord>
    {
        private readonly IMedicalRecordService medicalRecordService;

        public MedicalRecordViewer(IMedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }

        public void ViewDetails(int patientId)
        {
            var medicalRecord = medicalRecordService.RetrieveRecord(patientId);

            if (medicalRecord != null)
            {
                Console.WriteLine($"Medical Record for Patient ID {patientId}:");
                Console.WriteLine($"Details: {medicalRecord.Details}");
            }
        }
    }
}
