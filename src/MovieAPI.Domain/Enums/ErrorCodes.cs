using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.src.MovieAPI.Domain.Enums
{
    public enum ErrorCodes : byte
    {
        NotFound,
        AlreadyExists,
        NotExist,
        ValidationFailed,
        Unauthorized,
        Forbidden,
        InternalError,
        IdMismatch,
        ResourceNotFound
    }
}
