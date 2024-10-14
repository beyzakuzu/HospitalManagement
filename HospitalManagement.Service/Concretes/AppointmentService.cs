using AutoMapper;
using HospitalManagement.DataAccess.Abstracts;
using HospitalManagement.DataAccess.Concretes;
using HospitalManagement.Models.Dtos.AppointmentDto.Requests;
using HospitalManagement.Models.Dtos.AppointmentDto.Responses;
using HospitalManagement.Models.Entities;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Concretes;
using HospitalManagement.Service.Exceptions;
using HospitalManagement.Service.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IMapper mapper, IPatientRepository patientRepository)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _patientRepository = patientRepository;
    }

    public ResponseModel<AppointmentResponseDto> CreateAppointment(AppointmentRequestDto request)
    {
        if (request == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Randevu bilgileri null olamaz.",
                Data = null
            };
        }

        
        AppointmentValidator.Validate(request);

      
        var doctor = _doctorRepository.GetById(request.DoctorId);
        if (doctor == null)
        {
            throw new NotFoundException("Doktor bulunamadı.");
        }

        
        if (doctor.Appointments == null)
        {
            doctor.Appointments = new List<Appointment>();
        }

        if (doctor.Appointments.Count >= 10)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Bu doktor için maksimum randevu sayısına ulaşıldı.",
                Data = null
            };
        }

        
        var patient = _patientRepository.GetById(request.PatientId);
        if (patient == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Hasta bulunamadı.",
                Data = null
            };
        }

       
        var appointmentEntity = _mapper.Map<Appointment>(request);
        appointmentEntity.PatientId = patient.Id;

        var addedAppointment = _appointmentRepository.Add(appointmentEntity);
        if (addedAppointment == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Randevu eklenemedi.",
                Data = null
            };
        }

        var appointmentResponseDto = _mapper.Map<AppointmentResponseDto>(addedAppointment);
        if (appointmentResponseDto == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Randevu bilgileri alınamadı.",
                Data = null
            };
        }

        return new ResponseModel<AppointmentResponseDto>
        {
            Success = true,
            Message = "Randevu başarıyla oluşturuldu.",
            Data = appointmentResponseDto
        };
    }
    public ResponseModel<AppointmentResponseDto> GetAppointmentById(int id)
    {
        var appointment = _appointmentRepository.GetById(id);
        if (appointment == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Randevu bulunamadı.",
                Data = null
            };
        }

        var appointmentResponseDto = _mapper.Map<AppointmentResponseDto>(appointment);
        return new ResponseModel<AppointmentResponseDto>
        {
            Success = true,
            Message = "Randevu başarıyla getirildi.",
            Data = appointmentResponseDto
        };
    }

    public ResponseModel<bool> DeleteAppointment(int id)
    {
        var appointment = _appointmentRepository.GetById(id);
        if (appointment == null)
        {
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "Randevu bulunamadı.",
                Data = false
            };
        }

        _appointmentRepository.Remove(appointment);

        return new ResponseModel<bool>
        {
            Success = true,
            Message = "Randevu başarıyla silindi.",
            Data = true
        };
    }

    public ResponseModel<AppointmentResponseDto> UpdateAppointment(int id, AppointmentRequestDto request)
    {
        AppointmentValidator.Validate(request);

        var appointment = _appointmentRepository.GetById(id);
        if (appointment == null)
        {
            return new ResponseModel<AppointmentResponseDto>
            {
                Success = false,
                Message = "Randevu bulunamadı.",
                Data = null
            };
        }

        appointment.AppointmentDate = request.AppointmentDate;
        appointment.DoctorId = request.DoctorId;
        appointment.PatientId = request.PatientId;

        var updatedAppointment = _appointmentRepository.Update(appointment);
        var appointmentResponseDto = _mapper.Map<AppointmentResponseDto>(updatedAppointment);

        return new ResponseModel<AppointmentResponseDto>
        {
            Success = true,
            Message = "Randevu başarıyla güncellendi.",
            Data = appointmentResponseDto
        };
    }

    public void DeletePastAppointments()
    {
        var pastAppointments = _appointmentRepository.GetPastAppointments();
        foreach (var appointment in pastAppointments)
        {
            _appointmentRepository.Remove(appointment); 
        }
    }

    public ResponseModel<List<AppointmentResponseDto>> GetAllAppointments()
    {
        var appointments = _appointmentRepository.GetAll(); 
        var appointmentResponseDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments); 

        return new ResponseModel<List<AppointmentResponseDto>>
        {
            Success = true,
            Message = "Randevular başarıyla getirildi.",
            Data = appointmentResponseDtos
        };
    }
}