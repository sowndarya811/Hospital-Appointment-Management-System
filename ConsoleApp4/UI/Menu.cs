using System;
using System.Collections.Generic;
using System.Text;
using Hospital_Appointment_Management_System.Services;

namespace Hospital_Appointment_Management_System.UI
{
    public class Menu
        {
            public void Show()
            {
                while (true)
                {
                    Console.WriteLine("\nHospital Appointment Management");
                    Console.WriteLine("1. Manage Patients");
                    Console.WriteLine("2. Manage Doctors");
                    Console.WriteLine("3. Manage Appointments");
                    Console.WriteLine("4. Reports");
                    Console.WriteLine("5. Save Data");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter choice: ");
                    string? choice = Console.ReadLine();

                    if (choice == "0")
                        break;

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Patient Management");
                            break;

                        case "2":
                            Console.WriteLine("Doctor Management");
                            break;

                        case "3":
                            Console.WriteLine("Appointment Management");
                            break;

                        case "4":
                            Console.WriteLine("Reports");
                            break;

                        case "5":
                            Console.WriteLine("Data saved.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
        }
    }

