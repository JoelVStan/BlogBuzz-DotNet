using BlogBuzz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogBuzz.Data
{
    public class BlogBuzzDbContext : DbContext
    {
        public BlogBuzzDbContext(DbContextOptions<BlogBuzzDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set; }

        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
