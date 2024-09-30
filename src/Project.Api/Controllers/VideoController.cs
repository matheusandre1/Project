using Microsoft.AspNetCore.Mvc;
using Project.Api.Services;

namespace Project.Api.Controllers
{
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;

        private readonly VideoService _videoService;

        public VideoController(ILogger<VideoController> logger, VideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;                           
        }
    }
}
