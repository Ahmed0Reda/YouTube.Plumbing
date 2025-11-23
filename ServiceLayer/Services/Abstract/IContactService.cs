using EntityLayer.WebApplication.ViewModels.Contact;

namespace ServiceLayer.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ContactListVM>> GetAllListAsync();
        Task AddContactAsync(ContactAddVM model);
        Task DeleteContactAsync(int id);
        Task<ContactUpdateVM> GetContactById(int id);
        Task UpdateContactAsync(ContactUpdateVM model);
    }
}
