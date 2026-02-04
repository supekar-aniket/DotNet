using _22_code_first_approach.Models;
using Microsoft.EntityFrameworkCore;

namespace _22_code_first_approach.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
