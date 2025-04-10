using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class GenreValidation : AbstractValidator<Genre>
    {
        public GenreValidation() 
        {
            RuleFor(x => x.Name).NotEmpty()
            .WithMessage("{Property Name} is required")
            .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("First Name can only contain letters.");
        }
    }
}
