﻿using Microsoft.EntityFrameworkCore;
using MusicWebApp.Entities;

namespace MusicWebApp.Context
{
    public class MusicContext: DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options): base (options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
