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
using YummyRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using YummyRestaurant.Application.Extensions;

namespace YummyRestaurant.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(options => 
        {
            options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });
        // Distributed Cache (In-Memory)
        builder.Services.AddDistributedMemoryCache();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // Database Context
        builder.Services.AddDbContext<YummyRestaurantContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Dependency Injection
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IRestaurantEventRepository, RestaurantEventRepository>();
        builder.Services.AddScoped<IJwtService, YummyRestaurant.Persistence.Services.JwtService>();
        builder.Services.AddScoped<ITransactionService, YummyRestaurant.Persistence.Services.TransactionService>();

        // Identity
        builder.Services.AddIdentity<YummyRestaurant.Domain.Entities.AppUser, YummyRestaurant.Domain.Entities.AppRole>()
            .AddEntityFrameworkStores<YummyRestaurantContext>()
            .AddDefaultTokenProviders();

        // JWT Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var key = builder.Configuration["JwtSettings:Key"];
            if (string.IsNullOrEmpty(key)) throw new InvalidOperationException("JwtSettings:Key is missing");

            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key))
            };
        });

        // Application Services (AOP, Mediator, Validators, AutoMapper)
        builder.Services.AddApplicationServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
