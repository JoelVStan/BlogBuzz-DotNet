using BlogBuzz.Data;
using BlogBuzz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogBuzz.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogBuzzDbContext blogBuzzDbContext;

        public BlogPostLikeRepository(BlogBuzzDbContext blogBuzzDbContext)
        {
            this.blogBuzzDbContext = blogBuzzDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogBuzzDbContext.BlogPostLike.AddAsync(blogPostLike);
            await blogBuzzDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogBuzzDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogBuzzDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
