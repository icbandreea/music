using Microsoft.EntityFrameworkCore;
using MusicWebApp.Context;
using MusicWebApp.Entities;
using System;
using System.Linq;

namespace MusicWebApp.Services.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly MusicContext _context;

        public SongRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Aici nu inteleg de ce nu face legatura
        public Song GetSongDetails(Guid songId)
        {
            return _context.Songs
                .Where(b => b.Id == songId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Artist)
                .FirstOrDefault();
        }
    }
}
