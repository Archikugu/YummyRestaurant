using MediatR;

namespace YummyRestaurant.Application.Features.Abouts.Commands.RemoveAbout;

public class RemoveAboutCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
