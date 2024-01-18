using System;

namespace Hospital_Management_System
{
    public class MedicalRecordManager
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly MedicalRecordViewer medicalRecordViewer;

        public MedicalRecordManager(IMedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService ?? throw new ArgumentNullException(nameof(medicalRecordService));
            this.medicalRecordViewer = new MedicalRecordViewer(medicalRecordService);
        }

        public void StoreMedicalRecord(int patientId, string details)
        {
            var medicalRecord = new MedicalRecord { PatientId = patientId, Details = details };
            medicalRecordService.StoreRecord(medicalRecord);
        }

        public void ViewMedicalRecord(int patientId)
        {
            medicalRecordViewer.ViewDetails(patientId);
        }

        public void ManageMedicalRecords()
        {
            Console.WriteLine("Medical Record Management");
            Console.WriteLine("1. Store Medical Record");
            Console.WriteLine("2. View Medical Record");
            Console.WriteLine("0. Back");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Patient ID: ");
                    int patientId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Medical Record Details: ");
                    string details = Console.ReadLine();

                    StoreMedicalRecord(patientId, details);
                    break;
                case "2":
                    Console.Write("Enter Patient ID: ");
                    int viewPatientId = int.Parse(Console.ReadLine());

                    ViewMedicalRecord(viewPatientId);
                    break;
                case "0":
                    // Back to the main menu
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
