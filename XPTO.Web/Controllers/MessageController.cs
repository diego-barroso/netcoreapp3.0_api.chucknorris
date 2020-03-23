using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XPTO.Web.Client;

namespace XPTO.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices]MessageClient messageClient, string category)
        {
            return View(messageClient.GetMessage(category));
        }
    }
}