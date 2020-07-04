using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DM.Models 
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Incident> Incidents { get; set; }  // Creates the Incidents Table in Database on executing the PM> add-migration InitialModel

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}