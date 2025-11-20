using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Contact;

namespace ServiceLayer.AutoMapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ContactUsPage, ContactListVM>().ReverseMap();
            CreateMap<ContactUsPage, ContactAddVM>().ReverseMap();
            CreateMap<ContactUsPage, ContactUpdateVM>().ReverseMap();
        }
    }
}
