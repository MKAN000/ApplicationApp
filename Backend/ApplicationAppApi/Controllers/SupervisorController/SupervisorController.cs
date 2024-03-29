using ApplicationAppApi.Models.SupervisorModel;
using ApplicationAppApi.Services.Supervisor.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationAppApi.Controllers.SupervisorController
{
    [Route("/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisor _supervisorService;
        public SupervisorController(ISupervisor supervisor)
        {
            _supervisorService = supervisor;
        }

        [HttpPost("Create",Name = "CreateSupervisorOrder")]
        public async Task<IActionResult> CreateSupervisorOrder([FromBody]SupervisorModel supervisorModel)
        {
            if (await _supervisorService.CreateSupervisorOrder(supervisorModel))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Get",Name ="GetSupervisorOrderDetails")]
        public async Task<IActionResult> GetSupervisorOrderDetails([FromHeader]string orderNo)
        {
            var supervisorOrderDetails = await _supervisorService.GetSupervisorOrderDetails(orderNo);
            if (supervisorOrderDetails != null)
            {
                return Ok(supervisorOrderDetails);
            }
            return BadRequest();
        }

    }
}
