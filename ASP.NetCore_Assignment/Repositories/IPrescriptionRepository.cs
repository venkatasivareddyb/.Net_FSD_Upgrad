using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<Prescription> AddPrescriptionAsync(Prescription prescription);
        Task<Prescription> GetPrescriptionByAppointmentIdAsync(int appointmentId);
    }

}
