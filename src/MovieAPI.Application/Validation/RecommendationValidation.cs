using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class RecommendationValidation : AbstractValidator<Recommendation>
    {
        public RecommendationValidation() 
        {
            RuleFor(recommendation => recommendation.RecommendationText)
            .NotEmpty().WithMessage("Recommendation Text is required.")
            .Length(10, 1000).WithMessage("Recommendation Text must be between 10 and 1000 characters.")
            .Matches("^[a-zA-Z0-9\\s\\-',.!?]+$").WithMessage("Recommendation Text can only contain letters, numbers, spaces, and basic punctuation.");

            RuleFor(recommendation => recommendation.RecommendationDate)
            .NotEmpty().WithMessage("Recommendation Date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Recommendation Date must be in the past or present.")
            .Must(date => date >= DateTime.Now.AddYears(-1)).WithMessage("Recommendation Date must be within the last year.");

        }
    }
}
