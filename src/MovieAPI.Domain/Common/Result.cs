using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.src.MovieAPI.Domain.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Value { get; }
        public List<string> Errors { get; } = new List<string>();

        int StatusCode { get; }
        private Result(bool isSuccess, T value, List<string> errors, int statusCode)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors;
            StatusCode = statusCode;
        }

        public static Result<T> Ok(T value) => new(true, value, new List<string>(), 200);
        public static Result<T> Fail(List<string> errors) => new(false, default, errors, 404);
    }
}
