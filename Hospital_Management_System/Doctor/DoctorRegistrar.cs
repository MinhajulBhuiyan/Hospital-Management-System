using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class DoctorRegistrar : IRegistrar<Doctor>
    {
        private readonly IDataAccessor<Doctor> dataAccessor;

        public DoctorRegistrar(IDataAccessor<Doctor> dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void Register(Doctor doctor)
        {
            List<Doctor> doctors = dataAccessor.LoadData();

            int nextDoctorId = GetNextDoctorId(doctors);
            doctor.DoctorId = nextDoctorId;

            doctors.Add(doctor);

            dataAccessor.SaveData(doctors);
        }

        private int GetNextDoctorId(List<Doctor> doctors)
        {
            return doctors?.Any() == true ? doctors.Last().DoctorId + 1 : 1;
        }
    }
}
