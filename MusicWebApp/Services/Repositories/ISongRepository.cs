using MusicWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApp.Services.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Song GetSongDetails(Guid songId);
    }
}
