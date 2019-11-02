using Microsoft.EntityFrameworkCore;
using MusicStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreSample.Data
{
    public class MusicStoreContext:DbContext
    {
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : base(options)
        {

        }
        
        public DbSet<Artist> Artist { get; set; }
        public DbSet <Album> Album { get; set; }
        public DbSet<Genre> Genre { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<Genre>().ToTable("Genre");
        }


    }
}
