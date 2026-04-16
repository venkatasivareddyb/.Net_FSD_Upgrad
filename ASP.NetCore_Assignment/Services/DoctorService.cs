using Asp.net_Core_Assignment_1.Models;
using Asp.net_Core_Assignment_1.Repositories;


namespace Asp.net_Core_Assignment_1.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
            => await _doctorRepository.AddDoctorAsync(doctor);

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
            => await _doctorRepository.GetAllDoctorsAsync();

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization)
            => await _doctorRepository.GetDoctorsBySpecializationAsync(specialization);
    }
}
