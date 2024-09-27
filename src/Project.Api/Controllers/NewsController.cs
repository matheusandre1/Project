using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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

        return Ok(news);

    } 
    [HttpPost]
    public ActionResult<NewsViewModel> Create(NewsViewModel news)
    {
        var result = _newsService.Create(news);

        return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);   
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, NewsViewModel newsIn) 
    {
        var news = _newsService.Get(id);

        if(news is null)
        {
            return NotFound();
        }

        _newsService.Update(id, newsIn);

        return CreatedAtRoute("GetNews", new { id = id }, newsIn);
        
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        var news = _newsService.Get(id);

        if (news is null)
        {
            return NotFound();
        }

        _newsService.Remove(news.Id);

        return Ok();

    }



}

