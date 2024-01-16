using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class PatientRegistrar : IPatientRegistrar
    {
        private readonly IPatientDataAccessor dataAccessor;

        public PatientRegistrar(IPatientDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void RegisterPatient(Patient patient)
        {
            List<Patient> patients = dataAccessor.LoadPatients();

            int nextPatientId = GetNextPatientId(patients);
            patient.PatientId = nextPatientId;

            patients.Add(patient);

            dataAccessor.SavePatients(patients);
        }

        private int GetNextPatientId(List<Patient> patients)
        {
            return patients?.Any() == true ? patients.Last().PatientId + 1 : 1;
        }
    }
}
