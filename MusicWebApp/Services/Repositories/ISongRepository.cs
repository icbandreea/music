using MusicWebApp.Entities;
using System;

namespace MusicWebApp.Services.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Song GetSongDetails(Guid songId);
    }
}
