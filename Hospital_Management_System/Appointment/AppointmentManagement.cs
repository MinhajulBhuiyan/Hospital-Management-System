using System;

namespace Hospital_Management_System
{
    public class AppointmentManagement
    {
        private readonly IAppointmentScheduler appointmentScheduler;
        private readonly IAppointmentViewer appointmentViewer;

        public AppointmentManagement(IAppointmentScheduler appointmentScheduler, IAppointmentViewer appointmentViewer)
        {
            this.appointmentScheduler = appointmentScheduler;
            this.appointmentViewer = appointmentViewer;
        }

        public void ManageAppointments()
        {
            Console.WriteLine("Appointment Management:");
            Console.WriteLine("1. Schedule Appointment");
            Console.WriteLine("2. View Appointment Details");

            Console.Write("Enter your choice: ");
            string appointmentChoice = Console.ReadLine();

            Console.Clear();

            switch (appointmentChoice)
            {
                case "1":
                    ScheduleAppointment();
                    break;

                case "2":
                    ViewAppointmentDetails();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void ScheduleAppointment()
        {
            Console.WriteLine("Schedule Appointment:");

            Console.Write("Enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Enter doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter appointment date and time (e.g., '2024-01-13 14:30'): ");
            string appointmentDateTimeString = Console.ReadLine();

            if (DateTime.TryParse(appointmentDateTimeString, out DateTime appointmentDateTime))
            {
                Console.Write("Enter problem description: ");
                string problemDescription = Console.ReadLine();

                int appointmentId = appointmentScheduler.ScheduleAppointment(patientId, doctorId, problemDescription, appointmentDateTime);

                if (appointmentId != 0)
                {
                    Console.WriteLine($"Appointment scheduled successfully. Appointment ID: {appointmentId}");
                }
                else
                {
                    Console.WriteLine("Error scheduling the appointment.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date and time format.");
            }
        }


        private void ViewAppointmentDetails()
        {
            Console.Write("Enter appointment ID: ");
            int appointmentId = int.Parse(Console.ReadLine());

            appointmentViewer.ViewAppointmentDetails(appointmentId);
        }
    }
}
