using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Mappings;
using NzWalksApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); // Needed for minimal APIs or annotations
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NzWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalksConnectionString"))); // Dependency Injection

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>(); 
builder.Services.AddScoped<IWalksRepository, SQLWalksRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI(); // Enable middleware to serve Swagger UI.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
