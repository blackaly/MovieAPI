using Microsoft.EntityFrameworkCore;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.Application.Validation;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Enums;

namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepo repo;
        private readonly DirectorValidation validation = new DirectorValidation();
        public DirectorService(IDirectorRepo _repo)
        {
            repo = _repo;
        }

        public async Task<Result<Director>> Add(Director director)
        {
            var validationResult = validation.Validate(director);
            if (!validationResult.IsValid) return Result<Director>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return Result<Director>.Ok(await repo.Add(director));

        }

        public async Task<Result<IEnumerable<Director>>> GetAll()
        {
            return Result<IEnumerable<Director>>.Ok(await repo.GetAll());
        }

        public async Task<Result<Director>> GetBy(int id)
        {
            var obj = await repo.GetBy(id);
            if (obj == null) return Result<Director>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            return Result<Director>.Ok(obj);
        }

        public async Task<Result<IEnumerable<Director>>> GetBy(string name)
        {
            if (name.IsNullOrEmpty() || name.Length == 0)
                return Result<IEnumerable<Director>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ValidationFailed) });

            return Result<IEnumerable<Director>>.Ok(await repo.GetBy(name));
        }

        public async Task<Result<IEnumerable<Director>>> GetSeriesDirectors(int id)
        {
            if (id <= 0) return Result<IEnumerable<Director>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ValidationFailed) });
            return Result<IEnumerable<Director>>.Ok(await repo.GetSeriesDirectors(id));
        }

        public async Task<Result<IEnumerable<Director>>> GetSeriesDirectors(string name)
        {
            if (name.IsNullOrEmpty()) return Result<IEnumerable<Director>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ValidationFailed) });
            return Result<IEnumerable<Director>>.Ok(await repo.GetSeriesDirectors(name));
        }
    }
}
