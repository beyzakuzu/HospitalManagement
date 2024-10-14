using AutoMapper;
using HospitalManagement.Models.Dtos.DoctorDto.Requests;
using HospitalManagement.Models.Dtos.DoctorDto.Responses;
using HospitalManagement.Models.Entities;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models.Dtos.AppointmentDto.Responses;
using HospitalManagement.Models.Dtos.PatientDto.Responses;
using HospitalManagement.Service.Exceptions;
using HospitalManagement.Service.Validations;

namespace HospitalManagement.Service.Concretes;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public ResponseModel<DoctorResponseDto> CreateDoctor(DoctorRequestDto request)
    {
        DoctorValidator.Validate(request);

        var doctorEntity = _mapper.Map<Doctor>(request);
        var addedDoctor = _doctorRepository.Add(doctorEntity);
        var doctorResponseDto = _mapper.Map<DoctorResponseDto>(addedDoctor);

        return new ResponseModel<DoctorResponseDto>
        {
            Success = true,
            Message = "Doktor başarıyla oluşturuldu.",
            Data = doctorResponseDto
        };
    }

    public ResponseModel<List<DoctorResponseDto>> GetAllDoctors()
    {
        var doctors = _doctorRepository.GetAll();
        var doctorResponseDtos = _mapper.Map<List<DoctorResponseDto>>(doctors);

        return new ResponseModel<List<DoctorResponseDto>>
        {
            Success = true,
            Message = "Doktorlar başarıyla getirildi.",
            Data = doctorResponseDtos
        };
    }

    public ResponseModel<DoctorResponseDto> GetDoctorById(int id)
    {
        var doctor = _doctorRepository.GetById(id);
        if (doctor == null)
        {
            return new ResponseModel<DoctorResponseDto>
            {
                Success = false,
                Message = "Doktor bulunamadı.",
                Data = null
            };
        }

        var doctorResponseDto = _mapper.Map<DoctorResponseDto>(doctor);
        return new ResponseModel<DoctorResponseDto>
        {
            Success = true,
            Message = "Doktor başarıyla getirildi.",
            Data = doctorResponseDto
        };
    }

    public ResponseModel<bool> DeleteDoctor(int id)
    {
        var doctor = _doctorRepository.GetById(id);
        if (doctor == null)
        {
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "Doktor bulunamadı.",
                Data = false
            };
        }

        _doctorRepository.Remove(doctor);

        return new ResponseModel<bool>
        {
            Success = true,
            Message = "Doktor başarıyla silindi.",
            Data = true
        };
    }

    public ResponseModel<DoctorResponseDto> UpdateDoctor(int id, DoctorRequestDto request)
    {
        DoctorValidator.Validate(request);

        var doctor = _doctorRepository.GetById(id);
        if (doctor == null)
        {
            return new ResponseModel<DoctorResponseDto>
            {
                Success = false,
                Message = "Doktor bulunamadı.",
                Data = null
            };
        }

        doctor.Name = request.Name;
        doctor.Branch = request.Branch;

        var updatedDoctor = _doctorRepository.Update(doctor);
        var doctorResponseDto = _mapper.Map<DoctorResponseDto>(updatedDoctor);

        return new ResponseModel<DoctorResponseDto>
        {
            Success = true,
            Message = "Doktor başarıyla güncellendi.",
            Data = doctorResponseDto
        };
    }
}