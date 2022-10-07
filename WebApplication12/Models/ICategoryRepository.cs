namespace WebApplication12.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        Category EditCategory(int id,Category category);

        void DeleteCategory(int id);
    }
}
