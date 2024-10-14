using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Entities;

public class Patient : Entity<Guid>
{
    public string Name { get; set; } = string.Empty; 
    public string Surname { get; set; } = string.Empty; 
    public string ContactNumber { get; set; } = string.Empty; 
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    public Patient(string name, string surname, string contactNumber, List<Appointment> appointments)
    {
        Name = name;
        Surname = surname;
        ContactNumber = contactNumber;
        Appointments = appointments;
    }

    public Patient() { }
}