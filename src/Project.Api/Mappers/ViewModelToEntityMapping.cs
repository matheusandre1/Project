using AutoMapper;
using Project.Api.Entities;
using Project.Api.Entities.ViewModels;

namespace Project.Api.Mappers
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {

            CreateMap<NewsViewModel, News>();
        }
    }
}
