using AccountsService.DTOs;
using AccountsService.DTOs.Requests;

namespace AccountsService.Services.ValidationService
{
    public interface ICreateWorkerValidationService
    {
        List<string> Validate(PutWorkerRequest request);
    }
}
