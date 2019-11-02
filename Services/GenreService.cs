using Microsoft.EntityFrameworkCore;
using MusicStoreSample.Data;
using MusicStoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreSample.Services
{
    public class GenreService
    {
        MusicStoreContext _context;

        public GenreService(MusicStoreContext context)
        {
            _context = context;
        }


        public List<Genre> GetAll()
        {
            return _context.Genre.ToList();
        }

        public Genre GetGenre(int id)
        {
            Genre seletcedGenre = new Genre();
            seletcedGenre = _context.Genre.Find(id);
            return seletcedGenre;
        }

        public int SaveUpdate(Genre newGenre)
        {
            Genre Genre = new Genre();
            Genre.GenreId = newGenre.GenreId;
            Genre.Name = newGenre.Name;
            Genre.Description = newGenre.Description;

            if (newGenre.GenreId > 0)
            {
                _context.Entry(Genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.Entry(Genre).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            }

            int index = _context.SaveChanges();
            return index;
        }
    }
}
