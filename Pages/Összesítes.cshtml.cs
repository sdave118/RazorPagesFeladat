using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesFeladat.Data;
using RazorPagesFeladat.DTO;

namespace RazorPagesFeladat.Pages
{
    public class ÖsszesítesModel : PageModel
    {
        public readonly BarlangDbContext _context;
        public ÖsszesítesModel(BarlangDbContext context)
        {
            _context = context;
        }

        public IList<OsszesitesDTO> Osszesites { get; set; } = new List<OsszesitesDTO>();

        public void OnGet()
        {
            var telepulesek = _context.BarlangModels.Select(x => x.Telepules).Distinct().ToList();

            Osszesites = telepulesek.Select(telepules => new OsszesitesDTO
            {
                Telepules = telepules,
                BarlangokSzama = _context.BarlangModels.Count(b => b.Telepules == telepules),
            }).ToList();

        }
    }
}
