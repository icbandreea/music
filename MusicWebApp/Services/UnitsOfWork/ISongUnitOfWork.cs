using MusicWebApp.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApp.Services.UnitsOfWork
{
    public interface ISongUnitOfWork : IDisposable
    {
        ISongRepository Song { get; }

        IArtistRepository Artist { get; }

        int Complete();
    }
}
