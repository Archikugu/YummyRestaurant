using MediatR;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialById;

public class GetTestimonialByIdQuery : IRequest<GetByIdTestimonialDto>
{
    public int Id { get; set; }

    public GetTestimonialByIdQuery(int id)
    {
        Id = id;
    }
}
