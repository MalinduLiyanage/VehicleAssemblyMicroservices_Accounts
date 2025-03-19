using AccountsService.DTOs;

namespace AccountsService.Services.InternalAccountsService
{
    public interface IInternalAccountsService
    {
        public VehicleDTO GetVehicleById(int id);
        public Task<WorkerDTO> GetWorkerById(int id);
    }
}
