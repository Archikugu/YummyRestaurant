using FluentValidation;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;

namespace YummyRestaurant.Application.Validators.RestaurantEventValidators
{
    public class UpdateRestaurantEventValidator : AbstractValidator<UpdateRestaurantEventDto>
    {
        public UpdateRestaurantEventValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID alanı boş olamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez.");
        }
    }
}
