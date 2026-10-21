using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Appointment_Management_System.Exceptions
{
    public class HospitalException:Exception
    {
        public HospitalException(string message)
            :base(message)
        {
        }
    }
}
      