using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_Management_System
{
    public class PatientDataAccessor : IPatientDataAccessor
    {
        private string patientsFilePath = "C:\\Users\\bhuiy\\Desktop\\Hospital_Management_System\\Patient.txt";

        public List<Patient> LoadPatients()
        {
            List<Patient> loadedPatients = new List<Patient>();
            if (File.Exists(patientsFilePath))
            {
                using (StreamReader reader = new StreamReader(patientsFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 6 && int.TryParse(parts[0], out int id) && int.TryParse(parts[2], out int age))
                        {
                            loadedPatients.Add(new Patient
                            {
                                PatientId = id,
                                Name = parts[1],
                                Age = parts[2],
                                Gender = (Gender)Enum.Parse(typeof(Gender), parts[3]),
                                Address = parts[4],
                                Description = parts[5]
                            });
                        }
                    }
                }
            }
            return loadedPatients;
        }

        public void SavePatients(List<Patient> patientsToSave)
        {
            using (StreamWriter writer = new StreamWriter(patientsFilePath))
            {
                foreach (var patient in patientsToSave)
                {
                    writer.WriteLine($"{patient.PatientId},{patient.Name},{patient.Age},{patient.Gender},{patient.Address},{patient.Description}");
                }
            }
        }
    }
}
