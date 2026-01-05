using FluentValidation;
using YummyRestaurant.Application.DTOs.BookingDTOs;

namespace YummyRestaurant.Application.Validators.BookingValidators;

public class UpdateBookingValidator : AbstractValidator<UpdateBookingDto>
{
    public UpdateBookingValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty").EmailAddress().WithMessage("Invalid email format");
        RuleFor(x => x.ReservationDate).NotEmpty().WithMessage("Date cannot be empty");
        RuleFor(x => x.PersonCount).GreaterThan((byte)0).WithMessage("Person count must be greater than 0");
    }
}
