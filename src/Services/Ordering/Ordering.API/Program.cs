using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//add services to the container

//-------------------
//Infrastructure - EF Core
//Application - MediatR
//API - Carter

//builder.Services
//  .AddApplicationServices()
//  .AddInfrastructureServices(builder.Configuration)
//  .AddWebServices
//--------------------

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

//configure the http request pipeline


app.Run();
