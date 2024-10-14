using Core.Repositories;
using HospitalManagement.DataAccess.Abstracts;
using HospitalManagement.DataAccess.Contexts;
using HospitalManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Concretes;

public class EfDoctorRepository : EfRepositoryBase<MsSqlContext, Doctor, int>, IDoctorRepository
{
    public EfDoctorRepository(MsSqlContext context) : base(context)
    {
    }

    public List<Doctor> GetDoctorsWithAppointments()
    {
        return Context.Set<Doctor>()
            .Include(d => d.Appointments)
            .ToList();
    }
}
