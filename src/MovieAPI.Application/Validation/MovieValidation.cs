using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class MovieValidation : AbstractValidator<Movie>
    {
        public MovieValidation()
        {
            RuleFor(movie => movie.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 100).WithMessage("Title must be between 2 and 100 characters.")
            .Matches("^[a-zA-Z0-9\\s\\-',.!?]+$").WithMessage("Title can only contain letters, numbers, spaces, and basic punctuation.");

            RuleFor(movie => movie.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must be less than 1000 characters.");

            RuleFor(movie => movie.Date)
           .NotEmpty().WithMessage("Date is required.")
           .LessThanOrEqualTo(DateTime.Now).WithMessage("Date must be in the past or present.");

            RuleFor(movie => movie.StoreLine)
            .MaximumLength(1000).WithMessage("Store Line must be less than 1000 characters.")
            .When(movie => !string.IsNullOrEmpty(movie.StoreLine));

            RuleFor(movie => movie.Poster)
            .NotEmpty().WithMessage("Poster is required.")
            .Must(BeAValidPoster).WithMessage("Poster must be a valid image file.");
        }

        private bool BeAValidPoster(byte[] poster)
        {
            return poster != null || poster.Length > 0;
        }
    }
}
