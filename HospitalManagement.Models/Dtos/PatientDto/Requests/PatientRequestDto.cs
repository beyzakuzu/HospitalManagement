using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Dtos.PatientDto.Requests
{
    public class PatientRequestDto
    {
        public string Name { get; set; } 
        public string Surname { get; set; } = string.Empty; 
    }
}
