using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Services.Commands.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IGenericRepository<Service> _repository;
    private readonly IMapper _mapper;

    public UpdateServiceCommandHandler(IGenericRepository<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request.UpdateServiceDto);
        _repository.Update(service);
        await Task.CompletedTask;
    }
}
