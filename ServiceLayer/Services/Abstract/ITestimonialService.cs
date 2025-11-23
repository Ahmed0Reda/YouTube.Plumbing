using EntityLayer.WebApplication.ViewModels.Testimonial;

namespace ServiceLayer.Services.Abstract
{
    public interface ITestimonialService
    {
        Task<List<TestimonialListVM>> GetAllListAsync();
        Task AddTestimonialAsync(TestimonialAddVM model);
        Task DeleteTestimonialAsync(int id);
        Task<TestimonialUpdateVM> GetTestimonialById(int id);
        Task UpdateTestimonialAsync(TestimonialUpdateVM model);
    }
}
