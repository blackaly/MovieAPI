using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.Application.Validation;
using MovieAPI.src.MovieAPI.Domain.Common;
using MovieAPI.src.MovieAPI.Domain.Enums;

namespace MovieAPI.src.MovieAPI.Application.Services
{
    public class EposideService : IEposideService
    {
        private readonly IEposideRepo repo;
        private readonly ISeriesRepo seriesRepo;
        private readonly EposideValidation validation = new EposideValidation();
        public EposideService(IEposideRepo _repo, ISeriesRepo _seriesRepo)
        {
            repo = _repo;
            seriesRepo = _seriesRepo;
        }

        public async Task<Result<IEnumerable<Eposide>>> Add(int id, List<Eposide> eposide)
        {

            var obj = await seriesRepo.GetBy(id);
            if (obj == null) return Result<IEnumerable<Eposide>>.Fail(new List<string> { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound)  });

            bool isValid = true;
            List<string> errors = new List<string>();
            foreach (var item in eposide)
            {
                if (!validation.Validate(item).IsValid)
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
                return Result<IEnumerable<Eposide>>.Fail(errors);


            obj.Eposides = eposide;
            await seriesRepo.Update(obj);
            

            return Result<IEnumerable<Eposide>>.Ok(await repo.Add(eposide));

        }

        public async Task<Result<Eposide>> Add(int id, Eposide eposide)
        {
            var obj = await seriesRepo.GetBy(id);

            if (obj == null) return Result<Eposide>.Fail(new List<string> { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            var validationResult = validation.Validate(eposide);

            if (!validationResult.IsValid) return Result<Eposide>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return Result<Eposide>.Ok(await repo.Add(eposide));

        }

        public async Task<Result<Eposide>> EditEposide(int id, Eposide eposide)
        {
            if (id != eposide.EposideId) return Result<Eposide>.Fail(new List<string> { ErrorMessages.GetMessage(ErrorCodes.IdMismatch) });

            var validationResult = validation.Validate(eposide);
            if(!validationResult.IsValid) return Result<Eposide>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            var isExist = await repo.GetBy(id);
            if (isExist == null) return Result<Eposide>.Fail(new List<string> { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            return Result<Eposide>.Ok(await repo.Update(eposide));
        
        }

        public Task<Result<Eposide>> EditEposide(Eposide eposide)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<Eposide>>> GetAll()
        {
            return Result<IEnumerable<Eposide>>.Ok(await repo.GetAll());
        }

        public async Task<Result<Eposide>> GetBy(int id)
        {
            var obj = await repo.GetBy(id);
            if (obj == null) return Result<Eposide>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            return Result<Eposide>.Ok(obj);
        }

        public async Task<Result<IEnumerable<Eposide>>> GetBy(string name)
        {
            var obj = await repo.GetBy(name);
            if (obj == null) return Result<IEnumerable<Eposide>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            return Result<IEnumerable<Eposide>>.Ok(obj);
        }

        public async Task<Result<IEnumerable<Eposide>>> GetEposideWithSeriesiD(int id)
        {
            var obj = await repo.GetEposideWithSeriesiD(id);
            if (obj == null) return Result<IEnumerable<Eposide>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });
        
            return Result<IEnumerable<Eposide>>.Ok(obj);
        }

        public async Task<Result<IEnumerable<Eposide>>> GetEposideWithSeriesName(string name)
        {
            var obj = await repo.GetEposideWithSeriesName(name);
            if (obj == null) return Result<IEnumerable<Eposide>>.Fail(new List<string>() { ErrorMessages.GetMessage(ErrorCodes.ResourceNotFound) });

            return Result<IEnumerable<Eposide>>.Ok(obj);
        }

    }
}
