using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
using EntityLayer.WebApplication.ViewModels.Contact;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ContactService( IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<ContactListVM>> GetAllListAsync()
        {
            var ContactListVM = await _uniteOfWork.GetGenericRepository<ContactUsPage>().GetAllEntityList().
                ProjectTo<ContactListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return ContactListVM;
        }
        public async Task AddContactAsync(ContactAddVM model)
        {
            var ContactEntity = _mapper.Map<ContactUsPage>(model);
            await _uniteOfWork.GetGenericRepository<ContactUsPage>().AddEntityAsync(ContactEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteContactAsync(int id)
        {
            var ContactEntity = await _uniteOfWork.GetGenericRepository<ContactUsPage>().GetEntityByIdAsync(id);
            if (ContactEntity != null)
            {
                _uniteOfWork.GetGenericRepository<ContactUsPage>().DeleteEntity(ContactEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<ContactUpdateVM> GetContactById(int id)
        {
            var ContactEntity = await _uniteOfWork.GetGenericRepository<ContactUsPage>().Where(x => x.Id == id).
                ProjectTo<ContactUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return ContactEntity;
        }
        //public async Task UpdateContactAsync(ContactUpdateVM model)
        //{
        //    var ContactEntity = await _uniteOfWork.GetGenericRepository<ContactUsPage>().GetEntityByIdAsync(model.Id);
        //    if (ContactEntity != null)
        //    {
        //        _mapper.Map(model, ContactEntity);
        //        _uniteOfWork.GetGenericRepository<ContactUsPage>().UpdateEntity(ContactEntity);
        //        await _uniteOfWork.CommitAsync();
        //    }
        //}
        public async Task UpdateContactAsync(ContactUpdateVM model)
        {
            var about = _mapper.Map<ContactUsPage>(model);
            _uniteOfWork.GetGenericRepository<ContactUsPage>().UpdateEntity(about);
            await _uniteOfWork.CommitAsync();
        }
    }
}
