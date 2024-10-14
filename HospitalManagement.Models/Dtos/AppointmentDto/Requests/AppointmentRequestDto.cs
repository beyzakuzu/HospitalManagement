using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models.Dtos.AppointmentDto.Requests
{
    public class AppointmentRequestDto
    {
        public Guid PatientId { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; } 
        public string DoctorName { get; set; }  
    }
}

