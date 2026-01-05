using MediatR;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQuery : IRequest<GetByIdContactDto>
{
    public int Id { get; set; }

    public GetContactByIdQuery(int id)
    {
        Id = id;
    }
}
