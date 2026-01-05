using FluentValidation;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.Application.Validators.ProductValidators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ürün adı boş geçilemez.")
            .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.");
            
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş geçilemez.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Geçerli bir kategori seçiniz.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Görsel yolu boş geçilemez.");
    }
}
