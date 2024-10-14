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

public class EfPatientRepository : EfRepositoryBase<MsSqlContext, Patient, Guid>, IPatientRepository
{
    public EfPatientRepository(MsSqlContext context) : base(context)
    {
    }
    public List<Patient> GetPatientsWithAppointments()
    {
        return Context.Set<Patient>()
            .Include(p => p.Appointments)
            .ToList();
    }

}
