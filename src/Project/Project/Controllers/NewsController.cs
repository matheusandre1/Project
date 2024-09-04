using Microsoft.AspNetCore.Mvc;


namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
            
        }
    }
}
