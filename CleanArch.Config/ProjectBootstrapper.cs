
using CleanArch.Application.Products;
using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Application.Shared;
using CleanArch.Contracts;
using CleanArch.Domain.OrdersAgg.Repository;
using CleanArch.Domain.OrdersAgg.Services;
using CleanArch.Domain.Products.Repository;
using CleanArch.Domain.UsersAgg.Repository;
using CleanArch.Infrastructure;
using CleanArch.Infrastructure.Persistent.EF;
using CleanArch.Infrastructure.Persistent.EF.Users;
using CleanArch.Infrastructure.Persistent.Memory;
using CleanArch.Infrastructure.Persistent.Memory.Orders;
using CleanArch.Infrastructure.Persistent.Memory.Products;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using CleanArch.Query.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<IProductReadRepository,ProductReadRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddMediatR(typeof(EditProductCommand).Assembly);
            services.AddMediatR(typeof(GetProductByIdQuery).Assembly);
            services.AddMediatR(typeof(GetProductListQuery).Assembly);

            services.AddDbContext<AddDbContext>(option =>
                        {
                            option.UseSqlServer(connectionstring);
                        });
            services.AddSingleton<IMongoClient, MongoClient>(option =>
             {
                 return new MongoClient("connectionstring");
             });
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}
