// AppointmentViewer.cs
using System;
using System.Collections.Generic;

namespace Hospital_Management_System
{
    public class AppointmentViewer : IAppointmentViewer
    {
        private readonly IDataAccessor<Appointment> dataAccessor;

        public AppointmentViewer(IDataAccessor<Appointment> dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void ViewAppointmentDetails(int appointmentId)
        {
            var appointments = dataAccessor.LoadData();
            var appointment = appointments.Find(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                Console.WriteLine($"Patient ID: {appointment.PatientId}");
                Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
                Console.WriteLine($"Problem: {appointment.Problem}");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        public void ViewAppointments(DateTime date)
        {
            var appointments = dataAccessor.LoadData();
            var filteredAppointments = appointments.FindAll(a => a.AppointmentDate.Date == date.Date);

            if (filteredAppointments.Count > 0)
            {
                Console.WriteLine($"Appointments on {date.ToShortDateString()}:");
                foreach (var appointment in filteredAppointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                    Console.WriteLine($"Patient ID: {appointment.PatientId}");
                    Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                    Console.WriteLine($"Problem: {appointment.Problem}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No appointments on {date.ToShortDateString()}.");
            }
        }
    }
}
