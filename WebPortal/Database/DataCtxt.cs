using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

namespace WebPortal.Database
{
    public class DataCtxt:IdentityDbContext<ApplicationUser>
    {
        public DataCtxt(DbContextOptions<DataCtxt>options):base(options)
        {
                
        }

        //public DbSet<Student>  { get; set; }
        public DbSet<Course> courses { get; set; }     

       

        //public DbSet<Student>  { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}
