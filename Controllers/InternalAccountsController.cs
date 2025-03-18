﻿using AccountsService.Services.InternalAccountsService;
using Microsoft.AspNetCore.Mvc;

namespace AccountsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalAccountsController : ControllerBase
    {
        private readonly IInternalAccountsService internalAccountsService;

        public InternalAccountsController(IInternalAccountsService internalAccountsService)
        {
            this.internalAccountsService = internalAccountsService;
        }

        [HttpPost("vehicle/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var result = internalAccountsService.GetVehicleById(id);

            if (result == null)
            {
                return NotFound(new { message = "Vehicle not found" });
            }

            return Ok(result);
        }

        [HttpPost("worker/{id}")]
        public IActionResult GetWorkerById(int id)
        {
            var result = internalAccountsService.GetWorkerById(id);

            if (result == null)
            {
                return NotFound(new { message = "Worker not found" });
            }

            return Ok(result);
        }
    }
}
