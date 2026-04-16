using Asp.net_Core_Assignment_1.Data;
using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthcareDbContext _context;

        public AppointmentRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> BookAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
            => await _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
            => await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();

        public async Task CancelAppointmentAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                appointment.Status = "Cancelled";
                await _context.SaveChangesAsync();
            }
        }
    }

}
