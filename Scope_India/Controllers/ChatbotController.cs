using Microsoft.AspNetCore.Mvc;
using Scope_India.DAL;

namespace Scope_India.Controllers
{
    public class ChatbotController : Controller
    {
        private readonly IChatbotService _chatbot;

        public ChatbotController(IChatbotService chatbot)
        {
            _chatbot = chatbot;
        }

        [HttpPost]
        public IActionResult Ask([FromBody] ChatRequest request)
        {
            var answer = _chatbot.GetAnswer(request.Message);
            return Json(new { answer });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}