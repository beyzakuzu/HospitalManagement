using HospitalManagement.Models.Dtos.AppointmentDto.Requests;
using HospitalManagement.Models.Dtos.AppointmentDto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Service.Concretes;


namespace HospitalManagement.Service.Abstracts;

public interface IAppointmentService
{
    ResponseModel<AppointmentResponseDto> CreateAppointment(AppointmentRequestDto request);
    ResponseModel<List<AppointmentResponseDto>> GetAllAppointments();
    ResponseModel<AppointmentResponseDto> GetAppointmentById(int id);
    ResponseModel<bool> DeleteAppointment(int id);
    ResponseModel<AppointmentResponseDto> UpdateAppointment(int id, AppointmentRequestDto request);

    void DeletePastAppointments();
}
