using Asp.net_Core_Assignment_1.Data;
using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealthcareDbContext _context;

        public DoctorRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
            => await _context.Doctors.ToListAsync();

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization)
            => await _context.Doctors.Where(d => d.Specialization == specialization).ToListAsync();
    }

}
