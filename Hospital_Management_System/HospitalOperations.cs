﻿using System;

namespace Hospital_Management_System
{
    public class HospitalOperations
    {
        private readonly PatientManagement patientManagement;
        private readonly DoctorManagement doctorManagement;
        private readonly AppointmentManagement appointmentManagement;
        private readonly MedicalRecordManager medicalRecordManager;

        public HospitalOperations(
            IRegistrar<Patient> patientRegistrar,
            IUpdater<Patient> patientUpdater,
            IViewer<Patient> patientViewer,
            IRegistrar<Doctor> doctorRegistrar,
            IUpdater<Doctor> doctorUpdater,
            IViewer<Doctor> doctorViewer,
            IAppointmentScheduler appointmentScheduler,
            IAppointmentViewer appointmentViewer,
            IMedicalRecordService medicalRecordService)
        {
            patientManagement = new PatientManagement(patientRegistrar, patientUpdater, patientViewer);
            doctorManagement = new DoctorManagement(doctorRegistrar, doctorUpdater, doctorViewer);
            appointmentManagement = new AppointmentManagement(appointmentScheduler, appointmentViewer);
            medicalRecordManager = new MedicalRecordManager(medicalRecordService);
        }

        public void Execute()
        {
            while (true)
            {
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Management");
                Console.WriteLine("4. Medical Record Management");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        patientManagement.ManagePatients();
                        break;
                    case "2":
                        doctorManagement.ManageDoctors();
                        break;
                    case "3":
                        appointmentManagement.ManageAppointments();
                        break;
                    case "4":
                        medicalRecordManager.ManageMedicalRecords();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}