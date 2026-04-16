using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private static List<object> flights = new()
    {
        new { id = 1, flightNumber = "AI101", source = "Hyderabad", destination = "Delhi" }
    };

        [HttpGet]
        public IActionResult GetFlights() => Ok(flights);

        [HttpGet("{id}")]
        public IActionResult GetFlight(int id) => Ok(flights.FirstOrDefault(f => (int)f.GetType().GetProperty("id").GetValue(f) == id));

        [HttpPost]
        public IActionResult AddFlight([FromBody] object flight)
        {
            flights.Add(flight);
            return Ok(flight);
        }
    }
}
