using Microsoft.EntityFrameworkCore;

namespace UrnaEletrônica.Models
{


    public class HubCountContext : DbContext
    {
        public HubCountContext(DbContextOptions<HubCountContext> options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }

}
