using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Abouts.Commands.CreateAbout;

public class CreateAboutCommandHandler(IGenericRepository<About> _repository, IMapper _mapper) : IRequestHandler<CreateAboutCommand>
{
    public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        var value = _mapper.Map<About>(request.CreateAboutDto);
        await _repository.AddAsync(value);
    }
}
