using Microsoft.EntityFrameworkCore;
using MusicStoreSample.Data;
using MusicStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreSample.Repository
{
    public class ArtistService
    {
        MusicStoreContext _context;

        public ArtistService(MusicStoreContext context)
        {
            _context = context;
        }


        public List<Artist> GetAll()
        {
            return _context.Artist.ToList();
        }

        public Artist GetArtist(int id)
        {
            Artist seletcedArtist = new Artist();
            seletcedArtist = _context.Artist.Find(id);
            return seletcedArtist;
        }

        public int SaveUpdate(Artist newArtist)
        {
            Artist artist = new Artist();
            artist.ArtistId = newArtist.ArtistId;
            artist.Name = newArtist.Name;
            artist.IsActive = newArtist.IsActive;

            if (newArtist.ArtistId > 0)
            {
                _context.Entry(artist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            { 
                _context.Entry(artist).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            }

            int index = _context.SaveChanges();
            return index;
        }

    }
}
