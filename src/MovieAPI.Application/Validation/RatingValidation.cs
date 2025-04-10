using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class RatingValidation : AbstractValidator<Rating>
    {
        public RatingValidation() 
        {
            RuleFor(rating => rating.RatingScore)
            .NotEmpty().WithMessage("Rating Score is required.")
            .InclusiveBetween(0, 10).WithMessage("Rating Score must be between 0 and 10.")
            .Must(score => score % 0.5m == 0).WithMessage("Rating Score must be in increments of 0.5.");

            RuleFor(rating => rating.RatingDate)
            .NotEmpty().WithMessage("Rating Date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Rating Date must be in the past or present.")
            .Must(date => date >= DateTime.Now.AddYears(-1)).WithMessage("Rating Date must be within the last year.");
        }

    }
}
