using EttPrivatRepo.Data;
using EttPrivatRepo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttPrivatRepo.Areas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET /api/categories
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            var categories = context.Category
                .Include(x => x.CategoryProduct)
                .ThenInclude(x => x.Category)
                .ToList();

            //var projectedProducts = products.Select(x => new ProductDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    ImageUrl = x.ImageUrl,
            //    Categories = x.CategoryProduct.Select(y => new CategoryDto
            //    {
            //        Id = y.Category.Id,
            //        Name = y.Category.Name,
            //        ImageUrl = y.Category.ImageUrl
            //    }).ToList()
            //});

            //return projectedProducts;
            return categories;
            //var products = context.Product.ToList();
            //return products;
            //return Enumerable.Empty<Product>();
        }
        public class ProductDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public Uri ImageUrl { get; set; }
            public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        }
        public class CategoryDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Uri ImageUrl { get; set; }
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = context.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            //return Created($"/api/categories/{category.Id}", category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        //PUT /api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult Replace(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent(); // 204 no content
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = context.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            context.Category.Remove(category);
            context.SaveChanges();

            return NoContent();
        }

    }


}
