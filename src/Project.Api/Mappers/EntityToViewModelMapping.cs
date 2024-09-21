using AutoMapper;
using Project.Api.Entities;
using Project.Api.Entities.ViewModels;

namespace Project.Api.Mappers
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            CreateMap<News, NewsViewModel>();
        }
    }
}
