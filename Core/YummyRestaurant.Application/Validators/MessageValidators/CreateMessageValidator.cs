using FluentValidation;
using YummyRestaurant.Application.DTOs.MessageDTOs;

namespace YummyRestaurant.Application.Validators.MessageValidators;

public class CreateMessageValidator : AbstractValidator<CreateMessageDto>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş geçilemez.")
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.");
            
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş geçilemez.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş geçilemez.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Konu boş geçilemez.")
            .MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır.");

        RuleFor(x => x.MessageContent)
            .NotEmpty().WithMessage("Mesaj içeriği boş geçilemez.")
            .MaximumLength(1000).WithMessage("Mesaj çok uzun.");
    }
}
