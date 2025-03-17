using AccountsService.DTOs.Requests;
using AccountsService.DTOs.Responses;
using AccountsService.Services.VehicleService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpPost("get-all")]
        public BaseResponse VehicleList()
        {
            return vehicleService.GetVehicles();
        }

        [HttpPost("register")]
        public BaseResponse AddVehicle(PutVehicleRequest request)
        {
            return vehicleService.PutVehicles(request);
        }
    }
}
