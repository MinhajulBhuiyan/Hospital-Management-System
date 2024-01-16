using System;

namespace Hospital_Management_System
{
    public interface IAppointmentViewer
    {
        void ViewAppointmentDetails(int appointmentId);
        void ViewAppointments(DateTime date);
    }
}
