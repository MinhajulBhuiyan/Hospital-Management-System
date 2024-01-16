using System;

namespace Hospital_Management_System
{
    public interface IAppointmentScheduler
    {
        int ScheduleAppointment(int patientId, int doctorId, string problem, DateTime appointmentDate);
        void CancelAppointment(int appointmentId);
        void RescheduleAppointment(int appointmentId, DateTime newDate);
    }
}
