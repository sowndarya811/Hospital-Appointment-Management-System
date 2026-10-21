using System;
using System.Collections.Generic;
using System.Linq;
using Hospital_Appointment_Management_System.Models;
using Hospital_Appointment_Management_System.Services;

namespace Hospital_Appointment_Management_System.Services
{
    public class ReportService
        {
            private readonly IRepository<Appointment> appointmentRepo;
            private readonly IRepository<Doctor> doctorRepo;

            public ReportService(
                IRepository<Appointment> appointmentRepo,
                IRepository<Doctor> doctorRepo)
            {
                this.appointmentRepo = appointmentRepo;
                this.doctorRepo = doctorRepo;
            }

            public List<Appointment> GetByStatus(AppointmentStatus status)
            {
                return appointmentRepo.GetAll()
                    .Where(a => a.Status == status)
                    .ToList();
            }

            public List<Appointment> GetByDate(DateTime date)
            {
                return appointmentRepo.GetAll()
                    .Where(a => a.AppointmentDateTime.Date == date.Date)
                    .ToList();
            }

            public List<Appointment> GetPatientAppointments(string patientId)
            {
                return appointmentRepo.GetAll()
                    .Where(a => a.PatientId == patientId)
                    .ToList();
            }

            public List<Appointment> GetDoctorAppointments(string doctorId)
            {
                return appointmentRepo.GetAll()
                    .Where(a => a.DoctorId == doctorId)
                    .ToList();
            }

            public Dictionary<string, int> GetScheduledCount()
            {
                return appointmentRepo.GetAll()
                    .Where(a => a.Status == AppointmentStatus.Scheduled)
                    .GroupBy(a => a.DoctorId)
                    .ToDictionary(g => g.Key, g => g.Count());
            }

            public decimal GetRevenue()
            {
                decimal total = 0;

                foreach (var appointment in appointmentRepo.GetAll()
                    .Where(a => a.Status == AppointmentStatus.Completed))
                {
                    var doctor = doctorRepo.GetById(appointment.DoctorId);

                    if (doctor != null)
                        total += doctor.ConsultationFee;
                }

                return total;
            }

            public Doctor? GetTopDoctor()
            {
                var result = appointmentRepo.GetAll()
                    .Where(a => a.Status == AppointmentStatus.Completed)
                    .GroupBy(a => a.DoctorId)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault();

                if (result == null)
                    return null;

                return doctorRepo.GetById(result.Key);
            }
        }
    }