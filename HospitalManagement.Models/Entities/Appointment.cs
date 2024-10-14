using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Entities;

public class Appointment : Entity<int> 
{
    public Guid PatientId { get; set; } 
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } = new Doctor(); 
    public virtual Patient Patient { get; set; } = new Patient(); 

    public Appointment()
    {

    }

    public Appointment (Guid patientId, DateTime appointmentDate, int doctorId, Doctor doctor, Patient patient)
    {
        PatientId = patientId;
        AppointmentDate = appointmentDate;
        DoctorId = doctorId;
        Doctor = doctor;
        Patient = patient;
    }
}
