using Microsoft.AspNetCore.Identity;

namespace BlogBuzz.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
