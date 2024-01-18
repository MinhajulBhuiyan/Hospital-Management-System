using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public interface IViewer<T>
    {
        void ViewDetails(int entityId);
    }
}
