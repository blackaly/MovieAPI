using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class EposideValidation : AbstractValidator<Eposide>
    {
        public EposideValidation() 
        {
            RuleFor(episode => episode.EposideName)
            .NotEmpty().WithMessage("Episode Name is required.")
            .Length(2, 100).WithMessage("Episode Name must be between 2 and 100 characters.")
            .Matches("^[a-zA-Z0-9\\s\\-',.!?]+$").WithMessage("Episode Name can only contain letters, numbers, spaces, and basic punctuation.");

            RuleFor(episode => episode.EposideDiscription)
            .MaximumLength(700).WithMessage("Episode Description must be less than 500 characters.")
            .When(episode => !string.IsNullOrEmpty(episode.EposideDiscription));
        }
    }
}
