using AutoMapper;
using HospitalManagement.Models.Dtos.AppointmentDto.Requests;
using HospitalManagement.Models.Dtos.DoctorDto.Requests;
using HospitalManagement.Models.Dtos.PatientDto.Requests;
using HospitalManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DoctorRequestDto, Doctor>()
            .ReverseMap();

        CreateMap<AppointmentRequestDto, Appointment>()
            .ReverseMap();

        CreateMap<PatientRequestDto, Patient>()
            .ReverseMap();
    }
}
