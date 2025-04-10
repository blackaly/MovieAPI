using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class SeriesValidation : AbstractValidator<Series>
    {
        public SeriesValidation() 
        {
            RuleFor(movie => movie.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 100).WithMessage("Title must be between 2 and 100 characters.")
            .Matches("^[a-zA-Z0-9\\s\\-',.!?]+$").WithMessage("Title can only contain letters, numbers, spaces, and basic punctuation.");

            RuleFor(movie => movie.ReleaseYear)
            .NotEmpty().WithMessage("Release Year is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Release Year must be in the past or present.");

            RuleFor(movie => movie.Synopsis)
            .NotEmpty().WithMessage("Synopsis is required.")
            .Length(10, 1000).WithMessage("Synopsis must be between 10 and 1000 characters.");

            RuleFor(movie => movie.PosterImage)
            .NotEmpty().WithMessage("Poster Image is required.");


            RuleFor(movie => movie.TrailerVideoURL)
            .NotEmpty().WithMessage("Trailer Video URL is required.")
            .Matches(@"^(http|https)://[^\s]+$").WithMessage("Trailer Video URL must be a valid URL.");

            RuleFor(movie => movie.RuntimeperEpisode)
           .NotEmpty().WithMessage("Runtime per Episode is required.")
           .Matches(@"^\d+\s(min|minutes|hr|hours)$").WithMessage("Runtime per Episode must be in the format 'X min' or 'X hr'.");

            RuleFor(movie => movie.Language)
            .NotEmpty().WithMessage("Language is required.")
            .Matches("^[a-zA-Z\\s]+$").WithMessage("Language can only contain letters and spaces.");

            RuleFor(movie => movie.ProductionStudio)
            .NotEmpty().WithMessage("Production Studio is required.")
            .Length(2, 100).WithMessage("Production Studio must be between 2 and 100 characters.");

            RuleFor(movie => movie.Budget)
            .NotEmpty().WithMessage("Budget is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Budget must be greater than or equal to 0.");

            RuleFor(movie => movie.BoxOfficeRevenue)
            .NotEmpty().WithMessage("Box Office Revenue is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Box Office Revenue must be greater than or equal to 0.");

        }
    }
}
