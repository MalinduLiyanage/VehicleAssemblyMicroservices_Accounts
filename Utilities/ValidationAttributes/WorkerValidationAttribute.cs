using System.ComponentModel.DataAnnotations;
using AccountsService.DTOs.Requests;
using AccountsService.Services.ValidationService;

namespace AccountsService.Utilities.ValidationAttributes
{
    public class WorkerValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var request = (PutWorkerRequest)validationContext.ObjectInstance;

            if (request.NIC <= 0 || request.firstname == null || request.lastname == null || request.email == null || request.address == null || request.job_role == null)
            {
                return new ValidationResult("All fields are required.");
            }

            ICreateWorkerValidationService? validationService = validationContext.GetService(typeof(ICreateWorkerValidationService)) as ICreateWorkerValidationService;

            if (validationService == null)
            {
                return new ValidationResult("Validation service is unavailable.");
            }

            var validationErrors = validationService.Validate(request);

            if (validationErrors.Any())
            {
                return new ValidationResult(string.Join("; ", validationErrors));
            }

            return ValidationResult.Success;
        }
    }
}
