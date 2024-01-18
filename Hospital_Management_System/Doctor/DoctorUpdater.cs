using System;
using System.Collections.Generic;

namespace Hospital_Management_System
{
    public class DoctorUpdater : IUpdater<Doctor>
    {
        private readonly IDataAccessor<Doctor> dataAccessor;

        public DoctorUpdater(IDataAccessor<Doctor> dataAccessor)
        {
            this.dataAccessor = dataAccessor;
        }

        public void UpdateInformation()
        {
            // Load existing doctors
            List<Doctor> doctors = dataAccessor.LoadData();

            // Display the list of doctors
            Console.WriteLine("List of Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.DoctorId}, Name: {doctor.Name}");
            }

            Console.WriteLine("Update Doctor Information:");
            Console.Write("Enter doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid doctor ID.");
                return;
            }

            // Find the doctor with the specified ID
            Doctor doctorToUpdate = doctors.Find(d => d.DoctorId == doctorId);

            if (doctorToUpdate == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine($"\nUpdating information for doctor: {doctorToUpdate.Name}");

            // Now update the doctor information
            Console.WriteLine("\nSelect what you want to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Specialization");
            Console.WriteLine("5. Details");

            Console.Write("\nEnter your choice: ");
            string updateChoice = Console.ReadLine();

            switch (updateChoice)
            {
                case "1":
                    UpdateName(doctorToUpdate);
                    break;

                case "2":
                    UpdateAge(doctorToUpdate);
                    break;

                case "3":
                    UpdateGender(doctorToUpdate);
                    break;

                case "4":
                    UpdateSpecialization(doctorToUpdate);
                    break;

                case "5":
                    UpdateDetails(doctorToUpdate);
                    break;

                default:
                    Console.WriteLine("Invalid choice. No changes will be made.");
                    return;
            }

            // Save the updated doctors list to the file
            dataAccessor.SaveData(doctors);

            // Display the updated doctor information
            Console.WriteLine("\nDoctor information successfully updated.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Updated Doctor Information:");
            DisplayDoctorInformation(doctorToUpdate);
        }

        // Other update methods remain the same...

        private void UpdateName(Doctor doctor)
        {
            Console.Write("\nEnter updated doctor name: ");
            string name = Console.ReadLine();
            doctor.Name = name;
        }

        private void UpdateAge(Doctor doctor)
        {
            while (true)
            {
                Console.Write("\nEnter updated doctor age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out int age) && age >= 0)
                {
                    doctor.Age = age.ToString();
                    return;
                }

                Console.WriteLine("\nInvalid age. Age must be a non-negative integer.");
            }
        }

        private void UpdateDetails(Doctor doctor)
        {
            Console.Write("\nEnter updated doctor details: ");
            string details = Console.ReadLine();
            doctor.Details = details;
        }

        private void UpdateSpecialization(Doctor doctor)
        {
            Console.Write("\nEnter updated doctor specialization: ");
            string specialization = Console.ReadLine();
            doctor.Specialization = specialization;
        }

        private void UpdateGender(Doctor doctor)
        {
            while (true)
            {
                Console.Write("\nEnter updated doctor gender (Male/Female/Others): ");
                string genderInput = Console.ReadLine();
                Gender gender;

                if (Enum.TryParse(genderInput, true, out gender))
                {
                    doctor.Gender = gender;
                    break;
                }
                Console.WriteLine("\nInvalid gender. Setting gender to 'Others'.");
            }
        }

        private void DisplayDoctorInformation(Doctor doctor)
        {
            Console.WriteLine($"Doctor ID: {doctor.DoctorId}");
            Console.WriteLine($"Name: {doctor.Name}");
            Console.WriteLine($"Age: {doctor.Age}");
            Console.WriteLine($"Gender: {doctor.Gender}");
            Console.WriteLine($"Specialization: {doctor.Specialization}");
            Console.WriteLine($"Details: {doctor.Details}");
        }
    }
}
