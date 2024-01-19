using DTOLayer.MovieDto;
using Microsoft.EntityFrameworkCore;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFMovieRepository : GenericRepository<Movie>, IMovieDAL
    {
        private readonly Context _context;
        public EFMovieRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues()
        {
            var response = new VMNewMovieDropdownsDTO()
            {
                Actors = await _context.Actors.OrderBy(n => n.NameSurname).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.NameSurname).ToListAsync()
            };
            await _context.SaveChangesAsync();
            return response;           
        }
    }
}
