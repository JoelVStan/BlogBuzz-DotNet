using BlogBuzz.Data;
using BlogBuzz.Models.Domain;
using BlogBuzz.Models.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlogBuzz.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogBuzzDbContext blogBuzzDbContext;

        public TagRepository(BlogBuzzDbContext blogBuzzDbContext)
        {
            this.blogBuzzDbContext = blogBuzzDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogBuzzDbContext.Tags.AddAsync(tag);
            await blogBuzzDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogBuzzDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                blogBuzzDbContext.Tags.Remove(existingTag);
                await blogBuzzDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogBuzzDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return blogBuzzDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogBuzzDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await blogBuzzDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
