using MediatR;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactCommand : IRequest
{
    public CreateContactDto CreateContactDto { get; set; }

    public CreateContactCommand(CreateContactDto createContactDto)
    {
        CreateContactDto = createContactDto;
    }
}
