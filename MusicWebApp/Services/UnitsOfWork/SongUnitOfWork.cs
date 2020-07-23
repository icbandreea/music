using MusicWebApp.Context;
using MusicWebApp.Services.Repositories;
using System;

namespace MusicWebApp.Services.UnitsOfWork
{
    public class SongUnitOfWork : ISongUnitOfWork
    {
        private readonly MusicContext _context;

        public SongUnitOfWork(MusicContext context, ISongRepository song,
            IArtistRepository artist)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Song = song ?? throw new ArgumentNullException(nameof(context));
            Artist = artist ?? throw new ArgumentNullException(nameof(context));
        }

        public ISongRepository Song { get; }

        public IArtistRepository Artist { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
