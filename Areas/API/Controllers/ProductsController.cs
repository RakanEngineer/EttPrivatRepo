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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET /api/products
        [HttpGet]
        public IEnumerable<ProductDto> GetAll()
        {
            var products = context.Product
                .Include(x => x.CategoryProduct)
                .ThenInclude(x => x.Category)
                .ToList();

            var projectedProducts = products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Categories = x.CategoryProduct.Select(y => new CategoryDto
                {
                    Id = y.Category.Id,
                    Name = y.Category.Name,
                    ImageUrl = y.Category.ImageUrl
                }).ToList()
            });

            return projectedProducts;
            //return products;
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
        public ActionResult<Product> GetById(int id)
        {
            var product = context.Product.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
            //return Created($"/api/products/{product.Id}", product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = context.Product.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            context.Product.Remove(product);
            context.SaveChanges();

            return NoContent();
        }

        //PUT /api/products/{id}
        [HttpPut("{id}")]
        public ActionResult Replace(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent(); // 204 no content
        }

    }


}
