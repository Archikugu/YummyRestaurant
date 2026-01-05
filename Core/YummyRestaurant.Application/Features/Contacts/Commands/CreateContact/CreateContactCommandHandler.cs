using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
{
    private readonly IGenericRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public CreateContactCommandHandler(IGenericRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request.CreateContactDto);
        await _repository.AddAsync(contact);
    }
}
