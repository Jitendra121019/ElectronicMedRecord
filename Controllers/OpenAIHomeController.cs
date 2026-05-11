using ElectronicMedRecord.Models;
using ElectronicMedRecord.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicMedRecord.Controllers
{
    public class OpenAIHomeController : Controller
    {
        private readonly OpenAIService _openAIService;

        public OpenAIHomeController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Suggest([FromBody] SuggestionRequest request)
        {
            var suggestion = await _openAIService.GetSuggestion(request.Prompt);

            return Json(new { suggestion });
        }
    }
}
