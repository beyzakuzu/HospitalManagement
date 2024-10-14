using Core.Repositories;
using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Abstracts;

public interface IPatientRepository : IRepository<Patient, Guid>
{
}
