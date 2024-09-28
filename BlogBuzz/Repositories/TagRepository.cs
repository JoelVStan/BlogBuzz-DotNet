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

        public async Task<IEnumerable<Tag>> GetAllAsync(
            string? searchQuery,
            string? sortBy,
            string? sortDirection,
            int pageNumber = 1,
            int pageSize = 100)
        {
            var query = blogBuzzDbContext.Tags.AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(searchQuery) == false)
            {
                query = query.Where(x => x.Name.Contains(searchQuery) ||
                                         x.DisplayName.Contains(searchQuery));
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                var isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);

                if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                }

                if (string.Equals(sortBy, "DisplayName", StringComparison.OrdinalIgnoreCase))
                {
                    query = isDesc ? query.OrderByDescending(x => x.DisplayName) : query.OrderBy(x => x.DisplayName);
                }
            }

            // Pagination
            // Skip 0 Take 5 -> Page 1 of 5 results
            // Skip 5 Take next 5 -> Page 2 of 5 results
            var skipResults = (pageNumber - 1) * pageSize;
            query = query.Skip(skipResults).Take(pageSize);

            return await query.ToListAsync();

            // return await blogbuzzDbContext.Tags.ToListAsync();
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

        public async Task<int> CountAsync()
        {
            return await blogBuzzDbContext.Tags.CountAsync();
        }
    }
}
