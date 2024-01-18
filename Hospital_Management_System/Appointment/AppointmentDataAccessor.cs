using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_Management_System
{
    public class AppointmentDataAccessor : IDataAccessor<Appointment>
    {
        private string appointmentsFilePath = "C:\\Users\\bhuiy\\Desktop\\Hospital_Management_System\\Appointments.txt";

        public List<Appointment> LoadData()
        {
            List<Appointment> loadedAppointments = new List<Appointment>();
            if (File.Exists(appointmentsFilePath))
            {
                using (StreamReader reader = new StreamReader(appointmentsFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 5 && int.TryParse(parts[0], out int id) &&
                            int.TryParse(parts[1], out int patientId) && int.TryParse(parts[2], out int doctorId))
                        {
                            loadedAppointments.Add(new Appointment
                            {
                                AppointmentId = id,
                                PatientId = patientId,
                                DoctorId = doctorId,
                                AppointmentDate = DateTime.Parse(parts[3]),
                                Problem = parts[4]
                            });
                        }
                    }
                }
            }
            return loadedAppointments;
        }

        public void SaveData(List<Appointment> dataToSave)
        {
            using (StreamWriter writer = new StreamWriter(appointmentsFilePath))
            {
                foreach (var appointment in dataToSave)
                {
                    writer.WriteLine($"{appointment.AppointmentId},{appointment.PatientId},{appointment.DoctorId},{appointment.AppointmentDate},{appointment.Problem}");
                }
            }
        }
    }
}
