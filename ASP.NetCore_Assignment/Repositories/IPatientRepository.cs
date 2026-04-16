using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }

}
