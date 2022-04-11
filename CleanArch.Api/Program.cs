using CleanArch.Api;
using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Application.Shared;
using CleanArch.Application.Users;
using CleanArch.Config;
using CleanArch.Contracts;
using CleanArch.Domain.OrdersAgg.Repository;
using CleanArch.Domain.Products.Repository;
using CleanArch.Domain.UsersAgg;
using CleanArch.Domain.UsersAgg.Repository;
using CleanArch.Infrastructure;
using CleanArch.Infrastructure.Persistent.EF;
using CleanArch.Infrastructure.Persistent.EF.Orders;
using CleanArch.Infrastructure.Persistent.EF.Products;
using CleanArch.Infrastructure.Persistent.EF.Users;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Models.Users.Repository;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using CleanArch.Query.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//ProjectBootstrapper.Init(builder.Services,builder.Configuration.GetConnectionString("DefaultConnection"));

void ConfigureServices(IServiceCollection services, string connectionStrings)
{
    services.AddTransient<IUserDomainServices, UserDomainService>();

    services.AddTransient<IProductRepository, ProductRepository>();
    services.AddTransient<IUserRepository, UserRepository>();
    services.AddTransient<IOrderRepository, OrderRepository>();
    services.AddTransient<IProductReadRepository, ProductReadRepository>();
    services.AddTransient<IUserReadRepository, UserReadRepository>();

    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

    services.AddMediatR(typeof(CreateProductCommand).Assembly);
    //services.AddMediatR(typeof(EditProductCommand).Assembly);
    services.AddMediatR(typeof(GetProductByIdQuery).Assembly);
    //services.AddMediatR(typeof(GetProductListQuery).Assembly);

    services.AddDbContext<AddDbContext>(option =>
    {
        option.UseSqlServer(connectionStrings);
    });
    services.AddSingleton<IMongoClient, MongoClient>(option =>
    {
        return new MongoClient("mongodb://localhost:27017");
    });
    services.AddScoped<ISmsService, SmsService>();
    
}
builder.Services.AddAuthentication(option =>
{
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"])),
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateLifetime = true,
        ValidateIssuer = true ,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true
    };
});
ConfigureServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
