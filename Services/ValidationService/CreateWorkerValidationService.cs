using AccountsService.DTOs;
using AccountsService.DTOs.Requests;

namespace AccountsService.Services.ValidationService
{
    public class CreateWorkerValidationService : ICreateWorkerValidationService
    {
        private readonly ApplicationDbContext context;

        public CreateWorkerValidationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<string> Validate(PutWorkerRequest request)
        {
            List<string> errors = new List<string>();

            if (context.workers.Any(v => v.NIC == request.NIC))
            {
                errors.Add("The NIC is already registered!");
            }

            if (context.workers.Any(v => v.email == request.email))
            {
                errors.Add("The Email is already registered!");
            }

            return errors;
        }
    }
}
