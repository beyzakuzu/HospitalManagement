using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement.Models.Entities
{
    public class Doctor : Entity<int> 
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Branch? Branch { get; set; }
        public List<Appointment>? Appointments { get; set; } = new List<Appointment>();

        public Doctor()
        {
        }
        public Doctor(string name, string surname, Branch branch, List<Appointment> appointments)
        {
            Name = name;
            Surname = surname;
            Branch = branch;
            Appointments = appointments;
        }
    }

    public enum Branch
    {
        Cardiology,
        Neurology,
        Dermatology,
        Pediatrics,
        GeneralMedicine,
        Orthopedics,
        Psychiatry,
        Obstetrics,
        Gastroenterology,
        Endocrinology
    }
   


}
