using System.Collections.Generic;

namespace Hospital_Management_System
{
    public interface IRegistrar<T>
    {
        void Register(T entity);
    }
}
