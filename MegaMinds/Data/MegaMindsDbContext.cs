using MegaMinds.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MegaMinds.Data
{
    public class MegaMindsDbContext : DbContext
    {
        public MegaMindsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Register> Registers { get; set; }

    }
}
