using System;
using System.Collections.Generic;

namespace Hospital_Management_System
{
    public class PatientUpdater : IPatientUpdater
    {
        private readonly IPatientDataAccessor dataAccessor;

        public PatientUpdater(IPatientDataAccessor dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void UpdatePatientInformation()
        {
            Console.WriteLine("Update Patient Information:");
            Console.WriteLine("Enter patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid patient ID.");
                return;
            }

            // Load existing patients
            List<Patient> patients = dataAccessor.LoadPatients();

            // Find the patient with the specified ID
            Patient patientToUpdate = patients.Find(p => p.PatientId == patientId);

            if (patientToUpdate == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.WriteLine($"\nUpdating information for patient: {patientToUpdate.Name}");

            // Now update the patient information
            Console.WriteLine("\nSelect what you want to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Address");
            Console.WriteLine("5. Description");

            Console.Write("\nEnter your choice: ");
            string updateChoice = Console.ReadLine();

            switch (updateChoice)
            {
                case "1":
                    UpdateName(patientToUpdate);
                    break;

                case "2":
                    UpdateAge(patientToUpdate);
                    break;

                case "3":
                    UpdateGender(patientToUpdate);
                    break;

                case "4":
                    UpdateAddress(patientToUpdate);
                    break;

                case "5":
                    UpdateDescription(patientToUpdate);
                    break;

                default:
                    Console.WriteLine("Invalid choice. No changes will be made.");
                    return;
            }

            // Save the updated patients list to the file
            dataAccessor.SavePatients(patients);

            // Display the updated patient information
            Console.WriteLine("\nPatient information successfully updated.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Updated Patient Information:");
            DisplayPatientInformation(patientToUpdate);
        }

        // Other update methods remain the same...

        private void UpdateName(Patient patient)
        {
            Console.Write("\nEnter updated patient name: ");
            string name = Console.ReadLine();
            patient.Name = name;
        }

        private void UpdateAge(Patient patient)
        {
            while (true)
            {
                Console.Write("\nEnter updated patient age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out int age) && age >= 0)
                {
                    patient.Age = age.ToString();
                    return;
                }

                Console.WriteLine("\nInvalid age. Age must be a non-negative integer.");
            }
        }

        private void UpdateAddress(Patient patient)
        {
            Console.Write("\nEnter updated patient address: ");
            string address = Console.ReadLine();
            patient.Address = address;
        }

        private void UpdateDescription(Patient patient)
        {
            Console.Write("\nEnter updated patient description: ");
            string description = Console.ReadLine();
            patient.Description = description;
        }

        private void UpdateGender(Patient patient)
        {
            while (true)
            {
                Console.Write("\nEnter updated patient gender (Male/Female/Others): ");
                string genderInput = Console.ReadLine();
                Gender gender;

                if (Enum.TryParse(genderInput, true, out gender))
                {
                    patient.Gender = gender;
                    break;
                }
                Console.WriteLine("\nInvalid gender. Setting gender to 'Others'.");
            }
        }

        private void DisplayPatientInformation(Patient patient)
        {
            Console.WriteLine($"Patient ID: {patient.PatientId}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Age: {patient.Age}");
            Console.WriteLine($"Gender: {patient.Gender}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Description: {patient.Description}");
        }
    }
}
