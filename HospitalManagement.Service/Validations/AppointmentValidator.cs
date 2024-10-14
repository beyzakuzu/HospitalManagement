using HospitalManagement.Models.Dtos.AppointmentDto.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Validations
{
    public static class AppointmentValidator
    {
        public static void Validate(AppointmentRequestDto request)
        {
            if (request.PatientId == Guid.Empty || request.DoctorId <= 0)
            {
                throw new ValidationException("Doktor ve hasta bilgileri geçerli olmalıdır.");
            }

            if (request.AppointmentDate < DateTime.Now.AddDays(3))
            {
                throw new ValidationException("Randevu tarihi en az 3 gün sonrası olmalıdır.");
            }
            if (string.IsNullOrWhiteSpace(request.PatientName))
            {
                throw new ValidationException("Hasta ismi boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(request.DoctorName))
            {
                throw new ValidationException("Doktor ismi boş olamaz.");
            }
        }
    }
}
