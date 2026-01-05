using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Chefs.Commands.CreateChef;

public class CreateChefCommandHandler : IRequestHandler<CreateChefCommand>
{
    private readonly IGenericRepository<Chef> _repository;
    private readonly IMapper _mapper;

    public CreateChefCommandHandler(IGenericRepository<Chef> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateChefCommand request, CancellationToken cancellationToken)
    {
        var chef = _mapper.Map<Chef>(request.CreateChefDto);
        await _repository.AddAsync(chef);
    }
}
