using ApplicationAppApi.Models.ApplicantModel;
using ApplicationAppApi.Services.Applicant.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationAppApi.Controllers.ApplicantController
{
    [Route("/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    { 
        private readonly IApplicant _applicantService;

        public ApplicantController( IApplicant applicant)
        {
            _applicantService = applicant;
        }

        [HttpPost("Create", Name = "CreateApplicantAccount")]
        public async Task<IActionResult> CreateApplicantAccount([FromBody] ApplicantModel applicantModel)
        {
            if (await _applicantService.CreateApplicantAccount(applicantModel))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("Get", Name = "GetApplicantData")]
        public async Task<IActionResult> GetApplicantData([FromQuery] int albumNumber)
        {
            var applicantData = await _applicantService.GetApplicantData(albumNumber);
            if (applicantData != null)
            {
                return Ok(applicantData);

            }
            return BadRequest();
        }
    }
}
