using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Doctor(int id, string name, string specialization)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    public class HospitalRoom
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public List<Patient> Patients { get; set; }

        public HospitalRoom(int roomNumber, int capacity)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Patients = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (Patients.Count < Capacity)
            {
                Patients.Add(patient);
                Console.WriteLine($"Patient {patient.Name} доданий у палату №{RoomNumber}");
            }
            else
            {
                Console.WriteLine($"Палата №{RoomNumber} переповнена! неможливо додати пацієнта {patient.Name}");
            }
        }
    }

    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Description = description;
        }
    }

    public class Hospital
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }
        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name}, ({doctor.Specialization}) доданий до системи");
        }
        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} доданий до системи");
        }
        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} додана до системи");
        }
        public void HospitalizePatient(int patientId, int RoomNumber)
        {
            Patient patient = Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений");
                return;
            }
            HospitalRoom room = Rooms.FirstOrDefault(r => r.RoomNumber == RoomNumber);
            if (room == null)
            {
                Console.WriteLine($"Палата №{RoomNumber} не знайдена");
                return;
            }
            room.AddPatient(patient);
        }
        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name}->{record.Doctor.Name}");
        }
        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId).ToList();
        }
        public string GetStatistics()
        {
            int totalPatientsInRooms = Rooms.Sum(r => r.Patients.Count);

            return
                $@"=== СТАТИСТИКА ЛІКАРНІ ===:
                Кількість лікарів: {Doctors.Count}
                Кількість зареєстрованих пацієнтів: {Patients.Count}
                Кількість пацієнтів у палатах: {totalPatientsInRooms}
                Кількість палат: {Rooms.Count}
                Кількість медичних записів: {Records.Count}";
        }
        public class HospitalDemo
        {
            public void Run()
            {
                Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

                Hospital hospital = new Hospital();
                hospital.AddDoctor(new Doctor(1, "Др. Іваненко", "Терапевт"));
                hospital.AddDoctor(new Doctor(2, "Др. Петров", "Хірург"));
                hospital.AddDoctor(new Doctor(3, "Др. Сидоренко", "Педіатр"));

                hospital.RegisterPatient(new Patient(1, "Олексій", 30));
                hospital.RegisterPatient(new Patient(2, "Марія", 25));
                hospital.RegisterPatient(new Patient(3, "Іван", 5));
                hospital.RegisterPatient(new Patient(4, "Анна", 40));
                hospital.RegisterPatient(new Patient(5, "Петро", 60));

                hospital.CreateRoom(new HospitalRoom(101, 2));
                hospital.CreateRoom(new HospitalRoom(102, 3));
                hospital.CreateRoom(new HospitalRoom(103, 1));

                hospital.HospitalizePatient(1, 101);
                hospital.HospitalizePatient(2, 101);
                hospital.HospitalizePatient(3, 102);
                hospital.HospitalizePatient(4, 102);

                hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], hospital.Doctors[0], DateTime.Now, "Лікування грипу"));
                hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], hospital.Doctors[1], DateTime.Now, "Операція на перелом"));
                hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[2], hospital.Doctors[2], DateTime.Now, "Лікування інфекції"));
                hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[3], hospital.Doctors[0], DateTime.Now, "Лікування гастриту"));

                Console.WriteLine("\n=== ІСТОРІЯ ПАЦІЄНТА ===");
                var history = hospital.GetPatientHistory(1);
                foreach (var record in history)
                {
                    Console.WriteLine($"Дата : {record.Date}, Лікар: {record.Doctor.Name}, Опис: {record.Description}");

                }
                Console.WriteLine(hospital.GetStatistics());
            }
            public class Program
            {
                public static void Main(string[] args)
                {
                    HospitalDemo demo = new HospitalDemo();
                    demo.Run();

                    Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
                    Console.ReadKey();
                }
            }

        }

    }
}


