using ApplicationAppApi.Models.ApplicationModel;
using ApplicationAppApi.Services.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationAppApi.Controllers.ApplicationController
{
    [Route("/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplication _application;
        public ApplicationController(IApplication application)
        {
                _application = application;
        }

        [HttpPost("Create", Name = " CreateApplicationText")]
        public async Task<IActionResult> CreateApplicationText([FromBody] ApplicationModel applicationModel)
        {
            if (await _application.CreateApplicationText(applicationModel))
            {
                return Ok();
            } 
            return BadRequest();

        }
    }
}
