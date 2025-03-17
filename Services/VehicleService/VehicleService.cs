using AccountsService.DTOs.Requests;
using AccountsService.DTOs;
using AccountsService.Models;
using AccountsService;
using AccountsService.DTOs.Responses;

namespace AccountsService.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext context;

        public VehicleService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public BaseResponse GetVehicles()
        {
            BaseResponse response;
            try
            {
                List<VehicleDTO> vehicles = new List<VehicleDTO>();

                using (context)
                {
                    context.vehicles.ToList().ForEach(vehicle => vehicles.Add(new VehicleDTO
                    {
                        vehicle_id = vehicle.vehicle_id,
                        model = vehicle.model,
                        color = vehicle.color,
                        engine = vehicle.engine,
                    }));
                }
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { vehicles }
                };
                return response;
            }
            catch (Exception e)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error" + e.Message }
                };
                return response;

            }
        }

        public BaseResponse PutVehicles(PutVehicleRequest request)
        {
            BaseResponse response;
            try
            {
                VehicleModel newVehicle = new VehicleModel();
                newVehicle.model = request.model;
                newVehicle.color = request.color;
                newVehicle.engine = request.engine;


                using (context)
                {
                    context.Add(newVehicle);
                    context.SaveChanges();
                }
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created a Vehicle Record" }
                };
                return response;
            }
            catch (Exception e)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error" + e.Message }
                };
                return response;

            }
        }
    }
}
