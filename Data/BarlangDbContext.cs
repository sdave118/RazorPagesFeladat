using Microsoft.EntityFrameworkCore;
using RazorPagesFeladat.Models;

namespace RazorPagesFeladat.Data
{
    public class BarlangDbContext : DbContext
    {
        public BarlangDbContext(DbContextOptions<BarlangDbContext> options) : base(options)
        {

        }

        public DbSet<BarlangModel> BarlangModels { get; set; }
    }
}
