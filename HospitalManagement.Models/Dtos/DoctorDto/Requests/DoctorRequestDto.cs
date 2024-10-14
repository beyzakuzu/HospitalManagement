using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Dtos.DoctorDto.Requests
{
    public class DoctorRequestDto
    {
        public string Name { get; set; } 
        public string Surnanme { get; set; } = string.Empty;
        public Branch Branch { get; set; }
    }
}
