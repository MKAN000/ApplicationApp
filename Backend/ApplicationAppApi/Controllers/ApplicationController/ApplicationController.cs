using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Models.Application.DTO;
using ApplicationAppApi.Services.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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

        [HttpGet("GenerateTextFiles")]
        public async Task <IActionResult> GenerateTextFiles(string filePath, int id)
        {
            await _application.CreateFilePath(filePath,id);

            return Ok();
        }

        [HttpPost("PDF")]
        public async Task<ActionResult> GeneratePdf(int applicationId)
        {
            DateTime currentDate = DateTime.Now;

            string formattedDate = currentDate.ToString("dd.MM.yyyy");


            var applicationTextToGenerate = await _application.GeneratePdf(applicationId);

            applicationTextToGenerate.OrderDate = applicationTextToGenerate.OrderDate.Replace("-", ".");
            applicationTextToGenerate.StartDate = applicationTextToGenerate.StartDate.Replace("-", ".");
            applicationTextToGenerate.EndDate = applicationTextToGenerate.EndDate.Replace("-", ".");


            var data = new PdfDocument();
            var htmlContent = "<div style='margin: auto; max-width: 600px; padding: 20px; background-color: #FFFFFF; font-family: Arial, sans-serif; font-size: 12px;'>";
            htmlContent += $"<span style='margin: 0; text-align: left;'>{applicationTextToGenerate.Rank}, {applicationTextToGenerate.Name} {applicationTextToGenerate.Surname} <span style='text-align: right;'>Warszawa, {formattedDate}</span></span>";

            htmlContent += $"<p style = 'margin: 0;' >{applicationTextToGenerate.Subdivision}</p>";
            htmlContent += $"<p style = 'margin: 0;' >{applicationTextToGenerate.FacultyGroup}</p>";

            htmlContent += "<div style='margin-bottom: 20px; text-align: left;'>";
            htmlContent += $"<p style='text-indent: 2cm; font-size: 12px;'><b>{applicationTextToGenerate.ToWhom}</b></p>";
            htmlContent += "</div>";

            htmlContent += $"<p style='font-size: 10px;'> <b><i>Dotyczy:</i></b> <i>{applicationTextToGenerate.ApplicationPurpose}</i></p>";
            htmlContent += $"<p style='text-indent: 1cm;'>Szanowny Panie Pułkowniku,</p>";

            htmlContent += $"<p style='text-align: justify;'> Proszę o umożliwienie " +
                            $"{applicationTextToGenerate.ApplicationPurpose.ToLower()} udzielonego mi w rozkazie dziennym " +
                            $"{applicationTextToGenerate.SupervisorRank} {applicationTextToGenerate.Origin} nr. {applicationTextToGenerate.OrderNo}" +
                            $" z dnia {applicationTextToGenerate.OrderDate} w dniach {applicationTextToGenerate.StartDate} - {applicationTextToGenerate.EndDate}." +
                            $" Wniosek swój motywuję {applicationTextToGenerate.Reason}.</p>";

            if (applicationTextToGenerate.IsOnDuty == "true")
            {
            }
            else
            {
                htmlContent += $"<p style='text-align: justify;'>    Melduję, ze w w/w terminie nie jestem wyznaczony do pełnienia służby, " +
                    $"posiadam zaległości w nauce ({applicationTextToGenerate.arrears}) ,";
            }

            if (applicationTextToGenerate.IsHavingClasses == "true")
            {
            }
            else
            {
                htmlContent += $"    nie mam zajęć programowych, ";
            }

            if (applicationTextToGenerate.IsHavingDisciplinaryPenalty == "true")
            {
            }
            else
            {
                htmlContent += $"    oraz nie posiadam kar dyscyplinarnych.</p>";
            }

            htmlContent += $"<p>Na urlop udam się do {applicationTextToGenerate.VacDestination}.</p>";
            htmlContent += $"<p>Proszę o pozytywne rozpatrzenie mojego wnioksu.</p>";
            htmlContent += $"<p style='text-align: right;'>Z poważaniem</p>";


            htmlContent += "</div>";


            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A5);

            byte[]? response = null;

            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }

            var fileName = "Nagrodówka.pdf";

            return File(response, "application/pdf", fileName);
        }


    }
}
