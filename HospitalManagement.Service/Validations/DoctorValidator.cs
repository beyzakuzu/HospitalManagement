using HospitalManagement.Models.Dtos.DoctorDto.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Validations
{
    public static class DoctorValidator
    {
        public static void Validate(DoctorRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Doktor adı boş olamaz.");
            }
        }
    }
}
