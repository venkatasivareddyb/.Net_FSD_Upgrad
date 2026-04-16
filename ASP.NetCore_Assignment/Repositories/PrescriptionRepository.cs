using Asp.net_Core_Assignment_1.Data;
using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HealthcareDbContext _context;

        public PrescriptionRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Prescription> AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> GetPrescriptionByAppointmentIdAsync(int appointmentId)
            => await _context.Prescriptions.FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);
    }

}
