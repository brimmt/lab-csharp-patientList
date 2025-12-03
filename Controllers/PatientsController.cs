using Microsoft.AspNetCore.Mvc;
using patientAPI.Models;
using patientAPI.Services;


namespace patientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsService _service;

        public PatientsController(PatientsService service)
        {
            _service = service;
        }

        // Get /api/patients
        [HttpGet]
        public ActionResult<List<Patient>> GetAll()
        {
            var patients = _service.GetAll();
            return Ok(patients);
        }

        // Get /api/patients/1
        [HttpGet("{id:int}")]
        public ActionResult<Patient> GetById(int id)
        {
            var patient = _service.GetById(id);
            if (patient is null)
                return NotFound();
            return Ok(patient);
        }

        // POST /api/patients

        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {
            var created = _service.Add(patient);
            return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);
        }
        
        
        // PUT /api/patients/id
        [HttpPut("{id:int}")]
        public ActionResult<Patient> Update(int id, Patient patient)
        {
            if (id != patient.Id)
                return BadRequest();

            var updated = _service.Update(patient);
            if (updated is null)
                return NotFound();
            return Ok(updated);
        }



        // Delete /api/patients/id
        [HttpDelete("{id:int}")]
        public ActionResult<Patient> Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

    }
}