using System.Collections.Generic;

namespace Hospital_Management_System
{
    public interface IAppointmentDataAccessor
    {
        List<Appointment> LoadAppointments();
        void SaveAppointments(List<Appointment> appointments);
    }
}
