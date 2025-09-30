using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFeladat.Data;
using RazorPagesFeladat.Models;

namespace RazorPagesFeladat.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesFeladat.Data.BarlangDbContext _context;

        public DetailsModel(RazorPagesFeladat.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public BarlangModel BarlangModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel = await _context.BarlangModels.FirstOrDefaultAsync(m => m.Id == id);
            if (barlangmodel == null)
            {
                return NotFound();
            }
            else
            {
                BarlangModel = barlangmodel;
            }
            return Page();
        }
    }
}
