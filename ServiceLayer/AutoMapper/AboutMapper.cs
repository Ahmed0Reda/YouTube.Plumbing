using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;

namespace ServiceLayer.AutoMapper
{
    public class AboutMapper : Profile
    {
        public AboutMapper()
        {
            CreateMap<AboutUsPage, AboutListVM>().ReverseMap();
            CreateMap<AboutUsPage, AboutAddVM>().ReverseMap();
            CreateMap<AboutUsPage, AboutUpdateVM>().ReverseMap();
        }


    }
}
