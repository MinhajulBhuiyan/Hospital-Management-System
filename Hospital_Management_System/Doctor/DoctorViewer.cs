using System;

namespace Hospital_Management_System
{
    public class DoctorViewer : IViewer<Doctor>
    {
        private readonly IDoctorDataAccessor dataAccessor;

        public DoctorViewer(IDoctorDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void ViewDetails(int doctorId)
        {
            var doctors = dataAccessor.LoadDoctors();
            var doctor = doctors.Find(d => d.DoctorId == doctorId);

            if (doctor != null)
            {
                Console.WriteLine($"Doctor ID: {doctor.DoctorId}");
                Console.WriteLine($"Name: {doctor.Name}");
                Console.WriteLine($"Details: {doctor.Details}");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }
    }
}
