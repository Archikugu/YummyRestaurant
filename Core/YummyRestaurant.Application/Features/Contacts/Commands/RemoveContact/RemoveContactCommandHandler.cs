using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Contacts.Commands.RemoveContact;

public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
{
    private readonly IGenericRepository<Contact> _repository;

    public RemoveContactCommandHandler(IGenericRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
