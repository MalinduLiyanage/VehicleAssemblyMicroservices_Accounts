using AccountsService.DTOs.Requests;
using AccountsService.DTOs.Responses;

namespace AccountsService.Services.VehicleService
{
    public interface IVehicleService
    {
        BaseResponse GetVehicles();

        BaseResponse PutVehicles(PutVehicleRequest request);
    }
}
