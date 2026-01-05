using FluentValidation;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Validators.PhotoGalleryValidators;

public class CreatePhotoGalleryValidator : AbstractValidator<CreatePhotoGalleryDto>
{
    public CreatePhotoGalleryValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image URL cannot be empty");
    }
}
