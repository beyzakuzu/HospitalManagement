using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Dtos.DoctorDto.Responses
{
    public class DoctorResponseDto
    {
        public int Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        public Branch Branch { get; set; }
        public int PatientCount { get; set; }  
    }
}
