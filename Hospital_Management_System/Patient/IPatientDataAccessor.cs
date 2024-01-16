using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public interface IPatientDataAccessor
    {
        List<Patient> LoadPatients();
        void SavePatients(List<Patient> patients);
    }
}
