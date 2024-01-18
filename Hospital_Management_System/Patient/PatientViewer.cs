using System;

namespace Hospital_Management_System
{
    public class PatientViewer : IViewer<Patient>
    {
        private readonly IDataAccessor<Patient> dataAccessor;

        public PatientViewer(IDataAccessor<Patient> dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void ViewDetails(int patientId)
        {
            var patients = dataAccessor.LoadData();
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
