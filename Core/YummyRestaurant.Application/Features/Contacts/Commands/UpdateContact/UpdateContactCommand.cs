using MediatR;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommand : IRequest
{
    public UpdateContactDto UpdateContactDto { get; set; }

    public UpdateContactCommand(UpdateContactDto updateContactDto)
    {
        UpdateContactDto = updateContactDto;
    }
}
