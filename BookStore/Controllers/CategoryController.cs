using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository categoryRepository;
        public CategoryController()
        {
            categoryRepository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = categoryRepository.GetCategories();
            return Ok(data);
        }
    }
}
