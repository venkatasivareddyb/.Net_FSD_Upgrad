using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private static List<object> passengers = new()
    {
        new { passengerId = 201, name = "John Doe", age = 30 }
    };

        [HttpGet]
        public IActionResult GetPassengers() => Ok(passengers);

        [HttpPost]
        public IActionResult AddPassenger([FromBody] object passenger)
        {
            passengers.Add(passenger);
            return Ok(passenger);
        }
    }
}
