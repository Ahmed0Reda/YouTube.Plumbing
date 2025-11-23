using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Testimonial;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public TestimonialService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<TestimonialListVM>> GetAllListAsync()
        {
            var TestimonialListVM = await _uniteOfWork.GetGenericRepository<Testimonial>().GetAllEntityList().
                ProjectTo<TestimonialListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return TestimonialListVM;
        }
        public async Task AddTestimonialAsync(TestimonialAddVM model)
        {
            var Testimonial = _mapper.Map<Testimonial>(model);
            await _uniteOfWork.GetGenericRepository<Testimonial>().AddEntityAsync(Testimonial);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteTestimonialAsync(int id)
        {
            var TestimonialEntity = await _uniteOfWork.GetGenericRepository<Testimonial>().GetEntityByIdAsync(id);
            if (TestimonialEntity != null)
            {
                _uniteOfWork.GetGenericRepository<Testimonial>().DeleteEntity(TestimonialEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<TestimonialUpdateVM> GetTestimonialById(int id)
        {
            var TestimonialEntity = await _uniteOfWork.GetGenericRepository<Testimonial>().Where(x => x.Id == id).
                ProjectTo<TestimonialUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return TestimonialEntity;
        }
        public async Task UpdateTestimonialAsync(TestimonialUpdateVM model) 
        {
            var TestimonialEntity = await _uniteOfWork.GetGenericRepository<Testimonial>().GetEntityByIdAsync(model.Id);
            if (TestimonialEntity != null)
            {
                _mapper.Map(model, TestimonialEntity);
                _uniteOfWork.GetGenericRepository<Testimonial>().UpdateEntity(TestimonialEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
    }
}
