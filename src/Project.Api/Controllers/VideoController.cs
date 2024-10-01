using Microsoft.AspNetCore.Mvc;
using Project.Api.Entities.ViewModels;
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

        [HttpGet]
        public ActionResult<List<VideoViewModel>> Get() => _videoService.Get();

        [HttpGet("id:length(24)", Name = "GetVideos")]

        public ActionResult<VideoViewModel> Get(string id)
        {
            var video = _videoService.Get(id);

            if (video is null)
            {
                return NotFound();
            }

            return Ok(video);
        }
        [HttpPost]
        public ActionResult<VideoViewModel> Create(VideoViewModel video)
        {
            var result = _videoService.Create(video);

            return CreatedAtRoute("VideoNews", new { id = result.Id.ToString() }, result);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, VideoViewModel videoIn)
        {
            var video = _videoService.Get(id);

            if (video is null)
            {
                return NotFound();
            }

            _videoService.Update(id, videoIn);

            return CreatedAtRoute("VideoNews", new { id = id }, videoIn);

        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var video = _videoService.Get(id);

            if (video is null)
            {
                return NotFound();
            }

            _videoService.Remove(video.Id);

            var result = new
            {
                message = "Video Deletado com Sucesso"
            };

            return Ok();

        }
    }
}
