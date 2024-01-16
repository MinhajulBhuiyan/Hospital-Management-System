using System;

namespace Hospital_Management_System
{
    
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (Enum.IsDefined(typeof(Gender), value))
                {
                    _gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid gender value.");
                }
            }
        }
        public string Specialization { get; set; }
        public string Details { get; set; }
    }
}
