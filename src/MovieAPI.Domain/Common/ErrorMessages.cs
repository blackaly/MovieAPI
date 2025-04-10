using MovieAPI.src.MovieAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.src.MovieAPI.Domain.Common
{
    public static class ErrorMessages
    {
        public static readonly Dictionary<ErrorCodes, string> Messages = new Dictionary<ErrorCodes, string>()
        {
             { ErrorCodes.NotFound, "The requested resource was not found." },
             { ErrorCodes.AlreadyExists, "The resource already exists in the system." },
             { ErrorCodes.IdMismatch, "The provided ID does not match the expected resource ID." },
             { ErrorCodes.ResourceNotFound, "The requested resource with the given ID was not found." },
             { ErrorCodes.NotExist, "The resource not exist in the system." },
             { ErrorCodes.ValidationFailed, "One or more validation errors occurred." },
             { ErrorCodes.Unauthorized, "You are not authorized to perform this action." },
             { ErrorCodes.Forbidden, "You do not have permission to access this resource." },
             { ErrorCodes.InternalError, "An unexpected error occurred. Please try again later." }
        };
        public static string GetMessage(ErrorCodes code) => Messages.TryGetValue(code, out var message) ? message : "Unknown error occurred.";
    }
}
