using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class ReviewValidation : AbstractValidator<Review>
    {
        public ReviewValidation() 
        {
            RuleFor(review => review.ReviewText)
            .NotEmpty().WithMessage("Review Text is required.")
            .Length(10, 1000).WithMessage("Review Text must be between 10 and 1000 characters.")
            .Matches("^[a-zA-Z0-9\\s\\-',.!?]+$").WithMessage("Review Text can only contain letters, numbers, spaces, and basic punctuation.");

            RuleFor(review => review.ReviewDate)
            .NotEmpty().WithMessage("Review Date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Review Date must be in the past or present.")
            .Must(date => date >= DateTime.Now.AddYears(-1)).WithMessage("Review Date must be within the last year.");
        }
    }
}
