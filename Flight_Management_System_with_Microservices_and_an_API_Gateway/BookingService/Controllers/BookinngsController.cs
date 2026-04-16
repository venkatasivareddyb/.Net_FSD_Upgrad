using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookinngsController : ControllerBase
    {
        private static List<object> bookings = new()
    {
        new { bookingId = 101, flightId = 1, passengerId = 201 }
    };

        [HttpGet]
        public IActionResult GetBookings() => Ok(bookings);

        [HttpPost]
        public IActionResult AddBooking([FromBody] object booking)
        {
            bookings.Add(booking);
            return Ok(booking);
        }
    }
}
