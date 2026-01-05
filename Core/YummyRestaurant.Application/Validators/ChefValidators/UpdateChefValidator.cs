using FluentValidation;
using YummyRestaurant.Application.DTOs.ChefDTOs;

namespace YummyRestaurant.Application.Validators.ChefValidators;

public class UpdateChefValidator : AbstractValidator<UpdateChefDto>
{
    public UpdateChefValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("ID boş olamaz.");
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Şef adı boş geçilemez.")
            .MinimumLength(2).WithMessage("Şef adı en az 2 karakter olmalıdır.");
            
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Şef soyadı boş geçilemez.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş geçilemez.")
            .MaximumLength(500).WithMessage("Açıklama çok uzun.");
    }
}
