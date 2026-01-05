using FluentValidation;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;

namespace YummyRestaurant.Application.Validators.PhotoGalleryValidators;

public class UpdatePhotoGalleryValidator : AbstractValidator<UpdatePhotoGalleryDto>
{
    public UpdatePhotoGalleryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image URL cannot be empty");
    }
}
