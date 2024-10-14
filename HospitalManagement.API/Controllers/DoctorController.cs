using HospitalManagement.Models.Dtos.DoctorDto.Requests;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Exceptions;
using HospitalManagement.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using static HospitalManagement.Service.Abstracts.IDoctorService;

namespace HospitalManagement.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] DoctorRequestDto request)
        {
            try
            {
                DoctorValidator.Validate(request);
                var result = _doctorService.CreateDoctor(request);

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
                var result = _doctorService.GetDoctorById(id);

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
            var result = _doctorService.GetAllDoctors();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _doctorService.DeleteDoctor(id);

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
        public IActionResult Update(int id, [FromBody] DoctorRequestDto request)
        {
            try
            {
                DoctorValidator.Validate(request);
                var result = _doctorService.UpdateDoctor(id, request);

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
    }
}

