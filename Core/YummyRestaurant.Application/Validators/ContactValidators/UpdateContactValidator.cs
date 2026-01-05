using FluentValidation;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Validators.ContactValidators;

public class UpdateContactValidator : AbstractValidator<UpdateContactDto>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş geçilemez.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş geçilemez.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Lokasyon bilgisi boş geçilemez.");
    }
}
