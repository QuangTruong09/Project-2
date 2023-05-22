﻿using JORDAN_2T.Infrastructure.Data;
using JORDAN_2T.ApplicationCore.Models;
using System.Collections.Generic;

namespace JORDAN_2T.Infrastructure.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        // Add methods for movie repository
        Movie CreateNewMovie();
        Movie GetMovie(int id);
         int GetNumber(int i);
        IEnumerable<Movie> GetAdminMovies(MovieStatus status);
        IEnumerable<Movie> GetInventoryMovies(MovieSortKey sort,int pg);
        IEnumerable<Movie> GetInventoryMovies(MovieSortKey sort);
        IEnumerable<Movie> GetInventoryMovies();
        IEnumerable<Movie> GetCategory(int Id);
        IEnumerable<Movie> GetSubCategory(int Id);
    }
}
