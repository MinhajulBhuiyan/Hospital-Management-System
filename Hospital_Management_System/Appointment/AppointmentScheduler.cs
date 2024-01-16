using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_Management_System
{
    public class AppointmentScheduler : IAppointmentScheduler
    {
        private readonly IAppointmentDataAccessor dataAccessor;

        public AppointmentScheduler(IAppointmentDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public int ScheduleAppointment(int patientId, int doctorId, string problem, DateTime appointmentDate)
        {
            var appointments = dataAccessor.LoadAppointments();
            int appointmentId = GetNextAppointmentId(appointments);

            appointments.Add(new Appointment
            {
                AppointmentId = appointmentId,
                PatientId = patientId,
                DoctorId = doctorId,
                Problem = problem,
                AppointmentDate = appointmentDate
            });

            dataAccessor.SaveAppointments(appointments);

            return appointmentId; // Return the generated appointment ID
        }



        public void CancelAppointment(int appointmentId)
        {
            var appointments = dataAccessor.LoadAppointments();
            var appointment = appointments.Find(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                appointments.Remove(appointment);
                dataAccessor.SaveAppointments(appointments);
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        public void RescheduleAppointment(int appointmentId, DateTime newDate)
        {
            var appointments = dataAccessor.LoadAppointments();
            var appointment = appointments.Find(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                appointment.AppointmentDate = newDate;
                dataAccessor.SaveAppointments(appointments);
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        private int GetNextAppointmentId(List<Appointment> appointments)
        {
            return appointments.Count > 0 ? appointments.Last().AppointmentId + 1 : 1;
        }
    }
}
