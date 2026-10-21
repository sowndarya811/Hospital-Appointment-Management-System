using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Appointment_Management_System.Services
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetAll();
        T? GetById(string id);
        void Update(T item);
        void Delete(string id);
    }
}