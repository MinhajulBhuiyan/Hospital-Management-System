using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class PatientRegistrar : IRegistrar<Patient>
    {
        private readonly IDataAccessor<Patient> dataAccessor;

        public PatientRegistrar(IDataAccessor<Patient> dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void Register(Patient patient)
        {
            List<Patient> patients = dataAccessor.LoadData();

            int nextPatientId = GetNextPatientId(patients);
            patient.PatientId = nextPatientId;

            patients.Add(patient);

            dataAccessor.SaveData(patients);
        }

        private int GetNextPatientId(List<Patient> patients)
        {
            return patients?.Any() == true ? patients.Last().PatientId + 1 : 1;
        }
    }
}
