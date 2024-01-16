using Hospital_Management_System;
using System;

namespace Hospital_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var patientRegistrar = new PatientRegistrar(new PatientDataAccessor());
            var patientUpdater = new PatientUpdater(new PatientDataAccessor());
            var patientViewer = new PatientViewer(new PatientDataAccessor());
            var doctorRegistrar = new DoctorRegistrar(new DoctorDataAccessor());
            var doctorUpdater = new DoctorUpdater(new DoctorDataAccessor());
            var doctorViewer = new DoctorViewer(new DoctorDataAccessor());
            var appointmentViewer = new AppointmentViewer(new AppointmentDataAccessor());
            var appointmentScheduler = new AppointmentScheduler(new AppointmentDataAccessor());

            var hospitalOperations = new HospitalOperations(
            patientRegistrar, patientUpdater, patientViewer,
            doctorRegistrar, doctorUpdater, doctorViewer,
            appointmentScheduler, appointmentViewer
            );



            hospitalOperations.Execute();
        }
    }
}
