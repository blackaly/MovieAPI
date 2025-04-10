using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.Application.Validation;
using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Enums;
using Microsoft.IdentityModel.Tokens;

namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepo repo;
        private readonly SeriesValidation validationS = new SeriesValidation();
        private readonly EposideValidation validationE = new EposideValidation();
        public SeriesService(ISeriesRepo _repo)
        {
            repo = _repo;
        }

        public async Task<Result<Series>> Add(Series series)
        {
            var validationResult = validationS.Validate(series);
            if (!validationS.Validate(series).IsValid)
                return Result<Series>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            var output = await repo.Add(series);

            return Result<Series>.Ok(output);

        }

        public async Task<Result<Series>> AddWithEposides(Series series)
        {
            var validationSeries = validationS.Validate(series);
            var isValid = true;
            foreach(var o in series.Eposides)
            {
                if (!validationE.Validate(o).IsValid)
                {
                    isValid = false;
                    break;
                }

            }

            if(validationSeries.IsValid && isValid && series.Eposides.Count > 0)
            {
                return Result<Series>.Ok(await repo.Add(series));

            }
            return Result<Series>.Fail(validationSeries.Errors.Select(e => e.ErrorMessage).ToList());
        }

        public async Task<Result<Series>> EditSeries(int id, Series series)
        {
            if (id != series.SeriesId) Result<Series>.Fail(new List<string> { ErrorMessages.GetMessage(ErrorCodes.IdMismatch) });
            var validationResult = validationS.Validate(series);
            var isValid = true;

            if (series.Eposides?.Count > 0)
            {
                foreach (var o in series.Eposides)
                {
                    if (!validationE.Validate(o).IsValid)
                    {
                        isValid = false;
                        break;
                    }

                }
            }
            if(isValid && validationResult.IsValid && series.Eposides.Count > 0)
                return Result<Series>.Ok(await repo.Update(series));

            return Result<Series>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            
        }

        public async Task<Result<IEnumerable<Series>>> GetAll()
        {
            return Result<IEnumerable<Series>>.Ok(await repo.GetAll());
        }

        public async Task<Result<Series>> GetBy(int id)
        {
            if (id == 0) return Result<Series>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ValidationFailed) });
            return Result<Series>.Ok(await repo.GetBy(id));
        }

        public async Task<Result<IEnumerable<Series>>> GetBy(string name)
        {
            if (name.IsNullOrEmpty()) return Result<IEnumerable<Series>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ValidationFailed) });

            return Result<IEnumerable<Series>>.Ok(await repo.GetBy(name));
        }
    }
}
