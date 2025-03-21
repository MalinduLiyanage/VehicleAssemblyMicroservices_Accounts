using AccountsService.DTOs;
using AccountsService.Utilities.CommunicationClientUtility;
using Microsoft.EntityFrameworkCore;

namespace AccountsService.Services.InternalAccountsService
{
    public class InternalAccountsService : IInternalAccountsService
    {
        private readonly ApplicationDbContext context;
        private readonly CommunicationClientUtility communicationClientUtility;

        public InternalAccountsService(ApplicationDbContext context, CommunicationClientUtility communicationClientUtility)
        {
            this.context = context;
            this.communicationClientUtility = communicationClientUtility;
        }

        public VehicleDTO GetVehicleById(int id)
        {
            try
            {
                VehicleDTO? vehicle = context.vehicles
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
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<WorkerDTO> GetWorkerById(int id)
        {
            try
            {
                WorkerDTO? worker = await context.workers
                    .Where(a => a.NIC == id)
                    .Select(a => new WorkerDTO
                    {
                        NIC = a.NIC,
                        firstname = a.firstname,
                        lastname = a.lastname,
                        email = a.email,
                        address = a.address,
                        job_role = a.job_role,
                        Assemblies = new List<AssembleDTO>() 
                    })
                    .FirstOrDefaultAsync();  

                if (worker != null)
                {
                    List<AssembleDTO> assemblies = await communicationClientUtility.GetWorkerAssemblyData(id);

                    if (assemblies != null && assemblies.Any())
                    {
                        worker.Assemblies = assemblies;
                    }

                    return worker;
                }

                return null;  
            }
            catch (Exception)
            {
                return null;  
            }
        }



    }
}
