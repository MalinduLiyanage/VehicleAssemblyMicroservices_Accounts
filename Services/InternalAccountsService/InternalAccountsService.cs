using AccountsService.DTOs;

namespace AccountsService.Services.InternalAccountsService
{
    public class InternalAccountsService : IInternalAccountsService
    {
        private readonly ApplicationDbContext context;

        public InternalAccountsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public VehicleDTO GetVehicleById(int id)
        {
            try
            {
                var vehicle = context.vehicles
                    .Where(a => a.vehicle_id == id)
                    .Select(a => new VehicleDTO
                    {
                        vehicle_id = a.vehicle_id,
                        color = a.color,
                        model = a.model,
                    })
                    .FirstOrDefault();

                if (vehicle != null)
                {
                    return vehicle;
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public WorkerDTO GetWorkerById(int id)
        {
            try
            {
                var worker = context.workers
                    .Where(a => a.NIC == id)
                    .Select(a => new WorkerDTO
                    {
                        NIC = a.NIC,
                        firstname = a.firstname,
                        lastname = a.lastname,
                        email = a.email,
                        address = a.address,
                        job_role = a.job_role,
                    })
                    .FirstOrDefault();

                if (worker != null)
                {
                    return worker;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
