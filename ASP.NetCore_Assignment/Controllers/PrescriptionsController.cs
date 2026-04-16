using Asp.net_Core_Assignment_1.Models;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Asp.net_Core_Assignment_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly PrescriptionService _prescriptionService;

        public PrescriptionsController(PrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] Prescription prescription)
        {
            var result = await _prescriptionService.AddPrescriptionAsync(prescription);
            return Ok(result);
        }

        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetPrescriptionByAppointmentId(int appointmentId)
        {
            var result = await _prescriptionService.GetPrescriptionByAppointmentIdAsync(appointmentId);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
