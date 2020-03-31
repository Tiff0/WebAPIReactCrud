namespace WebAPIReactCrud.Models
{
    using Microsoft.EntityFrameworkCore;

    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
        }

        public DbSet<DonationCandidate> DonationCandidates { get; set; }
    }
}