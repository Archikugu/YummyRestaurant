using AutoMapper;
using MediatR;
using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Features.Services.Commands.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IGenericRepository<Service> _repository;
    private readonly IMapper _mapper;

    public CreateServiceCommandHandler(IGenericRepository<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request.CreateServiceDto);
        await _repository.AddAsync(service);
    }
}
