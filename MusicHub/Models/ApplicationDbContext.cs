using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MusicHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }


        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}