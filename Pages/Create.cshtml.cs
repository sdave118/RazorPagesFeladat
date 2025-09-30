using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesFeladat.Data;
using RazorPagesFeladat.Models;

namespace RazorPagesFeladat.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesFeladat.Data.BarlangDbContext _context;

        public CreateModel(RazorPagesFeladat.Data.BarlangDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BarlangModel BarlangModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BarlangModels.Add(BarlangModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
