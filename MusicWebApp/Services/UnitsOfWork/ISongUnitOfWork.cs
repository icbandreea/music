using MusicWebApp.Services.Repositories;
using System;

namespace MusicWebApp.Services.UnitsOfWork
{
    public interface ISongUnitOfWork : IDisposable
    {
        ISongRepository Song { get; }

        IArtistRepository Artist { get; }

        int Complete();
    }
}
