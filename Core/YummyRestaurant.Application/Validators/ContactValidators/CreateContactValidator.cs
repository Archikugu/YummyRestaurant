using FluentValidation;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Validators.ContactValidators;

public class CreateContactValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş geçilemez.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş geçilemez.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Lokasyon bilgisi boş geçilemez.");
    }
}
