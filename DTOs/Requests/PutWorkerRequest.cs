using AccountsService.Utilities.ValidationAttributes;

namespace AccountsService.DTOs.Requests
{
    public class PutWorkerRequest
    {
        [WorkerValidation]
        public int NIC { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? job_role { get; set; }

    }
}
