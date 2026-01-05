using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Chefs.Commands.UpdateChef;

public class UpdateChefCommandHandler : IRequestHandler<UpdateChefCommand>
{
    private readonly IGenericRepository<Chef> _repository;
    private readonly IMapper _mapper;

    public UpdateChefCommandHandler(IGenericRepository<Chef> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateChefCommand request, CancellationToken cancellationToken)
    {
        var chef = _mapper.Map<Chef>(request.UpdateChefDto);
        _repository.Update(chef);
        await Task.CompletedTask;
    }
}
