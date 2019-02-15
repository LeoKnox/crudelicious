using Microsoft.EntityFrameworkCore;

namespace crudelicious.Models
{
    public class crudeliciousContext : DbContext
    {
        public crudeliciousContext(DbContextOptions<crudeliciousContext> options) : base(options) {}
    }
}