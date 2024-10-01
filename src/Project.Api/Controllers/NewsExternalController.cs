using Microsoft.AspNetCore.Mvc;
using Project.Api.Entities.ViewModels;
using Project.Api.Services;

namespace Project.Api.Controllers
{
    public class NewsExternalController : ControllerBase
    {
        private readonly ILogger<NewsExternalController> _logger;
        private readonly NewsService _newsService;

        public NewsExternalController(ILogger<NewsExternalController> logger, NewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;            
        }

        [HttpGet]
        public ActionResult<List<NewsViewModel>> Get() => _newsService.Get();

        [HttpGet("{slug}")]
        public ActionResult<NewsViewModel> Get(string slug) 
        {
            var news = _newsService.GetBySlug(slug);

            if (news is null)
            {
                return NotFound();
            }

            return Ok(news);
        }

    }
}
