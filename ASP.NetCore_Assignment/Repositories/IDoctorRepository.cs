using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization);
    }

}
