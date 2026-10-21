using Hospital_Appointment_Management_System.Exceptions;
using Hospital_Appointment_Management_System.Models;
using Hospital_Appointment_Management_System.Services;

namespace Hospital_Appointment_Management_System.Services
{
    public class DoctorService
    {
        private readonly IRepository<Doctor> repo;
        public DoctorService(IRepository<Doctor> repo)
        {
            this.repo=repo;
        }
        public void AddDoctor(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.PersonId))
                throw new HospitalException("Doctor ID cannot be empty.");

            if (doctor.ConsultationFee < 0)
                throw new HospitalException("Consultation fee cannot be negative.");

            if (repo.GetById(doctor.PersonId)!=null)
                throw new HospitalException("Doctor ID already exists.");

            repo.Add(doctor);
        }

        public List<Doctor> GetAll()
        {
            return repo.GetAll();
        }

        public Doctor?GetById(string id)
        {
            return repo.GetById(id);
        }

        public List<Doctor> Search(string value)
        {
            return repo.GetAll()
                .Where(d =>
                    d.FullName.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                    d.Specialization.Contains(value, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void Update(
            string id,
            string name,
            string specialization,
            decimal fee)
        {
            var doctor = repo.GetById(id);

            if (doctor == null)
                throw new HospitalException("Doctor not found.");

            if (fee < 0)
                throw new HospitalException("Consultation fee cannot be negative.");

            doctor.FullName = name;
            doctor.Specialization = specialization;
            doctor.ConsultationFee = fee;

            repo.Update(doctor);
        }
        public void Delete(string id)
        {
            var doctor = repo.GetById(id);
            if (doctor == null)
                throw new HospitalException("Doctor not found.");
            repo.Delete(id);
        }
    }
}