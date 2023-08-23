using Microsoft.EntityFrameworkCore;
using Permission.Persistence;
using Permission.Application.Handlers;
using Permission.Domain.Interfaces;
using Permission.Persistence.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreatePermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IGetallPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IGetallPermissionTypesRepository, PermissionRepository>();
builder.Services.AddScoped<IUpdatePermissionRepository, PermissionRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(CreatePermissionHandler).Assembly,
        typeof(GetAllPermissionHandler).Assembly,
        typeof(GetAllPermissionTypesHandler).Assembly,
        typeof(UpdatePermissionHandler).Assembly
    )
);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("permissionsConnection"),
        b => b.MigrationsAssembly("Permission.Api")
    )
);

builder.Services.AddCors(options => 
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
