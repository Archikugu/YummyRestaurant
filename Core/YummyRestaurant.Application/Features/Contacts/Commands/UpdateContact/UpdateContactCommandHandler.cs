using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IGenericRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public UpdateContactCommandHandler(IGenericRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request.UpdateContactDto);
        _repository.Update(contact);
        await Task.CompletedTask;
    }
}
