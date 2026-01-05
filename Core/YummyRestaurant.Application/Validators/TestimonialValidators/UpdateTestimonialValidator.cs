using FluentValidation;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Validators.TestimonialValidators;

public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
{
    public UpdateTestimonialValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment cannot be empty");
    }
}
