using MediatR;
using YummyRestaurant.Application.DTOs.ContactDTOs;

namespace YummyRestaurant.Application.Features.Contacts.Queries.GetContactList;

public class GetContactQuery : IRequest<List<ResultContactDto>>
{
}
