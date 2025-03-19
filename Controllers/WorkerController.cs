using AccountsService.DTOs.Requests;
using AccountsService.DTOs.Responses;
using AccountsService.Services.WorkerService;
using Microsoft.AspNetCore.Mvc;

namespace AccountsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService workerService;

        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpPost("get-all")]
        public BaseResponse WorkerList()
        {
            return workerService.GetWorkers();
        }

        [HttpPost("register")]
        public BaseResponse AddWorker(PutWorkerRequest request)
        {
            return workerService.PutWorker(request);
        }
    }
}
