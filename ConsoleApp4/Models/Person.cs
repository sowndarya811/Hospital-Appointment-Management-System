using System;
using System.Collections.Generic;
using System.Text;
namespace Hospital_Appointment_Management_System.Models
{
    public abstract class Person
    {
        public string PersonId{get; set;}
        public string FullName{get; set;}
        protected Person()
        {
            PersonId=string.Empty;
            FullName=string.Empty;
        }
        protected Person(string id,string fullName)
        {
            PersonId=id;
            FullName=fullName;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID:{PersonId}");
            Console.WriteLine($"Name:{FullName}");
        }
    }
}
