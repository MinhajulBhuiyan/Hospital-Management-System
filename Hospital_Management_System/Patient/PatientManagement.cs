using System;

namespace Hospital_Management_System
{

    public class PatientManagement
    {
        private readonly IRegistrar<Patient> patientRegistrar;
        private readonly IPatientUpdater patientUpdater;
        private readonly IViewer<Patient> patientViewer;

        public PatientManagement(IRegistrar<Patient> patientRegistrar, IPatientUpdater patientUpdater, IViewer<Patient> patientViewer)
        {
            this.patientRegistrar = patientRegistrar;
            this.patientUpdater = patientUpdater;
            this.patientViewer = patientViewer;
        }

        public void ManagePatients()
        {
            Console.WriteLine("Patient Management:");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Update Patient Information");
            Console.WriteLine("3. View Patient Details");

            Console.Write("Enter your choice: ");
            string patientChoice = Console.ReadLine();

            Console.Clear();

            switch (patientChoice)
            {
                case "1":
                    patientRegistrar.Register(CreatePatient());
                    break;

                case "2":
                    patientUpdater.UpdatePatientInformation();
                    break;

                case "3":
                    ViewPatientDetails();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private Patient CreatePatient()
        {
            Console.WriteLine("Register Patient:");

            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Enter patient age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out age) && age >= 0)
                {
                    break; // Break the loop if a valid age is provided
                }

                Console.WriteLine("Invalid age. Age must be a non-negative integer.");
            }

            Console.Write("Enter patient gender (Male/Female/Others): ");
            string genderInput = Console.ReadLine();

            Console.Write("Enter patient address: ");
            string address = Console.ReadLine();

            Console.Write("Enter patient description: ");
            string description = Console.ReadLine();

            Gender gender;

            if (Enum.TryParse(genderInput, true, out gender))
            {
                // Successfully parsed the gender
                return new Patient { Name = name, Age = age.ToString(), Address = address, Description = description, Gender = gender };
            }
            else
            {
                // Invalid gender input
                Console.WriteLine("Invalid gender. Setting gender to 'Others'.");
                return new Patient { Name = name, Age = age.ToString(), Address = address, Description = description, Gender = Gender.Others };
            }
        }



        private int GetPatientId()
        {
            Console.Write("Enter patient ID: ");
            int.TryParse(Console.ReadLine(), out int patientId);
            return patientId;
        }

        


        private void ViewPatientDetails()
        {
            patientViewer.ViewDetails(GetPatientId());
        }
    }
}
