namespace WebApplication12.Models
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly BookDBContext _dBContext;

        public CategoryRepositoryImpl(BookDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Category> GetAllCategories()
        {
            return _dBContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dBContext.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        }
        public Category AddCategory(Category category)
        {
            _dBContext.Categories.Add(category);
            _dBContext.SaveChanges();
            return category;
        }

        public Category EditCategory(int id, Category category)
        {
            Category cat = this.GetCategoryById(id);
            
            cat.CategoryName = category.CategoryName;
            cat.Description = category.Description;
            cat.Image = category.Image;
            cat.Status = category.Status;
            cat.Position = category.Position;
            cat.CreatedAt = category.CreatedAt;

            _dBContext.SaveChanges();
            return cat;
        }
        public void DeleteCategory(int id)
        {
            Category cat = this.GetCategoryById(id);
            _dBContext.Categories.Remove(cat);
            _dBContext.SaveChanges();
        }
    }
}
