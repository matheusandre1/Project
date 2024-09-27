using ImageProcessor;
using ImageProcessorCore.Plugins.WebP.Formats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;            
        }

        [HttpPost]
        public IActionResult Post(IFormFile image)
        {
            try
            {
                if (image == null) return null;

                using (var stream = new FileStream(Path.Combine("Imagens", image.FileName), FileMode.Create)) 
                {
                    image.CopyTo(stream);
                }

                return Ok(image);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro no upload" + ex.Message);
            }
        }
    }
}
