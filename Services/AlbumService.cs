using Microsoft.EntityFrameworkCore;
using MusicStoreSample.Data;
using MusicStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreSample.Services
{
    public class AlbumService
    {
        MusicStoreContext _context;

        public AlbumService(MusicStoreContext context)
        {
            _context = context;
        }


        public List<Album> GetAll()
        {
            return _context.Album.Include(a =>a.Artist).Include(g => g.Genre).ToList();
        }

        public Album GetAlbum(int id)
        {
            Album seletcedAlbum = new Album();
            seletcedAlbum = _context.Album.Find(id);
            return seletcedAlbum;
        }

        public int SaveUpdate(Album newAlbum)
        {
            Album Album = new Album();
            Album.AlbumId = newAlbum.AlbumId;
            Album.GenreId = newAlbum.GenreId;
            Album.ArtistId = newAlbum.ArtistId;
            Album.Title = newAlbum.Title;
            Album.Price = newAlbum.Price;
            Album.AlbumArtUrl = newAlbum.AlbumArtUrl;
    
            if (newAlbum.AlbumId > 0)
            {
                _context.Entry(Album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.Entry(Album).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            }

            int index = _context.SaveChanges();
            return index;
        }
    }
}
