using FluentValidation;
using MovieAPI.src.MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Validation
{
    public class DirectorValidation : AbstractValidator<Director>
    {
        public DirectorValidation() 
        { 
            RuleFor(x => x.FirstName).NotEmpty()
            .WithMessage("{Property Name} is required")
            .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("First Name can only contain letters.");

            RuleFor(x => x.LastName).NotEmpty()
            .WithMessage("Last Name is required")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("Last Name can only contain letters.");

            RuleFor(x => x.Country)
            .MaximumLength(100).WithMessage("Country must be less than 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.Country));

            RuleFor(x => x.ProfilePicture)
            .MaximumLength(200).WithMessage("Profile Picture URL must be less than 200 characters.")
            .When(director => !string.IsNullOrEmpty(director.ProfilePicture));

            RuleFor(x => x.Bio)
            .MaximumLength(1000).WithMessage("Bio must be less than 1000 characters.")
            .When(x => !string.IsNullOrEmpty(x.Bio));

            RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .Must(ValidBirthDay).WithMessage("Date of Birth must be in the past.");
        }

        public bool ValidBirthDay(DateTime date)
        {
            int now = DateTime.Now.Year;
            int past = date.Year;

            return past <= now && past > (now - 120);
        }
    }
}
