﻿using DTOLayer.MovieDto;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;

namespace NTier_ECommerce_DAL.Abstract
{
    public interface IMovieDAL : IGenericRepository<Movie>
    {
        Task<VMNewMovieDropdownsDTO> GetNewMovieDropdownsValues();
    }
}
