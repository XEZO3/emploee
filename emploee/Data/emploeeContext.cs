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
            builder.UseSqlServer("Server=LAPTOP-BFFJ9SQ9;Database=emploee;Trusted_Connection=True");
        }
    }
}
