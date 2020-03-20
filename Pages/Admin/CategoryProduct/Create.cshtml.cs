using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EttPrivatRepo.Data;
using EttPrivatRepo.Data.Entities;

namespace EttPrivatRepo
{
    public class CreateModel : PageModel
    {
        private readonly EttPrivatRepo.Data.ApplicationDbContext _context;

        public CreateModel(EttPrivatRepo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CategoryProduct CategoryProduct { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryProduct.Add(CategoryProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
