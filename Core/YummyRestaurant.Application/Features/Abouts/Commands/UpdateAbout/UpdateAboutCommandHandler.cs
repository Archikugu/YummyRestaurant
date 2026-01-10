using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Abouts.Commands.UpdateAbout;

public class UpdateAboutCommandHandler(IGenericRepository<About> _repository, IMapper _mapper) : IRequestHandler<UpdateAboutCommand>
{
    public Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        var value = _mapper.Map<About>(request.UpdateAboutDto);
        _repository.Update(value);
        return Task.CompletedTask;
    }
}
