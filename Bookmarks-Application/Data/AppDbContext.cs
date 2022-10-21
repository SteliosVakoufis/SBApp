using Bookmarks_Application.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks_Application.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bookmark> Bookmarks { get; set; } 
    }
}
