using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EttPrivatRepo.Data;
using EttPrivatRepo.Data.Entities;

namespace EttPrivatRepo
{
    public class IndexModel : PageModel
    {
        private readonly EttPrivatRepo.Data.ApplicationDbContext _context;

        public IndexModel(EttPrivatRepo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CategoryProduct> CategoryProduct { get;set; }

        public async Task OnGetAsync()
        {
            CategoryProduct = await _context.CategoryProduct
                .Include(c => c.Category)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
