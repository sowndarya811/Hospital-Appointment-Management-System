using Hospital_Appointment_Management_System.Models;
using Hospital_Appointment_Management_System.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
namespace Hospital_Appointment_Management_System.Services
{
    public class PatientService
    {
        private readonly IRepository<Patient> _repository;
        public PatientService(IRepository<Patient> repository)
        {
            _repository=repository;
        }
        public void AddPatient(Patient patient)
        {
            if (patient==null)
            {
                throw new HospitalException(
                    "Patient cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(patient.PersonId))
            {
                throw new HospitalException(
                    "Patient ID cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(patient.FullName))
            {
                throw new HospitalException(
                    "Patient name cannot be empty.");
            }
            if (patient.Age<0||patient.Age>120)
            {
                throw new HospitalException(
                    "Patient age must be between 0 and 120.");
            }
            if (string.IsNullOrWhiteSpace(patient.PhoneNumber))
            {
                throw new HospitalException(
                    "Phone number cannot be empty.");
            }
            if(_repository.GetById(patient.PersonId)!=null)
            {
                throw new HospitalException(
                    "Patient ID already exists.");
            }
            _repository.Add(patient);
        }
        public List<Patient>GetAllPatients()
        {
            return _repository.GetAll();
        }
        public Patient? GetPatientById(string id)
        {
            return _repository.GetById(id);
        }
        public List<Patient>SearchPatients(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Patient>();
            }
            return _repository
                .GetAll()
                .Where(p=>p.FullName.Contains(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public void UpdatePatient(
            string id,
            string fullName,
            int age,
            string phoneNumber,
            string?email)
        {
            Patient? patient=_repository.GetById(id);
            if(patient==null)
            {
                throw new HospitalException(
                    "Patient not found.");
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new HospitalException(
                    "Patient name cannot be empty.");
            }
            if (age<0||age>120)
            {
                throw new HospitalException(
                    "Patient age must be between 0 and 120.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new HospitalException(
                    "Phone number cannot be empty.");
            }
            patient.FullName = fullName;
            patient.Age = age;
            patient.PhoneNumber = phoneNumber;
            patient.Email = email;
            _repository.Update(patient);
        }
        public void DeletePatient(string id)
        {
            Patient?patient=_repository.GetById(id);
            if (patient==null)
            {
                throw new HospitalException(
                    "Patient not found.");
            }
            _repository.Delete(id);
        }
    }
}
