using Microsoft.EntityFrameworkCore;
using crudelicious.Models;

namespace crudelicious.Models
{
    public class crudeliciousContext : DbContext
    {
        public crudeliciousContext(DbContextOptions<crudeliciousContext> options) : base(options) {}

        public DbSet<MyModel> mymodels {get; set;}
    }
}