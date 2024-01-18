using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class DoctorRegistrar : IRegistrar<Doctor>
    {
        private readonly IDoctorDataAccessor dataAccessor;

        public DoctorRegistrar(IDoctorDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void Register(Doctor doctor)
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
