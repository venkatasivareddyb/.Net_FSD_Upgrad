using Asp.net_Core_Assignment_1.Models;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<Prescription> AddPrescriptionAsync(Prescription prescription)
            => await _prescriptionRepository.AddPrescriptionAsync(prescription);

        public async Task<Prescription> GetPrescriptionByAppointmentIdAsync(int appointmentId)
            => await _prescriptionRepository.GetPrescriptionByAppointmentIdAsync(appointmentId);
    }
}
