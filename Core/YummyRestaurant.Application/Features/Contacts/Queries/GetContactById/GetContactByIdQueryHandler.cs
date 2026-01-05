using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetByIdContactDto>
{
    private readonly IGenericRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public GetContactByIdQueryHandler(IGenericRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetByIdContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetByIdContactDto>(value);
    }
}
