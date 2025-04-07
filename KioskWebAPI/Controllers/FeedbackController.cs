using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        [Route("SaveFeedback")]
        public async Task<KioskResponse> SaveFeedback(FeedbackSaveModel item)
        {
            var scrnItem = await _feedbackService.SaveFeedback(item);
            return scrnItem;
        }
    }
}
