using System;

namespace Hospital_Management_System
{
    public class PatientViewer : IPatientViewer
    {
        private readonly IPatientDataAccessor dataAccessor;

        public PatientViewer(IPatientDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void ViewDetails(int patientId)
        {
            var patients = dataAccessor.LoadPatients();
            var patient = patients.Find(p => p.PatientId == patientId);

            if (patient != null)
            {
                Console.WriteLine($"Patient ID: {patient.PatientId}");
                Console.WriteLine($"Name: {patient.Name}");
                Console.WriteLine($"Age: {patient.Age}");  
                Console.WriteLine($"Address: {patient.Address}");
                Console.WriteLine($"Gender: {patient.Gender}");
                Console.WriteLine($"Description: {patient.Description}");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
    }
}
