using Microsoft.EntityFrameworkCore;
using InvestApi.Models;

namespace InvestApi.Data
{
    public class InvestDbContext : DbContext
    {
        public InvestDbContext(DbContextOptions<InvestDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Investor> Investors { get; set; }
    }
}
