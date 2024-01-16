using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class DoctorRegistrar : IDoctorRegistrar
    {
        private readonly IDoctorDataAccessor dataAccessor;

        public DoctorRegistrar(IDoctorDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void RegisterDoctor(Doctor doctor)
        {
            List<Doctor> doctors = dataAccessor.LoadDoctors();

            int nextDoctorId = GetNextDoctorId(doctors);
            doctor.DoctorId = nextDoctorId;

            doctors.Add(doctor);

            dataAccessor.SaveDoctors(doctors);
        }

        private int GetNextDoctorId(List<Doctor> doctors)
        {
            return doctors?.Any() == true ? doctors.Last().DoctorId + 1 : 1;
        }
    }
}
