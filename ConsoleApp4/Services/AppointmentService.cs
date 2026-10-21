using Hospital_Appointment_Management_System.Exceptions;
using Hospital_Appointment_Management_System.Models;

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hospital_Appointment_Management_System.Services
{
    public class AppointmentService
    {
        private readonly IRepository<Appointment> repo;

        public AppointmentService(IRepository<Appointment> repo)
        {
            this.repo = repo;
        }
        public void AddAppointment(Appointment appointment)
        {
            if (repo.GetById(appointment.AppointmentId) != null)
                throw new HospitalException("Appointment ID already exists.");

            if (appointment.AppointmentDateTime <= DateTime.Now)
                throw new HospitalException("Date must be in the future.");

            appointment.Status = AppointmentStatus.Scheduled;
            repo.Add(appointment);
        }
        public List<Appointment> GetAll()
        {
            return repo.GetAll();
        }
        public Appointment? GetById(string id)
        {
            return repo.GetById(id);
        }
        public void Reschedule(string id, DateTime dateTime)
        {
            var appointment = repo.GetById(id);

            if (appointment == null)
                throw new HospitalException("Appointment not found.");

            if (appointment.Status != AppointmentStatus.Scheduled)
                throw new HospitalException("Only scheduled appointments can be rescheduled.");

            if (dateTime <= DateTime.Now)
                throw new HospitalException("Date must be in the future.");

            appointment.AppointmentDateTime = dateTime;
            repo.Update(appointment);
        }
        public void Cancel(string id)
        {
            var appointment = repo.GetById(id);

            if (appointment == null)
                throw new HospitalException("Appointment not found.");

            if (appointment.Status != AppointmentStatus.Scheduled)
                throw new HospitalException("Only scheduled appointments can be cancelled.");

            appointment.Status = AppointmentStatus.Cancelled;
            repo.Update(appointment);
        }
        public void Complete(string id)
        {
            var appointment = repo.GetById(id);

            if (appointment == null)
                throw new HospitalException("Appointment not found.");

            if (appointment.Status != AppointmentStatus.Scheduled)
                throw new HospitalException("Only scheduled appointments can be completed.");

            appointment.Status = AppointmentStatus.Completed;
            repo.Update(appointment);
        }
    }
}