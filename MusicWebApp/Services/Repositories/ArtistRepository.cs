using MusicWebApp.Context;
using MusicWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApp.Services.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly MusicContext _context;

        public ArtistRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
