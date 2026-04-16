using Asp.net_Core_Assignment_1.Models;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
            => await _patientRepository.CreatePatientAsync(patient);

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
            => await _patientRepository.GetAllPatientsAsync();

        public async Task<Patient> GetPatientByIdAsync(int id)
            => await _patientRepository.GetPatientByIdAsync(id);

        public async Task UpdatePatientAsync(Patient patient)
            => await _patientRepository.UpdatePatientAsync(patient);

        public async Task DeletePatientAsync(int id)
            => await _patientRepository.DeletePatientAsync(id);
    }
}
