using Microsoft.EntityFrameworkCore;
using WriteSecure.Models;

namespace WriteSecure.AppDbContext
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options):base(options)
        {
            
        }
        public DbSet<UserRegistratoin> UserRegistratoins { get; set; }
    }
}
