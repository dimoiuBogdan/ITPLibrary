using AutoMapper;
using ITPLibrary.Web.Core.Dtos;
using ITPLibrary.Web.Core.Models;
using ITPLibrary.Web.Core.ViewModels;

namespace ITPLibrary.Web.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewBookViewModel, BookCreateDto>();
            CreateMap<EditBookViewModel, BookEditDto>();
            CreateMap<BookModel, EditBookViewModel>();
        }
    }
}
