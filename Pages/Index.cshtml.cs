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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFeladat.Data.BarlangDbContext _context;

        public IndexModel(RazorPagesFeladat.Data.BarlangDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string KivalasztottTelepules { get; set; }

        public IList<string> Telepulesek { get; set; } = default!;
        public IList<BarlangModel> BarlangModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Telepulesek = await _context.BarlangModels
                .Select(x => x.Telepules)
                .Distinct()
                .ToListAsync();

            if (KivalasztottTelepules == null)
            {
                BarlangModel = await _context.BarlangModels.ToListAsync();
            }
            else
            {
                BarlangModel = await _context.BarlangModels
                    .Where(x => x.Telepules == KivalasztottTelepules)
                    .ToListAsync();
            }
        }
    }
}
