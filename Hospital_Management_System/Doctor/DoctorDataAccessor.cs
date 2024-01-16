using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_Management_System
{
    public class DoctorDataAccessor : IDoctorDataAccessor
    {
        private string doctorsFilePath = "C:\\Users\\bhuiy\\Desktop\\Hospital_Management_System\\Doctors.txt";

        public List<Doctor> LoadDoctors()
        {
            List<Doctor> loadedDoctors = new List<Doctor>();
            if (File.Exists(doctorsFilePath))
            {
                using (StreamReader reader = new StreamReader(doctorsFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 6 && int.TryParse(parts[0], out int id) && int.TryParse(parts[2], out int age))
                        {
                            loadedDoctors.Add(new Doctor
                            {
                                DoctorId = id,
                                Name = parts[1],
                                Age = parts[2],
                                Gender = (Gender)Enum.Parse(typeof(Gender), parts[3]),
                                Specialization = parts[4],
                                Details = parts[5]
                            });
                        }
                    }
                }
            }
            return loadedDoctors;
        }

        public void SaveDoctors(List<Doctor> doctorsToSave)
        {
            using (StreamWriter writer = new StreamWriter(doctorsFilePath))
            {
                foreach (var doctor in doctorsToSave)
                {
                    writer.WriteLine($"{doctor.DoctorId},{doctor.Name},{doctor.Age},{doctor.Gender},{doctor.Specialization},{doctor.Details}");
                }
            }
        }
    }
}
