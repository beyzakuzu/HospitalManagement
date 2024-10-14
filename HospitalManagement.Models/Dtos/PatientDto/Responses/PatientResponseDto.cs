using HospitalManagement.Models.Dtos.AppointmentDto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Dtos.PatientDto.Responses
{
    public class PatientResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;
        public List<AppointmentResponseDto> Appointments { get; set; } = new List<AppointmentResponseDto>();

    }
}
