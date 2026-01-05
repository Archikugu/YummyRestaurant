using MediatR;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;

namespace YummyRestaurant.Application.Features.Testimonials.Queries.GetTestimonialList;

public class GetTestimonialQuery : IRequest<List<ResultTestimonialDto>>
{
}
