using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesFeladat.Data;
using RazorPagesFeladat.Models;

namespace RazorPagesFeladat.Pages
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesFeladat.Data.BarlangDbContext _context;

        public EditModel(RazorPagesFeladat.Data.BarlangDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarlangModel BarlangModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangmodel =  await _context.BarlangModels.FirstOrDefaultAsync(m => m.Id == id);
            if (barlangmodel == null)
            {
                return NotFound();
            }
            BarlangModel = barlangmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BarlangModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarlangModelExists(BarlangModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BarlangModelExists(int id)
        {
            return _context.BarlangModels.Any(e => e.Id == id);
        }
    }
}
