using ApiRestaurante.Core.Application;
using ApiRestaurante.Infrastructure.Identity;
using ApiRestaurante.Infrastructure.Identity.Entities;
using ApiRestaurante.Infrastructure.Identity.Seeds;
using ApiRestaurante.Infrastructure.Persistence;
using ApiRestaurante.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using StockApp.Infrastructure.Identity.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddCoreApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
        await DefaultMeseroUser.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
