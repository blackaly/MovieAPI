using Microsoft.EntityFrameworkCore;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Enums;
using MovieAPI.Application.Validation;


namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepo repo;
        private readonly GenreValidation validation = new GenreValidation();
        public GenreService(IGenreRepo _repo)
        {
            repo = _repo;
        }

        public async Task<Result<Genre>> Add(Genre genre)
        {
            var validationResult = validation.Validate(genre);
            if (!validationResult.IsValid) return Result<Genre>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return Result<Genre>.Ok(await repo.Add(genre));
        }

        public async Task Delete(Genre genre)
        {
            
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<Genre> GetGenreById(byte id)
        {
            var genre = await GetBy(id);
            return genre.IsSuccess ? genre.Value : null;
        }

        public async Task Update(Genre genre)
        {
            await repo.Update(genre);
        }

        public async Task<bool> isGenereExists(string name)
        {
            var genre = await GetBy(name);
            return genre.IsSuccess;
        }

        public async Task<bool> isGenereExists(byte id)
        {
            var genre = await GetBy(id);
            return genre.IsSuccess;
        }

        Task<Result<IEnumerable<Genre>>> IGenreService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Result<Genre>> IGenreService.Add(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Genre>> GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Genre>> GetBy(string name)
        {
            throw new NotImplementedException();
        }

        Task<Result<bool>> IGenreService.Delete(Genre genre)
        {
            throw new NotImplementedException();
        }

        Task<Result<bool>> IGenreService.Update(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
