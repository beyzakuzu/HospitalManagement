using HospitalManagement.Models.Dtos.DoctorDto.Requests;
using HospitalManagement.Models.Dtos.DoctorDto.Responses;
using HospitalManagement.Service.Concretes;
using System.Collections.Generic;

namespace HospitalManagement.Service.Abstracts;


    public interface IDoctorService
    {
        ResponseModel<DoctorResponseDto> CreateDoctor(DoctorRequestDto request);
        ResponseModel<List<DoctorResponseDto>> GetAllDoctors();
        ResponseModel<DoctorResponseDto> GetDoctorById(int id);
        ResponseModel<bool> DeleteDoctor(int id);
        ResponseModel<DoctorResponseDto> UpdateDoctor(int id, DoctorRequestDto request);
    }



