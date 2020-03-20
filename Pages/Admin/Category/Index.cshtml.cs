using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EttPrivatRepo.Data;
using EttPrivatRepo.Data.Entities;

namespace EttPrivatRepo.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly EttPrivatRepo.Data.ApplicationDbContext _context;

        public IndexModel(EttPrivatRepo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Entities.Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
