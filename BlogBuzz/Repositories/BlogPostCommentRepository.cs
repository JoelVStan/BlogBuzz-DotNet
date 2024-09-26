using BlogBuzz.Data;
using BlogBuzz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogBuzz.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogBuzzDbContext blogBuzzDbContext;

        public BlogPostCommentRepository(BlogBuzzDbContext blogBuzzDbContext)
        {
            this.blogBuzzDbContext = blogBuzzDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogBuzzDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogBuzzDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await blogBuzzDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
