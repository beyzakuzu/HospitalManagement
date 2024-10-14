using Core.Repositories;
using HospitalManagement.DataAccess.Contexts;
using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Abstracts;

public interface IAppointmentRepository : IRepository<Appointment, int>
{
    List<Appointment> GetAppointmentsByDoctorId(int doctorId);
    List<Appointment> GetPastAppointments();
}
