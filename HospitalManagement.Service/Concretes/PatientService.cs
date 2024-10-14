using AutoMapper;
using HospitalManagement.DataAccess.Abstracts;
using HospitalManagement.Models.Dtos.AppointmentDto.Responses;
using HospitalManagement.Models.Dtos.PatientDto.Requests;
using HospitalManagement.Models.Dtos.PatientDto.Responses;
using HospitalManagement.Models.Entities;
using HospitalManagement.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Concretes;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper; 

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public ResponseModel<PatientResponseDto> AddPatient(PatientRequestDto patientRequestDto)
    {
        var patientEntity = _mapper.Map<Patient>(patientRequestDto);
        var addedPatient = _patientRepository.Add(patientEntity);
        var patientResponseDto = _mapper.Map<PatientResponseDto>(addedPatient);

        return new ResponseModel<PatientResponseDto>
        {
            Success = true,
            Message = "Hasta başarıyla eklendi.",
            Data = patientResponseDto
        };
    }

    public ResponseModel<PatientResponseDto?> GetPatientById(Guid patientId)
    {
        var patient = _patientRepository.GetById(patientId);
        if (patient == null)
        {
            return new ResponseModel<PatientResponseDto?>
            {
                Success = false,
                Message = "Hasta bulunamadı.",
                Data = null
            };
        }

        var patientResponseDto = _mapper.Map<PatientResponseDto>(patient);
        return new ResponseModel<PatientResponseDto?>
        {
            Success = true,
            Message = "Hasta başarıyla getirildi.",
            Data = patientResponseDto
        };
    }

    public ResponseModel<List<PatientResponseDto>> GetAllPatients()
    {
        var patients = _patientRepository.GetAll();
        var patientResponseDtos = _mapper.Map<List<PatientResponseDto>>(patients);

        return new ResponseModel<List<PatientResponseDto>>
        {
            Success = true,
            Message = "Hastalar başarıyla getirildi.",
            Data = patientResponseDtos
        };
    }

    public ResponseModel<PatientResponseDto> UpdatePatient(Guid patientId, PatientRequestDto patientRequestDto)
    {
        var existingPatient = _patientRepository.GetById(patientId);
        if (existingPatient == null)
        {
            return new ResponseModel<PatientResponseDto>
            {
                Success = false,
                Message = "Hasta bulunamadı.",
                Data = null
            };
        }

        var patientEntity = _mapper.Map(patientRequestDto, existingPatient);
        var updatedPatient = _patientRepository.Update(patientEntity);
        var patientResponseDto = _mapper.Map<PatientResponseDto>(updatedPatient);

        return new ResponseModel<PatientResponseDto>
        {
            Success = true,
            Message = "Hasta başarıyla güncellendi.",
            Data = patientResponseDto
        };
    }

    public ResponseModel<string> DeletePatient(Guid patientId)
    {
        var patient = _patientRepository.GetById(patientId);
        if (patient == null)
        {
            return new ResponseModel<string>
            {
                Success = false,
                Message = "Hasta bulunamadı.",
                Data = "Silme işlemi başarısız oldu."
            };
        }

        _patientRepository.Remove(patient);

        return new ResponseModel<string>
        {
            Success = true,
            Message = "Hasta başarıyla silindi.",
            Data = "Hasta silme işlemi başarıyla tamamlandı."
        };
    }
}