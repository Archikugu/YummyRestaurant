using FluentValidation;
using YummyRestaurant.Application.DTOs.FeatureDTOs;

namespace YummyRestaurant.Application.Validators.FeatureValidators;

public class UpdateFeatureValidator : AbstractValidator<UpdateFeatureDto>
{
    public UpdateFeatureValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş geçilemez.")
            .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir.");
            
        RuleFor(x => x.SubTitle)
            .NotEmpty().WithMessage("Alt başlık boş geçilemez.")
            .MinimumLength(5).WithMessage("Alt başlık en az 5 karakter olmalıdır.");
            
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş geçilemez.");
    }
}
