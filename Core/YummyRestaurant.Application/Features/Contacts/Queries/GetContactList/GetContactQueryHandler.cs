using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Contacts.Queries.GetContactList;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<ResultContactDto>>
{
    private readonly IGenericRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public GetContactQueryHandler(IGenericRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResultContactDto>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return _mapper.Map<List<ResultContactDto>>(values);
    }
}
