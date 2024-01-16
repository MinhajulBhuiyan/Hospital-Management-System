using System.Collections.Generic;

namespace Hospital_Management_System
{
    public interface IDoctorDataAccessor
    {
        List<Doctor> LoadDoctors();
        void SaveDoctors(List<Doctor> doctors);
    }
}
