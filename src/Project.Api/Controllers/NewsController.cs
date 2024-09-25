using Microsoft.AspNetCore.Mvc;
using Project.Api.Entities.ViewModels;
using Project.Api.Services;

namespace Project.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    private readonly NewsService _newsService;

    public NewsController(ILogger<NewsController> logger, NewsService newsService)
    {
        _logger = logger;        
        _newsService = newsService;
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<NewsViewModel>> Get() => _newsService.Get();

    [HttpGet("{id:length(24)}", Name = "GetNews")]
    public ActionResult<NewsViewModel> Get(string id)
    {
        var news = _newsService.Get(id);

        if (news is null) 
        {
            return NotFound();
        }

        return news;

    } 
    [HttpPost]
    public ActionResult<NewsViewModel> Create(NewsViewModel news)
    {
        var result = _newsService.Create(news);

        return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);   
    }
}
