using AutoMapper;
using Project.Api.Entities;
using Project.Api.Entities.ViewModels;
using Project.Api.Infra;

namespace Project.Api.Services
{
    public class VideoService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<Video> _video;

        public VideoService(IMongoRepository<Video> videos, IMapper mapper)
        {
            _mapper = mapper;
            _video = videos;
        }

        public List<VideoViewModel> Get() => _mapper.Map<List<VideoViewModel>>(_video.Get().ToList());

        public VideoViewModel Get(string id) => _mapper.Map<VideoViewModel>(_video.Get(id));

        public VideoViewModel GetBySlug(string slug) => _mapper.Map<VideoViewModel>(_video.GetBySlug(slug));

        public VideoViewModel Create(VideoViewModel video)
        {
            var entity = new Video(video.Hat, video.Title, video.Author, video.ThumbNail,video.Url, video.Status);

            _video.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, VideoViewModel news)
        {
            _video.Update(id, _mapper.Map<Video>(news));
        }

        public void Remove(string id) => _video.Remove(id);
    }
}
}
