using BlogBuzz.Data;
using BlogBuzz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogBuzz.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogBuzzDbContext blogBuzzDbContext;

        public BlogPostRepository(BlogBuzzDbContext blogBuzzDbContext)
        {
            this.blogBuzzDbContext = blogBuzzDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogBuzzDbContext.AddAsync(blogPost);
            await blogBuzzDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await blogBuzzDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                blogBuzzDbContext.BlogPosts.Remove(existingBlog);
                await blogBuzzDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogBuzzDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogBuzzDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await blogBuzzDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await blogBuzzDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.Author = blogPost.Author;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;

                await blogBuzzDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}