namespace EntityLayer.WebApplication.ViewModels.CategoryVM
{
    public class CategoryListVM
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("d");
        public string? UpdatedDate { get; set; }
        public string Name { get; set; } = null!;
    }
}
