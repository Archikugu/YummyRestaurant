using FluentValidation;
using YummyRestaurant.Application.DTOs.ServiceDTOs;

namespace YummyRestaurant.Application.Validators.ServiceValidators;

public class UpdateServiceValidator : AbstractValidator<UpdateServiceDto>
{
    public UpdateServiceValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Icon URL cannot be empty");
    }
}
