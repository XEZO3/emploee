using emploee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace emploee.Data
{
    public class emploeeContext :DbContext
    {
        public emploeeContext(DbContextOptions<emploeeContext> options) : base(options) { 
        
        }
        public DbSet<Emploee> Emploees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-JD76U9C;Database=emploee;Trusted_Connection=True");
        }
    }
}
