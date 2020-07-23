using MusicWebApp.Services.Repositories;
using System;

namespace MusicWebApp.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
