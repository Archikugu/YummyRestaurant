using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Abouts.Commands.RemoveAbout;

public class RemoveAboutCommandHandler(IGenericRepository<About> _repository) : IRequestHandler<RemoveAboutCommand>
{
    public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            _repository.Remove(value);
        }
    }
}
