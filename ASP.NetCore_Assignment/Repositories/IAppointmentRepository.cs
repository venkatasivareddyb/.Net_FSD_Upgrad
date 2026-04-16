using Asp.net_Core_Assignment_1.Models;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> BookAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);
        Task CancelAppointmentAsync(int appointmentId);
    }

}
