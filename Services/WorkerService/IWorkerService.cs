using AccountsService.DTOs.Requests;
using AccountsService.DTOs.Responses;

namespace AccountsService.Services.WorkerService
{
    public interface IWorkerService
    {
        BaseResponse GetWorkers();

        BaseResponse PutWorker(PutWorkerRequest request);
    }
}
