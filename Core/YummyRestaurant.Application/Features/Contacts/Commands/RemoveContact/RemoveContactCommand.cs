using MediatR;

namespace YummyRestaurant.Application.Features.Contacts.Commands.RemoveContact;

public class RemoveContactCommand : IRequest
{
    public int Id { get; set; }

    public RemoveContactCommand(int id)
    {
        Id = id;
    }
}
