using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 1442; Database = CommentDb; User id= sa; password=PASSWORD;TrustServerCertificate=True;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
