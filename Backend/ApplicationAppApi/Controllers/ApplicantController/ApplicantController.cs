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

        [HttpPost("Applicants", Name = "CreateApplicantAccount")]
        public async Task<IActionResult> CreateApplicantAccount([FromBody] ApplicantModel applicantModel)
        {
            if (await _applicantService.CreateApplicantAccount(applicantModel))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
