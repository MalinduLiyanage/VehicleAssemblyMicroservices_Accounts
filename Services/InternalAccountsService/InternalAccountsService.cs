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

        public async Task<WorkerDTO> GetWorkerById(int id)
        {
            try
            {
                var worker = await context.workers
                    .Where(a => a.NIC == id)
                    .Select(a => new WorkerDTO
                    {
                        NIC = a.NIC,
                        firstname = a.firstname,
                        lastname = a.lastname,
                        email = a.email,
                        address = a.address,
                        job_role = a.job_role,
                        Assemblies = new List<AssembleDTO>()  // Initialize the Assemblies list
                    })
                    .FirstOrDefaultAsync();  // Use FirstOrDefaultAsync for async database access

                if (worker != null)
                {
                    // Fetch assemblies asynchronously
                    var assemblies = await communicationClientUtility.GetWorkerAssemblyData(id);

                    if (assemblies != null && assemblies.Any())
                    {
                        worker.Assemblies = assemblies;  // Populate Assemblies if available
                    }

                    return worker;
                }

                return null;  // Return null if worker not found
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                return null;  // Return null on error
            }
        }



    }
}
