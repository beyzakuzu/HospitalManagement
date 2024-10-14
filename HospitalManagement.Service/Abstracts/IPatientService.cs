using HospitalManagement.Models.Dtos.PatientDto.Requests;
using HospitalManagement.Models.Dtos.PatientDto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Service.Concretes;


namespace HospitalManagement.Service.Abstracts;

public interface IPatientService
{
    ResponseModel<PatientResponseDto> AddPatient(PatientRequestDto patientRequestDto);
    ResponseModel<PatientResponseDto?> GetPatientById(Guid patientId);
    ResponseModel<List<PatientResponseDto>> GetAllPatients();
    ResponseModel<PatientResponseDto> UpdatePatient(Guid patientId, PatientRequestDto patientRequestDto);
    ResponseModel<string> DeletePatient(Guid patientId);
}
