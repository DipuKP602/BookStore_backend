using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var res = _categoryRepository.GetAllCategories();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = _categoryRepository.GetCategoryById(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var res = _categoryRepository.AddCategory(category);
            if (res == null)
                return BadRequest();

            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+"/"+HttpContext.Request.Path+"/"+category.CategoryId,res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Item deleted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Category category)
        {
            var res = _categoryRepository.EditCategory(id,category);
            return Ok(res);
        }
    }
}
