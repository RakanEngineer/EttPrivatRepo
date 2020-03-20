using EttPrivatRepo.Data;
using EttPrivatRepo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttPrivatRepo.Areas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CategoriesProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<CategoryProduct> GetById(int id)
        {
            var categoryProduct = context.CategoryProduct.FirstOrDefault(x => x.ProductId == id);
            if (categoryProduct == null)
            {
                return NotFound();
            }
            return categoryProduct;
        }
        [HttpPost]
        public ActionResult<CategoryProduct> Create(CategoryProduct categoryProduct)
        {
            context.CategoryProduct.Add(categoryProduct);
            context.SaveChanges();
            //return Created($"/api/categoryProduct/{categoryProduct.Id}", categoryProduct);
            return CreatedAtAction(nameof(GetById), new { id = categoryProduct.ProductId }, categoryProduct);

        }
    }
}
