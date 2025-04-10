using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Validation;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System.Collections.Generic;

namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepo repo;
        private readonly MovieValidation validation = new MovieValidation();

        public MovieService(IMovieRepo _repo)
        {
            repo = _repo;
        }

        public async Task<Result<Movie>> Add(Movie movie)
        {
            var validationResult = validation.Validate(movie);
            if (!validationResult.IsValid) return Result<Movie>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return Result<Movie>.Ok(await repo.Add(movie));
        }

        public async Task<Result<IEnumerable<Movie>>> GetAll()
        {
            return Result<IEnumerable<Movie>>.Ok(await repo.GetAll());
        }

        public async Task<Result<Movie>> GetBy(int id)
        {
            var obj = await repo.GetBy(id);
            if (obj == null) return Result<Movie>.Fail(new List<string>() { ErrorMessages.GetMessage(Domain.Enums.ErrorCodes.ResourceNotFound) });
            
            return Result<Movie>.Ok(obj);

        }

        public async Task<Result<IEnumerable<Movie>>> GetBy(string name)
        {
            var obj = await repo.GetBy(name);
            if (obj == null) return Result<IEnumerable<Movie>>.Fail(new List<string>() { ErrorMessages.GetMessage(Domain.Enums.ErrorCodes.ResourceNotFound) });

            return Result<IEnumerable<Movie>>.Ok(obj);
        }
        
        // Implementation of the generic IsMovieExists method
        public async Task<bool> IsMovieExists<T>(T identifier)
        {
            if (identifier is int id)
            {
                var result = await this.GetBy(id);
                return result.IsSuccess;
            }
            else if (identifier is string name)
            {
                var result = await this.GetBy(name);
                return result.IsSuccess;
            }
            
            return false;
        }
    }
}
