using AutoMapper;
using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.DTOs.ChefDTOs;
using YummyRestaurant.Application.DTOs.ContactDTOs;
using YummyRestaurant.Application.DTOs.FeatureDTOs;
using YummyRestaurant.Application.DTOs.MessageDTOs;
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
    }
}
