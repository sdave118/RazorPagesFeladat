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

        public IList<BarlangModel> BarlangModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BarlangModel = await _context.BarlangModels.ToListAsync();
        }
    }
}
