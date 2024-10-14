using Core.Repositories;
using HospitalManagement.DataAccess.Abstracts;
using HospitalManagement.DataAccess.Contexts;
using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Concretes;

public class EfAppointmentRepository : EfRepositoryBase<MsSqlContext, Appointment, int>, IAppointmentRepository
{
    public EfAppointmentRepository(MsSqlContext context) : base(context)
    {
    }

   
    public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
    {
        return Context.Set<Appointment>()
            .Where(a => a.DoctorId == doctorId)
            .ToList();
    }

    
    public List<Appointment> GetPastAppointments()
    {
        return Context.Set<Appointment>()
            .Where(a => a.AppointmentDate < DateTime.Now)
            .ToList();
    }
}