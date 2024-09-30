using AutoMapper;
using Project.Api.Entities;
using Project.Api.Entities.ViewModels;
using Project.Api.Infra;

namespace Project.Api.Services
{
    public class NewsService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<News> _news;

        public NewsService(IMongoRepository<News> news, IMapper mapper)
        {
            _mapper = mapper;
            _news = news;
        }

        public List<NewsViewModel> Get() => _mapper.Map<List<NewsViewModel>>(_news.Get().ToList());

        public NewsViewModel Get(string id) => _mapper.Map<NewsViewModel>(_news.Get(id));

        public NewsViewModel GetBySlug(string slug) => _mapper.Map<NewsViewModel>(_news.GetBySlug(slug));

        public NewsViewModel Create(NewsViewModel news) 
        {
            var entity = new News(news.Hat, news.Title, news.Text, news.Author, news.Img, news.Status);

            _news.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, NewsViewModel news) 
        {
            _news.Update(id, _mapper.Map<News>(news));
        }

        public void Remove(string id) => _news.Remove(id);
    }
}
