using System;


namespace Hospital_Management_System
{
    public class DoctorManagement
    {
        private readonly IRegistrar<Doctor> doctorRegistrar;
        private readonly IDoctorUpdater doctorUpdater;
        private readonly IViewer<Doctor> doctorViewer;

        public DoctorManagement(IRegistrar<Doctor> doctorRegistrar, IDoctorUpdater doctorUpdater, IViewer<Doctor> doctorViewer)
        {
            this.doctorRegistrar = doctorRegistrar;
            this.doctorUpdater = doctorUpdater;
            this.doctorViewer = doctorViewer;
        }

        public void ManageDoctors()
        {
            Console.WriteLine("Doctor Management:");
            Console.WriteLine("1. Register Doctor");
            Console.WriteLine("2. Update Doctor Information");
            Console.WriteLine("3. View Doctor Details");

            Console.Write("Enter your choice: ");
            string doctorChoice = Console.ReadLine();

            Console.Clear();

            switch (doctorChoice)
            {
                case "1":
                    doctorRegistrar.Register(CreateDoctor());
                    break;

                case "2":
                    doctorUpdater.UpdateDoctorInformation();
                    break;

                case "3":
                    ViewDoctorDetails();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private Doctor CreateDoctor()
        {
            Console.WriteLine("Register Doctor:");

            Console.Write("Enter doctor name: ");
            string name = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Enter doctor age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out age) && age >= 0)
                {
                    break; // Break the loop if a valid age is provided
                }

                Console.WriteLine("Invalid age. Age must be a non-negative integer.");
            }

            Console.Write("Enter doctor gender (Male/Female/Others): ");
            string genderInput = Console.ReadLine();

            Console.Write("Enter doctor specialization: ");
            string specialization = Console.ReadLine();

            Console.Write("Enter doctor details: ");
            string details = Console.ReadLine();

            Gender gender;

            if (Enum.TryParse(genderInput, true, out gender))
            {
                // Successfully parsed the gender
                return new Doctor { Name = name, Age = age.ToString(), Gender = gender, Specialization = specialization, Details = details };
            }
            else
            {
                // Invalid gender input
                Console.WriteLine("Invalid gender. Setting gender to 'Others'.");
                return new Doctor { Name = name, Age = age.ToString(), Gender = Gender.Others, Specialization = specialization, Details = details };
            }
        }

        private int GetDoctorId()
        {
            Console.Write("Enter doctor ID: ");
            int.TryParse(Console.ReadLine(), out int doctorId);
            return doctorId;
        }

        private void ViewDoctorDetails()
        {
            doctorViewer.ViewDetails(GetDoctorId());
        }
    }
}
