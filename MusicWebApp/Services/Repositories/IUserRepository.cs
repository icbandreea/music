using MusicWebApp.Entities;
using System.Collections.Generic;

namespace MusicWebApp.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
