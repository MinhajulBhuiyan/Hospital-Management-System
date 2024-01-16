using System;

namespace Hospital_Management_System
{
    public enum Gender
    {
        Male,
        Female,
        Others
    }

    public class Patient
    {       
        public int PatientId { get; set; }
        public string Age { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

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

        public string Description { get; set; }
    }
}
