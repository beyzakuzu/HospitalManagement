using HospitalManagement.Models.Dtos.AppointmentDto.Requests;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Concretes;
using HospitalManagement.Service.Exceptions;
using HospitalManagement.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HospitalManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AppointmentRequestDto request)
        {
            try
            {
                AppointmentValidator.Validate(request);
                var result = _appointmentService.CreateAppointment(request);

                if (result.Success)
                {
                    return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
                }
                return BadRequest(result.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _appointmentService.GetAppointmentById(id);

                if (result.Success)
                {
                    return Ok(result);
                }
                return NotFound(result.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _appointmentService.GetAllAppointments();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _appointmentService.DeleteAppointment(id);

                if (result.Success)
                {
                    return NoContent();
                }
                return NotFound(result.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AppointmentRequestDto request)
        {
            try
            {
                AppointmentValidator.Validate(request);
                var result = _appointmentService.UpdateAppointment(id, request);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("past")]
        public IActionResult DeletePastAppointments()
        {
            try
            {
                _appointmentService.DeletePastAppointments();
                return Ok(new { Message = "Geçmiş randevular başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}