using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class CommonContext : DbContext
    {
        public CommonContext(DbContextOptions options) : base(options) { }

        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
