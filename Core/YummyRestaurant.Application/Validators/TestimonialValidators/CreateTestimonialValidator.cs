using FluentValidation;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Validators.TestimonialValidators;

public class CreateTestimonialValidator : AbstractValidator<CreateTestimonialDto>
{
    public CreateTestimonialValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment cannot be empty");
    }
}
