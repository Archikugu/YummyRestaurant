using Microsoft.EntityFrameworkCore;
using YummyRestaurant.Application.Abstract;

using YummyRestaurant.Persistence.Context;
using YummyRestaurant.Persistence.Repositories;
using Scalar.AspNetCore;
using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;
using YummyRestaurant.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace YummyRestaurant.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // FluentValidation
        builder.Services.AddValidatorsFromAssemblyContaining<YummyRestaurant.Application.Validators.CategoryValidators.CreateCategoryValidator>();

        // Database Context
        builder.Services.AddDbContext<YummyRestaurantContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Dependency Injection
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IRestaurantEventRepository, RestaurantEventRepository>();

        
        // AutoMapper
        builder.Services.AddAutoMapper(cfg => cfg.AddProfile<GeneralMapping>());

        // MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(YummyRestaurant.Application.Mapping.GeneralMapping).Assembly));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
