using HospitalManagement.Models.Dtos.PatientDto.Requests;
using HospitalManagement.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] PatientRequestDto patientRequestDto)
        {
            try
            {
                var result = _patientService.AddPatient(patientRequestDto);

                if (result.Success)
                {
                    
                    if (result.Data != null)
                    {
                        return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
                    }
                    else
                    {
                        return BadRequest("Hasta eklendi, ancak ID alınamadı.");
                    }
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _patientService.GetPatientById(id);

                if (result.Success)
                {
                    return Ok(result);
                }
                return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _patientService.GetAllPatients();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PatientRequestDto patientRequestDto)
        {
            try
            {
                var result = _patientService.UpdatePatient(id, patientRequestDto);

                if (result.Success)
                {
                    return Ok(result);
                }
                return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _patientService.DeletePatient(id);

                if (result.Success)
                {
                    return NoContent(); 
                }
                return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}