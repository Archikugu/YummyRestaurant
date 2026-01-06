using AutoMapper;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Application.DTOs.MessageDTOs;
using YummyRestaurant.Application.DTOs.ProductDTOs;
using YummyRestaurant.Application.DTOs.BookingDTOs;
using YummyRestaurant.Application.DTOs.PhotoGalleryDTOs;
using YummyRestaurant.Application.DTOs.ServiceDTOs;
using YummyRestaurant.Application.DTOs.TestimonialDTOs;
using YummyRestaurant.Application.DTOs.RestaurantEventDTOs;
using YummyRestaurant.Application.Features.RestaurantEvents.Commands.CreateRestaurantEvent;
using YummyRestaurant.Application.Features.RestaurantEvents.Commands.UpdateRestaurantEvent;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Application.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Chef, ResultChefDto>().ReverseMap();
        CreateMap<Chef, CreateChefDto>().ReverseMap();
        CreateMap<Chef, UpdateChefDto>().ReverseMap();
        CreateMap<Chef, GetByIdChefDto>().ReverseMap();

        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
        CreateMap<Contact, GetByIdContactDto>().ReverseMap();

        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, GetByIdMessageDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();

        CreateMap<Booking, ResultBookingDto>().ReverseMap();
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
        CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        CreateMap<Booking, GetByIdBookingDto>().ReverseMap();

        CreateMap<PhotoGallery, ResultPhotoGalleryDto>().ReverseMap();
        CreateMap<PhotoGallery, CreatePhotoGalleryDto>().ReverseMap();
        CreateMap<PhotoGallery, UpdatePhotoGalleryDto>().ReverseMap();
        CreateMap<PhotoGallery, GetByIdPhotoGalleryDto>().ReverseMap();

        CreateMap<Service, ResultServiceDto>().ReverseMap();
        CreateMap<Service, CreateServiceDto>().ReverseMap();
        CreateMap<Service, UpdateServiceDto>().ReverseMap();
        CreateMap<Service, GetByIdServiceDto>().ReverseMap();

        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();

         CreateMap<RestaurantEvent, ResultRestaurantEventDto>().ReverseMap();
        CreateMap<RestaurantEvent, CreateRestaurantEventDto>().ReverseMap();
        CreateMap<RestaurantEvent, UpdateRestaurantEventDto>().ReverseMap();
        CreateMap<RestaurantEvent, GetByIdRestaurantEventDto>().ReverseMap();
        CreateMap<RestaurantEvent, CreateRestaurantEventCommand>().ReverseMap();
        CreateMap<RestaurantEvent, UpdateRestaurantEventCommand>().ReverseMap();
    }
}
