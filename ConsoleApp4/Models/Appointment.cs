
using Hospital_Appointment_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Hospital_Appointment_Management_System.Models
{
      public class Appointment
        {
            public string AppointmentId{get;set;}
            public string PatientId{get;set;}
            public string DoctorId{get;set;}
            public DateTime AppointmentDateTime{get;set;}
            public string Reason{get;set;}
            public AppointmentStatus Status{get;set;}

            public Appointment()
            {
                AppointmentId=string.Empty;
                PatientId=string.Empty;
                DoctorId=string.Empty;
                Reason=string.Empty;
                Status=AppointmentStatus.Scheduled;
            }

            public Appointment(
                string appointmentId,
                string patientId,
                string doctorId,
                DateTime appointmentDateTime,
                string reason)
            {
                AppointmentId=appointmentId;
                PatientId=patientId;
                DoctorId=doctorId;
                AppointmentDateTime=appointmentDateTime;
                Reason=reason;
                Status=AppointmentStatus.Scheduled;
            }
        }
    }