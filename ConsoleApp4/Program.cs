using Hospital_Appointment_Management_System.Models;
namespace HospitalAppointmentManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            Patient patient=new Patient(
                "P001",
                "Sowndarya",
                21,
                "9876543210",
                "sowndarya@gmail.com"
            );
            Doctor doctor=new Doctor(
                "D001",
                "Dr. Kumar",
                "Cardiology",
                800
            );
            Appointment appointment=new Appointment(
                "A001",
                patient.PersonId,
                doctor.PersonId,
                DateTime.Now.AddDays(1),
                "Regular Consultation"
            );
            Console.WriteLine("================================");
            Console.WriteLine("          PATIENT DETAILS");
            Console.WriteLine("================================");
            patient.DisplayInfo();
            Console.WriteLine("\n================================");
            Console.WriteLine("          DOCTOR DETAILS");
            Console.WriteLine("================================");
            doctor.DisplayInfo();
            Console.WriteLine("\n================================");
            Console.WriteLine("       APPOINTMENT DETAILS");
            Console.WriteLine("================================");
            Console.WriteLine($"Appointment ID:{appointment.AppointmentId}");
            Console.WriteLine($"Patient ID:{appointment.PatientId}");
            Console.WriteLine($"Doctor ID:{appointment.DoctorId}");
            Console.WriteLine($"Date & Time:{appointment.AppointmentDateTime}");
            Console.WriteLine($"Reason:{appointment.Reason}");
            Console.WriteLine($"Status:{appointment.Status}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}