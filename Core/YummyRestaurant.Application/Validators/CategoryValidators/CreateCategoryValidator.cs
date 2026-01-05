using FluentValidation;
using YummyRestaurant.Application.DTOs.CategoryDTOs;

namespace YummyRestaurant.Application.Validators.CategoryValidators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");
            
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş geçilemez.")
            .MinimumLength(5).WithMessage("Açıklama en az 5 karakter olmalıdır.");
    }
}
